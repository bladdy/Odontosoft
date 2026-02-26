using Microsoft.EntityFrameworkCore;
using Odontosoft.Shared.Entities;

namespace Odontosoft.Backend.Data
{
    public class DatabaseSeeder
    {
        public static void SeedDatabase(DataContext context)
        {
            // Aplicar migraciones pendientes
            context.Database.Migrate();

            // Seed Módulos del sistema
            if (!context.Modulos.Any())
            {
                SeedModulos(context);
            }

            // Seed Especialidades médicas
            if (!context.Especialidades.Any())
            {
                SeedEspecialidades(context);
            }

            // Seed Medicamentos comunes
            if (!context.Medicamentos.Any())
            {
                SeedMedicamentos(context);
            }

            // Seed Estudios de Laboratorio
            if (!context.EstudiosLaboratorio.Any())
            {
                SeedEstudiosLaboratorio(context);
            }

            // Seed Estudios de Imagen
            if (!context.EstudiosImagen.Any())
            {
                SeedEstudiosImagen(context);
            }

            // Seed Servicios comunes
            if (!context.Servicios.Any())
            {
                SeedServicios(context);
            }

            // Seed Roles predeterminados
            if (!context.Roles.Any())
            {
                SeedRoles(context);
            }

            // Seed Módulos de Odontología
            if (!context.Modulos.Any(m => m.Codigo == "ODONTOGRAMA"))
            {
                SeedModulosOdontologia(context);
            }

            // Seed Catálogo de Tratamientos Dentales
            if (!context.CatalogoTratamientosDentales.Any())
            {
                SeedCatalogoTratamientos(context);
            }

            // Seed Materiales Dentales
            if (!context.MaterialesDentales.Any())
            {
                SeedMaterialesDentales(context);
            }

            context.SaveChanges();
        }

        private static void SeedMaterialesDentales(DataContext context)
        {
            var materiales = new List<MaterialDental>
            {
                // Anestésicos
                new MaterialDental { Nombre = "Lidocaína 2% con Epinefrina", Codigo = "ANES001", Categoria = "Anestésicos", Marca = "Septodont", UnidadMedida = "Cartucho", PrecioUnitario = 15.00m, StockMinimo = 100, Activo = true },
                new MaterialDental { Nombre = "Articaína 4%", Codigo = "ANES002", Categoria = "Anestésicos", Marca = "Septodont", UnidadMedida = "Cartucho", PrecioUnitario = 18.00m, StockMinimo = 50, Activo = true },

                // Resinas
                new MaterialDental { Nombre = "Resina Compuesta Universal A2", Codigo = "RESIN001", Categoria = "Resinas", Marca = "3M", UnidadMedida = "Jeringa", PrecioUnitario = 350.00m, StockMinimo = 10, Activo = true },
                new MaterialDental { Nombre = "Resina Compuesta Universal A3", Codigo = "RESIN002", Categoria = "Resinas", Marca = "3M", UnidadMedida = "Jeringa", PrecioUnitario = 350.00m, StockMinimo = 10, Activo = true },
                new MaterialDental { Nombre = "Adhesivo Dental Universal", Codigo = "ADHES001", Categoria = "Resinas", Marca = "3M", UnidadMedida = "Frasco", PrecioUnitario = 450.00m, StockMinimo = 5, Activo = true },
                new MaterialDental { Nombre = "Ácido Grabador 37%", Codigo = "ACID001", Categoria = "Resinas", Marca = "Ultradent", UnidadMedida = "Jeringa", PrecioUnitario = 120.00m, StockMinimo = 10, Activo = true },

                // Cementos
                new MaterialDental { Nombre = "Cemento de Ionómero de Vidrio", Codigo = "CEM001", Categoria = "Cementos", Marca = "GC", UnidadMedida = "Frasco", PrecioUnitario = 280.00m, StockMinimo = 5, Activo = true },
                new MaterialDental { Nombre = "Cemento de Fosfato de Zinc", Codigo = "CEM002", Categoria = "Cementos", Marca = "Harvard", UnidadMedida = "Set", PrecioUnitario = 180.00m, StockMinimo = 5, Activo = true },
                new MaterialDental { Nombre = "Cemento Temporal", Codigo = "CEM003", Categoria = "Cementos", Marca = "Kerr", UnidadMedida = "Tubo", PrecioUnitario = 95.00m, StockMinimo = 10, Activo = true },

                // Endodoncia
                new MaterialDental { Nombre = "Limas K-File #15-40", Codigo = "ENDO001", Categoria = "Endodoncia", Marca = "Dentsply", UnidadMedida = "Caja", PrecioUnitario = 450.00m, StockMinimo = 3, Activo = true },
                new MaterialDental { Nombre = "Gutapercha Puntas", Codigo = "ENDO002", Categoria = "Endodoncia", Marca = "Dentsply", UnidadMedida = "Caja", PrecioUnitario = 250.00m, StockMinimo = 5, Activo = true },
                new MaterialDental { Nombre = "Sellador Endodóntico", Codigo = "ENDO003", Categoria = "Endodoncia", Marca = "Kerr", UnidadMedida = "Frasco", PrecioUnitario = 320.00m, StockMinimo = 3, Activo = true },
                new MaterialDental { Nombre = "Hipoclorito de Sodio 5.25%", Codigo = "ENDO004", Categoria = "Endodoncia", Marca = "Clorox", UnidadMedida = "Litro", PrecioUnitario = 80.00m, StockMinimo = 10, Activo = true },

                // Materiales de Impresión
                new MaterialDental { Nombre = "Alginato", Codigo = "IMP001", Categoria = "Materiales de Impresión", Marca = "Cavex", UnidadMedida = "Bolsa 450g", PrecioUnitario = 180.00m, StockMinimo = 10, Activo = true },
                new MaterialDental { Nombre = "Silicona de Adición", Codigo = "IMP002", Categoria = "Materiales de Impresión", Marca = "3M", UnidadMedida = "Set", PrecioUnitario = 850.00m, StockMinimo = 3, Activo = true },

                // Materiales de sutura
                new MaterialDental { Nombre = "Sutura Seda 3-0", Codigo = "SUT001", Categoria = "Suturas", Marca = "Ethicon", UnidadMedida = "Pieza", PrecioUnitario = 35.00m, StockMinimo = 20, Activo = true },
                new MaterialDental { Nombre = "Sutura Nylon 4-0", Codigo = "SUT002", Categoria = "Suturas", Marca = "Ethicon", UnidadMedida = "Pieza", PrecioUnitario = 38.00m, StockMinimo = 20, Activo = true },

                // Desinfección
                new MaterialDental { Nombre = "Glutaraldehído 2%", Codigo = "DES001", Categoria = "Desinfección", Marca = "Cidex", UnidadMedida = "Litro", PrecioUnitario = 350.00m, StockMinimo = 5, Activo = true },
                new MaterialDental { Nombre = "Alcohol Isopropílico 70%", Codigo = "DES002", Categoria = "Desinfección", Marca = "Generic", UnidadMedida = "Litro", PrecioUnitario = 45.00m, StockMinimo = 20, Activo = true },

                // Consumibles
                new MaterialDental { Nombre = "Guantes de Nitrilo (caja 100)", Codigo = "CONS001", Categoria = "Consumibles", Marca = "Kimberly Clark", UnidadMedida = "Caja", PrecioUnitario = 180.00m, StockMinimo = 10, Activo = true },
                new MaterialDental { Nombre = "Cubrebocas (caja 50)", Codigo = "CONS002", Categoria = "Consumibles", Marca = "3M", UnidadMedida = "Caja", PrecioUnitario = 120.00m, StockMinimo = 10, Activo = true },
                new MaterialDental { Nombre = "Babero Dental (paquete 500)", Codigo = "CONS003", Categoria = "Consumibles", Marca = "Generic", UnidadMedida = "Paquete", PrecioUnitario = 250.00m, StockMinimo = 5, Activo = true },
                new MaterialDental { Nombre = "Rollos de Algodón", Codigo = "CONS004", Categoria = "Consumibles", Marca = "Generic", UnidadMedida = "Bolsa", PrecioUnitario = 45.00m, StockMinimo = 20, Activo = true },
                new MaterialDental { Nombre = "Gasas Estériles (paquete 100)", Codigo = "CONS005", Categoria = "Consumibles", Marca = "Generic", UnidadMedida = "Paquete", PrecioUnitario = 85.00m, StockMinimo = 10, Activo = true }
            };

            context.MaterialesDentales.AddRange(materiales);
        }

