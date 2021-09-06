using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SunExpert.Framework.Sql
{
    public static class SqlHelper
    {
        /// <summary>
        /// Ejecuta procedimiento almacenado
        /// </summary>
        /// <param name="db">Contexto</param>
        /// <param name="procedureName">Nombre de procedimiento (Persona_I)</param>
        /// <param name="parameters">Arreglo de parametros (new SqlParameter("@Id", value))
        /// sug: usar Datos.SqlParameter</param>
        public static void ExecuteSqlCommand(DbContext db, string procedureName, params SqlParameter[] parameters)
        {
            try
            {


                string exec = "";

                foreach (SqlParameter x in parameters)
                {
                    if (x.Value == null)
                        x.Value = DBNull.Value;

                    exec = exec
                    + (exec.Length > 0 ? ", " : "")
                    + x.ParameterName
                    + (x.Direction == ParameterDirection.Output ? " OUTPUT" : "");
                }

                exec = "EXEC " + procedureName + " " + exec;

                db.Database.ExecuteSqlCommand(exec, parameters);
            }
            catch (Exception e)
            {
                throw e.GetBaseException();
            }
        }
        /// <summary>
        /// Ejecuta un procediento almacenado
        /// </summary>
        /// <param name="db">Contexto</param>
        /// <param name="procedureName">Nombre de procedimiento (Persona_I)</param>
        /// <param name="parameters">Arreglo de parametros (new SqlParameter("@Id", value))
        /// sug: usar Datos.SqlParameter</param>
        /// <returns>Colleccion de resultados del tipo T</returns>
        public static IEnumerable<T> ExecuteSqlQuery<T>(DbContext db, string procedureName, params SqlParameter[] parameters)
        {
            try
            {
                string exec = "";

                foreach (SqlParameter x in parameters)
                {
                    if (x.Value == null)
                        x.Value = DBNull.Value;

                    exec = exec
                    + (exec.Length > 0 ? ", " : "")
                    + x.ParameterName
                    + (x.Direction == ParameterDirection.Output ? " OUTPUT" : "");
                }

                exec = "EXEC " + procedureName + " " + exec;

                return db.Database.SqlQuery<T>(exec, parameters);
            }
            catch (Exception e)
            {
                throw e.GetBaseException();
            }
        }
        /// <summary>
        /// Crear un Parametro para sql, Sobrecargo SqlParameter
        /// </summary>
        /// <param name="paramName">Nombre del parametro (IdPersona) (ahorro el @) </param>
        /// <param name="value">Valor del parametro</param>
        /// <returns>SqlParameter</returns>
        public static SqlParameter SqlParameter(string paramName, object value)
        {

            SqlParameter p = SqlParameter(paramName, value, ParameterDirection.Input);

            return p;
        }
        /// <summary>
        /// Crear un Parametro para sql, Sobrecargo SqlParameter
        /// </summary>
        /// <param name="paramName">Nombre del parametro (IdPersona) (ahorro el @) </param>
        /// <param name="value">Valor del parametro</param>
        /// <returns>SqlParameter</returns>
        public static SqlParameter SqlParameter(string paramName, object value, SqlDbType typ)
        {

            SqlParameter p = SqlParameter(paramName, value, ParameterDirection.Input, typ);

            return p;
        }

        /// <summary>
        /// Crear un Parametro para sql, Sobrecargo SqlParameter
        /// </summary>
        /// <param name="paramName">Nombre del parametro (IdPersona) (ahorro el @) </param>
        /// <param name="value">Valor del parametro</param>
        ///<param name="size">Tamaño en del campo varchar(size)</param>
        /// <returns>SqlParameter</returns>
        public static SqlParameter SqlParameter(string paramName, object value, int size)
        {

            SqlParameter p = SqlParameter(paramName, value, ParameterDirection.Input);
            p.Size = size;

            return p;
        }
        /// <summary>
        /// Crear un Parametro para sql, Sobrecargo SqlParameter
        /// </summary>
        /// <param name="paramName">Nombre del parametro (IdPersona) (ahorro el @) </param>
        /// <param name="value">Valor del parametro</param>
        /// <param name="direction"></param>
        /// <returns>SqlParameter</returns>
        public static SqlParameter SqlParameter(string paramName, object value, ParameterDirection direction)
        {
            SqlParameter p = new SqlParameter();
            p.ParameterName = paramName.Contains("@") ? paramName : "@" + paramName;
            //p.ParameterName = paramName;
            p.Value = value;
            p.Direction = direction;
            return p;
        }
        /// <summary>
        /// Crear un Parametro para sql, Sobrecargo SqlParameter
        /// </summary>
        /// <param name="paramName">Nombre del parametro (IdPersona) (ahorro el @) </param>
        /// <param name="value">Valor del parametro</param>
        /// <param name="direction"></param>
        /// <returns>SqlParameter</returns>
        public static SqlParameter SqlParameter(string paramName, object value, ParameterDirection direction, SqlDbType typ)
        {
            SqlParameter p = SqlParameter(paramName, value, ParameterDirection.Input);
            p.SqlDbType = typ;

            return p;
        }
        public static ObjectParameter ObjectParameter(string paramName, object value)
        {
            return new ObjectParameter(paramName, value);
        }
        /// <summary>
        /// Crear un Parametro para sql, Sobrecargo SqlParameter
        /// </summary>
        /// <param name="paramName">Nombre del parametro (IdPersona) (ahorro el @) </param>
        /// <param name="value">Valor del parametro</param>
        /// <param name="direction"></param>
        ///<param name="size">Tamaño en del campo varchar(size)</param>
        /// <returns>SqlParameter</returns>
        public static SqlParameter SqlParameter(string paramName, object value, ParameterDirection direction, int size)
        {
            SqlParameter p = SqlParameter(paramName, value, direction);
            p.Size = size;

            return p;
        }
        /// <summary>
        /// Ejecutar sqlCommand desde connection de DbContext
        /// </summary>
        /// <param name="db"></param>
        /// <param name="procedureName">Nombre de procedimiento</param>
        /// <param name="parameters">Parametros</param>
        /// <returns>Devuelve datatable de resultados, directo de procedimiento</returns>
        public static DataTable ExecuteToDateTable(DbContext db, string procedureName, params SqlParameter[] parameters)
        {
            try
            {
                DataTable dt = new DataTable();

                DbDataReader dr = ExecuteDataReader(db, procedureName, parameters);

                dt.Load(dr);

                return dt;
            }
            catch (Exception e)
            {
                throw e.GetBaseException();
            }
        }
        /// <summary>
        /// Ejecutar sqlCommand desde connection de DbContext
        /// </summary>
        /// <param name="db"></param>
        /// <param name="procedureName">Nombre de procedimiento</param>
        /// <param name="parameters">Parametros</param>
        /// <returns>Devuelve datareader de resultados, directo de procedimiento</returns>
        public static DbDataReader ExecuteDataReader(DbContext db, string procedureName, params SqlParameter[] parameters)
        {
            try
            {
                DbDataReader dr;

                var cn = db.Database.Connection;

                try
                {
                    if (db.Database.Connection.State != ConnectionState.Open)
                        cn.Open();
                    using (var cmd = cn.CreateCommand())
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.CommandText = procedureName;
                        cmd.Parameters.AddRange(parameters);

                        dr = cmd.ExecuteReader();
                    }
                }
                finally
                {
                    //if (db.Database.Connection.State != ConnectionState.Closed)
                    //    cn.Close();
                }

                return dr;
            }
            catch (Exception e)
            {

                throw e.GetBaseException();
            }
        }

        public static ObjectResult<T> ExecuteFunction<T>(DbContext db, string procedureName, params ObjectParameter[] parameters)
        {
            try
            {
                var ObjContext = ((IObjectContextAdapter)db).ObjectContext;
                List<ObjectParameter> param = new List<ObjectParameter>();

                ObjectResult<T> obj = ObjContext.ExecuteFunction<T>(procedureName, param.ToArray());

                return obj;
            }
            catch (Exception e)
            {
                throw e.GetBaseException();
            }
        }
    }
}
