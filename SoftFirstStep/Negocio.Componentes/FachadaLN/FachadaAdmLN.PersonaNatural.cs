using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.ComponentModel;

namespace Negocio.Componentes.FachadaLN {

    public partial class FachadaAdmLN {

        #region Atributos

        #endregion

        #region Constructores

        #endregion

        #region PersonaNatural

        #region CRUD

        /// <author>Ernesto Medrano</author>
        /// <creationdate>11-ago-2015</creationdate>
        /// <summary>
        /// Método que agrega un nuevo objeto de tipo PersonaNatural.
        /// </summary>
        /// <param name="persona">Objeto tipo PersonaNatural a ser agregado.</param>
        /// <returns>True: Registro agregado </returns>        
        public Boolean AgregarPersonaNatural(Entidades.Persona.PersonaNatural personaNatural) {
            //Operaciones
            return PersonaLN.AgregarPersonaNatural(personaNatural);
        }

        ///// <author>Ernesto Medrano</author>
        ///// <creationdate>11-ago-2015</creationdate>
        ///// <summary>
        ///// Método que agrega un nuevo listado de objeto de tipo PersonaNatural.
        ///// </summary>
        ///// <param name="PersonaNaturalListado">Listado de objetos de tipo PersonaNatural a ser agregados.</param>
        ///// <returns>True: Registro agregado </returns>        
        //public Boolean AgregarListadoPersonaNatural(List<Entidades.Persona.PersonaNatural> personaNaturalListado) {
        //    //Operaciones
        //    return PersonaLN.AgregarListadoPersonaNatural(personaNaturalListado);
        //}

        ///// <author>Ernesto Medrano</author>
        ///// <creationdate>11-ago-2015</creationdate>
        ///// <summary>
        /////  Método para editar un objeto de tipo PersonaNatural.
        ///// </summary>
        ///// <param name="PersonaNatural">Objeto tipo PersonaNatural a ser editado</param>
        ///// <returns>True: Operación exitosa </returns>    
        //public Boolean ActualizarPersonaNatural(Entidades.Persona.PersonaNatural personaNatural) {
        //    //Operaciones
        //    return PersonaLN.ActualizarPersonaNatural(personaNatural);
        //}

        ///// <author>Ernesto Medrano</author>
        ///// <creationdate>11-ago-2015</creationdate>
        ///// <summary>
        ///// Método para editar un listado de objetos de tipo PersonaNatural.
        ///// </summary>
        ///// <param name="PersonaNaturalListado">Listado de objetos de tipo PersonaNatural a ser editado</param>
        ///// <returns>True: Operación exitosa </returns>    
        //public Boolean ActualizarListadoPersonaNatural(List<Entidades.Persona.PersonaNatural> personaNaturalListado) {
        //    //Operaciones
        //    return PersonaLN.ActualizarListadoPersonaNatural(personaNaturalListado);
        //}

        ///// <author>Ernesto Medrano</author>
        ///// <creationdate>11-ago-2015</creationdate>
        ///// <summary>
        ///// Método para dar de alta al objeto de tipo PersonaNatural.
        ///// Cambia el campo EstaActivo a True.
        ///// </summary>
        ///// <param name="PersonaNatural">Identificador del objeto</param>
        ///// <returns>True: Operación exitosa </returns>    
        //public Boolean DarAltaPersonaNatural(Entidades.Persona.PersonaNatural personaNatural) {
        //    //Operaciones
        //    return PersonaLN.DarAltaPersonaNatural(personaNatural);
        //}

        ///// <author>Ernesto Medrano</author>
        ///// <creationdate>11-ago-2015</creationdate>
        ///// <summary>
        ///// Método para dar de alta al listado del objeto de tipo PersonaNatural.
        ///// Cambia el campo EstaActivo a True.
        ///// </summary>
        ///// <param name="PersonaNatural">Listado de identificadores de objetos.</param>
        ///// <returns>True: Operación exitosa </returns>   
        //public Boolean DarAltaListadoPersonaNatural(List<Entidades.Persona.PersonaNatural> personaNaturalListado) {
        //    //Operaciones
        //    return PersonaLN.DarAltaListadoPersonaNatural(personaNaturalListado);
        //}

        ///// <author>Ernesto Medrano</author>
        ///// <creationdate>11-ago-2015</creationdate>
        ///// <summary>
        ///// Método para dar de baja al objeto de tipo PersonaNatural.
        ///// Cambia el estado del objeto a "False".
        ///// </summary>
        ///// <param name="PersonaNatural">Identificador del objeto.</param>
        ///// <returns>True: Operación exitosa </returns>   
        //public Boolean DarBajaPersonaNatural(Entidades.Persona.PersonaNatural personaNatural) {
        //    //Operaciones
        //    return PersonaLN.DarBajaPersonaNatural(personaNatural);
        //}

