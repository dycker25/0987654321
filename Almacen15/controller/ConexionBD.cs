using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace almacen_telar.controller
{
     public class ConexionBD
    {
         private string ObtenerCadenaConexion()
         {
             try
             {
                 //cadena del app.conf
                 string cadenaconexion = "Data Source=PC\\SQLEXPRESS;Initial Catalog= Almacen;Integrated Security=True";

                 SqlConnectionStringBuilder sqlString = new SqlConnectionStringBuilder(cadenaconexion);

                 return sqlString.ConnectionString;

             }
             catch (Exception ex)
             {

                 throw ex;
             }
         }
         public DataTable EjecutarSPResultSet(String nombreSP, IDataParameter[] parametros)
         {
             try
             {
                 using (SqlConnection conexion = new SqlConnection(ObtenerCadenaConexion()))
                 {
                     //Inici conexion
                     conexion.Open();
                     //Crear un comando para ejecutar
                     SqlCommand cmd = new SqlCommand(nombreSP, conexion);
                     //procedimientos
                     cmd.CommandType = CommandType.StoredProcedure;
                     cmd.CommandTimeout = 0;

                     if (parametros != null)
                     {
                         foreach (var parametro in parametros)
                         {
                             cmd.Parameters.Add(parametro);
                         }
                     }

                     //Ejecutamos el comando por medio del adaptador de SQL
                     SqlDataAdapter adptadorSql = new SqlDataAdapter(cmd);

                     DataSet conjutoResultados = new DataSet();
                     adptadorSql.Fill(conjutoResultados);
                     //Regresamos el conjunto de tablas
                     return conjutoResultados.Tables[0];


                 }

             }
             catch (Exception ex)
             {

                 throw ex;
             }
         }

         public bool EjecutarSPSinRetorno(String nombreSP, IDataParameter[] parametros)
         {
             try
             {
                 using (SqlConnection conexion = new SqlConnection(ObtenerCadenaConexion()))
                 {
                     //Inici conexion
                     conexion.Open();
                     //Crear un comando para ejecutar
                     SqlCommand cmd = new SqlCommand(nombreSP, conexion);
                     //procedimientos
                     cmd.CommandType = CommandType.StoredProcedure;
                     cmd.CommandTimeout = 0;

                     if (parametros != null)
                     {
                         foreach (var parametro in parametros)
                         {
                             cmd.Parameters.Add(parametro);
                         }
                     }

                     //retorna
                     int rengloesAfectados = cmd.ExecuteNonQuery();

                     return (rengloesAfectados <= 0) ? (false) : (true);


                 }

             }
             catch (Exception ex)
             {

                 throw ex;
             }
         }
    }
}
