
using AutomaticInfotch_Assignment.Models;
using AutomaticInfotch_Assignment.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;

public class VendorsController : Controller
{
    private readonly IVendorRepository _repository;

    public VendorsController(IVendorRepository repository)
    {
        _repository = repository;
    }

    public async Task<IActionResult> Index()
    {
        var vendors = await _repository.GetAllVendorsAsync();
        return View(vendors);
    }

    public IActionResult Create()
    {
        var vendor = new Vendor
        {
            Code = $"VND-{Guid.NewGuid().ToString().Substring(0, 8)}"
        };
        return View(vendor);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Vendor vendor)
    {
        if (vendor.ValidTillDate <= DateTime.Now)
        {
            ModelState.AddModelError("ValidTillDate", "Valid Till Date must be a future date.");
            return View(vendor);
        }

        await _repository.AddVendorAsync(vendor);
        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Edit(string code)
    {
        var vendor = await _repository.GetVendorByCodeAsync(code);
        if (vendor == null) return NotFound();
        return View(vendor);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(Vendor vendor)
    {
        if (vendor.ValidTillDate <= DateTime.Now)
        {
            ModelState.AddModelError("ValidTillDate", "Valid Till Date must be a future date.");
            return View(vendor);
        }

        await _repository.UpdateVendorAsync(vendor);
        return RedirectToAction(nameof(Index));
    }
 /*   public async Task<IActionResult> Delete(string code)
    {
        bool isInUsed = await _repository.CheckIsInUsed(code);
        if (isInUsed)
            return RedirectToAction(nameof(Index));
        await _repository.DeleteVendorAsync(code);
        return RedirectToAction(nameof(Index));
    }*/


    
    [HttpPost]
    public async Task<IActionResult> Delete(string code)
    {
        bool isInUsed = await _repository.CheckIsInUsed(code);

        if (isInUsed)
        {
            return Ok( new { success = false, message = "This vendor is already in use and cannot be deleted." });
        }

        await _repository.DeleteVendorAsync(code);
        return Ok(new { success = true, message = "Vendor deleted successfully." });
    }


}