        ///// <author>Ernesto Medrano</author>
        ///// <creationdate>11-ago-2015</creationdate>
        ///// <summary>
        ///// Método para dar de baja al listado de objeto de tipo PersonaNatural.
        ///// Cambia el estado del objeto a "False".
        ///// </summary>
        ///// <param name="PersonaNatural">Listado de identificadores de objetos.</param>
        ///// <returns>True: Operación exitosa </returns>   
        //public Boolean DarBajaListadoPersonaNatural(List<Entidades.Persona.PersonaNatural> personaNaturalListado) {
        //    //Operaciones
        //    return PersonaLN.DarBajaListadoPersonaNatural(personaNaturalListado);
        //}

        ///// <author>Ernesto Medrano</author>
        ///// <creationdate>11-ago-2015</creationdate>
        ///// <summary>
        ///// Método para eliminar un objeto de tipo PersonaNatural.
        ///// </summary>
        ///// <param name="PersonaNatural">Identificador del objeto.</param>
        ///// <returns>True: Operación exitosa </returns>   
        //public Boolean EliminarPersonaNatural(Entidades.Persona.PersonaNatural personaNatural) {
        //    //Operaciones
        //    return PersonaLN.EliminarPersonaNatural(personaNatural);
        //}

        ///// <author>Ernesto Medrano</author>
        ///// <creationdate>11-ago-2015</creationdate>
        ///// <summary>
        ///// Método para eliminar un listado de objetos de tipo PersonaNatural.
        ///// </summary>
        ///// <param name="PersonaNatural">Identificador del objeto.</param>
        ///// <returns>True: Operación exitosa </returns>   
        //public Boolean EliminarListadoPersonaNatural(List<Entidades.Persona.PersonaNatural> personaNaturalListado) {
        //    //Operaciones
        //    return PersonaLN.EliminarListadoPersonaNatural(personaNaturalListado);
        //}

        ///// <author>Ernesto Medrano</author>
        ///// <creationdate>11-ago-2015</creationdate>
        ///// <summary>
        ///// Método para obtener un objeto tipo PersonaNatural.
        ///// </summary>
        ///// <param name="PersonaNatural">Identificador del objeto.</param>
        ///// <returns>Retorna el Objeto PersonaNatural</returns>  
        //public Entidades.Persona.PersonaNatural ObtenerPersonaNatural(Int32 idPersonaNatural, Inclusiones.InclusionPersonaNatural inclusionPersonaNatural = null) {
        //    //Resultado
        //    return PersonaLN.ObtenerPersonaNatural(idPersonaNatural, inclusionPersonaNatural);
        //}

        ///// <author>Ernesto Medrano</author>
        ///// <creationdate>11-ago-2015</creationdate>
        ///// <summary>
        ///// Método para obtener un listado de objeto tipo PersonaNatural.
        ///// </summary>
        ///// <param name="idPersonaNaturalListado">Listado de identificadores de objetos de tipo PersonaNatural.</param>
        ///// <returns>Retorna el listado de Objeto PersonaNatural</returns>  
        //public List<Entidades.Persona.PersonaNatural> ObtenerListadoPersonaNatural(List<Int32> idPersonaNaturalListado, Inclusiones.InclusionPersonaNatural inclusionPersonaNatural = null) {
        //    //Resultado
        //    return PersonaLN.ObtenerListadoPersonaNatural(idPersonaNaturalListado, inclusionPersonaNatural);
        //}

        ///// <author>Ernesto Medrano</author>
        ///// <creationdate>11-ago-2015</creationdate>
        ///// <summary>
        ///// Método para obtener un listado de objetos de tipo PersonaNatural.
        ///// </summary>
        ///// <param name="activo">Estado de los Objetos a obtener.</param>
        ///// <returns>True: Operación exitosa</returns>  
        //public List<Entidades.Persona.PersonaNatural> ObtenerListadoPersonaNatural(Activo activo, Inclusiones.InclusionPersonaNatural inclusionPersonaNatural = null) {
        //    //Resultado
        //    return PersonaLN.ObtenerListadoPersonaNatural(activo, inclusionPersonaNatural);
        //}


        //public List<Negocio.Entidades.Persona.VistasEstructuras.EstructuraPersonaNatural> ObtenerEstructuraPersonaNatural(Int32 inicio, Int32 fin, Int32 filtro, Int32 ubicacion, Int32 idpersonanatural, out String cantidad, out String lotes) {
        //    //Resultado
        //    return PersonaLN.ObtenerEstructuraPersonaNatural(inicio, fin, filtro, ubicacion, idpersonanatural, out   cantidad, out   lotes);
        //}

        ////// <author>Ernesto Medrano</author>
        ///// <creationdate>11-ago-2015</creationdate>
        ///// <summary>
        ///// Método para obtener un listado de objetos de tipo PersonaNatural.
        ///// </summary>
        ///// <param name="criterio">Objeto de tipo PersonaNatural a obtener.</param>
        ///// <param name="activo">Estado de los datos.</param>
        ///// <returns>Retorna el listado de Objetos PersonaNatural.</returns>  
        //public List<Entidades.Persona.PersonaNatural> ObtenerListadoPersonaNaturalPorCriterio(Activo activo, Entidades.Persona.PersonaNatural criterio, Inclusiones.InclusionPersonaNatural inclusionPersonaNatural = null) {
        //    //Resultado
        //    return PersonaLN.ObtenerListadoPersonaNaturalPorCriterio(activo, criterio, inclusionPersonaNatural);
        //}


