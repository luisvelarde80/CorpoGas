using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Modelo.Crud
{
    public class Conexion
    {

        public SqlConnection Empresa(string Rfc)
        {

            string strCon = "CORPOGAS_" + Rfc + "";

            SqlConnection con = new SqlConnection();

            con.ConnectionString = "data source=10.0.3.7;initial catalog=" + strCon + ";user id=sa;password=Infod3x!ra";

            try
            {
                con.Open();
                return con;
            }
            catch (SqlException ex)
            {
                return null;
            }

        }

        public SqlConnection Empresa()
        {

            SqlConnection con = new SqlConnection();

            con.ConnectionString = "data source=10.0.3.7;initial catalog=CORPOGAS_BIS;user id=sa;password=Infod3x!ra";

            try
            {
                con.Open();
                return con;
            }
            catch (SqlException ex)
            {
                return null;
            }

        }

        public SqlConnection Corpogas()
        {

            SqlConnection con = new SqlConnection();

            con.ConnectionString = "data source=10.0.3.7;initial catalog=CORPOGAS;user id=sa;password=Infod3x!ra";

            try
            {
                con.Open();
                return con;
            }
            catch (SqlException ex)
            {
                return null;
            }

        }

    }

}
