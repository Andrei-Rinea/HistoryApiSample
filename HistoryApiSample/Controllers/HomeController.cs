using System.Linq;
using System.Web.Mvc;
using HistoryApiSample.Models;

namespace HistoryApiSample.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";
            return View();
        }

        [HttpGet]
        public ActionResult Selector()
        {
            var model = new SelectorViewModel
            {
                Makes = new[]
                {
                    new SelectListItem { Value = "VW",  Text = "Volkswagen" },
                    new SelectListItem { Value = "AUD", Text = "Audi"       },
                    new SelectListItem { Value = "SEA", Text = "Seat"       },
                    new SelectListItem { Value = "SKD", Text = "Skoda"      }
                },
                Models = Enumerable.Empty<SelectListItem>()
            };
            return View(model);
        }

        [HttpPost]
        public ActionResult Selector(SelectorViewModel viewModel)
        {
            return RedirectToAction("ShowSelection", new
            {
                makeId = viewModel.SelectedMake,
                modelId = viewModel.SelectedModel
            });
        }

        [HttpGet]
        public ActionResult ShowSelection(string makeId, string modelId)
        {
            string makeName = null;
            string modelName = null;
            switch (makeId)
            {
                case "VW": makeName = "Volkswagen"; break;
                case "AUD": makeName = "Audi"; break;
                case "SEA": makeName = "Seat"; break;
                case "SKD": makeName = "Skoda"; break;
            }
            switch (modelId)
            {
                case "TIG": modelName = "Tiguan"; break;
                case "TRG": modelName = "Touareg"; break;
                case "A4": modelName = "A4"; break;
                case "A6": modelName = "A6"; break;
                case "LEO": modelName = "Leon"; break;
                case "IBZ": modelName = "Ibiza"; break;
                case "FAB": modelName = "Fabia"; break;
                case "OCT": modelName = "Octavia"; break;
            }
            var viewModel = new SelectionViewModel
            {
                Make = makeName,
                Model = modelName
            };
            return View(viewModel);
        }

        [HttpGet]
        public ActionResult GetModelsByMake(string makeId)
        {
            object data;
            switch (makeId)
            {
                case "VW":
                    data = new[]
                    {
                        new DataItem { Id = "TIG", Text = "Tiguan"  },
                        new DataItem { Id = "TRG", Text = "Touareg" }
                    };
                    break;
                case "AUD":
                    data = new[]
                    {
                        new DataItem { Id = "A4", Text = "A4"  },
                        new DataItem { Id = "A6", Text = "A6" }
                    };
                    break;
                case "SEA":
                    data = new[]
                    {
                        new DataItem { Id = "LEO", Text = "Leon"  },
                        new DataItem { Id = "IBZ", Text = "Ibiza" }
                    };
                    break;
                case "SKD":
                    data = new[]
                    {
                        new DataItem { Id = "FAB", Text = "Fabia"  },
                        new DataItem { Id = "OCT", Text = "Octavia" }
                    };
                    break;
                default:
                    return HttpNotFound();
            }
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        private class DataItem
        {
            public string Id { get; set; }
            public string Text { get; set; }
        }
    }
}