using AccesoDato.Sql.Persona;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDato.Fachada {
    public partial class FachadaAdmAD {

        #region Atributos

        // Seguridad
        //public IAccionAD AccionAD { get { return AccionADLazy.Value; } }
        //public ICuentaAD CuentaAD { get { return CuentaADLazy.Value; } }
        //public IModuloAD ModuloAD { get { return ModuloADLazy.Value; } }
        //public IOpcionUsuarioAD OpcionUsuarioAD { get { return OpcionUsuarioADLazy.Value; } }
        //public IRolAD RolAD { get { return RolADLazy.Value; } }
        //public IRolAccionAD RolAccionAD { get { return RolAccionADLazy.Value; } }
        //public IRolCuentaAD RolCuentaAD { get { return RolCuentaADLazy.Value; } }
        //public ISistemaAD SistemaAD { get { return SistemaADLazy.Value; } }
        //public ISistemaSubsistemaAD SistemaSubsistemaAD { get { return SistemaSubsistemaADLazy.Value; } }
        //public ISubsistemaAD SubsistemaAD { get { return SubsistemaADLazy.Value; } }

        //public Lazy<IBaseDatosAD> BaseDatosADLazy;
        //public Lazy<IEsquemaAD> EsquemaADLazy;
        //public Lazy<ITablaAD> TablaADLazy;
        //public Lazy<IDetallePistaAuditoriaAD> DetallePistaAuditoriaADLazy;
        //public Lazy<IDetalleVisitaAD> DetalleVisitaADLazy;
        //public Lazy<IPistaAuditoriaAD> PistaAuditoriaADLazy;
        //public Lazy<IRegistroOperacionAD> RegistroOperacionADLazy;
        //public Lazy<ISesionAD> SesionADLazy;
        //public Lazy<IVisitaAD> VisitaADLazy;

        // Seguridad
        //public Lazy<IAccionAD> AccionADLazy;
        //public Lazy<ICuentaAD> CuentaADLazy;
        //public Lazy<IModuloAD> ModuloADLazy;
        //public Lazy<IOpcionUsuarioAD> OpcionUsuarioADLazy;
        //public Lazy<IRolAD> RolADLazy;
        //public Lazy<IRolAccionAD> RolAccionADLazy;
        //public Lazy<IRolCuentaAD> RolCuentaADLazy;
        //public Lazy<ISistemaAD> SistemaADLazy;
        //public Lazy<ISistemaSubsistemaAD> SistemaSubsistemaADLazy;
        //public Lazy<ISubsistemaAD> SubsistemaADLazy;
        //TablaBasica
        //public IEstadoFlujoAD EstadoFlujoAD { get { return EstadoFlujoADLazy.Value; } }
        //public ITipoAsignacionAD TipoAsignacionAD { get { return TipoAsignacionADLazy.Value; } }
        //public IFlujoTrabajoAD FlujoTrabajoAD { get { return FlujoTrabajoADLazy.Value; } }
        //public IActividadAD ActividadAD { get { return ActividadADLazy.Value; } }
        //public IActividadAsignacionAD ActividadAsignacionAD { get { return ActividadAsignacionADLazy.Value; } }
        //public ICasoAD CasoAD { get { return CasoADLazy.Value; } }
        //public ICasoMovimientoAD CasoMovimientoAD { get { return CasoMovimientoADLazy.Value; } }
        //public IComentarioAD ComentarioAD { get { return ComentarioADLazy.Value; } }
        //public IConfiguracionDistribucionAD ConfiguracionDistribucionAD { get { return ConfiguracionDistribucionADLazy.Value; } }
        //public IConfiguracionOrdenFlujoAD ConfiguracionOrdenFlujoAD { get { return ConfiguracionOrdenFlujoADLazy.Value; } }
        //public IDuracionActividadAD DuracionActividadAD { get { return DuracionActividadADLazy.Value; } }
        //public IEstadoCasoFlujoAD EstadoCasoFlujoAD { get { return EstadoCasoFlujoADLazy.Value; } }
        //public ITipoCasoAD TipoCasoAD { get { return TipoCasoADLazy.Value; } }
        //public IRegistrarCasosAD RegistrarCasoAD { get { return RegistrarCasoADLazy.Value; } }

        //TablaBasicaLazy
        //public Lazy<IEstadoFlujoAD> EstadoFlujoADLazy;
        //public Lazy<ITipoAsignacionAD> TipoAsignacionADLazy;
        //public Lazy<IFlujoTrabajoAD> FlujoTrabajoADLazy;
        //public Lazy<IActividadAD> ActividadADLazy;
        //public Lazy<IActividadAsignacionAD> ActividadAsignacionADLazy;
        //public Lazy<ICasoAD> CasoADLazy;
        //public Lazy<ICasoMovimientoAD> CasoMovimientoADLazy;
        //public Lazy<IComentarioAD> ComentarioADLazy;
        //public Lazy<IConfiguracionDistribucionAD> ConfiguracionDistribucionADLazy;
        //public Lazy<IConfiguracionOrdenFlujoAD> ConfiguracionOrdenFlujoADLazy;
        //public Lazy<IDuracionActividadAD> DuracionActividadADLazy;
        //public Lazy<IEstadoCasoFlujoAD> EstadoCasoFlujoADLazy;
        //public Lazy<ITipoCasoAD> TipoCasoADLazy;
        //public Lazy<IRegistrarCasosAD> RegistrarCasoADLazy;

        //Persona
        //public IAbogadoAD AbogadoAD { get { return AbogadoADLazy.Value; } }
        //public IAbogadoSuspendidoAD AbogadoSuspendidoAD { get { return AbogadoSuspendidoADLazy.Value; } }
        //public IDireccionAD DireccionAD { get { return DireccionADLazy.Value; } }
        //public IEmpleadoAD EmpleadoAD { get { return EmpleadoADLazy.Value; } }
        //public IEmpleadoAusenciaAD EmpleadoAusenciaAD { get { return EmpleadoAusenciaADLazy.Value; } }
        //public IEmpleadoObjetoAD EmpleadoObjetoAD { get { return EmpleadoObjetoADLazy.Value; } }
        //public IEmpleadoCargoAD EmpleadoCargoAD { get { return EmpleadoCargoADLazy.Value; } }
        //public ITopografoEstudioProfesionalAD TopografoEstudioProfesionalAD { get { return TopografoEstudioProfesionalADLazy.Value; } }
        //public IGrupoAD GrupoAD { get { return GrupoADLazy.Value; } }
        //public IGrupoPersonaAD GrupoPersonaAD { get { return GrupoPersonaADLazy.Value; } }
        //public INotaEvaluacionAD NotaEvaluacionAD { get { return NotaEvaluacionADLazy.Value; } }
        //public IPersonaAD PersonaAD { get { return PersonaADLazy.Value; } }
        //public IPersonaContactoAD PersonaContactoAD { get { return PersonaContactoADLazy.Value; } }
        //public IPersonaDireccionAD PersonaDireccionAD { get { return PersonaDireccionADLazy.Value; } }
        //public IPersonaIdentificacionAD PersonaIdentificacionAD { get { return PersonaIdentificacionADLazy.Value; } }
        //public IPersonaJuridicaAD PersonaJuridicaAD { get { return PersonaJuridicaADLazy.Value; } }
        //public IPersonaNacionalidadAD PersonaNacionalidadAD { get { return PersonaNacionalidadADLazy.Value; } }
        public PersonaAD PersonaAD { get { return PersonaADLazy.Value; } }
        public PersonaNaturalAD PersonaNaturalAD { get { return PersonaNaturalADLazy.Value; } }
        
        //public ITopografoSancionAD TopografoSancionAD { get { return TopografoSancionADLazy.Value; } }
        //public ITopografoAD TopografoAD { get { return TopografoADLazy.Value; } }
        //public IQuinquenioAD QuinquenioAD { get { return QuinquenioADLazy.Value; } }

        //PersonaLazy
        //public Lazy<IAbogadoAD> AbogadoADLazy;
        //public Lazy<IAbogadoSuspendidoAD> AbogadoSuspendidoADLazy;
        //public Lazy<IDireccionAD> DireccionADLazy;
        //public Lazy<IEmpleadoAD> EmpleadoADLazy;
        //public Lazy<IEmpleadoAusenciaAD> EmpleadoAusenciaADLazy;
        //public Lazy<IEmpleadoObjetoAD> EmpleadoObjetoADLazy;
        //public Lazy<IEmpleadoCargoAD> EmpleadoCargoADLazy;
        //public Lazy<ITopografoEstudioProfesionalAD> TopografoEstudioProfesionalADLazy;
        //public Lazy<IGrupoAD> GrupoADLazy;
        //public Lazy<IGrupoPersonaAD> GrupoPersonaADLazy;
        //public Lazy<INotaEvaluacionAD> NotaEvaluacionADLazy;
        public Lazy<PersonaAD> PersonaADLazy;
        //public Lazy<IPersonaContactoAD> PersonaContactoADLazy;
        //public Lazy<IPersonaDireccionAD> PersonaDireccionADLazy;
        //public Lazy<IPersonaIdentificacionAD> PersonaIdentificacionADLazy;
        //public Lazy<IPersonaJuridicaAD> PersonaJuridicaADLazy;
        //public Lazy<IPersonaNacionalidadAD> PersonaNacionalidadADLazy;
        public Lazy<PersonaNaturalAD> PersonaNaturalADLazy;
        //public Lazy<ITopografoSancionAD> TopografoSancionADLazy;
        //public Lazy<ITopografoAD> TopografoADLazy;
        //public Lazy<IQuinquenioAD> QuinquenioADLazy;

        //TablaBasica
        //public ICargoAD CargoAD { get { return CargoADLazy.Value; } }
        //public ICatalogoAD CatalogoAD { get { return CatalogoADLazy.Value; } }
        //public INivelContactoAD NivelContactoAD { get { return NivelContactoADLazy.Value; } }
        //public IParametroSistemaAD ParametroSistemaAD { get { return ParametroSistemaADLazy.Value; } }
        //public IValorAD ValorAD { get { return ValorADLazy.Value; } }
        //public IMonedaAD MonedaAD { get { return MonedaADLazy.Value; } }
        //public ITipoAccionAD TipoAccionAD { get { return TipoAccionADLazy.Value; } }
        //public ISecuenciaAD SecuenciaAD { get { return SecuenciaADLazy.Value; } }
        //public ISolicitudSecuenciaAD SolicitudSecuenciaAD { get { return SolicitudSecuenciaADLazy.Value; } }
        //public IHojaEstiloAD HojaEstiloAD { get { return HojaEstiloADLazy.Value; } }
        //public ICategoriaUnidadMedidaAD CategoriaUnidadMedidaAD { get { return CategoriaUnidadMedidaADLazy.Value; } }
        //public IUnidadMedidaAD UnidadMedidaAD { get { return UnidadMedidaADLazy.Value; } }
        //public IUnidadMedidaConversionAD UnidadMedidaConversionAD { get { return UnidadMedidaConversionADLazy.Value; } }
        //public ITipoActaAD TipoActaAD { get { return TipoActaADLazy.Value; } }
        //public ITipoActaTipoDocumentoAD TipoActaTipoDocumentoAD { get { return TipoActaTipoDocumentoADLazy.Value; } }
        //public ITipoDocumentoAD TipoDocumentoAD { get { return TipoDocumentoADLazy.Value; } }
        //public IDiaNoHabilAD DiaNoHabilAD { get { return DiaNoHabilADLazy.Value; } }
        //public IPlazoTiempoDocumentoAD PlazoTiempoDocumentoAD { get { return PlazoTiempoDocumentoADLazy.Value; } }

        //TablaBasica Lazy
        //public Lazy<ICargoAD> CargoADLazy;
        //public Lazy<ICatalogoAD> CatalogoADLazy;
        //public Lazy<INivelContactoAD> NivelContactoADLazy;
        //public Lazy<IParametroSistemaAD> ParametroSistemaADLazy;
        //public Lazy<IValorAD> ValorADLazy;
        //public Lazy<IMonedaAD> MonedaADLazy;
        //public Lazy<ITipoAccionAD> TipoAccionADLazy;
        //public Lazy<ISecuenciaAD> SecuenciaADLazy;
        //public Lazy<ISolicitudSecuenciaAD> SolicitudSecuenciaADLazy;
        //public Lazy<IHojaEstiloAD> HojaEstiloADLazy;
        //public Lazy<ICategoriaUnidadMedidaAD> CategoriaUnidadMedidaADLazy;
        //public Lazy<IUnidadMedidaAD> UnidadMedidaADLazy;
        //public Lazy<IUnidadMedidaConversionAD> UnidadMedidaConversionADLazy;
        //public Lazy<ITipoActaAD> TipoActaADLazy;
        //public Lazy<ITipoActaTipoDocumentoAD> TipoActaTipoDocumentoADLazy;
        //public Lazy<ITipoDocumentoAD> TipoDocumentoADLazy;
        //public Lazy<IDiaNoHabilAD> DiaNoHabilADLazy;
        //public Lazy<IPlazoTiempoDocumentoAD> PlazoTiempoDocumentoADLazy;

        #endregion

        #region Constructores

        /// <author>Ernesto Medrano</author>
        /// <creationdate>04-ago-2015</creationdate>
        /// <summary>
        /// Constructor que permite la conexion a un determinado  gestor de base de datos.
        /// </summary>
        public FachadaAdmAD(Lazy<PersonaAD> personaAD, Lazy<PersonaNaturalAD> personaNaturalAD) {

            //Persona 
            PersonaADLazy = personaAD;
            PersonaNaturalADLazy = personaNaturalAD;
        }

        #endregion

    }
}
