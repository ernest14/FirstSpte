using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using Utilidades.Mensajes;

namespace Negocio.Componentes.Persona {

    /// <author>Ernesto Medrano</author>
    /// <creationdate>16-sep-2015</creationdate>
    /// <summary>
    /// Clase AplicacionLN nos permite comunicarnos con la FachadaFunAD
    /// </summary>
    public partial class PersonaLN {

        #region Atributos



        #endregion

        #region Constructores

        #endregion

        #region Metodos

        #region CRUD

        /// <author>Ernesto Medrano</author>
        /// <creationdate>16-sep-2015</creationdate>
        /// <summary>
        /// Método que agrega un nuevo objeto de tipo PersonaNatural.
        /// </summary>
        /// <param name="personaNatural">Objeto tipo PersonaNatural a ser agregado.</param>
        /// <returns>True: Registro agregado </returns>        
        public Boolean AgregarPersonaNatural(Entidades.Persona.PersonaNatural personaNatural) {
            //Declaraciones
            //TransactionScope transaccion;
            Boolean resultado = false;
            //Operaciones
            if ( personaNatural == null ) {
                throw new ArgumentNullException("personaNatural", MensajeExcepcion.ParametroEnNulo);
            }
            if ( personaNatural.IdPersonaNatural != 0 ) {
                throw new ArgumentException(MensajeExcepcion.IdentificadorObjetoCreacion, "personaNatural");
            }
            if ( ValidarPersonaNatural(personaNatural) == false ) {
                return false;
            }
            // using ( transaccion = new TransactionScope() ) {
            Negocio.Entidades.Persona.Persona personaNueva = new Entidades.Persona.Persona();
            personaNueva.TipoPersona = new Entidades.TablaBasica.Valor() { IdValor = 7 };
            resultado = this.AgregarPersona(personaNueva);
            if ( resultado == true ) {
                personaNatural.Persona = personaNueva;
                if ( personaNatural.FechaFallecimiento == DateTime.MinValue ) {
                    personaNatural.FechaFallecimiento = null;
                }
                resultado = FachadaAdmAD.AgregarPersonaNatural(personaNatural);
            }
            //if ( resultado == true ) {
            //    transaccion.Complete();
            //}
            //}

            //Resultado
            return resultado;
        }

        ///// <author>Ernesto Medrano</author>
        ///// <creationdate>16-sep-2015</creationdate>
        ///// <summary>
        ///// Método que agrega un nuevo listado de objeto de tipo PersonaNatural.
        ///// </summary>
        ///// <param name="personaNaturalListado">Listado de objetos de tipo PersonaNatural a ser agregados.</param>
        ///// <returns>True: Registros agregados</returns>
        //public Boolean AgregarListadoPersonaNatural(List<Entidades.Persona.PersonaNatural> personaNaturalListado) {
        //    //Declaraciones
        //    //TransactionScope transaccion;
        //    Boolean resultado = false;

        //    //Operaciones
        //    if ( personaNaturalListado == null ) {
        //        throw new ArgumentNullException("personaNaturalListado", MensajeExcepcion.ParametroEnNulo);
        //    }
        //    if ( personaNaturalListado.Count() <= 0 ) {
        //        throw new ArgumentException(MensajeExcepcion.ParametroListaVacia, "personaNaturalListado");
        //    }
        //    if ( personaNaturalListado.Where(l => l.IdPersonaNatural != 0).Count() > 0 ) {
        //        throw new ArgumentException(MensajeExcepcion.IdentificadorObjetoCreacionListado, "personaNaturalListado");
        //    }
        //    // using ( transaccion = new TransactionScope() ) {
        //    foreach ( var personaNatural in personaNaturalListado ) {
        //        Negocio.Entidades.Persona.Persona personaNueva = new Entidades.Persona.Persona();
        //        personaNueva.TipoPersona = new Entidades.TablaBasica.Valor() { IdValor = 7 };
        //        resultado = this.AgregarPersona(personaNueva);
        //        if ( resultado == true ) {
        //            personaNatural.Persona = personaNueva;
        //            if ( personaNatural.FechaFallecimiento == DateTime.MinValue ) {
        //                personaNatural.FechaFallecimiento = null;
        //            }
        //            resultado = FachadaAdmAD.AgregarPersonaNatural(personaNatural);
        //        }
        //    }
        //    //    if ( resultado == true ) {
        //    //        transaccion.Complete();
        //    //    }
        //    //}

        //    //Resultado
        //    return resultado;
        //}

        ///// <author>Ernesto Medrano</author>
        ///// <creationdate>16-sep-2015</creationdate>
        ///// <summary>
        ///// Método para editar un objeto de tipo PersonaNatural.
        ///// </summary>
        ///// <param name="personaNatural">Objeto tipo PersonaNatural a ser editado.</param>
        ///// <returns>True: Operación exitosa</returns>
        //public Boolean ActualizarPersonaNatural(Entidades.Persona.PersonaNatural personaNatural) {
        //    //Declaraciones
        //    Boolean resultado = false;
        //    Entidades.Persona.PersonaNatural personaNaturalActual;

        //    //Operaciones
        //    if ( personaNatural == null ) {
        //        throw new ArgumentNullException("personaNatural", MensajeExcepcion.ParametroEnNulo);
        //    }
        //    if ( personaNatural.IdPersonaNatural <= 0 ) {
        //        throw new ArgumentException(MensajeExcepcion.IdentificadorObjetoNoValido, "personaNatural");
        //    }
        //    resultado = ValidarPersonaNatural(personaNatural);
        //    if ( resultado == true ) {
        //        resultado = FachadaAdmAD.ActualizarPersonaNatural(personaNatural);
        //        if ( resultado == true ) {
        //            if ( personaNatural.RegistroBloqueo != null ) {
        //                if ( personaNatural.RegistroBloqueo.IdRegistroBloqueo > 0 ) {
        //                    FinalizarEdicionPersonaNatural(personaNatural);
        //                }
        //            }
        //        }
        //    }

        //    //Resultado
        //    return resultado;
        //}

        ///// <author>Ernesto Medrano</author>
        ///// <creationdate>16-sep-2015</creationdate>
        ///// <summary>
        ///// Método para editar un listado de objetos de tipo PersonaNatural.
        ///// </summary>
        ///// <param name="personaNaturalListado">Listado de objetos de tipo PersonaNatural a ser editados</param>
        ///// <returns>True: Operación exitosa</returns>
        //public Boolean ActualizarListadoPersonaNatural(List<Entidades.Persona.PersonaNatural> personaNaturalListado) {
        //    //Declaraciones
        //    Boolean resultado = false;

        //    //Operaciones
        //    if ( personaNaturalListado == null ) {
        //        throw new ArgumentNullException("personaNaturalListado", MensajeExcepcion.ParametroEnNulo);
        //    }
        //    if ( personaNaturalListado.Count() <= 0 ) {
        //        throw new ArgumentException(MensajeExcepcion.ParametroListaVacia, "personaNaturalListado");
        //    }
        //    if ( personaNaturalListado.Where(mo => mo.IdPersonaNatural <= 0).Count() > 0 ) {
        //        throw new ArgumentException(MensajeExcepcion.IdentificadorObjetoNoValidoListado, "personaNaturalListado");
        //    }
        //    foreach ( var personaNatural in personaNaturalListado ) {
        //        resultado = ValidarPersonaNatural(personaNatural);
        //        if ( resultado == false ) {
        //            return resultado;
        //        } else {
        //            resultado = FachadaAdmAD.ActualizarPersonaNatural(personaNatural);
        //        }
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
        ///// <param name="personaNatural">Objeto a ser dado de alta.</param>
        ///// <returns>True: Operación exitosa</returns>
        //public Boolean DarAltaPersonaNatural(Entidades.Persona.PersonaNatural personaNatural) {
        //    //Declaraciones     
        //    Entidades.Persona.PersonaNatural personaNaturalActual;
        //    ReglaNegocio reglaNegocio = new ReglaNegocio();

        //    //Operaciones
        //    if ( personaNatural == null ) {
        //        throw new ArgumentNullException("personaNatural", MensajeExcepcion.ParametroEnNulo);
        //    }
        //    if ( personaNatural.IdPersonaNatural <= 0 ) {
        //        throw new ArgumentException(MensajeExcepcion.IdentificadorObjetoNoValido, "personaNatural");
        //    }
        //    if ( personaNatural.EstaActivo == true ) {
        //        personaNatural.AgregarReglaInfringida("", MensajeReglaNegocio.RegistroEstaActivo, "EstaActivo");
        //        return false;
        //    }
        //    personaNaturalActual = ObtenerPersonaNatural(personaNatural.IdPersonaNatural, new Inclusiones.InclusionPersonaNatural() { RegistroBloqueo = true });
        //    if ( personaNaturalActual.EstaBloqueado == true ) {
        //        personaNatural.AgregarReglaInfringida("", MensajeReglaNegocio.RegistroEstaBloqueado, "EstaBloqueado");
        //        return false;
        //    }
        //    if ( personaNaturalActual.EstaActivo == true ) {
        //        personaNatural.AgregarReglaInfringida("", MensajeReglaNegocio.RegistroEstaActivo, "EstaActivo");
        //        return false;
        //    }

        //    //Resultado
        //    return FachadaAdmAD.DarAltaPersonaNatural(personaNatural.IdPersonaNatural);
        //}

        ///// <author>Ernesto Medrano</author>
        ///// <creationdate>16-sep-2015</creationdate>
        ///// <summary>
        ///// Método para dar de alta al listado de objeto de tipo PersonaNatural.
        ///// Cambian los campos EstaActivo a True.
        ///// </summary>
        ///// <param name="personaNaturalListado">Listado de identificadores de objetos.</param>
        ///// <returns>True: Operación exitosa</returns>
        //public Boolean DarAltaListadoPersonaNatural(List<Entidades.Persona.PersonaNatural> personaNaturalListado) {
        //    //Declaraciones            
        //    List<Entidades.Persona.PersonaNatural> personaNaturalListadoActual;
        //    ReglaNegocio reglaNegocio = new ReglaNegocio();

        //    //Operaciones
        //    if ( personaNaturalListado == null ) {
        //        throw new ArgumentNullException("personaNaturalListado", MensajeExcepcion.ParametroEnNulo);
        //    }
        //    if ( personaNaturalListado.Count() <= 0 ) {
        //        throw new ArgumentException(MensajeExcepcion.ParametroListaVacia, "personaNaturalListado");
        //    }
        //    if ( personaNaturalListado.Where(mo => mo.IdPersonaNatural <= 0).Count() > 0 ) {
        //        throw new ArgumentException(MensajeExcepcion.IdentificadorObjetoNoValidoListado, "personaNaturalListado");
        //    }
        //    //Validando Objetos      
        //    if ( personaNaturalListado.Where(x => x.EstaActivo == true).Any() ) {
        //        personaNaturalListado.Where(x => x.EstaActivo == true).
        //            All(x => { x.AgregarReglaInfringida("", MensajeReglaNegocio.RegistroEstaActivo, "EstaActivo"); return true; });
        //        return false;
        //    }
        //    //validando el estado en la base de datos
        //    personaNaturalListadoActual = ObtenerListadoPersonaNatural(personaNaturalListado.Select(x => x.IdPersonaNatural).ToList(),
        //   new Inclusiones.InclusionPersonaNatural() { Topografos = true, PersonaJuridicas = true, Abogados = true, EmpleadoHijos = true, ActivoColecciones = Activo.Si, RegistroBloqueo = true });
        //    if ( personaNaturalListadoActual.Where(x => x.EstaBloqueado == true).Any() ) {
        //        personaNaturalListado.Where(x => x.EstaBloqueado == true).
        //            All(x => { x.AgregarReglaInfringida("", MensajeReglaNegocio.RegistroEstaActivo, "EstaActivo"); return true; });
        //        return false;
        //    }
        //    if ( personaNaturalListadoActual.Where(x => x.EstaActivo == true).Any() ) {
        //        personaNaturalListado.Where(x => x.EstaActivo == true).
        //            All(x => { x.AgregarReglaInfringida("", MensajeReglaNegocio.RegistroEstaActivo, "EstaActivo"); return true; });
        //        return false;
        //    }

