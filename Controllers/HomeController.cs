using Microsoft.AspNetCore.Mvc;
using Orbium_Desafio_Jr_RVW.Models;
using System.Diagnostics;


namespace Orbium_Desafio_Jr_RVW.Controllers
{
    public class HomeController : Controller
    {
       public int idUltimoFuncSelected = 0;

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            ViewBag.ListaFuncionarios = new FuncionarioModel().ListarFuncionarios();
            return View();
        }

        [HttpPost]
        public IActionResult Index(FuncionarioModel pesquisarFuncionario)
        {
            if(pesquisarFuncionario.Func_Nome != null)
            {
                ViewBag.ListaFuncionarios = pesquisarFuncionario.PesquisarFuncionario(pesquisarFuncionario.Func_Nome);
            }
            else
            {
                ViewBag.ListaFuncionarios = new FuncionarioModel().ListarFuncionarios();
            }          
            return View();
        }

        [HttpGet]
        public IActionResult CadastroFuncionario(int? id = 0) 
        {         
            if(id != 0)
            {
                //Carregar o Registro do Cliente em uma ViewBag
                ViewBag.Funcionario = new FuncionarioModel().RetornarFuncionario(id);

                idUltimoFuncSelected = Convert.ToInt32(id);

            }
                                         
            return View();

        }

        [HttpPost]
        public IActionResult CadastroFuncionario(FuncionarioModel funcionario)
        {
            if (!ModelState.IsValid)
            {          
                    if (funcionario.Inserir() == false)
                    {
                        ViewBag.MsgFuncJaExiste = "Email já Cadastrado, Confira se o Funcionário está Cadastrado!";
                    }
                    else
                    {
                        funcionario.Inserir();
                    }
               
               
            }
            else 
            {
                if (funcionario.Func_Id != 0)
                {
                    funcionario.Atualizar(funcionario.Func_Id);
                }

            }
            return RedirectToAction("Index");
            return View();
        }

        public IActionResult ConfirmarDelete(int id)
        {
            ViewData["idDelete"] = id;
            return View();
        }

        public IActionResult Deletar (int id)
        {
            new FuncionarioModel().Deletar(id);
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}