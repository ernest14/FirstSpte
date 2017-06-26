using System;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Transactions;
using System.Data.Common;
using System.ComponentModel;
using System.Data.SqlClient;
using AccesoDato.Sql.Modelo;
using AccesoDato.Sql.Mapeo;
using Utilidades.Mensajes;

namespace AccesoDato.Sql.Persona {

    /// <author>Ernesto Medrano</author>
    /// <creationdate>16-sep-2015</creationdate>
    /// <summary>
    /// Clase Persona que contiene el CRUD.
    /// </summary>
    public class PersonaAD {

        #region Atributos

        /// <author>Ernesto Medrano</author>
        /// <creationdate>16-sep-2015</creationdate>
        /// <summary>
        /// Identificador del Usuario.
        /// </summary>
        public Int32 IdUsuario {
            get {
                return 1;
                //ManejadorIdentidad.IdentidadActual != null ? ManejadorIdentidad.IdentidadActual.IdCuenta : 0;
            }
        }

        /// <author>Ernesto Medrano</author>
        /// <creationdate>16-sep-2015</creationdate>
        /// <summary>
        /// Contexto del modelo entidad.
        /// </summary>
        public PruebaSoftEntidades Contexto {
            get {
                return ConfiguracionContexto.Value.ObtenerContexto();
            }
        }

        /// <author>Jose Miguel Lopez Sevilla/author>
        /// <creationdate>06-Ene-2017</creationdate>
        /// <summary>
        /// Objeto para el AutoMappeo
        /// </summary>
        private ConfiguracionMapeoAD AutoMapeo {
            get;
            set;
        }

        /// <author>Ernesto Medrano</author>
        /// <creationdate>29-Oct-2015</creationdate>
        /// <summary>
        /// ConfiguracionContexto que es pasado por inyección
        /// </summary>
        private Lazy<ConfiguracionContexto> ConfiguracionContexto {
            get;
            set;
        }

        #endregion

        #region Constructores

        /// <author>Ernesto Medrano</author>
        /// <creationdate>16-sep-2015</creationdate>
        /// <summary>
        /// Constructor Clase Persona.
        /// </summary>
        public PersonaAD(Lazy<ConfiguracionContexto> configuracionContexto, ConfiguracionMapeoAD autoMapeo) {
            this.ConfiguracionContexto = configuracionContexto;
            AutoMapeo = autoMapeo;
            //this.Contexto = (AdministracionBDEntidades)configuracionContexto.ObtenerContexto();
        }

        #endregion

        #region Metodos

        /// <author>Ernesto Medrano</author>
        /// <creationdate>16-sep-2015</creationdate>
        /// <summary>
        /// Método que agrega un nuevo objeto de tipo Persona.
        /// </summary>
        /// <param name="persona">Objeto tipo Persona a ser agregado.</param>
        /// <returns>True: Registro agregado </returns>        
        public Boolean Agregar(Negocio.Entidades.Persona.Persona persona) {
            //Declaraciones
            Sql.Modelo.Persona personaAD = new Sql.Modelo.Persona();
            Boolean resultado = false;
            // transaccion.Dispose();

            //Operaciones
            if ( persona == null ) {
                throw new ArgumentNullException("persona", MensajeExcepcion.ParametroEnNulo);
            }
            if ( persona.IdPersona != 0 ) {
                throw new ArgumentException(MensajeExcepcion.IdentificadorObjetoCreacion, "persona");
            }

            try {
                ////using (transaccion = new TransactionScope()) {
                //using (var Contexto = (AdministracionBDEntidades)ConfiguracionContexto.ObtenerContexto())
                //{
                personaAD = AutoMapeo.Mapeo(persona, personaAD);
                personaAD.EstaActivo = true;
                personaAD.IdUsuarioCreacion = IdUsuario;
                personaAD.FechaCreacion = DateTime.Now;
                Contexto.Personas.Add(personaAD);
                if ( Contexto.SaveChanges() > 0 ) {
                    persona.IdPersona = personaAD.IdPersona;
                    resultado = true;
                }
            } catch ( Exception ex ) {
                //Parámetros
                List<Object> parametros = new List<Object>();
                //parametros.AddManejadorIdentidad.IdentidadActual != null ? ManejadorIdentidad.IdentidadActual.Name : "");

                //parametros.Addpersona);

                //RegistroEventoWindows.RegistroEventoFun.RegistroExcepcionUI(MensajeExcepcion.ErrorInesperado, "AgregarPersona", RegistroEventoWindows.ExtraerTraza(ex), RegistroEventoWindows.ExtraerMensaje(ex), (ManejadorIdentidad.IdentidadActual != null ? ManejadorIdentidad.IdentidadActual.Name : null), parametros);
                throw;
            }
            //if (resultado == true) {
            //   // transaccion.Complete();
            //}
            // }
            //}

            //Resultado
            return resultado;
        }

        ///// <author>Ernesto Medrano</author>
        ///// <creationdate>16-sep-2015</creationdate>
        ///// <summary>
        ///// Método que agrega un nuevo listado de objeto de tipo Persona.
        ///// </summary>
        ///// <param name="PersonaListado">Listado de objetos de tipo Persona a ser agregados.</param>
        ///// <returns>True: Registros agregados</returns>
        //public Boolean AgregarListado(List<Negocio.Entidades.Persona.Persona> personaListado) {

        //    //Declaraciones
        //    Sql.Modelo.Persona personaAD = new Sql.Modelo.Persona();
        //    List<Sql.Modelo.Persona> personaADListado = new List<Sql.Modelo.Persona>();
        //    Boolean resultado = false;
        //    // transaccion.Dispose();

        //    //Operaciones
        //    if ( personaListado == null ) {
        //        throw new ArgumentNullException("personaListado", MensajeExcepcion.ParametroEnNulo);
        //    }

        //    if ( personaListado.Count() <= 0 ) {
        //        throw new ArgumentException(MensajeExcepcion.ParametroListaVacia, "personaListado");
        //    }

        //    if ( personaListado.Where(p => p.IdPersona != 0).Count() > 0 ) {
        //        throw new ArgumentException(MensajeExcepcion.IdentificadorObjetoCreacionListado, "personaListado");
        //    }

        //    try {
        //        ////using (transaccion = new TransactionScope()) {
        //        //using (var Contexto = (AdministracionBDEntidades)ConfiguracionContexto.ObtenerContexto())
        //        //{
        //        foreach ( var p in personaListado ) {

        //            personaAD = new Sql.Modelo.Persona();
        //            personaAD = AutoMapeo.Mapeo(p, personaAD);
        //            personaAD.EstaActivo = true;
        //            personaAD.IdUsuarioCreacion = IdUsuario;
        //            personaAD.FechaCreacion = DateTime.Now;
        //            Contexto.Personas.Add(personaAD);
        //            personaADListado.Add(personaAD);

        //        }

        //        if ( Contexto.SaveChanges() > 0 ) {
        //            for ( int i = 0;i < personaListado.Count();i++ ) {
        //                personaListado[i].IdPersona = personaADListado[i].IdPersona;
        //            }
        //            resultado = true;
        //        }
        //    } catch ( Exception ex ) {
        //        //Parámetros
        //        List<Object> parametros = new List<Object>();
        //        //parametros.AddManejadorIdentidad.IdentidadActual != null ? ManejadorIdentidad.IdentidadActual.Name : "");
        //        personaListado.ForEach(x => //parametros.Addx));


