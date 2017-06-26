using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.Common;
using System.ComponentModel;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.EntityClient;

namespace AccesoDato.Fachada {

    /// <author>Ernesto Medrano</author>
    /// <creationdate>16-sep-2015</creationdate>
    /// <summary>
    /// Clase FachadaFun, Enmascara los métodos de los componentes.
    /// </summary>
    public partial class FachadaAdmAD {

        #region Atributos

        #endregion

        #region Constructores

        #endregion

        #region PersonaNatural

        /// <author>Ernesto Medrano</author>
        /// <creationdate>16-sep-2015</creationdate>
        /// <summary>
        ///  Método que agrega un nuevo objeto de tipo PersonaNatural.
        /// </summary>
        /// <param name="personaNatural">Objeto tipo PersonaNatural a ser agregado.</param>
        /// <returns>True: Registro agregado.</returns>
        public Boolean AgregarPersonaNatural(Negocio.Entidades.Persona.PersonaNatural personaNatural) {
            //Resultado
            return PersonaNaturalAD.Agregar(personaNatural);
        }

        ///// <author>Ernesto Medrano</author>
        ///// <creationdate>16-sep-2015</creationdate>
        ///// <summary>
        /////  Método que agrega un nuevo listado de objetos de tipo PersonaNatural.
        ///// </summary>
        ///// <param name="personaNaturalListado">Listado de objetos de tipo PersonaNatural a ser agregados.</param>
        ///// <returns>True: Registros agregados.</returns>
        //public Boolean AgregarListadoPersonaNatural(List<Negocio.Entidades.Persona.PersonaNatural> personaNaturalListado) {

        //    //Resultado
        //    return PersonaNaturalAD.AgregarListado(personaNaturalListado);
        //}

        ///// <author>Ernesto Medrano</author>
        ///// <creationdate>16-sep-2015</creationdate>
        ///// <summary>
        /////  Método que da de alta un objeto de tipo PersonaNatural.
        ///// </summary>
        ///// <param name="idPersonaNatural">Identificador del objeto de tipo PersonaNatural.</param>
        ///// <returns>True: Registro dado de Alta.</returns>
        //public Boolean DarAltaPersonaNatural(Int32 idPersonaNatural) {

        //    //Resultado
        //    return PersonaNaturalAD.DarAlta(idPersonaNatural);
        //}

        ///// <author>Ernesto Medrano</author>
        ///// <creationdate>16-sep-2015</creationdate>
        ///// <summary>
        /////  Método que da de alta un listado objeto de tipo PersonaNatural.
        ///// </summary>
        ///// <param name="idPersonaNaturalListado">Listado de objetos de tipo PersonaNatural a ser dado de alta.</param>
        ///// <returns>True: Registros dados de Alta.</returns>
        //public Boolean DarAltaListadoPersonaNatural(List<Int32> idPersonaNaturalListado) {

        //    //Resultado
        //    return PersonaNaturalAD.DarAltaListado(idPersonaNaturalListado);
        //}

        ///// <author>Ernesto Medrano</author>
        ///// <creationdate>16-sep-2015</creationdate>
        ///// <summary>
        /////  Método que da de baja un listado objeto de tipo PersonaNatural.
        ///// </summary>
        ///// <param name="idPersonaNatural">Identificador del objeto de tipo PersonaNatural.</param>
        ///// <returns>True: Registros dado de Baja.</returns>
        //public Boolean DarBajaPersonaNatural(Int32 idPersonaNatural) {

        //    //Resultado
        //    return PersonaNaturalAD.DarBaja(idPersonaNatural);
        //}

        ///// <author>Ernesto Medrano</author>
        ///// <creationdate>16-sep-2015</creationdate>
        ///// <summary>
        /////  Método que da de baja un listado de objetos de tipo PersonaNatural.
        ///// </summary>
        ///// <param name="idPersonaNaturalListado">Listado de identificadores de objetos a ser dados de baja.</param>
        ///// <returns>True: Registros dados de Baja.</returns>
        //public Boolean DarBajaListadoPersonaNatural(List<Int32> idPersonaNaturalListado) {

        //    //Resultado
        //    return PersonaNaturalAD.DarBajaListado(idPersonaNaturalListado);
        //}

