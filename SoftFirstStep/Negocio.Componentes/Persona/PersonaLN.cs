using AccesoDato.Fachada;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Negocio.Componentes.Persona {

    /// <author>Ernesto Medrano</author>
    /// <creationdate>16-sep-2015</creationdate>
    /// <summary>
    /// Clase AplicacionLN nos permite comunicarnos con la FachadaFunAD
    /// </summary>
    public partial class PersonaLN {

        #region Atributos

        /// <author>Ernesto Medrano</author>
        /// <creationdate>16-sep-2015</creationdate>
        /// <summary>
        /// Propiedad FachadaFunAD, de tipo de Interface a ser implementada.
        /// </summary>
        /// 
        public FachadaAdmAD FachadaAdmAD { get { return FachadaAdmADLazy.Value; } }
        public Lazy<FachadaAdmAD> FachadaAdmADLazy { get; set; }

        // private IManejadorValidacion ManejadorValidacion { get { return ManejadorValidacionLazy.Value; } }
        //private Lazy<IManejadorValidacion> ManejadorValidacionLazy { get; set; } 

        // private IManejadorBloqueo ManejadorBloqueo { get { return ManejadorBloqueoLazy.Value; } }
        // private Lazy<IManejadorBloqueo> ManejadorBloqueoLazy { get; set; }

        //public IFachadaUtlLN FachadaUtlLN { get { return FachadaUtlLNLazy.Value; } }
        //public Lazy<IFachadaUtlLN> FachadaUtlLNLazy { get; set; }
        //IFachadaUtlLN FachadaUtlLN = CsjIneter.MarcoTrabajo.Utilidades.Negocio.Componentes.InyeccionDependencia.ContenedorLN.Resolver<FachadaUtlLN>();

        #endregion

        #region Constructores

        /// <author>Ernesto Medrano</author>
        /// <creationdate>16-sep-2015</creationdate>
        /// <summary>
        /// Constructor que recibe la interface IFachadaFunAD que contiene los componentes 
        /// y sus metodos.
        /// </summary>
        /// <param name="fachadaAdmAD">Interaface a ser implementada.</param>
        public PersonaLN(Lazy<FachadaAdmAD> fachadaAdmAD)
            //, Lazy<IManejadorBloqueo> manejadorBloqueo, Lazy<IManejadorValidacion> manejadorValidacion, Lazy<IFachadaUtlLN> fachadaUtlLN) 
        {
            this.FachadaAdmADLazy = fachadaAdmAD;
            //this.ManejadorBloqueoLazy = manejadorBloqueo;
            //this.ManejadorValidacionLazy = manejadorValidacion;
            //this.FachadaUtlLNLazy = fachadaUtlLN;
        }

        #endregion

    }
}