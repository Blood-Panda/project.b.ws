using Oracle.ManagedDataAccess.Client;
using project.b.entity.Entity;
using project.b.repository.Entity;
using project.b.support.SupportUtil;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project.b.repository.Repository.Impl
{
    public class PaisRepository : IPaisRepository
    {
        #region "Variable de Conexión"
        private readonly IConfiguractionOracleConnection _ConfiguractionOracle;
        public PaisRepository(IConfiguractionOracleConnection ConfiguractionOracle)
        {
            this._ConfiguractionOracle = ConfiguractionOracle;
        }
        #endregion
        public List<PaisEntity> ListarPaises()
        {
            List<PaisEntity> list = new List<PaisEntity>();

            try
            {
                using (OracleConnection conexion = new OracleConnection(_ConfiguractionOracle.strConexion()))
                {
                    conexion.Open();

                    using (OracleCommand cmd = new OracleCommand())
                    {
                        cmd.Connection = conexion;
                        cmd.CommandText = Constant.StoreProcedure.SP_LISTAR_PAISES;
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.SetParameter("oListado", "", OracleDbType.RefCursor);

                        list = new List<PaisEntity>();
                        using (OracleDataReader oDrd = cmd.ExecuteReader())
                        {
                            int posId = oDrd.GetOrdinal("ID");
                            int posDescripcion = oDrd.GetOrdinal("DESCRIPCION");

                            while (oDrd.Read())
                            {
                                PaisEntity oEntidad = new PaisEntity();

                                oEntidad.id = oDrd.GetInt32DBNull(posId);
                                oEntidad.descripcion = oDrd.GetStringDBNull(posDescripcion);

                                list.Add(oEntidad);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return list;
        }
    }
}
