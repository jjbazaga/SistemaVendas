using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SistemaVendas.Uteis;
using System.Data;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace SistemaVendas.Models
{
    public class ProdutoModel
    {
        public string Id { get; set; }

        [Required(ErrorMessage = "Informe o Nome do Produto")]
        public string Nome { get; set; }

        public string Descricao { get; set; }

        public decimal Preco_Unitario { get; set; }

        public decimal Quantidade_Estoque { get; set; }

        public string Unidade_Medida { get; set; }

        public string Link_Foto { get; set; }

        public List<ProdutoModel> ListarTodosProduto()
        {
            List<ProdutoModel> lista = new List<ProdutoModel>();
            ProdutoModel item;
            DAL objDAL = new DAL();
            string sql = "SELECT id, nome, descricao, preco_unitario, quantidade_estoque, unidade_medida, link_foto FROM produto ORDER by nome ASC";
            DataTable dt = objDAL.RetDataTable(sql);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                item = new ProdutoModel
                {
                    Id = dt.Rows[i]["id"].ToString(),
                    Nome = dt.Rows[i]["nome"].ToString(),
                    Descricao = dt.Rows[i]["descricao"].ToString(),
                    Preco_Unitario = decimal.Parse(dt.Rows[i]["preco_unitario"].ToString()),
                    Quantidade_Estoque = decimal.Parse(dt.Rows[i]["quantidade_estoque"].ToString()),
                    Unidade_Medida = dt.Rows[i]["unidade_medida"].ToString(),
                    Link_Foto = dt.Rows[i]["link_foto"].ToString()
                };
                lista.Add(item);
            }
            return lista;
        }

        public ProdutoModel RetornarProduto(int? id)
        {
            ProdutoModel item;
            DAL objDAL = new DAL();
            string sql = $"SELECT id, nome, descricao, preco_unitario, quantidade_estoque, unidade_medida, link_foto FROM Produto WHERE id='{id}' ORDER by nome ASC";
            DataTable dt = objDAL.RetDataTable(sql);

            item = new ProdutoModel
            {
                Id = dt.Rows[0]["id"].ToString(),
                Nome = dt.Rows[0]["nome"].ToString(),
                Descricao = dt.Rows[0]["descricao"].ToString(),
                Preco_Unitario = decimal.Parse(dt.Rows[0]["preco_unitario"].ToString()),
                Quantidade_Estoque = decimal.Parse(dt.Rows[0]["quantidade_estoque"].ToString()),
                Unidade_Medida = dt.Rows[0]["unidade_medida"].ToString(),
                Link_Foto = dt.Rows[0]["link_foto"].ToString()
            };
            return item;
        }

        //INSERT OU UPDATE
        public void Gravar()
        {
            DAL objDAL = new DAL();
            string sql = string.Empty;
            if (Id != null)
            {
                sql = $"UPDATE produto SET nome='{Nome}', descricao='{Descricao}', preco_unitario='{Preco_Unitario.ToString().Replace(",",".")}', quantidade_estoque='{Quantidade_Estoque.ToString().Replace(",",".")}', unidade_medida='{Unidade_Medida}', link_foto='{Link_Foto}' WHERE id={Id}";
            }
            else
            {
                sql = $"INSERT INTO produto(nome, descricao, preco_unitario, quantidade_estoque, unidade_medida, link_foto ) VALUES ('{Nome}', '{Descricao}','{Preco_Unitario.ToString().Replace(',', '.')}', '{Quantidade_Estoque.ToString().Replace(',', '.')}', '{Unidade_Medida}', '{Link_Foto}' )";
            }

            objDAL.ExecutarComandoSQL(sql);
        }

        //DELETE
        public void Excluir(int id)
        {
            DAL objDAL = new DAL();
            string sql = $"DELETE FROM Produto WHERE ID='{id}'";
            objDAL.ExecutarComandoSQL(sql);
        }
    }
}