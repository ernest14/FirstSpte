using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.ComponentModel;
using Negocio.Componentes.Persona;
using Negocio.Componentes.FachadaLN;
using Negocio.Componentes.TablaBasica;

namespace Negocio.Componentes.FachadaLN {

    public partial class FachadaAdmLN {

        #region Atributos

        /// <author>Ernesto Medrano</author>
        /// <creationdate>11-ago-2015</creationdate>
        /// <summary>
        /// FachadaFunAD de tipo IFachadaFunAD que contien los conponentes y sus métodos.
        /// </summary>
        public PersonaLN PersonaLN { get { return PersonaLNLazy.Value; } }
        public TablaBasicaLN TablaBasicaLN { get { return TablaBasicaLNLazy.Value; } }

        //Propiedades Lazy
        public Lazy<PersonaLN> PersonaLNLazy { get; set; }
        public Lazy<TablaBasicaLN> TablaBasicaLNLazy { get; set; }

        #endregion

        #region Constructores

        public FachadaAdmLN(Lazy<PersonaLN> personaLN, Lazy<TablaBasicaLN> tablaBasicaLN) {

            this.PersonaLNLazy = personaLN;
            this.TablaBasicaLNLazy = tablaBasicaLN;

        }

        #endregion

    }
}







