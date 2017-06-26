using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Negocio.Entidades.Persona {

    public partial class PersonaNatural:IEquatable<PersonaNatural> {

        #region Constructores

        /// <author>Ernesto Medrano</author>
        /// <creationdate>11-ene-2016</creationdate>
        /// <summary>
        /// Constructor PersonaNatural que inicializa el campo estaActivo.
        /// </summary>
        /// <returns></returns>
        public PersonaNatural()
            : this(true) {
        }

        /// <author>Ernesto Medrano</author>
        /// <creationdate>11-ene-2016</creationdate>
        /// <summary>
        /// Constructor PersonaNatural que recibe el campo estaActivo.
        /// </summary>
        /// <param name="estaActivo">Estado del componente PersonaNatural.</param>
        /// <returns></returns>
        public PersonaNatural(Boolean estaActivo) {
            this.EstaActivo = estaActivo;           
            this.Persona = null;
            this.Genero = null;
            this.EstadoCivil = null;
            this.Ocupacion = null;
        }

        #endregion

        #region Propiedades

        public String NombreTabla {
            get {
                return "PersonaNatural";
            }
            set { }
        }

        /// <author>Ernesto Medrano</author>
        /// <creationdate>11-ene-2016</creationdate>
        /// <summary>
        /// Identificador única de la Persona, en este caso Persona Natural.
        /// </summary>
        public Int32 IdPersonaNatural { get; set; }

        /// <author>Ernesto Medrano</author>
        /// <creationdate>11-ene-2016</creationdate>
        /// <summary>
        /// Primer Nombre de la Persona.
        /// </summary>
        public String PrimerNombre { get; set; }

        /// <author>Ernesto Medrano</author>
        /// <creationdate>11-ene-2016</creationdate>
        /// <summary>
        /// Segundo Nombre de la Persona.
        ///         /// Valor opcional.
        /// </summary>
        public String SegundoNombre { get; set; }

        /// <author>Ernesto Medrano</author>
        /// <creationdate>11-ene-2016</creationdate>
        /// <summary>
        /// 
        /// </summary>
        public String TercerNombre { get; set; }

        /// <author>Ernesto Medrano</author>
        /// <creationdate>11-ene-2016</creationdate>
        /// <summary>
        /// 
        /// </summary>
        public String CuartoNombre { get; set; }

        /// <author>Ernesto Medrano</author>
        /// <creationdate>11-ene-2016</creationdate>
        /// <summary>
        /// Primer Apellido del la Persona.
        /// </summary>
        public String PrimerApellido { get; set; }

        /// <author>Ernesto Medrano</author>
        /// <creationdate>11-ene-2016</creationdate>
        /// <summary>
        /// Segundo Apellido del la Persona. 
        ///         /// Valor opcional.
        /// </summary>
        public String SegundoApellido { get; set; }

        /// <author>Ernesto Medrano</author>
        /// <creationdate>11-ene-2016</creationdate>
        /// <summary>
        /// Nombre completo de la persona. (nombres y apellidos).
        /// </summary>
        public String NombreCompleto { get; set; }

        /// <author>Ernesto Medrano</author>
        /// <creationdate>11-ene-2016</creationdate>
        /// <summary>
        /// Apellido de Casada
        /// </summary>
        public String ApellidoDeCasada { get; set; }

        /// <author>Ernesto Medrano</author>
        /// <creationdate>11-ene-2016</creationdate>
        /// <summary>
        /// Alias de la persona.
        ///         /// Valor opcional.
        /// </summary>
        public String ConocidoComo { get; set; }

        /// <author>Ernesto Medrano</author>
        /// <creationdate>11-ene-2016</creationdate>
        /// <summary>
        /// Fecha de nacimiento de la Persona, con el cual se calcular su edad.
        /// </summary>
        public DateTime FechaNacimiento { get; set; }

        /// <author>Ernesto Medrano</author>
        /// <creationdate>11-ene-2016</creationdate>
        /// <summary>
        /// Fecha y Hora de Fallecimiento de la persona. 
        /// </summary>
        public Nullable<DateTime> FechaFallecimiento { get; set; }

        /// <author>Ernesto Medrano</author>
        /// <creationdate>11-ene-2016</creationdate>
        /// <summary>
        /// 
        /// </summary>
        public Boolean EstaActivo { get; private set; }

        /// <author>Ernesto Medrano</author>
        /// <creationdate>11-ene-2016</creationdate>
        /// <summary>
        /// Esta tabla registra los diferentes tipos de personas como: naturales, jurídicos, organizaciones e instituciones, grupos de comunidades indígenas, etc.
        /// </summary>
        public Entidades.Persona.Persona Persona { get; set; }

        /// <author>Ernesto Medrano</author>
        /// <creationdate>11-ene-2016</creationdate>
        /// <summary>
        /// El Catálogo de Valores contiene en si como su nombre lo indica los valores o contenido de una tabla. Por ejemplo si el Catálogo es el de Género en el catálogo de valores se tendrá:
        ///         /// 1 Femenino
        ///         /// 2 Masculino
        /// </summary>
        public Entidades.TablaBasica.Valor Genero { get; set; }

        /// <author>Ernesto Medrano</author>
        /// <creationdate>11-ene-2016</creationdate>
        /// <summary>
        /// El Catálogo de Valores contiene en si como su nombre lo indica los valores o contenido de una tabla. Por ejemplo si el Catálogo es el de Género en el catálogo de valores se tendrá:
        ///         /// 1 Femenino
        ///         /// 2 Masculino
        /// </summary>
        public Entidades.TablaBasica.Valor EstadoCivil { get; set; }

        /// <author>Ernesto Medrano</author>
        /// <creationdate>11-ene-2016</creationdate>
        /// <summary>
        /// El Catálogo de Valores contiene en si como su nombre lo indica los valores o contenido de una tabla. Por ejemplo si el Catálogo es el de Género en el catálogo de valores se tendrá:
        ///         /// 1 Femenino
        ///         /// 2 Masculino
        /// </summary>
        public Entidades.TablaBasica.Valor Ocupacion { get; set; }

        #endregion

        #region Colecciones

        #endregion

        #region Métodos

        /// <author>Ernesto Medrano</author>
        /// <creationdate>11-ene-2016</creationdate>
        /// <summary>
        /// Método de comparación de propiedades.
        /// </summary>
        /// <param name="personaNatural">Objeto de tipo PersonaNatural a ser comparado.</param>
        /// <returns>True: Si las propiedades son iguales.</returns>
        public Boolean Equals(PersonaNatural personaNatural) {
            if ( this.IdPersonaNatural != personaNatural.IdPersonaNatural ) {
                return false;
            }
            if ( this.PrimerNombre != personaNatural.PrimerNombre ) {
                return false;
            }
            if ( this.SegundoNombre != personaNatural.SegundoNombre ) {
                return false;
            }
            if ( this.TercerNombre != personaNatural.TercerNombre ) {
                return false;
            }
            if ( this.CuartoNombre != personaNatural.CuartoNombre ) {
                return false;
            }
            if ( this.PrimerApellido != personaNatural.PrimerApellido ) {
                return false;
            }
            if ( this.SegundoApellido != personaNatural.SegundoApellido ) {
                return false;
            }
            if ( this.NombreCompleto != personaNatural.NombreCompleto ) {
                return false;
            }
            if ( this.ApellidoDeCasada != personaNatural.ApellidoDeCasada ) {
                return false;
            }
            if ( this.ConocidoComo != personaNatural.ConocidoComo ) {
                return false;
            }
            if ( this.FechaNacimiento != personaNatural.FechaNacimiento ) {
                return false;
            }
            if ( this.EstaActivo != personaNatural.EstaActivo ) {
                return false;
            }
            if ( this.Persona != null ) {
                if ( this.Persona.IdPersona != personaNatural.Persona.IdPersona ) {
                    return false;
                }
            }
            if ( this.Genero != null ) {
                if ( this.Genero.IdValor != personaNatural.Genero.IdValor ) {
                    return false;
                }
            }
            if ( this.EstadoCivil != null ) {
                if ( this.EstadoCivil.IdValor != personaNatural.EstadoCivil.IdValor ) {
                    return false;
                }
            }
            if ( this.Ocupacion != null ) {
                if ( this.Ocupacion.IdValor != personaNatural.Ocupacion.IdValor ) {
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
                case "idpersonanatural":
                case "primernombre":
                case "segundonombre":
                case "tercernombre":
                case "cuartonombre":
                case "primerapellido":
                case "segundoapellido":
                case "nombrecompleto":
                case "apellidodecasada":
                case "conocidocomo":
                case "fechanacimiento":
                case "existeenpadronelectoral":
                case "estafallecido":
                case "fechafallecimiento":
                case "estaactivo":
                    return false;
                case "idpersona":
                case "persona":
                case "idgenero":
                case "genero":
                case "idestadocivil":
                case "estadocivil":
                case "idocupacion":
                case "ocupacion":
                    return false;
                case "idabogados":
                case "abogados":
                case "idtopografos":
                case "topografos":
                case "idpersonajuridicas":
                case "personajuridicas":
                case "idempleadohijos":
                case "empleadohijos":
                    return true;
                default:
                    return false;

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
            listaPropiedades.Add("IdPersonaNatural");
            listaPropiedades.Add("PrimerNombre");
            listaPropiedades.Add("SegundoNombre");
            listaPropiedades.Add("TercerNombre");
            listaPropiedades.Add("CuartoNombre");
            listaPropiedades.Add("PrimerApellido");
            listaPropiedades.Add("SegundoApellido");
            listaPropiedades.Add("NombreCompleto");
            listaPropiedades.Add("ApellidoDeCasada");
            listaPropiedades.Add("ConocidoComo");
            listaPropiedades.Add("FechaNacimiento");
            listaPropiedades.Add("ExisteEnPadronElectoral");
            listaPropiedades.Add("EstaFallecido");
            listaPropiedades.Add("FechaFallecimiento");
            listaPropiedades.Add("EstaActivo");
            listaPropiedades.Add("Persona");
            listaPropiedades.Add("Genero");
            listaPropiedades.Add("EstadoCivil");
            listaPropiedades.Add("Ocupacion");
            listaPropiedades.Add("Abogados");
            listaPropiedades.Add("Topografos");
            listaPropiedades.Add("PersonaJuridicas");
            listaPropiedades.Add("EmpleadoHijos");
            return listaPropiedades;
        }

        /// <author>Ernesto Medrano</author>
        /// <creationdate>11-ene-2016</creationdate>
        /// <summary>
        /// Retorna una cadena que representa la clase actual.
        /// </summary>
        /// <returns>Cadena que representa la clase actual</returns>
        public override string ToString() {
            String textoPlano =
                this.IdPersonaNatural.ToString() + "." +
                ((this.PrimerNombre != null) ? this.PrimerNombre.ToString() : "null") + "." +
                ((this.SegundoNombre != null) ? this.SegundoNombre.ToString() : "null") + "." +
                ((this.TercerNombre != null) ? this.TercerNombre.ToString() : "null") + "." +
                ((this.CuartoNombre != null) ? this.CuartoNombre.ToString() : "null") + "." +
                ((this.PrimerApellido != null) ? this.PrimerApellido.ToString() : "null") + "." +
                ((this.SegundoApellido != null) ? this.SegundoApellido.ToString() : "null") + "." +
                ((this.NombreCompleto != null) ? this.NombreCompleto.ToString() : "null") + "." +
                ((this.ApellidoDeCasada != null) ? this.ApellidoDeCasada.ToString() : "null") + "." +
                ((this.ConocidoComo != null) ? this.ConocidoComo.ToString() : "null") + "." +
                ((this.FechaNacimiento != null) ? this.FechaNacimiento.ToString() : "null") + "." +
                ((this.FechaFallecimiento != null) ? this.FechaFallecimiento.ToString() : "null") + "." +
                this.EstaActivo.ToString() + "." +
                ((this.Persona != null) ? this.Persona.IdPersona.ToString() : "null") + "." +
                ((this.Genero != null) ? this.Genero.IdValor.ToString() : "null") + "." +
                ((this.EstadoCivil != null) ? this.EstadoCivil.IdValor.ToString() : "null") + "." +
                ((this.Ocupacion != null) ? this.Ocupacion.IdValor.ToString() : "null");
            return textoPlano;
        }

        /// <author>Ernesto Medrano</author>
        /// <creationdate>11-ene-2016</creationdate>
        /// <summary>
        /// Método de Clonar Entidad.
        /// </summary>
        /// <param name="personaNatural">Objeto de tipo PersonaNatural a ser Clonado.</param>
        /// <returns> </returns>
        public PersonaNatural Clone() {
            return new PersonaNatural() {
                IdPersonaNatural = this.IdPersonaNatural
            ,

                PrimerNombre = this.PrimerNombre
            ,

                SegundoNombre = this.SegundoNombre
            ,

                TercerNombre = this.TercerNombre
            ,

                CuartoNombre = this.CuartoNombre
            ,

                PrimerApellido = this.PrimerApellido
            ,

                SegundoApellido = this.SegundoApellido
            ,

                NombreCompleto = this.NombreCompleto
            ,
                ApellidoDeCasada = this.ApellidoDeCasada
            ,

                ConocidoComo = this.ConocidoComo
            ,

                FechaNacimiento = this.FechaNacimiento
            ,
                FechaFallecimiento = this.FechaFallecimiento
            ,

                EstaActivo = this.EstaActivo
            ,

                Persona = new Entidades.Persona.Persona() { IdPersona = this.Persona.IdPersona }
            ,

                Genero = new Entidades.TablaBasica.Valor() { IdValor = this.Genero.IdValor }
            ,

                EstadoCivil = new Entidades.TablaBasica.Valor() { IdValor = this.EstadoCivil.IdValor }
            ,

                Ocupacion = new Entidades.TablaBasica.Valor() { IdValor = this.Ocupacion.IdValor }
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
                "<PersonaNatural>\r\n" +
                "   <IdPersonaNatural>" + this.IdPersonaNatural + "</IdPersonaNatural>\r\n" +
                "   <Nombre1>" + (this.PrimerApellido != null ? this.PrimerNombre : "null") + "</Nombre1>\r\n" +
                "   <Nombre2>" + (this.SegundoNombre != null ? this.SegundoNombre : "null") + "</Nombre2>\r\n" +
                "   <Nombre3>" + (this.TercerNombre != null ? this.TercerNombre : "null") + "</Nombre3>\r\n" +
                "   <Nombre4>" + (this.CuartoNombre != null ? this.CuartoNombre : "null") + "</Nombre4>\r\n" +
                "   <Apellido1>" + (this.PrimerApellido != null ? this.PrimerApellido : "null") + "</Apellido1>\r\n" +
                "   <Apellido2>" + (this.SegundoApellido != null ? this.SegundoApellido : "null") + "</Apellido2>\r\n" +
                "   <NombreCompleto>" + (this.NombreCompleto != null ? this.NombreCompleto : "null") + "</NombreCompleto>\r\n" +
                "   <ApellidoDeCasada>" + (this.ApellidoDeCasada != null ? this.ApellidoDeCasada : "null") + "</ApellidoDeCasada>\r\n" +
                "   <ConocidoComo>" + (this.ConocidoComo != null ? this.ConocidoComo : "null") + "</ConocidoComo>\r\n" +
                "   <FechaNacimiento>" + this.FechaNacimiento + "</FechaNacimiento>\r\n" +
                "   <FechaFallecimiento>" + this.FechaFallecimiento + "</FechaFallecimiento>\r\n" +
                "   <EstaActivo>" + this.EstaActivo + "</EstaActivo>\r\n" +
                "   <Persona>" + (this.Persona != null ? this.Persona.ToString() : "null") + "</Persona>\r\n" +
                "   <Genero>" + (this.Genero != null ? this.Genero.ToString() : "null") + "</Genero>\r\n" +
                "   <EstadoCivil>" + (this.EstadoCivil != null ? this.EstadoCivil.ToString() : "null") + "</EstadoCivil>\r\n" +
                "   <Ocupacion>" + (this.Ocupacion != null ? this.Ocupacion.ToString() : "null") + "</Ocupacion>\r\n" +
                "   <Abogados>\r\n" +
                "      [Abogados]" +
                "   </Abogados>\r\n" +
                "   <Topografos>\r\n" +
                "      [Topografos]" +
                "   </Topografos>\r\n" +
                "   <PersonaJuridicas>\r\n" +
                "      [PersonaJuridicas]" +
                "   </PersonaJuridicas>\r\n" +
                "   <EmpleadoHijos>\r\n" +
                "      [EmpleadoHijos]" +
                "   </EmpleadoHijos>\r\n" +
                "</PersonaNatural>";

            return textoXml;
        }

        #endregion

    }
}
