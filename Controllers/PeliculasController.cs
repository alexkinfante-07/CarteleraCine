using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CarteleraCine.Models;

public class PeliculasController : Controller
{
    private readonly CarteleraCineContext _context;

    public PeliculasController(CarteleraCineContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        var carteleraCineContext = _context.Pelicula.Include(p => p.Genero);
        return View(await carteleraCineContext.ToListAsync());
    }

    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var pelicula = await _context.Pelicula
            .Include(p => p.Genero)
            .FirstOrDefaultAsync(m => m.Id == id);
        if (pelicula == null)
        {
            return NotFound();
        }

        return View(pelicula);
    }

    public IActionResult Create()
    {
        ViewData["GeneroId"] = new SelectList(_context.Genero.OrderBy(g => g.Nombre), "Id", "Nombre");
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Id,Titulo,Director,DuracionMinutos,GeneroId")] Pelicula pelicula)
    {
        if (ModelState.IsValid)
        {
            _context.Add(pelicula);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        ViewData["GeneroId"] = new SelectList(_context.Genero.OrderBy(g => g.Nombre), "Id", "Nombre", pelicula.GeneroId);
        return View(pelicula);
    }

    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var pelicula = await _context.Pelicula.FindAsync(id);
        if (pelicula == null)
        {
            return NotFound();
        }
        ViewData["GeneroId"] = new SelectList(_context.Genero.OrderBy(g => g.Nombre), "Id", "Nombre", pelicula.GeneroId);
        return View(pelicula);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int? id, [Bind("Id,Titulo,Director,DuracionMinutos,GeneroId")] Pelicula pelicula)
    {
        if (id != pelicula.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(pelicula);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PeliculaExists(pelicula.Id))
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
        ViewData["GeneroId"] = new SelectList(_context.Genero.OrderBy(g => g.Nombre), "Id", "Nombre", pelicula.GeneroId);
        return View(pelicula);
    }

    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var pelicula = await _context.Pelicula
            .Include(p => p.Genero)
            .FirstOrDefaultAsync(m => m.Id == id);
        if (pelicula == null)
        {
            return NotFound();
        }

        return View(pelicula);
    }

        [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int? id)
    {
        var pelicula = await _context.Pelicula.FindAsync(id);
        if (pelicula != null)
        {
            _context.Pelicula.Remove(pelicula);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool PeliculaExists(int? id)
    {
        return _context.Pelicula.Any(e => e.Id == id);
    }
}