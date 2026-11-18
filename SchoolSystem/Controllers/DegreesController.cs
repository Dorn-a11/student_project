
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchoolSystem.Models;
using SchoolSystem.Data;

public class DegreesController : Controller
{
    private readonly ApplicationDbContext _context;

    public DegreesController(ApplicationDbContext context)
    {
        _context = context;
    }

    // GET: DEGREES
    public IActionResult Index()    
    {
        return View();
    }

    // GET: DEGREES/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var degree = await _context.tblDegree
            .FirstOrDefaultAsync(m => m.Id == id);
        if (degree == null)
        {
            return NotFound();
        }

        return View(degree);
    }

    // GET: DEGREES/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: DEGREES/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Id,NameEnglish,NameKhmer")] Degree degree)
    {
        if (ModelState.IsValid)
        {
            _context.Add(degree);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(degree);
    }

    // GET: DEGREES/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var degree = await _context.tblDegree.FindAsync(id);
        if (degree == null)
        {
            return NotFound();
        }
        return View(degree);
    }

    // POST: DEGREES/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int? id, [Bind("Id,NameEnglish,NameKhmer")] Degree degree)
    {
        if (id != degree.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(degree);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DegreeExists(degree.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return RedirectToAction(nameof(Index));
        }
        return View(degree);
    }

    // GET: DEGREES/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var degree = await _context.tblDegree
            .FirstOrDefaultAsync(m => m.Id == id);
        if (degree == null)
        {
            return NotFound();
        }

        return View(degree);
    }

    // POST: DEGREES/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int? id)
    {
        var degree = await _context.tblDegree.FindAsync(id);
        if (degree != null)
        {
            _context.tblDegree.Remove(degree);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool DegreeExists(int? id)
    {
        return _context.tblDegree.Any(e => e.Id == id);
    }
}