        ///// <author>Ernesto Medrano</author>
        ///// <creationdate>16-sep-2015</creationdate>
        ///// <summary>
        /////  Método que actualiza un objeto de tipo PersonaNatural.
        ///// </summary>
        ///// <param name="personaNatural">Objeto de tipo PersonaNatural</param>
        ///// <returns>True: Registros actualizado.</returns>
        //public Boolean ActualizarPersonaNatural(Negocio.Entidades.Persona.PersonaNatural personaNatural) {

        //    //Resultado
        //    return PersonaNaturalAD.Actualizar(personaNatural);
        //}

        ///// <author>Ernesto Medrano</author>
        ///// <creationdate>16-sep-2015</creationdate>
        ///// <summary>
        /////  Método que actualiza un listado objeto de tipo PersonaNatural.
        ///// </summary>
        ///// <param name="personaNaturalListado">Listado de objetos de tipo PersonaNatural a ser actualizado.</param>
        ///// <returns>True: Registros actualizados.</returns>
        //public Boolean ActualizarListadoPersonaNatural(List<Negocio.Entidades.Persona.PersonaNatural> personaNaturalListado) {

        //    //Resultado
        //    return PersonaNaturalAD.ActualizarListado(personaNaturalListado);
        //}

        ///// <author>Ernesto Medrano</author>
        ///// <creationdate>16-sep-2015</creationdate>
        ///// <summary>
        /////  Método que elimina un objeto de tipo PersonaNatural.
        ///// </summary>
        ///// <param name="idPersonaNatural">Identificador del objeto de tipo PersonaNatural.</param>
        ///// <returns>True: Registro Eliminado.</returns>
        //public Boolean EliminarPersonaNatural(Int32 idPersonaNatural) {

        //    //Resultado
        //    return PersonaNaturalAD.Eliminar(idPersonaNatural);
        //}

        ///// <author>Ernesto Medrano</author>
        ///// <creationdate>16-sep-2015</creationdate>
        ///// <summary>
        /////  Método que elimina un listado de objetos de tipo PersonaNatural.
        ///// </summary>
        ///// <param name="idPersonaNaturalListado">Listado de identificadores de objetos a ser eliminados.</param>
        ///// <returns>True: Registros Eliminados.</returns>
        //public Boolean EliminarListadoPersonaNatural(List<Int32> idPersonaNaturalListado) {

        //    //Resultado
        //    return PersonaNaturalAD.EliminarListado(idPersonaNaturalListado);
        //}

        ///// <author>Ernesto Medrano</author>
        ///// <creationdate>16-sep-2015</creationdate>
        ///// <summary>
        /////  Método que obtiene un objeto de tipo PersonaNatural.
        ///// </summary>
        ///// <param name="idPersonaNatural">Identificador de objeto a obtener</param>
        ///// <returns>Retorna un objeto de tipo PersonaNatural</returns>
        //public Negocio.Entidades.Persona.PersonaNatural ObtenerPersonaNatural(Int32 idPersonaNatural) {

        //    //Resultado
        //    return PersonaNaturalAD.Obtener(idPersonaNatural);
        //}

        ///// <author>Ernesto Medrano</author>
        ///// <creationdate>16-sep-2015</creationdate>
        ///// <summary>
        /////  Método que obtiene un listado de objetos de tipo PersonaNatural.
        ///// </summary>
        ///// <param name="activo">Estado del objeto de tipo PersonaNatural</param>
        ///// <returns>Retorna listado de objetos de tipo PersonaNatural</returns>
        //public List<Negocio.Entidades.Persona.PersonaNatural> ObtenerListadoPersonaNatural(Activo activo) {

        //    //Resultado
        //    return PersonaNaturalAD.ObtenerListado(activo);
        //}

        ///// <author>Ernesto Medrano</author>
        ///// <creationdate>16-sep-2015</creationdate>
        ///// <summary>
        /////  Método que obtiene un listado de objetos de tipo PersonaNatural.
        ///// </summary>
        ///// <param name="idPersonaNaturalListado">Listado de identificadores de objetos a obtener.</param>
        ///// <returns>Retorna listado de objetos de tipo PersonaNatural</returns>
        //public List<Negocio.Entidades.Persona.PersonaNatural> ObtenerListadoPersonaNatural(List<Int32> idPersonaNaturalListado) {

        //    //Resultado
        //    return PersonaNaturalAD.ObtenerListado(idPersonaNaturalListado);
        //}

