using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Importar_datos
{
    public class D_Clientes
    {
        public int IdClientes { get; set; }
        public string CIORUC { get; set; }
        public string RazonSocial { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string TextoBuscar { get; set; }

        //METODO MOSTRAR REGISTROS DE LA TABLA CLIENTES
        public DataTable MostrarRegistros()
        {
            DataTable DtResultado = new DataTable();
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = CD_Conexion.conexion;
                SqlCommand SqlCmd = new SqlCommand
                {
                    Connection = SqlCon,
                    CommandText = "spmostrar_clientes",
                    CommandType = CommandType.StoredProcedure
                };

                //Declarar un SqlDataAdapter para Ejecutar los Comandos y llenar el DataTable
                SqlDataAdapter SqlDat = new SqlDataAdapter(SqlCmd);
                SqlDat.Fill(DtResultado);
            }
            catch (Exception) { DtResultado = null; }
            return DtResultado;
        }

        //METODO BUSCAR REGISTROS DE LA TABLA CLIENTES
        public DataTable BuscarRegistros(CD_Clientes Clientes)
        {
            DataTable DtResultado = new DataTable();
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = CD_Conexion.conexion;
                SqlCommand SqlCmd = new SqlCommand
                {
                    Connection = SqlCon,
                    CommandText = "spbuscar_clientes",
                    CommandType = CommandType.StoredProcedure
                };

                SqlParameter ParTextoBuscar = new SqlParameter
                {
                    ParameterName = "@textobuscar",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 50,
                    Value = Clientes.TextoBuscar
                };
                SqlCmd.Parameters.Add(ParTextoBuscar);

                SqlDataAdapter SqlDat = new SqlDataAdapter(SqlCmd);
                SqlDat.Fill(DtResultado);
            }
            catch (Exception) { DtResultado = null; }
            return DtResultado;
        }
    }
}
