using Business.Abstract;
using Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductController : ControllerBase
{

    private readonly IProductService _productService;

    public ProductController(IProductService productService)
    {
        _productService = productService;
    }

    [Authorize]
    [HttpGet]
    public IActionResult Get()
    {
        return Ok(_productService.GetAll());
    }

    [Authorize]
    [HttpGet("{id}")]
    public IActionResult GetByID(int id)
    {
        return Ok(_productService.GetById(id));
    }

    [HttpPost]
    [Authorize]
    public IActionResult Post(Product product)
    {
        return Ok(_productService.Add(product));
    }

}