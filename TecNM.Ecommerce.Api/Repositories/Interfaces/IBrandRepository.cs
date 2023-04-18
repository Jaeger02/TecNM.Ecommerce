using TecNM.Ecommerce.Core.Entities;

namespace TecNM.Ecommerce.Api.Repositories.Interfaces;

public interface IBrandRepository
{
    //Método paara guardar categorias
    Task<Brand> SaveAsync(Brand brand);
    
    //Método para actualizar categorías de productos
    Task<Brand> UpdateAsync(Brand brand);
    
    //Método para retornar una lista de categorías
    Task<List<Brand>> GetAllAsync();
    
    //Método para retornar el id de las categorias que borrara
    Task<bool> DeleteAsync(int id);
    
    //Método para obtener una categoria por id
    Task<Brand> GetById(int id);
}