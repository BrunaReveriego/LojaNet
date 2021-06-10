using System;
using System.Web.Mvc;
using System.Xml.Serialization;
using System.IO;
using LojaNet.Models;
using LojaNet.BLL;

namespace LojaNet.UI.Web.Controllers
{
    public class ClienteController : Controller
    {
        private ClienteBLL bll;

        public ClienteController()
        {
            bll = new ClienteBLL();
        }

        public ActionResult Serializar(Cliente cliente)
        {

            var _cliente = bll.ObterPorId(cliente.Id);
            string arquivo = @"C:\dados\" + cliente.Id + ".xml";
            var serializador = new XmlSerializer(cliente.GetType());
            var stream = new StreamWriter(arquivo);
            serializador.Serialize(stream, _cliente);
            stream.Close();
            return RedirectToAction("Index");
        }




        public ActionResult Alterar(string id)
        {
            var cliente = bll.ObterPorId(id);
            return View(cliente);
        }

        [HttpPost]
        public ActionResult Alterar(Cliente cliente)
        {
            try
            {

                bll.Alterar(cliente);

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                return View(cliente);
            }
        }


        public ActionResult Excluir(string id)
        {
            var cliente = bll.ObterPorId(id);
            return View(cliente);
        }

        [HttpPost]
        public ActionResult Excluir(string id, FormCollection formCollection)
        {
            try
            {
                bll.Excluir(id);

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                var cliente = bll.ObterPorId(id);
                return View(cliente);
            }
        }



        public ActionResult Detalhes(string id)
        {
            var cliente = bll.ObterPorId(id);
            return View(cliente);
        }


        public ActionResult Incluir()
        {
            var cli = new Cliente();
            return View(cli);
        }

        [HttpPost]
        public ActionResult Incluir(Cliente cliente)
        {
            try
            {



                bll.Incluir(cliente);

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                return View(cliente);
            }
        }


        // GET: Cliente
        public ActionResult Index()
        {

            var lista = bll.ObterTodos();

            return View(lista);
        }
    }
}