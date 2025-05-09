using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Text.RegularExpressions;
using TPLOCAL1.Models;

//Subject is find at the root of the project and the logo in the wwwroot/ressources folders of the solution
//--------------------------------------------------------------------------------------
//Careful, the MVC model is a so-called convention model instead of configuration,
//The controller must imperatively be name with "Controller" at the end !!!
namespace TPLOCAL1.Controllers
{
    public class HomeController : Controller
    {
        //methode "naturally" call by router
        public ActionResult Index(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
                //retourn to the Index view (see routing in Program.cs)
                return View();
            else
            {
                //Call different pages, according to the id pass as parameter
                switch (id)
                {
                    case "OpinionList":
                        //TODO : code reading of the xml files provide
                        var opinionList = new OpinionList().GetAvis("XlmFile/DataAvis.xml");
                        ViewBag.opinionList = opinionList;
                        return View(id);
                    case "Form":
                        //TODO : call the Form view with data model empty
                        return View(id);
                    default:
                        //retourn to the Index view (see routing in Program.cs)
                        return View();
                }
            }
        }


        //methode to send datas from form to validation page
        [HttpPost]
        public ActionResult ValidationFormulaire(Models.Form form )
        {
            //TODO : test if model's fields are set
            //if not, display an error message and stay on the form page
            //else, call ValidationForm with the datas set by the user
            
            if (form.Formation == "Cobol")
            {
                ModelState.Remove("AvisCsharp");
            }
            if (form.Formation == "Csharp")
            {
                ModelState.Remove("AvisCobol");
            }
            
            foreach (var field in ModelState)
            {
                if (field.Value.AttemptedValue == "")
                {
                    ModelState[field.Key].Errors.Clear();
                    ModelState.AddModelError(field.Key, "Vide");
                } else if (field.Value.AttemptedValue == "Invalid")
                {
                    ModelState[field.Key].Errors.Clear();
                    ModelState.AddModelError(field.Key, "Choose a value");
                } else if (ModelState[field.Key].Errors.Count > 1)
                {
                    var descriptions = "";
                    foreach (var error in ModelState[field.Key].Errors)
                    {
                        descriptions += error.ErrorMessage + "\n";
                    }
                    ModelState[field.Key].Errors.Clear();
                    ModelState.AddModelError(field.Key, descriptions);
                }
            }

            if (form.DateDebut > DateTime.Now)
            {
                ModelState.AddModelError("DateDebut", "Date dans le futur");
            }

            if (ModelState.IsValid)
            {
                ViewBag.form = form;
                return View("ValidatedForm");
            }
            return View("Form");

        }
    }
}