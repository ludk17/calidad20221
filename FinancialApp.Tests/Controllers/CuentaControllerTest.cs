using System.Collections.Generic;
using System.Security.Claims;
using FinancialApp.Web.Controllers;
using FinancialApp.Web.Models;
using FinancialApp.Web.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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

    [Test]
    public void IndexCase01()
    {

        var claimsPrincipal = new Mock<ClaimsPrincipal>();
        claimsPrincipal.Setup(o => o.Claims).Returns(new List<Claim>() {new Claim(ClaimTypes.Name, "admin")});
        var context = new Mock<HttpContext>();
        context.Setup(o => o.User).Returns(claimsPrincipal.Object);
        var mock = new Mock<ITipoCuentaRepositorio>();
        var controller = new CuentaController(mock.Object, null);
        controller.ControllerContext = new ControllerContext()
        {
            HttpContext =context.Object
        };
        var result = controller.Index();

    }
    
}