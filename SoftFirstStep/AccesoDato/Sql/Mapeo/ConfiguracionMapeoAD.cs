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
    public class ConfiguracionMapeoAD {
        
        private IMapper Mapper;
        /// <author>Ernesto Medrano</author>
        /// <creationdate>29-jul-2015</creationdate>
        /// <summary>
        /// Metodo que contiene la configuracion de los cada uno de los mapeos de los diferentes 
        /// objetos a ser mapiados.
        /// </summary> 
        public ConfiguracionMapeoAD() {
            MapperConfigurationExpression configuracionMapeo = new MapperConfigurationExpression();

            PersonaMP.RegistrarMapeos(configuracionMapeo);

            var MapperConfiguration = new MapperConfiguration(configuracionMapeo);

            Mapper = MapperConfiguration.CreateMapper();
            Mapper.ConfigurationProvider.AssertConfigurationIsValid();



        }

        public void CrearMapeo(MapperConfigurationExpression configuracionMapeo) {
            throw new NotImplementedException();
        }

        public TDestination Mapeo<TSource, TDestination>(TSource source, TDestination destination) {
            return this.Mapper.Map<TSource, TDestination>(source, destination);
        }

        public TDestination Mapeo<TSource, TDestination>(TSource source) {
            return this.Mapper.Map<TSource, TDestination>(source);
        }

        public void ValidarConfiguracionMapeo() {
            throw new NotImplementedException();
        }

    }
}