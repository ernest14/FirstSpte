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
        /// Método que agrega un nuevo objeto de tipo Persona.
        /// </summary>
        /// <param name="persona">Objeto tipo Persona a ser agregado.</param>
        /// <returns>True: Registro agregado </returns>        
        public Boolean AgregarPersona(Entidades.Persona.Persona persona) {
            //Declaraciones
            Boolean resultado = false;
            TransactionScope transaccion;

            //Operaciones
            if ( persona == null ) {
                throw new ArgumentNullException("persona", MensajeExcepcion.ParametroEnNulo);
            }
            if ( persona.IdPersona != 0 ) {
                throw new ArgumentException(MensajeExcepcion.IdentificadorObjetoCreacion, "persona");
            }
            if ( ValidarPersona(persona) == false ) {
                return false;
            } else {
                using ( transaccion = new TransactionScope() ) {
                    if ( FachadaAdmAD.AgregarPersona(persona) == true ) {
                        resultado = true;
                        //if ( persona.Direcciones != null ) {
                         //   resultado = FachadaAdmAD.AgregarListadoPersonaDireccion(persona.IdPersona, persona.Direcciones.Select(x => x.EntidadDestino.IdDireccion).ToList());
                        //}
                    }
                    if ( resultado == true ) {
                        transaccion.Complete();
                    }
                }
            }

            //Resultado
            return resultado;
        }

        ///// <author>Ernesto Medrano</author>
        ///// <creationdate>16-sep-2015</creationdate>
        ///// <summary>
        ///// Método que agrega un nuevo listado de objeto de tipo Persona.
        ///// </summary>
        ///// <param name="personaListado">Listado de objetos de tipo Persona a ser agregados.</param>
        ///// <returns>True: Registros agregados</returns>
        //public Boolean AgregarListadoPersona(List<Entidades.Persona.Persona> personaListado) {
        //    //Declaraciones
        //    Boolean resultado = false;
        //    TransactionScope transaccion;

        //    //Operaciones
        //    if ( personaListado == null ) {
        //        throw new ArgumentNullException("personaListado", MensajeExcepcion.ParametroEnNulo);
        //    }
        //    if ( personaListado.Count() <= 0 ) {
        //        throw new ArgumentException(MensajeExcepcion.ParametroListaVacia, "personaListado");
        //    }
        //    if ( personaListado.Where(l => l.IdPersona != 0).Count() > 0 ) {
        //        throw new ArgumentException(MensajeExcepcion.IdentificadorObjetoCreacionListado, "personaListado");
        //    }
        //    try {
        //        using ( transaccion = new TransactionScope() ) {
        //            foreach ( var persona in personaListado ) {
        //                if ( ValidarPersona(persona) == false ) {
        //                    return false;
        //                } else {
        //                    if ( FachadaAdmAD.AgregarPersona(persona) == true ) {
        //                        resultado = true;
        //                        if ( persona.Direcciones != null ) {
        //                            resultado = FachadaAdmAD.AgregarListadoPersonaDireccion(persona.IdPersona, persona.Direcciones.Select(x => x.EntidadDestino.IdDireccion).ToList());
        //                        }
        //                    }
        //                }
        //            }
        //            if ( resultado == true ) {
        //                transaccion.Complete();
        //            }
        //        }
        //    } catch ( Exception e ) {
        //        resultado = false;
        //        throw new Excepcion(MensajeExcepcion.ErrorInesperado);
        //    }

        //    //Resultado
        //    return resultado;
        //}

        ///// <author>Ernesto Medrano</author>
        ///// <creationdate>16-sep-2015</creationdate>
        ///// <summary>
        ///// Método para editar un objeto de tipo Persona.
        ///// </summary>
        ///// <param name="persona">Objeto tipo Persona a ser editado.</param>
        ///// <returns>True: Operación exitosa</returns>
        //public Boolean ActualizarPersona(Entidades.Persona.Persona persona) {

        //    //Declaraciones
        //    Boolean resultado = false;
        //    TransactionScope transaccion;

        //    Entidades.Persona.Persona personaActual;

        //    //Operaciones
        //    if ( persona == null ) {
        //        throw new ArgumentNullException("persona", MensajeExcepcion.ParametroEnNulo);
        //    }

        //    if ( persona.IdPersona <= 0 ) {
        //        throw new ArgumentException(MensajeExcepcion.IdentificadorObjetoNoValido, "persona");
        //    }

        //    resultado = ValidarPersona(persona);

        //    if ( resultado == true ) {
        //        try {
        //            using ( transaccion = new TransactionScope() ) {
        //                resultado = FachadaAdmAD.ActualizarPersona(persona);
        //                if ( resultado == true ) {
        //                    if ( persona.Direcciones != null ) {
        //                        personaActual = ObtenerPersona(persona.IdPersona, new Inclusiones.InclusionPersona() {
        //                            Direcciones = true,
        //                            ActivoColecciones = Activo.Todos
        //                        });
        //                        //Listado de subsistemas a agregar
        //                        var direccionListadoAgregar = persona.Direcciones.Select(x => x.EntidadDestino.IdDireccion).
        //                        Except(personaActual.Direcciones.Select(x => x.EntidadDestino.IdDireccion)).ToList();
        //                        //Listado a dar de alta
        //                        List<Int32> direccionListadoDarAlta = (from listado in persona.Direcciones
        //                                                               join listadoBD in personaActual.Direcciones
        //                                                               on listado.EntidadDestino.IdDireccion equals listadoBD.EntidadDestino.IdDireccion
        //                                                               where listado.EstaActivo == true && listadoBD.EstaActivo == false
        //                                                               select new {
        //                                                                   listado.EntidadDestino.IdDireccion
        //                                                               }).Select(x => (Int32)x.IdDireccion).ToList();
        //                        //Listado a dar de baja
        //                        List<Int32> direccionListadoDarBaja = (from listado in persona.Direcciones
        //                                                               join listadoBD in personaActual.Direcciones
        //                                                               on listado.EntidadDestino.IdDireccion equals listadoBD.EntidadDestino.IdDireccion
        //                                                               where listado.EstaActivo == false && listadoBD.EstaActivo == true
        //                                                               select new {
        //                                                                   listado.EntidadDestino.IdDireccion
        //                                                               }).Select(x => (Int32)x.IdDireccion).ToList();
        //                        if ( direccionListadoAgregar.Any() ) {
        //                            resultado = FachadaAdmAD.AgregarListadoPersonaDireccion(persona.IdPersona, direccionListadoAgregar);
        //                            if ( resultado == false )
        //                                transaccion.Dispose();
        //                        }
        //                        if ( direccionListadoDarAlta.Any() ) {
        //                            resultado = FachadaAdmAD.DarAltaListadoPersonaDireccion(persona.IdPersona, direccionListadoDarAlta);
        //                            if ( resultado == false )
        //                                transaccion.Dispose();
        //                        }
        //                        if ( direccionListadoDarBaja.Any() ) {
        //                            resultado = FachadaAdmAD.DarBajaListadoPersonaDireccion(persona.IdPersona, direccionListadoDarBaja);
        //                            if ( resultado == false )
        //                                transaccion.Dispose();
        //                        }
        //                    }
        //                }
        //                if ( resultado == true ) {
        //                    if ( persona.RegistroBloqueo != null ) {
        //                        if ( persona.RegistroBloqueo.IdRegistroBloqueo > 0 ) {
        //                            FinalizarEdicionPersona(persona);
        //                        }
        //                    }
        //                    transaccion.Complete();
        //                }
        //            }
        //        } catch ( Exception e ) {
        //            resultado = false;
        //            throw new Excepcion(MensajeExcepcion.ErrorInesperado);
        //        }
        //    }

        //    //Resultado
        //    return resultado;
        //}

        ///// <author>Ernesto Medrano</author>
        ///// <creationdate>16-sep-2015</creationdate>
        ///// <summary>
        ///// Método para editar un listado de objetos de tipo Persona.
        ///// </summary>
        ///// <param name="personaListado">Listado de objetos de tipo Persona a ser editados</param>
        ///// <returns>True: Operación exitosa</returns>
        //public Boolean ActualizarListadoPersona(List<Entidades.Persona.Persona> personaListado) {
        //    //Declaraciones
        //    Boolean resultado = false;
        //    TransactionScope transaccion;

        //    //Operaciones
        //    if ( personaListado == null ) {
        //        throw new ArgumentNullException("personaListado", MensajeExcepcion.ParametroEnNulo);
        //    }
        //    if ( personaListado.Count() <= 0 ) {
        //        throw new ArgumentException(MensajeExcepcion.ParametroListaVacia, "personaListado");
        //    }
        //    if ( personaListado.Where(mo => mo.IdPersona <= 0).Count() > 0 ) {
        //        throw new ArgumentException(MensajeExcepcion.IdentificadorObjetoNoValidoListado, "personaListado");
        //    }
        //    try {
        //        using ( transaccion = new TransactionScope() ) {
        //            foreach ( var persona in personaListado ) {
        //                if ( ValidarPersona(persona) == false ) {
        //                    return false;
        //                } else {
        //                    resultado = FachadaAdmAD.ActualizarPersona(persona);
        //                    if ( resultado == true ) {
        //                        if ( persona.Direcciones != null ) {
        //                            var personaActual = ObtenerPersona(persona.IdPersona, new Inclusiones.InclusionPersona() {
        //                                Direcciones = true,
        //                                ActivoColecciones = Activo.Todos
        //                            });
        //                            //Listado de subsistemas a agregar
        //                            var listadoDireccionAgregar = persona.Direcciones.Select(x => x.EntidadDestino.IdDireccion).
        //                            Except(personaActual.Direcciones.Select(x => x.EntidadDestino.IdDireccion)).ToList();
        //                            //Listado a dar de alta
        //                            List<Int32> listadoDireccionDarAlta = (from listado in persona.Direcciones
        //                                                                   join listadoBD in personaActual.Direcciones
        //                                                                   on listado.EntidadDestino.IdDireccion equals listadoBD.EntidadDestino.IdDireccion
        //                                                                   where listado.EstaActivo == true && listadoBD.EstaActivo == false
        //                                                                   select new {
        //                                                                       listado.EntidadDestino.IdDireccion
        //                                                                   }).Select(x => (Int32)x.IdDireccion).ToList();
        //                            //Listado a dar de baja
        //                            List<Int32> listadoDireccionDarBaja = (from listado in persona.Direcciones
        //                                                                   join listadoBD in personaActual.Direcciones
        //                                                                   on listado.EntidadDestino.IdDireccion equals listadoBD.EntidadDestino.IdDireccion
        //                                                                   where listado.EstaActivo == false && listadoBD.EstaActivo == true
        //                                                                   select new {
        //                                                                       listado.EntidadDestino.IdDireccion
        //                                                                   }).Select(x => (Int32)x.IdDireccion).ToList();
        //                            if ( listadoDireccionAgregar.Any() ) {
        //                                resultado = FachadaAdmAD.AgregarListadoPersonaDireccion(persona.IdPersona, listadoDireccionAgregar);
        //                                if ( resultado == false )
        //                                    transaccion.Dispose();
        //                            }
        //                            if ( listadoDireccionDarAlta.Any() ) {
        //                                resultado = FachadaAdmAD.DarAltaListadoPersonaDireccion(persona.IdPersona, listadoDireccionDarAlta);
        //                                if ( resultado == false )
        //                                    transaccion.Dispose();
        //                            }
        //                            if ( listadoDireccionDarBaja.Any() ) {
        //                                resultado = FachadaAdmAD.DarBajaListadoPersonaDireccion(persona.IdPersona, listadoDireccionDarBaja);
        //                                if ( resultado == false )
        //                                    transaccion.Dispose();
        //                            }
        //                        } else {
        //                            resultado = true;
        //                        }
        //                    }
        //                }
        //            }
        //            if ( resultado == true ) {
        //                transaccion.Complete();
        //            }
        //        }
        //    } catch ( Exception e ) {
        //        resultado = false;
        //        throw new Excepcion(MensajeExcepcion.ErrorInesperado);
        //    }

        //    //Resultado
        //    return resultado;
        //}

        ///// <author>Ernesto Medrano</author>
        ///// <creationdate>16-sep-2015</creationdate>
        ///// <summary>
        ///// Método para dar de alta al objeto de tipo Persona. 
        ///// Cambia el campo EstaActivo a True.
        ///// </summary>
        ///// <param name="persona">Objeto a ser dado de alta.</param>
        ///// <returns>True: Operación exitosa</returns>
        //public Boolean DarAltaPersona(Entidades.Persona.Persona persona) {

        //    //Declaraciones     
        //    Entidades.Persona.Persona personaActual;
        //    ReglaNegocio reglaNegocio = new ReglaNegocio();

        //    //Operaciones
        //    if ( persona == null ) {
        //        throw new ArgumentNullException("persona", MensajeExcepcion.ParametroEnNulo);
        //    }

        //    if ( persona.IdPersona <= 0 ) {
        //        throw new ArgumentException(MensajeExcepcion.IdentificadorObjetoNoValido, "persona");
        //    }

        //    if ( persona.EstaActivo == true ) {
        //        persona.AgregarReglaInfringida("", MensajeReglaNegocio.RegistroEstaActivo, "EstaActivo");
        //        return false;
        //    }

        //    persona = ObtenerPersona(persona.IdPersona);
        //    if ( persona.EstaActivo == true ) {
        //        persona.AgregarReglaInfringida("", MensajeReglaNegocio.RegistroEstaActivo, "EstaActivo");
        //        return false;
        //    }
        //    //Resultado
        //    return FachadaAdmAD.DarAltaPersona(persona.IdPersona);
        //}

        ///// <author>Ernesto Medrano</author>
        ///// <creationdate>16-sep-2015</creationdate>
        ///// <summary>
        ///// Método para dar de alta al listado de objeto de tipo Persona.
        ///// Cambian los campos EstaActivo a True.
        ///// </summary>
        ///// <param name="personaListado">Listado de identificadores de objetos.</param>
        ///// <returns>True: Operación exitosa</returns>
        //public Boolean DarAltaListadoPersona(List<Entidades.Persona.Persona> personaListado) {

        //    //Declaraciones            
        //    List<Entidades.Persona.Persona> personaListadoActual;
        //    ReglaNegocio reglaNegocio = new ReglaNegocio();

        //    //Operaciones
        //    if ( personaListado == null ) {
        //        throw new ArgumentNullException("personaListado", MensajeExcepcion.ParametroEnNulo);
        //    }

        //    if ( personaListado.Count() <= 0 ) {
        //        throw new ArgumentException(MensajeExcepcion.ParametroListaVacia, "personaListado");
        //    }

        //    if ( personaListado.Where(mo => mo.IdPersona <= 0).Count() > 0 ) {
        //        throw new ArgumentException(MensajeExcepcion.IdentificadorObjetoNoValidoListado, "personaListado");
        //    }

        //    //Validando Objetos      
        //    if ( personaListado.Where(x => x.EstaActivo == true).Any() ) {
        //        personaListado.Where(x => x.EstaActivo == true).
        //            All(x => {
        //                x.AgregarReglaInfringida("", MensajeReglaNegocio.RegistroEstaActivo, "EstaActivo");
        //                return true;
        //            });
        //        return false;
        //    }

        //    //validando el estado en la base de datos
        //    personaListado = ObtenerListadoPersona(personaListado.Select(x => x.IdPersona).ToList(),
        //   new Inclusiones.InclusionPersona() {
        //       GrupoPersonas = true,
        //       PersonaJuridicas = true,
        //       PersonaContactos = true,
        //       PersonaNaturales = true,
        //       PersonaIdentificaciones = true,
        //       PersonaNacionalidades = true,
        //       Direcciones = true,
        //       ActivoColecciones = Activo.Si
        //   });
        //    if ( personaListado.Where(x => x.EstaActivo == true).Any() ) {
        //        personaListado.Where(x => x.EstaActivo == true).
        //            All(x => {
        //                x.AgregarReglaInfringida("", MensajeReglaNegocio.RegistroEstaActivo, "EstaActivo");
        //                return true;
        //            });
        //        return false;
        //    }

        //    //Resultado
        //    return FachadaAdmAD.DarAltaListadoPersona(personaListado.Select(m => m.IdPersona).ToList());
        //}

        ///// <author>Ernesto Medrano</author>
        ///// <creationdate>16-sep-2015</creationdate>
        ///// <summary>
        ///// Método para dar de baja al objeto de tipo Persona; 
        ///// Cambia el estado del objeto a "False".
        ///// </summary>
        ///// <param name="persona">Objeto a ser dado de baja.</param>
        ///// <returns>True: Operación exitosa</returns>
        //public Boolean DarBajaPersona(Entidades.Persona.Persona persona) {
        //    //Declaraciones
        //    Entidades.Persona.Persona personaActual;

        //    //Operaciones
        //    if ( persona == null ) {
        //        throw new ArgumentNullException("persona", MensajeExcepcion.ParametroEnNulo);
        //    }
        //    if ( persona.IdPersona <= 0 ) {
        //        throw new ArgumentException(MensajeExcepcion.IdentificadorObjetoNoValido, "persona");
        //    }
        //    if ( persona.EstaActivo == false ) {
        //        persona.AgregarReglaInfringida("", MensajeReglaNegocio.RegistroEstaInactivo, "EstaActivo");
        //        return false;
        //    }
        //    personaActual = ObtenerPersona(persona.IdPersona,
        //    new Inclusiones.InclusionPersona() {
        //        GrupoPersonas = true,
        //        PersonaJuridicas = true,
        //        PersonaContactos = true,
        //        PersonaNaturales = true,
        //        PersonaIdentificaciones = true,
        //        PersonaNacionalidades = true,
        //        Direcciones = true,
        //        ActivoColecciones = Activo.Todos
        //    });

        //    if ( personaActual.EstaActivo == false ) {
        //        persona.AgregarReglaInfringida("", MensajeReglaNegocio.RegistroEstaInactivo, "EstaActivo");
        //        return false;
        //    }
        //    if ( personaActual.Direcciones != null ) {
        //        if ( personaActual.Direcciones.Count > 0 ) {
        //            if ( FachadaAdmAD.DarBajaListadoPersonaDireccion(persona.Direcciones.Select(ugc => ugc.EntidadDestino.IdDireccion).ToList(), persona.IdPersona) ) {
        //                return true;
        //            }
        //        }
        //    }
        //    if ( personaActual.PersonaJuridicas != null ) {
        //        if ( personaActual.PersonaJuridicas.Any() ) {
        //            persona.AgregarReglaInfringida("", String.Format(MensajeReglaNegocio.DardeBajaRegistroAsociados, "Persona", "PersonaJuridicas"), "PersonaJuridicas");
        //            return false;
        //        }
        //    }
        //    if ( personaActual.PersonaContactos != null ) {
        //        if ( personaActual.PersonaContactos.Any() ) {
        //            persona.AgregarReglaInfringida("", String.Format(MensajeReglaNegocio.DardeBajaRegistroAsociados, "Persona", "PersonaContactos"), "PersonaContactos");
        //            return false;
        //        }
        //    }
        //    if ( personaActual.PersonaNaturales != null ) {
        //        if ( personaActual.PersonaNaturales.Any() ) {
        //            persona.AgregarReglaInfringida("", String.Format(MensajeReglaNegocio.DardeBajaRegistroAsociados, "Persona", "PersonaNaturales"), "PersonaNaturales");
        //            return false;
        //        }
        //    }
        //    if ( personaActual.PersonaIdentificaciones != null ) {
        //        if ( personaActual.PersonaIdentificaciones.Any() ) {
        //            persona.AgregarReglaInfringida("", String.Format(MensajeReglaNegocio.DardeBajaRegistroAsociados, "Persona", "PersonaIdentificaciones"), "PersonaIdentificaciones");
        //            return false;
        //        }
        //    }
        //    if ( personaActual.PersonaNacionalidades != null ) {
        //        if ( personaActual.PersonaNacionalidades.Any() ) {
        //            persona.AgregarReglaInfringida("", String.Format(MensajeReglaNegocio.DardeBajaRegistroAsociados, "Persona", "PersonaNacionalidades"), "PersonaNacionalidades");
        //            return false;
        //        }
        //    }

        //    //Resultado
        //    return FachadaAdmAD.DarBajaPersona(persona.IdPersona);
        //}

        ///// <author>Ernesto Medrano</author>
        ///// <creationdate>16-sep-2015</creationdate>
        ///// <summary>
        ///// Método para dar de baja al listado de objeto de tipo Persona.
        ///// Cambian los campos EstaActivo a True.
        ///// </summary>
        ///// <param name="personaListado">Listado de identificadores de objetos.</param>
        ///// <returns>True: Operación exitosa.</returns>
        //public Boolean DarBajaListadoPersona(List<Entidades.Persona.Persona> personaListado) {
        //    //Declaraciones
        //    List<Entidades.Persona.Persona> personaListadoActual;

        //    //Operaciones
        //    if ( personaListado == null ) {
        //        throw new ArgumentNullException("personaListado", MensajeExcepcion.ParametroEnNulo);
        //    }

        //    if ( personaListado.Count() <= 0 ) {
        //        throw new ArgumentException(MensajeExcepcion.ParametroListaVacia, "personaListado");
        //    }

        //    if ( personaListado.Where(mo => mo.IdPersona <= 0).Count() > 0 ) {
        //        throw new ArgumentException(MensajeExcepcion.IdentificadorObjetoNoValidoListado, "personaListado");
        //    }

        //    //Validando Objetos            
        //    if ( personaListado.Where(x => x.EstaActivo == false).Any() ) {
        //        personaListado.Where(x => x.EstaActivo == false).
        //            All(x => {
        //                x.AgregarReglaInfringida("", MensajeReglaNegocio.RegistroEstaInactivo, "EstaActivo");
        //                return true;
        //            });
        //        return false;
        //    }

        //    //validando si tiene registros asociados.

        //    personaListadoActual = ObtenerListadoPersona(personaListado.Select(x => x.IdPersona).ToList(),
        //     new Inclusiones.InclusionPersona() {
        //         GrupoPersonas = true,
        //         PersonaJuridicas = true,
        //         PersonaContactos = true,
        //         PersonaNaturales = true,
        //         PersonaIdentificaciones = true,
        //         PersonaNacionalidades = true,
        //         Direcciones = true,
        //         ActivoColecciones = Activo.Si
        //     });

        //    if ( personaListadoActual.Where(x => x.EstaActivo == false).Any() ) {
        //        personaListadoActual.Where(x => x.EstaActivo == false).
        //            All(x => {
        //                x.AgregarReglaInfringida("", MensajeReglaNegocio.RegistroEstaInactivo, "EstaActivo");
        //                return true;
        //            });
        //        return false;
        //    }

        //    foreach ( var persona in personaListadoActual ) {
        //        if ( persona.Direcciones != null ) {
        //            if ( persona.Direcciones.Count > 0 ) {
        //                if ( FachadaAdmAD.DarBajaListadoPersonaDireccion(persona.Direcciones.Select(ugc => ugc.EntidadDestino.IdDireccion).ToList(), persona.IdPersona) ) {
        //                    return true;
        //                }
        //            }
        //        }
        //    }
        //    if ( personaListadoActual.Where(x => x.PersonaJuridicas != null).Any(x => x.PersonaJuridicas.Any()) ) {
        //        personaListadoActual.Where(x => x.PersonaJuridicas.Any()).
        //            All(x => {
        //                personaListado.Where(l => l.IdPersona == x.IdPersona).Where(l => l != null).All(l => {
        //                    l.AgregarReglaInfringida("", String.Format(MensajeReglaNegocio.DardeBajaRegistroAsociados, "Persona", "PersonaJuridicas"), "PersonaJuridicas");
        //                    return true;
        //                });
        //                return true;
        //            });
        //        return false;
        //    }
        //    if ( personaListadoActual.Where(x => x.PersonaContactos != null).Any(x => x.PersonaContactos.Any()) ) {
        //        personaListadoActual.Where(x => x.PersonaContactos.Any()).
        //            All(x => {
        //                personaListado.Where(l => l.IdPersona == x.IdPersona).Where(l => l != null).All(l => {
        //                    l.AgregarReglaInfringida("", String.Format(MensajeReglaNegocio.DardeBajaRegistroAsociados, "Persona", "PersonaContactos"), "PersonaContactos");
        //                    return true;
        //                });
        //                return true;
        //            });
        //        return false;
        //    }
        //    if ( personaListadoActual.Where(x => x.PersonaNaturales != null).Any(x => x.PersonaNaturales.Any()) ) {
        //        personaListadoActual.Where(x => x.PersonaNaturales.Any()).
        //            All(x => {
        //                personaListado.Where(l => l.IdPersona == x.IdPersona).Where(l => l != null).All(l => {
        //                    l.AgregarReglaInfringida("", String.Format(MensajeReglaNegocio.DardeBajaRegistroAsociados, "Persona", "PersonaNaturales"), "PersonaNaturales");
        //                    return true;
        //                });
        //                return true;
        //            });
        //        return false;
        //    }
        //    if ( personaListadoActual.Where(x => x.PersonaIdentificaciones != null).Any(x => x.PersonaIdentificaciones.Any()) ) {
        //        personaListadoActual.Where(x => x.PersonaIdentificaciones.Any()).
        //            All(x => {
        //                personaListado.Where(l => l.IdPersona == x.IdPersona).Where(l => l != null).All(l => {
        //                    l.AgregarReglaInfringida("", String.Format(MensajeReglaNegocio.DardeBajaRegistroAsociados, "Persona", "PersonaIdentificaciones"), "PersonaIdentificaciones");
        //                    return true;
        //                });
        //                return true;
        //            });
        //        return false;
        //    }
        //    if ( personaListadoActual.Where(x => x.PersonaNacionalidades != null).Any(x => x.PersonaNacionalidades.Any()) ) {
        //        personaListadoActual.Where(x => x.PersonaNacionalidades.Any()).
        //            All(x => {
        //                personaListado.Where(l => l.IdPersona == x.IdPersona).Where(l => l != null).All(l => {
        //                    l.AgregarReglaInfringida("", String.Format(MensajeReglaNegocio.DardeBajaRegistroAsociados, "Persona", "PersonaNacionalidades"), "PersonaNacionalidades");
        //                    return true;
        //                });
        //                return true;
        //            });
        //        return false;
        //    }

        //    //Resultado
        //    return FachadaAdmAD.DarBajaListadoPersona(personaListado.Select(m => m.IdPersona).ToList());
        //}

        ///// <author>Ernesto Medrano</author>
        ///// <creationdate>16-sep-2015</creationdate>
        ///// <summary>
        ///// Método para eliminar un objeto de tipo Persona. 
        ///// </summary>
        ///// <param name="persona">Objeto a ser eliminado.</param>
        ///// <returns>True: Operación exitosa</returns>
        //public Boolean EliminarPersona(Entidades.Persona.Persona persona) {
        //    //Declaraciones
        //    Boolean resultado = true;
        //    TransactionScope transaccion;
        //    Entidades.Persona.Persona personaSeleccionado;

        //    //Operaciones
        //    if ( persona == null ) {
        //        throw new ArgumentNullException("persona", MensajeExcepcion.ParametroEnNulo);
        //    }
        //    if ( persona.IdPersona <= 0 ) {
        //        throw new ArgumentException(MensajeExcepcion.IdentificadorObjetoNoValido, "persona");
        //    }
        //    //Verificando colecciones (excluyendo colecciones M:M)
        //    personaSeleccionado = ObtenerPersona(persona.IdPersona,
        //     new Inclusiones.InclusionPersona() {
        //         GrupoPersonas = true,
        //         PersonaJuridicas = true,
        //         PersonaContactos = true,
        //         PersonaNaturales = true,
        //         PersonaIdentificaciones = true,
        //         PersonaNacionalidades = true,
        //         Direcciones = true,
        //         ActivoColecciones = Activo.Todos
        //     });
        //    if ( personaSeleccionado.PersonaJuridicas != null ) {
        //        if ( personaSeleccionado.PersonaJuridicas.Any() ) {
        //            persona.AgregarReglaInfringida("", String.Format(MensajeReglaNegocio.EliminacionRegistrosAsociados, "Persona", "PersonaJuridicas"), "PersonaJuridicas");
        //            return false;
        //        }
        //    }
        //    if ( personaSeleccionado.PersonaContactos != null ) {
        //        if ( personaSeleccionado.PersonaContactos.Any() ) {
        //            persona.AgregarReglaInfringida("", String.Format(MensajeReglaNegocio.EliminacionRegistrosAsociados, "Persona", "PersonaContactos"), "PersonaContactos");
        //            return false;
        //        }
        //    }
        //    if ( personaSeleccionado.PersonaNaturales != null ) {
        //        if ( personaSeleccionado.PersonaNaturales.Any() ) {
        //            persona.AgregarReglaInfringida("", String.Format(MensajeReglaNegocio.EliminacionRegistrosAsociados, "Persona", "PersonaNaturales"), "PersonaNaturales");
        //            return false;
        //        }
        //    }
        //    if ( personaSeleccionado.PersonaIdentificaciones != null ) {
        //        if ( personaSeleccionado.PersonaIdentificaciones.Any() ) {
        //            persona.AgregarReglaInfringida("", String.Format(MensajeReglaNegocio.EliminacionRegistrosAsociados, "Persona", "PersonaIdentificaciones"), "PersonaIdentificaciones");
        //            return false;
        //        }
        //    }
        //    if ( personaSeleccionado.PersonaNacionalidades != null ) {
        //        if ( personaSeleccionado.PersonaNacionalidades.Any() ) {
        //            persona.AgregarReglaInfringida("", String.Format(MensajeReglaNegocio.EliminacionRegistrosAsociados, "Persona", "PersonaNacionalidades"), "PersonaNacionalidades");
        //            return false;
        //        }
        //    }
        //    using ( transaccion = new TransactionScope() ) {
        //        if ( personaSeleccionado.Direcciones.Count > 0 ) {
        //            resultado = FachadaAdmAD.EliminarListadoPersonaDireccion(persona.IdPersona, personaSeleccionado.Direcciones.Select(s => s.EntidadDestino.IdDireccion).ToList());
        //        } else {
        //            resultado = true;
        //        }
        //        if ( resultado == true ) {
        //            resultado = FachadaAdmAD.EliminarPersona(personaSeleccionado.IdPersona);
        //            if ( resultado == true ) {
        //                transaccion.Complete();
        //            }
        //        }
        //    }

        //    //Resultado
        //    return resultado;
        //}

        ///// <author>Ernesto Medrano</author>
        ///// <creationdate>16-sep-2015</creationdate>
        ///// <summary>
        ///// Método para eliminar un listado de objetos de tipo Persona.
        ///// </summary>
        ///// <param name="personaListado">Listado de identificadores de objetos.</param>
        ///// <returns>True: Operación exitosa</returns>
        //public Boolean EliminarListadoPersona(List<Entidades.Persona.Persona> personaListado) {

        //    //Declaraciones
        //    TransactionScope transaccion;
        //    Entidades.Persona.Persona personaSeleccionado;
        //    //Entidades.Persona.Persona persona = new Entidades.Persona.Persona();
        //    Boolean resultado = true;

        //    //Operaciones
        //    if ( personaListado == null ) {
        //        throw new ArgumentNullException("personaListado", MensajeExcepcion.ParametroEnNulo);
        //    }

        //    if ( personaListado.Count() <= 0 ) {
        //        throw new ArgumentException(MensajeExcepcion.ParametroListaVacia, "personaListado");
        //    }

        //    if ( personaListado.Where(mo => mo.IdPersona <= 0).Count() > 0 ) {
        //        throw new ArgumentException(MensajeExcepcion.IdentificadorObjetoNoValidoListado, "personaListado");
        //    }

        //    using ( transaccion = new TransactionScope() ) {
        //        foreach ( var persona in personaListado ) {
        //            personaSeleccionado = ObtenerPersona(persona.IdPersona,
        //                new Inclusiones.InclusionPersona() {
        //                    GrupoPersonas = true,
        //                    PersonaJuridicas = true,
        //                    PersonaContactos = true,
        //                    PersonaNaturales = true,
        //                    PersonaIdentificaciones = true,
        //                    PersonaNacionalidades = true,
        //                    Direcciones = true,
        //                    ActivoColecciones = Activo.Todos
        //                });

        //            if ( personaSeleccionado.PersonaJuridicas != null ) {
        //                if ( personaSeleccionado.PersonaJuridicas.Any() ) {
        //                    persona.AgregarReglaInfringida("", String.Format(MensajeReglaNegocio.EliminacionRegistrosAsociados, "Persona", "PersonaJuridicas"), "PersonaJuridicas");
        //                    return false;
        //                }
        //            }

        //            if ( personaSeleccionado.PersonaContactos != null ) {
        //                if ( personaSeleccionado.PersonaContactos.Any() ) {
        //                    persona.AgregarReglaInfringida("", String.Format(MensajeReglaNegocio.EliminacionRegistrosAsociados, "Persona", "PersonaContactos"), "PersonaContactos");
        //                    return false;
        //                }
        //            }

        //            if ( personaSeleccionado.PersonaNaturales != null ) {
        //                if ( personaSeleccionado.PersonaNaturales.Any() ) {
        //                    persona.AgregarReglaInfringida("", String.Format(MensajeReglaNegocio.EliminacionRegistrosAsociados, "Persona", "PersonaNaturales"), "PersonaNaturales");
        //                    return false;
        //                }
        //            }

        //            if ( personaSeleccionado.PersonaIdentificaciones != null ) {
        //                if ( personaSeleccionado.PersonaIdentificaciones.Any() ) {
        //                    persona.AgregarReglaInfringida("", String.Format(MensajeReglaNegocio.EliminacionRegistrosAsociados, "Persona", "PersonaIdentificaciones"), "PersonaIdentificaciones");
        //                    return false;
        //                }
        //            }

        //            if ( personaSeleccionado.PersonaNacionalidades != null ) {
        //                if ( personaSeleccionado.PersonaNacionalidades.Any() ) {
        //                    persona.AgregarReglaInfringida("", String.Format(MensajeReglaNegocio.EliminacionRegistrosAsociados, "Persona", "PersonaNacionalidades"), "PersonaNacionalidades");
        //                    return false;
        //                }
        //            }
        //            using ( transaccion = new TransactionScope() ) {
        //                if ( personaSeleccionado.Direcciones.Count > 0 ) {
        //                    resultado = FachadaAdmAD.EliminarListadoPersonaDireccion(persona.IdPersona, personaSeleccionado.Direcciones.Select(s => s.EntidadDestino.IdDireccion).ToList());
        //                } else {
        //                    resultado = true;
        //                }
        //                if ( resultado == true ) {
        //                    resultado = FachadaAdmAD.EliminarPersona(personaSeleccionado.IdPersona);
        //                }
        //            }
        //        }
        //        if ( resultado == true ) {
        //            transaccion.Complete();
        //        }
        //    }


        //    //Resultado            
        //    return resultado;
        //}

        ///// <author>Ernesto Medrano</author>
        ///// <creationdate>16-sep-2015</creationdate>
        ///// <summary>
        ///// Método para obtener un componente Persona, y sus Colecciones.
        ///// </summary>
        ///// <param name="idPersona">Identificador del objeto.</param>
        ///// <param name="inclusionPersona">Indica si se cargaran las colecciones del objeto Persona       
        ///// <returns>Retorna un objeto de tipo Persona.</returns>
        //public Entidades.Persona.Persona ObtenerPersona(Int32 idPersona, Inclusiones.InclusionPersona inclusionPersona = null) {
        //    //Declaraciones
        //    Entidades.Persona.Persona persona;
        //    String nombreBaseDatos;
        //    List<RegistroBloqueo> registroBloqueoPersonaJuridicas;
        //    List<RegistroBloqueo> registroBloqueoPersonaContactos;
        //    List<RegistroBloqueo> registroBloqueoPersonaNaturales;
        //    List<RegistroBloqueo> registroBloqueoPersonaIdentificaciones;
        //    List<RegistroBloqueo> registroBloqueoPersonaNacionalidades;

        //    //Operaciones
        //    if ( idPersona <= 0 ) {
        //        throw new ArgumentException(MensajeExcepcion.IdentificadorObjetoNoValido, "idPersona");
        //    }
        //    nombreBaseDatos = ManejadorConfiguracion.ObtenerValor("administracionConfig", "baseDatosConfig", "BaseDatos");
        //    persona = FachadaAdmAD.ObtenerPersona(idPersona);
        //    if ( persona != null && inclusionPersona != null ) {
        //        //Propiedades complejas
        //        if ( inclusionPersona.TipoPersona == true ) {
        //            persona.TipoPersona = FachadaAdmAD.ObtenerValor(persona.TipoPersona.IdValor);
        //        }
        //        //Propiedades de colección                
        //        if ( inclusionPersona.PersonaJuridicas == true ) {
        //            persona.PersonaJuridicas = FachadaAdmAD.ObtenerListadoPersonaJuridicaPorIdPersona(idPersona, inclusionPersona.ActivoColecciones);
        //        }
        //        if ( inclusionPersona.PersonaContactos == true ) {
        //            persona.PersonaContactos = FachadaAdmAD.ObtenerListadoPorIdPersona(idPersona, Activo.Todos);
        //        }
        //        if ( inclusionPersona.PersonaNaturales == true ) {
        //            persona.PersonaNaturales = FachadaAdmAD.ObtenerListadoPersonaNaturalPorPersona(idPersona, inclusionPersona.ActivoColecciones);
        //        }
        //        if ( inclusionPersona.PersonaIdentificaciones == true ) {
        //            persona.PersonaIdentificaciones = FachadaAdmAD.ObtenerListadoPersonaIdentificacionPorPersona(idPersona, inclusionPersona.ActivoColecciones);
        //        }
        //        if ( inclusionPersona.PersonaNacionalidades == true ) {
        //            persona.PersonaNacionalidades = FachadaAdmAD.ObtenerListadoPersonaNacionalidadPorIdPersona(idPersona, inclusionPersona.ActivoColecciones);
        //        }
        //        if ( inclusionPersona.Direcciones == true ) {
        //            persona.Direcciones = FachadaAdmAD.ObtenerListadoDireccionPorPersona(idPersona, inclusionPersona.ActivoColecciones);
        //            if ( inclusionPersona.RegistroBloqueo == true ) {
        //                persona.Direcciones.All(l => {
        //                    l.EntidadDestino.RegistroBloqueo = ManejadorBloqueo.ObtenerDatosBloqueo(l.EntidadDestino.IdDireccion, EntidadTabla.Direccion, nombreBaseDatos);
        //                    return true;
        //                });
        //                persona.Direcciones.Where(x => x.EntidadDestino.RegistroBloqueo != null).All(l => {
        //                    l.EntidadDestino.EstaBloqueado = true;
        //                    return true;
        //                });
        //            }
        //        }
        //        if ( inclusionPersona.GrupoPersonas == true ) {
        //            persona.GrupoPersonas = FachadaAdmAD.ObtenerListadoGrupoPersonaPorPersona(idPersona, inclusionPersona.ActivoColecciones);
        //            if ( inclusionPersona.RegistroBloqueo == true ) {
        //                persona.GrupoPersonas.All(l => {
        //                    l.RegistroBloqueo = ManejadorBloqueo.ObtenerDatosBloqueo(l.IdGrupoPersona, EntidadTabla.GrupoPersona, nombreBaseDatos);
        //                    return true;
        //                });
        //                persona.GrupoPersonas.Where(x => x.RegistroBloqueo != null).All(l => {
        //                    l.EstaBloqueado = true;
        //                    return true;
        //                });
        //            }
        //        }
        //        if ( inclusionPersona.RegistroBloqueo == true ) {
        //            try {
        //                persona.RegistroBloqueo = ManejadorBloqueo.ObtenerDatosBloqueo(idPersona, EntidadTabla.Persona, nombreBaseDatos);
        //                if ( persona.RegistroBloqueo != null ) {
        //                    persona.EstaBloqueado = true;
        //                }
        //            } catch ( RegistroNoEncontradoExcepcion ) {
        //                persona.RegistroBloqueo = null;
        //                persona.EstaBloqueado = true;
        //            }
        //        }
        //        //Cargando registrobloqueo para las colecciones.                
        //        if ( inclusionPersona.PersonaJuridicas == true && persona.PersonaJuridicas != null ) {
        //            registroBloqueoPersonaJuridicas = ManejadorBloqueo.ObtenerDatosBloqueoListado(EntidadTabla.PersonaJuridica, nombreBaseDatos, persona.PersonaJuridicas.Select(x => x.IdPersonaJuridica).ToList());
        //            persona.PersonaJuridicas.All(l => {
        //                l.RegistroBloqueo = registroBloqueoPersonaJuridicas.FirstOrDefault(x => x.IdRegistro == l.IdPersonaJuridica);
        //                return true;
        //            });
        //            persona.PersonaJuridicas.Where(x => x.RegistroBloqueo != null).All(l => {
        //                l.EstaBloqueado = true;
        //                return true;
        //            });
        //        }
        //        if ( inclusionPersona.PersonaContactos == true && persona.PersonaContactos != null ) {
        //            registroBloqueoPersonaContactos = ManejadorBloqueo.ObtenerDatosBloqueoListado(EntidadTabla.PersonaContacto, nombreBaseDatos, persona.PersonaContactos.Select(x => x.IdPersonaContacto).ToList());
        //            persona.PersonaContactos.All(l => {
        //                l.RegistroBloqueo = registroBloqueoPersonaContactos.FirstOrDefault(x => x.IdRegistro == l.IdPersonaContacto);
        //                return true;
        //            });
        //            persona.PersonaContactos.Where(x => x.RegistroBloqueo != null).All(l => {
        //                l.EstaBloqueado = true;
        //                return true;
        //            });
        //        }
        //        if ( inclusionPersona.PersonaNaturales == true && persona.PersonaNaturales != null ) {
        //            registroBloqueoPersonaNaturales = ManejadorBloqueo.ObtenerDatosBloqueoListado(EntidadTabla.PersonaNatural, nombreBaseDatos, persona.PersonaNaturales.Select(x => x.IdPersonaNatural).ToList());
        //            persona.PersonaNaturales.All(l => {
        //                l.RegistroBloqueo = registroBloqueoPersonaNaturales.FirstOrDefault(x => x.IdRegistro == l.IdPersonaNatural);
        //                return true;
        //            });
        //            persona.PersonaNaturales.Where(x => x.RegistroBloqueo != null).All(l => {
        //                l.EstaBloqueado = true;
        //                return true;
        //            });
        //        }
        //        if ( inclusionPersona.PersonaIdentificaciones == true && persona.PersonaIdentificaciones != null ) {
        //            registroBloqueoPersonaIdentificaciones = ManejadorBloqueo.ObtenerDatosBloqueoListado(EntidadTabla.PersonaIdentificacion, nombreBaseDatos, persona.PersonaIdentificaciones.Select(x => x.IdPersonaIdentificacion).ToList());
        //            persona.PersonaIdentificaciones.All(l => {
        //                l.RegistroBloqueo = registroBloqueoPersonaIdentificaciones.FirstOrDefault(x => x.IdRegistro == l.IdPersonaIdentificacion);
        //                return true;
        //            });
        //            persona.PersonaIdentificaciones.Where(x => x.RegistroBloqueo != null).All(l => {
        //                l.EstaBloqueado = true;
        //                return true;
        //            });
        //        }
        //        if ( inclusionPersona.PersonaNacionalidades == true && persona.PersonaNacionalidades != null ) {
        //            registroBloqueoPersonaNacionalidades = ManejadorBloqueo.ObtenerDatosBloqueoListado(EntidadTabla.PersonaNacionalidad, nombreBaseDatos, persona.PersonaNacionalidades.Select(x => x.IdPersonaNacionalidad).ToList());
        //            persona.PersonaNacionalidades.All(l => {
        //                l.RegistroBloqueo = registroBloqueoPersonaNacionalidades.FirstOrDefault(x => x.IdRegistro == l.IdPersonaNacionalidad);
        //                return true;
        //            });
        //            persona.PersonaNacionalidades.Where(x => x.RegistroBloqueo != null).All(l => {
        //                l.EstaBloqueado = true;
        //                return true;
        //            });
        //        }
        //    }

        //    //Resultado
        //    return persona;
        //}

        ///// <author>Ernesto Medrano</author>
        ///// <creationdate>16-sep-2015</creationdate>
        ///// <summary>
        ///// Método para obtener un listado de objetos de tipo Persona.
        ///// </summary>
        ///// <param name="activo">Estado de los Objetos de tipo Persona.</param>
        ///// <param name="inclusionPersona">Indica si se cargaran las colecciones del objeto Persona 
        ///// que posee el componente.</param>
        ///// <returns></returns>
        //public List<Entidades.Persona.Persona> ObtenerListadoPersona(Activo activo, Inclusiones.InclusionPersona inclusionPersona = null) {
        //    //Declaraciones
        //    List<Entidades.Persona.Persona> personaListado;
        //    List<RegistroBloqueo> registroBloqueoListado;
        //    List<RegistroBloqueo> registroBloqueoGrupoPersonas;
        //    List<RegistroBloqueo> registroBloqueoDirecciones;
        //    List<RegistroBloqueo> registroBloqueoPersonaJuridicas;
        //    List<RegistroBloqueo> registroBloqueoPersonaContactos;
        //    List<RegistroBloqueo> registroBloqueoPersonaNaturales;
        //    List<RegistroBloqueo> registroBloqueoPersonaIdentificaciones;
        //    List<RegistroBloqueo> registroBloqueoPersonaNacionalidades;
        //    List<Int32> idPersonaListado;
        //    String nombreBaseDatos;

        //    //Operaciones
        //    if ( !Enum.IsDefined(typeof(Activo), activo) ) {
        //        throw new ArgumentOutOfRangeException("activo", MensajeExcepcion.EnumeracionValorInvalido);
        //    }
        //    nombreBaseDatos = ManejadorConfiguracion.ObtenerValor("administracionConfig", "baseDatosConfig", "BaseDatos");
        //    personaListado = FachadaAdmAD.ObtenerListadoPersona(activo);
        //    if ( personaListado.Count > 0 && inclusionPersona != null ) {
        //        //Extrayendo Ids
        //        idPersonaListado = personaListado.Select(x => x.IdPersona).ToList();
        //        //Propiedades complejas            
        //        if ( inclusionPersona.TipoPersona == true ) {
        //            var tipoPersonaListado = FachadaAdmAD.ObtenerListadoValor(personaListado.Select(p => p.TipoPersona.IdValor).ToList());
        //            personaListado.All(l => {
        //                l.TipoPersona = tipoPersonaListado.FirstOrDefault(x => x.IdValor == l.TipoPersona.IdValor);
        //                return true;
        //            });
        //        }
        //        //Cargando Registro Bloqueo para las Cuentas
        //        if ( inclusionPersona.RegistroBloqueo == true ) {
        //            registroBloqueoListado = ManejadorBloqueo.ObtenerDatosBloqueoListado(EntidadTabla.Persona, nombreBaseDatos, idPersonaListado);
        //            personaListado.All(l => {
        //                l.RegistroBloqueo = registroBloqueoListado.FirstOrDefault(x => x.IdRegistro == l.IdPersona);
        //                return true;
        //            });
        //            personaListado.Where(x => x.RegistroBloqueo != null).All(l => {
        //                l.EstaBloqueado = true;
        //                return true;
        //            });
        //        }
        //        if ( inclusionPersona.Direcciones == true ) {
        //            var direccionesListado = FachadaAdmAD.ObtenerListadoDireccionPorPersona(idPersonaListado, inclusionPersona.ActivoColecciones);
        //            if ( inclusionPersona.RegistroBloqueo == true ) {
        //                registroBloqueoDirecciones = ManejadorBloqueo.ObtenerDatosBloqueoListado(EntidadTabla.PersonaDireccion, nombreBaseDatos, direccionesListado.Select(x => x.IdRelacion).ToList());
        //                direccionesListado.All(l => {
        //                    l.RegistroBloqueo = registroBloqueoDirecciones.FirstOrDefault(x => x.IdRegistro == l.IdRelacion);
        //                    return true;
        //                });
        //                direccionesListado.Where(x => x.RegistroBloqueo != null).All(l => {
        //                    l.EstaBloqueado = true;
        //                    return true;
        //                });
        //            }
        //            personaListado.All(l => {
        //                l.Direcciones = direccionesListado.Where(x => x.EntidadOrigen.IdPersona == l.IdPersona).ToList();
        //                return true;
        //            });
        //        }
        //        if ( inclusionPersona.GrupoPersonas == true ) {
        //            List<GrupoPersona> grupoPersonasListado = new List<GrupoPersona>();
        //            foreach ( var idPersona in idPersonaListado ) {
        //                grupoPersonasListado = FachadaAdmAD.ObtenerListadoGrupoPersonaPorPersona(idPersona, inclusionPersona.ActivoColecciones);
        //            }
        //            if ( inclusionPersona.RegistroBloqueo == true ) {
        //                registroBloqueoGrupoPersonas = ManejadorBloqueo.ObtenerDatosBloqueoListado(EntidadTabla.GrupoPersona, nombreBaseDatos, grupoPersonasListado.Select(x => x.IdGrupoPersona).ToList());
        //                grupoPersonasListado.All(l => {
        //                    l.RegistroBloqueo = registroBloqueoGrupoPersonas.FirstOrDefault(x => x.IdRegistro == l.IdGrupoPersona);
        //                    return true;
        //                });
        //                grupoPersonasListado.Where(x => x.RegistroBloqueo != null).All(l => {
        //                    l.EstaBloqueado = true;
        //                    return true;
        //                });
        //            }
        //            personaListado.All(l => {
        //                l.GrupoPersonas = grupoPersonasListado.Where(x => x.Persona.IdPersona == l.IdPersona).ToList();
        //                return true;
        //            });
        //        }
        //        if ( inclusionPersona.PersonaJuridicas == true ) {
        //            var personaJuridicasListado = FachadaAdmAD.ObtenerListadoPersonaJuridicaPorListadoIdPersona(idPersonaListado, inclusionPersona.ActivoColecciones);
        //            if ( inclusionPersona.RegistroBloqueo == true ) {
        //                registroBloqueoPersonaJuridicas = ManejadorBloqueo.ObtenerDatosBloqueoListado(EntidadTabla.PersonaJuridica, nombreBaseDatos, personaJuridicasListado.Select(x => x.IdPersonaJuridica).ToList());
        //                personaJuridicasListado.All(l => {
        //                    l.RegistroBloqueo = registroBloqueoPersonaJuridicas.FirstOrDefault(x => x.IdRegistro == l.IdPersonaJuridica);
        //                    return true;
        //                });
        //                personaJuridicasListado.Where(x => x.RegistroBloqueo != null).All(l => {
        //                    l.EstaBloqueado = true;
        //                    return true;
        //                });
        //            }
        //            personaListado.All(l => {
        //                l.PersonaJuridicas = personaJuridicasListado.Where(x => x.Persona.IdPersona == l.IdPersona).ToList();
        //                return true;
        //            });
        //        }
        //        if ( inclusionPersona.PersonaContactos == true ) {
        //            var personaContactosListado = FachadaAdmAD.ObtenerListadoPorListadoIdPersona(idPersonaListado, inclusionPersona.ActivoColecciones);
        //            if ( inclusionPersona.RegistroBloqueo == true ) {
        //                registroBloqueoPersonaContactos = ManejadorBloqueo.ObtenerDatosBloqueoListado(EntidadTabla.PersonaContacto, nombreBaseDatos, personaContactosListado.Select(x => x.IdPersonaContacto).ToList());
        //                personaContactosListado.All(l => {
        //                    l.RegistroBloqueo = registroBloqueoPersonaContactos.FirstOrDefault(x => x.IdRegistro == l.IdPersonaContacto);
        //                    return true;
        //                });
        //                personaContactosListado.Where(x => x.RegistroBloqueo != null).All(l => {
        //                    l.EstaBloqueado = true;
        //                    return true;
        //                });
        //            }
        //            personaListado.All(l => {
        //                l.PersonaContactos = personaContactosListado.Where(x => x.Persona.IdPersona == l.IdPersona).ToList();
        //                return true;
        //            });
        //        }
        //        if ( inclusionPersona.PersonaNaturales == true ) {
        //            var personaNaturalesListado = FachadaAdmAD.ObtenerListadoPersonaNaturalPorPersona(idPersonaListado, inclusionPersona.ActivoColecciones);
        //            if ( inclusionPersona.RegistroBloqueo == true ) {
        //                registroBloqueoPersonaNaturales = ManejadorBloqueo.ObtenerDatosBloqueoListado(EntidadTabla.PersonaNatural, nombreBaseDatos, personaNaturalesListado.Select(x => x.IdPersonaNatural).ToList());
        //                personaNaturalesListado.All(l => {
        //                    l.RegistroBloqueo = registroBloqueoPersonaNaturales.FirstOrDefault(x => x.IdRegistro == l.IdPersonaNatural);
        //                    return true;
        //                });
        //                personaNaturalesListado.Where(x => x.RegistroBloqueo != null).All(l => {
        //                    l.EstaBloqueado = true;
        //                    return true;
        //                });
        //            }
        //            personaListado.All(l => {
        //                l.PersonaNaturales = personaNaturalesListado.Where(x => x.Persona.IdPersona == l.IdPersona).ToList();
        //                return true;
        //            });
        //        }
        //        if ( inclusionPersona.PersonaIdentificaciones == true ) {
        //            var personaIdentificacionesListado = FachadaAdmAD.ObtenerListadoPersonaIdentificacionPorPersona(idPersonaListado, inclusionPersona.ActivoColecciones);
        //            if ( inclusionPersona.RegistroBloqueo == true ) {
        //                registroBloqueoPersonaIdentificaciones = ManejadorBloqueo.ObtenerDatosBloqueoListado(EntidadTabla.PersonaIdentificacion, nombreBaseDatos, personaIdentificacionesListado.Select(x => x.IdPersonaIdentificacion).ToList());
        //                personaIdentificacionesListado.All(l => {
        //                    l.RegistroBloqueo = registroBloqueoPersonaIdentificaciones.FirstOrDefault(x => x.IdRegistro == l.IdPersonaIdentificacion);
        //                    return true;
        //                });
        //                personaIdentificacionesListado.Where(x => x.RegistroBloqueo != null).All(l => {
        //                    l.EstaBloqueado = true;
        //                    return true;
        //                });
        //            }
        //            personaListado.All(l => {
        //                l.PersonaIdentificaciones = personaIdentificacionesListado.Where(x => x.Persona.IdPersona == l.IdPersona).ToList();
        //                return true;
        //            });
        //        }
        //        if ( inclusionPersona.PersonaNacionalidades == true ) {
        //            List<PersonaNacionalidad> personaNacionalidadesListado = new List<PersonaNacionalidad>();
        //            foreach ( var idPersona in idPersonaListado ) {
        //                personaNacionalidadesListado = FachadaAdmAD.ObtenerListadoPersonaNacionalidadPorIdPersona(idPersona, inclusionPersona.ActivoColecciones);
        //            }
        //            if ( inclusionPersona.RegistroBloqueo == true ) {
        //                registroBloqueoPersonaNacionalidades = ManejadorBloqueo.ObtenerDatosBloqueoListado(EntidadTabla.PersonaNacionalidad, nombreBaseDatos, personaNacionalidadesListado.Select(x => x.IdPersonaNacionalidad).ToList());
        //                personaNacionalidadesListado.All(l => {
        //                    l.RegistroBloqueo = registroBloqueoPersonaNacionalidades.FirstOrDefault(x => x.IdRegistro == l.IdPersonaNacionalidad);
        //                    return true;
        //                });
        //                personaNacionalidadesListado.Where(x => x.RegistroBloqueo != null).All(l => {
        //                    l.EstaBloqueado = true;
        //                    return true;
        //                });
        //            }
        //            personaListado.All(l => {
        //                l.PersonaNacionalidades = personaNacionalidadesListado.Where(x => x.Persona.IdPersona == l.IdPersona).ToList();
        //                return true;
        //            });
        //        }
        //    }

        //    //Resultado
        //    return personaListado;
        //}

        ///// <author>Ernesto Medrano</author>
        ///// <creationdate>16-sep-2015</creationdate>
        ///// <summary>
        ///// Método para obtener un listado de objetos de tipo Persona.
        ///// </summary>
        ///// <param name="idPersonaListado">Lisrtado de identificador de objetos.</param>
        ///// <param name="inclusionOpcionUsuario">Indica si se cargaran las colecciones
        ///// que posee el componente.</param>
        ///// <returns></returns>
        //public List<Entidades.Persona.Persona> ObtenerListadoPersona(List<Int32> idPersonaListado, Inclusiones.InclusionPersona inclusionPersona = null) {
        //    //Declaraciones
        //    List<Entidades.Persona.Persona> personaListado;
        //    List<Entidades.Persona.Grupo> GrupoPersonasListado;
        //    List<Entidades.Persona.PersonaJuridica> PersonaJuridicasListado;
        //    List<Entidades.Persona.PersonaContacto> PersonaContactosListado;
        //    List<Entidades.Persona.PersonaNatural> PersonaNaturalesListado;
        //    List<Entidades.Persona.PersonaIdentificacion> PersonaIdentificacionesListado;
        //    List<Entidades.Persona.PersonaNacionalidad> PersonaNacionalidadesListado;
        //    List<RegistroBloqueo> registroBloqueoListado;
        //    List<RegistroBloqueo> registroBloqueoDirecciones;
        //    List<RegistroBloqueo> registroBloqueoGrupoPersonas;
        //    List<RegistroBloqueo> registroBloqueoPersonaJuridicas;
        //    List<RegistroBloqueo> registroBloqueoPersonaContactos;
        //    List<RegistroBloqueo> registroBloqueoPersonaNaturales;
        //    List<RegistroBloqueo> registroBloqueoPersonaIdentificaciones;
        //    List<RegistroBloqueo> registroBloqueoPersonaNacionalidades;
        //    List<Int32> listadoIdPersona;
        //    String nombreBaseDatos;

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
        //    nombreBaseDatos = ManejadorConfiguracion.ObtenerValor("administracionConfig", "baseDatosConfig", "BaseDatos");
        //    personaListado = FachadaAdmAD.ObtenerListadoPersona(idPersonaListado);
        //    if ( personaListado.Count > 0 && inclusionPersona != null ) {
        //        //Extrayendo Ids
        //        idPersonaListado = personaListado.Select(x => x.IdPersona).ToList();
        //        //Propiedades complejas            
        //        if ( inclusionPersona.TipoPersona == true ) {
        //            var tipoPersonaListado = FachadaAdmAD.ObtenerListadoValor(personaListado.Select(p => p.TipoPersona.IdValor).ToList());
        //            personaListado.All(l => {
        //                l.TipoPersona = tipoPersonaListado.FirstOrDefault(x => x.IdValor == l.TipoPersona.IdValor);
        //                return true;
        //            });
        //        }
        //        //Cargando Registro Bloqueo para las Cuentas
        //        if ( inclusionPersona.RegistroBloqueo == true ) {
        //            registroBloqueoListado = ManejadorBloqueo.ObtenerDatosBloqueoListado(EntidadTabla.Persona, nombreBaseDatos, idPersonaListado);
        //            personaListado.All(l => {
        //                l.RegistroBloqueo = registroBloqueoListado.FirstOrDefault(x => x.IdRegistro == l.IdPersona);
        //                return true;
        //            });
        //            personaListado.Where(x => x.RegistroBloqueo != null).All(l => {
        //                l.EstaBloqueado = true;
        //                return true;
        //            });
        //        }
        //        if ( inclusionPersona.Direcciones == true ) {
        //            var direccionesListado = FachadaAdmAD.ObtenerListadoDireccionPorPersona(idPersonaListado, inclusionPersona.ActivoColecciones);
        //            if ( inclusionPersona.RegistroBloqueo == true ) {
        //                registroBloqueoDirecciones = ManejadorBloqueo.ObtenerDatosBloqueoListado(EntidadTabla.PersonaDireccion, nombreBaseDatos, direccionesListado.Select(x => x.IdRelacion).ToList());
        //                direccionesListado.All(l => {
        //                    l.RegistroBloqueo = registroBloqueoDirecciones.FirstOrDefault(x => x.IdRegistro == l.IdRelacion);
        //                    return true;
        //                });
        //                direccionesListado.Where(x => x.RegistroBloqueo != null).All(l => {
        //                    l.EstaBloqueado = true;
        //                    return true;
        //                });
        //            }
        //            personaListado.All(l => {
        //                l.Direcciones = direccionesListado.Where(x => x.EntidadOrigen.IdPersona == l.IdPersona).ToList();
        //                return true;
        //            });
        //        }
        //        if ( inclusionPersona.GrupoPersonas == true ) {
        //            List<GrupoPersona> grupoPersonasListado = new List<GrupoPersona>();
        //            foreach ( var idPersona in idPersonaListado ) {
        //                grupoPersonasListado = FachadaAdmAD.ObtenerListadoGrupoPersonaPorPersona(idPersona, inclusionPersona.ActivoColecciones);
        //            }
        //            if ( inclusionPersona.RegistroBloqueo == true ) {
        //                registroBloqueoGrupoPersonas = ManejadorBloqueo.ObtenerDatosBloqueoListado(EntidadTabla.GrupoPersona, nombreBaseDatos, grupoPersonasListado.Select(x => x.IdGrupoPersona).ToList());
        //                grupoPersonasListado.All(l => {
        //                    l.RegistroBloqueo = registroBloqueoGrupoPersonas.FirstOrDefault(x => x.IdRegistro == l.IdGrupoPersona);
        //                    return true;
        //                });
        //                grupoPersonasListado.Where(x => x.RegistroBloqueo != null).All(l => {
        //                    l.EstaBloqueado = true;
        //                    return true;
        //                });
        //            }
        //            personaListado.All(l => {
        //                l.GrupoPersonas = grupoPersonasListado.Where(x => x.Persona.IdPersona == l.IdPersona).ToList();
        //                return true;
        //            });
        //        }
        //        if ( inclusionPersona.PersonaJuridicas == true ) {
        //            var personaJuridicasListado = FachadaAdmAD.ObtenerListadoPersonaJuridicaPorListadoIdPersona(idPersonaListado, inclusionPersona.ActivoColecciones);
        //            if ( inclusionPersona.RegistroBloqueo == true ) {
        //                registroBloqueoPersonaJuridicas = ManejadorBloqueo.ObtenerDatosBloqueoListado(EntidadTabla.PersonaJuridica, nombreBaseDatos, personaJuridicasListado.Select(x => x.IdPersonaJuridica).ToList());
        //                personaJuridicasListado.All(l => {
        //                    l.RegistroBloqueo = registroBloqueoPersonaJuridicas.FirstOrDefault(x => x.IdRegistro == l.IdPersonaJuridica);
        //                    return true;
        //                });
        //                personaJuridicasListado.Where(x => x.RegistroBloqueo != null).All(l => {
        //                    l.EstaBloqueado = true;
        //                    return true;
        //                });
        //            }
        //            personaListado.All(l => {
        //                l.PersonaJuridicas = personaJuridicasListado.Where(x => x.Persona.IdPersona == l.IdPersona).ToList();
        //                return true;
        //            });
        //        }
        //        if ( inclusionPersona.PersonaContactos == true ) {
        //            var personaContactosListado = FachadaAdmAD.ObtenerListadoPorListadoIdPersona(idPersonaListado, inclusionPersona.ActivoColecciones);
        //            if ( inclusionPersona.RegistroBloqueo == true ) {
        //                registroBloqueoPersonaContactos = ManejadorBloqueo.ObtenerDatosBloqueoListado(EntidadTabla.PersonaContacto, nombreBaseDatos, personaContactosListado.Select(x => x.IdPersonaContacto).ToList());
        //                personaContactosListado.All(l => {
        //                    l.RegistroBloqueo = registroBloqueoPersonaContactos.FirstOrDefault(x => x.IdRegistro == l.IdPersonaContacto);
        //                    return true;
        //                });
        //                personaContactosListado.Where(x => x.RegistroBloqueo != null).All(l => {
        //                    l.EstaBloqueado = true;
        //                    return true;
        //                });
        //            }
        //            personaListado.All(l => {
        //                l.PersonaContactos = personaContactosListado.Where(x => x.Persona.IdPersona == l.IdPersona).ToList();
        //                return true;
        //            });
        //        }
        //        if ( inclusionPersona.PersonaNaturales == true ) {
        //            var personaNaturalesListado = FachadaAdmAD.ObtenerListadoPersonaNaturalPorPersona(idPersonaListado, inclusionPersona.ActivoColecciones);
        //            if ( inclusionPersona.RegistroBloqueo == true ) {
        //                registroBloqueoPersonaNaturales = ManejadorBloqueo.ObtenerDatosBloqueoListado(EntidadTabla.PersonaNatural, nombreBaseDatos, personaNaturalesListado.Select(x => x.IdPersonaNatural).ToList());
        //                personaNaturalesListado.All(l => {
        //                    l.RegistroBloqueo = registroBloqueoPersonaNaturales.FirstOrDefault(x => x.IdRegistro == l.IdPersonaNatural);
        //                    return true;
        //                });
        //                personaNaturalesListado.Where(x => x.RegistroBloqueo != null).All(l => {
        //                    l.EstaBloqueado = true;
        //                    return true;
        //                });
        //            }
        //            personaListado.All(l => {
        //                l.PersonaNaturales = personaNaturalesListado.Where(x => x.Persona.IdPersona == l.IdPersona).ToList();
        //                return true;
        //            });
        //        }
        //        if ( inclusionPersona.PersonaIdentificaciones == true ) {
        //            var personaIdentificacionesListado = FachadaAdmAD.ObtenerListadoPersonaIdentificacionPorPersona(idPersonaListado, inclusionPersona.ActivoColecciones);
        //            if ( inclusionPersona.RegistroBloqueo == true ) {
        //                registroBloqueoPersonaIdentificaciones = ManejadorBloqueo.ObtenerDatosBloqueoListado(EntidadTabla.PersonaIdentificacion, nombreBaseDatos, personaIdentificacionesListado.Select(x => x.IdPersonaIdentificacion).ToList());
        //                personaIdentificacionesListado.All(l => {
        //                    l.RegistroBloqueo = registroBloqueoPersonaIdentificaciones.FirstOrDefault(x => x.IdRegistro == l.IdPersonaIdentificacion);
        //                    return true;
        //                });
        //                personaIdentificacionesListado.Where(x => x.RegistroBloqueo != null).All(l => {
        //                    l.EstaBloqueado = true;
        //                    return true;
        //                });
        //            }
        //            personaListado.All(l => {
        //                l.PersonaIdentificaciones = personaIdentificacionesListado.Where(x => x.Persona.IdPersona == l.IdPersona).ToList();
        //                return true;
        //            });
        //        }
        //        if ( inclusionPersona.PersonaNacionalidades == true ) {
        //            List<PersonaNacionalidad> personaNacionalidadesListado = new List<PersonaNacionalidad>();
        //            foreach ( var idPersona in idPersonaListado ) {
        //                personaNacionalidadesListado = FachadaAdmAD.ObtenerListadoPersonaNacionalidadPorIdPersona(idPersona, inclusionPersona.ActivoColecciones);
        //            }
        //            if ( inclusionPersona.RegistroBloqueo == true ) {
        //                registroBloqueoPersonaNacionalidades = ManejadorBloqueo.ObtenerDatosBloqueoListado(EntidadTabla.PersonaNacionalidad, nombreBaseDatos, personaNacionalidadesListado.Select(x => x.IdPersonaNacionalidad).ToList());
        //                personaNacionalidadesListado.All(l => {
        //                    l.RegistroBloqueo = registroBloqueoPersonaNacionalidades.FirstOrDefault(x => x.IdRegistro == l.IdPersonaNacionalidad);
        //                    return true;
        //                });
        //                personaNacionalidadesListado.Where(x => x.RegistroBloqueo != null).All(l => {
        //                    l.EstaBloqueado = true;
        //                    return true;
        //                });
        //            }
        //            personaListado.All(l => {
        //                l.PersonaNacionalidades = personaNacionalidadesListado.Where(x => x.Persona.IdPersona == l.IdPersona).ToList();
        //                return true;
        //            });
        //        }
        //    }

        //    //Resultado
        //    return personaListado;
        //}

        ///// <author>Ernesto Medrano</author>
        ///// <creationdate>25-08-2015</creationdate>
        ///// <summary>
        ///// Se obtiene el listado de persona mediante un criterio especifico.
        ///// </summary>
        ///// <param name="nombreCompleto"></param>
        ///// <returns>Listado Persona</returns>
        //public List<EstructuraInteresados> ObtenerListadoPersonaPorNombreCompleto(String nombreCompleto) {
        //    Boolean resultado = false;
        //    var idPersona = 0;
        //    List<EstructuraInteresados> listado = new List<EstructuraInteresados>();
        //    List<EstructuraInteresados> listadoJ = new List<EstructuraInteresados>();
        //    List<EstructuraInteresados> listadoCompleto = new List<EstructuraInteresados>();
        //    //List<Persona> persona = new List<Persona>();

        //    List<PersonaNatural> ListadoPersonaNatural = new List<PersonaNatural>();
        //    List<PersonaJuridica> ListadoPersonaJuridica = new List<PersonaJuridica>();

        //    Int32 identificador = 0;
        //    string nombre = string.Empty;

        //    ListadoPersonaNatural = FachadaAdmAD.ObtenerListadoPersonaNaturalPorCriterio(new PersonaNatural() { NombreCompleto = nombreCompleto }, Activo.Todos);
        //    ListadoPersonaJuridica = this.ObtenerListadoPersonaJuridicaPorRazonSocial(nombreCompleto, Activo.Todos);

        //    ////persona = RepositorioDig.ObtenerListadoPersona(Activo.Si, new InclusionPersona() { PersonaIdentificaciones = true, PersonaNaturales = true, PersonaJuridicas = true });           
        //    //ListadoPersonaNatural = persona.SelectMany(x => x.PersonaNaturales).ToList();

        //    //var identificaciones = persona.SelectMany(x => x.PersonaIdentificaciones.Where(y => y.EsPrincipal == true));
        //    //var personaJuridica = persona.SelectMany(x => x.PersonaJuridicas);

        //    //var listadoPersonas = (from pn in ListadoPersonaNatural
        //    //                       join i in identificaciones on pn.Persona.IdPersona equals i.Persona.IdPersona into pi
        //    //                       from id in pi.DefaultIfEmpty()
        //    //                       where ((pn.NombreCompleto != null) ? RemoverAcento(pn.NombreCompleto).ToLowerInvariant().Contains(nombre.ToLowerInvariant()) : false)
        //    //                       select new { pn.Persona.IdPersona, pn.NombreCompleto, CodigoIdentificacion = (id == null ? String.Empty : id.CodigoIdentificacion), pn.EstaActivo, pn.EstaBloqueado }).ToList();

        //    //var listadoPersonasJuridicas = (from pj in personaJuridica
        //    //                                join i in identificaciones on pj.Persona.IdPersona equals i.Persona.IdPersona into pi
        //    //                                from id in pi.DefaultIfEmpty()
        //    //                                where ((pj.RazonSocial != null) ? RemoverAcento(pj.RazonSocial).ToLowerInvariant().Contains(nombre.ToLowerInvariant()) : false)
        //    //                                select new { pj.Persona.IdPersona, pj.RazonSocial, CodigoIdentificacion = (id == null ? String.Empty : id.CodigoIdentificacion), pj.EstaActivo, pj.EstaBloqueado }).ToList();

        //    listado.AddRange(ListadoPersonaNatural.Select(lObjetoInteresado => new EstructuraInteresados {
        //        IdEstructura = identificador++,
        //        IdPersona = lObjetoInteresado.IdPersona,
        //        Identificacion = "001",//lObjetoInteresado.CodigoIdentificacion,
        //        Nombre = lObjetoInteresado.NombreCompleto,
        //    }).ToList());
        //    listadoCompleto.AddRange(listado);

        //    listadoJ.AddRange(ListadoPersonaJuridica.Select(lObjetoInteresado => new EstructuraInteresados {
        //        IdEstructura = identificador++,
        //        IdPersona = lObjetoInteresado.Persona.IdPersona,
        //        Identificacion = "001", //lObjetoInteresado.CodigoIdentificacion,
        //        Nombre = lObjetoInteresado.RazonSocial,
        //    }).ToList());

        //    listadoCompleto.AddRange(listadoJ);

        //    return listadoCompleto;
        //}

        /// <author>Ernesto Medrano</author>
        /// <creationdate>16-sep-2015</creationdate>
        /// <summary>
        /// Metódo para validar las transacciones u operaciones
        /// que se realizan en la entidad.
        /// </summary>
        /// <param name="persona">Objeto o entidad que se evalúa o valida.</param>
        /// <returns>Resultado de la Operación</returns>
        public Boolean ValidarPersona(Entidades.Persona.Persona persona) {

            //Declaraciones                        
            Boolean resultado = true;
            //ReglaNegocio reglaCamposMinimos = new ReglaNegocio();
            //ReglaNegocio reglaNegocio = new ReglaNegocio();
            List<Entidades.Persona.Persona> listadoPersonaActual;

            //Operaciones
            if ( persona == null ) {
                throw new ArgumentNullException("persona", MensajeExcepcion.ParametroEnNulo);
            }

            #region Reglas de Negocio

            /*
            //Reglas de Negocio
            listadoPersonaActual = ObtenerListadoPersona(Activo.Si);

            if (listadoPersonaActual.Where(grupo => grupo.Nombre == persona.Nombre && grupo.IdPersona != persona.IdPersona).Count() > 0) {
                resultado = false;
                reglaNegocio.Campos.Add("Nombre");
                reglaNegocio.Mensaje = MensajeReglaNegocio.NombreDuplicado;
                persona.ReglasInfringidas.Add(reglaNegocio);
            }

            if (listadoPersonaActual.Where(grupo => grupo.CodigoInterno == persona.CodigoInterno && grupo.IdPersona != persona.IdPersona).Count() > 0) {
                resultado = false;
                reglaNegocio.Campos.Add("CodigoInterno");
                reglaNegocio.Mensaje = reglaNegocio.Mensaje + Environment.NewLine + MensajeReglaNegocio.CodigoDuplicado;
                persona.ReglasInfringidas.Add(reglaNegocio);
            }
            */
            #endregion

            //Resultado
            return resultado;
        }

        //public List<EstructuraPersona> ObtenerListadoRangoPersona() {
        //    return FachadaAdmAD.ObtenerListadoRangoPersona();
        //}

        //public List<Entidades.Persona.Persona> ObtenerListadoPersonaRango(List<int> idPersonaListado, Inclusiones.InclusionPersona inclusionPersona = null) {
        //    return FachadaAdmAD.ObtenerListadoPersonaRango(idPersonaListado);
        //}

        //public List<EstructuraPersona> ObtenerListadoPersonaActivoRango(Activo activo, Inclusiones.InclusionPersona inclusionPersona = null) {
        //    //Declaraciones
        //    List<EstructuraPersona> personaListado;

        //    List<Int32> idPersonaListado;
        //    String nombreBaseDatos;

        //    //Operaciones
        //    if ( !Enum.IsDefined(typeof(Activo), activo) ) {
        //        throw new ArgumentOutOfRangeException("activo", MensajeExcepcion.EnumeracionValorInvalido);
        //    }
        //    nombreBaseDatos = ManejadorConfiguracion.ObtenerValor("administracionConfig", "baseDatosConfig", "BaseDatos");
        //    personaListado = FachadaAdmAD.ObtenerListadoPersonaActivoRango(activo);
        //    //if (personaListado.Count > 0 && inclusionPersona != null) {
        //    //    //Extrayendo Ids
        //    //    idPersonaListado = personaListado.Select(x => x.IdPersona).ToList();
        //    //    //Propiedades complejas            
        //    //    if (inclusionPersona.TipoPersona == true) {
        //    //        var tipoPersonaListado = FachadaAdmAD.ObtenerListadoValor(personaListado.Select(p => p.IdTipoPersona).ToList());
        //    //        personaListado.All(l => { l.IdTipoPersona = tipoPersonaListado.FirstOrDefault(x => x.IdValor == l.IdTipoPersona).IdValor; return true; });
        //    //    }

        //    //}

        //    //Resultado
        //    return personaListado;
        //}


        //public List<EstructuraBusquedaTipoPersona> ObtenerBusquedaTipoPersona(String Busqueda, String TipoBusqueda) {
        //    return FachadaAdmAD.ObtenerBusquedaTipoPersona(Busqueda, TipoBusqueda);
        //}

        ///// <author>Fernando Gallegos</author>
        ///// <creationdate>12-Dic-2016</creationdate>
        ///// <summary>
        ///// Obtiene la información básica de una persona, ya sea natural o jurídica en formato XML y la hoja de estilo para renderizar la información.
        ///// </summary>
        ///// <param name="idPersona">Identificador único de la persona</param>
        ///// <returns>Listado con contenido Xml, el primer registro son los datos, el segundo es la hoja de estilo</returns>
        //public List<String> ObtenerInformacionPersona(Int32 idPersona) {
        //    return FachadaAdmAD.ObtenerInformacionPersona(idPersona);
        //}


        ///// <author>Mario Gomez</author>
        ///// <creationdate>12-Dic-2016</creationdate>
        ///// <summary>
        ///// Obtiene la información básica de una persona,en formato XML y la hoja de estilo para renderizar la información.
        ///// </summary>
        ///// <param name="idPersona">Identificador único de la persona</param>
        ///// <returns>Listado con contenido Xml, el primer registro son los datos, el segundo es la hoja de estilo</returns>
        //public List<String> ObtenerDetallePersonaXML(Int32 idPersona) {
        //    return FachadaAdmAD.ObtenerDetallePersonaXML(idPersona);
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
        //    return FachadaAdmAD.ObtenerListadoTipoPersonaPorIdTipoPersona(idTipoPersona, activo);
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
        //    return FachadaAdmAD.ObtenerListadoTipoPersonaPorListadoIdTipoPersona(listadoIdTipoPersona, activo);
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
        //public Boolean IniciarEdicionPersona(Entidades.Persona.Persona persona) {
        //    //Declaraciones                                  
        //    Boolean resultado = false;

        //    //Operaciones
        //    if ( persona == null ) {
        //        throw new ArgumentNullException("persona", MensajeExcepcion.ParametroEnNulo);
        //    }

        //    if ( persona.IdPersona <= 0 ) {
        //        throw new ArgumentException(MensajeExcepcion.IdentificadorObjetoNoValido, "persona");
        //    }

        //    resultado = IniciarEdicionListadoPersona(new List<Entidades.Persona.Persona>() { persona });

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
        //public Boolean IniciarEdicionListadoPersona(List<Entidades.Persona.Persona> personaListado) {
        //    //Declaraciones                      
        //    List<RegistroBloqueo> listado = new List<RegistroBloqueo>();
        //    Boolean resultado = false;
        //    String nombreBaseDato;
        //    List<RegistroBloqueo> bloqueoListadoActual;
        //    ReglaNegocio reglaNegocio = new ReglaNegocio();
        //    //Operaciones
        //    if ( personaListado == null ) {
        //        throw new ArgumentNullException("personaListado", MensajeExcepcion.ParametroEnNulo);
        //    }

        //    if ( personaListado.Count() <= 0 ) {
        //        throw new ArgumentException(MensajeExcepcion.ParametroListaVacia, "personaListado");
        //    }

        //    if ( personaListado.Where(m => m.IdPersona <= 0).Count() > 0 ) {
        //        throw new ArgumentException(MensajeExcepcion.IdentificadorObjetoNoValidoListado, "personaListado");
        //    }
        //    nombreBaseDato = ManejadorConfiguracion.ObtenerValor("administracionConfig", "baseDatosConfig", "BaseDatos");

        //    reglaNegocio.Campos.Add("EstaBloqueado");
        //    reglaNegocio.Mensaje = MensajeReglaNegocio.RegistroEstaBloqueado;

        //    //verificando si el persona está bloqueado
        //    if ( personaListado.Where(x => x.EstaBloqueado == true).Count() > 0 ) {
        //        personaListado.Where(x => x.EstaBloqueado == true).All(x => {
        //            x.ReglasInfringidas.Add(reglaNegocio);
        //            return true;
        //        });
        //        return false;
        //    }

        //    bloqueoListadoActual = ManejadorBloqueo.ObtenerDatosBloqueoListado(EntidadTabla.Persona, nombreBaseDato, personaListado.Select(x => x.IdPersona).ToList());
        //    personaListado.All(l => {
        //        l.RegistroBloqueo = bloqueoListadoActual.FirstOrDefault(x => l.IdPersona == x.IdRegistro);
        //        return true;
        //    });
        //    personaListado.Where(x => x.RegistroBloqueo != null).All(l => {
        //        l.EstaBloqueado = true;
        //        return true;
        //    });

        //    if ( personaListado.Where(x => x.EstaBloqueado == true).Count() > 0 ) {
        //        personaListado.Where(x => x.EstaBloqueado == true).All(x => {
        //            x.ReglasInfringidas.Add(reglaNegocio);
        //            return true;
        //        });
        //        return false;
        //    }

        //    //Registro Bloqueo Persona
        //    listado.AddRange(personaListado.Select(mod => new RegistroBloqueo() {
        //        IdRegistro = mod.IdPersona,
        //        EntidadTabla = EntidadTabla.Persona
        //    }).ToList());
        //    //Error

        //    //Definiendo la base de datos de proveniencia
        //    listado.All(x => {
        //        x.NombreBaseDato = nombreBaseDato;
        //        return true;
        //    });

        //    //Bloqueando registros
        //    resultado = ManejadorBloqueo.IniciarBloqueoListado(listado);

        //    //Asignando datos de bloqueo al objeto
        //    if ( resultado == true ) {
        //        personaListado.All(x => {
        //            x.EstaBloqueado = true;
        //            x.RegistroBloqueo = listado.FirstOrDefault(l => l.IdRegistro == x.IdPersona && l.EntidadTabla == EntidadTabla.Persona);
        //            return true;
        //        });
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
        //public Boolean CancelarEdicionPersona(Entidades.Persona.Persona persona) {
        //    //Declaraciones            
        //    Boolean resultado = false;

        //    //Operaciones
        //    if ( persona == null ) {
        //        throw new ArgumentNullException("persona", MensajeExcepcion.ParametroEnNulo);
        //    }
        //    if ( persona.RegistroBloqueo == null ) {
        //        throw new ArgumentException(MensajeExcepcion.ParametroEnNulo, "persona.RegistroBloqueo");
        //    }

        //    if ( persona.RegistroBloqueo.IdRegistro <= 0 ) {
        //        throw new ArgumentException(MensajeExcepcion.IdentificadorObjetoNoValido, "persona.RegistroBloqueo.IdRegistro");
        //    }

        //    resultado = FinalizarEdicionListadoPersona(new List<Entidades.Persona.Persona>() { persona });

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
        //public Boolean CancelarEdicionListadoPersona(List<Entidades.Persona.Persona> personaListado) {
        //    //Declaraciones                      
        //    List<RegistroBloqueo> listado = new List<RegistroBloqueo>();
        //    Boolean resultado = false;
        //    ReglaNegocio reglaNegocio = new ReglaNegocio();
        //    //Operaciones
        //    if ( personaListado == null ) {
        //        throw new ArgumentNullException("personaListado", MensajeExcepcion.ParametroEnNulo);
        //    }

        //    if ( personaListado.Count() <= 0 ) {
        //        throw new ArgumentException(MensajeExcepcion.ParametroListaVacia, "personaListado");
        //    }

        //    if ( personaListado.Where(m => m.IdPersona <= 0).Count() > 0 ) {
        //        throw new ArgumentException(MensajeExcepcion.IdentificadorObjetoNoValidoListado, "personaListado");
        //    }

        //    resultado = FinalizarEdicionListadoPersona(personaListado);

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
        //public Boolean FinalizarEdicionPersona(Entidades.Persona.Persona persona) {
        //    //Declaraciones            
        //    Boolean resultado = false;

        //    //Operaciones
        //    if ( persona == null ) {
        //        throw new ArgumentNullException("persona", MensajeExcepcion.ParametroEnNulo);
        //    }
        //    if ( persona.RegistroBloqueo == null ) {
        //        throw new ArgumentException(MensajeExcepcion.ParametroEnNulo, "persona.RegistroBloqueo");
        //    }

        //    if ( persona.RegistroBloqueo.IdRegistro <= 0 ) {
        //        throw new ArgumentException(MensajeExcepcion.IdentificadorObjetoNoValido, "persona.RegistroBloqueo.IdRegistro");
        //    }

        //    resultado = FinalizarEdicionListadoPersona(new List<Entidades.Persona.Persona>() { persona });

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
        //public Boolean FinalizarEdicionListadoPersona(List<Entidades.Persona.Persona> personaListado) {
        //    //Declaraciones                      
        //    List<RegistroBloqueo> listado = new List<RegistroBloqueo>();
        //    Boolean resultado = false;
        //    String nombreBaseDato;
        //    List<RegistroBloqueo> bloqueoListadoActual;
        //    ReglaNegocio reglaNegocio = new ReglaNegocio();

        //    //Operaciones
        //    if ( personaListado == null ) {
        //        throw new ArgumentNullException("personaListado", MensajeExcepcion.ParametroEnNulo);
        //    }

        //    if ( personaListado.Count() <= 0 ) {
        //        throw new ArgumentException(MensajeExcepcion.ParametroListaVacia, "personaListado");
        //    }

        //    if ( personaListado.Where(x => x.RegistroBloqueo == null).Count() > 0 ) {
        //        throw new ArgumentException(MensajeExcepcion.ParametroEnNulo, "personaListado.RegistroBloqueo");
        //    }

        //    if ( personaListado.Where(x => x.RegistroBloqueo.IdRegistroBloqueo <= 0).Count() > 0 ) {
        //        throw new ArgumentException(MensajeExcepcion.IdentificadorObjetoNoValidoListado, "personaListado.RegistroBloqueo.IdRegistroBloqueo");
        //    }

        //    if ( personaListado.Where(m => m.IdPersona <= 0).Count() > 0 ) {
        //        throw new ArgumentException(MensajeExcepcion.IdentificadorObjetoNoValidoListado, "personaListado.IdPersona");
        //    }
        //    nombreBaseDato = ManejadorConfiguracion.ObtenerValor("administracionConfig", "baseDatosConfig", "BaseDatos");

        //    reglaNegocio.Campos.Add("EstaBloqueado");
        //    reglaNegocio.Mensaje = MensajeReglaNegocio.RegistroEstaBloqueado;

        //    //verificando si el Persona está bloqueado
        //    if ( personaListado.Where(x => x.EstaBloqueado == false).Count() > 0 ) {
        //        personaListado.Where(x => x.EstaBloqueado == false).All(x => {
        //            x.ReglasInfringidas.Add(reglaNegocio);
        //            return true;
        //        });
        //        return false;
        //    }

        //    bloqueoListadoActual = ManejadorBloqueo.ObtenerDatosBloqueoListado(EntidadTabla.Persona, nombreBaseDato, personaListado.Select(x => x.IdPersona).ToList());
        //    personaListado.All(l => {
        //        l.RegistroBloqueo = bloqueoListadoActual.FirstOrDefault(x => l.IdPersona == x.IdRegistro);
        //        return true;
        //    });
        //    personaListado.Where(x => x.RegistroBloqueo != null).All(l => {
        //        l.EstaBloqueado = true;
        //        return true;
        //    });
        //    if ( personaListado.Where(x => x.EstaBloqueado == false).Count() > 0 ) {
        //        personaListado.Where(x => x.EstaBloqueado == false).All(x => {
        //            x.ReglasInfringidas.Add(reglaNegocio);
        //            return true;
        //        });
        //        return false;
        //    }

        //    //Registro Bloqueo Persona            
        //    listado.AddRange(personaListado.Where(x => x.RegistroBloqueo != null && x.RegistroBloqueo.IdRegistroBloqueo > 0).
        //            Select(x => x.RegistroBloqueo).ToList());

        //    //Bloqueando registros
        //    resultado = ManejadorBloqueo.FinalizarBloqueoListado(listado);

        //    //Asignando datos de bloqueo al objeto
        //    if ( resultado == true ) {
        //        personaListado.All(x => {
        //            x.EstaBloqueado = false;
        //            x.RegistroBloqueo = null;
        //            return true;
        //        });
        //    }

        //    //Resultado
        //    return resultado;
        //}

        #endregion

    }
}