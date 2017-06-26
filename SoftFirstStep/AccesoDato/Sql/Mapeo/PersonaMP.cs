using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

using AutoMapper.Configuration;

namespace AccesoDato.Sql.Mapeo {
    /// <author>Ernesto Medrano</author>
    /// <creationdate>29-jul-2015</creationdate>
    /// <summary>  
    /// Clase que lleva a cabo la configuracion de los mapeos.
    /// </summary> 
    public static class PersonaMP {

        /// <author>Ernesto Medrano</author>
        /// <creationdate>29-jul-2015</creationdate>
        /// <summary>
        /// Metodo que contiene la configuración de los cada uno de los mapeos de los diferentes 
        /// objetos a ser mapeados.
        /// </summary> 
        public static void RegistrarMapeos(MapperConfigurationExpression configuracionMapeo) {

            //#region Mapeo Abogado

            //configuracionMapeo.CreateMap<Negocio.Entidades.Persona.Abogado, Sql.Modelo.Abogado>()
            //    .ForMember(dest => dest.IdEstado, opt => opt.MapFrom(src => src.Estado.IdValor))
            //    .ForMember(dest => dest.IdClasificacionMateria, opt => opt.MapFrom(src => src.ClasificacionMateria.IdValor))
            //    .ForMember(dest => dest.IdCompetenciaTerritorial, opt => opt.MapFrom(src => src.CompetenciaTerritorial.IdObjeto))
            //    .ForMember(dest => dest.IdPersonaNatural, opt => opt.MapFrom(src => src.PersonaNatural.IdPersonaNatural))
            //     .ForMember(dest => dest.IdEstado, opt => opt.MapFrom(src => src.Estado.IdValor))
            //    .ForMember(dest => dest.Estado, opt => opt.Ignore())
            //    .ForMember(dest => dest.Objeto, opt => opt.Ignore())
            //    .ForMember(dest => dest.Valor, opt => opt.Ignore())
            //    .ForMember(dest => dest.PersonaNatural, opt => opt.Ignore())
            //    .ForMember(dest => dest.Quinquenios, opt => opt.Ignore())
            //    .ForMember(dest => dest.AbogadoSuspendidos, opt => opt.Ignore())
            //    .ForMember(dest => dest.FechaCreacion, opt => opt.Ignore())
            //    .ForMember(dest => dest.IdUsuarioModificacion, opt => opt.Ignore())
            //    .ForMember(dest => dest.IdUsuarioCreacion, opt => opt.Ignore())
            //    .ForMember(dest => dest.FechaModificacion, opt => opt.Ignore());

            //configuracionMapeo.CreateMap<Sql.Modelo.Abogado, Negocio.Entidades.Persona.Abogado>()
            //    .ForMember(dest => dest.ClasificacionMateria, opt => opt.MapFrom(src => src.IdClasificacionMateria == null ? null : new Negocio.Entidades.TablaBasica.Valor() { IdValor = src.IdClasificacionMateria ?? default(Int32) }))
            //    .ForMember(dest => dest.Estado, opt => opt.MapFrom(src => src.IdEstado == null ? null : new Negocio.Entidades.TablaBasica.Valor() { IdValor = src.IdEstado ?? default(Int32) }))
            //    .ForMember(dest => dest.CompetenciaTerritorial, opt => opt.MapFrom(src => src.IdCompetenciaTerritorial == null ? null : new Negocio.Entidades.ModeloUniversalDato.Objeto() { IdObjeto = src.IdCompetenciaTerritorial ?? default(Int32) }))
            //    .ForMember(dest => dest.PersonaNatural, opt => opt.MapFrom(src => new Negocio.Entidades.Persona.PersonaNatural() { IdPersonaNatural = src.IdPersonaNatural }))
            //    .ForMember(dest => dest.Quinquenios, opt => opt.Ignore())
            //    .ForMember(dest => dest.AbogadoSuspendidos, opt => opt.Ignore())
            //    .ForMember(dest => dest.ReglasInfringidas, opt => opt.Ignore())
            //    .ForMember(dest => dest.RegistroBloqueo, opt => opt.Ignore())
            //    .ForMember(dest => dest.NombreTabla, opt => opt.Ignore())
            //    .ForMember(dest => dest.EstaBloqueado, opt => opt.Ignore());


            //#endregion

            //#region Mapeo AbogadoSuspendido

            //configuracionMapeo.CreateMap<Negocio.Entidades.Persona.AbogadoSuspendido, Sql.Modelo.AbogadoSuspendido>()
            //    .ForMember(dest => dest.IdAbogado, opt => opt.MapFrom(src => src.Abogado.IdAbogado))
            //    .ForMember(dest => dest.IdTipoSuspension, opt => opt.MapFrom(src => src.TipoSuspension.IdValor))
            //    .ForMember(dest => dest.Abogado, opt => opt.Ignore())
            //    .ForMember(dest => dest.Valor, opt => opt.Ignore())
            //    .ForMember(dest => dest.FechaCreacion, opt => opt.Ignore())
            //    .ForMember(dest => dest.IdUsuarioModificacion, opt => opt.Ignore())
            //    .ForMember(dest => dest.IdUsuarioCreacion, opt => opt.Ignore())
            //    .ForMember(dest => dest.FechaModificacion, opt => opt.Ignore());


            //configuracionMapeo.CreateMap<Sql.Modelo.AbogadoSuspendido, Negocio.Entidades.Persona.AbogadoSuspendido>()
            //    .ForMember(dest => dest.Abogado, opt => opt.MapFrom(src => new Negocio.Entidades.Persona.Abogado() { IdAbogado = src.IdAbogado }))
            //    .ForMember(dest => dest.TipoSuspension, opt => opt.MapFrom(src => new Negocio.Entidades.TablaBasica.Valor() { IdValor = src.IdTipoSuspension }))
            //    .ForMember(dest => dest.NombreTabla, opt => opt.Ignore())
            //    .ForMember(dest => dest.ReglasInfringidas, opt => opt.Ignore())
            //    .ForMember(dest => dest.RegistroBloqueo, opt => opt.Ignore())
            //    .ForMember(dest => dest.EstaBloqueado, opt => opt.Ignore());


            //#endregion

            //#region Mapeo Direccion

            //configuracionMapeo.CreateMap<Negocio.Entidades.Persona.Direccion, Sql.Modelo.Direccion>()
            //    .ForMember(dest => dest.IdUbicacionGeografica, opt => opt.MapFrom(src => src.UbicacionGeografica.IdObjeto))
            //    .ForMember(dest => dest.Objeto, opt => opt.Ignore())
            //    .ForMember(dest => dest.PersonaDireccion, opt => opt.Ignore())
            //    .ForMember(dest => dest.FechaCreacion, opt => opt.Ignore())
            //    .ForMember(dest => dest.IdUsuarioModificacion, opt => opt.Ignore())
            //    .ForMember(dest => dest.IdUsuarioCreacion, opt => opt.Ignore())
            //    .ForMember(dest => dest.FechaModificacion, opt => opt.Ignore());            

            //configuracionMapeo.CreateMap<Sql.Modelo.Direccion, Negocio.Entidades.Persona.Direccion>()
            //    .ForMember(dest => dest.UbicacionGeografica, opt => opt.MapFrom(src => new Negocio.Entidades.ModeloUniversalDato.Objeto() { IdObjeto = src.IdUbicacionGeografica }))
            //    .ForMember(dest => dest.Personas, opt => opt.Ignore())
            //    .ForMember(dest => dest.NombreTabla, opt => opt.Ignore())
            //    .ForMember(dest => dest.ReglasInfringidas, opt => opt.Ignore())
            //    .ForMember(dest => dest.RegistroBloqueo, opt => opt.Ignore())
            //    .ForMember(dest => dest.EstaBloqueado, opt => opt.Ignore());
            //#endregion

            //#region Mapeo Empleado

            //configuracionMapeo.CreateMap<Negocio.Entidades.Persona.Empleado, Sql.Modelo.Empleado>()
            //    .ForMember(dest => dest.IdEmpleadoPadre, opt => opt.MapFrom(src => src.EmpleadoPadre == null ? default(Int32) : src.EmpleadoPadre.IdEmpleado))
            //    .ForMember(dest => dest.IdPersonaNatural, opt => opt.MapFrom(src => src.PersonaNatural.IdPersonaNatural))
            //    //.ForMember(dest => dest.IdCargo, opt => opt.MapFrom(src => src.Cargo.IdCargo))
            //    //.ForMember(dest => dest.Cargo, opt => opt.Ignore())
            //    .ForMember(dest => dest.EmpleadoHijos, opt => opt.Ignore())
            //    .ForMember(dest => dest.EmpleadoPadre, opt => opt.Ignore())
            //    .ForMember(dest => dest.PersonaNatural, opt => opt.Ignore())
            //    .ForMember(dest => dest.EmpleadoAusencia, opt => opt.Ignore())
            //    .ForMember(dest => dest.EmpleadoObjeto, opt => opt.Ignore())
            //    .ForMember(dest => dest.EmpleadoCargo, opt => opt.Ignore())
            //    .ForMember(dest => dest.FechaCreacion, opt => opt.Ignore())
            //    .ForMember(dest => dest.IdUsuarioModificacion, opt => opt.Ignore())
            //    .ForMember(dest => dest.IdUsuarioCreacion, opt => opt.Ignore())
            //    .ForMember(dest => dest.FechaModificacion, opt => opt.Ignore());


            //configuracionMapeo.CreateMap<Sql.Modelo.Empleado, Negocio.Entidades.Persona.Empleado>()
            //    .ForMember(dest => dest.EmpleadoPadre, opt => opt.MapFrom(src => src.IdEmpleadoPadre == null ? null : new Negocio.Entidades.Persona.Empleado() { IdEmpleado = src.IdEmpleadoPadre ?? default(Int32) }))
            //    .ForMember(dest => dest.PersonaNatural, opt => opt.MapFrom(src => src.IdPersonaNatural == null ? null : new Negocio.Entidades.Persona.PersonaNatural() { IdPersonaNatural = src.IdPersonaNatural ?? default(Int32), NombreCompleto = src.PersonaNatural.NombreCompleto }))
            //    //.ForMember(dest => dest.Cargo, opt => opt.MapFrom(src => new Negocio.Entidades.TablaBasica.Cargo() { IdCargo = src.IdCargo }))
            //    .ForMember(dest => dest.EmpleadoAusencias, opt => opt.Ignore())
            //    .ForMember(dest => dest.EmpleadoHijos, opt => opt.Ignore())
            //    .ForMember(dest => dest.Objetos, opt => opt.Ignore())
            //    .ForMember(dest => dest.EmpleadoCargos, opt => opt.Ignore())
            //    .ForMember(dest => dest.NombreTabla, opt => opt.Ignore())
            //    .ForMember(dest => dest.ReglasInfringidas, opt => opt.Ignore())
            //    .ForMember(dest => dest.RegistroBloqueo, opt => opt.Ignore())
            //    .ForMember(dest => dest.EstaBloqueado, opt => opt.Ignore())
            //    .ForMember(dest => dest.ExisteEnPadronElectoral, opt => opt.Ignore())
            //    //GB: Agregado por la implementacion de herencia, esto debe revisarse con calma
            //    .ForMember(dest => dest.PrimerNombre, opt => opt.Ignore())
            //    .ForMember(dest => dest.SegundoNombre, opt => opt.Ignore())
            //    .ForMember(dest => dest.TercerNombre, opt => opt.Ignore())
            //    .ForMember(dest => dest.CuartoNombre, opt => opt.Ignore())
            //    .ForMember(dest => dest.PrimerApellido, opt => opt.Ignore())
            //    .ForMember(dest => dest.SegundoApellido, opt => opt.Ignore())
            //    .ForMember(dest => dest.NombreCompleto, opt => opt.Ignore())
            //    .ForMember(dest => dest.ApellidoDeCasada, opt => opt.Ignore())
            //    .ForMember(dest => dest.ConocidoComo, opt => opt.Ignore())
            //    .ForMember(dest => dest.FechaNacimiento, opt => opt.Ignore())
            //    .ForMember(dest => dest.EstaFallecido, opt => opt.Ignore())
            //    .ForMember(dest => dest.FechaFallecimiento, opt => opt.Ignore())
            //    .ForMember(dest => dest.Persona, opt => opt.Ignore())
            //    .ForMember(dest => dest.Genero, opt => opt.Ignore())
            //    .ForMember(dest => dest.EstadoCivil, opt => opt.Ignore())
            //    .ForMember(dest => dest.Ocupacion, opt => opt.Ignore())
            //    .ForMember(dest => dest.Abogados, opt => opt.Ignore())
            //    .ForMember(dest => dest.Topografos, opt => opt.Ignore())
            //    .ForMember(dest => dest.PersonaJuridicas, opt => opt.Ignore())
            //    .ForMember(dest => dest.IdPersona, opt => opt.Ignore())
            //    .ForMember(dest => dest.TipoPersona, opt => opt.Ignore())
            //    .ForMember(dest => dest.PersonaNaturales, opt => opt.Ignore())
            //    .ForMember(dest => dest.GrupoPersonas, opt => opt.Ignore())
            //    .ForMember(dest => dest.PersonaIdentificaciones, opt => opt.Ignore())
            //    .ForMember(dest => dest.PersonaNacionalidades, opt => opt.Ignore())
            //    .ForMember(dest => dest.PersonaContactos, opt => opt.Ignore())
            //    .ForMember(dest => dest.Direcciones, opt => opt.Ignore());


            //#endregion

            //#region Mapeo EmpleadoCargo

            //configuracionMapeo.CreateMap<Negocio.Entidades.Persona.EmpleadoCargo, Sql.Modelo.EmpleadoCargo>()
            //    .ForMember(dest => dest.IdCargo, opt => opt.MapFrom(src => src.Cargo.IdCargo))
            //    .ForMember(dest => dest.IdEmpleado, opt => opt.MapFrom(src => src.Empleado.IdEmpleado))
            //    .ForMember(dest => dest.Cargo, opt => opt.Ignore())
            //    .ForMember(dest => dest.Empleado, opt => opt.Ignore())
            //    .ForMember(dest => dest.FechaCreacion, opt => opt.Ignore())
            //    .ForMember(dest => dest.IdUsuarioModificacion, opt => opt.Ignore())
            //    .ForMember(dest => dest.IdUsuarioCreacion, opt => opt.Ignore())
            //    .ForMember(dest => dest.FechaModificacion, opt => opt.Ignore());


            //configuracionMapeo.CreateMap<Sql.Modelo.EmpleadoCargo, Negocio.Entidades.Persona.EmpleadoCargo>()
            //    .ForMember(dest => dest.Cargo, opt => opt.MapFrom(src => new Negocio.Entidades.TablaBasica.Cargo() { IdCargo = src.IdCargo }))
            //    .ForMember(dest => dest.Empleado, opt => opt.MapFrom(src => new Negocio.Entidades.Persona.Empleado() { IdEmpleado = src.IdEmpleado }))
            //    .ForMember(dest => dest.NombreTabla, opt => opt.Ignore())
            //    .ForMember(dest => dest.ReglasInfringidas, opt => opt.Ignore())
            //    .ForMember(dest => dest.RegistroBloqueo, opt => opt.Ignore())
            //    .ForMember(dest => dest.EstaBloqueado, opt => opt.Ignore());


            //#endregion

            //#region Mapeo EmpleadoAusencia

            //configuracionMapeo.CreateMap<Negocio.Entidades.Persona.EmpleadoAusencia, Sql.Modelo.EmpleadoAusencia>()
            //    .ForMember(dest => dest.IdEmpleado, opt => opt.MapFrom(src => src.Empleado.IdEmpleado))
            //    .ForMember(dest => dest.IdMotivoAusencia, opt => opt.MapFrom(src => src.MotivoAusencia.IdValor))
            //    .ForMember(dest => dest.Empleado, opt => opt.Ignore())
            //    .ForMember(dest => dest.Valor, opt => opt.Ignore())
            //    .ForMember(dest => dest.FechaCreacion, opt => opt.Ignore())
            //    .ForMember(dest => dest.IdUsuarioModificacion, opt => opt.Ignore())
            //    .ForMember(dest => dest.IdUsuarioCreacion, opt => opt.Ignore())
            //    .ForMember(dest => dest.FechaModificacion, opt => opt.Ignore());


            //configuracionMapeo.CreateMap<Sql.Modelo.EmpleadoAusencia, Negocio.Entidades.Persona.EmpleadoAusencia>()
            //    .ForMember(dest => dest.Empleado, opt => opt.MapFrom(src => new Negocio.Entidades.Persona.Empleado() { IdEmpleado = src.IdEmpleado }))
            //    .ForMember(dest => dest.MotivoAusencia, opt => opt.MapFrom(src => new Negocio.Entidades.TablaBasica.Valor() { IdValor = src.IdMotivoAusencia }))
            //    .ForMember(dest => dest.NombreTabla, opt => opt.Ignore())
            //    .ForMember(dest => dest.ReglasInfringidas, opt => opt.Ignore())
            //    .ForMember(dest => dest.RegistroBloqueo, opt => opt.Ignore())
            //    .ForMember(dest => dest.EstaBloqueado, opt => opt.Ignore());


            //#endregion

            //#region Mapeo TopografoEstudioProfesional

            //configuracionMapeo.CreateMap<Negocio.Entidades.Persona.TopografoEstudioProfesional, Sql.Modelo.TopografoEstudioProfesional>()
            //    .ForMember(dest => dest.IdTopografo, opt => opt.MapFrom(src => src.Topografo.IdTopografo))
            //    .ForMember(dest => dest.IdNombreEstudioProfesional, opt => opt.MapFrom(src => src.NombreEstudioProfesional.IdValor))
            //    .ForMember(dest => dest.Topografo, opt => opt.Ignore())
            //    .ForMember(dest => dest.NombreEstudioProfesional, opt => opt.Ignore())
            //    .ForMember(dest => dest.FechaCreacion, opt => opt.Ignore())
            //    .ForMember(dest => dest.IdUsuarioModificacion, opt => opt.Ignore())
            //    .ForMember(dest => dest.IdUsuarioCreacion, opt => opt.Ignore())
            //    .ForMember(dest => dest.FechaModificacion, opt => opt.Ignore());


            //configuracionMapeo.CreateMap<Sql.Modelo.TopografoEstudioProfesional, Negocio.Entidades.Persona.TopografoEstudioProfesional>()
            //    .ForMember(dest => dest.Topografo, opt => opt.MapFrom(src => new Negocio.Entidades.Persona.Topografo() { IdTopografo = src.IdTopografo }))
            //    .ForMember(dest => dest.NombreEstudioProfesional, opt => opt.MapFrom(src => new Negocio.Entidades.TablaBasica.Valor() { IdValor = src.IdNombreEstudioProfesional }))
            //    .ForMember(dest => dest.NombreTabla, opt => opt.Ignore())
            //    .ForMember(dest => dest.ReglasInfringidas, opt => opt.Ignore())
            //    .ForMember(dest => dest.RegistroBloqueo, opt => opt.Ignore())
            //    .ForMember(dest => dest.EstaBloqueado, opt => opt.Ignore());


            //#endregion

            //#region Mapeo Grupo

            //configuracionMapeo.CreateMap<Negocio.Entidades.Persona.Grupo, Sql.Modelo.Grupo>()
            //    .ForMember(dest => dest.IdTipoGrupo, opt => opt.MapFrom(src => src.TipoGrupo.IdValor))
            //    .ForMember(dest => dest.Valor, opt => opt.Ignore())
            //    .ForMember(dest => dest.GrupoPersona, opt => opt.Ignore())
            //    .ForMember(dest => dest.FechaCreacion, opt => opt.Ignore())
            //    .ForMember(dest => dest.IdUsuarioModificacion, opt => opt.Ignore())
            //    .ForMember(dest => dest.IdUsuarioCreacion, opt => opt.Ignore())
            //    .ForMember(dest => dest.FechaModificacion, opt => opt.Ignore());


            //configuracionMapeo.CreateMap<Sql.Modelo.Grupo, Negocio.Entidades.Persona.Grupo>()
            //    .ForMember(dest => dest.TipoGrupo, opt => opt.MapFrom(src => new Negocio.Entidades.TablaBasica.Valor() { IdValor = src.IdTipoGrupo }))
            //    .ForMember(dest => dest.GrupoPersonas, opt => opt.Ignore())
            //    .ForMember(dest => dest.NombreTabla, opt => opt.Ignore())
            //    .ForMember(dest => dest.ReglasInfringidas, opt => opt.Ignore())
            //    .ForMember(dest => dest.RegistroBloqueo, opt => opt.Ignore())
            //    .ForMember(dest => dest.EstaBloqueado, opt => opt.Ignore());


            //#endregion

            //#region Mapeo GrupoPersona

            //configuracionMapeo.CreateMap<Negocio.Entidades.Persona.GrupoPersona, Sql.Modelo.GrupoPersona>()
            //    .ForMember(dest => dest.IdGrupo, opt => opt.MapFrom(src => src.Grupo.IdGrupo))
            //    .ForMember(dest => dest.IdPersona, opt => opt.MapFrom(src => src.Persona.IdPersona))
            //    .ForMember(dest => dest.Grupo, opt => opt.Ignore())
            //    .ForMember(dest => dest.Persona, opt => opt.Ignore())
            //    .ForMember(dest => dest.FechaCreacion, opt => opt.Ignore())
            //    .ForMember(dest => dest.IdUsuarioModificacion, opt => opt.Ignore())
            //    .ForMember(dest => dest.IdUsuarioCreacion, opt => opt.Ignore())
            //    .ForMember(dest => dest.FechaModificacion, opt => opt.Ignore());


            //configuracionMapeo.CreateMap<Sql.Modelo.GrupoPersona, Negocio.Entidades.Persona.GrupoPersona>()
            //    .ForMember(dest => dest.Grupo, opt => opt.MapFrom(src => new Negocio.Entidades.Persona.Grupo() { IdGrupo = src.IdGrupo }))
            //    .ForMember(dest => dest.Persona, opt => opt.MapFrom(src => new Negocio.Entidades.Persona.Persona() { IdPersona = src.IdPersona }))
            //    .ForMember(dest => dest.NombreTabla, opt => opt.Ignore())
            //    .ForMember(dest => dest.ReglasInfringidas, opt => opt.Ignore())
            //    .ForMember(dest => dest.RegistroBloqueo, opt => opt.Ignore())
            //    .ForMember(dest => dest.EstaBloqueado, opt => opt.Ignore());


            //#endregion

            //#region Mapeo GrupoPersonaNatural

            ////configuracionMapeo.CreateMap<Negocio.Entidades.Persona.GrupoPersonaNatural, Sql.Modelo.GrupoPersonaNatural>()
            ////    .ForMember(dest => dest.IdGrupo, opt => opt.MapFrom(src => src.Grupo.IdGrupo))
            ////    .ForMember(dest => dest.IdPersonaNatural, opt => opt.MapFrom(src => src.PersonaNatural.IdPersonaNatural))
            ////    .ForMember(dest => dest.Grupo, opt => opt.Ignore())
            ////    .ForMember(dest => dest.PersonaNatural, opt => opt.Ignore())
            ////    .ForMember(dest => dest.FechaCreacion, opt => opt.Ignore())
            ////    .ForMember(dest => dest.IdUsuarioModificacion, opt => opt.Ignore())
            ////    .ForMember(dest => dest.IdUsuarioCreacion, opt => opt.Ignore())
            ////    .ForMember(dest => dest.FechaModificacion, opt => opt.Ignore());

            ////configuracionMapeo.CreateMap<Sql.Modelo.GrupoPersonaNatural, Negocio.Entidades.Persona.GrupoPersonaNatural>()
            ////    .ForMember(dest => dest.Grupo, opt => opt.MapFrom(src => new Negocio.Entidades.Persona.Grupo() { IdGrupo = src.IdGrupo }))
            ////    .ForMember(dest => dest.PersonaNatural, opt => opt.MapFrom(src => new Negocio.Entidades.Persona.PersonaNatural() { IdPersonaNatural = src.IdPersonaNatural }))
            ////.ForMember(dest => dest.NombreTabla, opt => opt.Ignore())
            ////    .ForMember(dest => dest.ReglasInfringidas, opt => opt.Ignore())
            ////    .ForMember(dest => dest.RegistroBloqueo, opt => opt.Ignore())
            ////    .ForMember(dest => dest.EstaBloqueado, opt => opt.Ignore());

            //#endregion

            //#region Mapeo NotaEvaluacion

            //configuracionMapeo.CreateMap<Negocio.Entidades.Persona.NotaEvaluacion, Sql.Modelo.NotaEvaluacion>()
            //    .ForMember(dest => dest.IdTopografo, opt => opt.MapFrom(src => src.Topografo.IdTopografo))
            //    .ForMember(dest => dest.Topografo, opt => opt.Ignore())
            //    .ForMember(dest => dest.FechaCreacion, opt => opt.Ignore())
            //    .ForMember(dest => dest.IdUsuarioModificacion, opt => opt.Ignore())
            //    .ForMember(dest => dest.IdUsuarioCreacion, opt => opt.Ignore())
            //    .ForMember(dest => dest.FechaModificacion, opt => opt.Ignore());


            //configuracionMapeo.CreateMap<Sql.Modelo.NotaEvaluacion, Negocio.Entidades.Persona.NotaEvaluacion>()
            //    .ForMember(dest => dest.Topografo, opt => opt.MapFrom(src => new Negocio.Entidades.Persona.Topografo() { IdTopografo = src.IdTopografo }))
            //    .ForMember(dest => dest.NombreTabla, opt => opt.Ignore())
            //    .ForMember(dest => dest.ReglasInfringidas, opt => opt.Ignore())
            //    .ForMember(dest => dest.RegistroBloqueo, opt => opt.Ignore())
            //    .ForMember(dest => dest.EstaBloqueado, opt => opt.Ignore());


            //#endregion

            //#region Mapeo Quinquenio

            //configuracionMapeo.CreateMap<Negocio.Entidades.Persona.Quinquenio, Sql.Modelo.Quinquenio>()
            //    .ForMember(dest => dest.IdAbogado, opt => opt.MapFrom(src => src.Abogado.IdAbogado))
            //    .ForMember(dest => dest.Abogado, opt => opt.Ignore())
            //    .ForMember(dest => dest.FechaCreacion, opt => opt.Ignore())
            //    .ForMember(dest => dest.IdUsuarioModificacion, opt => opt.Ignore())
            //    .ForMember(dest => dest.IdUsuarioCreacion, opt => opt.Ignore())
            //    .ForMember(dest => dest.FechaModificacion, opt => opt.Ignore());


            //configuracionMapeo.CreateMap<Sql.Modelo.Quinquenio, Negocio.Entidades.Persona.Quinquenio>()
            //    .ForMember(dest => dest.Abogado, opt => opt.MapFrom(src => new Negocio.Entidades.Persona.Abogado() { IdAbogado = src.IdAbogado }))
            //    .ForMember(dest => dest.ReglasInfringidas, opt => opt.Ignore())
            //    .ForMember(dest => dest.RegistroBloqueo, opt => opt.Ignore())
            //     .ForMember(dest => dest.NombreTabla, opt => opt.Ignore())
            //    .ForMember(dest => dest.EstaBloqueado, opt => opt.Ignore());


            //#endregion

            //#region Mapeo Persona

            //configuracionMapeo.CreateMap<Negocio.Entidades.Persona.Persona, Sql.Modelo.Persona>()
            //    .ForMember(dest => dest.IdTipoPersona, opt => opt.MapFrom(src => src.TipoPersona.IdValor))
            //    .ForMember(dest => dest.GrupoPersona, opt => opt.Ignore())
            //    .ForMember(dest => dest.Valor, opt => opt.Ignore())
            //    .ForMember(dest => dest.PersonaContacto, opt => opt.Ignore())
            //    .ForMember(dest => dest.PersonaDireccion, opt => opt.Ignore())
            //     .ForMember(dest => dest.PersonaIdentificacion, opt => opt.Ignore())
            //    .ForMember(dest => dest.PersonaJuridica, opt => opt.Ignore())
            //    .ForMember(dest => dest.Cuenta, opt => opt.Ignore())
            //    .ForMember(dest => dest.PersonaNacionalidad, opt => opt.Ignore())
            //    .ForMember(dest => dest.PersonaNatural, opt => opt.Ignore())
            //    .ForMember(dest => dest.FechaCreacion, opt => opt.Ignore())
            //    .ForMember(dest => dest.IdUsuarioModificacion, opt => opt.Ignore())
            //    .ForMember(dest => dest.IdUsuarioCreacion, opt => opt.Ignore())
            //    .ForMember(dest => dest.FechaModificacion, opt => opt.Ignore());


            //configuracionMapeo.CreateMap<Sql.Modelo.Persona, Negocio.Entidades.Persona.Persona>()
            //    .ForMember(dest => dest.TipoPersona, opt => opt.MapFrom(src => new Negocio.Entidades.TablaBasica.Valor() { IdValor = src.IdTipoPersona }))
            //    .ForMember(dest => dest.PersonaJuridicas, opt => opt.Ignore())
            //    .ForMember(dest => dest.PersonaContactos, opt => opt.Ignore())
            //    .ForMember(dest => dest.PersonaNaturales, opt => opt.Ignore())
            //    .ForMember(dest => dest.PersonaIdentificaciones, opt => opt.Ignore())
            //    .ForMember(dest => dest.GrupoPersonas, opt => opt.Ignore())
            //    .ForMember(dest => dest.PersonaNacionalidades, opt => opt.Ignore())
            //    .ForMember(dest => dest.Direcciones, opt => opt.Ignore())
            //    .ForMember(dest => dest.NombreTabla, opt => opt.Ignore())
            //    .ForMember(dest => dest.ReglasInfringidas, opt => opt.Ignore())
            //    .ForMember(dest => dest.RegistroBloqueo, opt => opt.Ignore())
            //    .ForMember(dest => dest.EstaBloqueado, opt => opt.Ignore());


            //#endregion

            //#region Mapeo PersonaIdentificacion

            //configuracionMapeo.CreateMap<Negocio.Entidades.Persona.PersonaIdentificacion, Sql.Modelo.PersonaIdentificacion>()
            //    .ForMember(dest => dest.IdTipoIdentificacion, opt => opt.MapFrom(src => src.TipoIdentificacion.IdValor))
            //    .ForMember(dest => dest.IdPersona, opt => opt.MapFrom(src => src.Persona.IdPersona))
            //    .ForMember(dest => dest.Persona, opt => opt.Ignore())
            //    .ForMember(dest => dest.Valor, opt => opt.Ignore())
            //    .ForMember(dest => dest.FechaCreacion, opt => opt.Ignore())
            //    .ForMember(dest => dest.IdUsuarioModificacion, opt => opt.Ignore())
            //    .ForMember(dest => dest.IdUsuarioCreacion, opt => opt.Ignore())
            //    .ForMember(dest => dest.FechaModificacion, opt => opt.Ignore());


            //configuracionMapeo.CreateMap<Sql.Modelo.PersonaIdentificacion, Negocio.Entidades.Persona.PersonaIdentificacion>()
            //    .ForMember(dest => dest.TipoIdentificacion, opt => opt.MapFrom(src => new Negocio.Entidades.TablaBasica.Valor() { IdValor = src.IdTipoIdentificacion }))
            //    .ForMember(dest => dest.Persona, opt => opt.MapFrom(src => new Negocio.Entidades.Persona.Persona() { IdPersona = src.IdPersona }))
            //    .ForMember(dest => dest.NombreTabla, opt => opt.Ignore())
            //    .ForMember(dest => dest.ReglasInfringidas, opt => opt.Ignore())
            //    .ForMember(dest => dest.RegistroBloqueo, opt => opt.Ignore())
            //    .ForMember(dest => dest.EstaBloqueado, opt => opt.Ignore());


            //#endregion

            //#region Mapeo PersonaJuridica

            //configuracionMapeo.CreateMap<Negocio.Entidades.Persona.PersonaJuridica, Sql.Modelo.PersonaJuridica>()
            //    .ForMember(dest => dest.IdRepresentanteLegal, opt => opt.MapFrom(src => src.RepresentanteLegal.IdPersonaNatural))
            //    .ForMember(dest => dest.IdPersona, opt => opt.MapFrom(src => src.Persona.IdPersona))
            //    .ForMember(dest => dest.Persona, opt => opt.Ignore())
            //    .ForMember(dest => dest.PersonaNatural, opt => opt.Ignore())
            //    .ForMember(dest => dest.FechaCreacion, opt => opt.Ignore())
            //    .ForMember(dest => dest.IdUsuarioModificacion, opt => opt.Ignore())
            //    .ForMember(dest => dest.IdUsuarioCreacion, opt => opt.Ignore())
            //    .ForMember(dest => dest.FechaModificacion, opt => opt.Ignore());


            //configuracionMapeo.CreateMap<Sql.Modelo.PersonaJuridica, Negocio.Entidades.Persona.PersonaJuridica>()
            //    .ForMember(dest => dest.RepresentanteLegal, opt => opt.MapFrom(src => new Negocio.Entidades.Persona.PersonaNatural() { IdPersonaNatural = src.IdRepresentanteLegal }))
            //    .ForMember(dest => dest.Persona, opt => opt.MapFrom(src => new Negocio.Entidades.Persona.Persona() { IdPersona = src.IdPersona }))
            //    .ForMember(dest => dest.NombreTabla, opt => opt.Ignore())
            //    .ForMember(dest => dest.ReglasInfringidas, opt => opt.Ignore())
            //    .ForMember(dest => dest.RegistroBloqueo, opt => opt.Ignore())
            //    .ForMember(dest => dest.EstaBloqueado, opt => opt.Ignore());


            //#endregion

            //#region Mapeo PersonaNacionalidad

            //configuracionMapeo.CreateMap<Negocio.Entidades.Persona.PersonaNacionalidad, Sql.Modelo.PersonaNacionalidad>()
            //    .ForMember(dest => dest.IdNacionalidad, opt => opt.MapFrom(src => src.Nacionalidad.IdValor))
            //    .ForMember(dest => dest.IdPersona, opt => opt.MapFrom(src => src.Persona.IdPersona))
            //    .ForMember(dest => dest.Persona, opt => opt.Ignore())
            //    .ForMember(dest => dest.Valor, opt => opt.Ignore())
            //    .ForMember(dest => dest.FechaCreacion, opt => opt.Ignore())
            //    .ForMember(dest => dest.IdUsuarioModificacion, opt => opt.Ignore())
            //    .ForMember(dest => dest.IdUsuarioCreacion, opt => opt.Ignore())
            //    .ForMember(dest => dest.FechaModificacion, opt => opt.Ignore());


            //configuracionMapeo.CreateMap<Sql.Modelo.PersonaNacionalidad, Negocio.Entidades.Persona.PersonaNacionalidad>()
            //    .ForMember(dest => dest.Nacionalidad, opt => opt.MapFrom(src => new Negocio.Entidades.TablaBasica.Valor() { IdValor = src.IdNacionalidad }))
            //    .ForMember(dest => dest.Persona, opt => opt.MapFrom(src => new Negocio.Entidades.Persona.Persona() { IdPersona = src.IdPersona }))
            //    .ForMember(dest => dest.NombreTabla, opt => opt.Ignore())
            //    .ForMember(dest => dest.ReglasInfringidas, opt => opt.Ignore())
            //    .ForMember(dest => dest.RegistroBloqueo, opt => opt.Ignore())
            //    .ForMember(dest => dest.EstaBloqueado, opt => opt.Ignore());


            //#endregion

            #region Mapeo PersonaNatural

            configuracionMapeo.CreateMap<Negocio.Entidades.Persona.PersonaNatural, Sql.Modelo.PersonaNatural>()
                .ForMember(dest => dest.IdPersona, opt => opt.MapFrom(src => src.Persona.IdPersona))
                .ForMember(dest => dest.IdGenero, opt => opt.MapFrom(src => src.Genero.IdValor))
                .ForMember(dest => dest.IdEstadoCivil, opt => opt.MapFrom(src => src.EstadoCivil.IdValor))
                .ForMember(dest => dest.IdOcupacion, opt => opt.MapFrom(src => src.Ocupacion.IdValor))
                .ForMember(dest => dest.Persona, opt => opt.Ignore())
                .ForMember(dest => dest.Valor, opt => opt.Ignore())
                .ForMember(dest => dest.Valor1, opt => opt.Ignore())
                .ForMember(dest => dest.Valor2, opt => opt.Ignore())
                .ForMember(dest => dest.FechaCreacion, opt => opt.Ignore())
                .ForMember(dest => dest.IdUsuarioModificacion, opt => opt.Ignore())
                .ForMember(dest => dest.IdUsuarioCreacion, opt => opt.Ignore())
                .ForMember(dest => dest.FechaModificacion, opt => opt.Ignore());


            configuracionMapeo.CreateMap<Sql.Modelo.PersonaNatural, Negocio.Entidades.Persona.PersonaNatural>()
                .ForMember(dest => dest.Persona, opt => opt.MapFrom(src => new Negocio.Entidades.Persona.Persona() { IdPersona = src.IdPersona }))
                .ForMember(dest => dest.Genero, opt => opt.MapFrom(src => new Negocio.Entidades.TablaBasica.Valor() { IdValor = src.IdGenero }))
                .ForMember(dest => dest.EstadoCivil, opt => opt.MapFrom(src => new Negocio.Entidades.TablaBasica.Valor() { IdValor = src.IdEstadoCivil }))
                .ForMember(dest => dest.Ocupacion, opt => opt.MapFrom(src => new Negocio.Entidades.TablaBasica.Valor() { IdValor = src.IdOcupacion }))
                .ForMember(dest => dest.NombreTabla, opt => opt.Ignore());

            #endregion

            //#region Mapeo PersonaContacto

            //configuracionMapeo.CreateMap<Negocio.Entidades.Persona.PersonaContacto, Sql.Modelo.PersonaContacto>()
            //    .ForMember(dest => dest.IdPersona, opt => opt.MapFrom(src => src.Persona.IdPersona))
            //    .ForMember(dest => dest.IdNivelContacto, opt => opt.MapFrom(src => src.NivelContacto.IdNivelContacto))
            //    .ForMember(dest => dest.Persona, opt => opt.Ignore())
            //    .ForMember(dest => dest.NivelContacto, opt => opt.Ignore())
            //    .ForMember(dest => dest.FechaCreacion, opt => opt.Ignore())
            //    .ForMember(dest => dest.IdUsuarioModificacion, opt => opt.Ignore())
            //    .ForMember(dest => dest.IdUsuarioCreacion, opt => opt.Ignore())
            //    .ForMember(dest => dest.FechaModificacion, opt => opt.Ignore());


            //configuracionMapeo.CreateMap<Sql.Modelo.PersonaContacto, Negocio.Entidades.Persona.PersonaContacto>()
            //    .ForMember(dest => dest.Persona, opt => opt.MapFrom(src => new Negocio.Entidades.Persona.Persona() { IdPersona = src.IdPersona }))
            //    .ForMember(dest => dest.NivelContacto, opt => opt.MapFrom(src => new Negocio.Entidades.TablaBasica.NivelContacto() { IdNivelContacto = src.IdNivelContacto }))
            //    .ForMember(dest => dest.NombreTabla, opt => opt.Ignore())
            //    .ForMember(dest => dest.ReglasInfringidas, opt => opt.Ignore())
            //    .ForMember(dest => dest.RegistroBloqueo, opt => opt.Ignore())
            //    .ForMember(dest => dest.EstaBloqueado, opt => opt.Ignore());

            //#endregion

            //#region Mapeo Sancion

            //configuracionMapeo.CreateMap<Negocio.Entidades.Persona.TopografoSancion, Sql.Modelo.TopografoSancion>()
            //    .ForMember(dest => dest.IdCausalSancion, opt => opt.MapFrom(src => src.CausalSancion.IdValor))
            //    .ForMember(dest => dest.IdTopografo, opt => opt.MapFrom(src => src.Topografo.IdTopografo))
            //    .ForMember(dest => dest.IdTipoSancion, opt => opt.MapFrom(src => src.TipoSancion.IdValor))
            //    .ForMember(dest => dest.TipoSancion, opt => opt.Ignore())
            //    .ForMember(dest => dest.CausalSancion, opt => opt.Ignore())
            //    .ForMember(dest => dest.Topografo, opt => opt.Ignore())
            //    .ForMember(dest => dest.FechaCreacion, opt => opt.Ignore())
            //    .ForMember(dest => dest.IdUsuarioModificacion, opt => opt.Ignore())
            //    .ForMember(dest => dest.IdUsuarioCreacion, opt => opt.Ignore())
            //    .ForMember(dest => dest.FechaModificacion, opt => opt.Ignore());


            //configuracionMapeo.CreateMap<Sql.Modelo.TopografoSancion, Negocio.Entidades.Persona.TopografoSancion>()
            //    .ForMember(dest => dest.CausalSancion, opt => opt.MapFrom(src => new Negocio.Entidades.TablaBasica.Valor() { IdValor = src.IdCausalSancion }))
            //    .ForMember(dest => dest.Topografo, opt => opt.MapFrom(src => new Negocio.Entidades.Persona.Topografo() { IdTopografo = src.IdTopografo }))
            //    .ForMember(dest => dest.TipoSancion, opt => opt.MapFrom(src => new Negocio.Entidades.TablaBasica.Valor() { IdValor = src.IdTipoSancion }))
            //    .ForMember(dest => dest.NombreTabla, opt => opt.Ignore())
            //    .ForMember(dest => dest.ReglasInfringidas, opt => opt.Ignore())
            //    .ForMember(dest => dest.RegistroBloqueo, opt => opt.Ignore())
            //    .ForMember(dest => dest.EstaBloqueado, opt => opt.Ignore());


            //#endregion

            //#region Mapeo Topografo

            //configuracionMapeo.CreateMap<Negocio.Entidades.Persona.Topografo, Sql.Modelo.Topografo>()
            //    .ForMember(dest => dest.IdEstadoLicencia, opt => opt.MapFrom(src => src.EstadoLicencia.IdValor))
            //    .ForMember(dest => dest.IdPersonaNatural, opt => opt.MapFrom(src => src.PersonaNatural.IdPersonaNatural))
            //    .ForMember(dest => dest.TopografoEstudioProfesionales, opt => opt.Ignore())
            //    .ForMember(dest => dest.NotaEvaluacion, opt => opt.Ignore())
            //    .ForMember(dest => dest.PersonaNatural, opt => opt.Ignore())
            //    .ForMember(dest => dest.TopografoSanciones, opt => opt.Ignore())
            //    .ForMember(dest => dest.EstadoLicencia, opt => opt.Ignore())
            //    .ForMember(dest => dest.FechaCreacion, opt => opt.Ignore())
            //    .ForMember(dest => dest.IdUsuarioModificacion, opt => opt.Ignore())
            //    .ForMember(dest => dest.IdUsuarioCreacion, opt => opt.Ignore())
            //    .ForMember(dest => dest.FechaModificacion, opt => opt.Ignore());


            //configuracionMapeo.CreateMap<Sql.Modelo.Topografo, Negocio.Entidades.Persona.Topografo>()
            //    .ForMember(dest => dest.EstadoLicencia, opt => opt.MapFrom(src => new Negocio.Entidades.TablaBasica.Valor() { IdValor = src.IdEstadoLicencia }))
            //    .ForMember(dest => dest.PersonaNatural, opt => opt.MapFrom(src => new Negocio.Entidades.Persona.PersonaNatural() { IdPersonaNatural = src.IdPersonaNatural, NombreCompleto = src.PersonaNatural.NombreCompleto }))
            //    .ForMember(dest => dest.TopografoEstudioProfesionales, opt => opt.Ignore())
            //    .ForMember(dest => dest.NotaEvaluaciones, opt => opt.Ignore())
            //    .ForMember(dest => dest.TopografoSanciones, opt => opt.Ignore())
            //    .ForMember(dest => dest.NombreTabla, opt => opt.Ignore())
            //    .ForMember(dest => dest.ReglasInfringidas, opt => opt.Ignore())
            //    .ForMember(dest => dest.RegistroBloqueo, opt => opt.Ignore())
            //    .ForMember(dest => dest.EstaBloqueado, opt => opt.Ignore());


            //#endregion

            //Mapper.AssertConfigurationIsValid();
        }

    }
}