using AutomaticInfotch_Assignment.DataContext;
using AutomaticInfotch_Assignment.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol.Core.Types;
using static AutomaticInfotch_Assignment.Models.PurchaseOrder;

namespace AutomaticInfotch_Assignment.Controllers
{
    public class PurchaseOrdersController : Controller
    {
        private readonly ApplicationDataContext _context;

        public PurchaseOrdersController(ApplicationDataContext context)
        {
            _context = context;
        }

     /*   public IActionResult Index()
        {
            var purchaseOrders = _context.PurchaseOrders.ToList();
            return View(purchaseOrders);
        }*/

        public async Task<IActionResult> Index(int page = 1, int pageSize = 10)
        {
            var purchaseOrders = _context.PurchaseOrders.ToList();

            int totalRecords = purchaseOrders.Count();
            var pagedOrders = purchaseOrders
                                .Skip((page - 1) * pageSize)
                                .Take(pageSize)
                                .ToList();

            ViewBag.PageNumber = page;
            ViewBag.PageSize = pageSize;
            ViewBag.TotalRecords = totalRecords;

            return View(pagedOrders);
        }






        // GET: PurchaseOrders
        public IActionResult Create()
        {
            var random = new Random();
            ViewBag.materials = _context.Materials.ToList();
           // ViewBag.vendors = _context.Vendors.ToList();
            var PurchaseOrder = new PurchaseOrder
            {
                OrderNo = random.Next(1000, 9999).ToString(),
                vendors = _context.Vendors.ToList()
            };
            return View(PurchaseOrder);
        }
        [HttpPost]
        public IActionResult Create(PurchaseOrder purchaseOrder)
        {
            _context.PurchaseOrders.Add(purchaseOrder);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
        public async Task<IActionResult> View(int orderId)
        {
            var purchase = await _context.PurchaseOrders
        .Include(p => p.LineItems)  // Include LineItems
        .FirstOrDefaultAsync(t => t.OrderId == orderId);

            if (purchase == null)
            {
                return NotFound();
            }

            return View(purchase);
        }

    }
}
