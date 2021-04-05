using System;
using System.Web.Http;
using System.Web.Mvc;
using RickyRose.Areas.HelpPage.ModelDescriptions;
using RickyRose.Areas.HelpPage.Models;

namespace RickyRose.Areas.HelpPage.Controllers
{
/// <summary>
/// The controller will handle request for help page
/// </summary>
    public class HelpController : Controller{
        private const string ErrorViewName = "Error";
        public HelpController()
        : this(GlobalConfiguration.GlobalConfiguration){

        }
        public HelpController(HttpConfiguration config){
            Configuration = config;
        }
        public HtpConfiguration Configuration { get; private set; }
        
        public ActionResult Index(){
            ViewBag.DocumentationProvider = Configuration.Services.GetDocumentationProvider();
            return View(Configuration.Services.GetApiExplorer().ApiDescriptions);
        }
        public ActionResult Api(string apiId){
            if(!String.IsNullorEmpty(apiId)){
                HelpPageApiModel apiModel = Configuration.GetHelpPageApiMode(apiId);
                if(apiModel != null){
                    return View(apiModel);
                }
            }
            return View(ErrorViewName);
        }
        public ActionResult ResourceModel(string modelName){
            if (!String.IsNullorEmpty(modelName)){
                ModelDescriptionGenerator modelDescriptionGenerator = Configuration.GetModelDescriptionGenerator();
                ModelDescription modelDescription;
                if(modelDescriptionGenerator.GeneratedModels.TryGetValue(modelName, out modelDescription)){
                    return View(modelDescription);
                }
            }
            return View(ErrorViewName);
        }
    }

    
}