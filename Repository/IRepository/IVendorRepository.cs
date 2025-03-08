using AutomaticInfotch_Assignment.Models;

namespace AutomaticInfotch_Assignment.Repository.IRepository
{
    public interface IVendorRepository
    {
        Task<IEnumerable<Vendor>> GetAllVendorsAsync();
        Task<Vendor> GetVendorByCodeAsync(string code);
        Task AddVendorAsync(Vendor vendor);
        Task UpdateVendorAsync(Vendor vendor);
        Task DeleteVendorAsync(string code);
        Task<bool> CheckIsInUsed(string code);
    }
}