        private static void SeedCatalogoTratamientos(DataContext context)
        {
            var tratamientos = new List<CatalogoTratamientoDental>
            {
                // ODONTOLOGÍA PREVENTIVA
                new CatalogoTratamientoDental
                {
                    Nombre = "Limpieza Dental (Profilaxis)",
                    Codigo = "PROF001",
                    Categoria = "Preventiva",
                    Descripcion = "Limpieza profesional de dientes y encías",
                    PrecioBase = 500.00m,
                    DuracionEstimadaMinutos = 30,
                    RequiereConsentimiento = false,
                    Activo = true
                },
                new CatalogoTratamientoDental
                {
                    Nombre = "Aplicación de Flúor",
                    Codigo = "PREV001",
                    Categoria = "Preventiva",
                    Descripcion = "Aplicación tópica de flúor para fortalecer el esmalte",
                    PrecioBase = 300.00m,
                    DuracionEstimadaMinutos = 15,
                    RequiereConsentimiento = false,
                    Activo = true
                },
                new CatalogoTratamientoDental
                {
                    Nombre = "Selladores de Fosetas y Fisuras",
                    Codigo = "PREV002",
                    Categoria = "Preventiva",
                    Descripcion = "Sellado de superficies dentales para prevenir caries",
                    PrecioBase = 400.00m,
                    DuracionEstimadaMinutos = 20,
                    RequiereConsentimiento = false,
                    Activo = true
                },

                // ODONTOLOGÍA OPERATORIA (RESTAURACIONES)
                new CatalogoTratamientoDental
                {
                    Nombre = "Obturación con Resina (1 superficie)",
                    Codigo = "REST001",
                    Categoria = "Operatoria",
                    Descripcion = "Restauración de caries con resina compuesta",
                    PrecioBase = 600.00m,
                    DuracionEstimadaMinutos = 45,
                    MaterialesNecesarios = "Resina compuesta, adhesivo, ácido grabador",
                    RequiereConsentimiento = false,
                    Activo = true
                },
                new CatalogoTratamientoDental
                {
                    Nombre = "Obturación con Resina (2 superficies)",
                    Codigo = "REST002",
                    Categoria = "Operatoria",
                    Descripcion = "Restauración de caries en dos superficies",
                    PrecioBase = 800.00m,
                    DuracionEstimadaMinutos = 60,
                    MaterialesNecesarios = "Resina compuesta, adhesivo, ácido grabador",
                    RequiereConsentimiento = false,
                    Activo = true
                },
                new CatalogoTratamientoDental
                {
                    Nombre = "Obturación con Amalgama",
                    Codigo = "REST003",
                    Categoria = "Operatoria",
                    Descripcion = "Restauración con amalgama de plata",
                    PrecioBase = 550.00m,
                    DuracionEstimadaMinutos = 45,
                    MaterialesNecesarios = "Amalgama, barniz, matriz",
                    RequiereConsentimiento = false,
                    Activo = true
                },
                new CatalogoTratamientoDental
                {
                    Nombre = "Incrustación (Inlay/Onlay)",
                    Codigo = "REST004",
                    Categoria = "Operatoria",
                    Descripcion = "Restauración indirecta de porcelana o resina",
                    PrecioBase = 3500.00m,
                    DuracionEstimadaMinutos = 90,
                    RequiereConsentimiento = false,
                    Activo = true
                },

                // ENDODONCIA
                new CatalogoTratamientoDental
                {
                    Nombre = "Endodoncia Unirradicular",
                    Codigo = "ENDO001",
                    Categoria = "Endodoncia",
                    Descripcion = "Tratamiento de conducto en diente con una raíz",
                    PrecioBase = 2500.00m,
                    DuracionEstimadaMinutos = 90,
                    MaterialesNecesarios = "Limas, gutapercha, sellador endodóntico",
                    RequiereConsentimiento = true,
                    Activo = true
                },
                new CatalogoTratamientoDental
                {
                    Nombre = "Endodoncia Birradicular",
                    Codigo = "ENDO002",
                    Categoria = "Endodoncia",
                    Descripcion = "Tratamiento de conducto en diente con dos raíces",
                    PrecioBase = 3500.00m,
                    DuracionEstimadaMinutos = 120,
                    MaterialesNecesarios = "Limas, gutapercha, sellador endodóntico",
                    RequiereConsentimiento = true,
                    Activo = true
                },
                new CatalogoTratamientoDental
                {
                    Nombre = "Endodoncia Multirradicular",
                    Codigo = "ENDO003",
                    Categoria = "Endodoncia",
                    Descripcion = "Tratamiento de conducto en molares",
                    PrecioBase = 4500.00m,
                    DuracionEstimadaMinutos = 150,
                    MaterialesNecesarios = "Limas, gutapercha, sellador endodóntico",
                    RequiereConsentimiento = true,
                    Activo = true
                },

                // PERIODONCIA
                new CatalogoTratamientoDental
                {
                    Nombre = "Raspado y Alisado Radicular (por cuadrante)",
                    Codigo = "PERIO001",
                    Categoria = "Periodoncia",
                    Descripcion = "Limpieza profunda subgingival",
                    PrecioBase = 800.00m,
                    DuracionEstimadaMinutos = 60,
                    RequiereConsentimiento = false,
                    Activo = true
                },
                new CatalogoTratamientoDental
                {
                    Nombre = "Cirugía Periodontal",
                    Codigo = "PERIO002",
                    Categoria = "Periodoncia",
                    Descripcion = "Cirugía de encías y tejido periodontal",
                    PrecioBase = 5000.00m,
                    DuracionEstimadaMinutos = 120,
                    RequiereConsentimiento = true,
                    Activo = true
                },
                new CatalogoTratamientoDental
                {
                    Nombre = "Injerto de Encía",
                    Codigo = "PERIO003",
                    Categoria = "Periodoncia",
                    Descripcion = "Injerto de tejido blando gingival",
                    PrecioBase = 8000.00m,
                    DuracionEstimadaMinutos = 90,
                    RequiereConsentimiento = true,
                    Activo = true
                },

                // CIRUGÍA ORAL
                new CatalogoTratamientoDental
                {
                    Nombre = "Extracción Simple",
                    Codigo = "CIRUG001",
                    Categoria = "Cirugía",
                    Descripcion = "Extracción dental simple",
                    PrecioBase = 800.00m,
                    DuracionEstimadaMinutos = 30,
                    RequiereConsentimiento = true,
                    Activo = true
                },
                new CatalogoTratamientoDental
                {
                    Nombre = "Extracción Compleja",
                    Codigo = "CIRUG002",
                    Categoria = "Cirugía",
                    Descripcion = "Extracción quirúrgica con odontosección",
                    PrecioBase = 1500.00m,
                    DuracionEstimadaMinutos = 60,
                    RequiereConsentimiento = true,
                    Activo = true
                },
                new CatalogoTratamientoDental
                {
                    Nombre = "Extracción de Cordal Incluido",
                    Codigo = "CIRUG003",
                    Categoria = "Cirugía",
                    Descripcion = "Extracción de muela del juicio retenida",
                    PrecioBase = 3000.00m,
                    DuracionEstimadaMinutos = 90,
                    MaterialesNecesarios = "Sutura, bisturí, fórceps quirúrgicos",
                    RequiereConsentimiento = true,
                    Activo = true
                },

                // PRÓTESIS
                new CatalogoTratamientoDental
                {
                    Nombre = "Corona de Porcelana",
                    Codigo = "PROT001",
                    Categoria = "Prótesis",
                    Descripcion = "Corona de cerámica sobre metal",
                    PrecioBase = 4500.00m,
                    DuracionEstimadaMinutos = 120,
                    RequiereConsentimiento = false,
                    Activo = true
                },
                new CatalogoTratamientoDental
                {
                    Nombre = "Corona de Zirconia",
                    Codigo = "PROT002",
                    Categoria = "Prótesis",
                    Descripcion = "Corona de zirconia libre de metal",
                    PrecioBase = 6000.00m,
                    DuracionEstimadaMinutos = 120,
                    RequiereConsentimiento = false,
                    Activo = true
                },
                new CatalogoTratamientoDental
                {
                    Nombre = "Puente Fijo (3 unidades)",
                    Codigo = "PROT003",
                    Categoria = "Prótesis",
                    Descripcion = "Puente fijo de porcelana",
                    PrecioBase = 12000.00m,
                    DuracionEstimadaMinutos = 180,
                    RequiereConsentimiento = false,
                    Activo = true
                },
                new CatalogoTratamientoDental
                {
                    Nombre = "Prótesis Total (superior o inferior)",
                    Codigo = "PROT004",
                    Categoria = "Prótesis",
                    Descripcion = "Dentadura completa removible",
                    PrecioBase = 8000.00m,
                    DuracionEstimadaMinutos = 240,
                    RequiereConsentimiento = false,
                    Activo = true
                },
                new CatalogoTratamientoDental
                {
                    Nombre = "Prótesis Parcial Removible",
                    Codigo = "PROT005",
                    Categoria = "Prótesis",
                    Descripcion = "Prótesis removible con ganchos",
                    PrecioBase = 5500.00m,
                    DuracionEstimadaMinutos = 180,
                    RequiereConsentimiento = false,
                    Activo = true
                },

                // IMPLANTOLOGÍA
                new CatalogoTratamientoDental
                {
                    Nombre = "Implante Dental",
                    Codigo = "IMPL001",
                    Categoria = "Cirugía",
                    Descripcion = "Colocación de implante oseointegrado",
                    PrecioBase = 15000.00m,
                    DuracionEstimadaMinutos = 90,
                    MaterialesNecesarios = "Implante, pilar, sutura",
                    RequiereConsentimiento = true,
                    Activo = true
                },
                new CatalogoTratamientoDental
                {
                    Nombre = "Corona sobre Implante",
                    Codigo = "IMPL002",
                    Categoria = "Prótesis",
                    Descripcion = "Corona de porcelana sobre implante",
                    PrecioBase = 8000.00m,
                    DuracionEstimadaMinutos = 60,
                    RequiereConsentimiento = false,
                    Activo = true
                },

                // ORTODONCIA
                new CatalogoTratamientoDental
                {
                    Nombre = "Ortodoncia con Brackets Metálicos",
                    Codigo = "ORTO001",
                    Categoria = "Ortodoncia",
                    Descripcion = "Tratamiento completo con brackets metálicos",
                    PrecioBase = 25000.00m,
                    DuracionEstimadaMinutos = 120,
                    RequiereConsentimiento = true,
                    Activo = true
                },
                new CatalogoTratamientoDental
                {
                    Nombre = "Ortodoncia con Brackets Estéticos",
                    Codigo = "ORTO002",
                    Categoria = "Ortodoncia",
                    Descripcion = "Tratamiento con brackets de cerámica",
                    PrecioBase = 35000.00m,
                    DuracionEstimadaMinutos = 120,
                    RequiereConsentimiento = true,
                    Activo = true
                },
                new CatalogoTratamientoDental
                {
                    Nombre = "Alineadores Transparentes (tratamiento completo)",
                    Codigo = "ORTO003",
                    Categoria = "Ortodoncia",
                    Descripcion = "Ortodoncia invisible con alineadores",
                    PrecioBase = 45000.00m,
                    DuracionEstimadaMinutos = 90,
                    RequiereConsentimiento = true,
                    Activo = true
                },

                // ESTÉTICA DENTAL
                new CatalogoTratamientoDental
                {
                    Nombre = "Blanqueamiento Dental",
                    Codigo = "EST001",
                    Categoria = "Estética",
                    Descripcion = "Blanqueamiento dental en consultorio",
                    PrecioBase = 3500.00m,
                    DuracionEstimadaMinutos = 90,
                    RequiereConsentimiento = false,
                    Activo = true
                },
                new CatalogoTratamientoDental
                {
                    Nombre = "Carilla de Porcelana",
                    Codigo = "EST002",
                    Categoria = "Estética",
                    Descripcion = "Carilla estética de cerámica",
                    PrecioBase = 5500.00m,
                    DuracionEstimadaMinutos = 90,
                    RequiereConsentimiento = false,
                    Activo = true
                },
                new CatalogoTratamientoDental
                {
                    Nombre = "Carilla de Resina",
                    Codigo = "EST003",
                    Categoria = "Estética",
                    Descripcion = "Carilla estética de resina compuesta",
                    PrecioBase = 2500.00m,
                    DuracionEstimadaMinutos = 60,
                    RequiereConsentimiento = false,
                    Activo = true
                }
            };

            context.CatalogoTratamientosDentales.AddRange(tratamientos);
        }

