using System.Security.Claims;
using FinancialApp.Web.DB;
using FinancialApp.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FinancialApp.Web.Controllers;

[Authorize]
public class CuentaController : Controller
{
    [HttpGet]
    public IActionResult Index()
    {
        var cuentas = DbEntities.Cuentas.Where(o => o.UsuarioId == GetLoggedUser().Id).ToList();
        ViewBag.Total = cuentas.Any() ? cuentas.Sum(o => o.Monto) : 0; 
        return View(cuentas);
    }
    
    [HttpGet]
    public IActionResult Create()
    {
        ViewBag.TipoDeCuentas = DbEntities.TipoCuentas;
        return View(new Cuenta());
    }
    
    [HttpPost]
    public IActionResult Create(Cuenta cuenta)
    {
        if (cuenta.TipoCuentaId > 6 || cuenta.TipoCuentaId < 1)
        {
            ModelState.AddModelError("TipoCuentaId", "Tipo de cuenta no exite");
        }

        if (!ModelState.IsValid)
        {
            ViewBag.TipoDeCuentas = DbEntities.TipoCuentas;
            return View("Create", cuenta);
        }

        cuenta.Id = getNextId();
        cuenta.UsuarioId = GetLoggedUser().Id;
        DbEntities.Cuentas.Add(cuenta);
        return RedirectToAction("Index");

    }
    
    [HttpGet]
    public IActionResult Edit(int id)
    {
        var cuenta = DbEntities.Cuentas.First(o => o.Id == id); // lambdas / LINQ
        ViewBag.TipoDeCuentas = DbEntities.TipoCuentas;
        return View(cuenta);
    }
    
    [HttpPost]
    public IActionResult Edit(int id, Cuenta cuenta)
    {
        if (!ModelState.IsValid) {
            ViewBag.TipoDeCuentas = DbEntities.TipoCuentas;
            return View("Edit", cuenta);
        }
        
        var cuentaDb = DbEntities.Cuentas.First(o => o.Id == id);
        cuentaDb.Nombre = cuenta.Nombre;
        return RedirectToAction("Index");
    }
    
    [HttpGet]
    public IActionResult Delete(int id)
    {
        var cuentaDb = DbEntities.Cuentas.First(o => o.Id == id);
        DbEntities.Cuentas.Remove(cuentaDb);

        return RedirectToAction("Index");
    }

    public int getNextId()  {
        if (DbEntities.Cuentas.Count == 0)
            return 1;
        return DbEntities.Cuentas.Max(o => o.Id) + 1;
    }

    private Usuario GetLoggedUser()
    {
        var claim = HttpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Name);
        var username = claim.Value;
        return DbEntities.Usuarios.First(o => o.Username == username);
    }
}