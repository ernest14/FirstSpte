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
    /// Clase PersonaNatural que contiene el CRUD.
    /// </summary>
    public class PersonaNaturalAD {

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
        public PruebaSoftEntidades Contexto { get { return ConfiguracionContexto.Value.ObtenerContexto(); } }

        /// <author>Ernesto Medrano</author>
        /// <creationdate>29-Oct-2015</creationdate>
        /// <summary>
        /// ConfiguracionContexto que es pasado por inyección
        /// </summary>
        private Lazy<ConfiguracionContexto> ConfiguracionContexto { get; set; }

        /// <author>Jose Miguel Lopez Sevilla/author>
        /// <creationdate>06-Ene-2017</creationdate>
        /// <summary>
        /// Objeto para el AutoMappeo
        /// </summary>
        private ConfiguracionMapeoAD AutoMapeo { get; set; }

        #endregion

        #region Constructores

        /// <author>Ernesto Medrano</author>
        /// <creationdate>16-sep-2015</creationdate>
        /// <summary>
        /// Constructor Clase PersonaNatural.
        /// </summary>
        public PersonaNaturalAD(Lazy<ConfiguracionContexto> configuracionContexto, ConfiguracionMapeoAD autoMapeo) {
            this.ConfiguracionContexto = configuracionContexto;
            AutoMapeo = autoMapeo;
            // this.Contexto = (AdministracionBDEntidades)configuracionContexto.ObtenerContexto();
        }

        #endregion

        #region Metodos

        /// <author>Ernesto Medrano</author>
        /// <creationdate>16-sep-2015</creationdate>
        /// <summary>
        /// Método que agrega un nuevo objeto de tipo PersonaNatural.
        /// </summary>
        /// <param name="personaNatural">Objeto tipo PersonaNatural a ser agregado.</param>
        /// <returns>True: Registro agregado </returns>        
        public Boolean Agregar(Negocio.Entidades.Persona.PersonaNatural personaNatural) {
            //Declaraciones
            Sql.Modelo.PersonaNatural personaNaturalAD = new Sql.Modelo.PersonaNatural();
            Boolean resultado = false;
            //TransactionScope transaccion;

            //Operaciones
            if ( personaNatural == null ) {
                throw new ArgumentNullException("personaNatural", MensajeExcepcion.ParametroEnNulo);
            }

            if ( personaNatural.IdPersonaNatural != 0 ) {
                throw new ArgumentException(MensajeExcepcion.IdentificadorObjetoCreacion, "personaNatural");
            }

            try {
                ////using (transaccion = new TransactionScope()) {
                //using (var Contexto = (AdministracionBDEntidades)ConfiguracionContexto.ObtenerContexto()) {
                personaNaturalAD = AutoMapeo.Mapeo(personaNatural, personaNaturalAD);

                //personaNaturalAD.Persona = AutoMapeo.Mapeo(personaNatural.Persona, personaNaturalAD.Persona);

                personaNaturalAD.EstaActivo = true;
                personaNaturalAD.IdUsuarioCreacion = IdUsuario;
                personaNaturalAD.FechaCreacion = DateTime.Now;
                Contexto.PersonaNaturales.Add(personaNaturalAD);


                if ( Contexto.SaveChanges() > 0 ) {
                    personaNatural.IdPersonaNatural = personaNaturalAD.IdPersonaNatural;
                    resultado = true;
                }

                // if (resultado == true) {
                //transaccion.Complete();
                // }
                //  }
                //}
            } catch ( Exception ex ) {
                //Parámetros
                List<Object> parametros = new List<Object>();
                //parametros.Add(ManejadorIdentidad.IdentidadActual != null ? ManejadorIdentidad.IdentidadActual.Name : "");

                //parametros.Add(personaNatural);

                //RegistroEventoWindows.RegistroEventoFun.RegistroExcepcionAD(MensajeExcepcion.ErrorInesperado, "AgregarPersonaNatural", RegistroEventoWindows.ExtraerTraza(ex), RegistroEventoWindows.ExtraerMensaje(ex), (ManejadorIdentidad.IdentidadActual != null ? ManejadorIdentidad.IdentidadActual.Name : null), parametros);
                throw;
            }

            //Resultado
            return resultado;
        }

        ///// <author>Ernesto Medrano</author>
        ///// <creationdate>16-sep-2015</creationdate>
        ///// <summary>
        ///// Método que agrega un nuevo listado de objeto de tipo PersonaNatural.
        ///// </summary>
        ///// <param name="PersonaNaturalListado">Listado de objetos de tipo PersonaNatural a ser agregados.</param>
        ///// <returns>True: Registros agregados</returns>
        //public Boolean AgregarListado(List<Negocio.Entidades.Persona.PersonaNatural> personaNaturalListado) {

        //    //Declaraciones
        //    Sql.Modelo.PersonaNatural personaNaturalAD = new Sql.Modelo.PersonaNatural();
        //    List<Sql.Modelo.PersonaNatural> personaNaturalADListado = new List<Sql.Modelo.PersonaNatural>();
        //    Boolean resultado = false;
        //    //TransactionScope transaccion;

        //    //Operaciones
        //    if (personaNaturalListado == null) {
        //        throw new ArgumentNullException("personaNaturalListado", MensajeExcepcion.ParametroEnNulo);
        //    }

        //    if (personaNaturalListado.Count() <= 0) {
        //        throw new ArgumentException(MensajeExcepcion.ParametroListaVacia, "personaNaturalListado");
        //    }

        //    if (personaNaturalListado.Where(p => p.IdPersonaNatural != 0).Count() > 0) {
        //        throw new ArgumentException(MensajeExcepcion.IdentificadorObjetoCreacionListado, "personaNaturalListado");
        //    }

        //    try {
        //        ////using (transaccion = new TransactionScope()) {
        //        //using (var Contexto = (AdministracionBDEntidades)ConfiguracionContexto.ObtenerContexto()) {
        //        foreach (var p in personaNaturalListado) {

        //            personaNaturalAD = new Sql.Modelo.PersonaNatural();
        //            personaNaturalAD = AutoMapeo.Mapeo(p, personaNaturalAD);
        //            personaNaturalAD.EstaActivo = true;
        //            personaNaturalAD.IdUsuarioCreacion = IdUsuario;
        //            personaNaturalAD.FechaCreacion = DateTime.Now;
        //            Contexto.PersonaNaturales.Add(personaNaturalAD);
        //            personaNaturalADListado.Add(personaNaturalAD);

        //        }

        //        if (Contexto.SaveChanges() > 0) {
        //            for (int i = 0; i < personaNaturalListado.Count(); i++) {
        //                personaNaturalListado[i].IdPersonaNatural = personaNaturalADListado[i].IdPersonaNatural;
        //            }
        //            resultado = true;
        //        }

        //        // if (resultado == true) {
        //        //transaccion.Complete();
        //        // }
        //        // }
        //        // }
        //    } catch (Exception ex) {
        //        //Parámetros
        //        List<Object> parametros = new List<Object>();
        //        //parametros.Add(ManejadorIdentidad.IdentidadActual != null ? ManejadorIdentidad.IdentidadActual.Name : "");
        //        personaNaturalListado.ForEach(x => //parametros.Add(x));

        //        //RegistroEventoWindows.RegistroEventoFun.RegistroExcepcionAD(MensajeExcepcion.ErrorInesperado, "AgregarListadoPersonaNatural", RegistroEventoWindows.ExtraerTraza(ex), RegistroEventoWindows.ExtraerMensaje(ex), (ManejadorIdentidad.IdentidadActual != null ? ManejadorIdentidad.IdentidadActual.Name : null), parametros);
        //        throw;
        //    }

        //    //Resultado
        //    return resultado;
        //}

        ///// <author>Ernesto Medrano</author>
        ///// <creationdate>16-sep-2015</creationdate>
        ///// <summary>
        ///// Método para dar de alta al objeto de tipo PersonaNatural. 
        ///// Cambia el campo EstaActivo a True.
        ///// </summary>
        ///// <param name="idPersonaNatural">Identificador del objeto.</param>
        ///// <returns>True: Operación exitosa</returns>
        //public Boolean DarAlta(Int32 idPersonaNatural) {

        //    //Declaraciones
        //    Sql.Modelo.PersonaNatural personaNatural;
        //    bool resultado = false;
        //    //TransactionScope transaccion;

        //    //Operaciones
        //    if (idPersonaNatural <= 0) {
        //        throw new ArgumentException(MensajeExcepcion.IdentificadorObjetoNoValido, "idPersonaNatural");
        //    }

        //    try {
        //        ////using (transaccion = new TransactionScope()) {
        //        //using (var Contexto = (AdministracionBDEntidades)ConfiguracionContexto.ObtenerContexto()) {
        //        personaNatural = Contexto.PersonaNaturales.Where(p => p.IdPersonaNatural == idPersonaNatural).FirstOrDefault();
        //        if (personaNatural == null) {
        //            throw new RegistroNoEncontradoExcepcion(MensajeExcepcion.RegistroNoEncontrado, typeof(Modelo.PersonaNatural), idPersonaNatural);
        //        }

        //        personaNatural.EstaActivo = true;
        //        personaNatural.FechaModificacion = DateTime.Now;
        //        personaNatural.IdUsuarioModificacion = IdUsuario;

        //        if (Contexto.SaveChanges() > 0) {
        //            resultado = true;
        //        }

        //        // if (resultado == true) {
        //        //transaccion.Complete();
        //        // }
        //        // }
        //        //}
        //    } catch (Exception ex) {
        //        //Parámetros
        //        List<Object> parametros = new List<Object>();
        //        //parametros.Add(ManejadorIdentidad.IdentidadActual != null ? ManejadorIdentidad.IdentidadActual.Name : "");

        //        //parametros.Add(idPersonaNatural);

        //        //RegistroEventoWindows.RegistroEventoFun.RegistroExcepcionAD(MensajeExcepcion.ErrorInesperado, "DarAltaPersonaNatural", RegistroEventoWindows.ExtraerTraza(ex), RegistroEventoWindows.ExtraerMensaje(ex), (ManejadorIdentidad.IdentidadActual != null ? ManejadorIdentidad.IdentidadActual.Name : null), parametros);
        //        throw;
        //    }

        //    //Resultado
        //    return resultado;
        //}

        ///// <author>Ernesto Medrano</author>
        ///// <creationdate>16-sep-2015</creationdate>
        ///// <summary>
        ///// Método para dar de alta al listado de objeto de tipo PersonaNatural.
        ///// Cambian los campos EstaActivo a True.
        ///// </summary>
        ///// <param name="idPersonaNaturalListado">Listado de identificadores de objetos.</param>
        ///// <returns>True: Operación exitosa
        ///// </returns>
        //public Boolean DarAltaListado(List<Int32> idPersonaNaturalListado) {

        //    //Declaraciones
        //    Sql.Modelo.PersonaNatural personaNatural;
        //    bool resultado = false;
        //    //TransactionScope transaccion;

        //    //Operaciones
        //    if (idPersonaNaturalListado == null) {
        //        throw new ArgumentNullException("idPersonaNaturalListado", MensajeExcepcion.ParametroEnNulo);
        //    }

        //    if (idPersonaNaturalListado.Count() == 0) {
        //        throw new ArgumentException(MensajeExcepcion.ParametroListaVacia, "idPersonaNaturalListado");
        //    }

        //    if (idPersonaNaturalListado.Where(l => l <= 0).Count() > 0) {
        //        throw new ArgumentException(MensajeExcepcion.IdentificadorObjetoNoValidoListado, "idPersonaNaturalListado");
        //    }

        //    try {
        //        ////using (transaccion = new TransactionScope()) {
        //        //using (var Contexto = (AdministracionBDEntidades)ConfiguracionContexto.ObtenerContexto()) {
        //        foreach (var perAD in idPersonaNaturalListado) {
        //            personaNatural = Contexto.PersonaNaturales.Where(p => p.IdPersonaNatural == perAD).FirstOrDefault();

        //            if (personaNatural == null) {
        //                throw new RegistroNoEncontradoExcepcion(MensajeExcepcion.RegistroNoEncontrado, typeof(Modelo.PersonaNatural), perAD);
        //            }

        //            personaNatural.EstaActivo = true;
        //            personaNatural.IdUsuarioModificacion = IdUsuario;
        //            personaNatural.FechaModificacion = DateTime.Now;
        //        }

        //        if (Contexto.SaveChanges() > 0) {
        //            resultado = true;
        //        }

        //        // if (resultado == true) {
        //        //transaccion.Complete();
        //        // }
        //        //  }
        //        //}
        //    } catch (Exception ex) {
        //        //Parámetros
        //        List<Object> parametros = new List<Object>();
        //        //parametros.Add(ManejadorIdentidad.IdentidadActual != null ? ManejadorIdentidad.IdentidadActual.Name : "");
        //        idPersonaNaturalListado.ForEach(x => //parametros.Add(x));


        //        //RegistroEventoWindows.RegistroEventoFun.RegistroExcepcionAD(MensajeExcepcion.ErrorInesperado, "DarAltaListadoPersonaNatural", RegistroEventoWindows.ExtraerTraza(ex), RegistroEventoWindows.ExtraerMensaje(ex), (ManejadorIdentidad.IdentidadActual != null ? ManejadorIdentidad.IdentidadActual.Name : null), parametros);
        //        throw;
        //    }

        //    //Resultado
        //    return resultado;
        //}

        ///// <author>Ernesto Medrano</author>
        ///// <creationdate>16-sep-2015</creationdate>
        ///// <summary>
        ///// Método para dar de baja al objeto de tipo PersonaNatural; 
        ///// Cambia el estado del objeto a "False".
        ///// </summary>
        ///// <param name="idPersonaNatural">Identificador del objeto.</param>
        ///// <returns>True: Operación exitosa</returns>
        //public Boolean DarBaja(Int32 idPersonaNatural) {

        //    //Declaraciones
        //    Sql.Modelo.PersonaNatural personaNatural;
        //    bool resultado = false;
        //    //TransactionScope transaccion;

        //    //Operaciones
        //    if (idPersonaNatural <= 0) {
        //        throw new ArgumentException(MensajeExcepcion.IdentificadorObjetoNoValido, "idPersonaNatural");
        //    }

        //    try {
        //        ////using (transaccion = new TransactionScope()) {
        //        //using (var Contexto = (AdministracionBDEntidades)ConfiguracionContexto.ObtenerContexto()) {
        //        personaNatural = Contexto.PersonaNaturales.Where(p => p.IdPersonaNatural == idPersonaNatural).FirstOrDefault();

        //        if (personaNatural == null) {
        //            throw new RegistroNoEncontradoExcepcion(MensajeExcepcion.RegistroNoEncontrado, typeof(Modelo.PersonaNatural), idPersonaNatural);
        //        }

        //        personaNatural.EstaActivo = false;
        //        personaNatural.FechaModificacion = DateTime.Now;
        //        personaNatural.IdUsuarioModificacion = IdUsuario;

        //        if (Contexto.SaveChanges() > 0) {
        //            resultado = true;
        //        }

        //        //  if (resultado == true) {
        //        //transaccion.Complete();
        //        // }
        //        //  }
        //        // }
        //    } catch (Exception ex) {
        //        //Parámetros
        //        List<Object> parametros = new List<Object>();
        //        //parametros.Add(ManejadorIdentidad.IdentidadActual != null ? ManejadorIdentidad.IdentidadActual.Name : "");

        //        //parametros.Add(idPersonaNatural);

        //        //RegistroEventoWindows.RegistroEventoFun.RegistroExcepcionAD(MensajeExcepcion.ErrorInesperado, "DarBajaPersonaNatural", RegistroEventoWindows.ExtraerTraza(ex), RegistroEventoWindows.ExtraerMensaje(ex), (ManejadorIdentidad.IdentidadActual != null ? ManejadorIdentidad.IdentidadActual.Name : null), parametros);
        //        throw;
        //    }

        //    //Resultado
        //    return resultado;
        //}

        ///// <author>Ernesto Medrano</author>
        ///// <creationdate>16-sep-2015</creationdate>
        ///// <summary>
        ///// Método para dar de baja al listado de objeto de tipo PersonaNatural.
        ///// Cambian los campos EstaActivo a True.
        ///// </summary>
        ///// <param name="idPersonaNaturalListado">Listado de identificadores de objetos.</param>
        ///// <returns>True: Operación exitosa.</returns>
        //public Boolean DarBajaListado(List<Int32> idPersonaNaturalListado) {

        //    //Declaraciones
        //    Sql.Modelo.PersonaNatural personaNatural;
        //    bool resultado = false;
        //    //TransactionScope transaccion;

        //    //Operaciones
        //    if (idPersonaNaturalListado == null) {
        //        throw new ArgumentNullException("idPersonaNaturalListado", MensajeExcepcion.ParametroEnNulo);
        //    }

        //    if (idPersonaNaturalListado.Count() == 0) {
        //        throw new ArgumentException(MensajeExcepcion.ParametroListaVacia, "idPersonaNaturalListado");
        //    }

        //    if (idPersonaNaturalListado.Where(p => p <= 0).Count() > 0) {
        //        throw new ArgumentException(MensajeExcepcion.IdentificadorObjetoNoValidoListado, "idPersonaNaturalListado");
        //    }

        //    try {
        //        ////using (transaccion = new TransactionScope()) {
        //        //using (var Contexto = (AdministracionBDEntidades)ConfiguracionContexto.ObtenerContexto()) {
        //        foreach (var perAD in idPersonaNaturalListado) {
        //            personaNatural = Contexto.PersonaNaturales.Where(ad => ad.IdPersonaNatural == perAD).FirstOrDefault();

        //            if (personaNatural == null) {
        //                throw new RegistroNoEncontradoExcepcion(MensajeExcepcion.RegistroNoEncontrado, typeof(Modelo.PersonaNatural), perAD);
        //            }

        //            personaNatural.EstaActivo = false;
        //            personaNatural.IdUsuarioModificacion = IdUsuario;
        //            personaNatural.FechaModificacion = DateTime.Now;
        //        }

        //        if (Contexto.SaveChanges() > 0) {
        //            resultado = true;
        //        }

        //        if (resultado == true) {
        //            //transaccion.Complete();
        //        }
        //        //  }
        //        // }
        //    } catch (Exception ex) {
        //        //Parámetros
        //        List<Object> parametros = new List<Object>();
        //        //parametros.Add(ManejadorIdentidad.IdentidadActual != null ? ManejadorIdentidad.IdentidadActual.Name : "");
        //        idPersonaNaturalListado.ForEach(x => //parametros.Add(x));

        //        //RegistroEventoWindows.RegistroEventoFun.RegistroExcepcionAD(MensajeExcepcion.ErrorInesperado, "DarBajaListadoPersonaNatural", RegistroEventoWindows.ExtraerTraza(ex), RegistroEventoWindows.ExtraerMensaje(ex), (ManejadorIdentidad.IdentidadActual != null ? ManejadorIdentidad.IdentidadActual.Name : null), parametros);
        //        throw;
        //    }

        //    //Resultado
        //    return resultado;
        //}

        ///// <author>Ernesto Medrano</author>
        ///// <creationdate>16-sep-2015</creationdate>
        ///// <summary>
        ///// Método para editar un objeto de tipo PersonaNatural.
        ///// </summary>
        ///// <param name="PersonaNatural">Objeto tipo PersonaNatural a ser editado.</param>
        ///// <returns>True: Operación exitosa</returns>
        //public Boolean Actualizar(Negocio.Entidades.Persona.PersonaNatural personaNatural) {

        //    //Declaraciones
        //    Sql.Modelo.PersonaNatural personaNaturalAD;
        //    Boolean resultado = false;
        //    //TransactionScope transaccion;

        //    //Operaciones
        //    if (personaNatural == null) {
        //        throw new ArgumentNullException("PersonaNatural", MensajeExcepcion.ParametroEnNulo);
        //    }

        //    if (personaNatural.IdPersonaNatural <= 0) {
        //        throw new ArgumentException(MensajeExcepcion.IdentificadorObjetoNoValido, "personaNatural");
        //    }

        //    try {
        //        ////using (transaccion = new TransactionScope()) {
        //        //using (var Contexto = (AdministracionBDEntidades)ConfiguracionContexto.ObtenerContexto()) {
        //        personaNaturalAD = Contexto.PersonaNaturales.Where(p => p.IdPersonaNatural == personaNatural.IdPersonaNatural).FirstOrDefault();

        //        if (personaNaturalAD == null) {
        //            throw new RegistroNoEncontradoExcepcion(MensajeExcepcion.RegistroNoEncontrado, typeof(Modelo.PersonaNatural), personaNatural.IdPersonaNatural);
        //        }

        //        personaNaturalAD = AutoMapeo.Mapeo(personaNatural, personaNaturalAD);
        //        personaNaturalAD.FechaModificacion = DateTime.Now;
        //        personaNaturalAD.IdUsuarioModificacion = IdUsuario;

        //        if (Contexto.SaveChanges() > 0) {
        //            resultado = true;
        //        }

        //        // if (resultado == true) {
        //        //transaccion.Complete();
        //        //}
        //        //}
        //        //}
        //    } catch (Exception ex) {
        //        //Parámetros
        //        List<Object> parametros = new List<Object>();
        //        //parametros.Add(ManejadorIdentidad.IdentidadActual != null ? ManejadorIdentidad.IdentidadActual.Name : "");                
        //        //parametros.Add(personaNatural);

        //        //RegistroEventoWindows.RegistroEventoFun.RegistroExcepcionAD(MensajeExcepcion.ErrorInesperado, "ActualizarPersonaNatural", RegistroEventoWindows.ExtraerTraza(ex), RegistroEventoWindows.ExtraerMensaje(ex), (ManejadorIdentidad.IdentidadActual != null ? ManejadorIdentidad.IdentidadActual.Name : null), parametros);
        //        throw;
        //    }

        //    //Resultado
        //    return resultado;
        //}

        ///// <author>Ernesto Medrano</author>
        ///// <creationdate>16-sep-2015</creationdate>
        ///// <summary>
        ///// Método para editar un listado de objetos de tipo PersonaNatural.
        ///// </summary>
        ///// <param name="PersonaNaturalListado">Listado de objetos de tipo PersonaNatural a ser editados</param>
        ///// <returns>True: Operación exitosa</returns>
        //public Boolean ActualizarListado(List<Negocio.Entidades.Persona.PersonaNatural> personaNaturalListado) {

        //    //Declaraciones
        //    Sql.Modelo.PersonaNatural personaNaturalAD;
        //    Boolean resultado = false;
        //    //TransactionScope transaccion;

        //    //Operaciones
        //    if (personaNaturalListado == null) {
        //        throw new ArgumentNullException("personaNaturalListado", MensajeExcepcion.ParametroEnNulo);
        //    }

        //    if (personaNaturalListado.Count() == 0) {
        //        throw new ArgumentException(MensajeExcepcion.ParametroListaVacia, "personaNaturalListado");
        //    }

        //    if (personaNaturalListado.Where(p => p.IdPersonaNatural <= 0).Count() > 0) {
        //        throw new ArgumentException(MensajeExcepcion.IdentificadorObjetoNoValidoListado, "personaNaturalListado");
        //    }

        //    try {
        //        ////using (transaccion = new TransactionScope()) {
        //        //using (var Contexto = (AdministracionBDEntidades)ConfiguracionContexto.ObtenerContexto()) {
        //        foreach (var per in personaNaturalListado) {
        //            personaNaturalAD = Contexto.PersonaNaturales.Where(p => p.IdPersonaNatural == per.IdPersonaNatural).FirstOrDefault();

        //            if (personaNaturalAD == null) {
        //                throw new RegistroNoEncontradoExcepcion(MensajeExcepcion.RegistroNoEncontrado, typeof(Modelo.PersonaNatural), per.IdPersonaNatural);
        //            }

        //            personaNaturalAD = AutoMapeo.Mapeo(per, personaNaturalAD);
        //            personaNaturalAD.FechaModificacion = DateTime.Now;
        //            personaNaturalAD.IdUsuarioModificacion = IdUsuario;
        //        }

        //        if (Contexto.SaveChanges() > 0) {
        //            resultado = true;
        //        }

        //        // if (resultado == true) {
        //        //transaccion.Complete();
        //        //}
        //        // }
        //        //}
        //    } catch (Exception ex) {
        //        //Parámetros
        //        List<Object> parametros = new List<Object>();
        //        //parametros.Add(ManejadorIdentidad.IdentidadActual != null ? ManejadorIdentidad.IdentidadActual.Name : "");
        //        personaNaturalListado.ForEach(x => //parametros.Add(x));

        //        //RegistroEventoWindows.RegistroEventoFun.RegistroExcepcionAD(MensajeExcepcion.ErrorInesperado, "ActualizarListadoPersonaNatural", RegistroEventoWindows.ExtraerTraza(ex), RegistroEventoWindows.ExtraerMensaje(ex), (ManejadorIdentidad.IdentidadActual != null ? ManejadorIdentidad.IdentidadActual.Name : null), parametros);
        //        throw;
        //    }

        //    //Resultado
        //    return resultado;
        //}

        ///// <author>Ernesto Medrano</author>
        ///// <creationdate>16-sep-2015</creationdate>
        ///// <summary>
        ///// Método para eliminar un objeto de tipo PersonaNatural. 
        ///// </summary>
        ///// <param name="idPersonaNatural">Identificador del objeto.</param>
        ///// <returns>True: Operación exitosa</returns>
        //public Boolean Eliminar(Int32 idPersonaNatural) {
        //    //Declaraciones
        //    Sql.Modelo.PersonaNatural personaNatural;
        //    bool resultado = false;
        //    //TransactionScope transaccion;

        //    //Operaciones
        //    if (idPersonaNatural <= 0) {
        //        throw new ArgumentException(MensajeExcepcion.IdentificadorObjetoNoValido, "idPersonaNatural");
        //    }

        //    try {
        //        ////using (transaccion = new TransactionScope()) {
        //        //using (var Contexto = (AdministracionBDEntidades)ConfiguracionContexto.ObtenerContexto()) {
        //        personaNatural = Contexto.PersonaNaturales.Where(ad => ad.IdPersonaNatural == idPersonaNatural).FirstOrDefault();

        //        if (personaNatural == null) {
        //            throw new RegistroNoEncontradoExcepcion(MensajeExcepcion.RegistroNoEncontrado, typeof(Modelo.PersonaNatural), idPersonaNatural);
        //        }

        //        Contexto.PersonaNaturales.Remove(personaNatural);
        //        if (Contexto.SaveChanges() > 0) {
        //            resultado = true;
        //        }

        //        //  if (resultado == true) {
        //        //transaccion.Complete();
        //        //   }
        //        // }
        //        //}
        //    } catch (Exception ex) {
        //        //Parámetros
        //        List<Object> parametros = new List<Object>();
        //        //parametros.Add(ManejadorIdentidad.IdentidadActual != null ? ManejadorIdentidad.IdentidadActual.Name : "");

        //        //parametros.Add(idPersonaNatural );

        //        //RegistroEventoWindows.RegistroEventoFun.RegistroExcepcionAD(MensajeExcepcion.ErrorInesperado, "EliminarPersonaNatural", RegistroEventoWindows.ExtraerTraza(ex), RegistroEventoWindows.ExtraerMensaje(ex), (ManejadorIdentidad.IdentidadActual != null ? ManejadorIdentidad.IdentidadActual.Name : null), parametros);
        //        throw;
        //    }

        //    //Resultado
        //    return resultado;
        //}

        ///// <author>Ernesto Medrano</author>
        ///// <creationdate>16-sep-2015</creationdate>
        ///// <summary>
        ///// Método para eliminar un listado de objetos de tipo PersonaNatural.
        ///// </summary>
        ///// <param name="idPersonaNaturalListado">Listado de identificadores de objetos.</param>
        ///// <returns>True: Operación exitosa</returns>
        //public Boolean EliminarListado(List<Int32> idPersonaNaturalListado) {
        //    //Declaraciones
        //    Sql.Modelo.PersonaNatural personaNatural;
        //    bool resultado = false;
        //    //TransactionScope transaccion;

        //    //Operaciones
        //    if (idPersonaNaturalListado == null) {
        //        throw new ArgumentNullException("idPersonaNaturalListado", MensajeExcepcion.ParametroEnNulo);
        //    }

        //    if (idPersonaNaturalListado.Count() == 0) {
        //        throw new ArgumentException(MensajeExcepcion.ParametroListaVacia, "idPersonaNaturalListado");
        //    }

        //    if (idPersonaNaturalListado.Where(p => p <= 0).Count() > 0) {
        //        throw new ArgumentException(MensajeExcepcion.IdentificadorObjetoNoValidoListado, "idPersonaNaturalListado");
        //    }

        //    try {
        //        ////using (transaccion = new TransactionScope()) {
        //        //using (var Contexto = (AdministracionBDEntidades)ConfiguracionContexto.ObtenerContexto()) {
        //        foreach (var perAD in idPersonaNaturalListado) {
        //            personaNatural = Contexto.PersonaNaturales.Where(ad => ad.IdPersonaNatural == perAD).FirstOrDefault();

        //            if (personaNatural == null) {
        //                throw new RegistroNoEncontradoExcepcion(MensajeExcepcion.RegistroNoEncontrado, typeof(Modelo.PersonaNatural), perAD);
        //            }

        //            Contexto.PersonaNaturales.Remove(personaNatural);
        //        }

        //        if (Contexto.SaveChanges() > 0) {
        //            resultado = true;
        //        }

        //        // if (resultado == true) {
        //        //transaccion.Complete();
        //        //  }
        //        // }
        //        //}
        //    } catch (Exception ex) {
        //        //Parámetros
        //        List<Object> parametros = new List<Object>();
        //        //parametros.Add(ManejadorIdentidad.IdentidadActual != null ? ManejadorIdentidad.IdentidadActual.Name : "");
        //        idPersonaNaturalListado.ForEach(x => //parametros.Add(x));

        //        //RegistroEventoWindows.RegistroEventoFun.RegistroExcepcionAD(MensajeExcepcion.ErrorInesperado, "EliminarListadoPersonaNatural", RegistroEventoWindows.ExtraerTraza(ex), RegistroEventoWindows.ExtraerMensaje(ex), (ManejadorIdentidad.IdentidadActual != null ? ManejadorIdentidad.IdentidadActual.Name : null), parametros);
        //        throw;
        //    }

        //    //Resultado
        //    return resultado;
        //}

        ///// <author>Ernesto Medrano</author>
        ///// <creationdate>16-sep-2015</creationdate>
        ///// <summary>
        ///// Método para obtener un objeto tipo PersonaNatural.
        ///// </summary>
        ///// <param name="idPersonaNatural">Identificador del objeto.</param>
        ///// <returns>Retorna el objeto tipo PersonaNatural.</returns>
        //public Negocio.Entidades.Persona.PersonaNatural Obtener(Int32 idPersonaNatural) {

        //    //Declaraciones            
        //    Sql.Modelo.PersonaNatural personaNaturalAD = new Sql.Modelo.PersonaNatural();
        //    Negocio.Entidades.Persona.PersonaNatural personaNatural = new Negocio.Entidades.Persona.PersonaNatural();

        //    //Operaciones
        //    if (idPersonaNatural <= 0) {
        //        throw new ArgumentException(MensajeExcepcion.IdentificadorObjetoNoValido, "idPersonaNatural");
        //    }

        //    try {
        //        //using (var Contexto = (AdministracionBDEntidades)ConfiguracionContexto.ObtenerContexto()) {
        //        personaNaturalAD = Contexto.PersonaNaturales.Where(p => p.IdPersonaNatural == idPersonaNatural).FirstOrDefault();

        //        if (personaNaturalAD == null) {
        //            throw new RegistroNoEncontradoExcepcion(MensajeExcepcion.RegistroNoEncontrado, typeof(Modelo.PersonaNatural), idPersonaNatural);
        //        } else {
        //            personaNatural = AutoMapeo.Mapeo(personaNaturalAD, personaNatural);
        //        }
        //        //}
        //    } catch (Exception ex) {
        //        //Parámetros
        //        List<Object> parametros = new List<Object>();
        //        //parametros.Add(ManejadorIdentidad.IdentidadActual != null ? ManejadorIdentidad.IdentidadActual.Name : "");                
        //        //parametros.Add(idPersonaNatural);

        //        //RegistroEventoWindows.RegistroEventoFun.RegistroExcepcionAD(MensajeExcepcion.ErrorInesperado, "ObtenerListadoPersonaNatural", RegistroEventoWindows.ExtraerTraza(ex), RegistroEventoWindows.ExtraerMensaje(ex), (ManejadorIdentidad.IdentidadActual != null ? ManejadorIdentidad.IdentidadActual.Name : null), parametros);
        //        throw;
        //    }

        //    //Resultado
        //    return personaNatural;
        //}

        ///// <author>Ernesto Medrano</author>
        ///// <creationdate>16-sep-2015</creationdate>
        ///// <summary>
        ///// <param name="idPersonaNaturalListado">Lisrtado de identificador de objetos.</param>
        ///// <returns>Retorna el listado de Objetos PersonaNatural</returns>
        //public List<Negocio.Entidades.Persona.PersonaNatural> ObtenerListado(List<Int32> idPersonaNaturalListado) {
        //    //Declaraciones          
        //    List<Negocio.Entidades.Persona.PersonaNatural> personaNaturalListado = new List<Negocio.Entidades.Persona.PersonaNatural>();

        //    //Operaciones
        //    if (idPersonaNaturalListado == null) {
        //        throw new ArgumentNullException("idPersonaNaturalListado", MensajeExcepcion.ParametroEnNulo);
        //    }

        //    if (idPersonaNaturalListado.Count() == 0) {
        //        throw new ArgumentException(MensajeExcepcion.ParametroListaVacia, "idPersonaNaturalListado");
        //    }

        //    if (idPersonaNaturalListado.Where(l => l <= 0).Count() > 0) {
        //        throw new ArgumentException(MensajeExcepcion.IdentificadorObjetoNoValidoListado, "idPersonaNaturalListado");
        //    }

        //    try {
        //        ////using ( var Contexto = (AdministracionBDEntidades)ConfiguracionContexto.ObtenerContexto() ) {
        //        //    var consultaAd = Contexto.PersonaNaturales.ToList();

        //        //    //var consulta = from ra in Contexto.PersonaNaturales
        //        //    //               join lId in idPersonaNaturalListado on ra.IdPersonaNatural equals lId
        //        //    //               select ra;

        //        //    consultaAd.RemoveAll(x => !idPersonaNaturalListado.Contains(x.IdPersonaNatural));
        //        //    if ( consultaAd.Count() >= 0 ) {
        //        //        personaNaturalListado = consultaAd.ToList().Select(per => AutoMapeo.Mapeo(per, new Negocio.Entidades.Persona.PersonaNatural())).ToList();
        //        //    }
        //        //}
        //        foreach (var idPersonaNatural in idPersonaNaturalListado) {
        //            personaNaturalListado.Add(new Negocio.Entidades.Persona.PersonaNatural() { IdPersonaNatural = idPersonaNatural });
        //        }
        //        personaNaturalListado = ObtenerListadoPersonaNaturalPorCriterio(personaNaturalListado, Activo.Todos);
        //    } catch (Exception ex) {
        //        //Parámetros
        //        List<Object> parametros = new List<Object>();
        //        //parametros.Add(ManejadorIdentidad.IdentidadActual != null ? ManejadorIdentidad.IdentidadActual.Name : "");
        //        idPersonaNaturalListado.ForEach(x => //parametros.Add(x));

        //        //RegistroEventoWindows.RegistroEventoFun.RegistroExcepcionAD(MensajeExcepcion.ErrorInesperado, "ObtenerListadoPersonaNatural", RegistroEventoWindows.ExtraerTraza(ex), RegistroEventoWindows.ExtraerMensaje(ex), (ManejadorIdentidad.IdentidadActual != null ? ManejadorIdentidad.IdentidadActual.Name : null), parametros);
        //        throw;
        //    }

        //    //Resultado
        //    return personaNaturalListado;
        //}

        ///// <author>Jose Miguel Lopez Sevilla</author>
        ///// <creationdate>16-sep-2015</creationdate>
        ///// <summary>
        ///// <param name="idPersonaNaturalListado">Lisrtado de identificador de objetos.</param>
        ///// <returns>Retorna el listado de Objetos PersonaNatural</returns>
        //public List<Negocio.Entidades.Persona.PersonaNatural> ObtenerListadoDatosEmpleado(List<Int32> idPersonaNaturalListado) {
        //    //Declaraciones          
        //    List<Negocio.Entidades.Persona.PersonaNatural> personaNaturalListado = new List<Negocio.Entidades.Persona.PersonaNatural>();

        //    //Operaciones
        //    if (idPersonaNaturalListado == null) {
        //        throw new ArgumentNullException("idPersonaNaturalListado", MensajeExcepcion.ParametroEnNulo);
        //    }

        //    if (idPersonaNaturalListado.Count() == 0) {
        //        throw new ArgumentException(MensajeExcepcion.ParametroListaVacia, "idPersonaNaturalListado");
        //    }

        //    if (idPersonaNaturalListado.Where(l => l <= 0).Count() > 0) {
        //        throw new ArgumentException(MensajeExcepcion.IdentificadorObjetoNoValidoListado, "idPersonaNaturalListado");
        //    }

        //    try {
        //        ////using ( var Contexto = (AdministracionBDEntidades)ConfiguracionContexto.ObtenerContexto() ) {
        //        //    var consultaAd = Contexto.PersonaNaturales.ToList();

        //        //    //var consulta = from ra in Contexto.PersonaNaturales
        //        //    //               join lId in idPersonaNaturalListado on ra.IdPersonaNatural equals lId
        //        //    //               select ra;

        //        //    consultaAd.RemoveAll(x => !idPersonaNaturalListado.Contains(x.IdPersonaNatural));
        //        //    if ( consultaAd.Count() >= 0 ) {
        //        //        personaNaturalListado = consultaAd.ToList().Select(per => AutoMapeo.Mapeo(per, new Negocio.Entidades.Persona.PersonaNatural())).ToList();
        //        //    }
        //        //}
        //        foreach (var idPersonaNatural in idPersonaNaturalListado) {
        //            personaNaturalListado.Add(new Negocio.Entidades.Persona.PersonaNatural() { IdPersonaNatural = idPersonaNatural });
        //        }
        //        personaNaturalListado = ObtenerListadoPorCriterioDatosEmpleado(personaNaturalListado, Activo.Todos);
        //    } catch (Exception ex) {
        //        //Parámetros
        //        List<Object> parametros = new List<Object>();
        //        //parametros.Add(ManejadorIdentidad.IdentidadActual != null ? ManejadorIdentidad.IdentidadActual.Name : "");
        //        idPersonaNaturalListado.ForEach(x => //parametros.Add(x));

        //        //RegistroEventoWindows.RegistroEventoFun.RegistroExcepcionAD(MensajeExcepcion.ErrorInesperado, "ObtenerListadoDatosEmpleado", RegistroEventoWindows.ExtraerTraza(ex), RegistroEventoWindows.ExtraerMensaje(ex), (ManejadorIdentidad.IdentidadActual != null ? ManejadorIdentidad.IdentidadActual.Name : null), parametros);
        //        throw;
        //    }


        //    //Resultado
        //    return personaNaturalListado;
        //}

        ///// <author>Ernesto Medrano</author>
        ///// <creationdate>16-sep-2015</creationdate>
        ///// <summary>
        ///// Método para obtener un listado de objetos de tipo PersonaNatural.
        ///// </summary>
        ///// <param name="activo">Estado de los Objetos de tipo PersonaNatural.</param>
        ///// <returns>Retorna el listado de Objetos PersonaNatural</returns>
        //public List<Negocio.Entidades.Persona.PersonaNatural> ObtenerListado(Activo activo) {

        //    //Declaraciones 
        //    List<Sql.Modelo.PersonaNatural> listadoAD = new List<Sql.Modelo.PersonaNatural>();
        //    List<Negocio.Entidades.Persona.PersonaNatural> listado = new List<Negocio.Entidades.Persona.PersonaNatural>();

        //    if (!Enum.IsDefined(typeof(Activo), activo)) {
        //        throw new ArgumentOutOfRangeException("activo", MensajeExcepcion.EnumeracionValorInvalido);
        //    }

        //    IEnumerable<Sql.Modelo.PersonaNatural> consultaAD;

        //    try {
        //        consultaAD = Contexto.PersonaNaturales;
        //        //Verificando registros activos
        //        switch (activo) {
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
        //        listado = listadoAD.ToList().Select(personanatural => AutoMapeo.Mapeo(personanatural, new Negocio.Entidades.Persona.PersonaNatural())).ToList();
        //    } catch (Exception ex) {
        //        //Parámetros
        //        List<Object> parametros = new List<Object>();
        //        //parametros.Add(ManejadorIdentidad.IdentidadActual != null ? ManejadorIdentidad.IdentidadActual.Name : "");

        //        //parametros.Add(activo);

        //        //RegistroEventoWindows.RegistroEventoFun.RegistroExcepcionAD(MensajeExcepcion.ErrorInesperado, "ObtenerListadoPersonaNatural", RegistroEventoWindows.ExtraerTraza(ex), RegistroEventoWindows.ExtraerMensaje(ex), (ManejadorIdentidad.IdentidadActual != null ? ManejadorIdentidad.IdentidadActual.Name : null), parametros);
        //        throw;
        //    }

        //    //Resultado
        //    return listado;
        //}

        ///// <author>Ernesto Medrano</author>
        ///// <creationdate>16-sep-2015</creationdate>
        ///// <summary>
        ///// Método para obtener un listado de objetos de tipo PersonaNatural.
        ///// en dependencia del criterio de filtrado.
        ///// </summary>
        ///// <param name="criterio">Objeto de tipo PersonaNatural a obtener.</param>
        ///// <param name="activo">Estado de los Objetos de tipo PersonaNatural.</param>
        ///// <returns>Retorna listado de objetos PersonaNatural</returns>
        //public List<Negocio.Entidades.Persona.PersonaNatural> ObtenerListadoPersonaNaturalPorCriterio(Negocio.Entidades.Persona.PersonaNatural criterio, Activo activo) {

        //    //Declaraciones
        //    List<Negocio.Entidades.Persona.PersonaNatural> personaNaturalListado = new List<Negocio.Entidades.Persona.PersonaNatural>();

        //    //Operaciones

        //    if (criterio == null) {
        //        throw new ArgumentNullException("criterio", MensajeExcepcion.ParametroEnNulo);
        //    }

        //    if (!Enum.IsDefined(typeof(Activo), activo)) {
        //        throw new ArgumentOutOfRangeException("activo", MensajeExcepcion.EnumeracionValorInvalido);
        //    }

        //    personaNaturalListado.Add(criterio);

        //    //Resultado
        //    return ObtenerListadoPersonaNaturalPorCriterio(personaNaturalListado, activo);
        //}

        ///// <author>Ernesto Medrano</author>
        ///// <creationdate>16-sep-2015</creationdate>
        ///// <summary>
        ///// Método para obtener un listado de objetos de tipo PersonaNatural.
        ///// en dependencia del criterio de filtrado.
        ///// </summary>
        ///// <param name="criterioListado">Listado de Tipo Opcion Usuario</param>
        ///// <param name="activo">Estado de los objetos de tipo PersonaNatural.</param>
        ///// <returns>Retorna listado de objetos PersonaNatural.</returns>
        //public List<Negocio.Entidades.Persona.PersonaNatural> ObtenerListadoPersonaNaturalPorCriterio(List<Negocio.Entidades.Persona.PersonaNatural> criterioListado, Activo activo) {
        //    //Declaraciones 
        //    List<SqlParameter> parametrolistado = new List<SqlParameter>();
        //    StringBuilder consulta = new StringBuilder();
        //    List<Sql.Modelo.PersonaNatural> personaNaturalListadoAD = new List<Sql.Modelo.PersonaNatural>();
        //    List<Negocio.Entidades.Persona.PersonaNatural> personaNaturalListado = new List<Negocio.Entidades.Persona.PersonaNatural>();
        //    String listadoCriterio = "";

        //    //Operaciones
        //    if (criterioListado == null) {
        //        throw new ArgumentNullException("criterioListado", MensajeExcepcion.ParametroEnNulo);
        //    }

        //    if (criterioListado.Count() <= 0) {
        //        throw new ArgumentException(MensajeExcepcion.ParametroListaVacia, "criterioListado");
        //    }

        //    if (!Enum.IsDefined(typeof(Activo), activo)) {
        //        throw new ArgumentOutOfRangeException("activo", MensajeExcepcion.EnumeracionValorInvalido);
        //    }

        //    try {
        //        using (var contexto = new ConfiguracionContexto().ObtenerContexto()) {
        //            // consultaAD = Contexto.PersonaNaturales;
        //            //var consultaAd = Contexto.PersonaNaturales.Take(10000).ToList();
        //            //personaNaturalListadoAD = consultaAD.ToList().Select(l => (Sql.Modelo.PersonaNatural)l).ToList<Sql.Modelo.PersonaNatural>();
        //            //Verificando filtros

        //            if (criterioListado.Where(x => x.IdPersonaNatural != 0).Count() > 0) {
        //                var idPersonaNaturalListado = criterioListado.Select(x => x.IdPersonaNatural).ToList();

        //                foreach (var item in idPersonaNaturalListado) {
        //                    listadoCriterio = listadoCriterio + item.ToString() + ",";
        //                }
        //                personaNaturalListadoAD = contexto.Database.SqlQuery<PersonaNatural>("Persona.prObtenerPersonaNatural @listadoCriterio, @tipoCriterio", new SqlParameter("@listadoCriterio", listadoCriterio), new SqlParameter("@tipoCriterio", "IdPersonaNatural")).ToList();

        //                //consultaAd.RemoveAll(x => !IdPersonaNaturalListado.Contains(x.IdPersonaNatural));
        //                //consulta.Append(Contexto.PersonaNaturales.ToString() + " ");
        //                //consulta.Append(Utilidades.FuncionSql.AgregarFuncionFiltroEntero(parametrolistado, "IdPersonaNatural", IdPersonaNaturalListado));
        //                //personaNaturalListadoAD = Contexto.Database.SqlQuery<Sql.Modelo.PersonaNatural>(consulta.ToString(), parametrolistado.ToArray()).ToList();
        //            }

        //            if (criterioListado.Any(x => String.IsNullOrEmpty(x.PrimerNombre) == false)) {
        //                var Nombre1Listado = criterioListado.Select(x => x.PrimerNombre).ToList();
        //                foreach (var item in Nombre1Listado) {
        //                    listadoCriterio = listadoCriterio + item.ToString() + ",";
        //                }
        //                personaNaturalListadoAD = contexto.Database.SqlQuery<PersonaNatural>("Persona.prObtenerPersonaNatural @listadoCriterio, @tipoCriterio", new SqlParameter("@listadoCriterio", listadoCriterio), new SqlParameter("@tipoCriterio", "Nombre1")).ToList();

        //                //consultaAd.RemoveAll(x => !Nombre1Listado.Contains(x.Nombre1));
        //                //consulta.Append(Contexto.PersonaNaturales.ToString() + " ");
        //                //consulta.Append(Utilidades.FuncionSql.AgregarFuncionFiltroCadena(parametrolistado, "Nombre1", Nombre1Listado));
        //                //personaNaturalListadoAD = Contexto.Database.SqlQuery<Sql.Modelo.PersonaNatural>(consulta.ToString(), parametrolistado.ToArray()).ToList();
        //            }

        //            if (criterioListado.Any(x => String.IsNullOrEmpty(x.SegundoNombre) == false)) {
        //                var Nombre2Listado = criterioListado.Select(x => x.SegundoNombre).ToList();
        //                foreach (var item in Nombre2Listado) {
        //                    listadoCriterio = listadoCriterio + item.ToString() + ",";
        //                }
        //                personaNaturalListadoAD = contexto.Database.SqlQuery<PersonaNatural>("Persona.prObtenerPersonaNatural @listadoCriterio, @tipoCriterio", new SqlParameter("@listadoCriterio", listadoCriterio), new SqlParameter("@tipoCriterio", "Nombre2")).ToList();

        //                //consultaAd.RemoveAll(x => !Nombre2Listado.Contains(x.Nombre2));
        //                //consulta.Append(Contexto.PersonaNaturales.ToString() + " ");
        //                //consulta.Append(Utilidades.FuncionSql.AgregarFuncionFiltroCadena(parametrolistado, "Nombre2", Nombre2Listado));
        //                //personaNaturalListadoAD = Contexto.Database.SqlQuery<Sql.Modelo.PersonaNatural>(consulta.ToString(), parametrolistado.ToArray()).ToList();
        //            }

        //            if (criterioListado.Any(x => String.IsNullOrEmpty(x.TercerNombre) == false)) {
        //                var Nombre3Listado = criterioListado.Select(x => x.TercerNombre).ToList();
        //                foreach (var item in Nombre3Listado) {
        //                    listadoCriterio = listadoCriterio + item.ToString() + ",";
        //                }
        //                personaNaturalListadoAD = contexto.Database.SqlQuery<PersonaNatural>("Persona.prObtenerPersonaNatural @listadoCriterio, @tipoCriterio", new SqlParameter("@listadoCriterio", listadoCriterio), new SqlParameter("@tipoCriterio", "Nombre3")).ToList();

        //                //consultaAd.RemoveAll(x => !Nombre3Listado.Contains(x.Nombre3));
        //                //consulta.Append(Contexto.PersonaNaturales.ToString() + " ");
        //                //consulta.Append(Utilidades.FuncionSql.AgregarFuncionFiltroCadena(parametrolistado, "Nombre3", Nombre3Listado));
        //                //personaNaturalListadoAD = Contexto.Database.SqlQuery<Sql.Modelo.PersonaNatural>(consulta.ToString(), parametrolistado.ToArray()).ToList();
        //            }

        //            if (criterioListado.Any(x => String.IsNullOrEmpty(x.CuartoNombre) == false)) {
        //                var Nombre4Listado = criterioListado.Select(x => x.CuartoNombre).ToList();
        //                foreach (var item in Nombre4Listado) {
        //                    listadoCriterio = listadoCriterio + item.ToString() + ",";
        //                }
        //                personaNaturalListadoAD = contexto.Database.SqlQuery<PersonaNatural>("Persona.prObtenerPersonaNatural @listadoCriterio, @tipoCriterio", new SqlParameter("@listadoCriterio", listadoCriterio), new SqlParameter("@tipoCriterio", "Nombre4")).ToList();

        //                //consultaAd.RemoveAll(x => !Nombre4Listado.Contains(x.Nombre4));
        //                //consulta.Append(Contexto.PersonaNaturales.ToString() + " ");
        //                //consulta.Append(Utilidades.FuncionSql.AgregarFuncionFiltroCadena(parametrolistado, "Nombre4", Nombre4Listado));
        //                //personaNaturalListadoAD = Contexto.Database.SqlQuery<Sql.Modelo.PersonaNatural>(consulta.ToString(), parametrolistado.ToArray()).ToList();
        //            }

        //            if (criterioListado.Any(x => String.IsNullOrEmpty(x.PrimerApellido) == false)) {
        //                var Apellido1Listado = criterioListado.Select(x => x.PrimerApellido).ToList();
        //                foreach (var item in Apellido1Listado) {
        //                    listadoCriterio = listadoCriterio + item.ToString() + ",";
        //                }
        //                personaNaturalListadoAD = contexto.Database.SqlQuery<PersonaNatural>("Persona.prObtenerPersonaNatural @listadoCriterio, @tipoCriterio", new SqlParameter("@listadoCriterio", listadoCriterio), new SqlParameter("@tipoCriterio", "Apellido1")).ToList();

        //                //consultaAd.RemoveAll(x => !Apellido1Listado.Contains(x.Apellido1));
        //                //consulta.Append(Contexto.PersonaNaturales.ToString() + " ");
        //                //consulta.Append(Utilidades.FuncionSql.AgregarFuncionFiltroCadena(parametrolistado, "Apellido1", Apellido1Listado));
        //                //personaNaturalListadoAD = Contexto.Database.SqlQuery<Sql.Modelo.PersonaNatural>(consulta.ToString(), parametrolistado.ToArray()).ToList();
        //            }

        //            if (criterioListado.Any(x => String.IsNullOrEmpty(x.SegundoApellido) == false)) {
        //                var Apellido2Listado = criterioListado.Select(x => x.SegundoApellido).ToList();
        //                foreach (var item in Apellido2Listado) {
        //                    listadoCriterio = listadoCriterio + item.ToString() + ",";
        //                }
        //                personaNaturalListadoAD = contexto.Database.SqlQuery<PersonaNatural>("Persona.prObtenerPersonaNatural @listadoCriterio, @tipoCriterio", new SqlParameter("@listadoCriterio", listadoCriterio), new SqlParameter("@tipoCriterio", "Apellido2")).ToList();

        //                //consultaAd.RemoveAll(x => !Apellido2Listado.Contains(x.Apellido2));
        //                //consulta.Append(Contexto.PersonaNaturales.ToString() + " ");
        //                //consulta.Append(Utilidades.FuncionSql.AgregarFuncionFiltroCadena(parametrolistado, "Apellido2", Apellido2Listado));
        //                //personaNaturalListadoAD = Contexto.Database.SqlQuery<Sql.Modelo.PersonaNatural>(consulta.ToString(), parametrolistado.ToArray()).ToList();
        //            }

        //            if (criterioListado.Any(x => String.IsNullOrEmpty(x.NombreCompleto) == false)) {
        //                var NombreCompletoListado = criterioListado.Select(x => x.NombreCompleto).ToList();
        //                foreach (var item in NombreCompletoListado) {
        //                    listadoCriterio = listadoCriterio + item.ToString() + ",";
        //                }
        //                personaNaturalListadoAD = contexto.Database.SqlQuery<PersonaNatural>("Persona.prObtenerPersonaNatural @listadoCriterio, @tipoCriterio", new SqlParameter("@listadoCriterio", listadoCriterio), new SqlParameter("@tipoCriterio", "NombreCompleto")).ToList();

        //                //consultaAd.RemoveAll(x => !NombreCompletoListado.Contains(x.NombreCompleto));
        //                //consulta.Append(Contexto.PersonaNaturales.ToString() + " ");
        //                //consulta.Append(Utilidades.FuncionSql.AgregarFuncionFiltroCadena(parametrolistado, "NombreCompleto", NombreCompletoListado));
        //                //personaNaturalListadoAD = Contexto.Database.SqlQuery<Sql.Modelo.PersonaNatural>(consulta.ToString(), parametrolistado.ToArray()).ToList();
        //            }

        //            if (criterioListado.Any(x => String.IsNullOrEmpty(x.ConocidoComo) == false)) {
        //                var ConocidoComoListado = criterioListado.Select(x => x.ConocidoComo).ToList();
        //                foreach (var item in ConocidoComoListado) {
        //                    listadoCriterio = listadoCriterio + item.ToString() + ",";
        //                }
        //                personaNaturalListadoAD = contexto.Database.SqlQuery<PersonaNatural>("Persona.prObtenerPersonaNatural @listadoCriterio, @tipoCriterio", new SqlParameter("@listadoCriterio", listadoCriterio), new SqlParameter("@tipoCriterio", "ConocidoComo")).ToList();

        //                //consultaAd.RemoveAll(x => !ConocidoComoListado.Contains(x.ConocidoComo));
        //                //consulta.Append(Contexto.PersonaNaturales.ToString() + " ");
        //                //consulta.Append(Utilidades.FuncionSql.AgregarFuncionFiltroCadena(parametrolistado, "ConocidoComo", ConocidoComoListado));
        //                //personaNaturalListadoAD = Contexto.Database.SqlQuery<Sql.Modelo.PersonaNatural>(consulta.ToString(), parametrolistado.ToArray()).ToList();
        //            }

        //            if (criterioListado.Any(x => x.Persona != null && x.Persona.IdPersona != 0)) {
        //                var IdPersonaListado = criterioListado.Select(x => x.Persona.IdPersona).ToList();
        //                foreach (var item in IdPersonaListado) {
        //                    listadoCriterio = listadoCriterio + item.ToString() + ",";
        //                }
        //                personaNaturalListadoAD = contexto.Database.SqlQuery<PersonaNatural>("Persona.prObtenerPersonaNatural @listadoCriterio, @tipoCriterio", new SqlParameter("@listadoCriterio", listadoCriterio), new SqlParameter("@tipoCriterio", "IdPersona")).ToList();

        //                //consultaAd.RemoveAll(x => !IdPersonaListado.Contains(x.IdPersona));
        //                //consulta.Append(Contexto.PersonaNaturales.ToString() + " ");
        //                //consulta.Append(Utilidades.FuncionSql.AgregarFuncionFiltroEntero(parametrolistado, "IdPersona", IdPersonaListado));
        //                //personaNaturalListadoAD = Contexto.Database.SqlQuery<Sql.Modelo.PersonaNatural>(consulta.ToString(), parametrolistado.ToArray()).ToList();
        //            }

        //            if (criterioListado.Any(x => x.Genero != null && x.Genero.IdValor != 0)) {
        //                var IdGeneroListado = criterioListado.Select(x => x.Genero.IdValor).ToList();
        //                foreach (var item in IdGeneroListado) {
        //                    listadoCriterio = listadoCriterio + item.ToString() + ",";
        //                }
        //                personaNaturalListadoAD = contexto.Database.SqlQuery<PersonaNatural>("Persona.prObtenerPersonaNatural @listadoCriterio, @tipoCriterio", new SqlParameter("@listadoCriterio", listadoCriterio), new SqlParameter("@tipoCriterio", "IdGenero")).ToList();

        //                //consultaAd.RemoveAll(x => !IdGeneroListado.Contains(x.IdGenero));
        //                //consulta.Append(Contexto.PersonaNaturales.ToString() + " ");
        //                //consulta.Append(Utilidades.FuncionSql.AgregarFuncionFiltroEntero(parametrolistado, "IdGenero", IdGeneroListado));
        //                //personaNaturalListadoAD = Contexto.Database.SqlQuery<Sql.Modelo.PersonaNatural>(consulta.ToString(), parametrolistado.ToArray()).ToList();
        //            }

        //            if (criterioListado.Any(x => x.EstadoCivil != null && x.EstadoCivil.IdValor != 0)) {
        //                var IdEstadoCivilListado = criterioListado.Select(x => x.EstadoCivil.IdValor).ToList();
        //                foreach (var item in IdEstadoCivilListado) {
        //                    listadoCriterio = listadoCriterio + item.ToString() + ",";
        //                }
        //                personaNaturalListadoAD = contexto.Database.SqlQuery<PersonaNatural>("Persona.prObtenerPersonaNatural @listadoCriterio, @tipoCriterio", new SqlParameter("@listadoCriterio", listadoCriterio), new SqlParameter("@tipoCriterio", "IdEstadoCivil")).ToList();

        //                //consultaAd.RemoveAll(x => !IdEstadoCivilListado.Contains(x.IdEstadoCivil));
        //                //consulta.Append(Contexto.PersonaNaturales.ToString() + " ");
        //                //consulta.Append(Utilidades.FuncionSql.AgregarFuncionFiltroEntero(parametrolistado, "IdEstadoCivil", IdEstadoCivilListado));
        //                //personaNaturalListadoAD = Contexto.Database.SqlQuery<Sql.Modelo.PersonaNatural>(consulta.ToString(), parametrolistado.ToArray()).ToList();
        //            }

        //            if (criterioListado.Any(x => x.Ocupacion != null && x.Ocupacion.IdValor != 0)) {
        //                var IdOcupacionListado = criterioListado.Select(x => x.Ocupacion.IdValor).ToList();
        //                foreach (var item in IdOcupacionListado) {
        //                    listadoCriterio = listadoCriterio + item.ToString() + ",";
        //                }
        //                personaNaturalListadoAD = contexto.Database.SqlQuery<PersonaNatural>("Persona.prObtenerPersonaNatural @listadoCriterio, @tipoCriterio", new SqlParameter("@listadoCriterio", listadoCriterio), new SqlParameter("@tipoCriterio", "IdOcupacion")).ToList();

        //                //consultaAd.RemoveAll(x => !IdOcupacionListado.Contains(x.IdOcupacion));
        //                //consulta.Append(Contexto.PersonaNaturales.ToString() + " ");
        //                //consulta.Append(Utilidades.FuncionSql.AgregarFuncionFiltroEntero(parametrolistado, "IdOcupacion", IdOcupacionListado));
        //                //personaNaturalListadoAD = Contexto.Database.SqlQuery<Sql.Modelo.PersonaNatural>(consulta.ToString(), parametrolistado.ToArray()).ToList();
        //            }
        //        }

        //        //Verificando registros activos
        //        switch (activo) {
        //            case Activo.Si:
        //                personaNaturalListadoAD = personaNaturalListadoAD.Where(a => a.EstaActivo == true).ToList();
        //                break;
        //            case Activo.No:
        //                personaNaturalListadoAD = personaNaturalListadoAD.Where(a => a.EstaActivo == false).ToList();
        //                break;
        //        }

        //        personaNaturalListado = personaNaturalListadoAD.Select(personaNatural => AutoMapeo.Mapeo(personaNatural, new Negocio.Entidades.Persona.PersonaNatural())).ToList();
        //    } catch (Exception ex) {
        //        //Parámetros
        //        List<Object> parametros = new List<Object>();
        //        //parametros.Add(ManejadorIdentidad.IdentidadActual != null ? ManejadorIdentidad.IdentidadActual.Name : "");
        //        criterioListado.ForEach(x => //parametros.Add(x));

        //        //RegistroEventoWindows.RegistroEventoFun.RegistroExcepcionAD(MensajeExcepcion.ErrorInesperado, "ObtenerListadoPersonaNaturalPorCriterio", RegistroEventoWindows.ExtraerTraza(ex), RegistroEventoWindows.ExtraerMensaje(ex), (ManejadorIdentidad.IdentidadActual != null ? ManejadorIdentidad.IdentidadActual.Name : null), parametros);
        //        throw;
        //    }

        //    //Resultado
        //    return personaNaturalListado;
        //}

        ///// <author>Jose Miguel Lopez Sevilla</author>
        ///// <creationdate>16-sep-2015</creationdate>
        ///// <summary>
        ///// Método para obtener un listado de objetos de tipo PersonaNatural.
        ///// en dependencia del criterio de filtrado.
        ///// </summary>
        ///// <param name="criterioListado">Listado de Tipo Opcion Usuario</param>
        ///// <param name="activo">Estado de los objetos de tipo PersonaNatural.</param>
        ///// <returns>Retorna listado de objetos PersonaNatural.</returns>
        //public List<Negocio.Entidades.Persona.PersonaNatural> ObtenerListadoPorCriterioDatosEmpleado(List<Negocio.Entidades.Persona.PersonaNatural> criterioListado, Activo activo) {
        //    //Declaraciones 
        //    List<SqlParameter> parametrolistado = new List<SqlParameter>();
        //    StringBuilder consulta = new StringBuilder();
        //    List<Sql.Modelo.PersonaNatural> personaNaturalListadoAD = new List<Sql.Modelo.PersonaNatural>();
        //    List<Negocio.Entidades.Persona.PersonaNatural> personaNaturalListado = new List<Negocio.Entidades.Persona.PersonaNatural>();

        //    String listadoCriterio = "";

        //    //Operaciones
        //    if (criterioListado == null) {
        //        throw new ArgumentNullException("criterioListado", MensajeExcepcion.ParametroEnNulo);
        //    }

        //    if (criterioListado.Count() <= 0) {
        //        throw new ArgumentException(MensajeExcepcion.ParametroListaVacia, "criterioListado");
        //    }

        //    if (!Enum.IsDefined(typeof(Activo), activo)) {
        //        throw new ArgumentOutOfRangeException("activo", MensajeExcepcion.EnumeracionValorInvalido);
        //    }

        //    try {
        //        //using (var Contexto = (AdministracionBDEntidades)ConfiguracionContexto.ObtenerContexto()) {
        //        using (var contexto = new ConfiguracionContexto().ObtenerContexto()) {
        //            //Verificando filtros             
        //            if (criterioListado.Where(x => x.IdPersonaNatural != 0).Count() > 0) {
        //                var idPersonaNaturalListado = criterioListado.Select(x => x.IdPersonaNatural).ToList();

        //                foreach (var item in idPersonaNaturalListado) {
        //                    listadoCriterio = listadoCriterio + item.ToString() + ",";
        //                }
        //                personaNaturalListadoAD = contexto.Database.SqlQuery<PersonaNatural>("Persona.prObtenerPersonaNaturalPorEmpleado @listadoCriterio, @tipoCriterio", new SqlParameter("@listadoCriterio", listadoCriterio), new SqlParameter("@tipoCriterio", "IdPersonaNatural")).ToList();
        //            }


        //            if (criterioListado.Any(x => String.IsNullOrEmpty(x.PrimerNombre) == false)) {
        //                var Nombre1Listado = criterioListado.Select(x => x.PrimerNombre).ToList();
        //                foreach (var item in Nombre1Listado) {
        //                    listadoCriterio = listadoCriterio + item.ToString() + ",";
        //                }
        //                personaNaturalListadoAD = contexto.Database.SqlQuery<PersonaNatural>("Persona.prObtenerPersonaNaturalPorEmpleado @listadoCriterio, @tipoCriterio", new SqlParameter("@listadoCriterio", listadoCriterio), new SqlParameter("@tipoCriterio", "Nombre1")).ToList();

        //            }

        //            if (criterioListado.Any(x => String.IsNullOrEmpty(x.SegundoNombre) == false)) {
        //                var Nombre2Listado = criterioListado.Select(x => x.SegundoNombre).ToList();
        //                foreach (var item in Nombre2Listado) {
        //                    listadoCriterio = listadoCriterio + item.ToString() + ",";
        //                }
        //                personaNaturalListadoAD = contexto.Database.SqlQuery<PersonaNatural>("Persona.prObtenerPersonaNaturalPorEmpleado @listadoCriterio, @tipoCriterio", new SqlParameter("@listadoCriterio", listadoCriterio), new SqlParameter("@tipoCriterio", "Nombre2")).ToList();

        //            }

        //            if (criterioListado.Any(x => String.IsNullOrEmpty(x.TercerNombre) == false)) {
        //                var Nombre3Listado = criterioListado.Select(x => x.TercerNombre).ToList();
        //                foreach (var item in Nombre3Listado) {
        //                    listadoCriterio = listadoCriterio + item.ToString() + ",";
        //                }
        //                personaNaturalListadoAD = contexto.Database.SqlQuery<PersonaNatural>("Persona.prObtenerPersonaNaturalPorEmpleado @listadoCriterio, @tipoCriterio", new SqlParameter("@listadoCriterio", listadoCriterio), new SqlParameter("@tipoCriterio", "Nombre3")).ToList();

        //            }

        //            if (criterioListado.Any(x => String.IsNullOrEmpty(x.CuartoNombre) == false)) {
        //                var Nombre4Listado = criterioListado.Select(x => x.CuartoNombre).ToList();
        //                foreach (var item in Nombre4Listado) {
        //                    listadoCriterio = listadoCriterio + item.ToString() + ",";
        //                }
        //                personaNaturalListadoAD = contexto.Database.SqlQuery<PersonaNatural>("Persona.prObtenerPersonaNaturalPorEmpleado @listadoCriterio, @tipoCriterio", new SqlParameter("@listadoCriterio", listadoCriterio), new SqlParameter("@tipoCriterio", "Nombre4")).ToList();

        //            }

        //            if (criterioListado.Any(x => String.IsNullOrEmpty(x.PrimerApellido) == false)) {
        //                var Apellido1Listado = criterioListado.Select(x => x.PrimerApellido).ToList();
        //                foreach (var item in Apellido1Listado) {
        //                    listadoCriterio = listadoCriterio + item.ToString() + ",";
        //                }
        //                personaNaturalListadoAD = contexto.Database.SqlQuery<PersonaNatural>("Persona.prObtenerPersonaNaturalPorEmpleado @listadoCriterio, @tipoCriterio", new SqlParameter("@listadoCriterio", listadoCriterio), new SqlParameter("@tipoCriterio", "Apellido1")).ToList();

        //            }

        //            if (criterioListado.Any(x => String.IsNullOrEmpty(x.SegundoApellido) == false)) {
        //                var Apellido2Listado = criterioListado.Select(x => x.SegundoApellido).ToList();
        //                foreach (var item in Apellido2Listado) {
        //                    listadoCriterio = listadoCriterio + item.ToString() + ",";
        //                }
        //                personaNaturalListadoAD = contexto.Database.SqlQuery<PersonaNatural>("Persona.prObtenerPersonaNaturalPorEmpleado @listadoCriterio, @tipoCriterio", new SqlParameter("@listadoCriterio", listadoCriterio), new SqlParameter("@tipoCriterio", "Apellido2")).ToList();

        //            }

        //            if (criterioListado.Any(x => String.IsNullOrEmpty(x.NombreCompleto) == false)) {
        //                var NombreCompletoListado = criterioListado.Select(x => x.NombreCompleto).ToList();
        //                foreach (var item in NombreCompletoListado) {
        //                    listadoCriterio = listadoCriterio + item.ToString() + ",";
        //                }
        //                personaNaturalListadoAD = contexto.Database.SqlQuery<PersonaNatural>("Persona.prObtenerPersonaNaturalPorEmpleado @listadoCriterio, @tipoCriterio", new SqlParameter("@listadoCriterio", listadoCriterio), new SqlParameter("@tipoCriterio", "NombreCompleto")).ToList();

        //            }

        //            if (criterioListado.Any(x => String.IsNullOrEmpty(x.ConocidoComo) == false)) {
        //                var ConocidoComoListado = criterioListado.Select(x => x.ConocidoComo).ToList();
        //                foreach (var item in ConocidoComoListado) {
        //                    listadoCriterio = listadoCriterio + item.ToString() + ",";
        //                }
        //                personaNaturalListadoAD = contexto.Database.SqlQuery<PersonaNatural>("Persona.prObtenerPersonaNaturalPorEmpleado @listadoCriterio, @tipoCriterio", new SqlParameter("@listadoCriterio", listadoCriterio), new SqlParameter("@tipoCriterio", "ConocidoComo")).ToList();

        //            }

        //            if (criterioListado.Any(x => x.Persona != null && x.Persona.IdPersona != 0)) {
        //                var IdPersonaListado = criterioListado.Select(x => x.Persona.IdPersona).ToList();
        //                foreach (var item in IdPersonaListado) {
        //                    listadoCriterio = listadoCriterio + item.ToString() + ",";
        //                }
        //                personaNaturalListadoAD = contexto.Database.SqlQuery<PersonaNatural>("Persona.prObtenerPersonaNaturalPorEmpleado @listadoCriterio, @tipoCriterio", new SqlParameter("@listadoCriterio", listadoCriterio), new SqlParameter("@tipoCriterio", "IdPersona")).ToList();

        //            }

        //            if (criterioListado.Any(x => x.Genero != null && x.Genero.IdValor != 0)) {
        //                var IdGeneroListado = criterioListado.Select(x => x.Genero.IdValor).ToList();
        //                foreach (var item in IdGeneroListado) {
        //                    listadoCriterio = listadoCriterio + item.ToString() + ",";
        //                }
        //                personaNaturalListadoAD = contexto.Database.SqlQuery<PersonaNatural>("Persona.prObtenerPersonaNaturalPorEmpleado @listadoCriterio, @tipoCriterio", new SqlParameter("@listadoCriterio", listadoCriterio), new SqlParameter("@tipoCriterio", "IdGenero")).ToList();

        //            }

        //            if (criterioListado.Any(x => x.EstadoCivil != null && x.EstadoCivil.IdValor != 0)) {
        //                var IdEstadoCivilListado = criterioListado.Select(x => x.EstadoCivil.IdValor).ToList();
        //                foreach (var item in IdEstadoCivilListado) {
        //                    listadoCriterio = listadoCriterio + item.ToString() + ",";
        //                }
        //                personaNaturalListadoAD = contexto.Database.SqlQuery<PersonaNatural>("Persona.prObtenerPersonaNaturalPorEmpleado @listadoCriterio, @tipoCriterio", new SqlParameter("@listadoCriterio", listadoCriterio), new SqlParameter("@tipoCriterio", "IdEstadoCivil")).ToList();

        //            }

        //            if (criterioListado.Any(x => x.Ocupacion != null && x.Ocupacion.IdValor != 0)) {
        //                var IdOcupacionListado = criterioListado.Select(x => x.Ocupacion.IdValor).ToList();
        //                foreach (var item in IdOcupacionListado) {
        //                    listadoCriterio = listadoCriterio + item.ToString() + ",";
        //                }
        //                personaNaturalListadoAD = contexto.Database.SqlQuery<PersonaNatural>("Persona.prObtenerPersonaNaturalPorEmpleado @listadoCriterio, @tipoCriterio", new SqlParameter("@listadoCriterio", listadoCriterio), new SqlParameter("@tipoCriterio", "IdOcupacion")).ToList();

        //            }
        //        }
        //        //Verificando registros activos
        //        switch (activo) {
        //            case Activo.Si:
        //                personaNaturalListadoAD = personaNaturalListadoAD.Where(a => a.EstaActivo == true).ToList();
        //                break;
        //            case Activo.No:
        //                personaNaturalListadoAD = personaNaturalListadoAD.Where(a => a.EstaActivo == false).ToList();
        //                break;
        //        }

        //        personaNaturalListado = personaNaturalListadoAD.ToList().Select(personaNatural => AutoMapeo.Mapeo(personaNatural, new Negocio.Entidades.Persona.PersonaNatural())).ToList();
        //        //}
        //    } catch (Exception ex) {
        //        //Parámetros
        //        List<Object> parametros = new List<Object>();
        //        //parametros.Add(ManejadorIdentidad.IdentidadActual != null ? ManejadorIdentidad.IdentidadActual.Name : "");
        //        criterioListado.ForEach(x => //parametros.Add(x));
        //        //parametros.Add(activo);

        //        //RegistroEventoWindows.RegistroEventoFun.RegistroExcepcionAD(MensajeExcepcion.ErrorInesperado, "ObtenerListadoPorCriterioDatosEmpleado", RegistroEventoWindows.ExtraerTraza(ex), RegistroEventoWindows.ExtraerMensaje(ex), (ManejadorIdentidad.IdentidadActual != null ? ManejadorIdentidad.IdentidadActual.Name : null), parametros);
        //        throw;
        //    }

        //    //Resultado
        //    return personaNaturalListado;
        //}

        ///// <author>Ernesto Medrano</author>
        ///// <creationdate>16-sep-2015</creationdate>
        ///// <summary>
        ///// Método para obtener un listado de objetos de tipo PersonaNatural en dependencia del criterio de filtrado.
        ///// </summary>
        ///// <param name="idPersona">Comentario</param>
        ///// <param name="activo">Comentario</param>
        ///// <returns></returns>
        //public List<Negocio.Entidades.Persona.PersonaNatural> ObtenerListadoPersonaNaturalPorPersona(Int32 idPersona, Activo activo) {
        //    //Declaraciones
        //    List<Negocio.Entidades.Persona.PersonaNatural> personaNaturalListado = new List<Negocio.Entidades.Persona.PersonaNatural>();
        //    Negocio.Entidades.Persona.PersonaNatural personaNatural;
        //    List<SqlParameter> parametrolistado = new List<SqlParameter>();
        //    StringBuilder consulta = new StringBuilder();
        //    List<Sql.Modelo.PersonaNatural> personaNaturalListadoAD = new List<Sql.Modelo.PersonaNatural>();
        //    String listadoCriterio = "";

        //    // Operaciones
        //    try {
        //        using (var contexto = new ConfiguracionContexto().ObtenerContexto()) {
        //            personaNatural = new Negocio.Entidades.Persona.PersonaNatural() { Persona = new Negocio.Entidades.Persona.Persona() { IdPersona = idPersona } };
        //            personaNaturalListado.Add(personaNatural);

        //            if (personaNaturalListado.Any(x => x.Persona != null && x.Persona.IdPersona != 0)) {
        //                var IdPersonaListado = personaNaturalListado.Select(x => x.Persona.IdPersona).ToList();
        //                foreach (var item in IdPersonaListado) {
        //                    listadoCriterio = listadoCriterio + item.ToString() + ",";
        //                }
        //                personaNaturalListadoAD = contexto.Database.SqlQuery<PersonaNatural>("Persona.prObtenerPersonaNatural @listadoCriterio, @tipoCriterio", new SqlParameter("@listadoCriterio", listadoCriterio), new SqlParameter("@tipoCriterio", "IdPersona")).ToList();
        //            }
        //        }

        //        //Verificando registros activos
        //        switch (activo) {
        //            case Activo.Si:
        //                personaNaturalListadoAD = personaNaturalListadoAD.Where(a => a.EstaActivo == true).ToList();
        //                break;
        //            case Activo.No:
        //                personaNaturalListadoAD = personaNaturalListadoAD.Where(a => a.EstaActivo == false).ToList();
        //                break;
        //        }

        //        personaNaturalListado = personaNaturalListadoAD.Select(personasNatural => AutoMapeo.Mapeo(personasNatural, new Negocio.Entidades.Persona.PersonaNatural())).ToList();
        //        //}
        //    } catch (Exception ex) {
        //        //Parámetros
        //        List<Object> parametros = new List<Object>();
        //        //parametros.Add(ManejadorIdentidad.IdentidadActual != null ? ManejadorIdentidad.IdentidadActual.Name : "");                
        //        //parametros.Add(idPersona);
        //        //parametros.Add(activo);

        //        //RegistroEventoWindows.RegistroEventoFun.RegistroExcepcionAD(MensajeExcepcion.ErrorInesperado, "ObtenerListadoPersonaNaturalPorPersona", RegistroEventoWindows.ExtraerTraza(ex), RegistroEventoWindows.ExtraerMensaje(ex), (ManejadorIdentidad.IdentidadActual != null ? ManejadorIdentidad.IdentidadActual.Name : null), parametros);
        //        throw;
        //    }

        //    // Resultado
        //    return personaNaturalListado;
        //}

        ///// <author>Ernesto Medrano</author>
        ///// <creationdate>16-sep-2015</creationdate>
        ///// <summary>
        ///// Método para obtener un listado de objetos de tipo PersonaNatural en dependencia del criterio de filtrado.
        ///// </summary>
        ///// <param name="idPersonaListado">Comentario</param>
        ///// <param name="activo">Comentario</param>
        ///// <returns></returns>
        //public List<Negocio.Entidades.Persona.PersonaNatural> ObtenerListadoPersonaNaturalPorPersona(List<Int32> idPersonaListado, Activo activo) {
        //    //Declaraciones
        //    List<Negocio.Entidades.Persona.PersonaNatural> personaNaturalListado = new List<Negocio.Entidades.Persona.PersonaNatural>();
        //    List<SqlParameter> parametrolistado = new List<SqlParameter>();
        //    StringBuilder consulta = new StringBuilder();
        //    List<Sql.Modelo.PersonaNatural> personaNaturalListadoAD = new List<Sql.Modelo.PersonaNatural>();
        //    String listadoCriterio = "";

        //    // Operaciones
        //    try {
        //        using (var contexto = new ConfiguracionContexto().ObtenerContexto()) {
        //            personaNaturalListado.AddRange(idPersonaListado.
        //                Select(x => new Negocio.Entidades.Persona.PersonaNatural() {
        //                    Persona = new Negocio.Entidades.Persona.Persona() {
        //                        IdPersona = x
        //                    }
        //                }).ToList());

        //            // Resultado            
        //            if (personaNaturalListado.Any(x => x.Persona != null && x.Persona.IdPersona != 0)) {
        //                var IdPersonaListado = personaNaturalListado.Select(x => x.Persona.IdPersona).ToList();
        //                foreach (var item in IdPersonaListado) {
        //                    listadoCriterio = listadoCriterio + item.ToString() + ",";
        //                }
        //                personaNaturalListadoAD = contexto.Database.SqlQuery<PersonaNatural>("Persona.prObtenerPersonaNatural @listadoCriterio, @tipoCriterio", new SqlParameter("@listadoCriterio", listadoCriterio), new SqlParameter("@tipoCriterio", "IdPersona")).ToList();
        //            }
        //        }

        //        //Verificando registros activos
        //        switch (activo) {
        //            case Activo.Si:
        //                personaNaturalListadoAD = personaNaturalListadoAD.Where(a => a.EstaActivo == true).ToList();
        //                break;
        //            case Activo.No:
        //                personaNaturalListadoAD = personaNaturalListadoAD.Where(a => a.EstaActivo == false).ToList();
        //                break;
        //        }

        //        personaNaturalListado = personaNaturalListadoAD.Select(personasNatural => AutoMapeo.Mapeo(personasNatural, new Negocio.Entidades.Persona.PersonaNatural())).ToList();
        //        //}
        //    } catch (Exception ex) {
        //        //Parámetros
        //        List<Object> parametros = new List<Object>();
        //        //parametros.Add(ManejadorIdentidad.IdentidadActual != null ? ManejadorIdentidad.IdentidadActual.Name : "");
        //        idPersonaListado.ForEach(x => //parametros.Add(x));                
        //        //parametros.Add(activo);

        //        //RegistroEventoWindows.RegistroEventoFun.RegistroExcepcionAD(MensajeExcepcion.ErrorInesperado, "ObtenerListadoPersonaNaturalPorPersona", RegistroEventoWindows.ExtraerTraza(ex), RegistroEventoWindows.ExtraerMensaje(ex), (ManejadorIdentidad.IdentidadActual != null ? ManejadorIdentidad.IdentidadActual.Name : null), parametros);
        //        throw;
        //    }

        //    return personaNaturalListado;
        //}

        ///// <author>Ernesto Medrano</author>
        ///// <creationdate>16-sep-2015</creationdate>
        ///// <summary>
        ///// Método para obtener un listado de objetos de tipo PersonaNatural en dependencia del criterio de filtrado.
        ///// </summary>
        ///// <param name="idGenero">Comentario</param>
        ///// <param name="activo">Comentario</param>
        ///// <returns></returns>
        //public List<Negocio.Entidades.Persona.PersonaNatural> ObtenerListadoPersonaNaturalPorGenero(Int32 idGenero, Activo activo) {
        //    //Declaraciones
        //    List<Negocio.Entidades.Persona.PersonaNatural> personaNaturalListado = new List<Negocio.Entidades.Persona.PersonaNatural>();
        //    Negocio.Entidades.Persona.PersonaNatural personaNatural;
        //    List<SqlParameter> parametrolistado = new List<SqlParameter>();
        //    StringBuilder consulta = new StringBuilder();
        //    List<Sql.Modelo.PersonaNatural> personaNaturalListadoAD = new List<Sql.Modelo.PersonaNatural>();
        //    String listadoCriterio = "";

        //    // Operaciones
        //    try {
        //        using (var contexto = new ConfiguracionContexto().ObtenerContexto()) {
        //            personaNatural = new Negocio.Entidades.Persona.PersonaNatural() { Genero = new Negocio.Entidades.TablaBasica.Valor() { IdValor = idGenero } };

        //            personaNaturalListado.Add(personaNatural);

        //            if (personaNaturalListado.Any(x => x.Genero != null && x.Genero.IdValor != 0)) {
        //                var IdGeneroListado = personaNaturalListado.Select(x => x.Genero.IdValor).ToList();
        //                foreach (var item in IdGeneroListado) {
        //                    listadoCriterio = listadoCriterio + item.ToString() + ",";
        //                }
        //                personaNaturalListadoAD = contexto.Database.SqlQuery<PersonaNatural>("Persona.prObtenerPersonaNatural @listadoCriterio, @tipoCriterio", new SqlParameter("@listadoCriterio", listadoCriterio), new SqlParameter("@tipoCriterio", "IdGenero")).ToList();
        //            }
        //        }

        //        //Verificando registros activos
        //        switch (activo) {
        //            case Activo.Si:
        //                personaNaturalListadoAD = personaNaturalListadoAD.Where(a => a.EstaActivo == true).ToList();
        //                break;
        //            case Activo.No:
        //                personaNaturalListadoAD = personaNaturalListadoAD.Where(a => a.EstaActivo == false).ToList();
        //                break;
        //        }

        //        personaNaturalListado = personaNaturalListadoAD.Select(personasNatural => AutoMapeo.Mapeo(personasNatural, new Negocio.Entidades.Persona.PersonaNatural())).ToList();
        //        //}
        //    } catch (Exception ex) {
        //        //Parámetros
        //        List<Object> parametros = new List<Object>();
        //        //parametros.Add(ManejadorIdentidad.IdentidadActual != null ? ManejadorIdentidad.IdentidadActual.Name : "");                
        //        //parametros.Add(idGenero);
        //        //parametros.Add(activo);

        //        //RegistroEventoWindows.RegistroEventoFun.RegistroExcepcionAD(MensajeExcepcion.ErrorInesperado, "ObtenerListadoPersonaNaturalPorGenero", RegistroEventoWindows.ExtraerTraza(ex), RegistroEventoWindows.ExtraerMensaje(ex), (ManejadorIdentidad.IdentidadActual != null ? ManejadorIdentidad.IdentidadActual.Name : null), parametros);
        //        throw;
        //    }

        //    // Resultado
        //    return personaNaturalListado;
        //}

        ///// <author>Ernesto Medrano</author>
        ///// <creationdate>16-sep-2015</creationdate>
        ///// <summary>
        ///// Método para obtener un listado de objetos de tipo PersonaNatural en dependencia del criterio de filtrado.
        ///// </summary>
        ///// <param name="idGeneroListado">Comentario</param>
        ///// <param name="activo">Comentario</param>
        ///// <returns></returns>
        //public List<Negocio.Entidades.Persona.PersonaNatural> ObtenerListadoPersonaNaturalPorGenero(List<Int32> idGeneroListado, Activo activo) {
        //    //Declaraciones
        //    List<Negocio.Entidades.Persona.PersonaNatural> personaNaturalListado = new List<Negocio.Entidades.Persona.PersonaNatural>();
        //    List<SqlParameter> parametrolistado = new List<SqlParameter>();
        //    StringBuilder consulta = new StringBuilder();
        //    List<Sql.Modelo.PersonaNatural> personaNaturalListadoAD = new List<Sql.Modelo.PersonaNatural>();
        //    String listadoCriterio = "";

        //    // Operaciones
        //    try {
        //        using (var contexto = new ConfiguracionContexto().ObtenerContexto()) {
        //            personaNaturalListado.AddRange(idGeneroListado.
        //                Select(x => new Negocio.Entidades.Persona.PersonaNatural() {
        //                    Genero = new Negocio.Entidades.TablaBasica.Valor() {
        //                        IdValor = x
        //                    }
        //                }).ToList());

        //            // Resultado           
        //            if (personaNaturalListado.Any(x => x.Genero != null && x.Genero.IdValor != 0)) {
        //                var IdGeneroListado = personaNaturalListado.Select(x => x.Genero.IdValor).ToList();
        //                foreach (var item in IdGeneroListado) {
        //                    listadoCriterio = listadoCriterio + item.ToString() + ",";
        //                }
        //                personaNaturalListadoAD = contexto.Database.SqlQuery<PersonaNatural>("Persona.prObtenerPersonaNatural @listadoCriterio, @tipoCriterio", new SqlParameter("@listadoCriterio", listadoCriterio), new SqlParameter("@tipoCriterio", "IdGenero")).ToList();
        //            }
        //        }

        //        //Verificando registros activos
        //        switch (activo) {
        //            case Activo.Si:
        //                personaNaturalListadoAD = personaNaturalListadoAD.Where(a => a.EstaActivo == true).ToList();
        //                break;
        //            case Activo.No:
        //                personaNaturalListadoAD = personaNaturalListadoAD.Where(a => a.EstaActivo == false).ToList();
        //                break;
        //        }

        //        personaNaturalListado = personaNaturalListadoAD.Select(personasNatural => AutoMapeo.Mapeo(personasNatural, new Negocio.Entidades.Persona.PersonaNatural())).ToList();
        //        //}
        //    } catch (Exception ex) {
        //        //Parámetros
        //        List<Object> parametros = new List<Object>();
        //        //parametros.Add(ManejadorIdentidad.IdentidadActual != null ? ManejadorIdentidad.IdentidadActual.Name : "");
        //        idGeneroListado.ForEach(x => //parametros.Add(x));                
        //        //parametros.Add(activo);

        //        //RegistroEventoWindows.RegistroEventoFun.RegistroExcepcionAD(MensajeExcepcion.ErrorInesperado, "ObtenerListadoPersonaNaturalPorGenero", RegistroEventoWindows.ExtraerTraza(ex), RegistroEventoWindows.ExtraerMensaje(ex), (ManejadorIdentidad.IdentidadActual != null ? ManejadorIdentidad.IdentidadActual.Name : null), parametros);
        //        throw;
        //    }

        //    return personaNaturalListado;
        //}

        ///// <author>Ernesto Medrano</author>
        ///// <creationdate>16-sep-2015</creationdate>
        ///// <summary>
        ///// Método para obtener un listado de objetos de tipo PersonaNatural en dependencia del criterio de filtrado.
        ///// </summary>
        ///// <param name="idEstadoCivil">Comentario</param>
        ///// <param name="activo">Comentario</param>
        ///// <returns></returns>
        //public List<Negocio.Entidades.Persona.PersonaNatural> ObtenerListadoPersonaNaturalPorEstadoCivil(Int32 idEstadoCivil, Activo activo) {
        //    //Declaraciones
        //    List<Negocio.Entidades.Persona.PersonaNatural> personaNaturalListado = new List<Negocio.Entidades.Persona.PersonaNatural>();
        //    Negocio.Entidades.Persona.PersonaNatural personaNatural;
        //    List<SqlParameter> parametrolistado = new List<SqlParameter>();
        //    StringBuilder consulta = new StringBuilder();
        //    List<Sql.Modelo.PersonaNatural> personaNaturalListadoAD = new List<Sql.Modelo.PersonaNatural>();
        //    String listadoCriterio = "";

        //    // Operaciones
        //    try {
        //        using (var contexto = new ConfiguracionContexto().ObtenerContexto()) {
        //            personaNatural = new Negocio.Entidades.Persona.PersonaNatural() { EstadoCivil = new Negocio.Entidades.TablaBasica.Valor() { IdValor = idEstadoCivil } };

        //            personaNaturalListado.Add(personaNatural);

        //            // Resultado            
        //            if (personaNaturalListado.Any(x => x.EstadoCivil != null && x.EstadoCivil.IdValor != 0)) {
        //                var IdEstadoCivilListado = personaNaturalListado.Select(x => x.EstadoCivil.IdValor).ToList();
        //                foreach (var item in IdEstadoCivilListado) {
        //                    listadoCriterio = listadoCriterio + item.ToString() + ",";
        //                }
        //                personaNaturalListadoAD = contexto.Database.SqlQuery<PersonaNatural>("Persona.prObtenerPersonaNatural @listadoCriterio, @tipoCriterio", new SqlParameter("@listadoCriterio", listadoCriterio), new SqlParameter("@tipoCriterio", "IdEstadoCivil")).ToList();
        //            }
        //        }
        //        //Verificando registros activos
        //        switch (activo) {
        //            case Activo.Si:
        //                personaNaturalListadoAD = personaNaturalListadoAD.Where(a => a.EstaActivo == true).ToList();
        //                break;
        //            case Activo.No:
        //                personaNaturalListadoAD = personaNaturalListadoAD.Where(a => a.EstaActivo == false).ToList();
        //                break;
        //        }

        //        personaNaturalListado = personaNaturalListadoAD.Select(personasNatural => AutoMapeo.Mapeo(personasNatural, new Negocio.Entidades.Persona.PersonaNatural())).ToList();
        //        //}
        //    } catch (Exception ex) {
        //        //Parámetros
        //        List<Object> parametros = new List<Object>();
        //        //parametros.Add(ManejadorIdentidad.IdentidadActual != null ? ManejadorIdentidad.IdentidadActual.Name : "");                
        //        //parametros.Add(idEstadoCivil);
        //        //parametros.Add(activo);

        //        //RegistroEventoWindows.RegistroEventoFun.RegistroExcepcionAD(MensajeExcepcion.ErrorInesperado, "ObtenerListadoPersonaNaturalPorEstadoCivil", RegistroEventoWindows.ExtraerTraza(ex), RegistroEventoWindows.ExtraerMensaje(ex), (ManejadorIdentidad.IdentidadActual != null ? ManejadorIdentidad.IdentidadActual.Name : null), parametros);
        //        throw;
        //    }

        //    return personaNaturalListado;
        //}

        ///// <author>Ernesto Medrano</author>
        ///// <creationdate>16-sep-2015</creationdate>
        ///// <summary>
        ///// Método para obtener un listado de objetos de tipo PersonaNatural en dependencia del criterio de filtrado.
        ///// </summary>
        ///// <param name="idEstadoCivilListado">Comentario</param>
        ///// <param name="activo">Comentario</param>
        ///// <returns></returns>
        //public List<Negocio.Entidades.Persona.PersonaNatural> ObtenerListadoPersonaNaturalPorEstadoCivil(List<Int32> idEstadoCivilListado, Activo activo) {
        //    //Declaraciones
        //    List<Negocio.Entidades.Persona.PersonaNatural> personaNaturalListado = new List<Negocio.Entidades.Persona.PersonaNatural>();
        //    List<SqlParameter> parametrolistado = new List<SqlParameter>();
        //    StringBuilder consulta = new StringBuilder();
        //    List<Sql.Modelo.PersonaNatural> personaNaturalListadoAD = new List<Sql.Modelo.PersonaNatural>();
        //    String listadoCriterio = "";

        //    // Operaciones
        //    try {
        //        using (var contexto = new ConfiguracionContexto().ObtenerContexto()) {
        //            personaNaturalListado.AddRange(idEstadoCivilListado.
        //                Select(x => new Negocio.Entidades.Persona.PersonaNatural() {
        //                    EstadoCivil = new Negocio.Entidades.TablaBasica.Valor() {
        //                        IdValor = x
        //                    }
        //                }).ToList());


        //            // Resultado            
        //            if (personaNaturalListado.Any(x => x.EstadoCivil != null && x.EstadoCivil.IdValor != 0)) {
        //                var IdEstadoCivilListado = personaNaturalListado.Select(x => x.EstadoCivil.IdValor).ToList();
        //                foreach (var item in IdEstadoCivilListado) {
        //                    listadoCriterio = listadoCriterio + item.ToString() + ",";
        //                }
        //                personaNaturalListadoAD = contexto.Database.SqlQuery<PersonaNatural>("Persona.prObtenerPersonaNatural @listadoCriterio, @tipoCriterio", new SqlParameter("@listadoCriterio", listadoCriterio), new SqlParameter("@tipoCriterio", "IdEstadoCivil")).ToList();

        //            }
        //        }
        //        //Verificando registros activos
        //        switch (activo) {
        //            case Activo.Si:
        //                personaNaturalListadoAD = personaNaturalListadoAD.Where(a => a.EstaActivo == true).ToList();
        //                break;
        //            case Activo.No:
        //                personaNaturalListadoAD = personaNaturalListadoAD.Where(a => a.EstaActivo == false).ToList();
        //                break;
        //        }

        //        personaNaturalListado = personaNaturalListadoAD.Select(personasNatural => AutoMapeo.Mapeo(personasNatural, new Negocio.Entidades.Persona.PersonaNatural())).ToList();
        //        //}
        //    } catch (Exception ex) {
        //        //Parámetros
        //        List<Object> parametros = new List<Object>();
        //        //parametros.Add(ManejadorIdentidad.IdentidadActual != null ? ManejadorIdentidad.IdentidadActual.Name : "");
        //        idEstadoCivilListado.ForEach(x => //parametros.Add(x));                
        //        //parametros.Add(activo);

        //        //RegistroEventoWindows.RegistroEventoFun.RegistroExcepcionAD(MensajeExcepcion.ErrorInesperado, "ObtenerListadoPersonaNaturalPorEstadoCivil", RegistroEventoWindows.ExtraerTraza(ex), RegistroEventoWindows.ExtraerMensaje(ex), (ManejadorIdentidad.IdentidadActual != null ? ManejadorIdentidad.IdentidadActual.Name : null), parametros);
        //        throw;
        //    }

        //    return personaNaturalListado;
        //}

        ///// <author>Ernesto Medrano</author>
        ///// <creationdate>16-sep-2015</creationdate>
        ///// <summary>
        ///// Método para obtener un listado de objetos de tipo PersonaNatural en dependencia del criterio de filtrado.
        ///// </summary>
        ///// <param name="idOcupacion">Comentario</param>
        ///// <param name="activo">Comentario</param>
        ///// <returns></returns>
        //public List<Negocio.Entidades.Persona.PersonaNatural> ObtenerListadoPersonaNaturalPorOcupacion(Int32 idOcupacion, Activo activo) {
        //    //Declaraciones
        //    List<Negocio.Entidades.Persona.PersonaNatural> personaNaturalListado = new List<Negocio.Entidades.Persona.PersonaNatural>();
        //    Negocio.Entidades.Persona.PersonaNatural personaNatural;
        //    List<SqlParameter> parametrolistado = new List<SqlParameter>();
        //    StringBuilder consulta = new StringBuilder();
        //    List<Sql.Modelo.PersonaNatural> personaNaturalListadoAD = new List<Sql.Modelo.PersonaNatural>();
        //    String listadoCriterio = "";

        //    // Operaciones
        //    try {
        //        using (var contexto = new ConfiguracionContexto().ObtenerContexto()) {
        //            personaNatural = new Negocio.Entidades.Persona.PersonaNatural() { Ocupacion = new Negocio.Entidades.TablaBasica.Valor() { IdValor = idOcupacion } };

        //            personaNaturalListado.Add(personaNatural);

        //            // Resultado            
        //            if (personaNaturalListado.Any(x => x.Ocupacion != null && x.Ocupacion.IdValor != 0)) {
        //                var IdOcupacionListado = personaNaturalListado.Select(x => x.Ocupacion.IdValor).ToList();
        //                foreach (var item in IdOcupacionListado) {
        //                    listadoCriterio = listadoCriterio + item.ToString() + ",";
        //                }
        //                personaNaturalListadoAD = contexto.Database.SqlQuery<PersonaNatural>("Persona.prObtenerPersonaNatural @listadoCriterio, @tipoCriterio", new SqlParameter("@listadoCriterio", listadoCriterio), new SqlParameter("@tipoCriterio", "IdOcupacion")).ToList();
        //            }
        //        }

        //        //Verificando registros activos
        //        switch (activo) {
        //            case Activo.Si:
        //                personaNaturalListadoAD = personaNaturalListadoAD.Where(a => a.EstaActivo == true).ToList();
        //                break;
        //            case Activo.No:
        //                personaNaturalListadoAD = personaNaturalListadoAD.Where(a => a.EstaActivo == false).ToList();
        //                break;
        //        }

        //        personaNaturalListado = personaNaturalListadoAD.Select(personasNatural => AutoMapeo.Mapeo(personasNatural, new Negocio.Entidades.Persona.PersonaNatural())).ToList();
        //        //}
        //    } catch (Exception ex) {
        //        //Parámetros
        //        List<Object> parametros = new List<Object>();
        //        //parametros.Add(ManejadorIdentidad.IdentidadActual != null ? ManejadorIdentidad.IdentidadActual.Name : "");                
        //        //parametros.Add(idOcupacion);
        //        //parametros.Add(activo);

        //        //RegistroEventoWindows.RegistroEventoFun.RegistroExcepcionAD(MensajeExcepcion.ErrorInesperado, "ObtenerListadoPersonaNaturalPorOcupacion", RegistroEventoWindows.ExtraerTraza(ex), RegistroEventoWindows.ExtraerMensaje(ex), (ManejadorIdentidad.IdentidadActual != null ? ManejadorIdentidad.IdentidadActual.Name : null), parametros);
        //        throw;
        //    }

        //    return personaNaturalListado;
        //}

        ///// <author>Ernesto Medrano</author>
        ///// <creationdate>16-sep-2015</creationdate>
        ///// <summary>
        ///// Método para obtener un listado de objetos de tipo PersonaNatural en dependencia del criterio de filtrado.
        ///// </summary>
        ///// <param name="idOcupacionListado">Comentario</param>
        ///// <param name="activo">Comentario</param>
        ///// <returns></returns>
        //public List<Negocio.Entidades.Persona.PersonaNatural> ObtenerListadoPersonaNaturalPorOcupacion(List<Int32> idOcupacionListado, Activo activo) {
        //    //Declaraciones
        //    List<Negocio.Entidades.Persona.PersonaNatural> personaNaturalListado = new List<Negocio.Entidades.Persona.PersonaNatural>();
        //    List<SqlParameter> parametrolistado = new List<SqlParameter>();
        //    StringBuilder consulta = new StringBuilder();
        //    List<Sql.Modelo.PersonaNatural> personaNaturalListadoAD = new List<Sql.Modelo.PersonaNatural>();
        //    String listadoCriterio = "";

        //    // Operaciones
        //    try {
        //        using (var contexto = new ConfiguracionContexto().ObtenerContexto()) {
        //            personaNaturalListado.AddRange(idOcupacionListado.
        //                Select(x => new Negocio.Entidades.Persona.PersonaNatural() {
        //                    Ocupacion = new Negocio.Entidades.TablaBasica.Valor() {
        //                        IdValor = x
        //                    }
        //                }).ToList());

        //            // Resultado            
        //            if (personaNaturalListado.Any(x => x.Ocupacion != null && x.Ocupacion.IdValor != 0)) {
        //                var IdOcupacionListado = personaNaturalListado.Select(x => x.Ocupacion.IdValor).ToList();
        //                foreach (var item in IdOcupacionListado) {
        //                    listadoCriterio = listadoCriterio + item.ToString() + ",";
        //                }
        //                personaNaturalListadoAD = contexto.Database.SqlQuery<PersonaNatural>("Persona.prObtenerPersonaNatural @listadoCriterio, @tipoCriterio", new SqlParameter("@listadoCriterio", listadoCriterio), new SqlParameter("@tipoCriterio", "IdOcupacion")).ToList();
        //            }
        //        }

        //        //Verificando registros activos
        //        switch (activo) {
        //            case Activo.Si:
        //                personaNaturalListadoAD = personaNaturalListadoAD.Where(a => a.EstaActivo == true).ToList();
        //                break;
        //            case Activo.No:
        //                personaNaturalListadoAD = personaNaturalListadoAD.Where(a => a.EstaActivo == false).ToList();
        //                break;
        //        }

        //        personaNaturalListado = personaNaturalListadoAD.Select(personasNatural => AutoMapeo.Mapeo(personasNatural, new Negocio.Entidades.Persona.PersonaNatural())).ToList();
        //        //}
        //    } catch (Exception ex) {
        //        //Parámetros
        //        List<Object> parametros = new List<Object>();
        //        //parametros.Add(ManejadorIdentidad.IdentidadActual != null ? ManejadorIdentidad.IdentidadActual.Name : "");
        //        idOcupacionListado.ForEach(x => //parametros.Add(x));                
        //        //parametros.Add(activo);

        //        //RegistroEventoWindows.RegistroEventoFun.RegistroExcepcionAD(MensajeExcepcion.ErrorInesperado, "ObtenerListadoPersonaNaturalPorOcupacion", RegistroEventoWindows.ExtraerTraza(ex), RegistroEventoWindows.ExtraerMensaje(ex), (ManejadorIdentidad.IdentidadActual != null ? ManejadorIdentidad.IdentidadActual.Name : null), parametros);
        //        throw;
        //    }

        //    return personaNaturalListado;
        //}

        ///// <author>Mario Gomez</author>
        ///// <creationdate>01-Ago-2016</creationdate>
        ///// <summary>
        ///// Obtiene los datos para cargarlos en el arbol de buzon.
        ///// </summary>
        ///// <param name="idCuenta"></param>
        ///// <returns></returns>
        //public List<Negocio.Entidades.Persona.VistasEstructuras.EstructuraPersonaNatural> ObtenerEstructuraPersonaNatural(Int32 inicio, Int32 fin, Int32 filtro, Int32 ubicacion, Int32 idpersonanatural, out String cantidad, out String lotes) {
        //    List<EstructuraPersonaNatural> estructura = new List<EstructuraPersonaNatural>();
        //    lotes = "0";
        //    cantidad = "0";

        //    try {
        //        using (var contexto = new ConfiguracionContexto().ObtenerContexto()) {
        //            estructura = contexto.Database.SqlQuery<EstructuraPersonaNatural>("Persona.prObtenerEstructuraPersona @Inicio,@Fin,@filtro,@idUbicacion,@idpersonanatural"
        //                , new SqlParameter("@Inicio", inicio)
        //                , new SqlParameter("@Fin", fin)
        //                , new SqlParameter("@filtro", filtro)
        //                , new SqlParameter("@idUbicacion", ubicacion)
        //                , new SqlParameter("@idpersonanatural", idpersonanatural)

        //                ).ToList();
        //        }
        //    } catch (Exception ex) {
        //        //Parámetros
        //        List<Object> parametros = new List<Object>();
        //        //parametros.Add(ManejadorIdentidad.IdentidadActual != null ? ManejadorIdentidad.IdentidadActual.Name : "");                
        //        //parametros.Add(inicio);
        //        //parametros.Add(fin);
        //        //parametros.Add(filtro);
        //        //parametros.Add(ubicacion);
        //        //parametros.Add(idpersonanatural);

        //        //RegistroEventoWindows.RegistroEventoFun.RegistroExcepcionAD(MensajeExcepcion.ErrorInesperado, "ObtenerEstructuraPersonaNatural", RegistroEventoWindows.ExtraerTraza(ex), RegistroEventoWindows.ExtraerMensaje(ex), (ManejadorIdentidad.IdentidadActual != null ? ManejadorIdentidad.IdentidadActual.Name : null), parametros);
        //        throw;
        //    }

        //    //lotes = (Contexto.PersonaNaturales.OrderByDescending(pernat => pernat.IdPersonaNatural).FirstOrDefault().IdPersonaNatural / 30000).ToString();
        //    //cantidad = (Contexto.PersonaNaturales.Count()).ToString();

        //    //Resultado
        //    return estructura;
        //}

        //public class validar {
        //    public Int32 lotes { get; set; }
        //    public Int32 cantidad { get; set; }
        //}

        ///// <author>Jose Miguel Lopez Sevilla</author>
        ///// <creationdate>10-Ene-2017</creationdate>
        ///// <summary>
        ///// Método para obtener un listado de objetos de tipo Abogado.
        ///// </summary>
        ///// <param name="idAbogado">idPersonaNatural del Abogado a obtener.</param>
        ///// <param name="activo">Estado de los Objetos de tipo Abogado.</param>
        ///// <returns></returns>
        //public Negocio.Entidades.Persona.PersonaNatural ObtenerPersonaNaturalPorIdAbogado(int idAbogado) {
        //    //Declaraciones
        //    Negocio.Entidades.Persona.PersonaNatural personaNatural; Sql.Modelo.PersonaNatural personaNaturalAD;

        //    try {
        //        personaNaturalAD = (from p in Contexto.PersonaNaturales
        //                            join a in Contexto.Abogados on p.IdPersonaNatural equals a.IdPersonaNatural
        //                            where a.IdAbogado == idAbogado
        //                            select p).ToList().FirstOrDefault();

        //        personaNatural = AutoMapeo.Mapeo(personaNaturalAD, new Negocio.Entidades.Persona.PersonaNatural());
        //    } catch (Exception ex) {
        //        //Parámetros
        //        List<Object> parametros = new List<Object>();
        //        //parametros.Add(ManejadorIdentidad.IdentidadActual != null ? ManejadorIdentidad.IdentidadActual.Name : "");

        //        //parametros.Add(idAbogado);

        //        //RegistroEventoWindows.RegistroEventoFun.RegistroExcepcionAD(MensajeExcepcion.ErrorInesperado, "ObtenerPersonaNaturalPorIdAbogado", RegistroEventoWindows.ExtraerTraza(ex), RegistroEventoWindows.ExtraerMensaje(ex), (ManejadorIdentidad.IdentidadActual != null ? ManejadorIdentidad.IdentidadActual.Name : null), parametros);
        //        throw;
        //    }

        //    return personaNatural;
        //}

        #endregion

    }
}
