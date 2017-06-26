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

        #region Persona

        /// <author>Ernesto Medrano</author>
        /// <creationdate>16-sep-2015</creationdate>
        /// <summary>
        ///  Método que agrega un nuevo objeto de tipo Persona.
        /// </summary>
        /// <param name="persona">Objeto tipo Persona a ser agregado.</param>
        /// <returns>True: Registro agregado.</returns>
        public Boolean AgregarPersona(Negocio.Entidades.Persona.Persona persona) {

            //Resultado
            return PersonaAD.Agregar(persona);
        }

        ///// <author>Ernesto Medrano</author>
        ///// <creationdate>16-sep-2015</creationdate>
        ///// <summary>
        /////  Método que agrega un nuevo listado de objetos de tipo Persona.
        ///// </summary>
        ///// <param name="personaListado">Listado de objetos de tipo Persona a ser agregados.</param>
        ///// <returns>True: Registros agregados.</returns>
        //public Boolean AgregarListadoPersona(List<Negocio.Entidades.Persona.Persona> personaListado) {

        //    //Resultado
        //    return PersonaAD.AgregarListado(personaListado);
        //}

        ///// <author>Ernesto Medrano</author>
        ///// <creationdate>16-sep-2015</creationdate>
        ///// <summary>
        /////  Método que da de alta un objeto de tipo Persona.
        ///// </summary>
        ///// <param name="idPersona">Identificador del objeto de tipo Persona.</param>
        ///// <returns>True: Registro dado de Alta.</returns>
        //public Boolean DarAltaPersona(Int32 idPersona) {

        //    //Resultado
        //    return PersonaAD.DarAlta(idPersona);
        //}

        ///// <author>Ernesto Medrano</author>
        ///// <creationdate>16-sep-2015</creationdate>
        ///// <summary>
        /////  Método que da de alta un listado objeto de tipo Persona.
        ///// </summary>
        ///// <param name="idPersonaListado">Listado de objetos de tipo Persona a ser dado de alta.</param>
        ///// <returns>True: Registros dados de Alta.</returns>
        //public Boolean DarAltaListadoPersona(List<Int32> idPersonaListado) {

        //    //Resultado
        //    return PersonaAD.DarAltaListado(idPersonaListado);
        //}

        ///// <author>Ernesto Medrano</author>
        ///// <creationdate>16-sep-2015</creationdate>
        ///// <summary>
        /////  Método que da de baja un listado objeto de tipo Persona.
        ///// </summary>
        ///// <param name="idPersona">Identificador del objeto de tipo Persona.</param>
        ///// <returns>True: Registros dado de Baja.</returns>
        //public Boolean DarBajaPersona(Int32 idPersona) {

        //    //Resultado
        //    return PersonaAD.DarBaja(idPersona);
        //}

        ///// <author>Ernesto Medrano</author>
        ///// <creationdate>16-sep-2015</creationdate>
        ///// <summary>
        /////  Método que da de baja un listado de objetos de tipo Persona.
        ///// </summary>
        ///// <param name="idPersonaListado">Listado de identificadores de objetos a ser dados de baja.</param>
        ///// <returns>True: Registros dados de Baja.</returns>
        //public Boolean DarBajaListadoPersona(List<Int32> idPersonaListado) {

        //    //Resultado
        //    return PersonaAD.DarBajaListado(idPersonaListado);
        //}

        ///// <author>Ernesto Medrano</author>
        ///// <creationdate>16-sep-2015</creationdate>
        ///// <summary>
        /////  Método que actualiza un objeto de tipo Persona.
        ///// </summary>
        ///// <param name="persona">Objeto de tipo Persona</param>
        ///// <returns>True: Registros actualizado.</returns>
        //public Boolean ActualizarPersona(Negocio.Entidades.Persona.Persona persona) {

        //    //Resultado
        //    return PersonaAD.Actualizar(persona);
        //}

        ///// <author>Ernesto Medrano</author>
        ///// <creationdate>16-sep-2015</creationdate>
        ///// <summary>
        /////  Método que actualiza un listado objeto de tipo Persona.
        ///// </summary>
        ///// <param name="personaListado">Listado de objetos de tipo Persona a ser actualizado.</param>
        ///// <returns>True: Registros actualizados.</returns>
        //public Boolean ActualizarListadoPersona(List<Negocio.Entidades.Persona.Persona> personaListado) {

        //    //Resultado
        //    return PersonaAD.ActualizarListado(personaListado);
        //}

        ///// <author>Ernesto Medrano</author>
        ///// <creationdate>16-sep-2015</creationdate>
        ///// <summary>
        /////  Método que elimina un objeto de tipo Persona.
        ///// </summary>
        ///// <param name="idPersona">Identificador del objeto de tipo Persona.</param>
        ///// <returns>True: Registro Eliminado.</returns>
        //public Boolean EliminarPersona(Int32 idPersona) {

        //    //Resultado
        //    return PersonaAD.Eliminar(idPersona);
        //}

        ///// <author>Ernesto Medrano</author>
        ///// <creationdate>16-sep-2015</creationdate>
        ///// <summary>
        /////  Método que elimina un listado de objetos de tipo Persona.
        ///// </summary>
        ///// <param name="idPersonaListado">Listado de identificadores de objetos a ser eliminados.</param>
        ///// <returns>True: Registros Eliminados.</returns>
        //public Boolean EliminarListadoPersona(List<Int32> idPersonaListado) {

        //    //Resultado
        //    return PersonaAD.EliminarListado(idPersonaListado);
        //}

        ///// <author>Ernesto Medrano</author>
        ///// <creationdate>16-sep-2015</creationdate>
        ///// <summary>
        /////  Método que obtiene un objeto de tipo Persona.
        ///// </summary>
        ///// <param name="idPersona">Identificador de objeto a obtener</param>
        ///// <returns>Retorna un objeto de tipo Persona</returns>
        //public Negocio.Entidades.Persona.Persona ObtenerPersona(Int32 idPersona) {

        //    //Resultado
        //    return PersonaAD.Obtener(idPersona);
        //}

        ///// <author>Ernesto Medrano</author>
        ///// <creationdate>16-sep-2015</creationdate>
        ///// <summary>
        /////  Método que obtiene un listado de objetos de tipo Persona.
        ///// </summary>
        ///// <param name="activo">Estado del objeto de tipo Persona</param>
        ///// <returns>Retorna listado de objetos de tipo Persona</returns>
        //public List<Negocio.Entidades.Persona.Persona> ObtenerListadoPersona(Activo activo) {

        //    //Resultado
        //    return PersonaAD.ObtenerListado(activo);
        //}

        ///// <author>Ernesto Medrano</author>
        ///// <creationdate>16-sep-2015</creationdate>
        ///// <summary>
        /////  Método que obtiene un listado de objetos de tipo Persona.
        ///// </summary>
        ///// <param name="idPersonaListado">Listado de identificadores de objetos a obtener.</param>
        ///// <returns>Retorna listado de objetos de tipo Persona</returns>
        //public List<Negocio.Entidades.Persona.Persona> ObtenerListadoPersona(List<Int32> idPersonaListado) {

        //    //Resultado
        //    return PersonaAD.ObtenerListado(idPersonaListado);
        //}

        ///// <author>Ernesto Medrano</author>
        ///// <creationdate>16-sep-2015</creationdate>
        ///// <summary>
        ///// Comentario
        ///// </summary>
        ///// <param name="idTipoPersona">Comentario</param>
        ///// <param name="activo">Comentario</param>
        ///// <returns></returns>
        //public List<Negocio.Entidades.Persona.Persona> ObtenerListadoPersonaPorTipoPersona(Int32 idTipoPersona, Activo activo) {

        //    // Resultado
        //    return PersonaAD.ObtenerListadoPersonaPorTipoPersona(idTipoPersona, activo);
        //}

        ///// <author>Ernesto Medrano</author>
        ///// <creationdate>16-sep-2015</creationdate>
        ///// <summary>
        ///// Comentario
        ///// </summary>
        ///// <param name="idTipoPersonaListado">Comentario</param>
        ///// <param name="activo">Comentario</param>
        ///// <returns></returns>
        //public List<Negocio.Entidades.Persona.Persona> ObtenerListadoPersonaPorTipoPersona(List<Int32> idTipoPersonaListado, Activo activo) {

        //    // Resultado
        //    return PersonaAD.ObtenerListadoPersonaPorTipoPersona(idTipoPersonaListado, activo);
        //}

        ///// <author>Ernesto Medrano</author>
        ///// <creationdate>25-08-2015</creationdate>
        ///// <summary>
        ///// Se obtiene el listado de persona mediante un criterio especifico.
        ///// </summary>
        ///// <param name="nombreCompleto"></param>
        ///// <returns>Listado Persona</returns>
        //public List<EstructuraInteresados> ObtenerListadoPersonaPorNombreCompleto(String nombreCompleto) {
        //    //Resultado
        //    return PersonaAD.ObtenerListadoPersonaPorNombreCompleto(nombreCompleto);
        //}

        //public List<EstructuraPersona> ObtenerListadoRangoPersona() {
        //    return PersonaAD.ObtenerListadoRangoPersona();
        //}

        //public List<Persona> ObtenerListadoPersonaRango(List<int> idPersonaListado) {
        //    return PersonaAD.ObtenerListadoRango(idPersonaListado);
        //}

        ///// <author>Jeffry Huerta</author>
        ///// <creationdate>12-sep-2016</creationdate>
        ///// <summary>
        ///// Método para obtener un listado de objetos de tipo Persona.
        ///// </summary>
        ///// <param name="activo">Estado de los objetos de tipo Persona.</param>
        ///// <returns></returns>
        //public List<EstructuraPersona> ObtenerListadoPersonaActivoRango(Activo activo) {
        //    return PersonaAD.ObtenerListadoPersonaActivoRango(activo);
        //}

        //public List<EstructuraBusquedaTipoPersona> ObtenerBusquedaTipoPersona(String Busqueda, String TipoBusqueda) {
        //    return PersonaAD.ObtenerBusquedaTipoPersona(Busqueda, TipoBusqueda);
        //}

        ///// <author>Fernando Gallegos</author>
        ///// <creationdate>12-Dic-2016</creationdate>
        ///// <summary>
        ///// Obtiene la información básica de una persona, ya sea natural o jurídica en formato XML y la hoja de estilo para renderizar la información.
        ///// </summary>
        ///// <param name="idPersona">Identificador único de la persona</param>
        ///// <returns>Listado con contenido Xml, el primer registro son los datos, el segundo es la hoja de estilo</returns>
        //public List<String> ObtenerInformacionPersona(Int32 idPersona) {
        //    return PersonaAD.ObtenerInformacionPersona(idPersona);
        //}

        //public List<String> ObtenerDetallePersonaXML(Int32 idPersona) {
        //    return PersonaAD.ObtenerDetallePersonaXML(idPersona);
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
        //    return PersonaAD.ObtenerListadoTipoPersonaPorIdTipoPersona(idTipoPersona, activo);
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
        //    return PersonaAD.ObtenerListadoTipoPersonaPorListadoIdTipoPersona(listadoIdTipoPersona, activo);
        //}

        #endregion

    }
}
