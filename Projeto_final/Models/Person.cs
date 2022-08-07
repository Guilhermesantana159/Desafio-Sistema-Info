using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
namespace Projeto_final.Models
{
    public class Person{
        private readonly static string connect_sql = @"Data Source=DESKTOP-TCNDHDL\SQLEXPRESS;Initial Catalog=Register_Person;Integrated Security=True;
            Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        public String Codigo { get; set; }
        public String Nome { get; set; }
        public long Cpf { get; set;}
        public String Endereço { get; set;}
        public long Telefone { get; set; }

        public int Id { get; set; }

        public Person() { 
        }

        public Person(String codigo,string nome,long cpf,string endereço,long telefone, int id)
        {
            Codigo = codigo;
            Nome = nome;
            Cpf = cpf;
            Endereço = endereço;
            Telefone = telefone;
            Id = id;
        }
        
        public static List<Person> GetPerson()
        {
            var listaPerson = new List<Person>();
            var sql = "SELECT * FROM Person";

            try
            {
                using (var con = new SqlConnection(connect_sql))
                {
                    con.Open();
                    using (var cm = new SqlCommand(sql, con))
                    {
                        using (var dr = cm.ExecuteReader())
                        {
                            if (dr.HasRows)
                            {
                                while (dr.Read())
                                {
                                    listaPerson.Add(new Person(
                                        dr["Codigo"].ToString(),
                                        dr["Nome"].ToString(),
                                        Convert.ToInt64(dr["Cpf"]),
                                        dr["Endereço"].ToString(),
                                        Convert.ToInt64(dr["Telefone"]),
                                        Convert.ToInt32(dr["Id"])
                                    ));
                                }
                            }
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine("Falha: " + ex.Message);
            }
            return listaPerson;
        }
     
        public void Register()
        {
            var sql = "";

            if(Id == 0){
                sql = "INSERT INTO Person (Codigo,Nome,Cpf,Endereço,Telefone) VALUES(@codigo," +
                    "@nome,@cpf,@endereço,@telefone)";
            }
            else{
                sql = "UPDATE Person SET Codigo=@codigo,Nome=@nome,Cpf=@cpf,Endereço=@endereço," +
                    "Telefone=@telefone WHERE id=" + Id;
            }
            try
            {
                using (var con = new SqlConnection(connect_sql))
                {
                    con.Open();
                    using(var com = new SqlCommand(sql, con))
                    {
                        com.Parameters.AddWithValue("@codigo",Codigo);
                        com.Parameters.AddWithValue("@nome", Nome);
                        com.Parameters.AddWithValue("@cpf", Cpf);
                        com.Parameters.AddWithValue("@endereço", Endereço);
                        com.Parameters.AddWithValue("@telefone", Telefone);

                        com.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Falha" + ex.Message);
            }
        }

        public void Delete()
        {
            var sql = "DELETE FROM Person WHERE id=" + Id;
            try
            {
                using (var con = new SqlConnection(connect_sql))
                {
                    con.Open();
                    using (var com = new SqlCommand(sql, con))
                    {
                        com.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Falha" + ex.Message);
            }
        }
        public void GetPerson(int id)
        {
            var sql = "Select Codigo,Nome,Cpf,Endereço,Telefone FROM Person WHERE id=" + id;
            try
            {
                using (var con = new SqlConnection(connect_sql))
                {
                    con.Open();
                    using(var com = new SqlCommand(sql, con))
                    {
                        using (var dr = com.ExecuteReader())
                        {
                            if (dr.HasRows)
                            {
                               if (dr.Read())
                                {
                                    Id = id;
                                    Codigo = dr["Codigo"].ToString();
                                    Nome = dr["Nome"].ToString();
                                    Cpf = Convert.ToInt64(dr["Cpf"]);
                                    Endereço = dr["Endereço"].ToString();
                                    Telefone = Convert.ToInt64(dr["Telefone"]);
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Falha: " + ex.Message);
            }
        }
                
    }
}
