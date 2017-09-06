using System;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Web.Mvc;
using ccb_web.Models;
using PagedList;
using ccb_web.DAO;

namespace ccb_web.Controllers
{
    [Authorize]
    public class ClienteController : Controller
    {
        readonly Contexto _banco = new Contexto();

        private ClienteDAO clienteDAO;

        public ClienteController(ClienteDAO clienteDAO)
        {
            this.clienteDAO = clienteDAO;

            _banco.Database.Log = x => Debug.Write(x);
        }


        public ActionResult Form()
        {
            return View();
        }

        public ActionResult Index(int? pagina)
        {
            const int tamanhoPagina = 5;
            int numeroPagina = pagina ?? 1;

            var cliente = clienteDAO.Lista();

            var lista = cliente.ToPagedList(numeroPagina, tamanhoPagina);


            return View(lista);
        }

        [HttpPost]
        public ActionResult Index(string termoBusca, int? pagina)
        {
            const int tamanhoPagina = 5;
            int numeroPagina = pagina ?? 1;

            var cliente = clienteDAO.Lista();

            var lista = cliente.ToPagedList(numeroPagina, tamanhoPagina);

            if (!String.IsNullOrEmpty(termoBusca))
            {
                lista = lista.Where(x => x.Nome.ToUpper().Contains(termoBusca.ToUpper())).
                    ToPagedList(numeroPagina, tamanhoPagina);
            }

            if (Request.IsAjaxRequest())
                return PartialView("_ListaClientes", lista);
            return View(lista);
        }

        public ActionResult Adicionar()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Adicionar(Cliente novoCliente)
        {
            if (ModelState.IsValid)
            {
                clienteDAO.Salvar(novoCliente);
                return RedirectToAction("Index");
            }
            return View(novoCliente);
        }//fim adicionar

        public ActionResult RegistroUnico(string nome)
        {
            var nomeclientes = ((from al in _banco.Clientes
                               where al.Nome == nome
                               select al.Nome).ToArray());

            return Json(nomeclientes.All(x => x.ToUpper() != nome.ToUpper()), JsonRequestBehavior.AllowGet);
        }

        public ActionResult Detalhes(int id)
        {
            var cliente = clienteDAO.BuscarClienteId(id);

            if (cliente == null)
            {
                return HttpNotFound();
            }
            return View(cliente);
        }

        public ActionResult Editar(int id)
        {
            Cliente cliente = clienteDAO.BuscarClienteId(id);

            return View(cliente);
        }

        [HttpPost]
        public ActionResult Editar(Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                clienteDAO.Alterar(cliente);
                return RedirectToAction("Detalhes", cliente);
            }
            return View(cliente);
        }

        public ActionResult Excluir(int id)
        {
            var cliente = clienteDAO.BuscarClienteId(id);

            try
            {
                clienteDAO.Excluir(cliente);
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
