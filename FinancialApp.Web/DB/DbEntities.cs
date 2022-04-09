using FinancialApp.Web.DB.Mapping;
using FinancialApp.Web.Models;
using Microsoft.EntityFrameworkCore;

namespace FinancialApp.Web.DB;

public class DbEntities: DbContext
{
    public DbSet<Cuenta> Cuentas { get; set; }
    public DbSet<TipoCuenta> TipoCuentas { get; set; }
    public DbEntities(DbContextOptions<DbEntities> options) : base(options) { }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfiguration(new CuentaMapping());
        modelBuilder.ApplyConfiguration(new TipoCuentaMapping());
    }


    //public static List<Cuenta> Cuentas = new();
    public static List<Transaccion> Transacciones = new();
    //
    // public static List<TipoCuenta> TipoCuentas = new()
    // {
    //     new TipoCuenta {Id = 1, Nombre = "Efectivo", EsCredito = false},
    //     new TipoCuenta {Id = 2, Nombre = "Cuenta de Banco", EsCredito = false},
    //     new TipoCuenta {Id = 3, Nombre = "Tarjeta de Débito", EsCredito = false},
    //     new TipoCuenta {Id = 4, Nombre = "Tarjeta de Crédito", EsCredito = true},
    //     new TipoCuenta {Id = 5, Nombre = "Electrónico", EsCredito = false},
    //     new TipoCuenta {Id = 6, Nombre = "Otro", EsCredito = false},
    // };
    
    //     new TipoCuenta {Id = 1, Nombre = "Efectivo", EsCredito = false},
    //     new TipoCuenta {Id = 2, Nombre = "Cuenta de Banco", EsCredito = false},
    //     new TipoCuenta {Id = 3, Nombre = "Tarjeta de Débito", EsCredito = false},
    //     new TipoCuenta {Id = 4, Nombre = "Tarjeta de Crédito", EsCredito = true},
    //     new TipoCuenta {Id = 5, Nombre = "Electrónico", EsCredito = false},
    //     new TipoCuenta {Id = 6, Nombre = "Otro", EsCredito = false},
    
    public static List<Usuario> Usuarios = new()
    {
        new Usuario {Id = 1, Username = "admin", Password = "123456"},
        new Usuario {Id = 2, Username = "user1", Password = "123456"},
        new Usuario {Id = 3, Username = "user2", Password = "123456"},
    };
}