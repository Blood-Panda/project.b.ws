using Oracle.ManagedDataAccess.Client;
using System;
using System.Data;

namespace project.b.support.SupportUtil
{
    public static class FunctionParameter
    {
        public static void SetParameter(this OracleCommand cmd, string name, object value, OracleDbType oracleType = OracleDbType.Varchar2, int size = 0, ParameterDirection direction = ParameterDirection.Input)
        {
            OracleParameter obj = new OracleParameter();
            obj.ParameterName = name;
            obj.OracleDbType = oracleType;
            if (obj.OracleDbType == OracleDbType.RefCursor)
            {
                obj.Direction = ParameterDirection.Output;
            }
            else
            {
                if (direction == ParameterDirection.Input)
                {
                    obj.Value = value;
                }
                obj.Direction = direction;
            }

            if (size != 0) obj.Size = size;

            cmd.Parameters.Add(obj);
        }

        public static string GetStringDBNull(this OracleDataReader oDrd, int ordinal)
        {
            string salida = string.Empty;
            object value = oDrd[ordinal];

            if (value == null || value == DBNull.Value || oDrd.IsDBNull(ordinal))
            {
                salida = string.Empty;
            }
            else
            {
                salida = oDrd.GetString(ordinal);
            }
            return salida;
        }

        public static Int32 GetInt32DBNull(this OracleDataReader oDrd, int ordinal)
        {
            Int32 salida = 0;
            object value = oDrd[ordinal];

            if (value == null || value == DBNull.Value || oDrd.IsDBNull(ordinal))
            {
                salida = 0;
            }
            else
            {
                Int32.TryParse(Convert.ToString(value), out salida);
            }
            return salida;
        }

        public static double GetDoubleDBNull(this OracleDataReader oDrd, int ordinal)
        {
            double salida = 0.0d;
            object value = oDrd[ordinal];

            if (value == null || value == DBNull.Value || oDrd.IsDBNull(ordinal))
            {
                salida = 0.0d;
            }
            else
            {
                double.TryParse(Convert.ToString(value), out salida);
            }
            return salida;
        }

        public static decimal GetDecimalDBNull(this OracleDataReader oDrd, int ordinal)
        {
            decimal salida = 0;
            object value = oDrd[ordinal];

            if (value == null || value == DBNull.Value || oDrd.IsDBNull(ordinal))
            {
                salida = 0;
            }
            else
            {
                decimal.TryParse(Convert.ToString(value), out salida);
            }
            return salida;
        }
    }
}

