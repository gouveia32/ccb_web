using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using GestaoEscolar.Models;
using PagedList;
using System;

namespace GestaoEscolar.Controllers
{
    [Authorize]
    public class ClienteController : Controller
    {
        readonly Contexto _banco = new Contexto();

        public ActionResult Index(int? pagina)
        {
            const int tamanhoPagina = 5;
            int numeroPagina = pagina ?? 1;

            var cliente = _banco.Clientes.OrderBy(x => x.Nome).ToPagedList(numeroPagina, tamanhoPagina);
            return View(cliente);
        }

        public ActionResult Adicionar()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Adicionar(Cliente novaCliente)
        {
            if (ModelState.IsValid)
            {
                _banco.Clientes.Add(novaCliente);
                _banco.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(novaCliente);
        }//fim adicionar

        public ActionResult Detalhes(long id)
        {
            var cliente = _banco.Clientes.First(x => x.Id == id);


            if (cliente == null)
            {
                return HttpNotFound();
            }
            return View(cliente);
        }

        public ActionResult Editar(long id)
        {
            Cliente cliente = _banco.Clientes.Find(id);

            return View(cliente);
        }

        [HttpPost]
        public ActionResult Editar(Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                _banco.Entry(cliente).State = EntityState.Modified;
                _banco.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cliente);
        }

        public ActionResult Excluir(long id)
        {
            var cliente = _banco.Clientes.First(x => x.Id == id);
            _banco.Clientes.Remove(cliente);

            try
            {
                _banco.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                if (Request.UrlReferrer != null) ViewBag.Voltar = Request.UrlReferrer.ToString();
                return View("Error", new HandleErrorInfo(ex, "Cliente", "Index"));
            }
        }

    }
}