        private static void SeedModulosOdontologia(DataContext context)
        {
            var moduloPrincipalId = context.Modulos.First(m => m.Codigo == "CONSULTAS").Id;

            var modulosOdontologia = new List<Modulo>
            {
                // Módulos principales de odontología
                new Modulo
                {
                    Nombre = "Odontograma",
                    Codigo = "ODONTOGRAMA",
                    Descripcion = "Registro visual del estado dental del paciente",
                    Icono = "teeth",
                    Orden = 16,
                    Ruta = "/odontograma",
                    Activo = true
                },
                new Modulo
                {
                    Nombre = "Tratamientos Dentales",
                    Codigo = "TRATAMIENTOS_DENTALES",
                    Descripcion = "Gestión de tratamientos dentales específicos",
                    Icono = "medical_services",
                    Orden = 17,
                    Ruta = "/tratamientos-dentales",
                    Activo = true
                },
                new Modulo
                {
                    Nombre = "Presupuestos Dentales",
                    Codigo = "PRESUPUESTOS_DENTALES",
                    Descripcion = "Planes de tratamiento y presupuestos",
                    Icono = "description",
                    Orden = 18,
                    Ruta = "/presupuestos-dentales",
                    Activo = true
                },
                new Modulo
                {
                    Nombre = "Radiografías",
                    Codigo = "RADIOGRAFIAS",
                    Descripcion = "Gestión de radiografías dentales",
                    Icono = "radiology",
                    Orden = 19,
                    Ruta = "/radiografias",
                    Activo = true
                },
                new Modulo
                {
                    Nombre = "Periodoncia",
                    Codigo = "PERIODONCIA",
                    Descripcion = "Exámenes periodontales y bolsas",
                    Icono = "healing",
                    Orden = 20,
                    Ruta = "/periodoncia",
                    Activo = true
                },
                new Modulo
                {
                    Nombre = "Ortodoncia",
                    Codigo = "ORTODONCIA",
                    Descripcion = "Tratamientos y controles de ortodoncia",
                    Icono = "straighten",
                    Orden = 21,
                    Ruta = "/ortodoncia",
                    Activo = true
                },
                new Modulo
                {
                    Nombre = "Consentimientos",
                    Codigo = "CONSENTIMIENTOS",
                    Descripcion = "Consentimientos informados digitales",
                    Icono = "fact_check",
                    Orden = 22,
                    Ruta = "/consentimientos",
                    Activo = true
                }
            };

            context.Modulos.AddRange(modulosOdontologia);
            context.SaveChanges();
        }