        //    //Resultado
        //    return FachadaAdmAD.DarAltaListadoPersonaNatural(personaNaturalListado.Select(m => m.IdPersonaNatural).ToList());
        //}

        ///// <author>Ernesto Medrano</author>
        ///// <creationdate>16-sep-2015</creationdate>
        ///// <summary>
        ///// Método para dar de baja al objeto de tipo PersonaNatural; 
        ///// Cambia el estado del objeto a "False".
        ///// </summary>
        ///// <param name="personaNatural">Objeto a ser dado de baja.</param>
        ///// <returns>True: Operación exitosa</returns>
        //public Boolean DarBajaPersonaNatural(Entidades.Persona.PersonaNatural personaNatural) {
        //    //Declaraciones
        //    Entidades.Persona.PersonaNatural personaNaturalActual;

        //    //Operaciones
        //    if ( personaNatural == null ) {
        //        throw new ArgumentNullException("personaNatural", MensajeExcepcion.ParametroEnNulo);
        //    }
        //    if ( personaNatural.IdPersonaNatural <= 0 ) {
        //        throw new ArgumentException(MensajeExcepcion.IdentificadorObjetoNoValido, "personaNatural");
        //    }
        //    if ( personaNatural.EstaActivo == false ) {
        //        personaNatural.AgregarReglaInfringida("", MensajeReglaNegocio.RegistroEstaInactivo, "EstaActivo");
        //        return false;
        //    }
        //    personaNaturalActual = ObtenerPersonaNatural(personaNatural.IdPersonaNatural,
        //    new Inclusiones.InclusionPersonaNatural() { Topografos = true, PersonaJuridicas = true, Abogados = true, EmpleadoHijos = true, ActivoColecciones = Activo.Todos, RegistroBloqueo = true });

        //    if ( personaNaturalActual.EstaBloqueado == true ) {
        //        personaNatural.AgregarReglaInfringida("", MensajeReglaNegocio.RegistroEstaBloqueado, "EstaBloqueado");
        //        return false;
        //    }

        //    if ( personaNaturalActual.EstaActivo == false ) {
        //        personaNatural.AgregarReglaInfringida("", MensajeReglaNegocio.RegistroEstaInactivo, "EstaActivo");
        //        return false;
        //    }
        //    if ( personaNaturalActual.Topografos != null ) {
        //        if ( personaNaturalActual.Topografos.Any() ) {
        //            personaNatural.AgregarReglaInfringida("", String.Format(MensajeReglaNegocio.DardeBajaRegistroAsociados, "PersonaNatural", "Topografos"), "Topografos");
        //            return false;
        //        }
        //    }
        //    if ( personaNaturalActual.PersonaJuridicas != null ) {
        //        if ( personaNaturalActual.PersonaJuridicas.Any() ) {
        //            personaNatural.AgregarReglaInfringida("", String.Format(MensajeReglaNegocio.DardeBajaRegistroAsociados, "PersonaNatural", "PersonaJuridicas"), "PersonaJuridicas");
        //            return false;
        //        }
        //    }
        //    if ( personaNaturalActual.Abogados != null ) {
        //        if ( personaNaturalActual.Abogados.Any() ) {
        //            personaNatural.AgregarReglaInfringida("", String.Format(MensajeReglaNegocio.DardeBajaRegistroAsociados, "PersonaNatural", "Abogados"), "Abogados");
        //            return false;
        //        }
        //    }
        //    if ( personaNaturalActual.EmpleadoHijos != null ) {
        //        if ( personaNaturalActual.EmpleadoHijos.Any() ) {
        //            personaNatural.AgregarReglaInfringida("", String.Format(MensajeReglaNegocio.DardeBajaRegistroAsociados, "PersonaNatural", "EmpleadoHijos"), "EmpleadoHijos");
        //            return false;
        //        }
        //    }

        //    //Resultado
        //    return FachadaAdmAD.DarBajaPersonaNatural(personaNatural.IdPersonaNatural);
        //}

        ///// <author>Ernesto Medrano</author>
        ///// <creationdate>16-sep-2015</creationdate>
        ///// <summary>
        ///// Método para dar de baja al listado de objeto de tipo PersonaNatural.
        ///// Cambian los campos EstaActivo a True.
        ///// </summary>
        ///// <param name="personaNaturalListado">Listado de identificadores de objetos.</param>
        ///// <returns>True: Operación exitosa.</returns>
        //public Boolean DarBajaListadoPersonaNatural(List<Entidades.Persona.PersonaNatural> personaNaturalListado) {
        //    //Declaraciones
        //    List<Entidades.Persona.PersonaNatural> personaNaturalListadoActual;

        //    //Operaciones
        //    if ( personaNaturalListado == null ) {
        //        throw new ArgumentNullException("personaNaturalListado", MensajeExcepcion.ParametroEnNulo);
        //    }
        //    if ( personaNaturalListado.Count() <= 0 ) {
        //        throw new ArgumentException(MensajeExcepcion.ParametroListaVacia, "personaNaturalListado");
        //    }
        //    if ( personaNaturalListado.Where(mo => mo.IdPersonaNatural <= 0).Count() > 0 ) {
        //        throw new ArgumentException(MensajeExcepcion.IdentificadorObjetoNoValidoListado, "personaNaturalListado");
        //    }

        //    //Validando Objetos            
        //    if ( personaNaturalListado.Where(x => x.EstaActivo == false).Any() ) {
        //        personaNaturalListado.Where(x => x.EstaActivo == false).
        //            All(x => { x.AgregarReglaInfringida("", MensajeReglaNegocio.RegistroEstaInactivo, "EstaActivo"); return true; });
        //        return false;
        //    }

        //    //validando si tiene registros asociados.

        //    personaNaturalListadoActual = ObtenerListadoPersonaNatural(personaNaturalListado.Select(x => x.IdPersonaNatural).ToList(),
        //     new Inclusiones.InclusionPersonaNatural() { Topografos = true, PersonaJuridicas = true, Abogados = true, EmpleadoHijos = true, ActivoColecciones = Activo.Si, RegistroBloqueo = true });

        //    if ( personaNaturalListadoActual.Where(x => x.EstaBloqueado == true).Any() ) {
        //        personaNaturalListadoActual.Where(x => x.EstaBloqueado == true).
        //            All(x => { x.AgregarReglaInfringida("", MensajeReglaNegocio.RegistroEstaBloqueado, "EstaBloqueado"); return true; });
        //        return false;
        //    }

        //    if ( personaNaturalListadoActual.Where(x => x.EstaActivo == false).Any() ) {
        //        personaNaturalListadoActual.Where(x => x.EstaActivo == false).
        //            All(x => { x.AgregarReglaInfringida("", MensajeReglaNegocio.RegistroEstaInactivo, "EstaActivo"); return true; });
        //        return false;
        //    }
        //    if ( personaNaturalListadoActual.Where(x => x.Topografos != null).Any(x => x.Topografos.Any()) ) {
        //        personaNaturalListadoActual.Where(x => x.Topografos.Any()).
        //            All(x => { personaNaturalListado.Where(l => l.IdPersonaNatural == x.IdPersonaNatural).Where(l => l != null).All(l => { l.AgregarReglaInfringida("", String.Format(MensajeReglaNegocio.DardeBajaRegistroAsociados, "PersonaNatural", "Topografos"), "Topografos"); return true; }); return true; });
        //        return false;
        //    }
        //    if ( personaNaturalListadoActual.Where(x => x.PersonaJuridicas != null).Any(x => x.PersonaJuridicas.Any()) ) {
        //        personaNaturalListadoActual.Where(x => x.PersonaJuridicas.Any()).
        //            All(x => { personaNaturalListado.Where(l => l.IdPersonaNatural == x.IdPersonaNatural).Where(l => l != null).All(l => { l.AgregarReglaInfringida("", String.Format(MensajeReglaNegocio.DardeBajaRegistroAsociados, "PersonaNatural", "PersonaJuridicas"), "PersonaJuridicas"); return true; }); return true; });
        //        return false;
        //    }
        //    if ( personaNaturalListadoActual.Where(x => x.Abogados != null).Any(x => x.Abogados.Any()) ) {
        //        personaNaturalListadoActual.Where(x => x.Abogados.Any()).
        //            All(x => { personaNaturalListado.Where(l => l.IdPersonaNatural == x.IdPersonaNatural).Where(l => l != null).All(l => { l.AgregarReglaInfringida("", String.Format(MensajeReglaNegocio.DardeBajaRegistroAsociados, "PersonaNatural", "Abogados"), "Abogados"); return true; }); return true; });
        //        return false;
        //    }
        //    if ( personaNaturalListadoActual.Where(x => x.EmpleadoHijos != null).Any(x => x.EmpleadoHijos.Any()) ) {
        //        personaNaturalListadoActual.Where(x => x.EmpleadoHijos.Any()).
        //            All(x => { personaNaturalListado.Where(l => l.IdPersonaNatural == x.IdPersonaNatural).Where(l => l != null).All(l => { l.AgregarReglaInfringida("", String.Format(MensajeReglaNegocio.DardeBajaRegistroAsociados, "PersonaNatural", "EmpleadoHijos"), "EmpleadoHijos"); return true; }); return true; });
        //        return false;
        //    }

        //    //Resultado
        //    return FachadaAdmAD.DarBajaListadoPersonaNatural(personaNaturalListado.Select(m => m.IdPersonaNatural).ToList());
        //}

        ///// <author>Ernesto Medrano</author>
        ///// <creationdate>16-sep-2015</creationdate>
        ///// <summary>
        ///// Método para eliminar un objeto de tipo PersonaNatural. 
        ///// </summary>
        ///// <param name="personaNatural">Objeto a ser eliminado.</param>
        ///// <returns>True: Operación exitosa</returns>
        //public Boolean EliminarPersonaNatural(Entidades.Persona.PersonaNatural personaNatural) {
        //    //Declaraciones
        //    Boolean resultado = true;
        //    //TransactionScope transaccion;
        //    Entidades.Persona.PersonaNatural personaNaturalSeleccionado;

        //    //Operaciones
        //    if ( personaNatural == null ) {
        //        throw new ArgumentNullException("personaNatural", MensajeExcepcion.ParametroEnNulo);
        //    }
        //    if ( personaNatural.IdPersonaNatural <= 0 ) {
        //        throw new ArgumentException(MensajeExcepcion.IdentificadorObjetoNoValido, "personaNatural");
        //    }
        //    //Verificando colecciones (excluyendo colecciones M:M)

        //    personaNaturalSeleccionado = ObtenerPersonaNatural(personaNatural.IdPersonaNatural,
        //     new Inclusiones.InclusionPersonaNatural() { Topografos = true, PersonaJuridicas = true, Abogados = true, EmpleadoHijos = true, ActivoColecciones = Activo.Todos, RegistroBloqueo = true });

