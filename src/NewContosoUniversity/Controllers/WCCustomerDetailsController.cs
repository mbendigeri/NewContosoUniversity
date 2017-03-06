using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NewContosoUniversity.Data;
using NewContosoUniversity.Entity;

namespace NewContosoUniversity.Controllers
{
    public class WCCustomerDetailsController : Controller
    {
        private readonly NewContosoUniversityDBContext _context;
        

        public WCCustomerDetailsController(NewContosoUniversityDBContext context)
        {
            _context = context;    
        }

        // GET: WCCustomerDetails
        public async Task<IActionResult> Index()
        {
            return View(await _context.WCCustomerDetails.ToListAsync());
        }

        // GET: WCCustomerDetails/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var wCCustomerDetails = await _context.WCCustomerDetails.SingleOrDefaultAsync(m => m.CustomerID == id);
            if (wCCustomerDetails == null)
            {
                return NotFound();
            }

            return View(wCCustomerDetails);
        }

        // GET: WCCustomerDetails/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: WCCustomerDetails/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(
            [Bind("CustomerID,AddressTypeID,City,FirstName,LandMark,LastName,Locality,MiddleName,OccupationID,Organisation,Pincode,Street1,Street2")] WCCustomerDetails wCCustomerDetails)
        {
            if (ModelState.IsValid)
            {
                _context.Add(wCCustomerDetails);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(wCCustomerDetails);
        }

        // GET: WCCustomerDetails/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var wCCustomerDetails = await _context.WCCustomerDetails.SingleOrDefaultAsync(m => m.CustomerID == id);
            if (wCCustomerDetails == null)
            {
                return NotFound();
            }
            return View(wCCustomerDetails);
        }

        // POST: WCCustomerDetails/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CustomerID,AddressTypeID,City,FirstName,LandMark,LastName,Locality,MiddleName,OccupationID,Organisation,Pincode,Street1,Street2")] WCCustomerDetails wCCustomerDetails)
        {
            if (id != wCCustomerDetails.CustomerID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(wCCustomerDetails);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WCCustomerDetailsExists(wCCustomerDetails.CustomerID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            return View(wCCustomerDetails);
        }

        // GET: WCCustomerDetails/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var wCCustomerDetails = await _context.WCCustomerDetails.SingleOrDefaultAsync(m => m.CustomerID == id);
            if (wCCustomerDetails == null)
            {
                return NotFound();
            }

            return View(wCCustomerDetails);
        }

        // POST: WCCustomerDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var wCCustomerDetails = await _context.WCCustomerDetails.FirstOrDefaultAsync(m => m.CustomerID == id);
            _context.WCCustomerDetails.Remove(wCCustomerDetails);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool WCCustomerDetailsExists(int id)
        {
            return _context.WCCustomerDetails.Any(e => e.CustomerID == id);
        }
    }
}
