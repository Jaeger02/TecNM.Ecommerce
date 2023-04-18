using TecNM.Ecommerce.Core.Entities;

namespace TecNM.Ecommerce.Api.Repositories.Interfaces;

public interface IProductCategoryRepository
{
    //Método paara guardar categorias
    Task<ProductCategory> SaveAsync(ProductCategory category);
    
    //Método para actualizar categorías de productos
    Task<ProductCategory> UpdateAsync(ProductCategory category);
    
    //Método para retornar una lista de categorías
    Task<List<ProductCategory>> GetAllAsync();
    
    //Método para retornar el id de las categorias que borrara
    Task<bool> DeleteAsync(int id);
    
    //Método para obtener una categoria por id
    Task<ProductCategory> GetById(int id);
}