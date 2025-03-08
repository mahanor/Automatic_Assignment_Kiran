using AutomaticInfotch_Assignment.Models;

namespace AutomaticInfotch_Assignment.Repository.IRepository
{
    public interface IMaterialRepository
    {
        Task<IEnumerable<Material>> GetAllMaterialsAsync();
        Task<Material> GetMaterialByCodeAsync(string code);
        Task AddMaterialAsync(Material material);
        Task UpdateMaterialAsync(Material material);
        Task DeleteMaterialAsync(string code);
        Task<bool> CheckIsInUsed(string code);
 
    }

}
