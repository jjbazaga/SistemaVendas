using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using SistemaVendas.Uteis;
using System.ComponentModel.DataAnnotations;

namespace SistemaVendas.Models
{
    public class ClienteModel
    {
        public string Id { get; set; }

        [Required(ErrorMessage ="Informe o Nome do cliente")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Informe o CPF/CNPJ do cliente")]
        public string CPF { get; set; }

        [Required(ErrorMessage = "Informe o E-mail do cliente")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress(ErrorMessage = "O E-mail informado é inválido!")]
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

        public void Inserir()
        {
            DAL objDAL = new DAL();
            string sql = $"INSERT INTO cliente(nome, cpf_cnpj, email, senha) values ('{Nome}', '{CPF}','{Email}', '{123456}')";
            objDAL.ExecutarComandoSQL(sql);
        }
    }
}