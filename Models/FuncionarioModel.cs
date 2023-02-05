using Npgsql;
using Orbium_Desafio_Jr_RVW.db;
using System.ComponentModel.DataAnnotations;
using System.Data;

namespace Orbium_Desafio_Jr_RVW.Models
{
    public class FuncionarioModel
    {
        [Key]
       public int Func_Id { get; set; }

        [Required(ErrorMessage = "Informe o Nome do Funcionário")]
        public string Func_Nome { get; set; }

        [Required(ErrorMessage = "Informe o Email do Funcionário")]
        public string Func_Email { get; set; }

        [Required(ErrorMessage = "Informe o Cargo do Funcionário")]
        public string Func_Cargo { get; set; }

        [Required(ErrorMessage = "Informe o Salário do Funcionário")]
        public decimal Func_Salario { get; set; }
        
        public string Func_DataContratacao = DateTime.Now.Date.ToString("dd/MM/yyyy");


        public List<FuncionarioModel> ListarFuncionarios()
        {
            List<FuncionarioModel> list = new List<FuncionarioModel>();
            FuncionarioModel item;
            DAL dal = new DAL();

            string query = "SELECT * FROM funcionario ORDER BY func_salario, func_id";
            DataTable dt = dal.ReturnDataTable(query);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                item = new FuncionarioModel
                {
                    Func_Id = Convert.ToInt32(dt.Rows[i]["func_id"]),
                    Func_Nome = dt.Rows[i]["func_nome"].ToString(),
                    Func_Email = dt.Rows[i]["func_email"].ToString(),
                    Func_Cargo = dt.Rows[i]["func_cargo"].ToString(),
                    Func_Salario = Convert.ToDecimal(dt.Rows[i]["func_salario"]),
                    Func_DataContratacao = Convert.ToDateTime(dt.Rows[i]["func_dataContratacao"]).ToString("dd/MM/yyyy")
                };
                list.Add(item);
               
            }
            return list;
        }

        public List<FuncionarioModel> PesquisarFuncionario(string strNome)
        {
            List<FuncionarioModel> list = new List<FuncionarioModel>();
            FuncionarioModel item;
            DAL dal = new DAL();

            string query = $"SELECT * FROM funcionario  WHERE func_nome = '{strNome}' ORDER BY func_salario, func_id";
            DataTable dt = dal.ReturnDataTable(query);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                item = new FuncionarioModel
                {
                    Func_Id = Convert.ToInt32(dt.Rows[i]["func_id"]),
                    Func_Nome = dt.Rows[i]["func_nome"].ToString(),
                    Func_Email = dt.Rows[i]["func_email"].ToString(),
                    Func_Cargo = dt.Rows[i]["func_cargo"].ToString(),
                    Func_Salario = Convert.ToDecimal(dt.Rows[i]["func_salario"]),
                    Func_DataContratacao = Convert.ToDateTime(dt.Rows[i]["func_dataContratacao"]).ToString("dd/MM/yyyy")
                };
                list.Add(item);

            }
            return list;
        }

        public FuncionarioModel RetornarFuncionario(int? id)
        {
            FuncionarioModel item;
            DAL dal = new DAL();

            string query = $"SELECT * FROM funcionario WHERE func_id = {id}";
            DataTable dt = dal.ReturnDataTable(query);

            item = new FuncionarioModel
            {
                Func_Id = Convert.ToInt32(dt.Rows[0]["func_id"]),
                Func_Nome = dt.Rows[0]["func_nome"].ToString(),
                Func_Email = dt.Rows[0]["func_email"].ToString(),
                Func_Cargo = dt.Rows[0]["func_cargo"].ToString(),
                Func_Salario = Convert.ToDecimal(dt.Rows[0]["func_salario"]),
                Func_DataContratacao = Convert.ToDateTime(dt.Rows[0]["func_dataContratacao"]).ToString("dd/MM/yyyy")
            };
            return item;
        }

        //INSERT 
        public bool Inserir()
        {
            DAL dal = new DAL();
            string query_insert, query_select;

            query_select = $"SELECT * FROM funcionario WHERE func_email = '{Func_Email}'";
                     
            query_insert = $"INSERT INTO funcionario(func_nome, func_email, func_cargo, func_salario, func_dataContratacao) " +
             $"VALUES('{Func_Nome}', '{Func_Email}', '{Func_Cargo}', {Func_Salario}, '{Func_DataContratacao}')";


            try {

                DataTable dt = dal.ReturnDataTable(query_select);
                if (dt.Rows.Count == 1)
                {
                    return false;
                }
                else
                {
                    try
                    {
                        dal.CRUD(query_insert);
                        return true;
                    }
                    catch (NpgsqlException ex)
                    {
                        throw ex;
                    }


                }

            } catch(NpgsqlException ex)
            {
                throw ex;
            }

           
        }

        //UPDATE
        public void Atualizar(int id)
        {
            DAL dal = new DAL();
            string query = $"UPDATE funcionario SET func_nome = '{Func_Nome}', func_email = '{Func_Email}', func_cargo = '{Func_Cargo}', func_salario = {Func_Salario} WHERE func_id = {id}";
            try
            {
                dal.CRUD(query);
            }
            catch (NpgsqlException ex)
            {
                throw ex;
            }

        }

        //DELETE
        public void Deletar(int id)
        {
            DAL dal = new DAL();
            string query = $"DELETE FROM funcionario WHERE func_id = {id}";
            try
            {
                dal.CRUD(query);
            }
            catch (NpgsqlException ex)
            {
                throw ex;
            }

        }
    }
}
