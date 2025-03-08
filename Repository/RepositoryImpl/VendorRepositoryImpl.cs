using AutomaticInfotch_Assignment.DataContext;
using AutomaticInfotch_Assignment.Models;
using AutomaticInfotch_Assignment.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace AutomaticInfotch_Assignment.Repository.RepositoryImpl
{
    public class VendorRepositoryImpl: IVendorRepository
    {
        private readonly ApplicationDataContext _context;

        public VendorRepositoryImpl(ApplicationDataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Vendor>> GetAllVendorsAsync()
        {
            return await _context.Vendors.ToListAsync();
        }

        public async Task<Vendor> GetVendorByCodeAsync(string code)
        {
            return await _context.Vendors.FirstOrDefaultAsync(v => v.Code == code);
        }

        public async Task AddVendorAsync(Vendor vendor)
        {
            try
            {
                await _context.Vendors.AddAsync(vendor);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while adding the vendor.", ex);
            }
        }

        public async Task UpdateVendorAsync(Vendor vendor)
        {
            try
            {
                _context.Vendors.Update(vendor);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while updating the vendor.", ex);
            }
        }

        public async Task DeleteVendorAsync(string code)
        {
            try
            {
                var vendor = await GetVendorByCodeAsync(code);
                if (vendor != null)
                {
                    _context.Vendors.Remove(vendor);
                    await _context.SaveChangesAsync();
                }
                else
                {
                    throw new Exception("Vendor not found.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while deleting the vendor.", ex);
            }
        }

        public async Task<bool> CheckIsInUsed(string code)
        {
            return _context.PurchaseOrders.Any(t => t.Vendor.Equals(code));
        }
    }
}