        private static void SeedModulos(DataContext context)
        {
            var modulos = new List<Modulo>
            {
                // Módulos principales
                new Modulo { Nombre = "Dashboard", Codigo = "DASHBOARD", Descripcion = "Panel principal con estadísticas", Icono = "dashboard", Orden = 1, Ruta = "/dashboard" },
                new Modulo { Nombre = "Pacientes", Codigo = "PACIENTES", Descripcion = "Gestión de pacientes", Icono = "people", Orden = 2, Ruta = "/pacientes" },
                new Modulo { Nombre = "Citas", Codigo = "CITAS", Descripcion = "Agenda de citas médicas", Icono = "calendar", Orden = 3, Ruta = "/citas" },
                new Modulo { Nombre = "Consultas", Codigo = "CONSULTAS", Descripcion = "Registro de consultas médicas", Icono = "medical_services", Orden = 4, Ruta = "/consultas" },
                new Modulo { Nombre = "Historia Clínica", Codigo = "HISTORIA_CLINICA", Descripcion = "Expediente clínico de pacientes", Icono = "folder_shared", Orden = 5, Ruta = "/historia-clinica" },
                new Modulo { Nombre = "Recetas", Codigo = "RECETAS", Descripcion = "Emisión de recetas médicas", Icono = "receipt", Orden = 6, Ruta = "/recetas" },
                new Modulo { Nombre = "Laboratorio", Codigo = "LABORATORIO", Descripcion = "Órdenes y resultados de laboratorio", Icono = "biotech", Orden = 7, Ruta = "/laboratorio" },
                new Modulo { Nombre = "Imagenología", Codigo = "IMAGENOLOGIA", Descripcion = "Órdenes y resultados de estudios de imagen", Icono = "radiology", Orden = 8, Ruta = "/imagenologia" },
                new Modulo { Nombre = "Facturación", Codigo = "FACTURACION", Descripcion = "Facturación electrónica (CFDI)", Icono = "receipt_long", Orden = 9, Ruta = "/facturacion" },
                new Modulo { Nombre = "Inventario", Codigo = "INVENTARIO", Descripcion = "Control de inventario y productos", Icono = "inventory", Orden = 10, Ruta = "/inventario" },
                new Modulo { Nombre = "Médicos", Codigo = "MEDICOS", Descripcion = "Gestión de médicos y especialidades", Icono = "medical_information", Orden = 11, Ruta = "/medicos" },
                new Modulo { Nombre = "Usuarios", Codigo = "USUARIOS", Descripcion = "Gestión de usuarios del sistema", Icono = "manage_accounts", Orden = 12, Ruta = "/usuarios" },
                new Modulo { Nombre = "Configuración", Codigo = "CONFIGURACION", Descripcion = "Configuración general del sistema", Icono = "settings", Orden = 13, Ruta = "/configuracion" },
                new Modulo { Nombre = "Reportes", Codigo = "REPORTES", Descripcion = "Generación de reportes y estadísticas", Icono = "assessment", Orden = 14, Ruta = "/reportes" },
                new Modulo { Nombre = "Auditoría", Codigo = "AUDITORIA", Descripcion = "Registros de auditoría del sistema", Icono = "history", Orden = 15, Ruta = "/auditoria" },
            };

            context.Modulos.AddRange(modulos);
            context.SaveChanges();

            // Submódulos de Pacientes
            var moduloPacientes = context.Modulos.First(m => m.Codigo == "PACIENTES");
            var submodulosPacientes = new List<Modulo>
            {
                new Modulo { Nombre = "Registro de Pacientes", Codigo = "PACIENTES_REGISTRO", ModuloPadreId = moduloPacientes.Id, Icono = "person_add", Orden = 1, Ruta = "/pacientes/registro" },
                new Modulo { Nombre = "Lista de Pacientes", Codigo = "PACIENTES_LISTA", ModuloPadreId = moduloPacientes.Id, Icono = "list", Orden = 2, Ruta = "/pacientes/lista" },
                new Modulo { Nombre = "Alergias", Codigo = "PACIENTES_ALERGIAS", ModuloPadreId = moduloPacientes.Id, Icono = "warning", Orden = 3, Ruta = "/pacientes/alergias" },
                new Modulo { Nombre = "Antecedentes", Codigo = "PACIENTES_ANTECEDENTES", ModuloPadreId = moduloPacientes.Id, Icono = "history_edu", Orden = 4, Ruta = "/pacientes/antecedentes" },
            };

            // Submódulos de Configuración
            var moduloConfiguracion = context.Modulos.First(m => m.Codigo == "CONFIGURACION");
            var submodulosConfiguracion = new List<Modulo>
            {
                new Modulo { Nombre = "Clínicas", Codigo = "CONFIG_CLINICAS", ModuloPadreId = moduloConfiguracion.Id, Icono = "business", Orden = 1, Ruta = "/configuracion/clinicas" },
                new Modulo { Nombre = "Sucursales", Codigo = "CONFIG_SUCURSALES", ModuloPadreId = moduloConfiguracion.Id, Icono = "store", Orden = 2, Ruta = "/configuracion/sucursales" },
                new Modulo { Nombre = "Consultorios", Codigo = "CONFIG_CONSULTORIOS", ModuloPadreId = moduloConfiguracion.Id, Icono = "meeting_room", Orden = 3, Ruta = "/configuracion/consultorios" },
                new Modulo { Nombre = "Módulos", Codigo = "CONFIG_MODULOS", ModuloPadreId = moduloConfiguracion.Id, Icono = "extension", Orden = 4, Ruta = "/configuracion/modulos" },
                new Modulo { Nombre = "Roles y Permisos", Codigo = "CONFIG_ROLES", ModuloPadreId = moduloConfiguracion.Id, Icono = "admin_panel_settings", Orden = 5, Ruta = "/configuracion/roles" },
            };

            // Submódulos de Reportes
            var moduloReportes = context.Modulos.First(m => m.Codigo == "REPORTES");
            var submodulosReportes = new List<Modulo>
            {
                new Modulo { Nombre = "Reporte de Citas", Codigo = "REPORTES_CITAS", ModuloPadreId = moduloReportes.Id, Icono = "event_note", Orden = 1, Ruta = "/reportes/citas" },
                new Modulo { Nombre = "Reporte de Consultas", Codigo = "REPORTES_CONSULTAS", ModuloPadreId = moduloReportes.Id, Icono = "medical_services", Orden = 2, Ruta = "/reportes/consultas" },
                new Modulo { Nombre = "Reporte Financiero", Codigo = "REPORTES_FINANCIERO", ModuloPadreId = moduloReportes.Id, Icono = "attach_money", Orden = 3, Ruta = "/reportes/financiero" },
                new Modulo { Nombre = "Reporte de Inventario", Codigo = "REPORTES_INVENTARIO", ModuloPadreId = moduloReportes.Id, Icono = "inventory_2", Orden = 4, Ruta = "/reportes/inventario" },
            };

            context.Modulos.AddRange(submodulosPacientes);
            context.Modulos.AddRange(submodulosConfiguracion);
            context.Modulos.AddRange(submodulosReportes);
            context.SaveChanges();
        }

