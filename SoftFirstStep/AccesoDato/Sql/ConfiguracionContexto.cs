using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Common;
using System.Data.SqlClient;
using System.Data.EntityClient;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace AccesoDato.Sql {
    public class ConfiguracionContexto {
        private Modelo.PruebaSoftEntidades contexto;

        #region Contexto

        ///<author>Jennifer Salinas</author>
        ///<creationdate>01-02-2015</creationdate>
        /// <summary>
        /// Método que permite crear el contexto
        /// </summary>
        /// <returns></returns>
        private void CrearContexto() {
            DbConnection conexion;
            SqlConnectionStringBuilder CadenaConexionSql = new SqlConnectionStringBuilder();
            EntityConnectionStringBuilder CadenaConexionEntity = new EntityConnectionStringBuilder();

            //Operaciones
            //Configurando conexión a SQL
            // CadenaConexionSql.DataSource = ManejadorConfiguracion.ObtenerValor("administracionConfig", "baseDatosConfig", "ServidorBD");
            // CadenaConexionSql.InitialCatalog = ManejadorConfiguracion.ObtenerValor("administracionConfig", "baseDatosConfig", "BaseDatos");
            // CadenaConexionSql.IntegratedSecurity = Convert.ToBoolean(ManejadorConfiguracion.ObtenerValor("administracionConfig", "baseDatosConfig", "SeguridadIntegrada"));
            // 
            // CadenaConexionSql.MultipleActiveResultSets = true;
            // CadenaConexionSql.ApplicationName = "EntityFramework";
            // CadenaConexionSql.ConnectTimeout = Convert.ToInt32(ManejadorConfiguracion.ObtenerValor("administracionConfig", "baseDatosConfig", "TiempoEsperaBD"));
            // CadenaConexionSql.Encrypt = Convert.ToBoolean(ManejadorConfiguracion.ObtenerValor("administracionConfig", "baseDatosConfig", "EncriptarConexionBD"));
            //
            // CadenaConexionSql.UserID = ManejadorConfiguracion.ObtenerValor("administracionConfig", "baseDatosConfig", "UsuarioBD");
            // CadenaConexionSql.Password = ManejadorConfiguracion.ObtenerValor("administracionConfig", "baseDatosConfig", "ClaveBD");

            //Configurando conexión a Entity
            CadenaConexionEntity.Provider = "System.Data.SqlClient";
            CadenaConexionEntity.ProviderConnectionString = CadenaConexionSql.ToString();
            CadenaConexionEntity.Metadata = @"res://*/Sql.Modelo.PruebaSoftModelo.csdl|res://*/Sql.Modelo.PruebaSoftModelo.ssdl|res://*/Sql.Modelo.PruebaSoftModelo.msl";

            //Creando conexion.
            conexion = new EntityConnection(CadenaConexionEntity.ToString());

            //Se necesita abrir un conexión para que la suplantación se realice 
            contexto = new Modelo.PruebaSoftEntidades(conexion);
            contexto.Configuration.LazyLoadingEnabled = false;
            contexto.Configuration.ProxyCreationEnabled = false;
            //resultado
        }

        ///<author>Jennifer Salinas</author>
        ///<creationdate>01-02-2015</creationdate>
        /// <summary>
        /// Método que permite obtener el contexto
        /// </summary>
        /// <returns></returns>
        public Modelo.PruebaSoftEntidades ObtenerContexto() {
            if ( contexto == null )
                CrearContexto();
            return contexto;
        }

        #endregion

    }
}