        //        //RegistroEventoWindows.RegistroEventoFun.RegistroExcepcionUI(MensajeExcepcion.ErrorInesperado, "AgregarListadoPersona", RegistroEventoWindows.ExtraerTraza(ex), RegistroEventoWindows.ExtraerMensaje(ex), (ManejadorIdentidad.IdentidadActual != null ? ManejadorIdentidad.IdentidadActual.Name : null), parametros);
        //        throw;
        //    }

        //    //if (resultado == true) {
        //    //   // transaccion.Complete();
        //    //}
        //    //}
        //    //}

        //    //Resultado
        //    return resultado;
        //}

        ///// <author>Ernesto Medrano</author>
        ///// <creationdate>16-sep-2015</creationdate>
        ///// <summary>
        ///// Método para dar de alta al objeto de tipo Persona. 
        ///// Cambia el campo EstaActivo a True.
        ///// </summary>
        ///// <param name="idPersona">Identificador del objeto.</param>
        ///// <returns>True: Operación exitosa</returns>
        //public Boolean DarAlta(Int32 idPersona) {

        //    //Declaraciones
        //    Sql.Modelo.Persona persona;
        //    bool resultado = false;
        //    // transaccion.Dispose();

        //    //Operaciones
        //    if ( idPersona <= 0 ) {
        //        throw new ArgumentException(MensajeExcepcion.IdentificadorObjetoNoValido, "idPersona");
        //    }

        //    try {
        //        ////using (transaccion = new TransactionScope()) {
        //        //using (var Contexto = (AdministracionBDEntidades)ConfiguracionContexto.ObtenerContexto())
        //        //{
        //        persona = Contexto.Personas.Where(p => p.IdPersona == idPersona).FirstOrDefault();
        //        if ( persona == null ) {
        //            throw new RegistroNoEncontradoExcepcion(MensajeExcepcion.RegistroNoEncontrado, typeof(Modelo.Persona), idPersona);
        //        }

        //        persona.EstaActivo = true;
        //        persona.FechaModificacion = DateTime.Now;
        //        persona.IdUsuarioModificacion = IdUsuario;

        //        if ( Contexto.SaveChanges() > 0 ) {
        //            resultado = true;
        //        }
        //    } catch ( Exception ex ) {
        //        //Parámetros
        //        List<Object> parametros = new List<Object>();
        //        //parametros.AddManejadorIdentidad.IdentidadActual != null ? ManejadorIdentidad.IdentidadActual.Name : "");

        //        //parametros.AddidPersona);

        //        //RegistroEventoWindows.RegistroEventoFun.RegistroExcepcionUI(MensajeExcepcion.ErrorInesperado, "DarAltaPersona", RegistroEventoWindows.ExtraerTraza(ex), RegistroEventoWindows.ExtraerMensaje(ex), (ManejadorIdentidad.IdentidadActual != null ? ManejadorIdentidad.IdentidadActual.Name : null), parametros);
        //        throw;
        //    }

        //    //if (resultado == true) {
        //    //   // transaccion.Complete();
        //    //}
        //    //}
        //    //}

        //    //Resultado
        //    return resultado;
        //}

        ///// <author>Ernesto Medrano</author>
        ///// <creationdate>16-sep-2015</creationdate>
        ///// <summary>
        ///// Método para dar de alta al listado de objeto de tipo Persona.
        ///// Cambian los campos EstaActivo a True.
        ///// </summary>
        ///// <param name="idPersonaListado">Listado de identificadores de objetos.</param>
        ///// <returns>True: Operación exitosa
        ///// </returns>
        //public Boolean DarAltaListado(List<Int32> idPersonaListado) {

        //    //Declaraciones
        //    Sql.Modelo.Persona persona;
        //    bool resultado = false;
        //    // transaccion.Dispose();

        //    //Operaciones
        //    if ( idPersonaListado == null ) {
        //        throw new ArgumentNullException("idPersonaListado", MensajeExcepcion.ParametroEnNulo);
        //    }

        //    if ( idPersonaListado.Count() == 0 ) {
        //        throw new ArgumentException(MensajeExcepcion.ParametroListaVacia, "idPersonaListado");
        //    }

        //    if ( idPersonaListado.Where(l => l <= 0).Count() > 0 ) {
        //        throw new ArgumentException(MensajeExcepcion.IdentificadorObjetoNoValidoListado, "idPersonaListado");
        //    }

        //    try {
        //        ////using (transaccion = new TransactionScope()) {
        //        //using (var Contexto = (AdministracionBDEntidades)ConfiguracionContexto.ObtenerContexto())
        //        //{
        //        foreach ( var perAD in idPersonaListado ) {
        //            persona = Contexto.Personas.Where(p => p.IdPersona == perAD).FirstOrDefault();

        //            if ( persona == null ) {
        //                throw new RegistroNoEncontradoExcepcion(MensajeExcepcion.RegistroNoEncontrado, typeof(Modelo.Persona), perAD);
        //            }

        //            persona.EstaActivo = true;
        //            persona.IdUsuarioModificacion = IdUsuario;
        //            persona.FechaModificacion = DateTime.Now;
        //        }

        //        if ( Contexto.SaveChanges() > 0 ) {
        //            resultado = true;
        //        }
        //    } catch ( Exception ex ) {
        //        //Parámetros
        //        List<Object> parametros = new List<Object>();
        //        //parametros.AddManejadorIdentidad.IdentidadActual != null ? ManejadorIdentidad.IdentidadActual.Name : "");
        //        idPersonaListado.ForEach(x => //parametros.Addx));


        //        //RegistroEventoWindows.RegistroEventoFun.RegistroExcepcionUI(MensajeExcepcion.ErrorInesperado, "DarAltaListadoPersona", RegistroEventoWindows.ExtraerTraza(ex), RegistroEventoWindows.ExtraerMensaje(ex), (ManejadorIdentidad.IdentidadActual != null ? ManejadorIdentidad.IdentidadActual.Name : null), parametros);
        //        throw;
        //    }

        //    //if (resultado == true) {
        //    //   // transaccion.Complete();
        //    //}
        //    //}
        //    //}

        //    //Resultado
        //    return resultado;
        //}

        ///// <author>Ernesto Medrano</author>
        ///// <creationdate>16-sep-2015</creationdate>
        ///// <summary>
        ///// Método para dar de baja al objeto de tipo Persona; 
        ///// Cambia el estado del objeto a "False".
        ///// </summary>
        ///// <param name="idPersona">Identificador del objeto.</param>
        ///// <returns>True: Operación exitosa</returns>
        //public Boolean DarBaja(Int32 idPersona) {

        //    //Declaraciones
        //    Sql.Modelo.Persona persona;
        //    bool resultado = false;
        //    // transaccion.Dispose();

        //    //Operaciones
        //    if ( idPersona <= 0 ) {
        //        throw new ArgumentException(MensajeExcepcion.IdentificadorObjetoNoValido, "idPersona");
        //    }

        //    try {
        //        ////using (transaccion = new TransactionScope()) {
        //        //using (var Contexto = (AdministracionBDEntidades)ConfiguracionContexto.ObtenerContexto())
        //        //{
        //        persona = Contexto.Personas.Where(p => p.IdPersona == idPersona).FirstOrDefault();

