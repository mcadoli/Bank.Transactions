using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Transactions.Helpers;
using Transactions.Process;
using et = Transactions.Entities;


namespace Transaction.Presentation.MVC.Controllers
{
    public class HomeController : Controller
    {
        FinanceTransaction ft = new FinanceTransaction();
        public ActionResult Home()
        {
            List<et.Transaction> lstTransaction = ft.ListarDadosTransaction();
            return View(lstTransaction);
        }

        [HttpPost]
        public JsonResult UploadFiles()
        {
            foreach (string file in Request.Files)
            {
                HttpPostedFileBase hpf = Request.Files[file] as HttpPostedFileBase;
                if (hpf.ContentLength == 0)
                    continue;
                string savedFileName = Path.Combine((Util.Diretorio("DiretorioOfx")), hpf.FileName);

                if (System.IO.File.Exists(savedFileName))
                    System.IO.File.Delete(savedFileName);

                Session.Add("CaminhoArquivo", savedFileName);
                hpf.SaveAs(savedFileName);

                ft.SalvarDadosTransaction();
                
            }
            return new JsonResult { Data = new { Mensagem = "Arquivo importado com sucesso." } };
            
        }

       
    }
}