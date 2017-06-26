using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Negocio.Entidades.TablaBasica {

    public partial class Catalogo:IEquatable<Catalogo> {

        #region Constructores

        /// <author>Ernesto Medrano</author>
        /// <creationdate>11-ene-2016</creationdate>
        /// <summary>
        /// Constructor Catalogo que inicializa el campo estaActivo.
        /// </summary>
        /// <returns></returns>
        public Catalogo()
            : this(true) {
        }

        /// <author>Ernesto Medrano</author>
        /// <creationdate>11-ene-2016</creationdate>
        /// <summary>
        /// Constructor Catalogo que recibe el campo estaActivo.
        /// </summary>
        /// <param name="estaActivo">Estado del componente Catalogo.</param>
        /// <returns></returns>
        public Catalogo(Boolean estaActivo) {
            this.EstaActivo = estaActivo;           
            this.Valores = null;
        }

        #endregion

        #region Propiedades

        public String NombreTabla {
            get {
                return "Catalogo";
            }
            set { }
        }

        /// <author>Ernesto Medrano</author>
        /// <creationdate>11-ene-2016</creationdate>
        /// <summary>
        /// Identificador Único de Catálogo
        /// </summary>
        public Int16 IdCatalogo { get; set; }

        /// <author>Ernesto Medrano</author>
        /// <creationdate>11-ene-2016</creationdate>
        /// <summary>
        /// Este código interno será manejado en duro por el Sistema, es decir será el codigo que permitirá saber qué tabla utilizará un determinado caso de uso del negocio. Si será el dódigo uno, dos, tres, etc., que podría hacer referencia a la tabla de género, estado civil, etc. 
        /// </summary>
        public String CodigoInterno { get; set; }

        /// <author>Ernesto Medrano</author>
        /// <creationdate>11-ene-2016</creationdate>
        /// <summary>
        /// Nombre de Catalogo.
        /// </summary>
        public String Nombre { get; set; }

        /// <author>Ernesto Medrano</author>
        /// <creationdate>11-ene-2016</creationdate>
        /// <summary>
        /// Descripción General del Catalogo definido.
        /// </summary>
        public String Descripcion { get; set; }

        /// <author>Ernesto Medrano</author>
        /// <creationdate>11-ene-2016</creationdate>
        /// <summary>
        /// Bandera que indica que solo el Administrador DBA puede dar mantenimiento a dicho catalogo definido.
        /// </summary>
        public Boolean EsReservado { get; set; }

        /// <author>Ernesto Medrano</author>
        /// <creationdate>11-ene-2016</creationdate>
        /// <summary>
        /// Indica si el registro se encuentra activo o no activo.
        /// </summary>
        public Boolean EstaActivo { get; private set; }
        
        #endregion

        #region Colecciones

        /// <author>Ernesto Medrano</author>
        /// <creationdate>11-ene-2016</creationdate>
        /// <summary>
        /// El Catálogo de Valores contiene en si como su nombre lo indica los valores o contenido de una tabla. Por ejemplo si el Catálogo es el de Género en el catálogo de valores se tendrá:
        ///         /// 1 Femenino
        ///         /// 2 Masculino
        /// </summary>
        public ICollection<Entidades.TablaBasica.Valor> Valores { get; set; }

        #endregion

        #region Métodos


        /// <author>Ernesto Medrano</author>
        /// <creationdate>11-ene-2016</creationdate>
        /// <summary>
        /// Método de comparación de propiedades.
        /// </summary>
        /// <param name="catalogo">Objeto de tipo Catalogo a ser comparado.</param>
        /// <returns>True: Si las propiedades son iguales.</returns>
        public Boolean Equals(Catalogo catalogo) {
            if ( this.IdCatalogo != catalogo.IdCatalogo ) {
                return false;
            }
            if ( this.CodigoInterno != catalogo.CodigoInterno ) {
                return false;
            }
            if ( this.Nombre != catalogo.Nombre ) {
                return false;
            }
            if ( this.Descripcion != catalogo.Descripcion ) {
                return false;
            }
            if ( this.EsReservado != catalogo.EsReservado ) {
                return false;
            }
            if ( this.EstaActivo != catalogo.EstaActivo ) {
                return false;
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
                case "idcatalogo":
                case "codigointerno":
                case "nombre":
                case "descripcion":
                case "esreservado":
                case "estaactivo":
                    return false;
                case "idatributos":
                case "atributos":
                case "idvalores":
                case "valores":
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
                case "idcatalogo":
                    return NombreTabla;
                case "codigointerno":
                    return NombreTabla;
                case "nombre":
                    return NombreTabla;
                case "descripcion":
                    return NombreTabla;
                case "esreservado":
                    return NombreTabla;
                case "estaactivo":
                    return NombreTabla;                
                case "idvalores":
                case "valores":
                    return new Valor().NombreTabla;
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
            listaPropiedades.Add("IdCatalogo");
            listaPropiedades.Add("CodigoInterno");
            listaPropiedades.Add("Nombre");
            listaPropiedades.Add("Descripcion");
            listaPropiedades.Add("EsReservado");
            listaPropiedades.Add("EstaActivo");
            listaPropiedades.Add("Atributos");
            listaPropiedades.Add("Valores");
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
                case "idcatalogo":
                    return IdCatalogo.ToString();
                case "codigointerno":
                    return CodigoInterno.ToString();
                case "nombre":
                    return Nombre.ToString();
                case "descripcion":
                    return Descripcion.ToString();
                case "esreservado":
                    return EsReservado.ToString();
                case "estaactivo":
                    return EstaActivo.ToString();                
                case "idvalores":
                case "valores":
                    listadoId = new List<Int32>();
                    foreach ( Valor item in Valores ) {
                        listadoId.Add(item.IdValor);
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
                this.IdCatalogo.ToString() + "." +
                ((this.CodigoInterno != null) ? this.CodigoInterno.ToString() : "null") + "." +
                ((this.Nombre != null) ? this.Nombre.ToString() : "null") + "." +
                this.EsReservado.ToString() + "." +
                this.EstaActivo.ToString();
            return textoPlano;

        }

        /// <author>Ernesto Medrano</author>
        /// <creationdate>11-ene-2016</creationdate>
        /// <summary>
        /// Método de Clonar Entidad.
        /// </summary>
        /// <param name="catalogo">Objeto de tipo Catalogo a ser Clonado.</param>
        /// <returns> </returns>
        public Catalogo Clone() {
            return new Catalogo() {
                IdCatalogo = this.IdCatalogo
            ,

                CodigoInterno = this.CodigoInterno
            ,

                Nombre = this.Nombre
            ,

                Descripcion = this.Descripcion
            ,

                EsReservado = this.EsReservado
            ,

                EstaActivo = this.EstaActivo
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
                "<Catalogo>\r\n" +
                "   <IdCatalogo>" + this.IdCatalogo + "</IdCatalogo>\r\n" +
                "   <CodigoInterno>" + (this.CodigoInterno != null ? this.CodigoInterno : "null") + "</CodigoInterno>\r\n" +
                "   <Nombre>" + (this.Nombre != null ? this.Nombre : "null") + "</Nombre>\r\n" +
                "   <Descripcion>" + (this.Descripcion != null ? this.Descripcion : "null") + "</Descripcion>\r\n" +
                "   <EsReservado>" + this.EsReservado + "</EsReservado>\r\n" +
                "   <EstaActivo>" + this.EstaActivo + "</EstaActivo>\r\n" +
                "   <Atributos>\r\n" +
                "      [Atributos]" +
                "   </Atributos>\r\n" +
                "   <Valores>\r\n" +
                "      [Valores]" +
                "   </Valores>\r\n" +
                "</Catalogo>";                       
            //Generar Xml para 'Valores'
            if ( this.Valores != null ) {
                foreach ( Entidades.TablaBasica.Valor valor in this.Valores ) {
                    textoXml = textoXml.Replace("[Valores]", (valor != null ? valor.ToXml() : "null") + "[Valores]");
                }
            } else {
                textoXml = textoXml.Replace("[Valores]", "null\r\n");
            }
            textoXml = textoXml.Replace("[Valores]", "");

            return textoXml;
        }

        #endregion

    }
}
