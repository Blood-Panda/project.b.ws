using Microsoft.Extensions.Configuration;
using project.b.support.SupportUtil;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project.b.repository.Entity
{
    public interface IConfiguractionOracleConnection
    {
        string strConexion();
    }
    public class ConfiguractionOracleConnection : IConfiguractionOracleConnection
    {
        private string _Conexion;
        private readonly IConfiguration _config;
        public ConfiguractionOracleConnection(IConfiguration config)
        {
            _config = config;
            _Conexion = _config.GetSection(Constant.Conexion).Value;
        }

        public string strConexion()
        {
            return _Conexion;
        }
    }
}