        //    if ( personaNaturalSeleccionado.EstaBloqueado == true ) {
        //        personaNatural.AgregarReglaInfringida("", MensajeReglaNegocio.RegistroEstaBloqueado, "EstaBloqueado");
        //        return false;
        //    }
        //    if ( personaNaturalSeleccionado.Topografos != null ) {
        //        if ( personaNaturalSeleccionado.Topografos.Any() ) {
        //            personaNatural.AgregarReglaInfringida("", String.Format(MensajeReglaNegocio.EliminacionRegistrosAsociados, "PersonaNatural", "Topografos"), "Topografos");
        //            return false;
        //        }
        //    }
        //    if ( personaNaturalSeleccionado.PersonaJuridicas != null ) {
        //        if ( personaNaturalSeleccionado.PersonaJuridicas.Any() ) {
        //            personaNatural.AgregarReglaInfringida("", String.Format(MensajeReglaNegocio.EliminacionRegistrosAsociados, "PersonaNatural", "PersonaJuridicas"), "PersonaJuridicas");
        //            return false;
        //        }
        //    }
        //    if ( personaNaturalSeleccionado.Abogados != null ) {
        //        if ( personaNaturalSeleccionado.Abogados.Any() ) {
        //            personaNatural.AgregarReglaInfringida("", String.Format(MensajeReglaNegocio.EliminacionRegistrosAsociados, "PersonaNatural", "Abogados"), "Abogados");
        //            return false;
        //        }
        //    }
        //    if ( personaNaturalSeleccionado.EmpleadoHijos != null ) {
        //        if ( personaNaturalSeleccionado.EmpleadoHijos.Any() ) {
        //            personaNatural.AgregarReglaInfringida("", String.Format(MensajeReglaNegocio.EliminacionRegistrosAsociados, "PersonaNatural", "EmpleadoHijos"), "EmpleadoHijos");
        //            return false;
        //        }
        //    }
        //    if ( resultado != false ) {
        //        resultado = FachadaAdmAD.EliminarPersonaNatural(personaNaturalSeleccionado.IdPersonaNatural);
        //    }

        //    //Resultado
        //    return resultado;
        //}

        ///// <author>Ernesto Medrano</author>
        ///// <creationdate>16-sep-2015</creationdate>
        ///// <summary>
        ///// Método para eliminar un listado de objetos de tipo PersonaNatural.
        ///// </summary>
        ///// <param name="personaNaturalListado">Listado de identificadores de objetos.</param>
        ///// <returns>True: Operación exitosa</returns>
        //public Boolean EliminarListadoPersonaNatural(List<Entidades.Persona.PersonaNatural> personaNaturalListado) {
        //    //Declaraciones
        //    //TransactionScope transaccion;
        //    Entidades.Persona.PersonaNatural personaNaturalSeleccionado;
        //    //Entidades.Persona.PersonaNatural personaNatural = new Entidades.Persona.PersonaNatural();
        //    Boolean resultado = true;

        //    //Operaciones
        //    if ( personaNaturalListado == null ) {
        //        throw new ArgumentNullException("personaNaturalListado", MensajeExcepcion.ParametroEnNulo);
        //    }
        //    if ( personaNaturalListado.Count() <= 0 ) {
        //        throw new ArgumentException(MensajeExcepcion.ParametroListaVacia, "personaNaturalListado");
        //    }
        //    if ( personaNaturalListado.Where(mo => mo.IdPersonaNatural <= 0).Count() > 0 ) {
        //        throw new ArgumentException(MensajeExcepcion.IdentificadorObjetoNoValidoListado, "personaNaturalListado");
        //    }
        //    // using ( transaccion = new TransactionScope() ) {
        //    foreach ( var personaNatural in personaNaturalListado ) {
        //        personaNaturalSeleccionado = ObtenerPersonaNatural(personaNatural.IdPersonaNatural,
        //            new Inclusiones.InclusionPersonaNatural() { Topografos = true, PersonaJuridicas = true, Abogados = true, EmpleadoHijos = true, ActivoColecciones = Activo.Todos, RegistroBloqueo = true });

        //        if ( personaNaturalSeleccionado.EstaBloqueado == true ) {
        //            personaNatural.AgregarReglaInfringida("", MensajeReglaNegocio.RegistroEstaBloqueado, "EstaBloqueado");
        //            return false;
        //        }
        //        if ( personaNaturalSeleccionado.Topografos != null ) {
        //            if ( personaNaturalSeleccionado.Topografos.Any() ) {
        //                personaNatural.AgregarReglaInfringida("", String.Format(MensajeReglaNegocio.EliminacionRegistrosAsociados, "PersonaNatural", "Topografos"), "Topografos");
        //                return false;
        //            }
        //        }
        //        if ( personaNaturalSeleccionado.PersonaJuridicas != null ) {
        //            if ( personaNaturalSeleccionado.PersonaJuridicas.Any() ) {
        //                personaNatural.AgregarReglaInfringida("", String.Format(MensajeReglaNegocio.EliminacionRegistrosAsociados, "PersonaNatural", "PersonaJuridicas"), "PersonaJuridicas");
        //                return false;
        //            }
        //        }
        //        if ( personaNaturalSeleccionado.Abogados != null ) {
        //            if ( personaNaturalSeleccionado.Abogados.Any() ) {
        //                personaNatural.AgregarReglaInfringida("", String.Format(MensajeReglaNegocio.EliminacionRegistrosAsociados, "PersonaNatural", "Abogados"), "Abogados");
        //                return false;
        //            }
        //        }
        //        if ( personaNaturalSeleccionado.EmpleadoHijos != null ) {
        //            if ( personaNaturalSeleccionado.EmpleadoHijos.Any() ) {
        //                personaNatural.AgregarReglaInfringida("", String.Format(MensajeReglaNegocio.EliminacionRegistrosAsociados, "PersonaNatural", "EmpleadoHijos"), "EmpleadoHijos");
        //                return false;
        //            }
        //        }
        //        if ( resultado != false ) {
        //            resultado = FachadaAdmAD.EliminarPersonaNatural(personaNaturalSeleccionado.IdPersonaNatural);
        //        }
        //    }
        //    //    if ( resultado == true ) {
        //    //        transaccion.Complete();
        //    //    }
        //    //}

        //    //Resultado            
        //    return resultado;
        //}

        ///// <author>Ernesto Medrano</author>
        ///// <creationdate>16-sep-2015</creationdate>
        ///// <summary>
        ///// Método para obtener un componente PersonaNatural, y sus Colecciones.
        ///// </summary>
        ///// <param name="idPersonaNatural">Identificador del objeto.</param>
        ///// <param name="inclusionPersonaNatural">Indica si se cargaran las colecciones del objeto PersonaNatural       
        ///// <returns>Retorna un objeto de tipo PersonaNatural.</returns>
        //public Entidades.Persona.PersonaNatural ObtenerPersonaNatural(Int32 idPersonaNatural, Inclusiones.InclusionPersonaNatural inclusionPersonaNatural = null) {
        //    //Declaraciones
        //    Entidades.Persona.PersonaNatural personaNatural;
        //    String nombreBaseDatos;
        //    List<RegistroBloqueo> registroBloqueoTopografos;
        //    List<RegistroBloqueo> registroBloqueoPersonaJuridicas;
        //    List<RegistroBloqueo> registroBloqueoGrupoPersonaNaturales;
        //    List<RegistroBloqueo> registroBloqueoAbogados;
        //    List<RegistroBloqueo> registroBloqueoEmpleadoHijos;

        //    //Operaciones
        //    if ( idPersonaNatural <= 0 ) {
        //        throw new ArgumentException(MensajeExcepcion.IdentificadorObjetoNoValido, "idPersonaNatural");
        //    }
        //    nombreBaseDatos = ManejadorConfiguracion.ObtenerValor("administracionConfig", "baseDatosConfig", "BaseDatos");
        //    personaNatural = FachadaAdmAD.ObtenerPersonaNatural(idPersonaNatural);
        //    if ( personaNatural != null && inclusionPersonaNatural != null ) {
        //        //Propiedades complejas
        //        if ( inclusionPersonaNatural.Persona == true ) {
        //            personaNatural.Persona = FachadaAdmAD.ObtenerPersona(personaNatural.Persona.IdPersona);
        //        }
        //        if ( inclusionPersonaNatural.Genero == true ) {
        //            personaNatural.Genero = FachadaAdmAD.ObtenerValor(personaNatural.Genero.IdValor);
        //        }
        //        if ( inclusionPersonaNatural.EstadoCivil == true ) {
        //            personaNatural.EstadoCivil = FachadaAdmAD.ObtenerValor(personaNatural.EstadoCivil.IdValor);
        //        }
        //        if ( inclusionPersonaNatural.Ocupacion == true ) {
        //            personaNatural.Ocupacion = FachadaAdmAD.ObtenerValor(personaNatural.Ocupacion.IdValor);
        //        }
        //        //Propiedades de colección
        //        if ( inclusionPersonaNatural.Topografos == true ) {
        //            personaNatural.Topografos = FachadaAdmAD.ObtenerListadoTopografoPorIdPersonaNatural(idPersonaNatural, inclusionPersonaNatural.ActivoColecciones);
        //        }
        //        if ( inclusionPersonaNatural.PersonaJuridicas == true ) {
        //            personaNatural.PersonaJuridicas = FachadaAdmAD.ObtenerListadoPersonaJuridicaPorIdRepresentanteLegal(idPersonaNatural, inclusionPersonaNatural.ActivoColecciones);
        //        }
        //        if ( inclusionPersonaNatural.Abogados == true ) {
        //            personaNatural.Abogados = FachadaAdmAD.ObtenerListadoAbogadoPorIdPersonaNatural(idPersonaNatural, inclusionPersonaNatural.ActivoColecciones);
        //        }
        //        if ( inclusionPersonaNatural.EmpleadoHijos == true ) {
        //            personaNatural.EmpleadoHijos = FachadaAdmAD.ObtenerListadoEmpleadoPorPersonaNatural(idPersonaNatural, inclusionPersonaNatural.ActivoColecciones);
        //        }
        //        if ( inclusionPersonaNatural.RegistroBloqueo == true ) {
        //            try {
        //                personaNatural.RegistroBloqueo = ManejadorBloqueo.ObtenerDatosBloqueo(idPersonaNatural, EntidadTabla.PersonaNatural, nombreBaseDatos);
        //                if ( personaNatural.RegistroBloqueo != null ) {
        //                    personaNatural.EstaBloqueado = true;
        //                }
        //            } catch ( RegistroNoEncontradoExcepcion ) {
        //                personaNatural.RegistroBloqueo = null;
        //                personaNatural.EstaBloqueado = true;
        //            }
        //        }
        //        //Cargando registrobloqueo para las colecciones.
        //        if ( inclusionPersonaNatural.Topografos == true && personaNatural.Topografos != null ) {
        //            registroBloqueoTopografos = ManejadorBloqueo.ObtenerDatosBloqueoListado(EntidadTabla.Topografo, nombreBaseDatos, personaNatural.Topografos.Select(x => x.IdTopografo).ToList());
        //            personaNatural.Topografos.All(l => { l.RegistroBloqueo = registroBloqueoTopografos.FirstOrDefault(x => x.IdRegistro == l.IdTopografo); return true; });
        //            personaNatural.Topografos.Where(x => x.RegistroBloqueo != null).All(l => { l.EstaBloqueado = true; return true; });
        //        }
        //        if ( inclusionPersonaNatural.PersonaJuridicas == true && personaNatural.PersonaJuridicas != null ) {
        //            registroBloqueoPersonaJuridicas = ManejadorBloqueo.ObtenerDatosBloqueoListado(EntidadTabla.PersonaJuridica, nombreBaseDatos, personaNatural.PersonaJuridicas.Select(x => x.IdPersonaJuridica).ToList());
        //            personaNatural.PersonaJuridicas.All(l => { l.RegistroBloqueo = registroBloqueoPersonaJuridicas.FirstOrDefault(x => x.IdRegistro == l.IdPersonaJuridica); return true; });
        //            personaNatural.PersonaJuridicas.Where(x => x.RegistroBloqueo != null).All(l => { l.EstaBloqueado = true; return true; });
        //        }
        //        if ( inclusionPersonaNatural.Abogados == true && personaNatural.Abogados != null ) {
        //            registroBloqueoAbogados = ManejadorBloqueo.ObtenerDatosBloqueoListado(EntidadTabla.Abogado, nombreBaseDatos, personaNatural.Abogados.Select(x => x.IdAbogado).ToList());
        //            personaNatural.Abogados.All(l => { l.RegistroBloqueo = registroBloqueoAbogados.FirstOrDefault(x => x.IdRegistro == l.IdAbogado); return true; });
        //            personaNatural.Abogados.Where(x => x.RegistroBloqueo != null).All(l => { l.EstaBloqueado = true; return true; });
        //        }
        //        if ( inclusionPersonaNatural.EmpleadoHijos == true && personaNatural.EmpleadoHijos != null ) {
        //            registroBloqueoEmpleadoHijos = ManejadorBloqueo.ObtenerDatosBloqueoListado(EntidadTabla.Empleado, nombreBaseDatos, personaNatural.EmpleadoHijos.Select(x => x.IdEmpleado).ToList());
        //            personaNatural.EmpleadoHijos.All(l => { l.RegistroBloqueo = registroBloqueoEmpleadoHijos.FirstOrDefault(x => x.IdRegistro == l.IdEmpleado); return true; });
        //            personaNatural.EmpleadoHijos.Where(x => x.RegistroBloqueo != null).All(l => { l.EstaBloqueado = true; return true; });
        //        }
        //    }