        ///// <author>Ernesto Medrano</author>
        ///// <creationdate>16-sep-2015</creationdate>
        ///// <summary>
        ///// Método para obtener un listado de objetos de tipo PersonaNatural.
        ///// en dependencia del criterio de filtrado.
        ///// </summary>
        ///// <param name="activo">Estado de los Objetos de tipo PersonaNatural.</param>
        ///// <returns>Retorna el listado de Objetos PersonaNatural</returns>
        //public List<Negocio.Entidades.Persona.PersonaNatural> ObtenerListadoPersonaNaturalPorCriterio(Negocio.Entidades.Persona.PersonaNatural criterio, Activo activo) {

        //    //Resultado
        //    return PersonaNaturalAD.ObtenerListadoPersonaNaturalPorCriterio(criterio, activo);
        //}

        ///// <author>Ernesto Medrano</author>
        ///// <creationdate>16-sep-2015</creationdate>
        ///// <summary>
        ///// Método para obtener un listado de objetos de tipo PersonaNatural.
        ///// en dependencia del criterio de filtrado.
        ///// </summary>
        ///// <param name="activo">Estado de los Objetos de tipo PersonaNatural.</param>
        ///// <returns>Retorna el listado de Objetos PersonaNatural</returns>
        //public List<Negocio.Entidades.Persona.PersonaNatural> ObtenerListadoPersonaNaturalPorCriterio(List<Negocio.Entidades.Persona.PersonaNatural> criterioListado, Activo activo) {

        //    //Resultado
        //    return PersonaNaturalAD.ObtenerListadoPersonaNaturalPorCriterio(criterioListado, activo);
        //}

        ///// <author>Jose Miguel Lopez Sevilla</author>
        ///// <creationdate>04-Nov-2016</creationdate>
        ///// <summary>
        /////  Método que obtiene un listado de objetos de tipo PersonaNatural.
        ///// </summary>
        ///// <param name="idPersonaNaturalListado">Listado de identificadores de objetos a obtener.</param>
        ///// <returns>Retorna listado de objetos de tipo PersonaNatural</returns>
        //public List<Negocio.Entidades.Persona.PersonaNatural> ObtenerListadoPersonaNaturalDatosEmpleado(List<Int32> idPersonaNaturalListado) {

        //    //Resultado
        //    return PersonaNaturalAD.ObtenerListadoDatosEmpleado(idPersonaNaturalListado);
        //}

        ///// <author>Ernesto Medrano</author>
        ///// <creationdate>16-sep-2015</creationdate>
        ///// <summary>
        ///// Comentario
        ///// </summary>
        ///// <param name="idPersona">Comentario</param>
        ///// <param name="activo">Comentario</param>
        ///// <returns></returns>
        //public List<Negocio.Entidades.Persona.PersonaNatural> ObtenerListadoPersonaNaturalPorPersona(Int32 idPersona, Activo activo) {

        //    // Resultado
        //    return PersonaNaturalAD.ObtenerListadoPersonaNaturalPorPersona(idPersona, activo);
        //}

        ///// <author>Ernesto Medrano</author>
        ///// <creationdate>16-sep-2015</creationdate>
        ///// <summary>
        ///// Comentario
        ///// </summary>
        ///// <param name="idPersonaListado">Comentario</param>
        ///// <param name="activo">Comentario</param>
        ///// <returns></returns>
        //public List<Negocio.Entidades.Persona.PersonaNatural> ObtenerListadoPersonaNaturalPorPersona(List<Int32> idPersonaListado, Activo activo) {

        //    // Resultado
        //    return PersonaNaturalAD.ObtenerListadoPersonaNaturalPorPersona(idPersonaListado, activo);
        //}

        ///// <author>Ernesto Medrano</author>
        ///// <creationdate>16-sep-2015</creationdate>
        ///// <summary>
        ///// Comentario
        ///// </summary>
        ///// <param name="idGenero">Comentario</param>
        ///// <param name="activo">Comentario</param>
        ///// <returns></returns>
        //public List<Negocio.Entidades.Persona.PersonaNatural> ObtenerListadoPersonaNaturalPorGenero(Int32 idGenero, Activo activo) {

        //    // Resultado
        //    return PersonaNaturalAD.ObtenerListadoPersonaNaturalPorGenero(idGenero, activo);
        //}

