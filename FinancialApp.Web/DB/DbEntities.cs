using FinancialApp.Web.Models;

namespace FinancialApp.Web.DB;

public class DbEntities
{
    public static List<Cuenta> Cuentas = new();
    public static List<Transaccion> Transacciones = new();
    public static List<TipoCuenta> TipoCuentas = new()
    {
        new TipoCuenta { Id = 1, Nombre = "Efectivo"},
        new TipoCuenta { Id = 2, Nombre = "Cuenta de Banco"},
        new TipoCuenta { Id = 3, Nombre = "Tarjeta de Débito"},
        new TipoCuenta { Id = 4, Nombre = "Tarjeta de Crédito"},
        new TipoCuenta { Id = 5, Nombre = "Electrónico"},
        new TipoCuenta { Id = 6, Nombre = "Otro"},
    };
    
    
}