        //    //Resultado
        //    return personaNatural;
        //}

        ///// <author>Ernesto Medrano</author>
        ///// <creationdate>16-sep-2015</creationdate>
        ///// <summary>
        ///// Método para obtener un listado de objetos de tipo PersonaNatural.
        ///// </summary>
        ///// <param name="activo">Estado de los Objetos de tipo PersonaNatural.</param>
        ///// <param name="inclusionPersonaNatural">Indica si se cargaran las colecciones del objeto PersonaNatural 
        ///// que posee el componente.</param>
        ///// <returns></returns>
        //public List<Entidades.Persona.PersonaNatural> ObtenerListadoPersonaNatural(Activo activo, Inclusiones.InclusionPersonaNatural inclusionPersonaNatural = null) {

        //    //Declaraciones
        //    List<Entidades.Persona.PersonaNatural> personaNaturalListado;
        //    List<RegistroBloqueo> registroBloqueoListado;

        //    List<RegistroBloqueo> registroBloqueoTopografos;
        //    List<RegistroBloqueo> registroBloqueoPersonaJuridicas;
        //    List<RegistroBloqueo> registroBloqueoGrupoPersonaNaturales;
        //    List<RegistroBloqueo> registroBloqueoAbogados;
        //    List<RegistroBloqueo> registroBloqueoEmpleadoHijos;
        //    List<Int32> idPersonaNaturalListado;
        //    String nombreBaseDatos;

        //    //Operaciones
        //    if ( !Enum.IsDefined(typeof(Activo), activo) ) {
        //        throw new ArgumentOutOfRangeException("activo", MensajeExcepcion.EnumeracionValorInvalido);
        //    }

        //    nombreBaseDatos = ManejadorConfiguracion.ObtenerValor("administracionConfig", "baseDatosConfig", "BaseDatos");
        //    personaNaturalListado = FachadaAdmAD.ObtenerListadoPersonaNatural(activo);

        //    if ( personaNaturalListado.Count > 0 && inclusionPersonaNatural != null ) {

        //        //Extrayendo Ids
        //        idPersonaNaturalListado = personaNaturalListado.Select(x => x.IdPersonaNatural).ToList();

        //        //Propiedades complejas
        //        if ( inclusionPersonaNatural.Persona == true ) {
        //            var personaListado = ObtenerListadoPersona(personaNaturalListado.Select(p => p.Persona.IdPersona).ToList(), new Inclusiones.InclusionPersona() { PersonaIdentificaciones = true });
        //            personaNaturalListado.All(l => { l.Persona = personaListado.FirstOrDefault(x => x.IdPersona == l.Persona.IdPersona); return true; });
        //        }

        //        if ( inclusionPersonaNatural.Genero == true ) {
        //            var generoListado = FachadaAdmAD.ObtenerListadoValor(personaNaturalListado.Select(p => p.Genero.IdValor).Distinct().ToList());
        //            personaNaturalListado.All(l => { l.Genero = generoListado.FirstOrDefault(x => x.IdValor == l.Genero.IdValor); return true; });
        //        }

        //        if ( inclusionPersonaNatural.EstadoCivil == true ) {
        //            var estadoCivilListado = FachadaAdmAD.ObtenerListadoValor(personaNaturalListado.Select(p => p.EstadoCivil.IdValor).Distinct().ToList());
        //            personaNaturalListado.All(l => { l.EstadoCivil = estadoCivilListado.FirstOrDefault(x => x.IdValor == l.EstadoCivil.IdValor); return true; });
        //        }

        //        if ( inclusionPersonaNatural.Ocupacion == true ) {
        //            var ocupacionListado = FachadaAdmAD.ObtenerListadoValor(personaNaturalListado.Select(p => p.Ocupacion.IdValor).Distinct().ToList());
        //            personaNaturalListado.All(l => { l.Ocupacion = ocupacionListado.FirstOrDefault(x => x.IdValor == l.Ocupacion.IdValor); return true; });
        //        }

        //        //Cargando Registro Bloqueo para las Cuentas
        //        if ( inclusionPersonaNatural.RegistroBloqueo == true ) {
        //            registroBloqueoListado = ManejadorBloqueo.ObtenerDatosBloqueoListado(EntidadTabla.PersonaNatural, nombreBaseDatos, idPersonaNaturalListado);
        //            personaNaturalListado.All(l => { l.RegistroBloqueo = registroBloqueoListado.FirstOrDefault(x => x.IdRegistro == l.IdPersonaNatural); return true; });
        //            personaNaturalListado.Where(x => x.RegistroBloqueo != null).All(l => { l.EstaBloqueado = true; return true; });
        //        }

        //        if ( inclusionPersonaNatural.Topografos == true ) {
        //            var topografosListado = FachadaAdmAD.ObtenerListadoTopografoPorListadoIdPersonaNatural(idPersonaNaturalListado, inclusionPersonaNatural.ActivoColecciones);
        //            if ( inclusionPersonaNatural.RegistroBloqueo == true ) {
        //                registroBloqueoTopografos = ManejadorBloqueo.ObtenerDatosBloqueoListado(EntidadTabla.Topografo, nombreBaseDatos, topografosListado.Select(x => x.IdTopografo).ToList());
        //                topografosListado.All(l => { l.RegistroBloqueo = registroBloqueoTopografos.FirstOrDefault(x => x.IdRegistro == l.IdTopografo); return true; });
        //                topografosListado.Where(x => x.RegistroBloqueo != null).All(l => { l.EstaBloqueado = true; return true; });
        //            }
        //            personaNaturalListado.All(l => { l.Topografos = topografosListado.Where(x => x.PersonaNatural.IdPersonaNatural == l.IdPersonaNatural).ToList(); return true; });
        //        }

        //        if ( inclusionPersonaNatural.PersonaJuridicas == true ) {
        //            var personaJuridicasListado = FachadaAdmAD.ObtenerListadoPersonaJuridicaPorListadoIdRepresentanteLegal(idPersonaNaturalListado, inclusionPersonaNatural.ActivoColecciones);
        //            if ( inclusionPersonaNatural.RegistroBloqueo == true ) {
        //                registroBloqueoPersonaJuridicas = ManejadorBloqueo.ObtenerDatosBloqueoListado(EntidadTabla.PersonaJuridica, nombreBaseDatos, personaJuridicasListado.Select(x => x.IdPersonaJuridica).ToList());
        //                personaJuridicasListado.All(l => { l.RegistroBloqueo = registroBloqueoPersonaJuridicas.FirstOrDefault(x => x.IdRegistro == l.IdPersonaJuridica); return true; });
        //                personaJuridicasListado.Where(x => x.RegistroBloqueo != null).All(l => { l.EstaBloqueado = true; return true; });
        //            }
        //            personaNaturalListado.All(l => { l.PersonaJuridicas = personaJuridicasListado.Where(x => x.RepresentanteLegal.IdPersonaNatural == l.IdPersonaNatural).ToList(); return true; });
        //        }

        //        if ( inclusionPersonaNatural.Abogados == true ) {
        //            var abogadosListado = FachadaAdmAD.ObtenerListadoAbogadoPorListadoIdPersonaNatural(idPersonaNaturalListado, inclusionPersonaNatural.ActivoColecciones);
        //            if ( inclusionPersonaNatural.RegistroBloqueo == true ) {
        //                registroBloqueoAbogados = ManejadorBloqueo.ObtenerDatosBloqueoListado(EntidadTabla.Abogado, nombreBaseDatos, abogadosListado.Select(x => x.IdAbogado).ToList());
        //                abogadosListado.All(l => { l.RegistroBloqueo = registroBloqueoAbogados.FirstOrDefault(x => x.IdRegistro == l.IdAbogado); return true; });
        //                abogadosListado.Where(x => x.RegistroBloqueo != null).All(l => { l.EstaBloqueado = true; return true; });
        //            }
        //            personaNaturalListado.All(l => { l.Abogados = abogadosListado.Where(x => x.PersonaNatural.IdPersonaNatural == l.IdPersonaNatural).ToList(); return true; });
        //        }

        //        if ( inclusionPersonaNatural.EmpleadoHijos == true ) {
        //            var empleadoHijosListado = FachadaAdmAD.ObtenerListadoEmpleadoPorPersonaNatural(idPersonaNaturalListado, inclusionPersonaNatural.ActivoColecciones);
        //            if ( inclusionPersonaNatural.RegistroBloqueo == true ) {
        //                registroBloqueoEmpleadoHijos = ManejadorBloqueo.ObtenerDatosBloqueoListado(EntidadTabla.Empleado, nombreBaseDatos, empleadoHijosListado.Select(x => x.IdEmpleado).ToList());
        //                empleadoHijosListado.All(l => { l.RegistroBloqueo = registroBloqueoEmpleadoHijos.FirstOrDefault(x => x.IdRegistro == l.IdEmpleado); return true; });
        //                empleadoHijosListado.Where(x => x.RegistroBloqueo != null).All(l => { l.EstaBloqueado = true; return true; });
        //            }
        //            personaNaturalListado.All(l => { l.EmpleadoHijos = empleadoHijosListado.Where(x => x.PersonaNatural.IdPersonaNatural == l.IdPersonaNatural).ToList(); return true; });
        //        }
        //    }

        //    //Resultado
        //    return personaNaturalListado;
        //}

        ///// <author>Ernesto Medrano</author>
        ///// <creationdate>16-sep-2015</creationdate>
        ///// <summary>
        ///// Método para obtener un listado de objetos de tipo PersonaNatural.
        ///// </summary>
        ///// <param name="idPersonaNaturalListado">Lisrtado de identificador de objetos.</param>
        ///// <param name="inclusionOpcionUsuario">Indica si se cargaran las colecciones
        ///// que posee el componente.</param>
        ///// <returns></returns>
        //public List<Entidades.Persona.PersonaNatural> ObtenerListadoPersonaNatural(List<Int32> idPersonaNaturalListado, Inclusiones.InclusionPersonaNatural inclusionPersonaNatural = null) {

        //    //Declaraciones
        //    List<Entidades.Persona.PersonaNatural> personaNaturalListado;
        //    //List<Entidades.Persona.OpcionUsuario> listadoOpcionUsuario;

        //    List<RegistroBloqueo> listadoRegistroBloqueo;

        //    List<RegistroBloqueo> registroBloqueoTopografos;
        //    List<RegistroBloqueo> registroBloqueoPersonaJuridicas;
        //    List<RegistroBloqueo> registroBloqueoAbogados;
        //    List<RegistroBloqueo> registroBloqueoEmpleadoHijos;
        //    List<Int32> listadoIdPersonaNatural;
        //    String nombreBaseDatos;

