using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AdlumenMVC.Models.AbstractRepository;
using Moq;
using AdlumenMVC.Models.Model;
using System.Linq;
using System.Collections.Generic;


namespace AdlumenMVC.Tests.Repositories
{
    [TestClass]
    public class PeriodosTests
    {

        private IQueryable<PRY_PERIODOSPROYECTOS> _periodos = new List<PRY_PERIODOSPROYECTOS> {
            new PRY_PERIODOSPROYECTOS {
                IdPeriodo = 1,
                Nombre = "Periodo 1",
                FechaInicio = DateTime.Parse("01/01/2014"),
                FechaFin = DateTime.Parse("28/02/2014"),
                IdProyecto = 1,
                //Activo = true
            },
             new PRY_PERIODOSPROYECTOS {
                IdPeriodo = 2,
                Nombre = "Periodo 2",
                FechaInicio = DateTime.Parse("01/03/2014"),
                FechaFin = DateTime.Parse("30/04/2014"),
                IdProyecto = 1,
                //Activo = true
            },
             new PRY_PERIODOSPROYECTOS {
                IdPeriodo = 3,
                Nombre = "Periodo 3",
                FechaInicio = DateTime.Parse("01/05/2014"),
                FechaFin = DateTime.Parse("30/06/2014"),
                IdProyecto = 1,
                //Activo = true
            },
        }.AsQueryable();

        [TestMethod]
        public void GetAllPeriodosByProject_returns_ordered_periods()
        {
            Mock<IContextRepository> mock = new Mock<IContextRepository>();

            mock.Setup(m => m.pry_periodosproyectos).Returns(_periodos);

            var periodos = mock.Object.pry_periodosproyectos.ToList();

            string strPeriodosOrdenados = "";

            foreach (var periodo in periodos)
            {
                strPeriodosOrdenados += periodo.Nombre + ",";
            }

            Assert.AreEqual("Periodo 1,Periodo 2,Periodo 3", strPeriodosOrdenados.TrimEnd(','));

        }
    }
}