        //        if ( persona == null ) {
        //            throw new RegistroNoEncontradoExcepcion(MensajeExcepcion.RegistroNoEncontrado, typeof(Modelo.Persona), idPersona);
        //        }

        //        persona.EstaActivo = false;
        //        persona.FechaModificacion = DateTime.Now;
        //        persona.IdUsuarioModificacion = IdUsuario;

        //        if ( Contexto.SaveChanges() > 0 ) {
        //            resultado = true;
        //        }
        //    } catch ( Exception ex ) {
        //        //Parámetros
        //        List<Object> parametros = new List<Object>();
        //        //parametros.AddManejadorIdentidad.IdentidadActual != null ? ManejadorIdentidad.IdentidadActual.Name : "");

        //        //parametros.AddidPersona);

        //        //RegistroEventoWindows.RegistroEventoFun.RegistroExcepcionUI(MensajeExcepcion.ErrorInesperado, "DarBajaPersona", RegistroEventoWindows.ExtraerTraza(ex), RegistroEventoWindows.ExtraerMensaje(ex), (ManejadorIdentidad.IdentidadActual != null ? ManejadorIdentidad.IdentidadActual.Name : null), parametros);
        //        throw;
        //    }

        //    //if (resultado == true) {
        //    //   // transaccion.Complete();
        //    //}
        //    //}
        //    //}

        //    //Resultado
        //    return resultado;
        //}

        ///// <author>Ernesto Medrano</author>
        ///// <creationdate>16-sep-2015</creationdate>
        ///// <summary>
        ///// Método para dar de baja al listado de objeto de tipo Persona.
        ///// Cambian los campos EstaActivo a True.
        ///// </summary>
        ///// <param name="idPersonaListado">Listado de identificadores de objetos.</param>
        ///// <returns>True: Operación exitosa.</returns>
        //public Boolean DarBajaListado(List<Int32> idPersonaListado) {

        //    //Declaraciones
        //    Sql.Modelo.Persona persona;
        //    bool resultado = false;
        //    // transaccion.Dispose();

        //    //Operaciones
        //    if ( idPersonaListado == null ) {
        //        throw new ArgumentNullException("idPersonaListado", MensajeExcepcion.ParametroEnNulo);
        //    }

        //    if ( idPersonaListado.Count() == 0 ) {
        //        throw new ArgumentException(MensajeExcepcion.ParametroListaVacia, "idPersonaListado");
        //    }

        //    if ( idPersonaListado.Where(p => p <= 0).Count() > 0 ) {
        //        throw new ArgumentException(MensajeExcepcion.IdentificadorObjetoNoValidoListado, "idPersonaListado");
        //    }

        //    try {
        //        ////using (transaccion = new TransactionScope()) {
        //        //using (var Contexto = (AdministracionBDEntidades)ConfiguracionContexto.ObtenerContexto())
        //        //{
        //        foreach ( var perAD in idPersonaListado ) {
        //            persona = Contexto.Personas.Where(ad => ad.IdPersona == perAD).FirstOrDefault();

        //            if ( persona == null ) {
        //                throw new RegistroNoEncontradoExcepcion(MensajeExcepcion.RegistroNoEncontrado, typeof(Modelo.Persona), perAD);
        //            }

        //            persona.EstaActivo = false;
        //            persona.IdUsuarioModificacion = IdUsuario;
        //            persona.FechaModificacion = DateTime.Now;
        //        }

        //        if ( Contexto.SaveChanges() > 0 ) {
        //            resultado = true;
        //        }
        //    } catch ( Exception ex ) {
        //        //Parámetros
        //        List<Object> parametros = new List<Object>();
        //        //parametros.AddManejadorIdentidad.IdentidadActual != null ? ManejadorIdentidad.IdentidadActual.Name : "");
        //        idPersonaListado.ForEach(x => //parametros.Addx));

        //        //RegistroEventoWindows.RegistroEventoFun.RegistroExcepcionUI(MensajeExcepcion.ErrorInesperado, "DarBajaListadoPersona", RegistroEventoWindows.ExtraerTraza(ex), RegistroEventoWindows.ExtraerMensaje(ex), (ManejadorIdentidad.IdentidadActual != null ? ManejadorIdentidad.IdentidadActual.Name : null), parametros);
        //        throw;
        //    }

        //    //if (resultado == true) {
        //    //   // transaccion.Complete();
        //    //}
        //    //}
        //    //}

        //    //Resultado
        //    return resultado;
        //}

        ///// <author>Ernesto Medrano</author>
        ///// <creationdate>16-sep-2015</creationdate>
        ///// <summary>
        ///// Método para editar un objeto de tipo Persona.
        ///// </summary>
        ///// <param name="Persona">Objeto tipo Persona a ser editado.</param>
        ///// <returns>True: Operación exitosa</returns>
        //public Boolean Actualizar(Negocio.Entidades.Persona.Persona persona) {

        //    //Declaraciones
        //    Sql.Modelo.Persona personaAD;
        //    Boolean resultado = false;
        //    // transaccion.Dispose();

        //    //Operaciones
        //    if ( persona == null ) {
        //        throw new ArgumentNullException("Persona", MensajeExcepcion.ParametroEnNulo);
        //    }

        //    if ( persona.IdPersona <= 0 ) {
        //        throw new ArgumentException(MensajeExcepcion.IdentificadorObjetoNoValido, "persona");
        //    }

        //    try {
        //        ////using (transaccion = new TransactionScope()) {
        //        //using (var Contexto = (AdministracionBDEntidades)ConfiguracionContexto.ObtenerContexto())
        //        //{
        //        personaAD = Contexto.Personas.Where(p => p.IdPersona == persona.IdPersona).FirstOrDefault();

        //        if ( personaAD == null ) {
        //            throw new RegistroNoEncontradoExcepcion(MensajeExcepcion.RegistroNoEncontrado, typeof(Modelo.Persona), persona.IdPersona);
        //        }

        //        personaAD = AutoMapeo.Mapeo(persona, personaAD);
        //        personaAD.FechaModificacion = DateTime.Now;
        //        personaAD.IdUsuarioModificacion = IdUsuario;

        //        if ( Contexto.SaveChanges() > 0 ) {
        //            resultado = true;
        //        }
        //    } catch ( Exception ex ) {
        //        //Parámetros
        //        List<Object> parametros = new List<Object>();
        //        //parametros.AddManejadorIdentidad.IdentidadActual != null ? ManejadorIdentidad.IdentidadActual.Name : "");

        //        //parametros.Addpersona);

        //        //RegistroEventoWindows.RegistroEventoFun.RegistroExcepcionUI(MensajeExcepcion.ErrorInesperado, "ActualizarPersona", RegistroEventoWindows.ExtraerTraza(ex), RegistroEventoWindows.ExtraerMensaje(ex), (ManejadorIdentidad.IdentidadActual != null ? ManejadorIdentidad.IdentidadActual.Name : null), parametros);
        //        throw;
        //    }

        //    //if (resultado == true) {
        //    //   // transaccion.Complete();
        //    //}
        //    // }
        //    //}

        //    //Resultado
        //    return resultado;
        //}

