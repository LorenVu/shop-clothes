using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ClothesShop.API.Controllers.Cstomers;

[Route("api/v1/[controller]")]
public class CustomersController(IMediator mediator) : BaseController
{
    
}