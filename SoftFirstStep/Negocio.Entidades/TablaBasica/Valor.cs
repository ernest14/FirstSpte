using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Negocio.Entidades.TablaBasica {

    public partial class Valor:IEquatable<Valor> {

        #region Constructores

        /// <author>Mario Gomez</author>
        /// <creationdate>18-abr-2016</creationdate>
        /// <summary>
        /// Constructor Valor que inicializa el campo estaActivo.
        /// </summary>
        /// <returns></returns>
        public Valor()
            : this(true) {
        }

        /// <author>Mario Gomez</author>
        /// <creationdate>18-abr-2016</creationdate>
        /// <summary>
        /// Constructor Valor que recibe el campo estaActivo.
        /// </summary>
        /// <param name="estaActivo">Estado del componente Valor.</param>
        /// <returns></returns>
        public Valor(Boolean estaActivo) {
            this.EstaActivo = estaActivo;            
            this.PersonaNaturales = null;
            this.PersonaNaturales = null;
            this.PersonaNaturales = null;           
            this.Catalogo = null;
        }

        #endregion

        #region Propiedades

        public String NombreTabla {
            get {
                return "Valor";
            }
            set {
            }
        }

        /// <author>Mario Gomez</author>
        /// <creationdate>18-abr-2016</creationdate>
        /// <summary>
        /// Identificador de la tabla Valor.
        /// </summary>
        public Int32 IdValor { get; set; }

        /// <author>Mario Gomez</author>
        /// <creationdate>25-may-2016</creationdate>
        /// <summary>
        /// 
        /// </summary>
        public String CodigoInterno { get; set; }

        /// <author>Mario Gomez</author>
        /// <creationdate>18-abr-2016</creationdate>
        /// <summary>
        /// Correspondiente al Valor del Registro CatalgoValor perteneciente a un Catalogo.
        /// </summary>
        public String ValorCatalogo { get; set; }

        /// <author>Mario Gomez</author>
        /// <creationdate>18-abr-2016</creationdate>
        /// <summary>
        /// Este campo será utilizado para describir los valores que contendrá una tabla determinada, por ejemplo la de género, la del estado civil, etc.
        /// </summary>
        public String Descripcion { get; set; }

        /// <author>Yahaira Martinez</author>
        /// <creationdate>16-nov-2016</creationdate>
        /// <summary>
        /// 
        /// </summary>
        public Int16 Orden { get; set; }

        /// <author>Mario Gomez</author>
        /// <creationdate>18-abr-2016</creationdate>
        /// <summary>
        /// Indica si el registro se encuentra activo o no activo.
        /// </summary>
        public Boolean EstaActivo { get; private set; }

        /// <author>Mario Gomez</author>
        /// <creationdate>18-abr-2016</creationdate>
        /// <summary>
        /// Contendrá el listado de los nombre de entidades de catálogo. El contenido de cada lista estarán ubicadas en la entidad física Valor.
        /// </summary>
        public Entidades.TablaBasica.Catalogo Catalogo { get; set; }

        #endregion

        #region Colecciones

        /// <author>Mario Gomez</author>
        /// <creationdate>18-abr-2016</creationdate>
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

        /// <author>Mario Gomez</author>
        /// <creationdate>18-abr-2016</creationdate>
        /// <summary>
        /// Información General de la una Persona Natural, cual puede ser Nicaragüense o Extranjero temporal o Residente.
        ///         /// 
        ///         /// Un Persona Natural puede ser un Empleado interno (RP), externo ( Catastro Físico, empresas privadas, Instituciones del gobierno), Abogado, Notario, topógrafo, Representante legal, Jueces, otro tipo de Persona válido en el sistema SIICAR.
        ///         /// 
        ///         /// En caso de Registro de Comerciantes o Empresario Individuales, aquí se almacenará la información general,como lo que establece la ley 698 Art.157: Nombres, Apellidos, Edad ( se registrará la fecha de Nacimiento, validando que sea mayor de edad), Estado civil, Domicilio de la Persona, no del Comercio o Negocio, Nacionalidad. El resto de la información correspondiente al Comercio o Negocio se registrará en la entidades del Negocio como tal, esto es caso subsistema Mercantil.
        ///         /// 
        ///         /// En caso de la información de Nacionalidad, esta relacionada con País.
        /// </summary>
        public ICollection<Entidades.Persona.PersonaNatural> PersonaNaturales1 { get; set; }

        /// <author>Mario Gomez</author>
        /// <creationdate>18-abr-2016</creationdate>
        /// <summary>
        /// Información General de la una Persona Natural, cual puede ser Nicaragüense o Extranjero temporal o Residente.
        ///         /// 
        ///         /// Un Persona Natural puede ser un Empleado interno (RP), externo ( Catastro Físico, empresas privadas, Instituciones del gobierno), Abogado, Notario, topógrafo, Representante legal, Jueces, otro tipo de Persona válido en el sistema SIICAR.
        ///         /// 
        ///         /// En caso de Registro de Comerciantes o Empresario Individuales, aquí se almacenará la información general,como lo que establece la ley 698 Art.157: Nombres, Apellidos, Edad ( se registrará la fecha de Nacimiento, validando que sea mayor de edad), Estado civil, Domicilio de la Persona, no del Comercio o Negocio, Nacionalidad. El resto de la información correspondiente al Comercio o Negocio se registrará en la entidades del Negocio como tal, esto es caso subsistema Mercantil.
        ///         /// 
        ///         /// En caso de la información de Nacionalidad, esta relacionada con País.
        /// </summary>
        public ICollection<Entidades.Persona.PersonaNatural> PersonaNaturales2 { get; set; }

        /// <author>Mario Gomez</author>
        /// <creationdate>18-abr-2016</creationdate>
        /// <summary>
        /// Esta tabla registra los diferentes tipos de personas como: naturales, jurídicos, organizaciones e instituciones, grupos de comunidades indígenas, etc.
        /// </summary>
        public ICollection<Entidades.Persona.Persona> Personas { get; set; }

        #endregion

        #region Métodos

        /// <author>Mario Gomez</author>
        /// <creationdate>18-abr-2016</creationdate>
        /// <summary>
        /// Método de comparación de propiedades.
        /// </summary>
        /// <param name="valor">Objeto de tipo Valor a ser comparado.</param>
        /// <returns>True: Si las propiedades son iguales.</returns>
        public Boolean Equals(Valor valor) {
            if ( this.IdValor != valor.IdValor ) {
                return false;
            }
            if ( this.CodigoInterno != valor.CodigoInterno ) {
                return false;
            }
            if ( this.ValorCatalogo != valor.ValorCatalogo ) {
                return false;
            }
            if ( this.Descripcion != valor.Descripcion ) {
                return false;
            }
            if ( this.EstaActivo != valor.EstaActivo ) {
                return false;
            }
            if ( this.Catalogo != null ) {
                if ( this.Catalogo.IdCatalogo != valor.Catalogo.IdCatalogo ) {
                    return false;
                }
            }
            return true;
        }

        /// <author>Mario Gomez</author>
        /// <creationdate>18-abr-2016</creationdate>
        /// <summary>
        /// Retorna un valor que indica si la propiedad solicitada es una colección o no
        /// </summary>
        /// <returns>Boolean - Valor que indica si la propiedad es o no una colección</returns>
        public Boolean EsColeccion(String propiedad) {
            switch ( propiedad.ToLower() ) {
                case "idvalor":
                case "codigointerno":
                case "valorcatalogo":
                case "descripcion":
                case "estaactivo":
                    return false;
                case "idcatalogo":
                case "catalogo":
                    return false;
                case "idtopografos":
                case "topografos":
                case "idtopografoestudioprofesionales":
                case "topografoestudioprofesionales":
                case "idtopografocausalsanciones":
                case "topografocausalsanciones":
                case "idtopografotiposanciones":
                case "topografotiposanciones":
                case "idatributos":
                case "atributos":
                case "idatributos1":
                case "atributos1":
                case "idabogados":
                case "abogados":
                case "idabogadoestados":
                case "abogadoestados":
                case "idabogadosuspendidos":
                case "abogadosuspendidos":
                case "idclasificacionaranceles":
                case "clasificacionaranceles":
                case "idempleadoausencias":
                case "empleadoausencias":
                case "idclasificacionplazotiempos":
                case "clasificacionplazotiempos":
                case "idclasificaciondias":
                case "clasificaciondias":
                case "idgrupos":
                case "grupos":
                case "idrevalidaciones":
                case "revalidaciones":
                case "idpersonas":
                case "personas":
                case "idpersonaidentificaciones":
                case "personaidentificaciones":
                case "idpersonanacionalidades":
                case "personanacionalidades":
                case "idpersonanaturales":
                case "personanaturales":
                case "idpersonanaturales2":
                case "personanaturales2":
                case "idpersonanaturales1":
                case "personanaturales1":
                case "idcargos":
                case "cargos":
                case "idparametrosistemas":
                case "parametrosistemas":
                case "iddianohabiles":
                case "dianohabiles":
                case "idplantillaextendidos":
                case "plantillaextendidos":
                case "idNivelDificultadDocumentos":
                case "nivelDificultadDocumentos":
                case "idNivelPrioridadDocumentos":
                case "nivelPrioridadDocumentos":
                    return true;
                default:
                    return false;

            }
        }

        /// <author>Mario Gomez</author>
        /// <creationdate>18-abr-2016</creationdate>
        /// <summary>
        /// Obtiene el nombre de la tabla de la propiedad solicitada en formato de texto
        /// </summary>
        /// <returns>String - Nombre de la tabla si no se encuentra retorna nulo</returns>
        public String ObtenerNombreTabla(String propiedad) {
            switch ( propiedad.ToLower() ) {
                case "idvalor":
                    return NombreTabla;
                case "codigointerno":
                    return NombreTabla;
                case "valorcatalogo":
                    return NombreTabla;
                case "descripcion":
                    return NombreTabla;
                case "estaactivo":
                    return NombreTabla;
                case "idcatalogo":
                case "catalogo":
                    return new Catalogo().NombreTabla;                
                default:
                    return null;

            }
        }

        /// <author>Mario Gomez</author>
        /// <creationdate>18-abr-2016</creationdate>
        /// <summary>
        /// Obtiene el valor de la propiedad solicitada en formato de texto
        /// </summary>
        /// <returns>String - Valor de la propiedad solicitada, de no existir retorna nulo</returns>
        public List<String> ObtenerPropiedades() {
            List<String> listaPropiedades = new List<String>();
            listaPropiedades.Add("IdValor");
            listaPropiedades.Add("CodigoInterno");
            listaPropiedades.Add("ValorCatalogo");
            listaPropiedades.Add("Descripcion");
            listaPropiedades.Add("EstaActivo");
            listaPropiedades.Add("Catalogo");
            listaPropiedades.Add("Topografos");
            listaPropiedades.Add("TopografoEstudioProfesionales");
            listaPropiedades.Add("TopografoTipoSanciones");
            listaPropiedades.Add("TopografoCausalSanciones");
            listaPropiedades.Add("Atributos");
            listaPropiedades.Add("Atributos1");
            listaPropiedades.Add("Abogados");
            listaPropiedades.Add("AbogadoEstados");
            listaPropiedades.Add("AbogadoSuspendidos");
            listaPropiedades.Add("ClasificacionAranceles");
            listaPropiedades.Add("EmpleadoAusencias");
            listaPropiedades.Add("ClasificacionPlazoTiempos");
            listaPropiedades.Add("ClasificacionDias");
            listaPropiedades.Add("Grupos");
            listaPropiedades.Add("Revalidaciones");
            listaPropiedades.Add("Personas");
            listaPropiedades.Add("PersonaIdentificaciones");
            listaPropiedades.Add("PersonaNacionalidades");
            listaPropiedades.Add("NivelDificultadDocumentos");
            listaPropiedades.Add("NivelPrioridadDocumentos");
            listaPropiedades.Add("PersonaNaturales");
            listaPropiedades.Add("PersonaNaturales1");
            listaPropiedades.Add("PersonaNaturales2");
            listaPropiedades.Add("Cargos");
            listaPropiedades.Add("ParametroSistemas");
            listaPropiedades.Add("DiaNoHabiles");
            listaPropiedades.Add("PlantillaExtendidos");
            return listaPropiedades;
        }

        /// <author>Mario Gomez</author>
        /// <creationdate>18-abr-2016</creationdate>
        /// <summary>
        /// Obtiene el valor de la propiedad solicitada en formato de texto
        /// </summary>
        /// <returns>String - Valor de la propiedad solicitada, de no existir retorna nulo</returns>
        public String ObtenerValor(String propiedad) {
            List<Int32> listadoId = new List<Int32>();

            switch ( propiedad.ToLower() ) {
                case "idvalor":
                    return IdValor.ToString();
                case "codigointerno":
                    return CodigoInterno.ToString();
                case "valorcatalogo":
                    return ValorCatalogo.ToString();
                case "descripcion":
                    return Descripcion.ToString();
                case "estaactivo":
                    return EstaActivo.ToString();
                case "idcatalogo":
                case "catalogo":
                    return Catalogo.IdCatalogo.ToString();                
                default:
                    return null;

            }
        }

        /// <author>Mario Gomez</author>
        /// <creationdate>18-abr-2016</creationdate>
        /// <summary>
        /// Retorna una cadena que representa la clase actual.
        /// </summary>
        /// <returns>Cadena que representa la clase actual</returns>
        public override string ToString() {
            String textoPlano =
                this.IdValor.ToString() + "." +
                   ((this.CodigoInterno != null) ? this.CodigoInterno.ToString() : "null") + "." +
                ((this.ValorCatalogo != null) ? this.ValorCatalogo.ToString() : "null") + "." +
                this.EstaActivo.ToString() + "." +
                ((this.Catalogo != null) ? this.Catalogo.IdCatalogo.ToString() : "null");
            return textoPlano;

        }

        /// <author>Mario Gomez</author>
        /// <creationdate>18-abr-2016</creationdate>
        /// <summary>
        /// Método de Clonar Entidad.
        /// </summary>
        /// <param name="valor">Objeto de tipo Valor a ser Clonado.</param>
        /// <returns> </returns>
        public Valor Clone() {
            return new Valor() {
                IdValor = this.IdValor
                     ,

                CodigoInterno = this.CodigoInterno
            ,

                ValorCatalogo = this.ValorCatalogo
            ,

                Descripcion = this.Descripcion
            ,

                EstaActivo = this.EstaActivo
            ,

                Catalogo = new Entidades.TablaBasica.Catalogo() { IdCatalogo = this.Catalogo.IdCatalogo }
            };
        }

        /// <author>Mario Gomez</author>
        /// <creationdate>18-abr-2016</creationdate>
        /// <summary>
        /// Genera una porción de texto Xml basado en el registro, respetando las normas de esquemas estandarizadas.
        /// </summary>
        /// <returns>Texto con formato Xml de los valores del objeto actual</returns>
        public String ToXml() {
            String textoXml =
                "<Valor>\r\n" +
                "   <IdValor>" + this.IdValor + "</IdValor>\r\n" +
                   "   <CodigoInterno>" + (this.CodigoInterno != null ? this.CodigoInterno : "null") + "</CodigoInterno>\r\n" +
                "   <ValorCatalogo>" + (this.ValorCatalogo != null ? this.ValorCatalogo : "null") + "</ValorCatalogo>\r\n" +
                "   <Descripcion>" + (this.Descripcion != null ? this.Descripcion : "null") + "</Descripcion>\r\n" +
                "   <EstaActivo>" + this.EstaActivo + "</EstaActivo>\r\n" +
                "   <Catalogo>" + (this.Catalogo != null ? this.Catalogo.ToString() : "null") + "</Catalogo>\r\n" +
                "   <Topografos>\r\n" +
                "      [Topografos]" +
                "   </Topografos>\r\n" +
                "   <TopografoEstudioProfesionales>\r\n" +
                "      [TopografoEstudioProfesionales]" +
                "   </TopografoEstudioProfesionales>\r\n" +
                "   <TopografoTipoSanciones>\r\n" +
                "      [TopograTipofoSanciones]" +
                "   </TopografoTipoSanciones>\r\n" +
                "   <TopografoCausalSanciones>\r\n" +
                "      [TopografoCausalSanciones]" +
                "   </TopografoCausalSanciones>\r\n" +
                "   <Atributos>\r\n" +
                "      [Atributos]" +
                "   </Atributos>\r\n" +
                "   <Atributos1>\r\n" +
                "      [Atributos1]" +
                "   </Atributos1>\r\n" +
                "   <NivelDificultadDocumentos>\r\n" +
                "      [NivelDificultadDocumentos]" +
                "   </NivelDificultadDocumentos>\r\n" +
                "   <NivelPrioridadDocumentos>\r\n" +
                "      [NivelPrioridadDocumentos]" +
                "   </NivelPrioridadDocumentos>\r\n" +
                "   <Abogados>\r\n" +
                "      [Abogados]" +
                "   </Abogados>\r\n" +
                "   <AbogadoEstados>\r\n" +
                "      [AbogadoEstados]" +
                "   </AbogadoEstados>\r\n" +
                "   <AbogadoSuspendidos>\r\n" +
                "      [AbogadoSuspendidos]" +
                "   </AbogadoSuspendidos>\r\n" +
                "   <ClasificacionAranceles>\r\n" +
                "      [ClasificacionAranceles]" +
                "   </ClasificacionAranceles>\r\n" +
                "   <EmpleadoAusencias>\r\n" +
                "      [EmpleadoAusencias]" +
                "   </EmpleadoAusencias>\r\n" +
                "   <ClasificacionPlazoTiempos>\r\n" +
                "      [ClasificacionPlazoTiempos]" +
                "   </ClasificacionPlazoTiempos>\r\n" +
                "   <ClasificacionDias>\r\n" +
                "      [ClasificacionDias]" +
                "   </ClasificacionDias>\r\n" +
                "   <Grupos>\r\n" +
                "      [Grupos]" +
                "   </Grupos>\r\n" +
                "   <Revalidaciones>\r\n" +
                "      [Revalidaciones]" +
                "   </Revalidaciones>\r\n" +
                "   <Personas>\r\n" +
                "      [Personas]" +
                "   </Personas>\r\n" +
                "   <PersonaIdentificaciones>\r\n" +
                "      [PersonaIdentificaciones]" +
                "   </PersonaIdentificaciones>\r\n" +
                "   <PersonaNacionalidades>\r\n" +
                "      [PersonaNacionalidades]" +
                "   </PersonaNacionalidades>\r\n" +
                "   <PersonaNaturales>\r\n" +
                "      [PersonaNaturales]" +
                "   </PersonaNaturales>\r\n" +
                "   <PersonaNaturales1>\r\n" +
                "      [PersonaNaturales1]" +
                "   </PersonaNaturales1>\r\n" +
                "   <PersonaNaturales2>\r\n" +
                "      [PersonaNaturales2]" +
                "   </PersonaNaturales2>\r\n" +
                "   <Cargos>\r\n" +
                "      [Cargos]" +
                "   </Cargos>\r\n" +
                "   <ParametroSistemas>\r\n" +
                "      [ParametroSistemas]" +
                "   </ParametroSistemas>\r\n" +
                "   <DiaNoHabiles>\r\n" +
                "      [DiaNoHabiles]" +
                "   </DiaNoHabiles>\r\n" +
                "   <PlantillaExtendidos>\r\n" +
                "      [PlantillaExtendidos]" +
                "   </PlantillaExtendidos>\r\n" +
                "</Valor>";

            //Generar Xml para 'PersonaNaturales'
            if ( this.PersonaNaturales != null ) {
                foreach ( Entidades.Persona.PersonaNatural personaNatural in this.PersonaNaturales ) {
                    textoXml = textoXml.Replace("[PersonaNaturales]", (personaNatural != null ? personaNatural.ToString() : "null") + "[PersonaNaturales]");
                }
            } else {
                textoXml = textoXml.Replace("[PersonaNaturales]", "null\r\n");
            }
            textoXml = textoXml.Replace("[PersonaNaturales]", "");

            //Generar Xml para 'PersonaNaturales'
            if ( this.PersonaNaturales != null ) {
                foreach ( Entidades.Persona.PersonaNatural personaNatural in this.PersonaNaturales ) {
                    textoXml = textoXml.Replace("[PersonaNaturales1]", (personaNatural != null ? personaNatural.ToString() : "null") + "[PersonaNaturales]");
                }
            } else {
                textoXml = textoXml.Replace("[PersonaNaturales1]", "null\r\n");
            }
            textoXml = textoXml.Replace("[PersonaNaturales1]", "");

            //Generar Xml para 'PersonaNaturales'
            if ( this.PersonaNaturales != null ) {
                foreach ( Entidades.Persona.PersonaNatural personaNatural in this.PersonaNaturales ) {
                    textoXml = textoXml.Replace("[PersonaNaturales2]", (personaNatural != null ? personaNatural.ToString() : "null") + "[PersonaNaturales]");
                }
            } else {
                textoXml = textoXml.Replace("[PersonaNaturales2]", "null\r\n");
            }
            textoXml = textoXml.Replace("[PersonaNaturales2]", "");
            return textoXml;
        }

        #endregion

    }
}
