using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjetoIgreja.Models;

namespace ProjetoIgreja.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var db = new assembleiaEntities();

            var viewModel = new IndexViewModel(); 
            viewModel.agenda = db.agenda.OrderByDescending(p => p.idagenda).FirstOrDefault();

            viewModel.eventos = new List<evento>();

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult CadastraAgenda(IndexViewModel model)
        {
            try
            {
                var db = new assembleiaEntities();
                agenda agenda = new agenda();

                agenda.periodo = "De " + model.inicio.Date + "até " + model.fim.Date;

                int i = 0;
                foreach (var evento in model.eventos)
                {
                    evento.data = evento.data + new TimeSpan(0,model.hora[i],0,0);
                    evento.data = evento.data + new TimeSpan(0,0,model.minutos[i], 0);
                    i++;
                    agenda.evento.Add(evento);
                    
                }
                db.agenda.Add(agenda);
                db.SaveChanges();

                TempData["msgSucesso"] = "Sucesso!! Agenda Semanal atualizada.";
                return RedirectToAction("Index");
            }
            catch(Exception e)
            {
                TempData["msgErro"] = "Erro ao atualizar a agenda semanal. Informações :" + e;
                return RedirectToAction("Index");
            }
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
    }
}