        //    //Operaciones
        //    if ( idPersonaNaturalListado == null ) {
        //        throw new ArgumentNullException("idPersonaNaturalListado", MensajeExcepcion.ParametroEnNulo);
        //    }

        //    if ( idPersonaNaturalListado.Count() == 0 ) {
        //        throw new ArgumentException(MensajeExcepcion.ParametroListaVacia, "idPersonaNaturalListado");
        //    }

        //    if ( idPersonaNaturalListado.Where(l => l <= 0).Count() > 0 ) {
        //        throw new ArgumentException(MensajeExcepcion.IdentificadorObjetoNoValidoListado, "idPersonaNaturalListado");
        //    }

        //    nombreBaseDatos = ManejadorConfiguracion.ObtenerValor("administracionConfig", "baseDatosConfig", "BaseDatos");
        //    personaNaturalListado = FachadaAdmAD.ObtenerListadoPersonaNatural(idPersonaNaturalListado);

        //    if ( personaNaturalListado.Count > 0 && inclusionPersonaNatural != null ) {

        //        //Extrayendo Ids
        //        listadoIdPersonaNatural = personaNaturalListado.Select(x => x.IdPersonaNatural).ToList();

        //        //Propiedades complejas
        //        if ( inclusionPersonaNatural.Persona == true ) {
        //            var personaListado = FachadaAdmAD.ObtenerListadoPersona(personaNaturalListado.Select(p => p.Persona.IdPersona).ToList());
        //            personaNaturalListado.All(l => { l.Persona = personaListado.FirstOrDefault(x => x.IdPersona == l.Persona.IdPersona); return true; });
        //        }

        //        if ( inclusionPersonaNatural.Genero == true ) {
        //            var generoListado = FachadaAdmAD.ObtenerListadoValor(personaNaturalListado.Select(p => p.Genero.IdValor).ToList());
        //            personaNaturalListado.All(l => { l.Genero = generoListado.FirstOrDefault(x => x.IdValor == l.Genero.IdValor); return true; });
        //        }

        //        if ( inclusionPersonaNatural.EstadoCivil == true ) {
        //            var estadoCivilListado = FachadaAdmAD.ObtenerListadoValor(personaNaturalListado.Select(p => p.EstadoCivil.IdValor).ToList());
        //            personaNaturalListado.All(l => { l.Genero = estadoCivilListado.FirstOrDefault(x => x.IdValor == l.EstadoCivil.IdValor); return true; });
        //        }

        //        if ( inclusionPersonaNatural.Ocupacion == true ) {
        //            var ocupacionListado = FachadaAdmAD.ObtenerListadoValor(personaNaturalListado.Select(p => p.Ocupacion.IdValor).ToList());
        //            personaNaturalListado.All(l => { l.Ocupacion = ocupacionListado.FirstOrDefault(x => x.IdValor == l.Ocupacion.IdValor); return true; });
        //        }

        //        //Cargando Registro Bloqueo para las Cuentas
        //        if ( inclusionPersonaNatural.RegistroBloqueo == true ) {
        //            listadoRegistroBloqueo = ManejadorBloqueo.ObtenerDatosBloqueoListado(EntidadTabla.PersonaNatural, nombreBaseDatos, listadoIdPersonaNatural);
        //            personaNaturalListado.All(l => { l.RegistroBloqueo = listadoRegistroBloqueo.FirstOrDefault(x => x.IdRegistro == l.IdPersonaNatural); return true; });
        //            personaNaturalListado.Where(x => x.RegistroBloqueo != null).All(l => { l.EstaBloqueado = true; return true; });
        //        }

        //        if ( inclusionPersonaNatural.Topografos == true ) {
        //            var topografosListado = FachadaAdmAD.ObtenerListadoTopografoPorListadoIdPersonaNatural(idPersonaNaturalListado, inclusionPersonaNatural.ActivoColecciones);
        //            if ( inclusionPersonaNatural.RegistroBloqueo == true ) {
        //                registroBloqueoTopografos = ManejadorBloqueo.ObtenerDatosBloqueoListado(EntidadTabla.Topografo, nombreBaseDatos, topografosListado.Select(x => x.IdTopografo).ToList());
        //                topografosListado.All(l => { l.RegistroBloqueo = registroBloqueoTopografos.FirstOrDefault(x => x.IdRegistro == l.IdTopografo); return true; });
        //                topografosListado.Where(x => x.RegistroBloqueo != null).All(l => { l.EstaBloqueado = true; return true; });
        //            }
        //            personaNaturalListado.All(l => { l.Topografos = topografosListado.Where(x => x.PersonaNatural.IdPersonaNatural == l.IdPersonaNatural).ToList(); return true; });
        //        }

        //        if ( inclusionPersonaNatural.PersonaJuridicas == true ) {
        //            var personaJuridicasListado = FachadaAdmAD.ObtenerListadoPersonaJuridicaPorListadoIdRepresentanteLegal(idPersonaNaturalListado, inclusionPersonaNatural.ActivoColecciones);
        //            if ( inclusionPersonaNatural.RegistroBloqueo == true ) {
        //                registroBloqueoPersonaJuridicas = ManejadorBloqueo.ObtenerDatosBloqueoListado(EntidadTabla.PersonaJuridica, nombreBaseDatos, personaJuridicasListado.Select(x => x.IdPersonaJuridica).ToList());
        //                personaJuridicasListado.All(l => { l.RegistroBloqueo = registroBloqueoPersonaJuridicas.FirstOrDefault(x => x.IdRegistro == l.IdPersonaJuridica); return true; });
        //                personaJuridicasListado.Where(x => x.RegistroBloqueo != null).All(l => { l.EstaBloqueado = true; return true; });
        //            }
        //            personaNaturalListado.All(l => { l.PersonaJuridicas = personaJuridicasListado.Where(x => x.RepresentanteLegal.IdPersonaNatural == l.IdPersonaNatural).ToList(); return true; });
        //        }

        //        if ( inclusionPersonaNatural.Abogados == true ) {
        //            var abogadosListado = FachadaAdmAD.ObtenerListadoAbogadoPorListadoIdPersonaNatural(idPersonaNaturalListado, inclusionPersonaNatural.ActivoColecciones);
        //            if ( inclusionPersonaNatural.RegistroBloqueo == true ) {
        //                registroBloqueoAbogados = ManejadorBloqueo.ObtenerDatosBloqueoListado(EntidadTabla.Abogado, nombreBaseDatos, abogadosListado.Select(x => x.IdAbogado).ToList());
        //                abogadosListado.All(l => { l.RegistroBloqueo = registroBloqueoAbogados.FirstOrDefault(x => x.IdRegistro == l.IdAbogado); return true; });
        //                abogadosListado.Where(x => x.RegistroBloqueo != null).All(l => { l.EstaBloqueado = true; return true; });
        //            }
        //            personaNaturalListado.All(l => { l.Abogados = abogadosListado.Where(x => x.PersonaNatural.IdPersonaNatural == l.IdPersonaNatural).ToList(); return true; });
        //        }

        //        if ( inclusionPersonaNatural.EmpleadoHijos == true ) {
        //            var empleadoHijosListado = FachadaAdmAD.ObtenerListadoEmpleadoPorPersonaNatural(idPersonaNaturalListado, inclusionPersonaNatural.ActivoColecciones);
        //            if ( inclusionPersonaNatural.RegistroBloqueo == true ) {
        //                registroBloqueoEmpleadoHijos = ManejadorBloqueo.ObtenerDatosBloqueoListado(EntidadTabla.Empleado, nombreBaseDatos, empleadoHijosListado.Select(x => x.IdEmpleado).ToList());
        //                empleadoHijosListado.All(l => { l.RegistroBloqueo = registroBloqueoEmpleadoHijos.FirstOrDefault(x => x.IdRegistro == l.IdEmpleado); return true; });
        //                empleadoHijosListado.Where(x => x.RegistroBloqueo != null).All(l => { l.EstaBloqueado = true; return true; });
        //            }
        //            personaNaturalListado.All(l => { l.EmpleadoHijos = empleadoHijosListado.Where(x => x.PersonaNatural.IdPersonaNatural == l.IdPersonaNatural).ToList(); return true; });
        //        }


        //    }
        //    //Resultado
        //    return personaNaturalListado;
        //}

        /// <author>Ernesto Medrano</author>
        /// <creationdate>16-sep-2015</creationdate>
        /// <summary>
        /// Metódo para validar las transacciones u operaciones
        /// que se realizan en la entidad.
        /// </summary>
        /// <change author="Jose Miguel Lopez Sevilla" changedate="18-Nov-2016">
        ///     Ajustes en la validación de persona natural para mejorar el rendimiento
        ///  </change>
        /// <param name="personaNatural">Objeto o entidad que se evalúa o valida.</param>
        /// <returns>Resultado de la Operación</returns>
        public Boolean ValidarPersonaNatural(Entidades.Persona.PersonaNatural personaNatural) {
            //Declaraciones                        
            Boolean resultado = true;
            //ReglaNegocio reglaCamposMinimos = new ReglaNegocio();
            //ReglaNegocio reglaNegocio = new ReglaNegocio();
            List<Entidades.Persona.PersonaNatural> listadoPersonaNaturalActual;

            //Operaciones
            if ( personaNatural == null ) {
                throw new ArgumentNullException("personaNatural", MensajeExcepcion.ParametroEnNulo);
            }

            #region Reglas de Negocio

            //Reglas de Negocio
            //listadoPersonaNaturalActual = FachadaAdmAD.ObtenerListadoPersonaNaturalPorCriterio(new PersonaNatural() { NombreCompleto = personaNatural.NombreCompleto }, Activo.Todos);

            //if ( listadoPersonaNaturalActual.Where(m => m.NombreCompleto.ToLower() == personaNatural.NombreCompleto.ToLower() && m.IdPersonaNatural != personaNatural.IdPersonaNatural).Count() > 0 ) {
            //    reglaNegocio.Campos.Add("NombreCompleto");
            //    reglaNegocio.Mensaje = MensajeReglaNegocio.NombreDuplicado;
            //    personaNatural.ReglasInfringidas.Add(reglaNegocio);
            //    return false;
            //}

            //if ( personaNatural.FechaNacimiento == DateTime.Today ) {
            //    reglaNegocio.Campos.Add("FechaNacimiento");
            //    reglaNegocio.Mensaje = reglaNegocio.Mensaje + Environment.NewLine + MensajeReglaNegocio.FechaIncorrecta;
            //    personaNatural.ReglasInfringidas.Add(reglaNegocio);
            //    return false;
            //}

            //if ( personaNatural.FechaNacimiento > DateTime.Today ) {
            //    reglaNegocio.Campos.Add("FechaNacimiento");
            //    reglaNegocio.Mensaje = reglaNegocio.Mensaje + Environment.NewLine + MensajeReglaNegocio.FechaMayorActual;
            //    personaNatural.ReglasInfringidas.Add(reglaNegocio);
            //    return false;
            //}

            //if ( personaNatural.FechaFallecimiento > DateTime.Today ) {
            //    reglaNegocio.Campos.Add("FechaFallecimiento");
            //    reglaNegocio.Mensaje = reglaNegocio.Mensaje + Environment.NewLine + MensajeReglaNegocio.FechaMayorActual;
            //    personaNatural.ReglasInfringidas.Add(reglaNegocio);
            //    return false;
            //}

            //if ( personaNatural.FechaNacimiento >= personaNatural.FechaFallecimiento ) {
            //    reglaNegocio.Campos.Add("FechaFallecimiento");
            //    reglaNegocio.Mensaje = reglaNegocio.Mensaje + Environment.NewLine + MensajeReglaNegocio.FechaFallecimientoMayorFechaNacimiento;
            //    personaNatural.ReglasInfringidas.Add(reglaNegocio);
            //    return false;
            //}

            //#endregion

            //Resultado
            return resultado;
        }

