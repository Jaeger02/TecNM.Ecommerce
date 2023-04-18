using TecNM.Ecommerce.Core.Dto;

namespace TecNM.Ecommerce.Api.Services.Interfaces;

public interface IProductCategoryService
{
    //Método paara guardar categorias
    Task<ProductCategoryDto> SaveAsync(ProductCategoryDto category);
    
    //Método para actualizar categorías de productos
    Task<ProductCategoryDto> UpdateAsync(ProductCategoryDto category);
    
    //Método para retornar una lista de categorías
    Task<List<ProductCategoryDto>> GetAllAsync();
    
    //Método para retornar el id de las categorias que borrara
    Task<bool> ProductCategoryExist(int id);
    
    //Método para retornar el id de las categorias que borrara
    Task<bool> DeleteAsync(int id);
    
    //Método para obtener una categoria por id
    Task<ProductCategoryDto> GetById(int id);
}