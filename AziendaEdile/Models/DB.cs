using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace AziendaEdile.Models
{
    public static class DB
    {
        public static List<Dipendente> getAllDipendenti()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["ConnectionStringDB"].ToString();
            SqlConnection conn = new SqlConnection(connectionString);

            SqlCommand cmd = new SqlCommand("select * from Dipendenti", conn);
            SqlDataReader sqlDataReader;

            conn.Open();

            List<Dipendente> dipendenti = new List<Dipendente>();
            sqlDataReader = cmd.ExecuteReader();
            while (sqlDataReader.Read())
            {
                Dipendente dipendente = new Dipendente();
                dipendente.Id = Convert.ToInt32(sqlDataReader["IdDipendente"]);
                dipendente.Name = sqlDataReader["Nome"].ToString();
                dipendente.Surname = sqlDataReader["Cognome"].ToString();
                dipendente.Address = sqlDataReader["Indirizzo"].ToString();
                dipendente.CF = sqlDataReader["CF"].ToString();
                dipendente.IsMarried = Convert.ToBoolean(sqlDataReader["Sposato"]);
                dipendente.NOfChildren = Convert.ToInt16(sqlDataReader["Figli"]);
                dipendente.Job = sqlDataReader["Mansione"].ToString();
                dipendenti.Add(dipendente);
            }

            conn.Close();
            return dipendenti;
        }

        public static void AddEmployee(string name, string surname, string address, string cf, bool isMarried, int nOfChildren, string job)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["ConnectionStringDB"].ConnectionString.ToString();
            SqlConnection conn = new SqlConnection(connectionString);

            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "INSERT INTO Dipendenti VALUES(@name, @surname, @address, @cf, @isMarried, @nOfChildren, @job)";
                cmd.Parameters.AddWithValue("name", name);
                cmd.Parameters.AddWithValue("surname", surname);
                cmd.Parameters.AddWithValue("address", address);
                cmd.Parameters.AddWithValue("cf", cf);
                cmd.Parameters.AddWithValue("isMarried", isMarried);
                cmd.Parameters.AddWithValue("nOfChildren", nOfChildren);
                cmd.Parameters.AddWithValue("job", job);
                int IsOk = cmd.ExecuteNonQuery();

            }

            catch
            {

            }
            finally
            {
                conn.Close();
            }
        }
        public static void AddPayment(DateTime date, double amount, bool salary, int idDipendente)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["ConnectionStringDB"].ConnectionString.ToString();
            SqlConnection conn = new SqlConnection(connectionString);

            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "INSERT INTO Pagamenti VALUES(@date, @amount, @salary, @idDipendente)";
                cmd.Parameters.AddWithValue("date", date);
                cmd.Parameters.AddWithValue("amount", amount);
                cmd.Parameters.AddWithValue("salary", salary);
                cmd.Parameters.AddWithValue("idDipendente", idDipendente);
                int IsOk = cmd.ExecuteNonQuery();

            }

            catch
            {

            }
            finally
            {
                conn.Close();
            }
        }
        public static List<PagamentoDipendente> getAllPaymentByEmployee(int idDipendente)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["ConnectionStringDB"].ToString();
            SqlConnection conn = new SqlConnection(connectionString);

            SqlCommand cmd = new SqlCommand("SELECT Dipendenti.IdDipendente, Cognome, Nome, Mansione, Data, Importo, Stipendio FROM Dipendenti INNER JOIN Pagamenti ON Dipendenti.IdDipendente = Pagamenti.IdDipendente WHERE Dipendenti.IdDipendente = @idDipendente ORDER BY Data asc;", conn);
            cmd.Parameters.AddWithValue("idDipendente", idDipendente);
            SqlDataReader sqlDataReader;

            conn.Open();
            sqlDataReader = cmd.ExecuteReader();

            List<PagamentoDipendente> pagamenti = new List<PagamentoDipendente>();
            while (sqlDataReader.Read())
            {
                PagamentoDipendente pagamento = new PagamentoDipendente();
                pagamento.Surname = sqlDataReader["Cognome"].ToString();
                pagamento.Name = sqlDataReader["Nome"].ToString();
                pagamento.Job = sqlDataReader["Mansione"].ToString();
                pagamento.Date = Convert.ToDateTime(sqlDataReader["Data"]);
                pagamento.Amount = Convert.ToDouble(sqlDataReader["Importo"]);
                pagamento.Salary = Convert.ToBoolean(sqlDataReader["Stipendio"]);
                pagamenti.Add(pagamento);
            }

            conn.Close();
            return pagamenti;
        }

        public static List<PagamentoDipendente> getAllPayments()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["ConnectionStringDB"].ToString();
            SqlConnection conn = new SqlConnection(connectionString);

            SqlCommand cmd = new SqlCommand("SELECT Cognome, Nome, Mansione, Data, Importo, Stipendio FROM Dipendenti INNER JOIN Pagamenti ON Dipendenti.IdDipendente = Pagamenti.IdDipendente ORDER BY Data asc;", conn);
            SqlDataReader sqlDataReader;

            conn.Open();
            sqlDataReader = cmd.ExecuteReader();

            List<PagamentoDipendente> pagamenti = new List<PagamentoDipendente>();
            while (sqlDataReader.Read())
            {
                PagamentoDipendente pagamento = new PagamentoDipendente();
                pagamento.Surname = sqlDataReader["Cognome"].ToString();
                pagamento.Name = sqlDataReader["Nome"].ToString();
                pagamento.Job = sqlDataReader["Mansione"].ToString();
                pagamento.Date = Convert.ToDateTime(sqlDataReader["Data"]);
                pagamento.Amount = Convert.ToDouble(sqlDataReader["Importo"]);
                pagamento.Salary = Convert.ToBoolean(sqlDataReader["Stipendio"]);
                pagamenti.Add(pagamento);
            }

            conn.Close();
            return pagamenti;

        }
    }
}