        private static void SeedEspecialidades(DataContext context)
        {
            var especialidades = new List<Especialidad>
            {
                new Especialidad { Nombre = "Medicina General", Descripcion = "Atención médica general" },
                new Especialidad { Nombre = "Pediatría", Descripcion = "Atención médica infantil" },
                new Especialidad { Nombre = "Ginecología", Descripcion = "Salud femenina y reproductiva" },
                new Especialidad { Nombre = "Obstetricia", Descripcion = "Atención del embarazo y parto" },
                new Especialidad { Nombre = "Cardiología", Descripcion = "Enfermedades del corazón" },
                new Especialidad { Nombre = "Dermatología", Descripcion = "Enfermedades de la piel" },
                new Especialidad { Nombre = "Oftalmología", Descripcion = "Enfermedades de los ojos" },
                new Especialidad { Nombre = "Otorrinolaringología", Descripcion = "Oídos, nariz y garganta" },
                new Especialidad { Nombre = "Traumatología", Descripcion = "Lesiones y fracturas" },
                new Especialidad { Nombre = "Ortopedia", Descripcion = "Sistema musculoesquelético" },
                new Especialidad { Nombre = "Neurología", Descripcion = "Sistema nervioso" },
                new Especialidad { Nombre = "Psiquiatría", Descripcion = "Salud mental" },
                new Especialidad { Nombre = "Urología", Descripcion = "Sistema urinario" },
                new Especialidad { Nombre = "Gastroenterología", Descripcion = "Sistema digestivo" },
                new Especialidad { Nombre = "Endocrinología", Descripcion = "Glándulas y hormonas" },
                new Especialidad { Nombre = "Neumología", Descripcion = "Sistema respiratorio" },
                new Especialidad { Nombre = "Oncología", Descripcion = "Tratamiento del cáncer" },
                new Especialidad { Nombre = "Cirugía General", Descripcion = "Procedimientos quirúrgicos" },
                new Especialidad { Nombre = "Anestesiología", Descripcion = "Manejo del dolor y anestesia" },
                new Especialidad { Nombre = "Radiología", Descripcion = "Diagnóstico por imagen" },
            };

            context.Especialidades.AddRange(especialidades);
        }

