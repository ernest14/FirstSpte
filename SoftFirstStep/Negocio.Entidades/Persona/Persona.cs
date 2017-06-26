using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Negocio.Entidades.TablaBasica;

namespace Negocio.Entidades.Persona {

    public partial class Persona:IEquatable<Persona> {

        #region Constructores

        /// <author>Ernesto Medrano</author>
        /// <creationdate>11-ene-2016</creationdate>
        /// <summary>
        /// Constructor Persona que inicializa el campo estaActivo.
        /// </summary>
        /// <returns></returns>
        public Persona()
            : this(true) {
        }

        /// <author>Ernesto Medrano</author>
        /// <creationdate>11-ene-2016</creationdate>
        /// <summary>
        /// Constructor Persona que recibe el campo estaActivo.
        /// </summary>
        /// <param name="estaActivo">Estado del componente Persona.</param>
        /// <returns></returns>
        public Persona(Boolean estaActivo) {
            this.EstaActivo = estaActivo;
            this.PersonaNaturales = null;           
            this.TipoPersona = null;
        }

        #endregion

        #region Propiedades

        public String NombreTabla {
            get {
                return "Persona";
            }
            set { }
        }

        /// <author>Ernesto Medrano</author>
        /// <creationdate>11-ene-2016</creationdate>
        /// <summary>
        /// Identificador único en todo el sistema SIICAR de una persona.
        /// </summary>
        public Int32 IdPersona { get; set; }

        /// <author>Ernesto Medrano</author>
        /// <creationdate>11-ene-2016</creationdate>
        /// <summary>
        /// 
        /// </summary>
        public Boolean EstaActivo { get; private set; }

        /// <author>Ernesto Medrano</author>
        /// <creationdate>11-ene-2016</creationdate>
        /// <summary>
        /// El Catálogo de Valores contiene en si como su nombre lo indica los valores o contenido de una tabla. Por ejemplo si el Catálogo es el de Género en el catálogo de valores se tendrá:
        ///         /// 1 Femenino
        ///         /// 2 Masculino
        /// </summary>
        public Entidades.TablaBasica.Valor TipoPersona { get; set; }

        #endregion

        #region Colecciones

        /// <author>Ernesto Medrano</author>
        /// <creationdate>11-ene-2016</creationdate>
        /// <summary>
        /// Información General de la una Persona Natural, cual puede ser Nicaragüense o Extranjero temporal o Residente.
        ///         /// 
        ///         /// Un Persona Natural puede ser un Empleado interno (RP), externo ( Catastro Físico, empresas privadas, Instituciones del gobierno), Abogado, Notario, topógrafo, Representante legal, Jueces, otro tipo de Persona válido en el sistema SIICAR.
        ///         /// 
        ///         /// En caso de Registro de Comerciantes o Empresario Individuales, aquí se almacenará la información general,como lo que establece la ley 698 Art.157: Nombres, Apellidos, Edad ( se registrará la fecha de Nacimiento, validando que sea mayor de edad), Estado civil, Domicilio de la Persona, no del Comercio o Negocio, Nacionalidad. El resto de la información correspondiente al Comercio o Negocio se registrará en la entidades del Negocio como tal, esto es caso subsistema Mercantil.
        ///         /// 
        ///         /// En caso de la información de Nacionalidad, esta relacionada con País.
        /// </summary>
        public ICollection<Entidades.Persona.PersonaNatural> PersonaNaturales { get; set; }
       
        #endregion

        #region Métodos

        /// <author>Ernesto Medrano</author>
        /// <creationdate>11-ene-2016</creationdate>
        /// <summary>
        /// Método de comparación de propiedades.
        /// </summary>
        /// <param name="persona">Objeto de tipo Persona a ser comparado.</param>
        /// <returns>True: Si las propiedades son iguales.</returns>
        public Boolean Equals(Persona persona) {
            if ( this.IdPersona != persona.IdPersona ) {
                return false;
            }
            if ( this.EstaActivo != persona.EstaActivo ) {
                return false;
            }
            if ( this.TipoPersona != null ) {
                if ( this.TipoPersona.IdValor != persona.TipoPersona.IdValor ) {
                    return false;
                }
            }
            return true;
        }

        /// <author>Ernesto Medrano</author>
        /// <creationdate>11-ene-2016</creationdate>
        /// <summary>
        /// Retorna un valor que indica si la propiedad solicitada es una colección o no
        /// </summary>
        /// <returns>Boolean - Valor que indica si la propiedad es o no una colección</returns>
        public Boolean EsColeccion(String propiedad) {
            switch ( propiedad.ToLower() ) {
                case "idpersona":
                case "estaactivo":
                    return false;
                case "idtipopersona":
                case "tipopersona":
                    return false;
                case "idpersonanaturales":
                case "personanaturales":
                case "idgrupopersonas":
                case "grupopersonas":
                case "idpersonaidentificaciones":
                case "personaidentificaciones":
                case "idpersonanacionalidades":
                case "personanacionalidades":
                case "idpersonajuridicas":
                case "personajuridicas":
                case "idpersonacontactos":
                case "personacontactos":
                case "iddirecciones":
                case "direcciones":
                    return true;
                default:
                    return false;

            }
        }

        /// <author>Ernesto Medrano</author>
        /// <creationdate>11-ene-2016</creationdate>
        /// <summary>
        /// Obtiene el nombre de la tabla de la propiedad solicitada en formato de texto
        /// </summary>
        /// <returns>String - Nombre de la tabla si no se encuentra retorna nulo</returns>
        public String ObtenerNombreTabla(String propiedad) {
            switch ( propiedad.ToLower() ) {
                case "idpersona":
                    return NombreTabla;
                case "estaactivo":
                    return NombreTabla;
                case "idtipopersona":
                case "tipopersona":
                    return new Valor().NombreTabla;
                case "idpersonanaturales":
                case "personanaturales":
                    return new PersonaNatural().NombreTabla;                
                default:
                    return null;

            }
        }

