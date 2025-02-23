using System.Net;
using System.Net.Mime;
using System.Text;
using Clothes.Application.Common.Exceptions;
using Clothes.Domain.Configs;
using Clothes.Domain.Extensions;
using Clothes.Infrastructure.Shared.Responses;
using FluentValidation;
using Microsoft.EntityFrameworkCore.Storage;
using Serilog;

namespace ClothesShop.API.Middlewares;

public class CustomErrorHandlerMiddleware(RequestDelegate next)
{
    public const string ErrorHandlerMiddlewareContext = nameof(CustomErrorHandlerMiddleware);

    
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
                    await response.WriteAsync(new ApiFailedResult<object>(CodeResponseMessage.PathIsNotExist).MySerialize());
                    
                    return;
                }
                // Xử lí cho mã 405
                case 405:
                {
                    var response = context.Response;
                    response.ContentType = MediaTypeNames.Application.Json;
                    await response.WriteAsync(new ApiFailedResult<object>(CodeResponseMessage.MethodNotAllowed).MySerialize());
                    
                    return;
                }

                // Xử lí cho mã 500
                case 500:
                {
                    var response = context.Response;
                    response.ContentType = MediaTypeNames.Application.Json;
                    await response.WriteAsync(new ApiFailedResult<object>(CodeResponseMessage.SystemError).MySerialize());
                    
                    return;
                }
            }
        }
        catch (ValidationException ex)
        {
            var errors = ex.Errors
                .GroupBy(e => e.PropertyName)
                .Select(
                    g => string.Format(ResponseMessageConfig.GetMessage(CodeResponseMessage.ValidationException), g.Key)
                );

            var messageBuilder = new StringBuilder();
            var mesage = string.Join("", errors);
            messageBuilder.AppendLine(mesage.Replace("[", "").Replace("]", "").Replace(".", ","));
            messageBuilder.AppendLine(". Vui lòng quay lại sau vài phút!");

            var result = ApiFailedResult<object>.Instance.WithMessage(CodeResponseMessage.DataInValid);

            var response = context.Response;
            response.ContentType = MediaTypeNames.Application.Json;
            response.StatusCode = StatusCodes.Status400BadRequest;
            await response.WriteAsync(result.MySerialize());

            throw;
        }
        catch (RetryLimitExceededException)
        {
            var response = context.Response;
            response.ContentType = MediaTypeNames.Application.Json;
            ApiFailedResult<object> result;
            
            response.StatusCode = (int)HttpStatusCode.GatewayTimeout;
            result = new(CodeResponseMessage.DatabaseTimeout);
            
            await response.WriteAsync(result.MySerialize());

            throw;
        }
        catch (InvalidCastException)
        {
            var response = context.Response;
            response.ContentType = MediaTypeNames.Application.Json;
            ApiFailedResult<object> result;
            
            response.StatusCode = (int)HttpStatusCode.BadRequest;
            result = new(CodeResponseMessage.ExcuteSqlQueryError);
            
            await response.WriteAsync(result.MySerialize());

            throw;
        }
        catch (Exception error)
        {
            Log.ForContext("SourceContext", context);
            
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

            await response.WriteAsync(result.MySerialize());
            
            throw;
        }
    }
}