        private static void SeedMedicamentos(DataContext context)
        {
            var medicamentos = new List<Medicamento>
            {
                // Analgésicos
                new Medicamento { Nombre = "Paracetamol 500mg", NombreGenerico = "Paracetamol", Presentacion = "Tabletas", Concentracion = "500mg", Via = "Oral", RequiereReceta = false },
                new Medicamento { Nombre = "Ibuprofeno 400mg", NombreGenerico = "Ibuprofeno", Presentacion = "Tabletas", Concentracion = "400mg", Via = "Oral", RequiereReceta = false },
                new Medicamento { Nombre = "Ketorolaco 10mg", NombreGenerico = "Ketorolaco", Presentacion = "Tabletas", Concentracion = "10mg", Via = "Oral", RequiereReceta = true },

                // Antibióticos
                new Medicamento { Nombre = "Amoxicilina 500mg", NombreGenerico = "Amoxicilina", Presentacion = "Cápsulas", Concentracion = "500mg", Via = "Oral", RequiereReceta = true },
                new Medicamento { Nombre = "Azitromicina 500mg", NombreGenerico = "Azitromicina", Presentacion = "Tabletas", Concentracion = "500mg", Via = "Oral", RequiereReceta = true },
                new Medicamento { Nombre = "Ciprofloxacino 500mg", NombreGenerico = "Ciprofloxacino", Presentacion = "Tabletas", Concentracion = "500mg", Via = "Oral", RequiereReceta = true },

                // Antihistamínicos
                new Medicamento { Nombre = "Loratadina 10mg", NombreGenerico = "Loratadina", Presentacion = "Tabletas", Concentracion = "10mg", Via = "Oral", RequiereReceta = false },
                new Medicamento { Nombre = "Cetirizina 10mg", NombreGenerico = "Cetirizina", Presentacion = "Tabletas", Concentracion = "10mg", Via = "Oral", RequiereReceta = false },

                // Antihipertensivos
                new Medicamento { Nombre = "Losartán 50mg", NombreGenerico = "Losartán", Presentacion = "Tabletas", Concentracion = "50mg", Via = "Oral", RequiereReceta = true },
                new Medicamento { Nombre = "Enalapril 10mg", NombreGenerico = "Enalapril", Presentacion = "Tabletas", Concentracion = "10mg", Via = "Oral", RequiereReceta = true },

                // Antidiabéticos
                new Medicamento { Nombre = "Metformina 850mg", NombreGenerico = "Metformina", Presentacion = "Tabletas", Concentracion = "850mg", Via = "Oral", RequiereReceta = true },
                new Medicamento { Nombre = "Glibenclamida 5mg", NombreGenerico = "Glibenclamida", Presentacion = "Tabletas", Concentracion = "5mg", Via = "Oral", RequiereReceta = true },

                // Antiácidos
                new Medicamento { Nombre = "Omeprazol 20mg", NombreGenerico = "Omeprazol", Presentacion = "Cápsulas", Concentracion = "20mg", Via = "Oral", RequiereReceta = false },
                new Medicamento { Nombre = "Ranitidina 150mg", NombreGenerico = "Ranitidina", Presentacion = "Tabletas", Concentracion = "150mg", Via = "Oral", RequiereReceta = false },

                // Vitaminas
                new Medicamento { Nombre = "Vitamina C 1000mg", NombreGenerico = "Ácido Ascórbico", Presentacion = "Tabletas", Concentracion = "1000mg", Via = "Oral", RequiereReceta = false },
                new Medicamento { Nombre = "Complejo B", NombreGenerico = "Vitaminas del complejo B", Presentacion = "Tabletas", Concentracion = "Variable", Via = "Oral", RequiereReceta = false },
            };

            context.Medicamentos.AddRange(medicamentos);
        }