        ///// <author>Ernesto Medrano</author>
        ///// <creationdate>16-sep-2015</creationdate>
        ///// <summary>
        ///// Método para editar un listado de objetos de tipo Persona.
        ///// </summary>
        ///// <param name="PersonaListado">Listado de objetos de tipo Persona a ser editados</param>
        ///// <returns>True: Operación exitosa</returns>
        //public Boolean ActualizarListado(List<Negocio.Entidades.Persona.Persona> personaListado) {

        //    //Declaraciones
        //    Sql.Modelo.Persona personaAD;
        //    Boolean resultado = false;
        //    // transaccion.Dispose();

        //    //Operaciones
        //    if ( personaListado == null ) {
        //        throw new ArgumentNullException("personaListado", MensajeExcepcion.ParametroEnNulo);
        //    }

        //    if ( personaListado.Count() == 0 ) {
        //        throw new ArgumentException(MensajeExcepcion.ParametroListaVacia, "personaListado");
        //    }

        //    if ( personaListado.Where(p => p.IdPersona <= 0).Count() > 0 ) {
        //        throw new ArgumentException(MensajeExcepcion.IdentificadorObjetoNoValidoListado, "personaListado");
        //    }

        //    try {
        //        ////using (transaccion = new TransactionScope()) {
        //        //using (var Contexto = (AdministracionBDEntidades)ConfiguracionContexto.ObtenerContexto())
        //        //{
        //        foreach ( var per in personaListado ) {
        //            personaAD = Contexto.Personas.Where(p => p.IdPersona == per.IdPersona).FirstOrDefault();

        //            if ( personaAD == null ) {
        //                throw new RegistroNoEncontradoExcepcion(MensajeExcepcion.RegistroNoEncontrado, typeof(Modelo.Persona), per.IdPersona);
        //            }

        //            personaAD = AutoMapeo.Mapeo(per, personaAD);
        //            personaAD.FechaModificacion = DateTime.Now;
        //            personaAD.IdUsuarioModificacion = IdUsuario;
        //        }

        //        if ( Contexto.SaveChanges() > 0 ) {
        //            resultado = true;
        //        }
        //    } catch ( Exception ex ) {
        //        //Parámetros
        //        List<Object> parametros = new List<Object>();
        //        //parametros.AddManejadorIdentidad.IdentidadActual != null ? ManejadorIdentidad.IdentidadActual.Name : "");
        //        personaListado.ForEach(x => //parametros.Addx));


        //        //RegistroEventoWindows.RegistroEventoFun.RegistroExcepcionUI(MensajeExcepcion.ErrorInesperado, "ActualizarListadoPersona", RegistroEventoWindows.ExtraerTraza(ex), RegistroEventoWindows.ExtraerMensaje(ex), (ManejadorIdentidad.IdentidadActual != null ? ManejadorIdentidad.IdentidadActual.Name : null), parametros);
        //        throw;
        //    }

        //    //if (resultado == true) {
        //    //   // transaccion.Complete();
        //    //}
        //    //}
        //    //}

        //    //Resultado
        //    return resultado;
        //}

        ///// <author>Ernesto Medrano</author>
        ///// <creationdate>16-sep-2015</creationdate>
        ///// <summary>
        ///// Método para eliminar un objeto de tipo Persona. 
        ///// </summary>
        ///// <param name="idPersona">Identificador del objeto.</param>
        ///// <returns>True: Operación exitosa</returns>
        //public Boolean Eliminar(Int32 idPersona) {
        //    //Declaraciones
        //    Sql.Modelo.Persona persona;
        //    bool resultado = false;
        //    // transaccion.Dispose();

        //    //Operaciones
        //    if ( idPersona <= 0 ) {
        //        throw new ArgumentException(MensajeExcepcion.IdentificadorObjetoNoValido, "idPersona");
        //    }

        //    try {
        //        ////using (transaccion = new TransactionScope()) {
        //        //using (var Contexto = (AdministracionBDEntidades)ConfiguracionContexto.ObtenerContexto())
        //        //{
        //        persona = Contexto.Personas.Where(ad => ad.IdPersona == idPersona).FirstOrDefault();
        //        if ( persona == null ) {
        //            throw new RegistroNoEncontradoExcepcion(MensajeExcepcion.RegistroNoEncontrado, typeof(Modelo.Persona), idPersona);
        //        }
        //        Contexto.Personas.Remove(persona);
        //        if ( Contexto.SaveChanges() > 0 ) {
        //            resultado = true;
        //        }
        //    } catch ( Exception ex ) {
        //        //Parámetros
        //        List<Object> parametros = new List<Object>();
        //        //parametros.AddManejadorIdentidad.IdentidadActual != null ? ManejadorIdentidad.IdentidadActual.Name : "");

        //        //parametros.AddidPersona);

        //        //RegistroEventoWindows.RegistroEventoFun.RegistroExcepcionUI(MensajeExcepcion.ErrorInesperado, "EliminarPersona", RegistroEventoWindows.ExtraerTraza(ex), RegistroEventoWindows.ExtraerMensaje(ex), (ManejadorIdentidad.IdentidadActual != null ? ManejadorIdentidad.IdentidadActual.Name : null), parametros);
        //        throw;
        //    }
        //    //if (resultado == true) {
        //    //   // transaccion.Complete();
        //    //}
        //    //}
        //    //}

        //    //Resultado
        //    return resultado;
        //}

        ///// <author>Ernesto Medrano</author>
        ///// <creationdate>16-sep-2015</creationdate>
        ///// <summary>
        ///// Método para eliminar un listado de objetos de tipo Persona.
        ///// </summary>
        ///// <param name="idPersonaListado">Listado de identificadores de objetos.</param>
        ///// <returns>True: Operación exitosa</returns>
        //public Boolean EliminarListado(List<Int32> idPersonaListado) {
        //    //Declaraciones
        //    Sql.Modelo.Persona persona;
        //    bool resultado = false;
        //    // transaccion.Dispose();

        //    //Operaciones
        //    if ( idPersonaListado == null ) {
        //        throw new ArgumentNullException("idPersonaListado", MensajeExcepcion.ParametroEnNulo);
        //    }

        //    if ( idPersonaListado.Count() == 0 ) {
        //        throw new ArgumentException(MensajeExcepcion.ParametroListaVacia, "idPersonaListado");
        //    }

        //    if ( idPersonaListado.Where(p => p <= 0).Count() > 0 ) {
        //        throw new ArgumentException(MensajeExcepcion.IdentificadorObjetoNoValidoListado, "idPersonaListado");
        //    }

        //    try {
        //        ////using (transaccion = new TransactionScope()) {
        //        //using (var Contexto = (AdministracionBDEntidades)ConfiguracionContexto.ObtenerContexto())
        //        //{
        //        foreach ( var perAD in idPersonaListado ) {
        //            persona = Contexto.Personas.Where(ad => ad.IdPersona == perAD).FirstOrDefault();

        //            if ( persona == null ) {
        //                throw new RegistroNoEncontradoExcepcion(MensajeExcepcion.RegistroNoEncontrado, typeof(Modelo.Persona), perAD);
        //            }

        //            Contexto.Personas.Remove(persona);
        //        }

