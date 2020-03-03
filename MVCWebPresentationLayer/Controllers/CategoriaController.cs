using AutoMapper;
using BLL.Impl;
using DTO;
using MVCWebPresentationLayer.Models;
using MVCWebPresentationLayer.Models.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace MVCWebPresentationLayer.Controllers
{
    public class CategoriaController : Controller
    {
        // GET: Categoria
        public async Task<ActionResult> Index()
        {
            CategoriaService svc = new CategoriaService();
            List<CategoriaDTO> categorias = await svc.GetCategorias();

            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<CategoriaDTO, CategoriaQueryViewModel>();
            });
            IMapper mapper = configuration.CreateMapper();
            // new SERService().GetSERByID(4);
            //Transforma o ClienteInsertViewModel em um ClienteDTO
            List<CategoriaQueryViewModel> categoriasViewModel =
                mapper.Map<List<CategoriaQueryViewModel>>(categorias);

            ViewBag.Categorias = categoriasViewModel;

            return View();
        }

        public async Task<ActionResult> Cadastrar()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Cadastrar(CategoriaInsertViewModel viewModel)
        {
            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<CategoriaInsertViewModel, CategoriaDTO>();
            });
            IMapper mapper = configuration.CreateMapper();
            // new SERService().GetSERByID(4);
            //Transforma o ClienteInsertViewModel em um ClienteDTO
            CategoriaDTO dto = mapper.Map<CategoriaDTO>(viewModel);

            CategoriaService svc = new CategoriaService();
            try
            {
                await svc.Insert(dto);
                return RedirectToAction("Index", "Produto");
            }
            catch (Exception ex)
            {
                ViewBag.Erros = ex.Message;
            }
            return View();
        }

    }
}