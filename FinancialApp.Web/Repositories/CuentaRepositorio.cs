using FinancialApp.Web.DB;
using FinancialApp.Web.Models;

namespace FinancialApp.Web.Repositories;

public interface ICuentaRepositorio
{
    List<Cuenta> ObtenerTodos();
}

public class CuentaRepositorio: ICuentaRepositorio
{
    private DbEntities _dbEntities;
    public CuentaRepositorio(DbEntities dbEntities)
    {
        this._dbEntities = dbEntities;
    }
    public List<Cuenta> ObtenerTodos()
    {
        return _dbEntities.Cuentas.ToList();
    }
}