        //        if ( Contexto.SaveChanges() > 0 ) {
        //            resultado = true;
        //        }
        //    } catch ( Exception ex ) {
        //        //Parámetros
        //        List<Object> parametros = new List<Object>();
        //        //parametros.AddManejadorIdentidad.IdentidadActual != null ? ManejadorIdentidad.IdentidadActual.Name : "");
        //        idPersonaListado.ForEach(x => //parametros.Addx));

        //        //RegistroEventoWindows.RegistroEventoFun.RegistroExcepcionUI(MensajeExcepcion.ErrorInesperado, "EliminarListadoPersona", RegistroEventoWindows.ExtraerTraza(ex), RegistroEventoWindows.ExtraerMensaje(ex), (ManejadorIdentidad.IdentidadActual != null ? ManejadorIdentidad.IdentidadActual.Name : null), parametros);
        //        throw;
        //    }

        //    //if (resultado == true) {
        //    //   // transaccion.Complete();
        //    //}
        //    //}
        //    //}

        //    //Resultado
        //    return resultado;
        //}

        ///// <author>Ernesto Medrano</author>
        ///// <creationdate>16-sep-2015</creationdate>
        ///// <summary>
        ///// Método para obtener un objeto tipo Persona.
        ///// </summary>
        ///// <param name="idPersona">Identificador del objeto.</param>
        ///// <returns>Retorna el objeto tipo Persona.</returns>
        //public Negocio.Entidades.Persona.Persona Obtener(Int32 idPersona) {
        //    //Declaraciones            
        //    Sql.Modelo.Persona personaAD = new Sql.Modelo.Persona();
        //    Negocio.Entidades.Persona.Persona persona = new Negocio.Entidades.Persona.Persona();

        //    //Operaciones
        //    if ( idPersona <= 0 ) {
        //        throw new ArgumentException(MensajeExcepcion.IdentificadorObjetoNoValido, "idPersona");
        //    }

        //    try {
        //        //using (var Contexto = (AdministracionBDEntidades)ConfiguracionContexto.ObtenerContexto())
        //        // {

        //        personaAD = Contexto.Personas.Where(p => p.IdPersona == idPersona).FirstOrDefault();

        //        if ( personaAD == null ) {
        //            throw new RegistroNoEncontradoExcepcion(MensajeExcepcion.RegistroNoEncontrado, typeof(Modelo.Persona), idPersona);
        //        } else {
        //            persona = AutoMapeo.Mapeo(personaAD, persona);
        //        }
        //        //}
        //    } catch ( Exception ex ) {
        //        //Parámetros
        //        List<Object> parametros = new List<Object>();
        //        //parametros.AddManejadorIdentidad.IdentidadActual != null ? ManejadorIdentidad.IdentidadActual.Name : "");

        //        //parametros.AddidPersona);

        //        //RegistroEventoWindows.RegistroEventoFun.RegistroExcepcionUI(MensajeExcepcion.ErrorInesperado, "ObtenerPersona", RegistroEventoWindows.ExtraerTraza(ex), RegistroEventoWindows.ExtraerMensaje(ex), (ManejadorIdentidad.IdentidadActual != null ? ManejadorIdentidad.IdentidadActual.Name : null), parametros);
        //        throw;
        //    }

        //    //Resultado
        //    return persona;
        //}

        ///// <author>Ernesto Medrano</author>
        ///// <creationdate>16-sep-2015</creationdate>
        ///// <summary>
        ///// <param name="idPersonaListado">Lisrtado de identificador de objetos.</param>
        ///// <returns>Retorna el listado de Objetos Persona</returns>
        //public List<Negocio.Entidades.Persona.Persona> ObtenerListado(List<Int32> idPersonaListado) {
        //    //Declaraciones            
        //    List<SqlParameter> parametrolistado = new List<SqlParameter>();
        //    StringBuilder consulta = new StringBuilder();
        //    List<Sql.Modelo.Persona> personaListadoAD = new List<Sql.Modelo.Persona>();

        //    List<Negocio.Entidades.Persona.Persona> personaListado = new List<Negocio.Entidades.Persona.Persona>();

        //    //Operaciones
        //    if ( idPersonaListado == null ) {
        //        throw new ArgumentNullException("idPersonaListado", MensajeExcepcion.ParametroEnNulo);
        //    }

        //    if ( idPersonaListado.Count() == 0 ) {
        //        throw new ArgumentException(MensajeExcepcion.ParametroListaVacia, "idPersonaListado");
        //    }

        //    if ( idPersonaListado.Where(l => l <= 0).Count() > 0 ) {
        //        throw new ArgumentException(MensajeExcepcion.IdentificadorObjetoNoValidoListado, "idPersonaListado");
        //    }

        //    try {
        //        using ( var contexto = new ConfiguracionContexto().ObtenerContexto() ) {
        //            var consultaAd = Contexto.Database.SqlQuery<Negocio.Entidades.Persona.Persona>("Persona.[prObtenerPersona]").ToList();
        //            consultaAd.RemoveAll(x => !idPersonaListado.Contains(x.IdPersona));

        //            if ( consultaAd.Count() >= 0 ) {
        //                personaListado = consultaAd.ToList().Select(per => AutoMapeo.Mapeo(per, new Negocio.Entidades.Persona.Persona())).ToList();
        //            }
        //        }
        //    } catch ( Exception ex ) {
        //        //Parámetros
        //        List<Object> parametros = new List<Object>();
        //        //parametros.AddManejadorIdentidad.IdentidadActual != null ? ManejadorIdentidad.IdentidadActual.Name : "");
        //        idPersonaListado.ForEach(x => //parametros.Addx));


        //        //RegistroEventoWindows.RegistroEventoFun.RegistroExcepcionUI(MensajeExcepcion.ErrorInesperado, "ObtenerListadoPersona", RegistroEventoWindows.ExtraerTraza(ex), RegistroEventoWindows.ExtraerMensaje(ex), (ManejadorIdentidad.IdentidadActual != null ? ManejadorIdentidad.IdentidadActual.Name : null), parametros);
        //        throw;
        //    }

        //    //Resultado
        //    return personaListado;
        //}

        ///// <author>Ernesto Medrano</author>
        ///// <creationdate>16-sep-2015</creationdate>
        ///// <summary>
        ///// Método para obtener un listado de objetos de tipo Persona.
        ///// </summary>
        ///// <param name="activo">Estado de los Objetos de tipo Persona.</param>
        ///// <returns>Retorna el listado de Objetos Persona</returns>
        //public List<Negocio.Entidades.Persona.Persona> ObtenerListado(Activo activo) {

        //    //Declaraciones 
        //    List<Sql.Modelo.Persona> listadoAD = new List<Sql.Modelo.Persona>();
        //    List<Negocio.Entidades.Persona.Persona> listado = new List<Negocio.Entidades.Persona.Persona>();

        //    if ( !Enum.IsDefined(typeof(Activo), activo) ) {
        //        throw new ArgumentOutOfRangeException("activo", MensajeExcepcion.EnumeracionValorInvalido);
        //    }

        //    IEnumerable<Sql.Modelo.Persona> consultaAD;