        ///// <author>Ernesto Medrano</author>
        ///// <creationdate>12-Jul-2016</creationdate>
        ///// <summary>
        ///// Obtiene los datos para cargarlos en el arbol de buzon.
        ///// </summary>
        ///// <param name="idCuenta"></param>
        ///// <returns></returns>
        //public List<Negocio.Entidades.Persona.VistasEstructuras.EstructuraPersonaNatural> ObtenerEstructuraPersonaNatural(Int32 inicio, Int32 fin, Int32 filtro, Int32 ubicacion, Int32 idpersonanatural, out String cantidad, out String lotes) {

        //    //Resultados
        //    return FachadaAdmAD.ObtenerEstructuraPersonaNatural(inicio, fin, filtro, ubicacion, idpersonanatural, out   cantidad, out   lotes);
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
        //public List<Entidades.Persona.PersonaNatural> ObtenerListadoPersonaNaturalPorCriterio(Activo activo, Entidades.Persona.PersonaNatural criterio, Inclusiones.InclusionPersonaNatural inclusionPersonaNatural = null) {
        //    //Declaraciones
        //    List<Entidades.Persona.PersonaNatural> personaNaturalListado;


        //    List<RegistroBloqueo> listadoRegistroBloqueo;

        //    List<RegistroBloqueo> registroBloqueoTopografos;
        //    List<RegistroBloqueo> registroBloqueoPersonaJuridicas;
        //    List<RegistroBloqueo> registroBloqueoAbogados;
        //    List<RegistroBloqueo> registroBloqueoEmpleadoHijos;
        //    List<Int32> idPersonaNaturalListado;
        //    String nombreBaseDatos;

        //    //Operaciones
        //    if ( criterio == null ) {
        //        throw new ArgumentNullException("criterio", MensajeExcepcion.ParametroEnNulo);
        //    }

        //    if ( !Enum.IsDefined(typeof(Activo), activo) ) {
        //        throw new ArgumentOutOfRangeException("activo", MensajeExcepcion.EnumeracionValorInvalido);
        //    }

        //    nombreBaseDatos = ManejadorConfiguracion.ObtenerValor("administracionConfig", "baseDatosConfig", "BaseDatos");
        //    personaNaturalListado = FachadaAdmAD.ObtenerListadoPersonaNaturalPorCriterio(criterio, activo);

        //    if ( personaNaturalListado.Count > 0 && inclusionPersonaNatural != null ) {

        //        //Extrayendo Ids
        //        idPersonaNaturalListado = personaNaturalListado.Select(x => x.IdPersonaNatural).ToList();

        //        //Propiedades complejas
        //        if ( inclusionPersonaNatural.Persona == true ) {
        //            var personaListado = FachadaAdmAD.ObtenerListadoPersona(personaNaturalListado.Select(p => p.Persona.IdPersona).ToList());
        //            personaNaturalListado.All(l => { l.Persona = personaListado.FirstOrDefault(x => x.IdPersona == l.Persona.IdPersona); return true; });
        //        }

        //        if ( inclusionPersonaNatural.Genero == true ) {
        //            var generoListado = FachadaAdmAD.ObtenerListadoValor(personaNaturalListado.Select(p => p.Genero.IdValor).ToList());
        //            personaNaturalListado.All(l => { l.Genero = generoListado.FirstOrDefault(x => x.IdValor == l.Genero.IdValor); return true; });
        //        }

        //        if ( inclusionPersonaNatural.EstadoCivil == true ) {
        //            var estadoCivilListado = FachadaAdmAD.ObtenerListadoValor(personaNaturalListado.Select(p => p.EstadoCivil.IdValor).ToList());
        //            personaNaturalListado.All(l => { l.EstadoCivil = estadoCivilListado.FirstOrDefault(x => x.IdValor == l.EstadoCivil.IdValor); return true; });
        //        }

        //        if ( inclusionPersonaNatural.Ocupacion == true ) {
        //            var ocupacionListado = FachadaAdmAD.ObtenerListadoValor(personaNaturalListado.Select(p => p.Ocupacion.IdValor).ToList());
        //            personaNaturalListado.All(l => { l.Ocupacion = ocupacionListado.FirstOrDefault(x => x.IdValor == l.Ocupacion.IdValor); return true; });
        //        }

        //        //Cargando Registro Bloqueo para las Cuentas
        //        if ( inclusionPersonaNatural.RegistroBloqueo == true ) {
        //            listadoRegistroBloqueo = ManejadorBloqueo.ObtenerDatosBloqueoListado(EntidadTabla.PersonaNatural, nombreBaseDatos, idPersonaNaturalListado);
        //            personaNaturalListado.All(l => { l.RegistroBloqueo = listadoRegistroBloqueo.FirstOrDefault(x => x.IdRegistro == l.IdPersonaNatural); return true; });
        //            personaNaturalListado.Where(x => x.RegistroBloqueo != null).All(l => { l.EstaBloqueado = true; return true; });
        //        }

        //        if ( inclusionPersonaNatural.Topografos == true ) {
        //            var topografosListado = FachadaAdmAD.ObtenerListadoTopografoPorListadoIdPersonaNatural(idPersonaNaturalListado, inclusionPersonaNatural.ActivoColecciones);
        //            if ( inclusionPersonaNatural.RegistroBloqueo == true ) {
        //                registroBloqueoTopografos = ManejadorBloqueo.ObtenerDatosBloqueoListado(EntidadTabla.Topografo, nombreBaseDatos, topografosListado.Select(x => x.IdTopografo).ToList());
        //                topografosListado.All(l => { l.RegistroBloqueo = registroBloqueoTopografos.FirstOrDefault(x => x.IdRegistro == l.IdTopografo); return true; });
        //                topografosListado.Where(x => x.RegistroBloqueo != null).All(l => { l.EstaBloqueado = true; return true; });
        //            }
        //            personaNaturalListado.All(l => { l.Topografos = topografosListado.Where(x => x.PersonaNatural.IdPersonaNatural == l.IdPersonaNatural).ToList(); return true; });
        //        }

        //        if ( inclusionPersonaNatural.PersonaJuridicas == true ) {
        //            var personaJuridicasListado = FachadaAdmAD.ObtenerListadoPersonaJuridicaPorListadoIdRepresentanteLegal(idPersonaNaturalListado, inclusionPersonaNatural.ActivoColecciones);
        //            if ( inclusionPersonaNatural.RegistroBloqueo == true ) {
        //                registroBloqueoPersonaJuridicas = ManejadorBloqueo.ObtenerDatosBloqueoListado(EntidadTabla.PersonaJuridica, nombreBaseDatos, personaJuridicasListado.Select(x => x.IdPersonaJuridica).ToList());
        //                personaJuridicasListado.All(l => { l.RegistroBloqueo = registroBloqueoPersonaJuridicas.FirstOrDefault(x => x.IdRegistro == l.IdPersonaJuridica); return true; });
        //                personaJuridicasListado.Where(x => x.RegistroBloqueo != null).All(l => { l.EstaBloqueado = true; return true; });
        //            }
        //            personaNaturalListado.All(l => { l.PersonaJuridicas = personaJuridicasListado.Where(x => x.RepresentanteLegal.IdPersonaNatural == l.IdPersonaNatural).ToList(); return true; });
        //        }

        //        if ( inclusionPersonaNatural.Abogados == true ) {
        //            var abogadosListado = FachadaAdmAD.ObtenerListadoAbogadoPorListadoIdPersonaNatural(idPersonaNaturalListado, inclusionPersonaNatural.ActivoColecciones);
        //            if ( inclusionPersonaNatural.RegistroBloqueo == true ) {
        //                registroBloqueoAbogados = ManejadorBloqueo.ObtenerDatosBloqueoListado(EntidadTabla.Abogado, nombreBaseDatos, abogadosListado.Select(x => x.IdAbogado).ToList());
        //                abogadosListado.All(l => { l.RegistroBloqueo = registroBloqueoAbogados.FirstOrDefault(x => x.IdRegistro == l.IdAbogado); return true; });
        //                abogadosListado.Where(x => x.RegistroBloqueo != null).All(l => { l.EstaBloqueado = true; return true; });
        //            }
        //            personaNaturalListado.All(l => { l.Abogados = abogadosListado.Where(x => x.PersonaNatural.IdPersonaNatural == l.IdPersonaNatural).ToList(); return true; });
        //        }

        //        if ( inclusionPersonaNatural.EmpleadoHijos == true ) {
        //            var empleadoHijosListado = FachadaAdmAD.ObtenerListadoEmpleadoPorPersonaNatural(idPersonaNaturalListado, inclusionPersonaNatural.ActivoColecciones);
        //            if ( inclusionPersonaNatural.RegistroBloqueo == true ) {
        //                registroBloqueoEmpleadoHijos = ManejadorBloqueo.ObtenerDatosBloqueoListado(EntidadTabla.Empleado, nombreBaseDatos, empleadoHijosListado.Select(x => x.IdEmpleado).ToList());
        //                empleadoHijosListado.All(l => { l.RegistroBloqueo = registroBloqueoEmpleadoHijos.FirstOrDefault(x => x.IdRegistro == l.IdEmpleado); return true; });
        //                empleadoHijosListado.Where(x => x.RegistroBloqueo != null).All(l => { l.EstaBloqueado = true; return true; });
        //            }
        //            personaNaturalListado.All(l => { l.EmpleadoHijos = empleadoHijosListado.Where(x => x.PersonaNatural.IdPersonaNatural == l.IdPersonaNatural).ToList(); return true; });
        //        }
        //    }
        //    //Resultado
        //    return personaNaturalListado;
        //}

        //public List<PersonaNatural> ObtenerListadoPersonaNaturalPorPersona(int idPersona, Activo activo) {
        //    return FachadaAdmAD.ObtenerListadoPersonaNaturalPorPersona(idPersona, activo);
        //}

        //public List<PersonaNatural> ObtenerListadoPersonaNaturalPorPersona(List<int> idPersonaListado, Activo activo) {
        //    return FachadaAdmAD.ObtenerListadoPersonaNaturalPorPersona(idPersonaListado, activo);
        //}

            #endregion

        #endregion

        #region Bloqueo

        ///// <author>Ernesto Medrano</author>
        ///// <creationdate>16-sep-2015</creationdate>
        ///// <summary> 
        /////<creationdate>26-Feb-2015</creationdate>
        ///// Método que inicia un bloqueo de un registro de una tabla de la base de datos.
        ///// <param name="registroBloqueo">Objeto de tipo RegistroBloqueo a ser bloqueado.</param>
        ///// <returns>True: Registro Bloqueado</returns>
        //public Boolean IniciarEdicionPersonaNatural(Entidades.Persona.PersonaNatural personaNatural) {
        //    //Declaraciones                                  
        //    Boolean resultado = false;

        //    //Operaciones
        //    if ( personaNatural == null ) {
        //        throw new ArgumentNullException("personaNatural", MensajeExcepcion.ParametroEnNulo);
        //    }

        //    if ( personaNatural.IdPersonaNatural <= 0 ) {
        //        throw new ArgumentException(MensajeExcepcion.IdentificadorObjetoNoValido, "personaNatural");
        //    }

        //    resultado = IniciarEdicionListadoPersonaNatural(new List<Entidades.Persona.PersonaNatural>() { personaNatural });

        //    //Resultado
        //    return resultado;
        //}

        ///// <author>Ernesto Medrano</author>
        ///// <creationdate>16-sep-2015</creationdate>
        ///// <summary> 
        ///// Método que inicia el bloqueo de un listado de registros de una tabla de la base de datos.
        ///// </summary>
        ///// <param name="registroBloqueoListado"></param>
        ///// <returns>True: Registro Bloqueado</returns>
        //public Boolean IniciarEdicionListadoPersonaNatural(List<Entidades.Persona.PersonaNatural> personaNaturalListado) {
        //    //Declaraciones                      
        //    List<RegistroBloqueo> listado = new List<RegistroBloqueo>();
        //    Boolean resultado = false;
        //    String nombreBaseDato;
        //    List<RegistroBloqueo> bloqueoListadoActual;
        //    ReglaNegocio reglaNegocio = new ReglaNegocio();
        //    //Operaciones
        //    if ( personaNaturalListado == null ) {
        //        throw new ArgumentNullException("personaNaturalListado", MensajeExcepcion.ParametroEnNulo);
        //    }

