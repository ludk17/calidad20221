using System.Collections.Generic;
using FinancialApp.Web.Controllers;
using FinancialApp.Web.Models;
using FinancialApp.Web.Repositories;
using Moq;
using NUnit.Framework;

namespace FinancialApp.Tests.Controllers;

public class CuentaControllerTest
{
    [Test]
    public void CreateViewCase01()
    {
        var mockTipoRepositorio = new Mock<ITipoCuentaRepositorio>();
        mockTipoRepositorio.Setup(o => o.ObtenerTodos()).Returns(new List<TipoCuenta>());
        
        var controller = new CuentaController(mockTipoRepositorio.Object, null);
        var view = controller.Create();
        
        Assert.IsNotNull(view);
    }
    
}