        //    try {
        //        consultaAD = Contexto.Personas;
        //        //Verificando registros activos
        //        switch ( activo ) {
        //            case Activo.Si:
        //                listadoAD = consultaAD.Where(a => a.EstaActivo == true).ToList();
        //                break;
        //            case Activo.No:
        //                listadoAD = consultaAD.Where(a => a.EstaActivo == false).ToList();
        //                break;
        //            default:
        //                listadoAD = consultaAD.ToList();
        //                break;
        //        }
        //        listado = listadoAD.ToList().Select(persona => AutoMapeo.Mapeo(persona, new Negocio.Entidades.Persona.Persona())).ToList();
        //    } catch ( Exception ex ) {
        //        //Parámetros
        //        List<Object> parametros = new List<Object>();
        //        //parametros.AddManejadorIdentidad.IdentidadActual != null ? ManejadorIdentidad.IdentidadActual.Name : "");

        //        //parametros.Addactivo);

        //        //RegistroEventoWindows.RegistroEventoFun.RegistroExcepcionUI(MensajeExcepcion.ErrorInesperado, "ObtenerListadoPersona", RegistroEventoWindows.ExtraerTraza(ex), RegistroEventoWindows.ExtraerMensaje(ex), (ManejadorIdentidad.IdentidadActual != null ? ManejadorIdentidad.IdentidadActual.Name : null), parametros);
        //        throw;
        //    }

        //    //Resultado
        //    return listado;
        //}

        ///// <author>Ernesto Medrano</author>
        ///// <creationdate>16-sep-2015</creationdate>
        ///// <summary>
        ///// Método para obtener un listado de objetos de tipo Persona en dependencia del criterio de filtrado.
        ///// </summary>
        ///// <param name="idTipoPersona">Comentario</param>
        ///// <param name="activo">Comentario</param>
        ///// <returns></returns>
        //public List<Negocio.Entidades.Persona.Persona> ObtenerListadoPersonaPorTipoPersona(Int32 idTipoPersona, Activo activo) {
        //    //Declaraciones
        //    //List<Negocio.Entidades.Persona.Persona> personaListado = new List<Negocio.Entidades.Persona.Persona>();
        //    //Negocio.Entidades.Persona.Persona persona;

        //    // Operaciones
        //    //persona = new Negocio.Entidades.Persona.Persona() {
        //    //    TipoPersona = new Negocio.Entidades.TablaBasica.Valor() {
        //    //        IdValor = idTipoPersona
        //    //    }
        //    //};

        //    //personaListado.Add(persona);

        //    // Resultado
        //    return ObtenerListadoTipoPersonaPorIdTipoPersona(idTipoPersona, activo);
        //}

        ///// <author>Ernesto Medrano</author>
        ///// <creationdate>16-sep-2015</creationdate>
        ///// <summary>
        ///// Método para obtener un listado de objetos de tipo Persona en dependencia del criterio de filtrado.
        ///// </summary>
        ///// <param name="idTipoPersonaListado">Comentario</param>
        ///// <param name="activo">Comentario</param>
        ///// <returns></returns>
        //public List<Negocio.Entidades.Persona.Persona> ObtenerListadoPersonaPorTipoPersona(List<Int32> idTipoPersonaListado, Activo activo) {
        //    //Declaraciones
        //    List<Negocio.Entidades.Persona.Persona> personaListado = new List<Negocio.Entidades.Persona.Persona>();

        //    // Operaciones
        //    //personaListado.AddRange(idTipoPersonaListado.
        //    //    Select(x => new Negocio.Entidades.Persona.Persona() {
        //    //        TipoPersona = new Negocio.Entidades.TablaBasica.Valor() {
        //    //            IdValor = x
        //    //        }
        //    //    }).ToList());

        //    // Resultado
        //    return ObtenerListadoTipoPersonaPorListadoIdTipoPersona(idTipoPersonaListado, activo);
        //}

        ///// <author>Ernesto Medrano</author>
        ///// <creationdate>25-08-2015</creationdate>
        ///// <summary>
        ///// Se obtiene el listado de persona mediante un criterio especifico.
        ///// </summary>
        ///// <param name="nombreCompleto"></param>
        ///// <returns>Listado Persona</returns>
        //public List<EstructuraInteresados> ObtenerListadoPersonaPorNombreCompleto(String nombreCompleto) {
        //    List<EstructuraInteresados> listado = new List<EstructuraInteresados>();
        //    return listado;
        //}

        //public List<EstructuraPersona> ObtenerListadoRangoPersona() {
        //    List<EstructuraPersona> listadoPersona = new List<EstructuraPersona>();

        //    try {
        //        //using (var Contexto = (AdministracionBDEntidades)ConfiguracionContexto.ObtenerContexto())
        //        //{
        //        listadoPersona = Contexto.Database.SqlQuery<EstructuraPersona>("Persona.prObtenerRangoPersona").ToList();
        //        //}
        //    } catch ( Exception ex ) {
        //        //Parámetros
        //        List<Object> parametros = new List<Object>();
        //        //parametros.AddManejadorIdentidad.IdentidadActual != null ? ManejadorIdentidad.IdentidadActual.Name : "");

        //        //RegistroEventoWindows.RegistroEventoFun.RegistroExcepcionUI(MensajeExcepcion.ErrorInesperado, "ObtenerListadoRangoPersona", RegistroEventoWindows.ExtraerTraza(ex), RegistroEventoWindows.ExtraerMensaje(ex), (ManejadorIdentidad.IdentidadActual != null ? ManejadorIdentidad.IdentidadActual.Name : null), parametros);
        //        throw;
        //    }

        //    return listadoPersona.OrderByDescending(x => x.IdPersonaNatural).ToList();
        //}

        //public List<Negocio.Entidades.Persona.Persona> ObtenerListadoRango(List<int> idPersonaListado) {
        //    List<SqlParameter> parametrolistado = new List<SqlParameter>();
        //    StringBuilder consulta = new StringBuilder();
        //    List<Sql.Modelo.Persona> personaListadoAD = new List<Sql.Modelo.Persona>();

        //    List<Negocio.Entidades.Persona.Persona> personaListado = new List<Negocio.Entidades.Persona.Persona>();
        //    try {

        //        //using (var Contexto = (AdministracionBDEntidades)ConfiguracionContexto.ObtenerContexto())
        //        // {
        //        var consultaAd = ObtenerListadoRangoPersona();
        //        consultaAd.RemoveAll(x => !idPersonaListado.Contains(x.IdPersona));
        //        //consulta.Append(Contexto.Personas.ToString() + " ");
        //        //consulta.Append(Utilidades.FuncionSql.AgregarFuncionFiltroEntero(parametrolistado, "IdPersona", idPersonaListado));
        //        //personaListadoAD = Contexto.Database.SqlQuery<Sql.Modelo.Persona>(consulta.ToString(), parametrolistado.ToArray()).ToList();

        //        if ( consultaAd.Count() >= 0 ) {
        //            personaListado = consultaAd.ToList().Select(per => AutoMapeo.Mapeo(per, new Negocio.Entidades.Persona.Persona())).ToList();
        //        }
        //        //}
        //    } catch ( Exception ex ) {
        //        //Parámetros
        //        List<Object> parametros = new List<Object>();
        //        //parametros.AddManejadorIdentidad.IdentidadActual != null ? ManejadorIdentidad.IdentidadActual.Name : "");
        //        idPersonaListado.ForEach(x => //parametros.Addx));