        private static void SeedEstudiosLaboratorio(DataContext context)
        {
            var estudios = new List<EstudioLaboratorio>
            {
                // Hematología
                new EstudioLaboratorio { Nombre = "Biometría Hemática Completa", Codigo = "BHC", Categoria = "Hematología", Precio = 150.00m, Preparacion = "No requiere ayuno" },
                new EstudioLaboratorio { Nombre = "Química Sanguínea", Codigo = "QS", Categoria = "Química Clínica", Precio = 200.00m, Preparacion = "Ayuno de 8-12 horas" },
                new EstudioLaboratorio { Nombre = "Glucosa en Sangre", Codigo = "GLU", Categoria = "Química Clínica", Precio = 80.00m, Preparacion = "Ayuno de 8-12 horas" },

                // Perfil lipídico
                new EstudioLaboratorio { Nombre = "Perfil de Lípidos", Codigo = "LIPIDOS", Categoria = "Química Clínica", Precio = 250.00m, Preparacion = "Ayuno de 12-14 horas" },
                new EstudioLaboratorio { Nombre = "Colesterol Total", Codigo = "COL", Categoria = "Química Clínica", Precio = 100.00m, Preparacion = "Ayuno de 12 horas" },
                new EstudioLaboratorio { Nombre = "Triglicéridos", Codigo = "TRIG", Categoria = "Química Clínica", Precio = 100.00m, Preparacion = "Ayuno de 12 horas" },

                // Función hepática
                new EstudioLaboratorio { Nombre = "Perfil Hepático", Codigo = "PH", Categoria = "Química Clínica", Precio = 300.00m, Preparacion = "Ayuno de 8 horas" },
                new EstudioLaboratorio { Nombre = "Transaminasas", Codigo = "TGO-TGP", Categoria = "Química Clínica", Precio = 150.00m, Preparacion = "Ayuno de 8 horas" },

                // Función renal
                new EstudioLaboratorio { Nombre = "Perfil Renal", Codigo = "PR", Categoria = "Química Clínica", Precio = 250.00m, Preparacion = "No requiere ayuno" },
                new EstudioLaboratorio { Nombre = "Creatinina", Codigo = "CREAT", Categoria = "Química Clínica", Precio = 80.00m, Preparacion = "No requiere ayuno" },
                new EstudioLaboratorio { Nombre = "Urea", Codigo = "UREA", Categoria = "Química Clínica", Precio = 80.00m, Preparacion = "No requiere ayuno" },
                new EstudioLaboratorio { Nombre = "Ácido Úrico", Codigo = "AU", Categoria = "Química Clínica", Precio = 90.00m, Preparacion = "Ayuno de 8 horas" },

                // Hormonas
                new EstudioLaboratorio { Nombre = "Perfil Tiroideo", Codigo = "TIROIDEO", Categoria = "Endocrinología", Precio = 500.00m, Preparacion = "No requiere ayuno" },
                new EstudioLaboratorio { Nombre = "TSH", Codigo = "TSH", Categoria = "Endocrinología", Precio = 200.00m, Preparacion = "No requiere ayuno" },
                new EstudioLaboratorio { Nombre = "Hemoglobina Glucosilada (HbA1c)", Codigo = "HBA1C", Categoria = "Química Clínica", Precio = 250.00m, Preparacion = "No requiere ayuno" },

                // Orina
                new EstudioLaboratorio { Nombre = "Examen General de Orina", Codigo = "EGO", Categoria = "Urianálisis", Precio = 100.00m, Preparacion = "Primera orina de la mañana" },
                new EstudioLaboratorio { Nombre = "Urocultivo", Codigo = "UROCULT", Categoria = "Microbiología", Precio = 250.00m, Preparacion = "Primera orina de la mañana, higiene previa" },

                // Microbiología
                new EstudioLaboratorio { Nombre = "Coproparasitoscópico", Codigo = "CPS", Categoria = "Microbiología", Precio = 150.00m, Preparacion = "3 muestras en días alternos" },
                new EstudioLaboratorio { Nombre = "Coprocultivo", Codigo = "COPROCULT", Categoria = "Microbiología", Precio = 300.00m, Preparacion = "Muestra fresca" },

                // Inmunología
                new EstudioLaboratorio { Nombre = "VIH (ELISA)", Codigo = "VIH", Categoria = "Inmunología", Precio = 350.00m, Preparacion = "No requiere ayuno" },
                new EstudioLaboratorio { Nombre = "Antígeno Prostático Específico (PSA)", Codigo = "PSA", Categoria = "Inmunología", Precio = 400.00m, Preparacion = "Sin eyaculación 48h antes" },
            };

            context.EstudiosLaboratorio.AddRange(estudios);
        }

        private static void SeedEstudiosImagen(DataContext context)
        {
            var estudios = new List<EstudioImagen>
            {
                // Rayos X
                new EstudioImagen { Nombre = "Radiografía de Tórax", Codigo = "RX-TORAX", Tipo = "Rayos X", Precio = 250.00m, Preparacion = "No requiere preparación" },
                new EstudioImagen { Nombre = "Radiografía de Abdomen", Codigo = "RX-ABDOMEN", Tipo = "Rayos X", Precio = 250.00m, Preparacion = "No requiere preparación" },
                new EstudioImagen { Nombre = "Radiografía de Columna Lumbar", Codigo = "RX-COLUMNA", Tipo = "Rayos X", Precio = 300.00m, Preparacion = "No requiere preparación" },
                new EstudioImagen { Nombre = "Radiografía de Rodilla", Codigo = "RX-RODILLA", Tipo = "Rayos X", Precio = 250.00m, Preparacion = "No requiere preparación" },

                // Ultrasonido
                new EstudioImagen { Nombre = "Ultrasonido Abdominal", Codigo = "US-ABDOMEN", Tipo = "Ultrasonido", Precio = 500.00m, Preparacion = "Ayuno de 6-8 horas" },
                new EstudioImagen { Nombre = "Ultrasonido Pélvico", Codigo = "US-PELVICO", Tipo = "Ultrasonido", Precio = 500.00m, Preparacion = "Vejiga llena (tomar 1 litro de agua 1 hora antes)" },
                new EstudioImagen { Nombre = "Ultrasonido Obstétrico", Codigo = "US-OBSTETRICO", Tipo = "Ultrasonido", Precio = 600.00m, Preparacion = "Vejiga llena" },
                new EstudioImagen { Nombre = "Ultrasonido de Tiroides", Codigo = "US-TIROIDES", Tipo = "Ultrasonido", Precio = 450.00m, Preparacion = "No requiere preparación" },
                new EstudioImagen { Nombre = "Ultrasonido Renal", Codigo = "US-RENAL", Tipo = "Ultrasonido", Precio = 500.00m, Preparacion = "Ayuno de 6 horas" },

                // Tomografía
                new EstudioImagen { Nombre = "Tomografía de Cráneo Simple", Codigo = "TAC-CRANEO", Tipo = "Tomografía", Precio = 1500.00m, Preparacion = "No requiere preparación" },
                new EstudioImagen { Nombre = "Tomografía de Tórax", Codigo = "TAC-TORAX", Tipo = "Tomografía", Precio = 1800.00m, Preparacion = "Ayuno de 4 horas" },
                new EstudioImagen { Nombre = "Tomografía de Abdomen", Codigo = "TAC-ABDOMEN", Tipo = "Tomografía", Precio = 1800.00m, Preparacion = "Ayuno de 6 horas, tomar medio de contraste" },

                // Resonancia Magnética
                new EstudioImagen { Nombre = "Resonancia Magnética de Cerebro", Codigo = "RM-CEREBRO", Tipo = "Resonancia Magnética", Precio = 3500.00m, Preparacion = "Retirar objetos metálicos" },
                new EstudioImagen { Nombre = "Resonancia Magnética de Columna", Codigo = "RM-COLUMNA", Tipo = "Resonancia Magnética", Precio = 3500.00m, Preparacion = "Retirar objetos metálicos" },
                new EstudioImagen { Nombre = "Resonancia Magnética de Rodilla", Codigo = "RM-RODILLA", Tipo = "Resonancia Magnética", Precio = 3000.00m, Preparacion = "Retirar objetos metálicos" },

                // Mastografía
                new EstudioImagen { Nombre = "Mastografía Bilateral", Codigo = "MASTO", Tipo = "Mastografía", Precio = 800.00m, Preparacion = "No usar desodorante ni cremas, preferible 1 semana después del periodo menstrual" },

                // Densitometría
                new EstudioImagen { Nombre = "Densitometría Ósea", Codigo = "DENSITO", Tipo = "Densitometría", Precio = 1000.00m, Preparacion = "No tomar suplementos de calcio 24h antes" },
            };

            context.EstudiosImagen.AddRange(estudios);
        }

