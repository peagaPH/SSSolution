using AutoMapper;
using BLL.Impl;
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
    public class UsuarioController : Controller
    {
        UsuarioService userService = new UsuarioService();

        [HttpGet]
        public ActionResult Cadastrar()
        {
            return View();
        }
        public async Task<ActionResult> Login()
        {

            return View();
        }
        public async Task<ActionResult> Login(string email, string senha)
        {
            try
            {
                UsuarioDTO user = await userService.Autenticar(email, senha);
                //se chegou aqui sucesso
                HttpCookie cookie = new HttpCookie("USERIDENTITY", user.ID.ToString());
                cookie.Expires = DateTime.Now.AddMinutes(25);
                Response.Cookies.Add(cookie);
                return RedirectToAction("Index", "Cliente");
            }
            catch (Exception ex)
            {
                ViewBag.Erros = ex.Message;
            }
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Cadastrar(UsuarioInsertViewModel viewModel)
        {
            UsuarioService svc = new UsuarioService();

            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<UsuarioInsertViewModel, UsuarioDTO>();
            });

            IMapper mapper = configuration.CreateMapper();
            // new SERService().GetSERByID(4);
            //Transforma o ClienteInsertViewModel em um ClienteDTO
            UsuarioDTO dto = mapper.Map<UsuarioDTO>(viewModel);
            try
            {
                await svc.Insert(dto);
                //Se funcionou, redireciona pra página inicial
                return RedirectToAction("Home", "Index");
            }
            catch (NecoException ex)
            {
                //Se caiu aqui, o ClienteService lançou a exceção por validação de campos
                ViewBag.ValidationErrors = ex.Errors;
            }
            catch (Exception ex)
            {
                //Se caiu aqui, o ClienteService lançou uma exceção genérica, provavelmente por falha de acesso ao banco
                ViewBag.ErrorMessage = ex.Message;
            }
            //Se chegou aqui, temos erro
            return View();
        }
    }
}