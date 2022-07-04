using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using SistemaVendas.Uteis;

namespace SistemaVendas.Models
{
    public class ClienteModel
    {
        public string Id { get; set; }
        public string Nome { get; set; }
        public string CPF { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }

        public List<ClienteModel> ListarTodosCliente()
        {
            List<ClienteModel> lista = new List<ClienteModel>();
            ClienteModel item;
            DAL objDAL = new DAL();
            string sql = "SELECT id, nome, cpf_cnpj, email, senha FROM sistema_venda.cliente ORDER by nome ASC";
            DataTable dt = objDAL.RetDataTable(sql);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                item = new ClienteModel
                {
                    Id = dt.Rows[i]["Id"].ToString(),
                    Nome = dt.Rows[i]["Nome"].ToString(),
                    Email = dt.Rows[i]["Email"].ToString(),
                    CPF = dt.Rows[i]["cpf_cnpj"].ToString(),
                    Senha = dt.Rows[i]["Senha"].ToString(),
                };
                lista.Add(item);
            }
            return lista;
        }
    }
}