        //        //RegistroEventoWindows.RegistroEventoFun.RegistroExcepcionUI(MensajeExcepcion.ErrorInesperado, "ObtenerListadoRangoPersona", RegistroEventoWindows.ExtraerTraza(ex), RegistroEventoWindows.ExtraerMensaje(ex), (ManejadorIdentidad.IdentidadActual != null ? ManejadorIdentidad.IdentidadActual.Name : null), parametros);
        //        throw;
        //    }

        //    return personaListado;
        //}

        ///// <author>Jeffry Huerta</author>
        ///// <creationdate>12-sep-2016</creationdate>
        ///// <summary>
        ///// Método para obtener un listado de objetos de tipo Persona.
        ///// </summary>
        ///// <param name="activo">Estado de los objetos de tipo Persona.</param>
        ///// <returns></returns>
        //public List<EstructuraPersona> ObtenerListadoPersonaActivoRango(Activo activo) {
        //    List<EstructuraPersona> listadoPersona = new List<EstructuraPersona>();

        //    try {
        //        listadoPersona = this.ObtenerListadoRangoPersona();

        //        switch ( activo ) {
        //            case Activo.No:
        //                listadoPersona = listadoPersona.Where(x => !x.EstaActivo).ToList();
        //                break;
        //            case Activo.Si:
        //                listadoPersona = listadoPersona.Where(x => x.EstaActivo).ToList();
        //                break;
        //        }
        //    } catch ( Exception ex ) {
        //        //Parámetros
        //        List<Object> parametros = new List<Object>();
        //        //parametros.AddManejadorIdentidad.IdentidadActual != null ? ManejadorIdentidad.IdentidadActual.Name : "");

        //        //parametros.Addactivo);

        //        //RegistroEventoWindows.RegistroEventoFun.RegistroExcepcionUI(MensajeExcepcion.ErrorInesperado, "ObtenerListadoPersonaActivoRango", RegistroEventoWindows.ExtraerTraza(ex), RegistroEventoWindows.ExtraerMensaje(ex), (ManejadorIdentidad.IdentidadActual != null ? ManejadorIdentidad.IdentidadActual.Name : null), parametros);
        //        throw;
        //    }

        //    return listadoPersona;
        //}

        //public List<EstructuraBusquedaTipoPersona> ObtenerBusquedaTipoPersona(String Busqueda, String TipoBusqueda) {
        //    List<EstructuraBusquedaTipoPersona> listadoPersonaBusqueda = new List<EstructuraBusquedaTipoPersona>();

        //    try {
        //        //using (var Contexto = (AdministracionBDEntidades)ConfiguracionContexto.ObtenerContexto())
        //        //{
        //        listadoPersonaBusqueda = Contexto.Database.SqlQuery<EstructuraBusquedaTipoPersona>("Persona.prObtenerBusquedaTipoPersona @Busqueda,@TipoBusqueda", new SqlParameter("@Busqueda", Busqueda), new SqlParameter("@TipoBusqueda", TipoBusqueda)).ToList();
        //        //}
        //    } catch ( Exception ex ) {
        //        //Parámetros
        //        List<Object> parametros = new List<Object>();
        //        //parametros.AddManejadorIdentidad.IdentidadActual != null ? ManejadorIdentidad.IdentidadActual.Name : "");

        //        //parametros.AddBusqueda);
        //        //parametros.AddTipoBusqueda);

        //        //RegistroEventoWindows.RegistroEventoFun.RegistroExcepcionUI(MensajeExcepcion.ErrorInesperado, "ObtenerBusquedaTipoPersona", RegistroEventoWindows.ExtraerTraza(ex), RegistroEventoWindows.ExtraerMensaje(ex), (ManejadorIdentidad.IdentidadActual != null ? ManejadorIdentidad.IdentidadActual.Name : null), parametros);
        //        throw;
        //    }

        //    return listadoPersonaBusqueda;
        //}

        ///// <author>Jose Miguel Lopez Sevilla</author>
        ///// <creationdate>02-Dic-2016</creationdate>
        ///// <summary>
        ///// Método para obtener un listado de objetos de tipo EstructuraDatosAbogado
        ///// </summary>
        ///// <param name="idPersona">id de la persona</param>
        ///// <returns>Retorna el nombre por tipo persona.</returns>
        //public string ObtenerNombrePorTipoPersona(int idPersona, out string nombre) {
        //    String nombreInterno = "";
        //    try {
        //        //using (var Contexto = (AdministracionBDEntidades) ConfiguracionContexto.ObtenerContexto())
        //        //{
        //        nombreInterno = nombre = Contexto.Database.SqlQuery<String>("Utilidad.prObtenerNombrePorTipoPersona @IdPersona", new SqlParameter("@IdPersona", idPersona)).FirstOrDefault();
        //        // }
        //    } catch ( Exception ex ) {
        //        //Parámetros

        //        List<Object> parametros = new List<Object>();
        //        //parametros.AddManejadorIdentidad.IdentidadActual != null ? ManejadorIdentidad.IdentidadActual.Name : "");

        //        //parametros.AddidPersona);
        //        //parametros.AddnombreInterno);

        //        //RegistroEventoWindows.RegistroEventoFun.RegistroExcepcionUI(MensajeExcepcion.ErrorInesperado, "ObtenerNombrePorTipoPersona", RegistroEventoWindows.ExtraerTraza(ex), RegistroEventoWindows.ExtraerMensaje(ex), (ManejadorIdentidad.IdentidadActual != null ? ManejadorIdentidad.IdentidadActual.Name : null), new List<String> { ManejadorIdentidad.IdentidadActual != null ? ManejadorIdentidad.IdentidadActual.Name : "" });
        //        throw;
        //    }

        //    return nombre;
        //}

        ///// <author>Fernando Gallegos</author>
        ///// <creationdate>12-Dic-2016</creationdate>
        ///// <summary>
        ///// Obtiene la información básica de una persona, ya sea natural o jurídica en formato XML y la hoja de estilo para renderizar la información.
        ///// </summary>
        ///// <param name="idPersona">Identificador único de la persona</param>
        ///// <returns>Listado con contenido Xml, el primer registro son los datos, el segundo es la hoja de estilo</returns>
        //public List<String> ObtenerInformacionPersona(Int32 idPersona) {
        //    List<String> estructura = new List<String>();

        //    try {
        //        //using (var Contexto = (AdministracionBDEntidades)ConfiguracionContexto.ObtenerContexto()) {
        //        using ( var contexto = new ConfiguracionContexto().ObtenerContexto() ) {
        //            estructura = Contexto.Database.SqlQuery<String>("Persona.prObtenerInformacionPersona @IdPersona", new SqlParameter("@IdPersona", idPersona)).ToList();
        //            //}
        //        }
        //    } catch ( Exception ex ) {
        //        //Parámetros
        //        List<Object> parametros = new List<Object>();
        //        //parametros.AddManejadorIdentidad.IdentidadActual != null ? ManejadorIdentidad.IdentidadActual.Name : "");

        //        //parametros.AddidPersona);

        //        //RegistroEventoWindows.RegistroEventoFun.RegistroExcepcionUI(MensajeExcepcion.ErrorInesperado, "ObtenerInformacionPersona", RegistroEventoWindows.ExtraerTraza(ex), RegistroEventoWindows.ExtraerMensaje(ex), (ManejadorIdentidad.IdentidadActual != null ? ManejadorIdentidad.IdentidadActual.Name : null), parametros);
        //        throw;
        //    }

