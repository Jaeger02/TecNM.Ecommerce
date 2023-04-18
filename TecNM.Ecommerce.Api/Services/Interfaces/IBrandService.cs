using TecNM.Ecommerce.Core.Dto;

namespace TecNM.Ecommerce.Api.Services.Interfaces;

public interface IBrandService
{
    //Método paara guardar categorias
    Task<BrandDto> SaveAsync(BrandDto brandDto);
    
    //Método para actualizar categorías de productos
    Task<BrandDto> UpdateAsync(BrandDto brandDto);
    
    //Método para retornar una lista de categorías
    Task<List<BrandDto>> GetAllAsync();
    
    //Método para retornar el id de las categorias que borrara
    Task<bool> DeleteAsync(int id);
    
    //Método para retornar el id de las categorias que borrara
    Task<bool> BrandExist(int id);
    
    //Método para obtener una categoria por id
    Task<BrandDto> GetById(int id);
}