        ///// <author>Ernesto Medrano</author>
        ///// <creationdate>16-sep-2015</creationdate>
        ///// <summary>
        ///// Comentario
        ///// </summary>
        ///// <param name="idGeneroListado">Comentario</param>
        ///// <param name="activo">Comentario</param>
        ///// <returns></returns>
        //public List<Negocio.Entidades.Persona.PersonaNatural> ObtenerListadoPersonaNaturalPorGenero(List<Int32> idGeneroListado, Activo activo) {

        //    // Resultado
        //    return PersonaNaturalAD.ObtenerListadoPersonaNaturalPorGenero(idGeneroListado, activo);
        //}

        ///// <author>Ernesto Medrano</author>
        ///// <creationdate>16-sep-2015</creationdate>
        ///// <summary>
        ///// Comentario
        ///// </summary>
        ///// <param name="idEstadoCivil">Comentario</param>
        ///// <param name="activo">Comentario</param>
        ///// <returns></returns>
        //public List<Negocio.Entidades.Persona.PersonaNatural> ObtenerListadoPersonaNaturalPorEstadoCivil(Int32 idEstadoCivil, Activo activo) {

        //    // Resultado
        //    return PersonaNaturalAD.ObtenerListadoPersonaNaturalPorEstadoCivil(idEstadoCivil, activo);
        //}

        ///// <author>Ernesto Medrano</author>
        ///// <creationdate>16-sep-2015</creationdate>
        ///// <summary>
        ///// Comentario
        ///// </summary>
        ///// <param name="idEstadoCivilListado">Comentario</param>
        ///// <param name="activo">Comentario</param>
        ///// <returns></returns>
        //public List<Negocio.Entidades.Persona.PersonaNatural> ObtenerListadoPersonaNaturalPorEstadoCivil(List<Int32> idEstadoCivilListado, Activo activo) {

        //    // Resultado
        //    return PersonaNaturalAD.ObtenerListadoPersonaNaturalPorEstadoCivil(idEstadoCivilListado, activo);
        //}

        ///// <author>Ernesto Medrano</author>
        ///// <creationdate>16-sep-2015</creationdate>
        ///// <summary>
        ///// Comentario
        ///// </summary>
        ///// <param name="idOcupacion">Comentario</param>
        ///// <param name="activo">Comentario</param>
        ///// <returns></returns>
        //public List<Negocio.Entidades.Persona.PersonaNatural> ObtenerListadoPersonaNaturalPorOcupacion(Int32 idOcupacion, Activo activo) {

        //    // Resultado
        //    return PersonaNaturalAD.ObtenerListadoPersonaNaturalPorOcupacion(idOcupacion, activo);
        //}

        ///// <author>Ernesto Medrano</author>
        ///// <creationdate>16-sep-2015</creationdate>
        ///// <summary>
        ///// Comentario
        ///// </summary>
        ///// <param name="idOcupacionListado">Comentario</param>
        ///// <param name="activo">Comentario</param>
        ///// <returns></returns>
        //public List<Negocio.Entidades.Persona.PersonaNatural> ObtenerListadoPersonaNaturalPorOcupacion(List<Int32> idOcupacionListado, Activo activo) {

        //    // Resultado
        //    return PersonaNaturalAD.ObtenerListadoPersonaNaturalPorOcupacion(idOcupacionListado, activo);
        //}

        //public List<Negocio.Entidades.Persona.VistasEstructuras.EstructuraPersonaNatural> ObtenerEstructuraPersonaNatural(Int32 inicio, Int32 fin, Int32 filtro, Int32 ubicacion, Int32 idpersonanatural, out String cantidad, out String lotes) {
        //    // Resultado,
        //    return PersonaNaturalAD.ObtenerEstructuraPersonaNatural(inicio, fin, filtro, ubicacion, idpersonanatural, out cantidad, out lotes);
        //}

        ///// <author>Jose Miguel Lopez Sevilla</author>
        ///// <creationdate>10-Ene-2017</creationdate>
        ///// <summary>
        ///// Método para obtener un listado de objetos de tipo Abogado.
        ///// </summary>
        ///// <param name="idPersonaNatural">idPersonaNatural del Abogado a obtener.</param>
        ///// <param name="activo">Estado de los Objetos de tipo Abogado.</param>
        ///// <returns></returns>
        //public Negocio.Entidades.Persona.PersonaNatural ObtenerPersonaNaturalPorIdAbogado(int idAbogado) {
        //    return PersonaNaturalAD.ObtenerPersonaNaturalPorIdAbogado(idAbogado);
        //}

        #endregion

    }
}