        //    //Resultado
        //    return estructura;
        //}

        ///// <author>Mario Gomez</author>
        ///// <creationdate>12-Dic-2016</creationdate>
        ///// <summary>
        ///// Obtiene la información básica de una persona, en formato XML y la hoja de estilo para renderizar la información.
        ///// </summary>
        ///// <param name="idPersona">Identificador único de la persona</param>
        ///// <returns>Listado con contenido Xml, el primer registro son los datos, el segundo es la hoja de estilo</returns>
        //public List<String> ObtenerDetallePersonaXML(Int32 idPersona) {
        //    List<String> estructura = new List<String>();

        //    try {
        //        //using (var Contexto = (AdministracionBDEntidades)ConfiguracionContexto.ObtenerContexto())
        //        using ( var contexto = new ConfiguracionContexto().ObtenerContexto() ) {
        //            // {
        //            estructura = Contexto.Database.SqlQuery<String>("Persona.prObtenerDetallePersonaXML @IdPersona", new SqlParameter("@IdPersona", idPersona)).ToList();
        //            //  }
        //        }
        //    } catch ( Exception ex ) {
        //        //Parámetros
        //        List<Object> parametros = new List<Object>();
        //        //parametros.AddManejadorIdentidad.IdentidadActual != null ? ManejadorIdentidad.IdentidadActual.Name : "");

        //        //parametros.AddidPersona);

        //        //RegistroEventoWindows.RegistroEventoFun.RegistroExcepcionUI(MensajeExcepcion.ErrorInesperado, "ObtenerDetallePersonaXML", RegistroEventoWindows.ExtraerTraza(ex), RegistroEventoWindows.ExtraerMensaje(ex), (ManejadorIdentidad.IdentidadActual != null ? ManejadorIdentidad.IdentidadActual.Name : null), parametros);
        //        throw;
        //    }

        //    //Resultado
        //    return estructura;
        //}

        ///// <author>Aquiles Toruño</author>
        ///// <creationdate>11-Ene-2017</creationdate>
        ///// <summary>
        ///// Método para obtener listado del tipo Negocio.Entidades.Persona.Persona filtrado por el parámetro enviado
        ///// </summary>
        ///// <param name="idTipoPersona"></param>
        ///// <param name="activo"></param>
        ///// <returns></returns>
        //public List<Negocio.Entidades.Persona.Persona> ObtenerListadoTipoPersonaPorIdTipoPersona(Int32 idTipoPersona, Activo activo) {
        //    List<Negocio.Entidades.Persona.Persona> listadoPersona = new List<Negocio.Entidades.Persona.Persona>();

        //    try {
        //        switch ( activo ) {
        //            case Activo.No:
        //                listadoPersona = Contexto.Personas.Where(x => x.IdTipoPersona == idTipoPersona && !x.EstaActivo).Select(x => new Negocio.Entidades.Persona.Persona() {
        //                    IdPersona = x.IdPersona
        //                }).ToList();
        //                break;
        //            case Activo.Si:
        //                listadoPersona = Contexto.Personas.Where(x => x.IdTipoPersona == idTipoPersona && x.EstaActivo).Select(x => new Negocio.Entidades.Persona.Persona() {
        //                    IdPersona = x.IdPersona
        //                }).ToList();
        //                break;
        //            case Activo.Todos:
        //                listadoPersona = Contexto.Personas.Where(x => x.IdTipoPersona == idTipoPersona).Select(x => new Negocio.Entidades.Persona.Persona() {
        //                    IdPersona = x.IdPersona
        //                }).ToList();
        //                break;
        //            default:
        //                break;
        //        }
        //    } catch ( Exception ex ) {
        //        //Parámetros
        //        List<Object> parametros = new List<Object>();
        //        //parametros.AddManejadorIdentidad.IdentidadActual != null ? ManejadorIdentidad.IdentidadActual.Name : "");

        //        //parametros.AddidTipoPersona);
        //        //parametros.Addactivo);

        //        //RegistroEventoWindows.RegistroEventoFun.RegistroExcepcionUI(MensajeExcepcion.ErrorInesperado, "ObtenerListadoTipoPersonaPorIdTipoPersona", RegistroEventoWindows.ExtraerTraza(ex), RegistroEventoWindows.ExtraerMensaje(ex), (ManejadorIdentidad.IdentidadActual != null ? ManejadorIdentidad.IdentidadActual.Name : null), parametros);
        //        throw;
        //    }

        //    return listadoPersona;
        //}

        ///// <author>Aquiles Toruño</author>
        ///// <creationdate>11-Ene-2017</creationdate>
        ///// <summary>
        ///// Método para obtener listado del tipo Negocio.Entidades.Persona.Persona filtrado por el parámetro enviado
        ///// </summary>
        ///// <param name="idTipoPersona"></param>
        ///// <param name="activo"></param>
        ///// <returns></returns>
        //public List<Negocio.Entidades.Persona.Persona> ObtenerListadoTipoPersonaPorListadoIdTipoPersona(List<Int32> listadoIdTipoPersona, Activo activo) {
        //    List<Negocio.Entidades.Persona.Persona> listadoPersona = new List<Negocio.Entidades.Persona.Persona>();

        //    try {
        //        switch ( activo ) {
        //            case Activo.No:
        //                listadoPersona = Contexto.Personas.Where(x => listadoIdTipoPersona.Contains(x.IdTipoPersona) && !x.EstaActivo).Select(x => new Negocio.Entidades.Persona.Persona() {
        //                    IdPersona = x.IdPersona
        //                }).ToList();
        //                break;
        //            case Activo.Si:
        //                listadoPersona = Contexto.Personas.Where(x => listadoIdTipoPersona.Contains(x.IdTipoPersona) && x.EstaActivo).Select(x => new Negocio.Entidades.Persona.Persona() {
        //                    IdPersona = x.IdPersona
        //                }).ToList();
        //                break;
        //            case Activo.Todos:
        //                listadoPersona = Contexto.Personas.Where(x => listadoIdTipoPersona.Contains(x.IdTipoPersona)).Select(x => new Negocio.Entidades.Persona.Persona() {
        //                    IdPersona = x.IdPersona
        //                }).ToList();
        //                break;
        //            default:
        //                break;
        //        }
        //    } catch ( Exception ex ) {
        //        //Parámetros
        //        List<Object> parametros = new List<Object>();
        //        //parametros.AddManejadorIdentidad.IdentidadActual != null ? ManejadorIdentidad.IdentidadActual.Name : "");
        //        listadoIdTipoPersona.ForEach(x => //parametros.Addx));
        //        //parametros.Addactivo);

        //        //RegistroEventoWindows.RegistroEventoFun.RegistroExcepcionUI(MensajeExcepcion.ErrorInesperado, "ObtenerListadoTipoPersonaPorIdTipoPersona", RegistroEventoWindows.ExtraerTraza(ex), RegistroEventoWindows.ExtraerMensaje(ex), (ManejadorIdentidad.IdentidadActual != null ? ManejadorIdentidad.IdentidadActual.Name : null), parametros);
        //        throw;
        //    }

        //    return listadoPersona;
        //}

        #endregion

    }
}
