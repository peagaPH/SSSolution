using AutoMapper;
using BLL.Impl;
using BLL.Remote;
using Common;
using DTO;
using MVCWebPresentationLayer.Models.Insert;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace MVCWebPresentationLayer.Controllers
{
    public class FornecedorController : Controller
    {
        // GET: Fornecedor
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Create(FornecedorInsertViewModel viewModel)
        {
            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<FornecedorInsertViewModel, FornecedorDTO>();
            });
            IMapper mapper = configuration.CreateMapper();
            FornecedorDTO fornecedor = mapper.Map<FornecedorDTO>(viewModel);

            FornecedorService svc = new FornecedorService();
            try
            {
                await svc.Create(fornecedor);
                return RedirectToAction("Index", "Produto");
            }
            catch (NecoException ex)
            {
                ViewBag.Errors = ex.Errors;
            }
            catch (Exception ex)
            {
                ViewBag.ErroGenerico = ex.Message;
            }
            return View();
        }

        [HttpPost]
        public ActionResult PesquisaCEP(string cep)
        {
            cep = cep.Replace("-", "");
            CepRemoteService cepSvc = new CepRemoteService(cep);
            var obj = new
            {
                Bairro = cepSvc.Bairro,
                Rua = cepSvc.Logradouro,
                UF = cepSvc.UF,
                Cidade = cepSvc.Cidade
            };
            return Json(obj, JsonRequestBehavior.AllowGet);
        }

    }
}