        private static void SeedServicios(DataContext context)
        {
            var servicios = new List<Servicio>
            {
                // Consultas
                new Servicio { Nombre = "Consulta de Medicina General", Codigo = "CONS-GEN", ClaveProdServ = "85121800", Categoria = "Consultas", Precio = 300.00m, IVA = 0 },
                new Servicio { Nombre = "Consulta de Especialidad", Codigo = "CONS-ESP", ClaveProdServ = "85121800", Categoria = "Consultas", Precio = 500.00m, IVA = 0 },
                new Servicio { Nombre = "Consulta de Urgencias", Codigo = "CONS-URG", ClaveProdServ = "85121800", Categoria = "Consultas", Precio = 800.00m, IVA = 0 },
                new Servicio { Nombre = "Consulta Pediátrica", Codigo = "CONS-PED", ClaveProdServ = "85121800", Categoria = "Consultas", Precio = 400.00m, IVA = 0 },

                // Procedimientos
                new Servicio { Nombre = "Curación Menor", Codigo = "PROC-CUR", ClaveProdServ = "85121801", Categoria = "Procedimientos", Precio = 200.00m, IVA = 0 },
                new Servicio { Nombre = "Sutura Simple", Codigo = "PROC-SUT", ClaveProdServ = "85121801", Categoria = "Procedimientos", Precio = 500.00m, IVA = 0 },
                new Servicio { Nombre = "Extracción de Puntos", Codigo = "PROC-EXT", ClaveProdServ = "85121801", Categoria = "Procedimientos", Precio = 150.00m, IVA = 0 },
                new Servicio { Nombre = "Inyección Intramuscular", Codigo = "PROC-INY", ClaveProdServ = "85121801", Categoria = "Procedimientos", Precio = 80.00m, IVA = 0 },

                // Certificados
                new Servicio { Nombre = "Certificado Médico", Codigo = "CERT-MED", ClaveProdServ = "85121803", Categoria = "Certificados", Precio = 250.00m, IVA = 16 },
                new Servicio { Nombre = "Certificado Preoperatorio", Codigo = "CERT-PRE", ClaveProdServ = "85121803", Categoria = "Certificados", Precio = 350.00m, IVA = 16 },

                // Otros
                new Servicio { Nombre = "Hospitalización (por día)", Codigo = "HOSP-DIA", ClaveProdServ = "85131500", Categoria = "Hospitalización", Precio = 1500.00m, IVA = 0 },
                new Servicio { Nombre = "Sala de Operaciones (por hora)", Codigo = "QUIROF-HR", ClaveProdServ = "85131600", Categoria = "Quirófano", Precio = 3000.00m, IVA = 0 },
            };

            context.Servicios.AddRange(servicios);
        }

        private static void SeedRoles(DataContext context)
        {
            var roles = new List<Rol>
            {
                new Rol { Nombre = "Administrador", Descripcion = "Acceso completo al sistema" },
                new Rol { Nombre = "Médico", Descripcion = "Acceso a consultas, recetas y órdenes" },
                new Rol { Nombre = "Enfermera", Descripcion = "Acceso a citas y toma de signos vitales" },
                new Rol { Nombre = "Recepcionista", Descripcion = "Acceso a agenda y registro de pacientes" },
                new Rol { Nombre = "Facturador", Descripcion = "Acceso al módulo de facturación" },
                new Rol { Nombre = "Almacenista", Descripcion = "Acceso al módulo de inventario" },
                new Rol { Nombre = "Laboratorista", Descripcion = "Acceso al módulo de laboratorio" },
                new Rol { Nombre = "Radiólogo", Descripcion = "Acceso al módulo de imagenología" },
            };

            context.Roles.AddRange(roles);
            context.SaveChanges();

            // Asignar permisos al rol Administrador (acceso completo a todos los módulos)
            var rolAdmin = context.Roles.First(r => r.Nombre == "Administrador");
            var todosLosModulos = context.Modulos.Where(m => m.ModuloPadreId == null).ToList();

            foreach (var modulo in todosLosModulos)
            {
                context.RolPermisos.Add(new RolPermiso
                {
                    RolId = rolAdmin.Id,
                    ModuloId = modulo.Id,
                    PuedeLeer = true,
                    PuedeCrear = true,
                    PuedeEditar = true,
                    PuedeEliminar = true
                });
            }

            // Asignar permisos específicos al rol Médico
            var rolMedico = context.Roles.First(r => r.Nombre == "Médico");
            var modulosMedico = new[] { "DASHBOARD", "PACIENTES", "CITAS", "CONSULTAS", "HISTORIA_CLINICA", "RECETAS", "LABORATORIO", "IMAGENOLOGIA" };

            foreach (var codigoModulo in modulosMedico)
            {
                var modulo = context.Modulos.FirstOrDefault(m => m.Codigo == codigoModulo);
                if (modulo != null)
                {
                    context.RolPermisos.Add(new RolPermiso
                    {
                        RolId = rolMedico.Id,
                        ModuloId = modulo.Id,
                        PuedeLeer = true,
                        PuedeCrear = true,
                        PuedeEditar = true,
                        PuedeEliminar = false
                    });
                }
            }

            // Asignar permisos al rol Recepcionista
            var rolRecepcionista = context.Roles.First(r => r.Nombre == "Recepcionista");
            var modulosRecepcionista = new[] { "DASHBOARD", "PACIENTES", "CITAS" };

            foreach (var codigoModulo in modulosRecepcionista)
            {
                var modulo = context.Modulos.FirstOrDefault(m => m.Codigo == codigoModulo);
                if (modulo != null)
                {
                    context.RolPermisos.Add(new RolPermiso
                    {
                        RolId = rolRecepcionista.Id,
                        ModuloId = modulo.Id,
                        PuedeLeer = true,
                        PuedeCrear = true,
                        PuedeEditar = true,
                        PuedeEliminar = false
                    });
                }
            }
        }
    }
}