        /// <author>Ernesto Medrano</author>
        /// <creationdate>11-ene-2016</creationdate>
        /// <summary>
        /// Obtiene el valor de la propiedad solicitada en formato de texto
        /// </summary>
        /// <returns>String - Valor de la propiedad solicitada, de no existir retorna nulo</returns>
        public List<String> ObtenerPropiedades() {
            List<String> listaPropiedades = new List<String>();
            listaPropiedades.Add("IdPersona");
            listaPropiedades.Add("EstaActivo");
            listaPropiedades.Add("TipoPersona");
            listaPropiedades.Add("PersonaNaturales");
            listaPropiedades.Add("GrupoPersonas");
            listaPropiedades.Add("PersonaIdentificaciones");
            listaPropiedades.Add("PersonaNacionalidades");
            listaPropiedades.Add("PersonaJuridicas");
            listaPropiedades.Add("PersonaContactos");
            listaPropiedades.Add("Direcciones");
            return listaPropiedades;
        }

        /// <author>Ernesto Medrano</author>
        /// <creationdate>11-ene-2016</creationdate>
        /// <summary>
        /// Obtiene el valor de la propiedad solicitada en formato de texto
        /// </summary>
        /// <returns>String - Valor de la propiedad solicitada, de no existir retorna nulo</returns>
        public String ObtenerValor(String propiedad) {
            List<Int32> listadoId = new List<Int32>();

            switch ( propiedad.ToLower() ) {
                case "idpersona":
                    return IdPersona.ToString();
                case "estaactivo":
                    return EstaActivo.ToString();
                case "idtipopersona":
                case "tipopersona":
                    return TipoPersona.IdValor.ToString();
                case "idpersonanaturales":
                case "personanaturales":
                    listadoId = new List<Int32>();
                    foreach ( PersonaNatural item in PersonaNaturales ) {
                        listadoId.Add(item.IdPersonaNatural);
                    }
                    return String.Join("|", listadoId);               
                default:
                    return null;

            }
        }

        /// <author>Ernesto Medrano</author>
        /// <creationdate>11-ene-2016</creationdate>
        /// <summary>
        /// Retorna una cadena que representa la clase actual.
        /// </summary>
        /// <returns>Cadena que representa la clase actual</returns>
        public override string ToString() {
            String textoPlano =
                this.IdPersona.ToString() + "." +
                this.EstaActivo.ToString() + "." +
                ((this.TipoPersona != null) ? this.TipoPersona.IdValor.ToString() : "null");
            return textoPlano;

        }

        /// <author>Ernesto Medrano</author>
        /// <creationdate>11-ene-2016</creationdate>
        /// <summary>
        /// Método de Clonar Entidad.
        /// </summary>
        /// <param name="persona">Objeto de tipo Persona a ser Clonado.</param>
        /// <returns> </returns>
        public Persona Clone() {
            return new Persona() {
                IdPersona = this.IdPersona
            ,

                EstaActivo = this.EstaActivo
            ,

                TipoPersona = new Entidades.TablaBasica.Valor() { IdValor = this.TipoPersona.IdValor }
            };
        }

        /// <author>Ernesto Medrano</author>
        /// <creationdate>11-ene-2016</creationdate>
        /// <summary>
        /// Genera una porción de texto Xml basado en el registro, respetando las normas de esquemas estandarizadas.
        /// </summary>
        /// <returns>Texto con formato Xml de los valores del objeto actual</returns>
        public String ToXml() {
            String textoXml =
                "<Persona>\r\n" +
                "   <IdPersona>" + this.IdPersona + "</IdPersona>\r\n" +
                "   <EstaActivo>" + this.EstaActivo + "</EstaActivo>\r\n" +
                "   <TipoPersona>" + (this.TipoPersona != null ? this.TipoPersona.ToString() : "null") + "</TipoPersona>\r\n" +
                "   <PersonaNaturales>\r\n" +
                "      [PersonaNaturales]" +
                "   </PersonaNaturales>\r\n" +
                "   <GrupoPersonas>\r\n" +
                "      [GrupoPersonas]" +
                "   </GrupoPersonas>\r\n" +
                "   <PersonaIdentificaciones>\r\n" +
                "      [PersonaIdentificaciones]" +
                "   </PersonaIdentificaciones>\r\n" +
                "   <PersonaNacionalidades>\r\n" +
                "      [PersonaNacionalidades]" +
                "   </PersonaNacionalidades>\r\n" +
                "   <PersonaJuridicas>\r\n" +
                "      [PersonaJuridicas]" +
                "   </PersonaJuridicas>\r\n" +
                "   <PersonaContactos>\r\n" +
                "      [PersonaContactos]" +
                "   </PersonaContactos>\r\n" +
                "   <Direcciones>\r\n" +
                "      [Direcciones]" +
                "   </Direcciones>\r\n" +
                "</Persona>";

            //Generar Xml para 'PersonaNaturales'
            if ( this.PersonaNaturales != null ) {
                foreach ( Entidades.Persona.PersonaNatural personaNatural in this.PersonaNaturales ) {
                    textoXml = textoXml.Replace("[PersonaNaturales]", (personaNatural != null ? personaNatural.ToString() : "null") + "[PersonaNaturales]");
                }
            } else {
                textoXml = textoXml.Replace("[PersonaNaturales]", "null\r\n");
            }
            textoXml = textoXml.Replace("[PersonaNaturales]", "");
            
            return textoXml;
        }

        #endregion

    }
}
