using AutomaticInfotch_Assignment.DataContext;
using AutomaticInfotch_Assignment.Models;
using AutomaticInfotch_Assignment.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using static AutomaticInfotch_Assignment.Models.PurchaseOrder;

namespace AutomaticInfotch_Assignment.Repository.RepositoryImpl
{
    public class MaterialRepositoryImpl : IMaterialRepository
    {
        private readonly ApplicationDataContext _context;

        public MaterialRepositoryImpl(ApplicationDataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Material>> GetAllMaterialsAsync()
        {
            return await _context.Materials.ToListAsync();
        }

        public async Task<Material> GetMaterialByCodeAsync(string code)
        {
            return await _context.Materials.FirstOrDefaultAsync(m => m.Code == code);
        }

        public async Task AddMaterialAsync(Material material)
        {
            try
            {
                await _context.Materials.AddAsync(material);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                // Log exception or handle accordingly
                throw new Exception("An error occurred while adding the material.", ex);
            }
        }

        public async Task UpdateMaterialAsync(Material material)
        {
            try
            {
                _context.Materials.Update(material);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                // Log exception or handle accordingly
                throw new Exception("An error occurred while updating the material.", ex);
            }
        }

        public async Task DeleteMaterialAsync(string code)
        {
            try
            {
                var material = await GetMaterialByCodeAsync(code);
                if (material != null)
                {
                    _context.Materials.Remove(material);
                    await _context.SaveChangesAsync();
                }
                else
                {
                    throw new Exception("Material not found.");
                }
            }
            catch (Exception ex)
            {
                // Log exception or handle accordingly
                throw new Exception("An error occurred while deleting the material.", ex);
            }
        }

        public async Task<bool> CheckIsInUsed(string code)
        {
            return  _context.Set<LineItem>().Any(t => t.MaterialCode.Equals(code));
        }
    }
}
