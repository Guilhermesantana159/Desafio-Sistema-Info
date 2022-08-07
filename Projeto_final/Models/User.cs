using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace Projeto_final.Models
{
    public class User
    {
        private readonly static string connect_sql = @"Data Source=DESKTOP-TCNDHDL\SQLEXPRESS;Initial Catalog=Register_Person;Integrated Security=True;
            Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public String Usuario { get; set;}
        public String Senha { get; set; }
        public int Id { get; set; }
        public bool Login()
        {
            var result = false;
            var sql = "SELECT Id,Usuario,Senha FROM Login WHERE Usuario = '" + Usuario + "'";

            try
            {
                using(var con = new SqlConnection(connect_sql))
                {
                    con.Open();
                    using (var com = new SqlCommand(sql,con))
                    {
                        using(var dr = com.ExecuteReader())
                        {
                            if (dr.Read())
                            {
                                if (Senha == dr["Senha"].ToString())
                                {
                                    Id = Convert.ToInt32(dr["Id"]);
                                    Usuario = dr["Usuario"].ToString();
                                    result = true;
                                }
                                
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Falha" + ex.Message);
            }
            return result;
        }
    }
}