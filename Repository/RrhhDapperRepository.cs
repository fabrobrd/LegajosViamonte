using Dapper;
using Legajos.Domain;
using Legajos.Domain.Repository;
using System.Data.SqlClient;

namespace Legajos.Repository
{
    internal class RrhhDapperRepository : Irrhh
    {
        public IEnumerable<Rrhh> GetAllActives(int active)
        {
            List<Rrhh> rrhhs = null;
            string sql = string.Empty;
            if (active < 2)
            {
                sql = "Select LEGAJO, NOMBRE, NIVEL, PASSWD, code, doc_tipo, doc_nro, cuil, IF_ACTIVO, IF_DEL, f_alta from RRHH where IF_DEL = " + active;
            }
            else
            {
                sql = "Select LEGAJO, NOMBRE, NIVEL, PASSWD, code, doc_tipo, doc_nro, cuil, IF_ACTIVO, IF_DEL, f_alta from RRHH";
            }
            using (var connection = new SqlConnection(ConfigurationHelper.ViamonteConnetionString))
            {
                rrhhs = connection.Query<Rrhh>(sql).ToList();
            }
            return rrhhs;
        }

        public Rrhh GetPerson(int legajo)
        {
            Rrhh result = null;
            string sql = string.Empty;
            sql = "Select LEGAJO, NOMBRE, NIVEL, PASSWD, code, doc_tipo, doc_nro, cuil, IF_ACTIVO, IF_DEL, f_alta from RRHH where legajo = @legajo";
            using (var connection = new SqlConnection(ConfigurationHelper.ViamonteConnetionString))
            {
                result = connection.QuerySingle<Rrhh>(sql, new { Legajo = legajo });
            }
            return result;
        }

        public async Task<int> AddPerson(int legajo, string nombre, int nivel, string passwd, string cuil, int if_activo, int if_del, DateTime f_alta)
        {
            string sql = string.Empty;
            int rowsAffected = 0;
            sql = "insert into RRHH (LEGAJO, NOMBRE, NIVEL, PASSWD,cuil, IF_ACTIVO, IF_DEL, f_alta) values (@legajo, @Nombre, @Nivel, @Passwd, @Cuil, @If_activo, @If_del, @F_alta )";
            var anonymousPerson = new
            {
                Legajo = legajo,
                Nombre = nombre,
                Nivel = nivel,
                Passwd = passwd,
                Cuil = cuil,
                If_activo = if_activo,
                If_del = if_del,
                F_alta = f_alta
            };
            try
            {
                
                using (var connection = new SqlConnection(ConfigurationHelper.ViamonteConnetionString))
                {
                    rowsAffected = await connection.ExecuteAsync(sql, anonymousPerson);
                }
                
            }
            catch (Exception e)
            {
                throw new ArgumentException(e.Message);
            }
            return rowsAffected;
        }

        public async Task<int> UnsubscribePerson(int legajo)
        {
            string sql = string.Empty;
            int rowsAffected = 0;

            sql = "Update RRHH set if_del = 1, if_activo = 0 where legajo = @Legajo";
            var anonymousPerson = new { Legajo = legajo };
            try
            {
                
                using (var connection = new SqlConnection(ConfigurationHelper.ViamonteConnetionString))
                {
                    rowsAffected = await connection.ExecuteAsync(sql, anonymousPerson);
                }
                
            }
            catch (Exception e)
            {
                throw new ArgumentException(e.Message);
            }
            return rowsAffected;

        }

        public async Task<int> SubscribePerson(int legajo)
        {
            string sql = string.Empty;
            int rowsAffected = 0;

            sql = "Update RRHH set if_del = 0, if_activo = 1 where legajo = @Legajo";
            var anonymousPerson = new { Legajo = legajo };
            try
            {
                
                using (var connection = new SqlConnection(ConfigurationHelper.ViamonteConnetionString))
                {
                    rowsAffected = await connection.ExecuteAsync(sql, anonymousPerson);
                }
                
            }
            catch (Exception e)
            {
                throw new ArgumentException(e.Message);
            }
            return rowsAffected;

        }


        public async Task<int> UpdatePerson(int legajo, string nombre, int nivel, string passwd, string cuil)
        {
            string sql = string.Empty;
            int rowsAffected = 0;

            sql = "Update RRHH set nombre = @Nombre, nivel = @nivel, passwd = @Passwd, cuil = @Cuil where legajo = @Legajo";
            var anonymousPerson = new
            {
                Legajo = legajo,
                Nombre = nombre,
                Nivel = nivel,
                Passwd = passwd,
                Cuil = cuil,
            };
            try
            {
                using (var connection = new SqlConnection(ConfigurationHelper.ViamonteConnetionString))
                {
                    rowsAffected = await connection.ExecuteAsync(sql, anonymousPerson);
                }
                
            }
            catch (Exception e)
            {
                throw new ArgumentException(e.Message);
            }
            return rowsAffected;

        }
    }
}
