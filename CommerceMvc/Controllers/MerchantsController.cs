using CommerceMvc.DataAccess;
using CommerceMvc.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CommerceMvc.Controllers
{
    public class MerchantsController : Controller
    {
        private CommerceMvcContext _context;

        public MerchantsController(CommerceMvcContext context)
        {
            _context = context;
        }

        public ActionResult Index()
        {
            var merchants = _context.Merchants;

            return View(merchants);
        }

        [Route("/merchants/{id:int}")]
        public ActionResult Show(int id)
        {
            var merchant = _context
                .Merchants
                .Include(m => m.Products)
                .Where(m => m.Id == id)
                .First();

            return View(merchant);
        }

        public ActionResult New()
        {
            return View();
        }

        [HttpPost]
        [Route("/merchants")]
        public ActionResult Create(Merchant merchant)
        {
            _context.Merchants.Add(merchant);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
