﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SistemaVendas.Models;

namespace SistemaVendas.Controllers
{
    public class VendedorController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.ListaVendedor = new VendedorModel().ListarTodosVendedores();
            return View();
        }

        [HttpGet]
        public IActionResult Cadastro(int? id) 
        {
             if(id != null)
            {
                //Carregar o registro do Vendedor em uma ViewBag
                ViewBag.Vendedor = new VendedorModel().RetornarVendedor(id);
            }
            return View();
        }

        [HttpPost]
        public IActionResult Cadastro(VendedorModel Vendedor)
        {
            if (ModelState.IsValid)
            {
                Vendedor.Gravar();
                return RedirectToAction("Index"); 
            }
            return View();
        }

        public IActionResult Excluir(int id)
        {
            ViewData["IdExcluir"] = id;
            return View();
        }

        public IActionResult ExcluirVendedor(int id)
        {
            new VendedorModel().Excluir(id);
            return View();
        }
    }
}