using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.ManagedDataAccess.Client;

namespace Datos
{
    public class Conexion
    {

        public Conexion()
        {
            ConnectionString = "Data Source=DESKTOP-E6EV4RF;User Id=cem2018;Password=1234;";
        }

        public string ConnectionString { get; set; }

        public DataTable Ejecutar(string sqlSentence)
        {
            OracleConnection conn = new OracleConnection(this.ConnectionString);
            OracleDataAdapter dr = new OracleDataAdapter(sqlSentence, conn);
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            dr.Fill(dt);
            return dt;
        }

        //public DataTable EjecutarSP(string nombreSP)
        //{
        //    //GIVE PROCEDURE NAME
        //    OracleConnection con = new OracleConnection(this.ConnectionString);
        //    OracleCommand cmd;
        //    cmd = new OracleCommand("PROCEDURE_NAME", con);
        //    cmd.CommandType = CommandType.StoredProcedure;

        //    //ASSIGN PARAMETERS TO BE PASSED
        //    cmd.Parameters.Add("PARAM1", OracleDbType.Varchar2).Value = VAL1;
        //    cmd.Parameters.Add("PARAM2", OracleDbType.Varchar2).Value = VAL2;

        //    //CALL PROCEDURE
        //    con.Open();
        //    OracleDataAdapter da = new OracleDataAdapter(cmd);
        //    cmd.ExecuteNonQuery();
            
        //    DataTable dt = new DataTable();
        //    da.Fill(dt);
        //    return dt;
        //}
    }
}
