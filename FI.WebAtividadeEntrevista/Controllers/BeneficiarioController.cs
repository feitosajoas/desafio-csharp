using FI.AtividadeEntrevista.BLL;
using FI.AtividadeEntrevista.DML;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebAtividadeEntrevista.Models;

namespace WebAtividadeEntrevista.Controllers
{
    public class BeneficiarioController : Controller
    {
        // GET: Beneficiario
        public ActionResult Incluir()
        {
            return View();
        }

        public ActionResult Listar()
        {
            BoBeneficiario bo = new BoBeneficiario();
            var beneficiarios = bo.Listar();
            return View(beneficiarios);
        }

        [HttpPost]
        public ActionResult BeneficiarioList(int jtStartIndex = 0, int jtPageSize = 0, string jtSorting = null)
        {
            try
            {
                int qtd = 0;
                string campo = string.Empty;
                string crescente = string.Empty;
                string[] array = jtSorting.Split(' ');

                if (array.Length > 0)
                    campo = array[0];

                if (array.Length > 1)
                    crescente = array[1];

                List<Cliente> clientes = new BoCliente().Pesquisa(jtStartIndex, jtPageSize, campo, crescente.Equals("ASC", StringComparison.InvariantCultureIgnoreCase), out qtd);

                //Return result to jTable
                return View(clientes);
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = ex.Message });
            }
        }

        [HttpGet]
        public ActionResult Alterar(long id)
        {

            var _beneficiario = BoBeneficiario.Consultar(id);
            Models.BeneficiarioModel model = null;

            if (_beneficiario != null)
            {
                model = BeneficiarioModel.ConvertToModel(_beneficiario);
            }

            return View(model);
        }

        [HttpPost]
        public JsonResult Incluir(BeneficiarioModel model)
        {

            BoBeneficiario bo = new BoBeneficiario();

            if (!this.ModelState.IsValid)
            {
                List<string> erros = (from item in ModelState.Values
                                      from error in item.Errors
                                      select error.ErrorMessage).ToList();

                Response.StatusCode = 400;
                return Json(string.Join(Environment.NewLine, erros));
            }
            else
            {
                var isExist = BoBeneficiario.VerificarExistencia(model.CPF, model.Id);

                if (isExist)
                {
                    Response.StatusCode = 400;
                    return Json(string.Join(Environment.NewLine, "O Beneficiario já esta associado ao cliente"));
                }

                model.Id = bo.Incluir(new Beneficiario()
                {
                    Nome = model.Nome,
                    IdCliente = model.Id,
                    CPF = model.CPF
                });

                return Json("Cadastro efetuado com sucesso");
            }
        }

        public ActionResult Excluir(long id)
        {
            var _beneficiario = BoBeneficiario.Consultar(id);
            Models.BeneficiarioModel model = null;

            if (_beneficiario != null)
            {
                model = BeneficiarioModel.ConvertToModel(_beneficiario);
            }

            return View(model);
        }

        [HttpPost]
        public JsonResult Excluir(BeneficiarioModel model)
        {
            if (!this.ModelState.IsValid)
            {
                List<string> erros = (from item in ModelState.Values
                                      from error in item.Errors
                                      select error.ErrorMessage).ToList();

                Response.StatusCode = 400;
                return Json(string.Join(Environment.NewLine, erros));
            }
            else
            {
                var _beneficiario = model.GetBeneficiario();
                BoBeneficiario.Excluir(_beneficiario.Id);

                return Json("Cadastro excluido com sucesso");
            }
        }
    }
}