        //    if ( personaNaturalListado.Count() <= 0 ) {
        //        throw new ArgumentException(MensajeExcepcion.ParametroListaVacia, "personaNaturalListado");
        //    }

        //    if ( personaNaturalListado.Where(m => m.IdPersonaNatural <= 0).Count() > 0 ) {
        //        throw new ArgumentException(MensajeExcepcion.IdentificadorObjetoNoValidoListado, "personaNaturalListado");
        //    }
        //    nombreBaseDato = ManejadorConfiguracion.ObtenerValor("administracionConfig", "baseDatosConfig", "BaseDatos");

        //    reglaNegocio.Campos.Add("EstaBloqueado");
        //    reglaNegocio.Mensaje = MensajeReglaNegocio.RegistroEstaBloqueado;

        //    //verificando si el personaNatural está bloqueado
        //    if ( personaNaturalListado.Where(x => x.EstaBloqueado == true).Count() > 0 ) {
        //        personaNaturalListado.Where(x => x.EstaBloqueado == true).All(x => { x.ReglasInfringidas.Add(reglaNegocio); return true; });
        //        return false;
        //    }

        //    bloqueoListadoActual = ManejadorBloqueo.ObtenerDatosBloqueoListado(EntidadTabla.PersonaNatural, nombreBaseDato, personaNaturalListado.Select(x => x.IdPersonaNatural).ToList());
        //    personaNaturalListado.All(l => { l.RegistroBloqueo = bloqueoListadoActual.FirstOrDefault(x => l.IdPersonaNatural == x.IdRegistro); return true; });
        //    personaNaturalListado.Where(x => x.RegistroBloqueo != null).All(l => { l.EstaBloqueado = true; return true; });

        //    if ( personaNaturalListado.Where(x => x.EstaBloqueado == true).Count() > 0 ) {
        //        personaNaturalListado.Where(x => x.EstaBloqueado == true).All(x => { x.ReglasInfringidas.Add(reglaNegocio); return true; });
        //        return false;
        //    }

        //    //Registro Bloqueo PersonaNatural
        //    listado.AddRange(personaNaturalListado.Select(mod => new RegistroBloqueo() { IdRegistro = mod.IdPersonaNatural, EntidadTabla = EntidadTabla.PersonaNatural }).ToList());
        //    //Error

        //    //Definiendo la base de datos de proveniencia
        //    listado.All(x => { x.NombreBaseDato = nombreBaseDato; return true; });

        //    //Bloqueando registros
        //    resultado = ManejadorBloqueo.IniciarBloqueoListado(listado);

        //    //Asignando datos de bloqueo al objeto
        //    if ( resultado == true ) {
        //        personaNaturalListado.All(x => { x.EstaBloqueado = true; x.RegistroBloqueo = listado.FirstOrDefault(l => l.IdRegistro == x.IdPersonaNatural && l.EntidadTabla == EntidadTabla.PersonaNatural); return true; });
        //    }
        //    //Resultado
        //    return resultado;
        //}

        ///// <author>Ernesto Medrano</author>
        ///// <creationdate>16-sep-2015</creationdate>
        ///// <summary>
        ///// Método que Cancela el bloqueo de un registro de una tabla de la base de datos.
        ///// </summary>
        ///// <param name="registroBloqueo"></param>
        ///// <returns>True: Registro Desbloqueado</returns>
        //public Boolean CancelarEdicionPersonaNatural(Entidades.Persona.PersonaNatural personaNatural) {
        //    //Declaraciones            
        //    Boolean resultado = false;

        //    //Operaciones
        //    if ( personaNatural == null ) {
        //        throw new ArgumentNullException("personaNatural", MensajeExcepcion.ParametroEnNulo);
        //    }
        //    if ( personaNatural.RegistroBloqueo == null ) {
        //        throw new ArgumentException(MensajeExcepcion.ParametroEnNulo, "personaNatural.RegistroBloqueo");
        //    }

        //    if ( personaNatural.RegistroBloqueo.IdRegistro <= 0 ) {
        //        throw new ArgumentException(MensajeExcepcion.IdentificadorObjetoNoValido, "personaNatural.RegistroBloqueo.IdRegistro");
        //    }

        //    resultado = FinalizarEdicionListadoPersonaNatural(new List<Entidades.Persona.PersonaNatural>() { personaNatural });

        //    //Resultado
        //    return resultado;
        //}

        ///// <author>Ernesto Medrano</author>
        ///// <creationdate>16-sep-2015</creationdate>
        ///// <summary>
        ///// Método que cancela el bloqueo de un listado de registros de uan tabla de la base de datos.
        ///// </summary>
        ///// <param name="registroBloqueoListado"></param>
        ///// <returns>True: Registro Desbloqueado</returns>
        //public Boolean CancelarEdicionListadoPersonaNatural(List<Entidades.Persona.PersonaNatural> personaNaturalListado) {
        //    //Declaraciones                      
        //    List<RegistroBloqueo> listado = new List<RegistroBloqueo>();
        //    Boolean resultado = false;
        //    ReglaNegocio reglaNegocio = new ReglaNegocio();
        //    //Operaciones
        //    if ( personaNaturalListado == null ) {
        //        throw new ArgumentNullException("personaNaturalListado", MensajeExcepcion.ParametroEnNulo);
        //    }

        //    if ( personaNaturalListado.Count() <= 0 ) {
        //        throw new ArgumentException(MensajeExcepcion.ParametroListaVacia, "personaNaturalListado");
        //    }

        //    if ( personaNaturalListado.Where(m => m.IdPersonaNatural <= 0).Count() > 0 ) {
        //        throw new ArgumentException(MensajeExcepcion.IdentificadorObjetoNoValidoListado, "personaNaturalListado");
        //    }

        //    resultado = FinalizarEdicionListadoPersonaNatural(personaNaturalListado);

        //    //Resultado
        //    return resultado;
        //}

        ///// <author>Ernesto Medrano</author>
        ///// <creationdate>16-sep-2015</creationdate>
        ///// <summary>
        ///// Método que finaliza el bloqueo de un registro de una tabla de la base de datos.
        ///// </summary>
        ///// <param name="registroBloqueo"></param>
        ///// <returns>True: Registro Desbloqueado</returns>
        //public Boolean FinalizarEdicionPersonaNatural(Entidades.Persona.PersonaNatural personaNatural) {
        //    //Declaraciones            
        //    Boolean resultado = false;

        //    //Operaciones
        //    if ( personaNatural == null ) {
        //        throw new ArgumentNullException("personaNatural", MensajeExcepcion.ParametroEnNulo);
        //    }
        //    if ( personaNatural.RegistroBloqueo == null ) {
        //        throw new ArgumentException(MensajeExcepcion.ParametroEnNulo, "personaNatural.RegistroBloqueo");
        //    }

        //    if ( personaNatural.RegistroBloqueo.IdRegistro <= 0 ) {
        //        throw new ArgumentException(MensajeExcepcion.IdentificadorObjetoNoValido, "personaNatural.RegistroBloqueo.IdRegistro");
        //    }

        //    resultado = FinalizarEdicionListadoPersonaNatural(new List<Entidades.Persona.PersonaNatural>() { personaNatural });

        //    //Resultado
        //    return resultado;
        //}

        ///// <author>Ernesto Medrano</author>
        ///// <creationdate>16-sep-2015</creationdate>
        ///// <summary>
        ///// Método que finaliza el bloqueo de un listado de registros de una tabla de la base de datos.
        ///// </summary>
        ///// <param name="registroBloqueoListado"></param>
        ///// <returns></returns>
        //public Boolean FinalizarEdicionListadoPersonaNatural(List<Entidades.Persona.PersonaNatural> personaNaturalListado) {
        //    //Declaraciones                      
        //    List<RegistroBloqueo> listado = new List<RegistroBloqueo>();
        //    Boolean resultado = false;
        //    String nombreBaseDato;
        //    List<RegistroBloqueo> bloqueoListadoActual;
        //    ReglaNegocio reglaNegocio = new ReglaNegocio();

        //    //Operaciones
        //    if ( personaNaturalListado == null ) {
        //        throw new ArgumentNullException("personaNaturalListado", MensajeExcepcion.ParametroEnNulo);
        //    }

        //    if ( personaNaturalListado.Count() <= 0 ) {
        //        throw new ArgumentException(MensajeExcepcion.ParametroListaVacia, "personaNaturalListado");
        //    }

        //    if ( personaNaturalListado.Where(x => x.RegistroBloqueo == null).Count() > 0 ) {
        //        throw new ArgumentException(MensajeExcepcion.ParametroEnNulo, "personaNaturalListado.RegistroBloqueo");
        //    }

        //    if ( personaNaturalListado.Where(x => x.RegistroBloqueo.IdRegistroBloqueo <= 0).Count() > 0 ) {
        //        throw new ArgumentException(MensajeExcepcion.IdentificadorObjetoNoValidoListado, "personaNaturalListado.RegistroBloqueo.IdRegistroBloqueo");
        //    }

        //    if ( personaNaturalListado.Where(m => m.IdPersonaNatural <= 0).Count() > 0 ) {
        //        throw new ArgumentException(MensajeExcepcion.IdentificadorObjetoNoValidoListado, "personaNaturalListado.IdPersonaNatural");
        //    }
        //    nombreBaseDato = ManejadorConfiguracion.ObtenerValor("administracionConfig", "baseDatosConfig", "BaseDatos");

        //    reglaNegocio.Campos.Add("EstaBloqueado");
        //    reglaNegocio.Mensaje = MensajeReglaNegocio.RegistroEstaBloqueado;

        //    //verificando si el PersonaNatural está bloqueado
        //    if ( personaNaturalListado.Where(x => x.EstaBloqueado == false).Count() > 0 ) {
        //        personaNaturalListado.Where(x => x.EstaBloqueado == false).All(x => { x.ReglasInfringidas.Add(reglaNegocio); return true; });
        //        return false;
        //    }

        //    bloqueoListadoActual = ManejadorBloqueo.ObtenerDatosBloqueoListado(EntidadTabla.PersonaNatural, nombreBaseDato, personaNaturalListado.Select(x => x.IdPersonaNatural).ToList());
        //    personaNaturalListado.All(l => { l.RegistroBloqueo = bloqueoListadoActual.FirstOrDefault(x => l.IdPersonaNatural == x.IdRegistro); return true; });
        //    personaNaturalListado.Where(x => x.RegistroBloqueo != null).All(l => { l.EstaBloqueado = true; return true; });
        //    if ( personaNaturalListado.Where(x => x.EstaBloqueado == false).Count() > 0 ) {
        //        personaNaturalListado.Where(x => x.EstaBloqueado == false).All(x => { x.ReglasInfringidas.Add(reglaNegocio); return true; });
        //        return false;
        //    }

        //    //Registro Bloqueo PersonaNatural            
        //    listado.AddRange(personaNaturalListado.Where(x => x.RegistroBloqueo != null && x.RegistroBloqueo.IdRegistroBloqueo > 0).
        //            Select(x => x.RegistroBloqueo).ToList());

        //    //Bloqueando registros
        //    resultado = ManejadorBloqueo.FinalizarBloqueoListado(listado);

        //    //Asignando datos de bloqueo al objeto
        //    if ( resultado == true ) {
        //        personaNaturalListado.All(x => { x.EstaBloqueado = false; x.RegistroBloqueo = null; return true; });
        //    }

