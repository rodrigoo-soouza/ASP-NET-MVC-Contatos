using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Projeto_MVC_DIO.Context;
using Projeto_MVC_DIO.Models;

namespace Projeto_MVC_DIO.Controllers;

public class ContatoController : Controller
{
    private readonly AgendaContext _context;

    public ContatoController(AgendaContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        var contatos = await _context.Contatos.ToListAsync();
        
        return View(contatos);
    }

    public IActionResult Criar()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Criar(Contato contato)    
    {
        if (ModelState.IsValid)
        {
            _context.Contatos.Add(contato);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(contato);
    }
           
    public async Task<IActionResult> Editar(int id)
    {
        var contato = await _context.Contatos.FindAsync(id);

        if (contato == null)
        {
            return NotFound();
        }
        
        return View(contato);
    }

    [HttpPost]
    public async Task<IActionResult> Editar(int id, Contato contato)
    {
        if (id != contato.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(contato);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ContatoExists(contato.Id))
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

        return View(contato);
    }

    private bool ContatoExists(int id)
    {
        return _context.Contatos.Any(x => x.Id == id);
    }

    public async Task<IActionResult> Detalhes(int id)
    {
        var contato = await _context.Contatos.FindAsync(id);

        if (contato == null)
        {
            return NotFound();
        }
        
        return View(contato);
    }

    public async Task<IActionResult> Deletar(int id)
    {
        var contato = await _context.Contatos.FindAsync(id);

        if (contato == null)
        {
            return NotFound();
        }

        return View(contato);
    }


   [HttpPost, ActionName("Deletar")]
   public async Task<IActionResult> ConfirmarDeletar(int id)
   {
        var contato = await _context.Contatos.FindAsync(id);

        if (contato == null)
        {
            return RedirectToAction(nameof(Index));
        }
        
        _context.Contatos.Remove(contato);
        await _context.SaveChangesAsync();

        return RedirectToAction(nameof(Index));
        

   }
    


}

