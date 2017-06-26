using AccesoDato.Fachada;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Negocio.Componentes.TablaBasica {

    /// <author>Mario Gomez</author>
    /// <creationdate>12-may-2016</creationdate>
    /// <summary>
    /// Clase AplicacionLN nos permite comunicarnos con la FachadaFunAD
    /// </summary>
    public partial class TablaBasicaLN {

        #region Atributos

        /// <author>Mario Gomez</author>
        /// <creationdate>12-may-2016</creationdate>
        /// <summary>
        /// Propiedad FachadaFunAD de tipo de Interface a ser implementada.
        /// </summary>

        public FachadaAdmAD FachadaAdmAD { get { return FachadaAdmADLazy.Value; } }
        public Lazy<FachadaAdmAD> FachadaAdmADLazy { get; set; }

        //private IManejadorValidacion ManejadorValidacion { get { return ManejadorValidacionLazy.Value; } }
        //private Lazy<IManejadorValidacion> ManejadorValidacionLazy { get; set; }

        //private IManejadorBloqueo ManejadorBloqueo { get { return ManejadorBloqueoLazy.Value; } }
        //private Lazy<IManejadorBloqueo> ManejadorBloqueoLazy { get; set; }

        //IFachadaUtlLN FachadaUtlLN = CsjIneter.MarcoTrabajo.Utilidades.Negocio.Componentes.InyeccionDependencia.ContenedorLN.Resolver<FachadaUtlLN>();

        #endregion

        #region Constructores

        /// <author>Mario Gomez</author>
        /// <creationdate>12-may-2016</creationdate>
        /// <summary>
        /// Constructor que recibe la interface IFachadaFunAD que contiene los componentes 
        /// y sus metodos.
        /// </summary>
        /// <param name="fachadaAdmAD">Interaface a ser implementada.</param>
        public TablaBasicaLN(Lazy<FachadaAdmAD> fachadaAdmAD
            //, Lazy<IManejadorBloqueo> manejadorBloqueo, Lazy<IManejadorValidacion> manejadorValidacion
            ) {
            this.FachadaAdmADLazy = fachadaAdmAD;
            //this.ManejadorBloqueoLazy = manejadorBloqueo;
            //this.ManejadorValidacionLazy = manejadorValidacion;
        }

        #endregion

    }
}