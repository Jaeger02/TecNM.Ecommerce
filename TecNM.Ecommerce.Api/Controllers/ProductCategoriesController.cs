using Microsoft.AspNetCore.Mvc;
using TecNM.Ecommerce.Api.Repositories.Interfaces;
using TecNM.Ecommerce.Api.Services.Interfaces;
using TecNM.Ecommerce.Core.Dto;
using TecNM.Ecommerce.Core.Entities;
using TecNM.Ecommerce.Core.Http;

namespace TecNM.Ecommerce.Api.Controllers;

[ApiController]
[Route("api/[Controller]")]
public class ProductCategoriesController : ControllerBase
{
    //private readonly IProductCategoryRepository _productCategoryRepository;
    private readonly IProductCategoryService _productCategoryService;
    
    public ProductCategoriesController(IProductCategoryService productCategoryService)
    {
        _productCategoryService = productCategoryService;
    }
    
    //Estrucutura para visualizar en swager
    [HttpGet]
    //public async Task<ActionResult<Response<List<ProductCategory>>>> GetAll()
    public async Task<ActionResult<Response<List<ProductCategoryDto>>>> GetAll()
    {
        
        //var categories = await _productCategoryRepository.GetAllAsync();
        var response = new Response<List<ProductCategoryDto>>
        {
            Data = await _productCategoryService.GetAllAsync()
        };
        //response.Data = categories.Select(c=> new ProductCategoryDto(c)).ToList();
        //response.Data = categories;
        
        return Ok(response);
        /*var list = new List<ProductCategory>();
        list.Add(new ProductCategory{Id=1, Name="Test", Description="Test"});
        list.Add(new ProductCategory{Id=2, Name="Test2", Description="Test2"});

        var response = new Response<List<ProductCategory>>();
        response.Data = list;
        return Ok(response);*/
    }
    //saveAsync
    [HttpPost]
    public async Task<ActionResult<Response<ProductCategoryDto>>> Post([FromBody] ProductCategoryDto categoryDto)
    {
        var response = new Response<ProductCategoryDto>
        {
            Data = await _productCategoryService.SaveAsync(categoryDto)
        };
        
        return Created($"/api/[controller]/{response.Data.Id}", response);
    }
    //getById
    [HttpGet]
    [Route("{id:int}")]
    public async Task<ActionResult<Response<ProductCategoryDto>>> GetById(int id)
    {
        //Usando Service
        var response = new Response<ProductCategoryDto>();
        
        if (!await _productCategoryService.ProductCategoryExist(id))
        {
            response.Errors.Add("Product Category Not Found");
            return NotFound(response);
        }
        
        response.Data = await _productCategoryService.GetById(id);
        return Ok(response);
        
        //Usando Repository
        /*var response = new Response<ProductCategoryDto>();
        var category = await _productCategoryRepository.GetById(id);
        if (category == null)
        {
            response.Errors.Add("Product Category Not Found");
            return NotFound(response);
        }

        var categoryDto = new ProductCategoryDto(category);
        response.Data = categoryDto;
        
        return Ok(response);*/
    }

    //actualizar
    /*[HttpPut]
    public async Task<ActionResult<Response<ProductCategory>>> Update([FromBody] ProductCategory category){
        var result = await _productCategoryRepository.UpdateAsync(category);
        var response = new Response<ProductCategory>{Data=result};

        return Ok(response);
    }*/
    [HttpPut]
    //[Route("{id:int}")]
    public async Task<ActionResult<Response<ProductCategoryDto>>> Update([FromBody] ProductCategoryDto categoryDto){
        //Usando Service
        var response = new Response<ProductCategoryDto>();
        if (!await _productCategoryService.ProductCategoryExist(categoryDto.Id))
        {
            response.Errors.Add("Product Category Not Found");
            return NotFound(response);
        }

        response.Data = await _productCategoryService.UpdateAsync(categoryDto);
        return Ok(response);

        //Usando repository
        //var category = await _productCategoryRepository.GetById(categoryDto.id);
        /*var category = await _productCategoryRepository.GetById(id);
        if (category == null)
        {
            response.Errors.Add("Product Category Not Found");
            return NotFound(response);
        }

        category.Name = categoryDto.Name;
        category.Description = categoryDto.Description;
        category.UpdatedBy = "";
        category.UpdateDate = DateTime.Now;

        category = await _productCategoryRepository.UpdateAsync(category);
        var categoryDtoResult = new ProductCategoryDto(category);
        response.Data = categoryDtoResult;

        return Ok(response);*/
    }

    [HttpDelete]
    [Route("{id:int}")]
    public async Task<ActionResult<Response<ProductCategory>>> Delete(int id)
    {
        var response = new Response<bool>();
        var result = await _productCategoryService.DeleteAsync(id);
        response.Data=result;
        return Ok(response);
    }

}