        //public List<PersonaNatural> ObtenerListadoPersonaNaturalPorPersona(int idPersona, Activo activo) {
        //    return PersonaLN.ObtenerListadoPersonaNaturalPorPersona(idPersona, activo);
        //}

        //public List<PersonaNatural> ObtenerListadoPersonaNaturalPorPersona(List<int> idPersonaListado, Activo activo) {
        //    return PersonaLN.ObtenerListadoPersonaNaturalPorPersona(idPersonaListado, activo);
        //}

        #endregion

        #region Bloqueo

        ///// <author>Ernesto Medrano</author>
        ///// <creationdate>11-ago-2015</creationdate>
        ///// <summary>
        ///// Método que inicia un bloqueo de un registro de una tabla de la base de datos.
        ///// </summary>
        ///// <param name="registroBloqueo">Objeto de tipo RegistroBloqueo a ser bloqueado.</param>
        ///// <returns>True: Registro Bloqueado</returns>
        //public Boolean IniciarEdicionPersonaNatural(Entidades.Persona.PersonaNatural personaNatural) {
        //    return PersonaLN.IniciarEdicionPersonaNatural(personaNatural);
        //}

        ///// <author>Ernesto Medrano</author>
        ///// <creationdate>11-ago-2015</creationdate>
        ///// <summary>
        ///// Método que inicia el bloqueo de un listado de registros de una tabla de la base de datos.
        ///// </summary>
        ///// <param name="registroBloqueoListado">Lista de objetos tipo RegistroBloqueo a ser bloqueado.</param>
        ///// <returns>True: Registro Bloqueado</returns>
        //public Boolean IniciarEdicionListadoPersonaNatural(List<Entidades.Persona.PersonaNatural> personaNaturalListado) {
        //    return PersonaLN.IniciarEdicionListadoPersonaNatural(personaNaturalListado);
        //}

        ///// <author>Ernesto Medrano</author>
        ///// <creationdate>11-ago-2015</creationdate>
        ///// <summary>
        ///// Método que Cancela el bloqueo de un registro de una tabla de la base de datos.
        ///// </summary>
        ///// <param name="registroBloqueo">Objeto de tipo RegistroBloqueo a ser bloqueado.</param>
        ///// <returns>True: Registro Desbloqueado</returns>
        //public Boolean CancelarEdicionPersonaNatural(Entidades.Persona.PersonaNatural personaNatural) {
        //    return PersonaLN.CancelarEdicionPersonaNatural(personaNatural);
        //}

        ///// <author>Ernesto Medrano</author>
        ///// <creationdate>11-ago-2015</creationdate>
        ///// <summary>
        ///// Método que cancela el bloqueo de un listado de registros de uan tabla de la base de datos.
        ///// </summary>
        ///// <param name="registroBloqueoListado">Lista de objetos tipo RegistroBloqueo a ser bloqueado.</param>
        ///// <returns>True: Registro Desbloqueado</returns>
        //public Boolean CancelarEdicionListadoPersonaNatural(List<Entidades.Persona.PersonaNatural> personaNaturalListado) {
        //    return PersonaLN.CancelarEdicionListadoPersonaNatural(personaNaturalListado);
        //}

        ///// <author>Ernesto Medrano</author>
        ///// <creationdate>11-ago-2015</creationdate>
        ///// <summary>
        ///// Método que finaliza el bloqueo de un registro de una tabla de la base de datos.
        ///// </summary>
        ///// <param name="registroBloqueo">Objeto de tipo RegistroBloqueo a ser bloqueado.</param>
        ///// <returns>True: Registro Desbloqueado</returns>
        //public Boolean FinalizarEdicionPersonaNatural(Entidades.Persona.PersonaNatural personaNatural) {
        //    return PersonaLN.FinalizarEdicionPersonaNatural(personaNatural);
        //}

        ///// <author>Ernesto Medrano</author>
        ///// <creationdate>11-ago-2015</creationdate>
        ///// <summary>
        ///// Método que finaliza el bloqueo de un listado de registros de una tabla de la base de datos.
        ///// </summary>
        ///// <param name="registroBloqueoListado">Lista de objetos tipo RegistroBloqueo a ser bloqueado.</param>
        ///// <returns>True: Registro Desbloqueado</returns>
        //public Boolean FinalizarEdicionListadoPersonaNatural(List<Entidades.Persona.PersonaNatural> personaNaturalListado) {
        //    return PersonaLN.FinalizarEdicionListadoPersonaNatural(personaNaturalListado);
        //}

        #endregion

        #endregion

    }
}







