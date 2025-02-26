using System.Net;
using System.Net.Mime;
using System.Reflection.Metadata;
using System.Text;
using BuildingBlock.Shared.Configs;
using BuildingBlock.Shared.Seeds;
using Clothes.Domain.Extensions;
using FluentValidation;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore.Storage;
using Serilog;
using Shared.Exceptions;

namespace Shared.Middlewares;

public class CustomErrorHandlerMiddleware(RequestDelegate next)
{
    public const string CustomErrorHandlerMiddlewareContext = nameof(CustomErrorHandlerMiddleware);
    
    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await next(context);

            switch (context.Response.StatusCode)
            {
                //Xử lí cho mã 400
                case 400:
                {
                    var response = context.Response;
                    response.ContentType = MediaTypeNames.Application.Json;
                    await response.WriteAsync(ApiFailedResult<object>.Instance.WithMessage(CodeResponseMessage.DataInValid).MySerialize());
                    
                    return;
                }

                // Xử lí cho mã 401
                case 401:
                {
                    var response = context.Response;
                    response.ContentType = MediaTypeNames.Application.Json;
                    await response.WriteAsync(ApiFailedResult<object>.Instance.WithMessage(CodeResponseMessage.TokenIsNull)
                        .MySerialize());
                    
                    return;
                }
                // Xử lí cho mã 403
                case 403:
                {
                    var response = context.Response;
                    response.ContentType = MediaTypeNames.Application.Json;
                    await response.WriteAsync(ApiFailedResult<object>.Instance.WithMessage(CodeResponseMessage.NotSystemAccessPermission).MySerialize());
                    
                    return;
                }
                // Xử lí cho mã 404
                case 404:
                {
                    var response = context.Response;
                    response.ContentType = MediaTypeNames.Application.Json;
                    await response.WriteAsync(ApiFailedResult<object>.Instance.WithMessage(CodeResponseMessage.PathIsNotExist).MySerialize());
                    
                    return;
                }
                // Xử lí cho mã 405
                case 405:
                {
                    var response = context.Response;
                    response.ContentType = MediaTypeNames.Application.Json;
                    await response.WriteAsync(ApiFailedResult<object>.Instance.WithMessage(CodeResponseMessage.MethodNotAllowed).MySerialize());
                    
                    return;
                }

                // Xử lí cho mã 500
                case 500:
                {
                    var response = context.Response;
                    response.ContentType = MediaTypeNames.Application.Json;
                    await response.WriteAsync(ApiFailedResult<object>.Instance.WithMessage(CodeResponseMessage.SystemError).MySerialize());
                    
                    return;
                }
            }
        }
        catch (ValidationException ex)
        {
            await HandleValidationException(context, ex);
        }
        catch (RetryLimitExceededException)
        {
            await HandleRetryLimitExceededException(context);
        }
        catch (InvalidCastException)
        {
            await HandleInvalidCastException(context);
        }
        catch (Exception error)
        {
            await HandleExceptionError(context, error);
        }
    }

    private Task HandleValidationException(HttpContext context, ValidationException ex)
    {
        var errors = ex.Errors
            .GroupBy(e => e.PropertyName)
            .Select(
                g => string.Format(ResponseMessageConfigs.GetMessage(CodeResponseMessage.ValidationException), g.Key)
            );

        var messageBuilder = new StringBuilder();
        var mesage = string.Join("", errors);
        messageBuilder.AppendLine(mesage.Replace("[", "").Replace("]", "").Replace(".", ","));
        messageBuilder.AppendLine(". Vui lòng quay lại sau vài phút!");

        var result = ApiFailedResult<object>.Instance.WithMessage(CodeResponseMessage.DataInValid, messageBuilder.ToString());

        var response = context.Response;
        response.ContentType = MediaTypeNames.Application.Json;
        response.StatusCode = StatusCodes.Status400BadRequest;
        return response.WriteAsync(result.MySerialize());
    }

    private Task HandleRetryLimitExceededException(HttpContext context)
    {
        HandleRetryLimitExceededException(context);
        var response = context.Response;
        response.ContentType = MediaTypeNames.Application.Json;
        ApiFailedResult<object> result;
            
        response.StatusCode = (int)HttpStatusCode.GatewayTimeout;
        result = ApiFailedResult<object>.Instance.WithMessage(CodeResponseMessage.DatabaseTimeout);
            
        return response.WriteAsync(result.MySerialize());
    }

    private Task HandleInvalidCastException(HttpContext context)
    {
        var response = context.Response;
        response.ContentType = MediaTypeNames.Application.Json;
        ApiFailedResult<object> result;
            
        response.StatusCode = (int)HttpStatusCode.BadRequest;
        result = ApiFailedResult<object>.Instance.WithMessage(CodeResponseMessage.ExcuteSqlQueryError);
            
        return response.WriteAsync(result.MySerialize());
    }

    private Task HandleExceptionError(HttpContext context, Exception error)
    {
        Log.ForContext(CustomErrorHandlerMiddlewareContext, context);
            
        var response = context.Response;
        response.ContentType = MediaTypeNames.Application.Json;
        ApiFailedResult<object> result;
            
        // Using switch for custom exception
        switch (error)
        {
            // Add custom exception code below!
            case TaskCanceledException ex1:
            case OperationCanceledException ex2:
                response.StatusCode = (int)HttpStatusCode.GatewayTimeout;
                result = new ApiFailedResult<object>(CodeResponseMessage.Timeout);
                break;
            case BadRequestException:
                response.StatusCode = (int)HttpStatusCode.BadRequest;
                result = new ApiFailedResult<object>(CodeResponseMessage.DataInValid);
                break;
            default:
                response.StatusCode = (int)HttpStatusCode.InternalServerError;
                result = new ApiFailedResult<object>(CodeResponseMessage.SystemError);
                break;
        }

        return response.WriteAsync(result.MySerialize()); 
    }
}

public static class CustomErrorHandlerMiddlewareExtensions
{
    public static IApplicationBuilder UseExceptionHandling(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<CustomErrorHandlerMiddleware>();
    }
}
