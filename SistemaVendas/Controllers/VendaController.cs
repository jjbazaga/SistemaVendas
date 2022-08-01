using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SistemaVendas.Models;

namespace SistemaVendas.Controllers
{
    public class VendaController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            //ViewBag.ListaVendas = new VendaModel().ListaVendas();
            return View();
        }

        [HttpGet]
        public IActionResult Registrar()
        {
            CarregarDados();
            return View();
        }

        [HttpPost]
        public IActionResult Registrar(VendaModel venda)
        {
            venda.Inserir();
            return View();
        }

        private void CarregarDados()
        {
            ViewBag.ListaClientes = new VendaModel().RetornarListaClientes();
            ViewBag.ListaVendedores = new VendaModel().RetornarListaVendedores();
            ViewBag.ListaProdutos = new VendaModel().RetornarListaProdutos();
        }
    }
}