        //    //Resultado
        //    return resultado;
        //}

        #endregion

        //#region Auditoria

        ///// <author>Yahaira Martinez</author>
        ///// <creationdate>07-oct-2016</creationdate>
        ///// <summary>
        ///// Registra el detalle de pista de auditoria
        ///// </summary>
        ///// <param name="anterior">Entidad cargada con los valores previos</param>
        ///// <param name="nuevo">Entidad cargada con los valores nuevo</param>
        ///// <param name="codigoAccion">Código de la acción a registrar</param>
        ///// <returns></returns>
        //public Boolean RegistrarDetallePistaAuditoriaPersonaNatural(PersonaNatural anterior, PersonaNatural nuevo, String codigoAccion) {
        //    List<DetallePistaAuditoria> detallePistaAuditoria = new List<DetallePistaAuditoria>();
        //    Sesion sesion;
        //    List<Sesion> sesionListado;
        //    PistaAuditoria pistaAuditoria;
        //    List<PistaAuditoria> pistaAuditoriaListado;
        //    Boolean resultado = false;
        //    List<String> propiedades;
        //    String nombreTabla;
        //    Dictionary<Int32, String> accionListado;
        //    Int32 idAccion = 0;
        //    Object tabla = new Object();
        //    Int32 idTabla;
        //    Int32 contador = 0;

        //    //Obtener la accion y su identificador
        //    accionListado = ManejadorIdentidad.Autorizaciones.Acciones;
        //    idAccion = accionListado.Where(p => p.Value == codigoAccion).Select(p => p.Key).FirstOrDefault();

        //    //Continuar
        //    sesion = new Sesion { IdSesion = ManejadorIdentidad.IdentidadActual.IdSesion };
        //    pistaAuditoriaListado = FachadaUtlLN.ObtenerListadoPistaAuditoriaPorSesion(sesion.IdSesion, Activo.Todos);

        //    #region Nuevo != null

        //    if ( nuevo != null ) {
        //        propiedades = nuevo.ObtenerPropiedades();

        //        if ( anterior == null ) {
        //            foreach ( String item in propiedades ) {
        //                String valor = nuevo.ObtenerValor(item);
        //                List<String> datosSeparados = valor.Split(new[] { "|" }, StringSplitOptions.RemoveEmptyEntries).ToList<String>();

        //                if ( contador == 0 ) {
        //                    contador++;
        //                    nombreTabla = nuevo.ObtenerNombreTabla(item);
        //                    tabla = ManejadorIdentidad.Autorizaciones.ObtenerTablaPorNombre(nombreTabla);
        //                    idTabla = Convert.ToInt32(tabla.GetType().GetMethod("ObtenerValor").Invoke(tabla, new[] { "IdTabla" }).ToString());
        //                    pistaAuditoriaListado.Add(RegistrarPistaAuditoriaIntermediaPersonaNatural(idTabla, idAccion, nuevo.IdPersonaNatural, sesion));
        //                }


        //                datosSeparados.All(x => {
        //                    detallePistaAuditoria.Add(new DetallePistaAuditoria() {
        //                        PistaAuditoria = pistaAuditoriaListado.Last(),
        //                        AliasCampo = item,
        //                        ValorAnterior = x,
        //                        ValorNuevo = null
        //                    });
        //                    return true;
        //                });
        //            }
        //        } else {
        //            foreach ( String item in propiedades ) {
        //                String valorAnterior = anterior.ObtenerValor(item);
        //                String valorNuevo = nuevo.ObtenerValor(item);
        //                tabla = new Object();
        //                Boolean continuar = true;
        //                Boolean esColeccion = nuevo.EsColeccion(item);

        //                if ( esColeccion == true ) {
        //                    if ( valorAnterior == "" & valorNuevo == "" ) {
        //                        continuar = false;
        //                    }
        //                }
        //                if ( contador == 0 ) {
        //                    contador++;
        //                    nombreTabla = nuevo.ObtenerNombreTabla(item);
        //                    tabla = ManejadorIdentidad.Autorizaciones.ObtenerTablaPorNombre(nombreTabla);
        //                    idTabla = Convert.ToInt32(tabla.GetType().GetMethod("ObtenerValor").Invoke(tabla, new[] { "IdTabla" }).ToString());
        //                    pistaAuditoriaListado.Add(RegistrarPistaAuditoriaIntermediaPersonaNatural(idTabla, idAccion, nuevo.IdPersonaNatural, sesion));
        //                }
        //                if ( continuar == true ) {
        //                    nombreTabla = nuevo.ObtenerNombreTabla(item);
        //                    tabla = ManejadorIdentidad.Autorizaciones.ObtenerTablaPorNombre(nombreTabla);
        //                    idTabla = Convert.ToInt32(tabla.GetType().GetMethod("ObtenerValor").Invoke(tabla, new[] { "IdTabla" }).ToString());

        //                    if ( (valorAnterior != "" && valorAnterior != null) && (valorNuevo != "" && valorNuevo != null) ) {
        //                        if ( valorAnterior != valorNuevo ) {

        //                            List<String> listadoAnteriores = new List<String>();
        //                            List<String> listadoNuevos = new List<String>();
        //                            List<String> listadoAgregados = new List<String>();
        //                            List<String> listadoEliminados = new List<String>();

        //                            listadoAnteriores = valorAnterior.Split(new[] { "|" }, StringSplitOptions.RemoveEmptyEntries).ToList<String>();
        //                            listadoNuevos = valorNuevo.Split(new[] { "|" }, StringSplitOptions.RemoveEmptyEntries).ToList<String>();

        //                            if ( esColeccion == true ) {
        //                                List<DetallePistaAuditoria> detallePistaAuditoriaColeccion = new List<DetallePistaAuditoria>();

        //                                listadoAgregados = listadoNuevos.Where(x => listadoAnteriores.Any(a => a == x) == false).ToList();
        //                                listadoEliminados = listadoAnteriores.Where(x => listadoNuevos.Any(a => a == x) == false).ToList();



        //                                #region Principal
        //                                listadoAgregados.All(x => {
        //                                    detallePistaAuditoria.Add(new DetallePistaAuditoria() {
        //                                        PistaAuditoria = pistaAuditoriaListado.Last(),
        //                                        AliasCampo = item,
        //                                        ValorAnterior = null,
        //                                        ValorNuevo = x
        //                                    });
        //                                    return true;
        //                                });

        //                                listadoEliminados.All(x => {
        //                                    detallePistaAuditoria.Add(new DetallePistaAuditoria() {
        //                                        PistaAuditoria = pistaAuditoriaListado.Last(),
        //                                        AliasCampo = item,
        //                                        ValorAnterior = x,
        //                                        ValorNuevo = null
        //                                    });
        //                                    return true;
        //                                });
        //                                #endregion


        //                                #region Intermedia
        //                                listadoAgregados.All(x => {
        //                                    // PistaAuditoria pista = RegistrarPistaAuditoriaIntermediaPersonaNatural(idTabla, idAccion, Convert.ToInt32(x), sesion);
        //                                    detallePistaAuditoriaColeccion.Add(new DetallePistaAuditoria() {
        //                                        PistaAuditoria = pistaAuditoriaListado.Last(),
        //                                        AliasCampo = "EstaActivo",
        //                                        ValorAnterior = "0",
        //                                        ValorNuevo = "1"
        //                                    });
        //                                    return true;
        //                                });

        //                                listadoEliminados.All(x => {
        //                                    //PistaAuditoria pista = RegistrarPistaAuditoriaIntermediaPersonaNatural(idTabla, idAccion, Convert.ToInt32(x), sesion);
        //                                    detallePistaAuditoriaColeccion.Add(new DetallePistaAuditoria() {
        //                                        PistaAuditoria = pistaAuditoriaListado.Last(),
        //                                        AliasCampo = "EstaActivo",
        //                                        ValorAnterior = "1",
        //                                        ValorNuevo = "0"
        //                                    });
        //                                    return true;
        //                                });
        //                                FachadaUtlLN.AgregarListadoDetallePistaAuditoria(detallePistaAuditoriaColeccion);
        //                                #endregion

        //                            } else {
        //                                if ( pistaAuditoriaListado.Count == 0 ) {
        //                                    pistaAuditoriaListado.Add(RegistrarPistaAuditoriaIntermediaPersonaNatural(idTabla, idAccion, nuevo.IdPersonaNatural, sesion));
        //                                }
        //                                detallePistaAuditoria.Add(new DetallePistaAuditoria() {
        //                                    PistaAuditoria = pistaAuditoriaListado.Last(),
        //                                    AliasCampo = item,
        //                                    ValorAnterior = valorAnterior,
        //                                    ValorNuevo = valorNuevo
        //                                });
        //                            }
        //                        }
        //                    }
        //                }
        //            }
        //        }
        //    } else {
        //        if ( anterior != null ) {
        //            propiedades = anterior.ObtenerPropiedades();
        //            foreach ( String item in propiedades ) {
        //                String valor = anterior.ObtenerValor(item);
        //                List<String> datosSeparados = valor.Split(new[] { "|" }, StringSplitOptions.RemoveEmptyEntries).ToList<String>();

        //                if ( contador == 0 ) {
        //                    contador++;
        //                    nombreTabla = anterior.ObtenerNombreTabla(item);
        //                    tabla = ManejadorIdentidad.Autorizaciones.ObtenerTablaPorNombre(nombreTabla);
        //                    idTabla = Convert.ToInt32(tabla.GetType().GetMethod("ObtenerValor").Invoke(tabla, new[] { "IdTabla" }).ToString());
        //                    pistaAuditoriaListado.Add(RegistrarPistaAuditoriaIntermediaPersonaNatural(idTabla, idAccion, anterior.IdPersonaNatural, sesion));
        //                }

        //                datosSeparados.All(x => {
        //                    detallePistaAuditoria.Add(new DetallePistaAuditoria() {
        //                        PistaAuditoria = pistaAuditoriaListado.Last(),
        //                        AliasCampo = item,
        //                        ValorAnterior = x,
        //                        ValorNuevo = null
        //                    });
        //                    return true;
        //                });
        //            }
        //        }
        //    }
        //    #endregion

        //    if ( detallePistaAuditoria.Count > 0 ) {
        //        resultado = FachadaUtlLN.AgregarListadoDetallePistaAuditoria(detallePistaAuditoria);
        //    } else {
        //        resultado = true;
        //    }

        //    return resultado;
        //}

        ///// <author>Yahaira Martinez</author>
        ///// <creationdate>07-oct-2016</creationdate>
        ///// <summary>
        ///// Método que se encarga de registar las pistas de auditoria sobre un registro.
        ///// </summary>
        ///// <param name="idTabla">Identificador de la tabla que se va a registrar</param>
        ///// <param name="idAccion">Identificador de la acción que se va a registrar</param>
        ///// <param name="idRegistro">Identificador del registro que se va a registrar</param>
        ///// <param name="sesion">Sesión sobre la cual se regitrará la pista de auditoría</param>
        ///// <returns></returns>
        //public PistaAuditoria RegistrarPistaAuditoriaIntermediaPersonaNatural(Int32 idTabla, Int32 idAccion, Int32 idRegistro, Sesion sesion) {
        //    Boolean resultado = false;
        //    PistaAuditoria pistasAuditoria = new PistaAuditoria();

        //    pistasAuditoria.Sesion = sesion;
        //    pistasAuditoria.IdTabla = idTabla;
        //    pistasAuditoria.IdRegistro = idRegistro;
        //    pistasAuditoria.IdAccion = idAccion;
        //    pistasAuditoria.Fecha = DateTime.Now;

        //    resultado = FachadaUtlLN.AgregarPistaAuditoria(pistasAuditoria);

        //    if ( resultado == true )
        //        return pistasAuditoria;
        //    else
        //        return null;
        //}

        #endregion

    }
}