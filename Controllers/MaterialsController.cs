
using AutomaticInfotch_Assignment.Models;
using AutomaticInfotch_Assignment.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;

public class MaterialsController : Controller
{
    private readonly IMaterialRepository _repository;

    public MaterialsController(IMaterialRepository repository)
    {
        _repository = repository;
    }


    public async Task<IActionResult> Index()
    {
        var materials = await _repository.GetAllMaterialsAsync();
        return View(materials);
    }

 
    public IActionResult Create()
    {
        var material = new Material
        {
            Code = $"MAT-{Guid.NewGuid().ToString().Substring(0, 8)}"
        };
        return View(material);
    }

   
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Material material)
    {
        if (ModelState.IsValid)
        {
            await _repository.AddMaterialAsync(material);
            return RedirectToAction(nameof(Index));
        }
        return View(material);
    }

    
    public async Task<IActionResult> Edit(string code)
    {
        var material = await _repository.GetMaterialByCodeAsync(code);
        if (material == null)
        {
            return NotFound();
        }
        return View(material);
    }

  
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(Material material)
    {
        if (ModelState.IsValid)
        {
            await _repository.UpdateMaterialAsync(material);
            return RedirectToAction(nameof(Index));
        }
        return View(material);
    }


    [HttpPost]
    public async Task<IActionResult> Delete(string code)
    {
     
        bool isInUsed = await _repository.CheckIsInUsed(code);

        if (isInUsed)
        {
            return Ok(new { success = false, message = "This material is already in use and cannot be deleted." });
        }

        await _repository.DeleteMaterialAsync(code);
        return Ok(new { success = true, message = "material deleted successfully." });
    }



}