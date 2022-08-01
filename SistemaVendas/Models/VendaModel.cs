using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SistemaVendas.Models;
using SistemaVendas.Uteis;

namespace SistemaVendas.Models
{
    public class VendaModel
    {
        public string Id { get; set; }
        public string Cliente_Id { get; set; }
        public string Vendedor_Id { get; set; }
        public double Total { get; set; }
        public string ListaProdutos { get; set; }

        public List<ClienteModel> RetornarListaClientes()
        {
            return new ClienteModel().ListarTodosClientes();
        }

        public List<VendedorModel> RetornarListaVendedores()
        {
            return new VendedorModel().ListarTodosVendedores();
        }

        public List<ProdutoModel> RetornarListaProdutos()
        {
            return new ProdutoModel().ListarTodosProdutos();
        }

        public void Inserir()
        {
            DAL objDAL = new DAL();

            string dataVenda = DateTime.Now.Date.ToString("yyyy/MM/dd");

            string sql = "INSERT INTO venda (data, total, vendedorId, clienteId)" +
                $"VALUES ('{dataVenda}', '{Total}', '{Vendedor_Id}' , '{Cliente_Id}')";
           
            objDAL.ExecutarComandoSQL(sql);
        }
    }
}