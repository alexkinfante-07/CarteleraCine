using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CarteleraCine.Models;

[Authorize]
public class GenerosController : Controller
{
    private readonly CarteleraCineContext _context;

    public GenerosController(CarteleraCineContext context)
    {
        _context = context;
    }

    // GET: Generos
    public async Task<IActionResult> Index()
    {
        return View(await _context.Genero.Include(g => g.Peliculas).ToListAsync());
    }

    // GET: Generos/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var genero = await _context.Genero
            .Include(g => g.Peliculas)
            .FirstOrDefaultAsync(m => m.Id == id);
        if (genero == null)
        {
            return NotFound();
        }

        return View(genero);
    }

    // GET: Generos/Create
    [Authorize(Roles = "Curador")]
    public IActionResult Create()
    {
        return View();
    }

    // POST: Generos/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    [Authorize(Roles = "Curador")]
    public async Task<IActionResult> Create([Bind("Id,Nombre,Descripcion")] Genero genero)
    {
        if (ModelState.IsValid)
        {
            if (await _context.Genero.AnyAsync(g => g.Nombre.ToLower() == genero.Nombre.ToLower()))
            {
                ModelState.AddModelError("Nombre", "Ya existe un género registrado con este nombre.");
                return View(genero);
            }

            _context.Add(genero);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(genero);
    }

    // GET: Generos/Edit/5
    [Authorize(Roles = "Curador")]
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var genero = await _context.Genero.FindAsync(id);
        if (genero == null)
        {
            return NotFound();
        }
        return View(genero);
    }

    // POST: Generos/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    [Authorize(Roles = "Curador")]
    public async Task<IActionResult> Edit(int? id, [Bind("Id,Nombre,Descripcion")] Genero genero)
    {
        if (id != genero.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(genero);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GeneroExists(genero.Id))
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
        return View(genero);
    }

    // GET: Generos/Delete/5
    [Authorize(Roles = "Curador")]
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var genero = await _context.Genero
            .FirstOrDefaultAsync(m => m.Id == id);
        if (genero == null)
        {
            return NotFound();
        }

        return View(genero);
    }

    // POST: Generos/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    [Authorize(Roles = "Curador")]
    public async Task<IActionResult> DeleteConfirmed(int? id)
    {
        var genero = await _context.Genero.FindAsync(id);
        if (genero != null)
        {
            _context.Genero.Remove(genero);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool GeneroExists(int? id)
    {
        return _context.Genero.Any(e => e.Id == id);
    }
}