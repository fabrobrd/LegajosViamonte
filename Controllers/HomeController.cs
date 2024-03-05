using LegajosViamonte.Models;
using Legajos.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Legajos.Domain.Model;
using Legajos.Domain;
using Legajos.Domain.Service;

namespace LegajosViamonte.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        const int allPersons = 2;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            RrhhModel model = GetDataPersons(allPersons);

            return View(model);
        }
        private static RrhhModel GetDataPersons(int filter)
        {
            RrhhModel model = new RrhhModel();

            RrhhDapperRepository dapperRepository = new RrhhDapperRepository();
            var resultdapper = dapperRepository.GetAllActives(filter);
            List<Rrhh> listRrhh = new List<Rrhh>();
            foreach (var item in resultdapper)
            {
                listRrhh.Add(item);
            }
            model.legajos = listRrhh;
            model.Code = string.Empty;
            model.Nombre = string.Empty;
            model.Doc_Nro = 0;
            model.Doc_Tipo = string.Empty;
            model.If_Del = 0;
            model.Nivel = 0;
            model.If_Activo = 0;
            model.Cuil = string.Empty;
            model.F_Alta = DateTime.Now;
            return model;
        }
        public IActionResult FilterActivePersons(int filter)
        {
            RrhhModel model = GetDataPersons(filter);

            return View("Index", model);

        }
        private static RrhhModel GetPerson(int legajo)
        {
            RrhhModel model = new RrhhModel();

            RrhhDapperRepository dapperRepository = new RrhhDapperRepository();
            var resultdapper = dapperRepository.GetPerson(legajo);
            model.Code = resultdapper.Code;
            model.Nombre = resultdapper.Nombre;
            model.Doc_Nro = resultdapper.Doc_Nro;
            model.Doc_Tipo = resultdapper.Doc_Tipo;
            model.If_Del = resultdapper.If_Del;
            model.Nivel = resultdapper.Nivel;
            model.If_Activo = resultdapper.If_Activo;
            model.Cuil = resultdapper.Cuil;
            model.F_Alta = resultdapper.F_Alta;
            model.Legajo = resultdapper.Legajo;
            return model;
        }
        [HttpPost]
        public IActionResult AddPersons(RrhhModel rrhhmodel)
        {
            RrhhService rrhhService = new RrhhService();
            if (rrhhmodel.Legajo != null)
            {
                rrhhService.SavePerson(rrhhmodel);
            }
            RrhhModel model = GetDataPersons(allPersons);
            return View("Index", model);

        }
        public IActionResult UnsuscribePerson(int legajo)
        {
            RrhhService rrhhService = new RrhhService();
            if (legajo != null)
            {
                rrhhService.UnsubscribePerson(legajo);
            }
            RrhhModel model = GetDataPersons(allPersons);
            return View("Index", model);
        }
        public IActionResult SuscribePerson(int legajo)
        {
            RrhhService rrhhService = new RrhhService();
            if (legajo != null)
            {
                rrhhService.SubscribePerson(legajo);
            }
            RrhhModel model = GetDataPersons(allPersons);
            return View("Index", model);
        }

        public IActionResult UpdatePerson(int legajo)
        {
            RrhhModel model = GetPerson(legajo);
            return View(model);
            //return View("Index", model);
        }

        public IActionResult UpdatePersons(RrhhModel rrhhmodel, int codUser)
        {
            RrhhService rrhhService = new RrhhService();
            if (codUser != null)
            {
                rrhhmodel.Legajo = codUser;
                rrhhService.UpdatePerson(rrhhmodel);
            }
            RrhhModel model = GetDataPersons(allPersons);
            return View("Index", model);

        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
