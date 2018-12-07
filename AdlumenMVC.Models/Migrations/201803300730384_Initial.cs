namespace AdlumenMVC.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            //CreateTable(
            //    "dbo.Acciones",
            //    c => new
            //        {
            //            AccionesId = c.Int(nullable: false, identity: true),
            //            Nombre = c.String(),
            //            Descripcion = c.String(),
            //            ModuloId = c.Int(nullable: false),
            //        })
            //    .PrimaryKey(t => t.AccionesId)
            //    .ForeignKey("dbo.Moduloes", t => t.ModuloId, cascadeDelete: true)
            //    .Index(t => t.ModuloId);
            
            //CreateTable(
            //    "dbo.AspNetRoles",
            //    c => new
            //        {
            //            Id = c.String(nullable: false, maxLength: 128),
            //            Name = c.String(nullable: false, maxLength: 256),
            //            Discriminator = c.String(nullable: false, maxLength: 128),
            //        })
            //    .PrimaryKey(t => t.Id);
            
            //CreateTable(
            //    "dbo.AspNetUsers",
            //    c => new
            //        {
            //            Id = c.String(nullable: false, maxLength: 128),
            //            FirstName = c.String(nullable: false, maxLength: 100),
            //            LastName = c.String(nullable: false, maxLength: 100),
            //            Level = c.Byte(nullable: false),
            //            JoinDate = c.DateTime(nullable: false),
            //            Latitude = c.String(),
            //            Longitude = c.String(),
            //            Client = c.Int(nullable: false),
            //            Logo = c.String(),
            //            IdLocal = c.Int(nullable: false),
            //            Email = c.String(maxLength: 256),
            //            EmailConfirmed = c.Boolean(nullable: false),
            //            PasswordHash = c.String(),
            //            SecurityStamp = c.String(),
            //            PhoneNumber = c.String(),
            //            PhoneNumberConfirmed = c.Boolean(nullable: false),
            //            TwoFactorEnabled = c.Boolean(nullable: false),
            //            LockoutEndDateUtc = c.DateTime(),
            //            LockoutEnabled = c.Boolean(nullable: false),
            //            AccessFailedCount = c.Int(nullable: false),
            //            UserName = c.String(nullable: false, maxLength: 256),
            //            IdTenant = c.Int(nullable: false),
            //        })
            //    .PrimaryKey(t => t.Id);
            
            //CreateTable(
            //    "dbo.AspNetUserClaims",
            //    c => new
            //        {
            //            Id = c.Int(nullable: false, identity: true),
            //            UserId = c.String(nullable: false, maxLength: 128),
            //            ClaimType = c.String(),
            //            ClaimValue = c.String(),
            //        })
            //    .PrimaryKey(t => t.Id)
            //    .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
            //    .Index(t => t.UserId);
            
            //CreateTable(
            //    "dbo.AspNetUserLogins",
            //    c => new
            //        {
            //            LoginProvider = c.String(nullable: false, maxLength: 128),
            //            ProviderKey = c.String(nullable: false, maxLength: 128),
            //            UserId = c.String(nullable: false, maxLength: 128),
            //        })
            //    .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
            //    .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
            //    .Index(t => t.UserId);
            
            //CreateTable(
            //    "dbo.Moduloes",
            //    c => new
            //        {
            //            ModuloId = c.Int(nullable: false, identity: true),
            //            Nombre = c.String(),
            //        })
            //    .PrimaryKey(t => t.ModuloId);
            
            //CreateTable(
            //    "dbo.Cms_MenuNodos",
            //    c => new
            //        {
            //            IdNodo = c.Int(nullable: false, identity: true),
            //            IdMenu = c.Int(nullable: false),
            //            IdPadre = c.Int(nullable: false),
            //            Posicion = c.Int(),
            //            Destino = c.String(maxLength: 50),
            //            Url = c.String(nullable: false, maxLength: 256),
            //            Nombre = c.String(maxLength: 256),
            //            Descripcion = c.String(maxLength: 256),
            //            IconoUrl = c.String(maxLength: 256),
            //            Estado = c.Boolean(),
            //            FechaCreacion = c.DateTime(),
            //            UsuarioCreacion = c.String(maxLength: 256),
            //            FechaModificacion = c.DateTime(),
            //            UsuarioModificacion = c.String(maxLength: 256),
            //            Roles = c.String(maxLength: 100),
            //            RutaXml = c.String(),
            //            IdTenant = c.Int(nullable: false),
            //        })
            //    .PrimaryKey(t => t.IdNodo)
            //    .ForeignKey("dbo.Cms_Menus", t => t.IdMenu, cascadeDelete: true)
            //    .Index(t => t.IdMenu);
            
            //CreateTable(
            //    "dbo.Cms_Menus",
            //    c => new
            //        {
            //            IdMenu = c.Int(nullable: false, identity: true),
            //            Nombre = c.String(nullable: false, maxLength: 256),
            //            Estado = c.Boolean(nullable: false),
            //            IdTenant = c.Int(nullable: false),
            //        })
            //    .PrimaryKey(t => t.IdMenu);
            
            //CreateTable(
            //    "dbo.Org_Empresas",
            //    c => new
            //        {
            //            IdEmpresa = c.Int(nullable: false, identity: true),
            //            Nombre = c.String(nullable: false, maxLength: 256),
            //            Ubicacion = c.String(maxLength: 256),
            //            URL = c.String(maxLength: 256),
            //            Telefono = c.String(maxLength: 50),
            //            Logo = c.String(maxLength: 256),
            //            IdIdentificacionTipo = c.Int(nullable: false),
            //            Identificacion = c.String(nullable: false, maxLength: 50),
            //            IdPais = c.Int(nullable: false),
            //            IdMenuAdministracion = c.Int(),
            //            IdMenuSuperior = c.Int(),
            //            IdMenuIzquierdo = c.Int(),
            //            IdMenuPanel = c.Int(),
            //            FechaCreacion = c.DateTime(nullable: false),
            //            UsuarioCreacion = c.String(nullable: false, maxLength: 256),
            //            FechaModificacion = c.DateTime(),
            //            UsuarioModificacion = c.String(maxLength: 256),
            //            Eliminado = c.Boolean(nullable: false),
            //            IdMenuSLDerecho = c.Int(),
            //            IdMenuReportes = c.Int(),
            //            Latitude = c.Double(),
            //            Longitude = c.Double(),
            //            IdCliente = c.Int(),
            //            IdCategoriaDocumentos = c.Int(),
            //            IdTenant = c.Int(nullable: false),
            //        })
            //    .PrimaryKey(t => t.IdEmpresa)
            //    .ForeignKey("dbo.Cms_Menus", t => t.IdMenuSuperior)
            //    .ForeignKey("dbo.Cms_Menus", t => t.IdMenuIzquierdo)
            //    .ForeignKey("dbo.Cms_Menus", t => t.IdMenuPanel)
            //    .ForeignKey("dbo.M_Paises", t => t.IdPais, cascadeDelete: true)
            //    .ForeignKey("dbo.Org_IdentificacionTipos", t => t.IdIdentificacionTipo, cascadeDelete: true)
            //    .ForeignKey("dbo.Sys_Clientes", t => t.IdCliente)
            //    .Index(t => t.IdIdentificacionTipo)
            //    .Index(t => t.IdPais)
            //    .Index(t => t.IdMenuSuperior)
            //    .Index(t => t.IdMenuIzquierdo)
            //    .Index(t => t.IdMenuPanel)
            //    .Index(t => t.IdCliente);
            
            //CreateTable(
            //    "dbo.M_Paises",
            //    c => new
            //        {
            //            IdPais = c.Int(nullable: false, identity: true),
            //            Nombre = c.String(nullable: false, maxLength: 50),
            //        })
            //    .PrimaryKey(t => t.IdPais);
            
            //CreateTable(
            //    "dbo.Org_Areas",
            //    c => new
            //        {
            //            IdArea = c.Int(nullable: false, identity: true),
            //            IdPadre = c.Int(nullable: false),
            //            IdEmpresa = c.Int(nullable: false),
            //            IdResponsable = c.Int(),
            //            Nombre = c.String(nullable: false, maxLength: 256),
            //            Objetivo = c.String(),
            //            Descripcion = c.String(),
            //            UsuarioCreacion = c.String(nullable: false, maxLength: 256),
            //            FechaCreacion = c.DateTime(nullable: false),
            //            UsuarioModificacion = c.String(maxLength: 256),
            //            FechaModificacion = c.DateTime(),
            //            Eliminado = c.Boolean(nullable: false),
            //            IdTenant = c.Int(nullable: false),
            //        })
            //    .PrimaryKey(t => t.IdArea)
            //    .ForeignKey("dbo.Org_Empresas", t => t.IdEmpresa, cascadeDelete: true)
            //    .Index(t => t.IdEmpresa);
            
            //CreateTable(
            //    "dbo.Org_Cargos",
            //    c => new
            //        {
            //            IdCargo = c.Int(nullable: false, identity: true),
            //            IdArea = c.Int(nullable: false),
            //            Nombre = c.String(nullable: false, maxLength: 256),
            //            IdPadre = c.Int(),
            //            Descripcion = c.String(),
            //            Perfil = c.String(),
            //            UsuarioCreacion = c.String(nullable: false, maxLength: 256),
            //            FechaCreacion = c.DateTime(nullable: false),
            //            UsuarioModificacion = c.String(maxLength: 256),
            //            FechaModificacion = c.DateTime(),
            //            Eliminado = c.Boolean(nullable: false),
            //            IdTenant = c.Int(nullable: false),
            //        })
            //    .PrimaryKey(t => t.IdCargo)
            //    .ForeignKey("dbo.Org_Areas", t => t.IdArea, cascadeDelete: true)
            //    .Index(t => t.IdArea);
            
            //CreateTable(
            //    "dbo.Org_Empleados",
            //    c => new
            //        {
            //            IdEmpleado = c.Int(nullable: false, identity: true),
            //            IdCargo = c.Int(),
            //            Nombre = c.String(nullable: false, maxLength: 256),
            //            Apellido = c.String(maxLength: 256),
            //            IdIdentificacionTipo = c.Int(nullable: false),
            //            Identificacion = c.String(nullable: false, maxLength: 50),
            //            Foto = c.String(maxLength: 256),
            //            Correo = c.String(maxLength: 50),
            //            Observaciones = c.String(),
            //            Competencias = c.String(),
            //            HojaVida = c.String(maxLength: 256),
            //            UsuarioCreacion = c.String(nullable: false, maxLength: 256),
            //            FechaCreacion = c.DateTime(nullable: false),
            //            UsuarioModificacion = c.String(maxLength: 256),
            //            FechaModificacion = c.DateTime(),
            //            Retirado = c.Boolean(nullable: false),
            //            IdUsuario = c.Int(),
            //            IdTenant = c.Int(nullable: false),
            //        })
            //    .PrimaryKey(t => t.IdEmpleado)
            //    .ForeignKey("dbo.Org_Cargos", t => t.IdCargo)
            //    .ForeignKey("dbo.Org_IdentificacionTipos", t => t.IdIdentificacionTipo, cascadeDelete: true)
            //    .ForeignKey("dbo.Sys_Usuarios", t => t.IdUsuario)
            //    .Index(t => t.IdCargo)
            //    .Index(t => t.IdIdentificacionTipo)
            //    .Index(t => t.IdUsuario);
            
            //CreateTable(
            //    "dbo.Org_EmpleadosCargosHistorico",
            //    c => new
            //        {
            //            IdEmpleadoCargo = c.Int(nullable: false, identity: true),
            //            IdEmpleado = c.Int(nullable: false),
            //            IdCargo = c.Int(nullable: false),
            //            FechaInicioCargo = c.DateTime(nullable: false),
            //            FechaFinCargo = c.DateTime(),
            //            UsuarioCreacion = c.String(nullable: false, maxLength: 256),
            //            FechaCreacion = c.DateTime(nullable: false),
            //            UsuarioModificacion = c.String(maxLength: 256),
            //            FechaModificacion = c.DateTime(),
            //            IdTenant = c.Int(nullable: false),
            //        })
            //    .PrimaryKey(t => t.IdEmpleadoCargo)
            //    .ForeignKey("dbo.Org_Cargos", t => t.IdCargo, cascadeDelete: true)
            //    .ForeignKey("dbo.Org_Empleados", t => t.IdEmpleado, cascadeDelete: true)
            //    .Index(t => t.IdEmpleado)
            //    .Index(t => t.IdCargo);
            
            //CreateTable(
            //    "dbo.Org_IdentificacionTipos",
            //    c => new
            //        {
            //            IdIdentificacionTipo = c.Int(nullable: false, identity: true),
            //            Nombre = c.String(nullable: false, maxLength: 256),
            //            IdTenant = c.Int(nullable: false),
            //        })
            //    .PrimaryKey(t => t.IdIdentificacionTipo);
            
            //CreateTable(
            //    "dbo.Org_Donantes",
            //    c => new
            //        {
            //            IdDonante = c.Int(nullable: false, identity: true),
            //            Nombre = c.String(nullable: false, maxLength: 256),
            //            IdIdentificacionTipo = c.Int(nullable: false),
            //            Identificacion = c.String(nullable: false, maxLength: 50),
            //            Contacto = c.String(maxLength: 256),
            //            Telefono = c.String(maxLength: 20),
            //            Ubicacion = c.String(maxLength: 100),
            //            Correo = c.String(maxLength: 256),
            //            URL = c.String(maxLength: 256),
            //            HojaVida = c.String(maxLength: 256),
            //            FechaCreacion = c.DateTime(nullable: false),
            //            UsuarioCreacion = c.String(nullable: false, maxLength: 256),
            //            FechaModificacion = c.DateTime(),
            //            UsuarioModificacion = c.String(maxLength: 256),
            //            Eliminado = c.Boolean(nullable: false),
            //            IdCliente = c.Int(),
            //            IdPrograma = c.Int(),
            //            IdTenant = c.Int(nullable: false),
            //            Sys_Usuarios_IdUsuario = c.Int(),
            //            Org_Empresas_IdEmpresa = c.Int(),
            //        })
            //    .PrimaryKey(t => t.IdDonante)
            //    .ForeignKey("dbo.Org_IdentificacionTipos", t => t.IdIdentificacionTipo, cascadeDelete: true)
            //    .ForeignKey("dbo.Sys_Usuarios", t => t.Sys_Usuarios_IdUsuario)
            //    .ForeignKey("dbo.Sys_Clientes", t => t.IdCliente)
            //    .ForeignKey("dbo.Org_Empresas", t => t.Org_Empresas_IdEmpresa)
            //    .Index(t => t.IdIdentificacionTipo)
            //    .Index(t => t.IdCliente)
            //    .Index(t => t.Sys_Usuarios_IdUsuario)
            //    .Index(t => t.Org_Empresas_IdEmpresa);
            
            //CreateTable(
            //    "dbo.Org_Donantes_Empresas",
            //    c => new
            //        {
            //            IdDonante = c.Int(nullable: false),
            //            IdEmpresa = c.Int(nullable: false),
            //            IdTenant = c.Int(nullable: false),
            //        })
            //    .PrimaryKey(t => new { t.IdDonante, t.IdEmpresa })
            //    .ForeignKey("dbo.Org_Donantes", t => t.IdDonante, cascadeDelete: true)
            //    .ForeignKey("dbo.Org_Empresas", t => t.IdEmpresa, cascadeDelete: true)
            //    .Index(t => t.IdDonante)
            //    .Index(t => t.IdEmpresa);
            
            //CreateTable(
            //    "dbo.Pry_CalendarioDonaciones",
            //    c => new
            //        {
            //            IdDonacion = c.Int(nullable: false, identity: true),
            //            IdProyecto = c.Int(nullable: false),
            //            IdDonante = c.Int(nullable: false),
            //            Monto = c.Double(nullable: false),
            //            FechaProgramada = c.DateTime(nullable: false),
            //            IdTenant = c.Int(nullable: false),
            //        })
            //    .PrimaryKey(t => t.IdDonacion)
            //    .ForeignKey("dbo.Org_Donantes", t => t.IdDonante, cascadeDelete: true)
            //    .ForeignKey("dbo.Pry_Proyectos", t => t.IdProyecto, cascadeDelete: true)
            //    .Index(t => t.IdProyecto)
            //    .Index(t => t.IdDonante);
            
            //CreateTable(
            //    "dbo.Pry_Proyectos",
            //    c => new
            //        {
            //            IdProyecto = c.Int(nullable: false, identity: true),
            //            IdUsuarioResponsable = c.Int(),
            //            IdUsuarioDigitador = c.Int(),
            //            IdUsuarioEvaluador = c.Int(),
            //            Codigo = c.String(maxLength: 50),
            //            Nombre = c.String(maxLength: 500),
            //            Descripcion = c.String(maxLength: 2000),
            //            Problema = c.String(),
            //            DescripcionProblema = c.String(),
            //            Justificacion = c.String(),
            //            IdCategoriaDocumentos = c.Int(),
            //            IdCategoriaSupuestos = c.Int(),
            //            Beneficiarios = c.String(maxLength: 256),
            //            Region = c.String(maxLength: 256),
            //            DiasNotificacion = c.Int(nullable: false),
            //            IdMoneda = c.Int(),
            //            Eliminado = c.Boolean(nullable: false),
            //            IdProposito = c.Int(),
            //            Area = c.String(maxLength: 256),
            //            FechaInicio = c.DateTime(),
            //            FechaFin = c.DateTime(),
            //            Presupuesto = c.Double(),
            //            Logo = c.String(maxLength: 250),
            //            IdEstado = c.Int(),
            //            Latitude = c.Double(),
            //            Longitude = c.Double(),
            //            CustomerId = c.Int(nullable: false),
            //            IdEmpresa = c.Int(),
            //            IdTipo = c.Int(nullable: false),
            //            IDPROYECTOPADRE = c.Int(),
            //            MONTOFINANCIAMIENTO = c.Double(),
            //            MONTOCONTRAPARTIDA = c.Double(),
            //            IdTenant = c.Int(nullable: false),
            //        })
            //    .PrimaryKey(t => t.IdProyecto)
            //    .ForeignKey("dbo.M_Monedas", t => t.IdMoneda)
            //    .ForeignKey("dbo.Pry_Objetivos", t => t.IdProposito)
            //    .ForeignKey("dbo.Pry_Proyectos", t => t.IDPROYECTOPADRE)
            //    .ForeignKey("dbo.Pry_ProyectosEstados", t => t.IdEstado)
            //    .ForeignKey("dbo.Pry_ProyectosTipos", t => t.IdTipo, cascadeDelete: true)
            //    .ForeignKey("dbo.Sys_Clientes", t => t.CustomerId, cascadeDelete: true)
            //    .ForeignKey("dbo.Sys_Usuarios", t => t.IdUsuarioEvaluador)
            //    .ForeignKey("dbo.Sys_Usuarios", t => t.IdUsuarioResponsable)
            //    .ForeignKey("dbo.Sys_Usuarios", t => t.IdUsuarioDigitador)
            //    .Index(t => t.IdUsuarioResponsable)
            //    .Index(t => t.IdUsuarioDigitador)
            //    .Index(t => t.IdUsuarioEvaluador)
            //    .Index(t => t.IdMoneda)
            //    .Index(t => t.IdProposito)
            //    .Index(t => t.IdEstado)
            //    .Index(t => t.CustomerId)
            //    .Index(t => t.IdTipo)
            //    .Index(t => t.IDPROYECTOPADRE);
            
            //CreateTable(
            //    "dbo.M_Monedas",
            //    c => new
            //        {
            //            IdMoneda = c.Int(nullable: false, identity: true),
            //            Nombre = c.String(nullable: false, maxLength: 50),
            //            Representacion = c.String(maxLength: 10, fixedLength: true),
            //            IdTenant = c.Int(nullable: false),
            //        })
            //    .PrimaryKey(t => t.IdMoneda);
            
            //CreateTable(
            //    "dbo.m_TipCambio",
            //    c => new
            //        {
            //            idTipCambio = c.Int(nullable: false, identity: true),
            //            idMoneda = c.Int(nullable: false),
            //            FecTipCambio = c.DateTime(nullable: false),
            //            ValCompra = c.Decimal(precision: 18, scale: 2),
            //            ValVenta = c.Decimal(precision: 18, scale: 2),
            //            IdTenant = c.Int(nullable: false),
            //            M_Monedas_IdMoneda = c.Int(),
            //        })
            //    .PrimaryKey(t => t.idTipCambio)
            //    .ForeignKey("dbo.M_Monedas", t => t.idMoneda, cascadeDelete: true)
            //    .ForeignKey("dbo.M_Monedas", t => t.M_Monedas_IdMoneda)
            //    .Index(t => t.idMoneda)
            //    .Index(t => t.M_Monedas_IdMoneda);
            
            //CreateTable(
            //    "dbo.Pry_Movimientos",
            //    c => new
            //        {
            //            IdMovimiento = c.Int(nullable: false, identity: true),
            //            IdPresupuesto = c.Int(),
            //            IdProveedor = c.Int(),
            //            Monto = c.Double(),
            //            Fecha = c.DateTime(),
            //            Observaciones = c.String(maxLength: 500),
            //            UrlSoporte = c.String(maxLength: 250),
            //            IdPeriodo = c.Long(),
            //            BENEFICIARIO = c.String(maxLength: 150),
            //            MEDIOPAGO = c.String(maxLength: 50),
            //            CONTRAPARTIDA = c.Decimal(precision: 18, scale: 2),
            //            APORTEPROGRAMA = c.Decimal(precision: 18, scale: 2),
            //            IDPARTIDAGASTO = c.Int(),
            //            USUARIOCREACION = c.String(maxLength: 256),
            //            FECHACREACION = c.DateTime(),
            //            USUARIOMODIFICACION = c.String(maxLength: 256),
            //            FECHAMODIFICACION = c.DateTime(),
            //            MONEDALOCAL = c.Int(),
            //            APORTEMONEDALOCAL = c.Decimal(precision: 18, scale: 2),
            //            IdTenant = c.Int(nullable: false),
            //        })
            //    .PrimaryKey(t => t.IdMovimiento)
            //    .ForeignKey("dbo.M_Monedas", t => t.MONEDALOCAL)
            //    .ForeignKey("dbo.PRY_PARTIDAGASTOS", t => t.IDPARTIDAGASTO)
            //    .ForeignKey("dbo.PRY_PERIODOSPROYECTOS", t => t.IdPeriodo)
            //    .ForeignKey("dbo.Pry_Presupuesto", t => t.IdPresupuesto)
            //    .Index(t => t.IdPresupuesto)
            //    .Index(t => t.IdPeriodo)
            //    .Index(t => t.IDPARTIDAGASTO)
            //    .Index(t => t.MONEDALOCAL);
            
            //CreateTable(
            //    "dbo.Pry_MontoDonacion",
            //    c => new
            //        {
            //            IdMontoDonante = c.Int(nullable: false, identity: true),
            //            IdMovimiento = c.Int(),
            //            IdDonante = c.Int(),
            //            Monto = c.Double(),
            //            IdTenant = c.Int(nullable: false),
            //        })
            //    .PrimaryKey(t => t.IdMontoDonante)
            //    .ForeignKey("dbo.Pry_Movimientos", t => t.IdMovimiento)
            //    .Index(t => t.IdMovimiento);
            
            //CreateTable(
            //    "dbo.PRY_PARTIDAGASTOS",
            //    c => new
            //        {
            //            IDPARTIDAGASTO = c.Int(nullable: false, identity: true),
            //            ABREVIATURA = c.String(nullable: false, maxLength: 50),
            //            CODIGO = c.String(nullable: false, maxLength: 50),
            //            NOMBRE = c.String(nullable: false, maxLength: 50),
            //            IdTenant = c.Int(nullable: false),
            //        })
            //    .PrimaryKey(t => t.IDPARTIDAGASTO);
            
            //CreateTable(
            //    "dbo.Pry_Recursos",
            //    c => new
            //        {
            //            IdRecurso = c.Int(nullable: false, identity: true),
            //            IdObjetivo = c.Int(nullable: false),
            //            Codigo = c.String(maxLength: 50),
            //            Descripcion = c.String(nullable: false, maxLength: 500),
            //            Tipo = c.String(maxLength: 100),
            //            Cantidad = c.Double(),
            //            UnidadMedida = c.String(maxLength: 50),
            //            ValorUnitario = c.Double(),
            //            Monto = c.Double(),
            //            IDPARTIDAGASTO = c.Int(),
            //            CONTRAPARTIDA = c.Decimal(precision: 18, scale: 2),
            //            APORTEPROGRAMA = c.Decimal(precision: 18, scale: 2),
            //            IdTenant = c.Int(nullable: false),
            //        })
            //    .PrimaryKey(t => t.IdRecurso)
            //    .ForeignKey("dbo.Pry_Objetivos", t => t.IdObjetivo, cascadeDelete: true)
            //    .ForeignKey("dbo.PRY_PARTIDAGASTOS", t => t.IDPARTIDAGASTO)
            //    .Index(t => t.IdObjetivo)
            //    .Index(t => t.IDPARTIDAGASTO);
            
            //CreateTable(
            //    "dbo.Pry_Objetivos",
            //    c => new
            //        {
            //            IdObjetivo = c.Int(nullable: false, identity: true),
            //            IdPadre = c.Int(),
            //            IdObjetivoClase = c.Int(),
            //            Codigo = c.String(maxLength: 50),
            //            Descripcion = c.String(maxLength: 2000),
            //            Eliminado = c.Boolean(),
            //            IdEmpresa = c.Int(),
            //            IdResponsable = c.Int(),
            //            FechaInicio = c.DateTime(),
            //            FechaFin = c.DateTime(),
            //            Ponderado = c.Double(),
            //            Progreso = c.Double(),
            //            IdNivelAceptacion = c.Int(),
            //            Efectividad = c.Double(),
            //            Eficacia = c.Double(),
            //            Eficiencia = c.Double(),
            //            Costo = c.Double(),
            //            IdNivelAceptacionEfectividad = c.Int(),
            //            IdNivelAceptacionEficacia = c.Int(),
            //            IdNivelAceptacionEficiencia = c.Int(),
            //            IdNivelAceptacionCosto = c.Int(),
            //            CostoNotificado = c.Boolean(nullable: false),
            //            EfectividadNotificada = c.Boolean(nullable: false),
            //            CustomerId = c.Int(),
            //            IdProyecto = c.Int(nullable: false),
            //            IdTenant = c.Int(nullable: false),
            //        })
            //    .PrimaryKey(t => t.IdObjetivo)
            //    .ForeignKey("dbo.Org_Empresas", t => t.IdEmpresa)
            //    .ForeignKey("dbo.Pry_ObjetivosClase", t => t.IdObjetivoClase)
            //    .Index(t => t.IdObjetivoClase)
            //    .Index(t => t.IdEmpresa);
            
            //CreateTable(
            //    "dbo.Pry_Beneficiarios",
            //    c => new
            //        {
            //            IdBeneficiario = c.Int(nullable: false, identity: true),
            //            IdObjetivo = c.Int(nullable: false),
            //            Nombre = c.String(nullable: false, maxLength: 250),
            //            Email = c.String(nullable: false, maxLength: 100),
            //            Telefono = c.String(maxLength: 20),
            //            Direccion = c.String(maxLength: 250),
            //            extensionTerritorial = c.Decimal(precision: 18, scale: 2),
            //            Status = c.Byte(nullable: false),
            //            IdTenant = c.Int(nullable: false),
            //        })
            //    .PrimaryKey(t => t.IdBeneficiario)
            //    .ForeignKey("dbo.Pry_Objetivos", t => t.IdObjetivo, cascadeDelete: true)
            //    .Index(t => t.IdObjetivo);
            
            //CreateTable(
            //    "dbo.Pry_CapacitacionBeneficiario",
            //    c => new
            //        {
            //            IdCapacitacionBeneficiario = c.Int(nullable: false, identity: true),
            //            IdCapacitacion = c.Int(nullable: false),
            //            IdBeneficiario = c.Int(nullable: false),
            //            FechaInscripcion = c.DateTime(nullable: false),
            //            Status = c.Byte(nullable: false),
            //            IdTenant = c.Int(nullable: false),
            //        })
            //    .PrimaryKey(t => t.IdCapacitacionBeneficiario)
            //    .ForeignKey("dbo.Pry_Beneficiarios", t => t.IdBeneficiario, cascadeDelete: true)
            //    .ForeignKey("dbo.Pry_Capacitaciones", t => t.IdCapacitacion, cascadeDelete: true)
            //    .Index(t => t.IdCapacitacion)
            //    .Index(t => t.IdBeneficiario);
            
            //CreateTable(
            //    "dbo.Pry_Capacitaciones",
            //    c => new
            //        {
            //            IdCapacitacion = c.Int(nullable: false, identity: true),
            //            IdFacilitador = c.Int(nullable: false),
            //            NombreCapacitacion = c.String(nullable: false, maxLength: 200),
            //            DescripcionCapacitacion = c.String(maxLength: 1000),
            //            FechaInicio = c.DateTime(nullable: false),
            //            FechaFinal = c.DateTime(nullable: false),
            //            Status = c.Byte(nullable: false),
            //            IdTenant = c.Int(nullable: false),
            //        })
            //    .PrimaryKey(t => t.IdCapacitacion)
            //    .ForeignKey("dbo.Pry_Facilitadores", t => t.IdFacilitador, cascadeDelete: true)
            //    .Index(t => t.IdFacilitador);
            
            //CreateTable(
            //    "dbo.Pry_Facilitadores",
            //    c => new
            //        {
            //            IdFacilitador = c.Int(nullable: false, identity: true),
            //            Nombre = c.String(nullable: false, maxLength: 250),
            //            Email = c.String(nullable: false, maxLength: 100),
            //            Telefono = c.String(maxLength: 20),
            //            Direccion = c.String(maxLength: 250),
            //            Status = c.Byte(nullable: false),
            //            IdTenant = c.Int(nullable: false),
            //        })
            //    .PrimaryKey(t => t.IdFacilitador);
            
            //CreateTable(
            //    "dbo.Pry_ProductividadBeneficiario",
            //    c => new
            //        {
            //            IdProductividadBeneficiario = c.Int(nullable: false, identity: true),
            //            IdBeneficiario = c.Int(nullable: false),
            //            AreaSembrada = c.Decimal(nullable: false, precision: 18, scale: 2),
            //            CultivoSembrado = c.String(maxLength: 250),
            //            CantidadSembrada = c.Decimal(nullable: false, precision: 18, scale: 2),
            //            ProduccionCultivo = c.Decimal(nullable: false, precision: 18, scale: 2),
            //            Eliminado = c.Boolean(nullable: false),
            //            IdTenant = c.Int(nullable: false),
            //        })
            //    .PrimaryKey(t => t.IdProductividadBeneficiario)
            //    .ForeignKey("dbo.Pry_Beneficiarios", t => t.IdBeneficiario, cascadeDelete: true)
            //    .Index(t => t.IdBeneficiario);
            
            //CreateTable(
            //    "dbo.PRY_EVALUACIONESACTIVIDADESPERIODO",
            //    c => new
            //        {
            //            IDOBJETIVO = c.Int(nullable: false),
            //            IDPERIODO = c.Long(nullable: false),
            //            IDPROYECTO = c.Int(nullable: false),
            //            OBSERVACIONES = c.String(maxLength: 2000),
            //            IdTenant = c.Int(nullable: false),
            //        })
            //    .PrimaryKey(t => new { t.IDOBJETIVO, t.IDPERIODO, t.IDPROYECTO })
            //    .ForeignKey("dbo.PRY_EVALUACIONPROYECTOPERIODO", t => new { t.IDPERIODO, t.IDPROYECTO }, cascadeDelete: true)
            //    .ForeignKey("dbo.Pry_Objetivos", t => t.IDOBJETIVO, cascadeDelete: true)
            //    .Index(t => t.IDOBJETIVO)
            //    .Index(t => new { t.IDPERIODO, t.IDPROYECTO });
            
            //CreateTable(
            //    "dbo.PRY_EVALUACIONPROYECTOPERIODO",
            //    c => new
            //        {
            //            IDPERIODO = c.Long(nullable: false),
            //            IDPROYECTO = c.Int(nullable: false),
            //            DATOSFINANCIEROS = c.String(maxLength: 2000),
            //            OBSERVACIONES = c.String(maxLength: 2000),
            //            RECOMENDACIONES = c.String(maxLength: 2000),
            //            IdTenant = c.Int(nullable: false),
            //        })
            //    .PrimaryKey(t => new { t.IDPERIODO, t.IDPROYECTO })
            //    .ForeignKey("dbo.PRY_PERIODOSPROYECTOS", t => t.IDPERIODO, cascadeDelete: true)
            //    .ForeignKey("dbo.Pry_Proyectos", t => t.IDPROYECTO, cascadeDelete: true)
            //    .Index(t => t.IDPERIODO)
            //    .Index(t => t.IDPROYECTO);
            
            //CreateTable(
            //    "dbo.PRY_PERIODOSPROYECTOS",
            //    c => new
            //        {
            //            IdPeriodo = c.Long(nullable: false, identity: true),
            //            Nombre = c.String(nullable: false, maxLength: 50),
            //            FechaInicio = c.DateTime(nullable: false),
            //            FechaFin = c.DateTime(nullable: false),
            //            IdProyecto = c.Int(),
            //            Activo = c.Boolean(nullable: false),
            //            Secuencia = c.Int(nullable: false),
            //            IdTenant = c.Int(nullable: false),
            //        })
            //    .PrimaryKey(t => t.IdPeriodo)
            //    .ForeignKey("dbo.Pry_Proyectos", t => t.IdProyecto)
            //    .Index(t => t.IdProyecto);
            
            //CreateTable(
            //    "dbo.Pry_DatosMuestras",
            //    c => new
            //        {
            //            IdDatosMuestra = c.Int(nullable: false, identity: true),
            //            IdIndicador = c.Int(),
            //            Fecha = c.DateTime(),
            //            Logro = c.Double(),
            //            Observaciones = c.String(maxLength: 500),
            //            Efectividad = c.Double(),
            //            IdNivelAceptacionEfectividad = c.Int(),
            //            Eficacia = c.Double(),
            //            IdNivelAceptacionEficacia = c.Int(),
            //            IdPeriodo = c.Long(),
            //            USUARIOCREACION = c.String(maxLength: 256),
            //            FECHACREACION = c.DateTime(),
            //            USUARIOMODIFICACION = c.String(maxLength: 256),
            //            FECHAMODIFICACION = c.DateTime(),
            //            IdTenant = c.Int(nullable: false),
            //        })
            //    .PrimaryKey(t => t.IdDatosMuestra)
            //    .ForeignKey("dbo.Pry_Indicadores", t => t.IdIndicador)
            //    .ForeignKey("dbo.Pry_NivelAceptacion", t => t.IdNivelAceptacionEfectividad)
            //    .ForeignKey("dbo.PRY_PERIODOSPROYECTOS", t => t.IdPeriodo)
            //    .Index(t => t.IdIndicador)
            //    .Index(t => t.IdNivelAceptacionEfectividad)
            //    .Index(t => t.IdPeriodo);
            
            //CreateTable(
            //    "dbo.Pry_DatosVariables",
            //    c => new
            //        {
            //            IdDatosMuestra = c.Int(nullable: false),
            //            IdVariable = c.Int(nullable: false),
            //            Valor = c.Double(),
            //            IdTenant = c.Int(nullable: false),
            //        })
            //    .PrimaryKey(t => new { t.IdDatosMuestra, t.IdVariable })
            //    .ForeignKey("dbo.Pry_DatosMuestras", t => t.IdDatosMuestra, cascadeDelete: true)
            //    .ForeignKey("dbo.Pry_Variables", t => t.IdVariable, cascadeDelete: true)
            //    .Index(t => t.IdDatosMuestra)
            //    .Index(t => t.IdVariable);
            
            //CreateTable(
            //    "dbo.Pry_Variables",
            //    c => new
            //        {
            //            IdVariable = c.Int(nullable: false, identity: true),
            //            Nombre = c.String(maxLength: 50),
            //            FuenteInformacion = c.String(maxLength: 250),
            //            IdTenant = c.Int(nullable: false),
            //        })
            //    .PrimaryKey(t => t.IdVariable);
            
            //CreateTable(
            //    "dbo.Pry_Indicadores_Variables",
            //    c => new
            //        {
            //            IdIndicador = c.Int(nullable: false),
            //            IdVariable = c.Int(nullable: false),
            //            IdTenant = c.Int(nullable: false),
            //        })
            //    .PrimaryKey(t => new { t.IdIndicador, t.IdVariable })
            //    .ForeignKey("dbo.Pry_Indicadores", t => t.IdVariable, cascadeDelete: true)
            //    .ForeignKey("dbo.Pry_Variables", t => t.IdIndicador, cascadeDelete: true)
            //    .Index(t => t.IdIndicador)
            //    .Index(t => t.IdVariable);
            
            //CreateTable(
            //    "dbo.Pry_Indicadores",
            //    c => new
            //        {
            //            IdIndicador = c.Int(nullable: false, identity: true),
            //            IdObjetivo = c.Int(),
            //            Codigo = c.String(maxLength: 50),
            //            IdTipo = c.Int(nullable: false),
            //            IdSubTipo = c.Int(nullable: false),
            //            Descripcion = c.String(nullable: false, maxLength: 2000),
            //            Definicion = c.String(maxLength: 500),
            //            Objetivo = c.String(maxLength: 500),
            //            Cualidades = c.String(maxLength: 500),
            //            UnidadMedida = c.String(maxLength: 250),
            //            Cobertura = c.String(maxLength: 250),
            //            IdResponsableIndicador = c.Int(),
            //            UnidadOperativa = c.String(maxLength: 500),
            //            UnidadOperativaId = c.String(maxLength: 500),
            //            FechaInicio = c.DateTime(),
            //            FechaFin = c.DateTime(),
            //            Base = c.Double(nullable: false),
            //            Meta = c.Double(nullable: false),
            //            Porcentual = c.Boolean(nullable: false),
            //            Ponderado = c.Double(),
            //            IdDatosMuestra = c.Int(),
            //            EfectividadNotificada = c.Boolean(nullable: false),
            //            PalabrasClave = c.String(),
            //            IdPeriodo = c.Long(),
            //            IdTenant = c.Int(nullable: false),
            //        })
            //    .PrimaryKey(t => t.IdIndicador)
            //    .ForeignKey("dbo.Org_Empleados", t => t.IdResponsableIndicador)
            //    .ForeignKey("dbo.Pry_IndicadoresTipos", t => t.IdSubTipo, cascadeDelete: true)
            //    .ForeignKey("dbo.Pry_IndicadoresTipos", t => t.IdTipo, cascadeDelete: true)
            //    .Index(t => t.IdTipo)
            //    .Index(t => t.IdSubTipo)
            //    .Index(t => t.IdResponsableIndicador);
            
            //CreateTable(
            //    "dbo.Pry_EvaluacionHitos",
            //    c => new
            //        {
            //            IdProyecto = c.Int(nullable: false),
            //            IdPeriodo = c.Long(nullable: false),
            //            IdResultado = c.Int(nullable: false),
            //            IdActividad = c.Int(nullable: false),
            //            IdHito = c.Int(nullable: false),
            //            HitoEfectividad = c.Decimal(precision: 18, scale: 2),
            //            ObservacionED = c.String(maxLength: 2000),
            //            ADH = c.Decimal(precision: 18, scale: 2),
            //            CV = c.Decimal(precision: 18, scale: 2),
            //            ObservacionUrip = c.String(maxLength: 2000),
            //            IdTenant = c.Int(nullable: false),
            //        })
            //    .PrimaryKey(t => new { t.IdProyecto, t.IdPeriodo, t.IdResultado, t.IdActividad, t.IdHito })
            //    .ForeignKey("dbo.Pry_Indicadores", t => t.IdHito, cascadeDelete: true)
            //    .ForeignKey("dbo.Pry_Objetivos", t => t.IdResultado, cascadeDelete: true)
            //    .ForeignKey("dbo.Pry_Objetivos", t => t.IdActividad, cascadeDelete: true)
            //    .ForeignKey("dbo.PRY_PERIODOSPROYECTOS", t => t.IdPeriodo, cascadeDelete: true)
            //    .ForeignKey("dbo.Pry_Proyectos", t => t.IdProyecto, cascadeDelete: true)
            //    .Index(t => t.IdProyecto)
            //    .Index(t => t.IdPeriodo)
            //    .Index(t => t.IdResultado)
            //    .Index(t => t.IdActividad)
            //    .Index(t => t.IdHito);
            
            //CreateTable(
            //    "dbo.PRY_EVALUACIONINDICADORESPERIODO",
            //    c => new
            //        {
            //            IdProyecto = c.Int(nullable: false),
            //            IdPeriodo = c.Long(nullable: false),
            //            IdResultado = c.Int(nullable: false),
            //            IdHito = c.Int(nullable: false),
            //            HitoEfectividad = c.Decimal(precision: 18, scale: 2),
            //            ObservacionED = c.String(maxLength: 2000),
            //            ADH = c.Decimal(precision: 18, scale: 2),
            //            CV = c.Decimal(precision: 18, scale: 2),
            //            ObservacionUrip = c.String(maxLength: 2000),
            //            IdTenant = c.Int(nullable: false),
            //        })
            //    .PrimaryKey(t => new { t.IdProyecto, t.IdPeriodo, t.IdResultado, t.IdHito })
            //    .ForeignKey("dbo.Pry_Indicadores", t => t.IdHito, cascadeDelete: true)
            //    .ForeignKey("dbo.Pry_Objetivos", t => t.IdResultado, cascadeDelete: true)
            //    .ForeignKey("dbo.PRY_PERIODOSPROYECTOS", t => t.IdPeriodo, cascadeDelete: true)
            //    .ForeignKey("dbo.Pry_Proyectos", t => t.IdProyecto, cascadeDelete: true)
            //    .Index(t => t.IdProyecto)
            //    .Index(t => t.IdPeriodo)
            //    .Index(t => t.IdResultado)
            //    .Index(t => t.IdHito);
            
            //CreateTable(
            //    "dbo.Pry_IndicadoresProyecto_Programa",
            //    c => new
            //        {
            //            IdIndicadorProyecto = c.Int(nullable: false),
            //            IdIndicadorPrograma = c.Int(nullable: false),
            //            IdTenant = c.Int(nullable: false),
            //        })
            //    .PrimaryKey(t => new { t.IdIndicadorProyecto, t.IdIndicadorPrograma })
            //    .ForeignKey("dbo.Pry_Indicadores", t => t.IdIndicadorProyecto, cascadeDelete: true)
            //    .Index(t => t.IdIndicadorProyecto);
            
            //CreateTable(
            //    "dbo.Pry_IndicadoresTipos",
            //    c => new
            //        {
            //            IdTipo = c.Int(nullable: false),
            //            Descripcion = c.String(nullable: false, maxLength: 500),
            //            IdPadre = c.Int(),
            //            Myme = c.String(maxLength: 2),
            //            IdTenant = c.Int(nullable: false),
            //        })
            //    .PrimaryKey(t => t.IdTipo);
            
            //CreateTable(
            //    "dbo.Pry_IndicadoresVerificadores",
            //    c => new
            //        {
            //            IdVerificador = c.Int(nullable: false, identity: true),
            //            IdIndicador = c.Int(nullable: false),
            //            Descripcion = c.String(nullable: false, maxLength: 500),
            //            IdTenant = c.Int(nullable: false),
            //        })
            //    .PrimaryKey(t => t.IdVerificador)
            //    .ForeignKey("dbo.Pry_Indicadores", t => t.IdIndicador, cascadeDelete: true)
            //    .Index(t => t.IdIndicador);
            
            //CreateTable(
            //    "dbo.Pry_DatosVerificadores",
            //    c => new
            //        {
            //            IdDatosFuentes = c.Int(nullable: false, identity: true),
            //            IdDatosMuestra = c.Int(),
            //            IdVerificador = c.Int(),
            //            Url = c.String(maxLength: 250),
            //            IdTenant = c.Int(nullable: false),
            //        })
            //    .PrimaryKey(t => t.IdDatosFuentes)
            //    .ForeignKey("dbo.Pry_DatosMuestras", t => t.IdDatosMuestra)
            //    .ForeignKey("dbo.Pry_IndicadoresVerificadores", t => t.IdVerificador)
            //    .Index(t => t.IdDatosMuestra)
            //    .Index(t => t.IdVerificador);
            
            //CreateTable(
            //    "dbo.Pry_Informes_Indicador",
            //    c => new
            //        {
            //            IdInforme = c.Int(nullable: false),
            //            IdIndicador = c.Int(nullable: false),
            //            Meta = c.Double(),
            //            IdDatosMuestra = c.Int(),
            //            Evaluacion = c.Int(),
            //            IdTenant = c.Int(nullable: false),
            //        })
            //    .PrimaryKey(t => new { t.IdInforme, t.IdIndicador })
            //    .ForeignKey("dbo.Pry_DatosMuestras", t => t.IdDatosMuestra)
            //    .ForeignKey("dbo.Pry_Indicadores", t => t.IdIndicador, cascadeDelete: true)
            //    .ForeignKey("dbo.Pry_Informes", t => t.IdInforme, cascadeDelete: true)
            //    .ForeignKey("dbo.Pry_NivelAceptacion", t => t.Evaluacion)
            //    .Index(t => t.IdInforme)
            //    .Index(t => t.IdIndicador)
            //    .Index(t => t.IdDatosMuestra)
            //    .Index(t => t.Evaluacion);
            
            //CreateTable(
            //    "dbo.Pry_Informes",
            //    c => new
            //        {
            //            IdInforme = c.Int(nullable: false, identity: true),
            //            IdProyecto = c.Int(),
            //            Descripcion = c.String(maxLength: 500),
            //            FechaProgramada = c.DateTime(),
            //            FechaInforme = c.DateTime(),
            //            PresupuestoMeta = c.Double(),
            //            PresupuestoEjecutado = c.Double(),
            //            AvanceMeta = c.Double(),
            //            AvanceEjecutado = c.Double(),
            //            DescripcionSupuestos = c.String(),
            //            Informe = c.String(),
            //            EvaluacionComponentes = c.Int(),
            //            EvaluacionComponentesDes = c.String(),
            //            EvaluacionProposito = c.Int(),
            //            EvaluacionPropositoDes = c.String(),
            //            Lecciones = c.String(),
            //            Acciones = c.String(),
            //            IdEstado = c.Int(),
            //            IdEstadoNotificado = c.Boolean(),
            //            IdTenant = c.Int(nullable: false),
            //        })
            //    .PrimaryKey(t => t.IdInforme)
            //    .ForeignKey("dbo.Pry_InformesEstados", t => t.IdEstado)
            //    .ForeignKey("dbo.Pry_NivelAceptacion", t => t.EvaluacionProposito)
            //    .ForeignKey("dbo.Pry_NivelAceptacion", t => t.EvaluacionComponentes)
            //    .ForeignKey("dbo.Pry_Proyectos", t => t.IdProyecto)
            //    .Index(t => t.IdProyecto)
            //    .Index(t => t.EvaluacionComponentes)
            //    .Index(t => t.EvaluacionProposito)
            //    .Index(t => t.IdEstado);
            
            //CreateTable(
            //    "dbo.Pry_Informes_Donantes",
            //    c => new
            //        {
            //            IdInforme = c.Int(nullable: false),
            //            IdDonante = c.Int(nullable: false),
            //            Donacion = c.Double(),
            //            FechaPrimeraDonacion = c.DateTime(),
            //            FechaUltimaDonacion = c.DateTime(),
            //            IdTenant = c.Int(nullable: false),
            //        })
            //    .PrimaryKey(t => new { t.IdInforme, t.IdDonante })
            //    .ForeignKey("dbo.Org_Donantes", t => t.IdDonante, cascadeDelete: true)
            //    .ForeignKey("dbo.Pry_Informes", t => t.IdInforme, cascadeDelete: true)
            //    .Index(t => t.IdInforme)
            //    .Index(t => t.IdDonante);
            
            //CreateTable(
            //    "dbo.Pry_Informes_Encuestas",
            //    c => new
            //        {
            //            IdInforme = c.Int(nullable: false),
            //            IdPregunta = c.Int(nullable: false),
            //            Respuesta = c.Boolean(),
            //            Descripcion = c.String(maxLength: 250),
            //            IdTenant = c.Int(nullable: false),
            //        })
            //    .PrimaryKey(t => new { t.IdInforme, t.IdPregunta })
            //    .ForeignKey("dbo.M_Preguntas", t => t.IdPregunta, cascadeDelete: true)
            //    .ForeignKey("dbo.Pry_Informes", t => t.IdInforme, cascadeDelete: true)
            //    .Index(t => t.IdInforme)
            //    .Index(t => t.IdPregunta);
            
            //CreateTable(
            //    "dbo.M_Preguntas",
            //    c => new
            //        {
            //            IdPregunta = c.Int(nullable: false, identity: true),
            //            IdEncuesta = c.Int(),
            //            Pregunta = c.String(),
            //            Tipo = c.Int(),
            //            Orden = c.Int(),
            //            IdTenant = c.Int(nullable: false),
            //        })
            //    .PrimaryKey(t => t.IdPregunta)
            //    .ForeignKey("dbo.M_Encuestas", t => t.IdEncuesta)
            //    .Index(t => t.IdEncuesta);
            
            //CreateTable(
            //    "dbo.M_Encuestas",
            //    c => new
            //        {
            //            IdEncuesta = c.Int(nullable: false, identity: true),
            //            Titulo = c.String(maxLength: 50),
            //            Descripcion = c.String(maxLength: 100),
            //            FechaCreacion = c.DateTime(),
            //            IdIdioma = c.Int(),
            //            Estado = c.String(maxLength: 1),
            //            IdTenant = c.Int(nullable: false),
            //        })
            //    .PrimaryKey(t => t.IdEncuesta)
            //    .ForeignKey("dbo.M_Idiomas", t => t.IdIdioma)
            //    .Index(t => t.IdIdioma);
            
            //CreateTable(
            //    "dbo.M_EncuestasResueltas",
            //    c => new
            //        {
            //            IdEncuestaResuelta = c.Int(nullable: false, identity: true),
            //            IdEncuesta = c.Int(),
            //            Usuario = c.String(maxLength: 100),
            //            Fecha = c.DateTime(),
            //            Comentarios = c.String(),
            //            IdTenant = c.Int(nullable: false),
            //        })
            //    .PrimaryKey(t => t.IdEncuestaResuelta)
            //    .ForeignKey("dbo.M_Encuestas", t => t.IdEncuesta)
            //    .Index(t => t.IdEncuesta);
            
            //CreateTable(
            //    "dbo.M_PreguntasResueltas",
            //    c => new
            //        {
            //            IdPreguntaResuelta = c.Int(nullable: false, identity: true),
            //            IdEncuestaResuelta = c.Int(),
            //            IdPregunta = c.Int(),
            //            TextoRespuesta = c.String(),
            //            IdTenant = c.Int(nullable: false),
            //        })
            //    .PrimaryKey(t => t.IdPreguntaResuelta)
            //    .ForeignKey("dbo.M_EncuestasResueltas", t => t.IdEncuestaResuelta)
            //    .ForeignKey("dbo.M_Preguntas", t => t.IdPregunta)
            //    .Index(t => t.IdEncuestaResuelta)
            //    .Index(t => t.IdPregunta);
            
            //CreateTable(
            //    "dbo.M_ValoresRespuesta",
            //    c => new
            //        {
            //            IdValorRespuesta = c.Int(nullable: false, identity: true),
            //            IdPreguntaResuelta = c.Int(),
            //            Valor = c.String(maxLength: 50),
            //            IdTenant = c.Int(nullable: false),
            //        })
            //    .PrimaryKey(t => t.IdValorRespuesta)
            //    .ForeignKey("dbo.M_PreguntasResueltas", t => t.IdPreguntaResuelta)
            //    .Index(t => t.IdPreguntaResuelta);
            
            //CreateTable(
            //    "dbo.M_Idiomas",
            //    c => new
            //        {
            //            IdIdioma = c.Int(nullable: false, identity: true),
            //            Nombre = c.String(nullable: false, maxLength: 50),
            //            Mime = c.String(maxLength: 8),
            //        })
            //    .PrimaryKey(t => t.IdIdioma);
            
            //CreateTable(
            //    "dbo.M_PosiblesRespuestas",
            //    c => new
            //        {
            //            IdPosibleRespuesta = c.Int(nullable: false, identity: true),
            //            Respuesta = c.String(),
            //            IdPregunta = c.Int(),
            //            IdTenant = c.Int(nullable: false),
            //        })
            //    .PrimaryKey(t => t.IdPosibleRespuesta)
            //    .ForeignKey("dbo.M_Preguntas", t => t.IdPregunta)
            //    .Index(t => t.IdPregunta);
            
            //CreateTable(
            //    "dbo.Pry_Informes_Presupuestos",
            //    c => new
            //        {
            //            IdInforme = c.Int(nullable: false),
            //            IdPresupuesto = c.Int(nullable: false),
            //            Ejecutado = c.Double(),
            //            Utilizacion = c.Double(),
            //            Evaluacion = c.Int(),
            //            IdTenant = c.Int(nullable: false),
            //        })
            //    .PrimaryKey(t => new { t.IdInforme, t.IdPresupuesto })
            //    .ForeignKey("dbo.Pry_Informes", t => t.IdInforme, cascadeDelete: true)
            //    .ForeignKey("dbo.Pry_NivelAceptacion", t => t.Evaluacion)
            //    .ForeignKey("dbo.Pry_Presupuesto", t => t.IdPresupuesto, cascadeDelete: true)
            //    .Index(t => t.IdInforme)
            //    .Index(t => t.IdPresupuesto)
            //    .Index(t => t.Evaluacion);
            
            //CreateTable(
            //    "dbo.Pry_NivelAceptacion",
            //    c => new
            //        {
            //            IdNivelAceptacion = c.Int(nullable: false, identity: true),
            //            Nombre = c.String(nullable: false, maxLength: 10),
            //            Descripcion = c.String(maxLength: 100),
            //            Color = c.String(maxLength: 15),
            //            IdTenant = c.Int(nullable: false),
            //        })
            //    .PrimaryKey(t => t.IdNivelAceptacion);
            
            //CreateTable(
            //    "dbo.Pry_Proyectos_NivelAceptacion",
            //    c => new
            //        {
            //            IdProyecto = c.Int(nullable: false),
            //            IdNivelAceptacion = c.Int(nullable: false),
            //            Valor = c.Double(nullable: false),
            //            IdTenant = c.Int(nullable: false),
            //        })
            //    .PrimaryKey(t => new { t.IdProyecto, t.IdNivelAceptacion })
            //    .ForeignKey("dbo.Pry_NivelAceptacion", t => t.IdNivelAceptacion, cascadeDelete: true)
            //    .ForeignKey("dbo.Pry_Proyectos", t => t.IdProyecto, cascadeDelete: true)
            //    .Index(t => t.IdProyecto)
            //    .Index(t => t.IdNivelAceptacion);
            
            //CreateTable(
            //    "dbo.Pry_Presupuesto",
            //    c => new
            //        {
            //            IdPresupuesto = c.Int(nullable: false, identity: true),
            //            IdTipoPresupuesto = c.Int(),
            //            IdObjetivo = c.Int(),
            //            IdProyecto = c.Int(),
            //            Monto = c.Double(),
            //            IdDonante = c.Int(),
            //            UsuarioCreacion = c.String(nullable: false, maxLength: 256),
            //            FechaCreacion = c.DateTime(nullable: false),
            //            UsuarioModificacion = c.String(maxLength: 256),
            //            FechaModificacion = c.DateTime(),
            //            IdTenant = c.Int(nullable: false),
            //        })
            //    .PrimaryKey(t => t.IdPresupuesto)
            //    .ForeignKey("dbo.Pry_PresupuestoTipo", t => t.IdTipoPresupuesto)
            //    .ForeignKey("dbo.Pry_Proyectos", t => t.IdProyecto)
            //    .Index(t => t.IdTipoPresupuesto)
            //    .Index(t => t.IdProyecto);
            
            //CreateTable(
            //    "dbo.Pry_PresupuestoTipo",
            //    c => new
            //        {
            //            IdTipo = c.Int(nullable: false, identity: true),
            //            Descripcion = c.String(maxLength: 50),
            //            IdTenant = c.Int(nullable: false),
            //        })
            //    .PrimaryKey(t => t.IdTipo);
            
            //CreateTable(
            //    "dbo.Pry_Informes_Supuestos",
            //    c => new
            //        {
            //            IdInforme = c.Int(nullable: false),
            //            IdSupuesto = c.Int(nullable: false),
            //            Valor = c.Boolean(nullable: false),
            //            Tipo = c.String(maxLength: 15),
            //            IdTenant = c.Int(nullable: false),
            //        })
            //    .PrimaryKey(t => new { t.IdInforme, t.IdSupuesto })
            //    .ForeignKey("dbo.Pry_Informes", t => t.IdInforme, cascadeDelete: true)
            //    .ForeignKey("dbo.Pry_Supuestos", t => t.IdSupuesto, cascadeDelete: true)
            //    .Index(t => t.IdInforme)
            //    .Index(t => t.IdSupuesto);
            
            //CreateTable(
            //    "dbo.Pry_Supuestos",
            //    c => new
            //        {
            //            IdSupuesto = c.Int(nullable: false, identity: true),
            //            IdObjetivo = c.Int(),
            //            Descripcion = c.String(nullable: false, maxLength: 2000),
            //            Impacto = c.Boolean(),
            //            PlanContingencia = c.String(maxLength: 250),
            //            IdTenant = c.Int(nullable: false),
            //        })
            //    .PrimaryKey(t => t.IdSupuesto)
            //    .ForeignKey("dbo.Pry_Objetivos", t => t.IdObjetivo)
            //    .Index(t => t.IdObjetivo);
            
            //CreateTable(
            //    "dbo.Pry_InformesEstados",
            //    c => new
            //        {
            //            IdEstado = c.Int(nullable: false, identity: true),
            //            Descripcion = c.String(nullable: false, maxLength: 250),
            //            IdTenant = c.Int(nullable: false),
            //        })
            //    .PrimaryKey(t => t.IdEstado);
            
            //CreateTable(
            //    "dbo.PRY_INFORMESICAINDICADORES",
            //    c => new
            //        {
            //            IDINFORME = c.Int(nullable: false),
            //            IDINDICADOR = c.Int(nullable: false),
            //            LOGROS = c.String(maxLength: 4000),
            //            IdTenant = c.Int(nullable: false),
            //        })
            //    .PrimaryKey(t => new { t.IDINFORME, t.IDINDICADOR })
            //    .ForeignKey("dbo.Pry_Indicadores", t => t.IDINDICADOR, cascadeDelete: true)
            //    .ForeignKey("dbo.PRY_INFORMESICA", t => t.IDINFORME, cascadeDelete: true)
            //    .Index(t => t.IDINFORME)
            //    .Index(t => t.IDINDICADOR);
            
            //CreateTable(
            //    "dbo.PRY_INFORMESICA",
            //    c => new
            //        {
            //            IDINFORME = c.Int(nullable: false, identity: true),
            //            IDPROYECTO = c.Int(nullable: false),
            //            IDTIPO = c.Int(nullable: false),
            //            FECHA = c.DateTime(nullable: false),
            //            IDESTADO = c.Int(nullable: false),
            //            PERIODOINICIAL = c.Long(nullable: false),
            //            PERIODOFINAL = c.Long(nullable: false),
            //            IdTenant = c.Int(nullable: false),
            //        })
            //    .PrimaryKey(t => t.IDINFORME)
            //    .ForeignKey("dbo.PRY_INFORMESICAESTADOS", t => t.IDESTADO, cascadeDelete: true)
            //    .ForeignKey("dbo.PRY_INFORMESICATIPOS", t => t.IDTIPO, cascadeDelete: true)
            //    .ForeignKey("dbo.PRY_PERIODOSPROYECTOS", t => t.PERIODOINICIAL, cascadeDelete: true)
            //    .ForeignKey("dbo.PRY_PERIODOSPROYECTOS", t => t.PERIODOFINAL, cascadeDelete: true)
            //    .ForeignKey("dbo.Pry_Proyectos", t => t.IDPROYECTO, cascadeDelete: true)
            //    .Index(t => t.IDPROYECTO)
            //    .Index(t => t.IDTIPO)
            //    .Index(t => t.IDESTADO)
            //    .Index(t => t.PERIODOINICIAL)
            //    .Index(t => t.PERIODOFINAL);
            
            //CreateTable(
            //    "dbo.PRY_INFORMESICADETALLE",
            //    c => new
            //        {
            //            IDDETALLE = c.Int(nullable: false, identity: true),
            //            IDINFORME = c.Int(nullable: false),
            //            DATOSFINANCIEROS = c.String(maxLength: 4000),
            //            OBSERVACIONES = c.String(maxLength: 4000),
            //            LOGROSPRINCIPALES = c.String(maxLength: 4000),
            //            PROBLEMASYACCIONES = c.String(maxLength: 4000),
            //            SUPUESTOS = c.String(maxLength: 4000),
            //            RECOMENDACIONES = c.String(maxLength: 4000),
            //            FACTORESEXITO = c.String(maxLength: 4000),
            //            FACTORESLIMITANTES = c.String(maxLength: 4000),
            //            CONDICIONALIDAD = c.String(maxLength: 4000),
            //            SOSTENIBILIDAD = c.String(maxLength: 4000),
            //            EFICACIAPROYECTO = c.String(maxLength: 4000),
            //            EFICACIARESULTADOS = c.String(maxLength: 4000),
            //            RELEVANCIAOBJETIVOS = c.String(maxLength: 4000),
            //            RELEVANCIAEXTERNA = c.String(maxLength: 4000),
            //            SOSTENIBILIDADBENEFICIOS = c.String(maxLength: 4000),
            //            SOSTENIBILIDADCAPACIDADES = c.String(maxLength: 4000),
            //            SOSTENIBILIDADPERTENECIA = c.String(maxLength: 4000),
            //            SOSTENIBILIDADOREPLICAS = c.String(maxLength: 4000),
            //            IMPACTOOBJETIVOS = c.String(maxLength: 4000),
            //            IMPACTOGENERAL = c.String(maxLength: 4000),
            //            IMPACTOALIANZAS = c.String(maxLength: 4000),
            //            IMPACTODIALOGO = c.String(maxLength: 4000),
            //            IdTenant = c.Int(nullable: false),
            //        })
            //    .PrimaryKey(t => t.IDDETALLE)
            //    .ForeignKey("dbo.PRY_INFORMESICA", t => t.IDINFORME, cascadeDelete: true)
            //    .Index(t => t.IDINFORME);
            
            //CreateTable(
            //    "dbo.PRY_INFORMESICADOCUMENTOS",
            //    c => new
            //        {
            //            IDDOCUMENTO = c.Guid(nullable: false),
            //            IDINFORME = c.Int(nullable: false),
            //            DESCRIPCION = c.String(maxLength: 250),
            //            URL = c.String(nullable: false, maxLength: 500),
            //            NOMBRE = c.String(nullable: false, maxLength: 250),
            //            TIPO = c.Int(nullable: false),
            //            IdTenant = c.Int(nullable: false),
            //        })
            //    .PrimaryKey(t => t.IDDOCUMENTO)
            //    .ForeignKey("dbo.PRY_INFORMESICA", t => t.IDINFORME, cascadeDelete: true)
            //    .Index(t => t.IDINFORME);
            
            //CreateTable(
            //    "dbo.PRY_INFORMESICAESTADOS",
            //    c => new
            //        {
            //            IDESTADO = c.Int(nullable: false, identity: true),
            //            DESCRIPCION = c.String(maxLength: 50),
            //            IdTenant = c.Int(nullable: false),
            //        })
            //    .PrimaryKey(t => t.IDESTADO);
            
            //CreateTable(
            //    "dbo.PRY_INFORMESICAOBJETIVOS",
            //    c => new
            //        {
            //            IDINFORME = c.Int(nullable: false),
            //            IDOBJETIVO = c.Int(nullable: false),
            //            LOGROS = c.String(maxLength: 4000),
            //            IdTenant = c.Int(nullable: false),
            //        })
            //    .PrimaryKey(t => new { t.IDINFORME, t.IDOBJETIVO })
            //    .ForeignKey("dbo.PRY_INFORMESICA", t => t.IDINFORME, cascadeDelete: true)
            //    .ForeignKey("dbo.Pry_Objetivos", t => t.IDOBJETIVO, cascadeDelete: true)
            //    .Index(t => t.IDINFORME)
            //    .Index(t => t.IDOBJETIVO);
            
            //CreateTable(
            //    "dbo.PRY_INFORMESICATIPOS",
            //    c => new
            //        {
            //            IDTIPO = c.Int(nullable: false, identity: true),
            //            DESCRIPCION = c.String(maxLength: 50),
            //            IdTenant = c.Int(nullable: false),
            //        })
            //    .PrimaryKey(t => t.IDTIPO);
            
            //CreateTable(
            //    "dbo.Pry_ObjetivosClase",
            //    c => new
            //        {
            //            IdObjetivoClase = c.Int(nullable: false, identity: true),
            //            Descripcion = c.String(maxLength: 50),
            //            IdTenant = c.Int(nullable: false),
            //        })
            //    .PrimaryKey(t => t.IdObjetivoClase);
            
            //CreateTable(
            //    "dbo.Pry_Bitacoras",
            //    c => new
            //        {
            //            IdBitacora = c.Int(nullable: false, identity: true),
            //            IdProyecto = c.Int(),
            //            Titulo = c.String(maxLength: 250),
            //            Text = c.String(),
            //            Url = c.String(maxLength: 250),
            //            UsuarioCreacion = c.String(nullable: false, maxLength: 256),
            //            FechaCreacion = c.DateTime(nullable: false),
            //            UsuarioModificacion = c.String(maxLength: 256),
            //            FechaModificacion = c.DateTime(),
            //            IdTenant = c.Int(nullable: false),
            //        })
            //    .PrimaryKey(t => t.IdBitacora)
            //    .ForeignKey("dbo.Pry_Proyectos", t => t.IdProyecto)
            //    .Index(t => t.IdProyecto);
            
            //CreateTable(
            //    "dbo.Pry_Proyectos_Donantes",
            //    c => new
            //        {
            //            IdProyecto = c.Int(nullable: false),
            //            IdDonante = c.Int(nullable: false),
            //            IdUsuarioResponsable = c.Int(),
            //            Monto = c.Double(),
            //            UsuarioCreacion = c.String(nullable: false, maxLength: 256),
            //            FechaCreacion = c.DateTime(nullable: false),
            //            UsuarioModificacion = c.String(maxLength: 256),
            //            FechaModificacion = c.DateTime(),
            //            IdTenant = c.Int(nullable: false),
            //        })
            //    .PrimaryKey(t => new { t.IdProyecto, t.IdDonante })
            //    .ForeignKey("dbo.Org_Donantes", t => t.IdDonante, cascadeDelete: true)
            //    .ForeignKey("dbo.Pry_Proyectos", t => t.IdProyecto, cascadeDelete: true)
            //    .ForeignKey("dbo.Sys_Usuarios", t => t.IdUsuarioResponsable)
            //    .Index(t => t.IdProyecto)
            //    .Index(t => t.IdDonante)
            //    .Index(t => t.IdUsuarioResponsable);
            
            //CreateTable(
            //    "dbo.Sys_Usuarios",
            //    c => new
            //        {
            //            IdUsuario = c.Int(nullable: false, identity: true),
            //            UserName = c.String(nullable: false, maxLength: 256),
            //            Nombre = c.String(maxLength: 250),
            //            Correo = c.String(maxLength: 250),
            //            CustomerId = c.Int(),
            //            UserReport = c.String(nullable: false, maxLength: 256),
            //            idEmpresa = c.Int(nullable: false),
            //            IdTenant = c.Int(nullable: false),
            //        })
            //    .PrimaryKey(t => t.IdUsuario);
            
            //CreateTable(
            //    "dbo.Com_Mensajes",
            //    c => new
            //        {
            //            IdMensaje = c.Int(nullable: false, identity: true),
            //            IdUsuarioRemitente = c.Int(nullable: false),
            //            IdUsuarioDestinatario = c.Int(nullable: false),
            //            IdEstado = c.Int(nullable: false),
            //            Asunto = c.String(nullable: false, maxLength: 100),
            //            Mensaje = c.String(nullable: false),
            //            Prioridad = c.Boolean(nullable: false),
            //            FechaEnvio = c.DateTime(nullable: false),
            //            FechaLectura = c.DateTime(),
            //            FechaBorrado = c.DateTime(),
            //            IdTenant = c.Int(nullable: false),
            //        })
            //    .PrimaryKey(t => t.IdMensaje)
            //    .ForeignKey("dbo.Com_MensajesEstado", t => t.IdEstado, cascadeDelete: true)
            //    .ForeignKey("dbo.Sys_Usuarios", t => t.IdUsuarioRemitente, cascadeDelete: true)
            //    .Index(t => t.IdUsuarioRemitente)
            //    .Index(t => t.IdEstado);
            
            //CreateTable(
            //    "dbo.Com_MensajesEstado",
            //    c => new
            //        {
            //            IdEstado = c.Int(nullable: false, identity: true),
            //            Nombre = c.String(nullable: false, maxLength: 50),
            //            Observaciones = c.String(maxLength: 100),
            //            IdTenant = c.Int(nullable: false),
            //        })
            //    .PrimaryKey(t => t.IdEstado);
            
            //CreateTable(
            //    "dbo.Tar_Bitacora",
            //    c => new
            //        {
            //            IdBitacora = c.Int(nullable: false, identity: true),
            //            IdVisita = c.Int(),
            //            Comentario = c.String(),
            //            FechaRegistro = c.DateTime(),
            //            IdUsuario = c.Int(),
            //            IdTenant = c.Int(nullable: false),
            //        })
            //    .PrimaryKey(t => t.IdBitacora)
            //    .ForeignKey("dbo.Sys_Usuarios", t => t.IdUsuario)
            //    .ForeignKey("dbo.Tar_Visitas", t => t.IdVisita)
            //    .Index(t => t.IdVisita)
            //    .Index(t => t.IdUsuario);
            
            //CreateTable(
            //    "dbo.Tar_Visitas",
            //    c => new
            //        {
            //            IdVisita = c.Int(nullable: false, identity: true),
            //            IdTarea = c.Int(),
            //            Fecha = c.DateTime(),
            //            Descripcion = c.String(maxLength: 1000),
            //            Ubicacion = c.String(maxLength: 500),
            //            PersonaContacto = c.String(maxLength: 100),
            //            Latitud = c.Decimal(precision: 18, scale: 2),
            //            Longitud = c.Decimal(precision: 18, scale: 2),
            //            Estado = c.String(maxLength: 1),
            //            IdTenant = c.Int(nullable: false),
            //        })
            //    .PrimaryKey(t => t.IdVisita)
            //    .ForeignKey("dbo.Tar_Tareas", t => t.IdTarea)
            //    .Index(t => t.IdTarea);
            
            //CreateTable(
            //    "dbo.Tar_Permisos_Bitacora",
            //    c => new
            //        {
            //            IdPermisoBitacora = c.Int(nullable: false, identity: true),
            //            IdUsuario = c.Int(),
            //            IdVisita = c.Int(),
            //            Permiso = c.String(maxLength: 50),
            //            IdTenant = c.Int(nullable: false),
            //        })
            //    .PrimaryKey(t => t.IdPermisoBitacora)
            //    .ForeignKey("dbo.Sys_Usuarios", t => t.IdUsuario)
            //    .ForeignKey("dbo.Tar_Visitas", t => t.IdVisita)
            //    .Index(t => t.IdUsuario)
            //    .Index(t => t.IdVisita);
            
            //CreateTable(
            //    "dbo.Tar_Tareas",
            //    c => new
            //        {
            //            Id = c.Int(nullable: false, identity: true),
            //            IdLista = c.Int(),
            //            Descripcion = c.String(maxLength: 2000),
            //            FechaInicio = c.DateTime(),
            //            FechaFin = c.DateTime(),
            //            IdResponsable = c.Int(),
            //            IdUsuarioCreacion = c.Int(),
            //            FechaCreacion = c.DateTime(),
            //            IdUsuarioModificacion = c.Int(),
            //            FechaModificacion = c.DateTime(),
            //            Prioridad = c.Boolean(),
            //            Estado = c.Boolean(),
            //            FechaCompletado = c.DateTime(),
            //            IdUsuarioCompletado = c.Int(),
            //            IdTenant = c.Int(nullable: false),
            //        })
            //    .PrimaryKey(t => t.Id)
            //    .ForeignKey("dbo.Sys_Usuarios", t => t.IdResponsable)
            //    .ForeignKey("dbo.Sys_Usuarios", t => t.IdUsuarioCreacion)
            //    .ForeignKey("dbo.Sys_Usuarios", t => t.IdUsuarioModificacion)
            //    .ForeignKey("dbo.Sys_Usuarios", t => t.IdUsuarioCompletado)
            //    .ForeignKey("dbo.Tar_Listas", t => t.IdLista)
            //    .Index(t => t.IdLista)
            //    .Index(t => t.IdResponsable)
            //    .Index(t => t.IdUsuarioCreacion)
            //    .Index(t => t.IdUsuarioModificacion)
            //    .Index(t => t.IdUsuarioCompletado);
            
            //CreateTable(
            //    "dbo.Documentos_Tareas",
            //    c => new
            //        {
            //            IdDocumento = c.Int(nullable: false),
            //            IdTarea = c.Int(nullable: false),
            //            IdTenant = c.Int(nullable: false),
            //        })
            //    .PrimaryKey(t => new { t.IdDocumento, t.IdTarea })
            //    .ForeignKey("dbo.Doc_Documentos", t => t.IdDocumento, cascadeDelete: true)
            //    .ForeignKey("dbo.Tar_Tareas", t => t.IdTarea, cascadeDelete: true)
            //    .Index(t => t.IdDocumento)
            //    .Index(t => t.IdTarea);
            
            //CreateTable(
            //    "dbo.Doc_Documentos",
            //    c => new
            //        {
            //            IdDocumento = c.Int(nullable: false, identity: true),
            //            IdCategoria = c.Int(nullable: false),
            //            IdTipoArchivo = c.Int(nullable: false),
            //            Titulo = c.String(nullable: false, maxLength: 100),
            //            PalabrasClaves = c.String(nullable: false, maxLength: 256),
            //            Resumen = c.String(nullable: false, maxLength: 500),
            //            Url = c.String(nullable: false, maxLength: 256),
            //            UsuarioCreacion = c.String(nullable: false, maxLength: 256),
            //            FechaCreacion = c.DateTime(nullable: false),
            //            UsuarioModificacion = c.String(maxLength: 256),
            //            FechaModificacion = c.DateTime(),
            //            Roles = c.String(maxLength: 256),
            //            IdTenant = c.Int(nullable: false),
            //        })
            //    .PrimaryKey(t => t.IdDocumento)
            //    .ForeignKey("dbo.Doc_ArchivosTipos", t => t.IdTipoArchivo, cascadeDelete: true)
            //    .ForeignKey("dbo.Doc_Categorias", t => t.IdCategoria, cascadeDelete: true)
            //    .Index(t => t.IdCategoria)
            //    .Index(t => t.IdTipoArchivo);
            
            //CreateTable(
            //    "dbo.Doc_ArchivosTipos",
            //    c => new
            //        {
            //            IdTipoArchivo = c.Int(nullable: false, identity: true),
            //            Nombre = c.String(nullable: false, maxLength: 256),
            //            Mime_Type = c.String(nullable: false, maxLength: 50),
            //            IdTenant = c.Int(nullable: false),
            //        })
            //    .PrimaryKey(t => t.IdTipoArchivo);
            
            //CreateTable(
            //    "dbo.Doc_Categorias",
            //    c => new
            //        {
            //            IdCategoria = c.Int(nullable: false, identity: true),
            //            IdPadre = c.Int(),
            //            Nombre = c.String(nullable: false, maxLength: 50),
            //            Descripcion = c.String(maxLength: 200),
            //            Ruta = c.String(maxLength: 256),
            //            UsuarioCreacion = c.String(nullable: false, maxLength: 256),
            //            FechaCreacion = c.DateTime(nullable: false),
            //            UsuarioModificacion = c.String(maxLength: 256),
            //            FechaModificacion = c.DateTime(),
            //            Estado = c.Boolean(),
            //            IdTipo = c.Int(),
            //            IdEmpresa = c.Int(),
            //            IdTenant = c.Int(nullable: false),
            //        })
            //    .PrimaryKey(t => t.IdCategoria);
            
            //CreateTable(
            //    "dbo.Doc_Clientes_Categorias",
            //    c => new
            //        {
            //            IdCliente = c.Int(nullable: false),
            //            IdCategoria = c.Int(nullable: false),
            //            IdTenant = c.Int(nullable: false),
            //        })
            //    .PrimaryKey(t => new { t.IdCliente, t.IdCategoria })
            //    .ForeignKey("dbo.Doc_Categorias", t => t.IdCategoria, cascadeDelete: true)
            //    .ForeignKey("dbo.Sys_Clientes", t => t.IdCliente, cascadeDelete: true)
            //    .Index(t => t.IdCliente)
            //    .Index(t => t.IdCategoria);
            
            //CreateTable(
            //    "dbo.Sys_Clientes",
            //    c => new
            //        {
            //            Id = c.Int(nullable: false),
            //            Name = c.String(maxLength: 250),
            //            MaxUsers = c.Int(nullable: false),
            //            MaxProjects = c.Int(nullable: false),
            //            MaxStorage = c.Int(nullable: false),
            //            OrderDate = c.DateTime(nullable: false),
            //            ExpirationDate = c.DateTime(nullable: false),
            //            Logo = c.String(maxLength: 250),
            //            Status = c.Boolean(nullable: false),
            //            ContactName = c.String(nullable: false, maxLength: 250),
            //            ContactMail = c.String(nullable: false, maxLength: 50),
            //            ContactAddress = c.String(maxLength: 255),
            //            ContactPhone = c.String(maxLength: 20),
            //            IdTenant = c.Int(nullable: false),
            //        })
            //    .PrimaryKey(t => t.Id);
            
            //CreateTable(
            //    "dbo.Tar_Listas",
            //    c => new
            //        {
            //            Id = c.Int(nullable: false, identity: true),
            //            IdProyecto = c.Int(),
            //            Descripcion = c.String(nullable: false, maxLength: 2000),
            //            IdUsuarioCreacion = c.Int(nullable: false),
            //            FechaCreacion = c.DateTime(nullable: false),
            //            IdUsuarioModificacion = c.Int(),
            //            FechaModificacion = c.DateTime(),
            //            IdPadre = c.Int(),
            //            IdTenant = c.Int(nullable: false),
            //        })
            //    .PrimaryKey(t => t.Id)
            //    .ForeignKey("dbo.Pry_Proyectos", t => t.IdProyecto)
            //    .ForeignKey("dbo.Sys_Usuarios", t => t.IdUsuarioCreacion, cascadeDelete: true)
            //    .ForeignKey("dbo.Sys_Usuarios", t => t.IdUsuarioModificacion)
            //    .Index(t => t.IdProyecto)
            //    .Index(t => t.IdUsuarioCreacion)
            //    .Index(t => t.IdUsuarioModificacion);
            
            //CreateTable(
            //    "dbo.Pry_ProyectosEstados",
            //    c => new
            //        {
            //            IdEstado = c.Int(nullable: false, identity: true),
            //            Descripcion = c.String(maxLength: 50),
            //            IdTenant = c.Int(nullable: false),
            //        })
            //    .PrimaryKey(t => t.IdEstado);
            
            //CreateTable(
            //    "dbo.Pry_ProyectosTipos",
            //    c => new
            //        {
            //            Id = c.Int(nullable: false, identity: true),
            //            Descripcion = c.String(maxLength: 50),
            //            IdTenant = c.Int(nullable: false),
            //        })
            //    .PrimaryKey(t => t.Id);
            
            //CreateTable(
            //    "dbo.Sys_Usuarios_Donantes",
            //    c => new
            //        {
            //            IdUsuario = c.Int(nullable: false),
            //            IdDonante = c.Int(nullable: false),
            //            IdTenant = c.Int(nullable: false),
            //        })
            //    .PrimaryKey(t => new { t.IdUsuario, t.IdDonante })
            //    .ForeignKey("dbo.Org_Donantes", t => t.IdDonante, cascadeDelete: true)
            //    .ForeignKey("dbo.Sys_Usuarios", t => t.IdUsuario, cascadeDelete: true)
            //    .Index(t => t.IdUsuario)
            //    .Index(t => t.IdDonante);
            
            //CreateTable(
            //    "dbo.Org_Proveedores",
            //    c => new
            //        {
            //            IdProveedor = c.Int(nullable: false, identity: true),
            //            IdEmpresa = c.Int(nullable: false),
            //            Nombre = c.String(nullable: false, maxLength: 256),
            //            IdIdentificacionTipo = c.Int(nullable: false),
            //            Identificacion = c.String(nullable: false, maxLength: 50),
            //            Telefono = c.String(maxLength: 20),
            //            Correo = c.String(maxLength: 256),
            //            Ubicacion = c.String(maxLength: 100),
            //            HojaVida = c.String(maxLength: 256),
            //            FechaCreacion = c.DateTime(nullable: false),
            //            UsuarioCreacion = c.String(nullable: false, maxLength: 256),
            //            FechaModificacion = c.DateTime(),
            //            UsuarioModificacion = c.String(maxLength: 256),
            //            Eliminado = c.Boolean(nullable: false),
            //            IdTenant = c.Int(nullable: false),
            //        })
            //    .PrimaryKey(t => t.IdProveedor)
            //    .ForeignKey("dbo.Org_Empresas", t => t.IdEmpresa, cascadeDelete: true)
            //    .ForeignKey("dbo.Org_IdentificacionTipos", t => t.IdIdentificacionTipo, cascadeDelete: true)
            //    .Index(t => t.IdEmpresa)
            //    .Index(t => t.IdIdentificacionTipo);
            
            //CreateTable(
            //    "dbo.M_Periodos",
            //    c => new
            //        {
            //            IdPeriodo = c.Int(nullable: false),
            //            Descripcion = c.String(maxLength: 50),
            //            ValorDias = c.Int(),
            //            IdTenant = c.Int(nullable: false),
            //        })
            //    .PrimaryKey(t => t.IdPeriodo);
            
            //CreateTable(
            //    "dbo.M_Plantillas",
            //    c => new
            //        {
            //            IdTenant = c.Int(nullable: false),
            //            IdPlantilla = c.Int(),
            //            Plantilla = c.String(),
            //        })
            //    .PrimaryKey(t => t.IdTenant);
            
            //CreateTable(
            //    "dbo.M_Temas",
            //    c => new
            //        {
            //            IdTema = c.Int(nullable: false, identity: true),
            //            Nombre = c.String(nullable: false, maxLength: 256),
            //        })
            //    .PrimaryKey(t => t.IdTema);
            
            //CreateTable(
            //    "dbo.Sys_Usuarios_Empresas",
            //    c => new
            //        {
            //            IdUsuario = c.Int(nullable: false),
            //            IdEmpresa = c.Int(nullable: false),
            //            IdTenant = c.Int(nullable: false),
            //        })
            //    .PrimaryKey(t => new { t.IdUsuario, t.IdEmpresa })
            //    .ForeignKey("dbo.Org_Empresas", t => t.IdEmpresa, cascadeDelete: true)
            //    .ForeignKey("dbo.Sys_Usuarios", t => t.IdUsuario, cascadeDelete: true)
            //    .Index(t => t.IdUsuario)
            //    .Index(t => t.IdEmpresa);
            
            //CreateTable(
            //    "dbo.sysdiagrams",
            //    c => new
            //        {
            //            diagram_id = c.Int(nullable: false, identity: true),
            //            name = c.String(nullable: false, maxLength: 128),
            //            principal_id = c.Int(nullable: false),
            //            version = c.Int(),
            //            definition = c.Binary(),
            //        })
            //    .PrimaryKey(t => t.diagram_id);
            
            //CreateTable(
            //    "dbo.Tenants",
            //    c => new
            //        {
            //            Id = c.Int(nullable: false),
            //            Name = c.String(nullable: false, maxLength: 50),
            //            DisplayName = c.String(nullable: false, maxLength: 50),
            //            Email = c.String(nullable: false, maxLength: 50),
            //        })
            //    .PrimaryKey(t => t.Id);
            
            //CreateTable(
            //    "dbo.View_ejecutado_resultado_tipo",
            //    c => new
            //        {
            //            tipopresupuesto = c.Int(nullable: false),
            //            IdProyecto = c.Int(),
            //            idobjetivo = c.Int(),
            //            Codigo = c.String(maxLength: 50),
            //            Descripcion = c.String(maxLength: 2000),
            //            ejecutado = c.Decimal(precision: 18, scale: 2),
            //            anio = c.Int(),
            //        })
            //    .PrimaryKey(t => t.tipopresupuesto);
            
            //CreateTable(
            //    "dbo.View_Informe de Saldos",
            //    c => new
            //        {
            //            IdProyecto = c.Int(nullable: false),
            //            Ejecutor = c.String(nullable: false, maxLength: 256),
            //            Pais = c.String(nullable: false, maxLength: 50),
            //            ObjetivoProposito = c.Int(nullable: false),
            //            ObjetivoResultado = c.Int(nullable: false),
            //            ObjetivoActividad = c.Int(nullable: false),
            //            IdPresupuestoActividad = c.Int(nullable: false),
            //            Fecha_Gasto = c.DateTime(nullable: false),
            //            IdMovimiento = c.Int(nullable: false),
            //            id = c.Long(),
            //            Proyecto = c.String(maxLength: 500),
            //            Fecha_de_Vencimiento = c.DateTime(),
            //            Fecha_de_Inicio = c.DateTime(),
            //            Presupuesto_Proposito = c.Double(),
            //            Proposito = c.String(maxLength: 2000),
            //            Presupuesto_de_Resultado = c.Double(),
            //            Tipo_Presupuesto_Resultado = c.Int(),
            //            Resultado = c.String(maxLength: 2000),
            //            Actividad = c.String(maxLength: 50),
            //            Descripcion_de_Actividad = c.String(maxLength: 2000),
            //            Tipo_de_Presupuesto_Actividad = c.Int(),
            //            Presupuesto_de_Actividad = c.Double(),
            //            Monto_Movimiento = c.Double(),
            //            Año = c.Int(),
            //            Descripcion_Monto = c.String(maxLength: 500),
            //        })
            //    .PrimaryKey(t => new { t.IdProyecto, t.Ejecutor, t.Pais, t.ObjetivoProposito, t.ObjetivoResultado, t.ObjetivoActividad, t.IdPresupuestoActividad, t.Fecha_Gasto, t.IdMovimiento });
            
            //CreateTable(
            //    "dbo.View_Informe ITFSemestral",
            //    c => new
            //        {
            //            IdProyecto = c.Int(nullable: false),
            //            Pais = c.String(nullable: false, maxLength: 50),
            //            Ejecutor = c.String(nullable: false, maxLength: 256),
            //            Periodo = c.String(nullable: false, maxLength: 50),
            //            IdPeriodo = c.Long(nullable: false),
            //            CantidadPro = c.Double(nullable: false),
            //            CantidadResul = c.Double(nullable: false),
            //            Indicadores_Proposito = c.String(nullable: false, maxLength: 2000),
            //            IdIndicadorproposito = c.Int(nullable: false),
            //            ObjetivoResultado = c.Int(nullable: false),
            //            Tipo_Informe = c.Int(nullable: false),
            //            Indicadores_Resultado = c.String(nullable: false, maxLength: 2000),
            //            Idindicadorresultado = c.Int(nullable: false),
            //            Base_Proposito = c.Double(nullable: false),
            //            Base_Resultado = c.Double(nullable: false),
            //            id = c.Long(),
            //            Proyecto = c.String(maxLength: 500),
            //            Codigo = c.String(maxLength: 50),
            //            LogrosPrincipales = c.String(maxLength: 4000),
            //            Observaciones = c.String(maxLength: 4000),
            //            Factores_Exito = c.String(maxLength: 4000),
            //            Factores_Limitantes = c.String(maxLength: 4000),
            //            Condiicionalidad = c.String(maxLength: 4000),
            //            Sostenibilidad = c.String(maxLength: 4000),
            //            Problemas_y_Acciones = c.String(maxLength: 4000),
            //            Sostenibilidad_Replicas = c.String(maxLength: 4000),
            //            ObjetivoProposito = c.Int(),
            //            Proposito = c.String(maxLength: 2000),
            //            Logros_Comentarios_Proproposito = c.String(maxLength: 4000),
            //            Explicacion_Logros_Proposito = c.String(maxLength: 4000),
            //            Resultado = c.String(maxLength: 2000),
            //            Logros_Comentarios_Resultado = c.String(maxLength: 4000),
            //            Recomendaciones = c.String(maxLength: 4000),
            //            Replicas = c.String(maxLength: 4000),
            //            Avance_Principal = c.String(maxLength: 4000),
            //            Cambios_Internos = c.String(maxLength: 4000),
            //            Objetivo_General = c.String(maxLength: 2000),
            //            Fecha_Fin = c.DateTime(),
            //            Fecha_Inicio = c.DateTime(),
            //            Explicacion_logros_Resultado = c.String(maxLength: 4000),
            //        })
            //    .PrimaryKey(t => new { t.IdProyecto, t.Pais, t.Ejecutor, t.Periodo, t.IdPeriodo, t.CantidadPro, t.CantidadResul, t.Indicadores_Proposito, t.IdIndicadorproposito, t.ObjetivoResultado, t.Tipo_Informe, t.Indicadores_Resultado, t.Idindicadorresultado, t.Base_Proposito, t.Base_Resultado });
            
            //CreateTable(
            //    "dbo.View_Informe_Saldos_FER",
            //    c => new
            //        {
            //            tipopresupuesto = c.Int(nullable: false),
            //            IdProyecto = c.Int(),
            //            CodigoPRY = c.String(maxLength: 50),
            //            NombrePRY = c.String(maxLength: 500),
            //            FechaInicio = c.DateTime(),
            //            FechaFin = c.DateTime(),
            //            idobjetivo = c.Int(),
            //            codigo = c.String(maxLength: 50),
            //            descripcion = c.String(maxLength: 2000),
            //            anio = c.Int(),
            //            presupuesto = c.Decimal(precision: 18, scale: 2),
            //            ejecutado = c.Decimal(precision: 18, scale: 2),
            //            NombreEMP = c.String(maxLength: 256),
            //            pais = c.String(maxLength: 50),
            //            moneda = c.String(maxLength: 50),
            //            simbolomnd = c.String(maxLength: 10, fixedLength: true),
            //        })
            //    .PrimaryKey(t => t.tipopresupuesto);
            
            //CreateTable(
            //    "dbo.View_InformeAdministrativoITFUNIP",
            //    c => new
            //        {
            //            IdProyecto = c.Int(nullable: false),
            //            Pais = c.String(nullable: false, maxLength: 50),
            //            Entidad_Desarrolladora = c.String(nullable: false, maxLength: 256),
            //            IdPeriodo = c.Long(nullable: false),
            //            Periodo = c.String(nullable: false, maxLength: 50),
            //            Programa = c.String(maxLength: 500),
            //            Proyecto = c.String(maxLength: 500),
            //            Codigo = c.String(maxLength: 50),
            //            Fecha_de_Inicio = c.DateTime(),
            //            Fecha_de_Vencimiento = c.DateTime(),
            //            ObjetivoActividad = c.Int(),
            //            Actividad = c.String(maxLength: 50),
            //            Descripcion_de_Actividad = c.String(maxLength: 2000),
            //            Observacion_de_la_Actividad = c.String(maxLength: 2000),
            //            Recomendaciones = c.String(maxLength: 2000),
            //            Observaciones_Generales = c.String(maxLength: 2000),
            //            Datos_Financieros = c.String(maxLength: 2000),
            //        })
            //    .PrimaryKey(t => new { t.IdProyecto, t.Pais, t.Entidad_Desarrolladora, t.IdPeriodo, t.Periodo });
            
            //CreateTable(
            //    "dbo.View_InformeAvanceHitos",
            //    c => new
            //        {
            //            IdProyecto = c.Int(nullable: false),
            //            Periodo = c.String(nullable: false, maxLength: 50),
            //            IdobjetivoResultado = c.Int(nullable: false),
            //            IdobjetivoAvtividad = c.Int(nullable: false),
            //            Hito = c.String(nullable: false, maxLength: 2000),
            //            Meta_actividad = c.Double(nullable: false),
            //            Meta_Resultado = c.Double(nullable: false),
            //            Meta_Proposito = c.Double(nullable: false),
            //            Idperiodo = c.Long(nullable: false),
            //            Base_Hito = c.Double(nullable: false),
            //            Meta_Hito = c.Double(nullable: false),
            //            id = c.Long(),
            //            Proyecto = c.String(maxLength: 500),
            //            Fecha_de_Inicio = c.DateTime(),
            //            Fecha_de_Vencimiento = c.DateTime(),
            //            IdProposito = c.Int(),
            //            Proposito = c.String(maxLength: 2000),
            //            Entregable = c.String(maxLength: 2000),
            //            IdClaseResultdo = c.Int(),
            //            Actividad = c.String(maxLength: 50),
            //            Descripcion_Actividad = c.String(maxLength: 2000),
            //            Fecha_de_Inicio_Actividad = c.DateTime(),
            //            IdClaseActividad = c.Int(),
            //            Fecha_de_Inicio_Resultado = c.DateTime(),
            //            PondereadoProposito = c.Double(),
            //            PonderedoResultado = c.Double(),
            //            PonderedoActividad = c.Double(),
            //            Ponderado_Hito = c.Double(),
            //            Ponderado_Avance_Hito = c.Double(),
            //        })
            //    .PrimaryKey(t => new { t.IdProyecto, t.Periodo, t.IdobjetivoResultado, t.IdobjetivoAvtividad, t.Hito, t.Meta_actividad, t.Meta_Resultado, t.Meta_Proposito, t.Idperiodo, t.Base_Hito, t.Meta_Hito });
            
            //CreateTable(
            //    "dbo.View_InformeCronogramaHitos",
            //    c => new
            //        {
            //            idproyecto = c.String(nullable: false, maxLength: 7),
            //            nombreproyecto = c.String(nullable: false, maxLength: 111),
            //            idejcutor = c.String(nullable: false, maxLength: 11),
            //            nombreejecutor = c.String(nullable: false, maxLength: 6),
            //            nombrepais = c.String(nullable: false, maxLength: 4),
            //            fechainicio = c.String(nullable: false, maxLength: 10),
            //            fechafin = c.String(nullable: false, maxLength: 10),
            //            resultadoid = c.Int(nullable: false),
            //            porcentajeresultado = c.Int(nullable: false),
            //            nombreresultado = c.String(nullable: false, maxLength: 18),
            //            actividadid = c.Decimal(nullable: false, precision: 18, scale: 2),
            //            actividadDes = c.String(nullable: false, maxLength: 85),
            //            porcentajeact = c.Int(nullable: false),
            //            Idhito = c.Int(nullable: false),
            //            hito = c.String(nullable: false, maxLength: 47),
            //            porcentajehito = c.Int(nullable: false),
            //            porcentajeperiodo = c.Int(nullable: false),
            //            periodo = c.Int(nullable: false),
            //        })
            //    .PrimaryKey(t => new { t.idproyecto, t.nombreproyecto, t.idejcutor, t.nombreejecutor, t.nombrepais, t.fechainicio, t.fechafin, t.resultadoid, t.porcentajeresultado, t.nombreresultado, t.actividadid, t.actividadDes, t.porcentajeact, t.Idhito, t.hito, t.porcentajehito, t.porcentajeperiodo, t.periodo });
            
            //CreateTable(
            //    "dbo.View_InformeCronogramaHitos1",
            //    c => new
            //        {
            //            IdProyecto = c.Int(nullable: false),
            //            Periodo = c.String(nullable: false, maxLength: 50),
            //            IdobjetivoResultado = c.Int(nullable: false),
            //            IdobjetivoAvtividad = c.Int(nullable: false),
            //            Hito = c.String(nullable: false, maxLength: 2000),
            //            Meta_actividad = c.Double(nullable: false),
            //            Meta_Resultado = c.Double(nullable: false),
            //            Meta_Proposito = c.Double(nullable: false),
            //            Idperiodo = c.Long(nullable: false),
            //            id = c.Long(),
            //            Proyecto = c.String(maxLength: 500),
            //            Fecha_de_Inicio = c.DateTime(),
            //            Fecha_de_Vencimiento = c.DateTime(),
            //            IdProposito = c.Int(),
            //            Proposito = c.String(maxLength: 2000),
            //            Entregable = c.String(maxLength: 2000),
            //            IdClaseResultdo = c.Int(),
            //            Actividad = c.String(maxLength: 50),
            //            Descripcion_Actividad = c.String(maxLength: 2000),
            //            Fecha_de_Inicio_Actividad = c.DateTime(),
            //            IdClaseActividad = c.Int(),
            //            Fecha_de_Inicio_Resultado = c.DateTime(),
            //            PondereadoProposito = c.Double(),
            //            PonderedoResultado = c.Double(),
            //            PonderedoActividad = c.Double(),
            //            Ponderado_Hito = c.Double(),
            //        })
            //    .PrimaryKey(t => new { t.IdProyecto, t.Periodo, t.IdobjetivoResultado, t.IdobjetivoAvtividad, t.Hito, t.Meta_actividad, t.Meta_Resultado, t.Meta_Proposito, t.Idperiodo });
            
            //CreateTable(
            //    "dbo.View_InformeRendicionGastos1",
            //    c => new
            //        {
            //            Ejecutor = c.String(nullable: false, maxLength: 256),
            //            Pais = c.String(nullable: false, maxLength: 50),
            //            IdProyecto = c.Int(nullable: false),
            //            ObjetivoProposito = c.Int(nullable: false),
            //            ObjetivoResultado = c.Int(nullable: false),
            //            ObjetivoActividad = c.Int(nullable: false),
            //            IdPresupuestoActividad = c.Int(nullable: false),
            //            Periodo_id = c.Long(nullable: false),
            //            Periodo_Movimiento = c.String(nullable: false, maxLength: 50),
            //            IdPartidaGasto = c.Int(nullable: false),
            //            Partida_Gasto = c.String(nullable: false, maxLength: 50),
            //            id = c.Long(),
            //            Proyecto = c.String(maxLength: 500),
            //            Fecha_de_Inicio = c.DateTime(),
            //            Fecha_de_Vencimiento = c.DateTime(),
            //            Proposito = c.String(maxLength: 2000),
            //            Presupuesto_Proposito = c.Double(),
            //            Resultado = c.String(maxLength: 2000),
            //            Actividad = c.String(maxLength: 50),
            //            Descripcion_de_Actividad = c.String(maxLength: 2000),
            //            Tipo_Presupuesto_Actividad = c.Int(),
            //            Presupuesto_Actividad = c.Double(),
            //            Monto_Movimiento = c.Double(),
            //            Descripcion = c.String(maxLength: 500),
            //            Aportes = c.Decimal(precision: 18, scale: 2),
            //            Contrapartida = c.Decimal(precision: 18, scale: 2),
            //            Aporte_Moneda_Local = c.Decimal(precision: 18, scale: 2),
            //            Taza_Cambio = c.Decimal(precision: 18, scale: 2),
            //            Numero_Comprobante = c.String(maxLength: 50),
            //            Fecha_Pago = c.DateTime(),
            //            Moneda = c.String(maxLength: 61),
            //            Beneficiario = c.String(maxLength: 150),
            //        })
            //    .PrimaryKey(t => new { t.Ejecutor, t.Pais, t.IdProyecto, t.ObjetivoProposito, t.ObjetivoResultado, t.ObjetivoActividad, t.IdPresupuestoActividad, t.Periodo_id, t.Periodo_Movimiento, t.IdPartidaGasto, t.Partida_Gasto });
            
            //CreateTable(
            //    "dbo.View_InformeRendicionGastos1fer",
            //    c => new
            //        {
            //            IdProyecto = c.Int(nullable: false),
            //            Ejecutor = c.String(nullable: false, maxLength: 256),
            //            Pais = c.String(nullable: false, maxLength: 50),
            //            ObjetivoProposito = c.Int(nullable: false),
            //            ObjetivoResultado = c.Int(nullable: false),
            //            ObjetivoActividad = c.Int(nullable: false),
            //            IdPresupuestoActividad = c.Int(nullable: false),
            //            Periodo_id = c.Long(nullable: false),
            //            Periodo_Movimiento = c.String(nullable: false, maxLength: 50),
            //            IdPartidaGasto = c.Int(nullable: false),
            //            Partida_Gasto = c.String(nullable: false, maxLength: 50),
            //            id = c.Long(),
            //            Proyecto = c.String(maxLength: 500),
            //            Fecha_de_Vencimiento = c.DateTime(),
            //            Fecha_de_Inicio = c.DateTime(),
            //            Presupuesto_Proposito = c.Double(),
            //            Proposito = c.String(maxLength: 2000),
            //            Resultado = c.String(maxLength: 2000),
            //            Actividad = c.String(maxLength: 50),
            //            Descripcion_de_Actividad = c.String(maxLength: 2000),
            //            Tipo_Presupuesto_Actividad = c.Int(),
            //            Presupuesto_Actividad = c.Double(),
            //            Monto_Movimiento = c.Double(),
            //            Beneficiario = c.String(maxLength: 150),
            //            Contrapartida = c.Decimal(precision: 18, scale: 2),
            //            Fecha_Pago = c.DateTime(),
            //            Aportes = c.Decimal(precision: 18, scale: 2),
            //            Aporte_Moneda_Local = c.Decimal(precision: 18, scale: 2),
            //            Taza_Cambio = c.Decimal(precision: 18, scale: 2),
            //            Numero_Comprobante = c.String(maxLength: 50),
            //            Descripcion = c.String(maxLength: 500),
            //            Moneda = c.String(maxLength: 61),
            //        })
            //    .PrimaryKey(t => new { t.IdProyecto, t.Ejecutor, t.Pais, t.ObjetivoProposito, t.ObjetivoResultado, t.ObjetivoActividad, t.IdPresupuestoActividad, t.Periodo_id, t.Periodo_Movimiento, t.IdPartidaGasto, t.Partida_Gasto });
            
            //CreateTable(
            //    "dbo.View_InformeTecnicoAvanceHitos",
            //    c => new
            //        {
            //            IdProyecto = c.Int(nullable: false),
            //            Periodo = c.String(nullable: false, maxLength: 50),
            //            IdobjetivoResultado = c.Int(nullable: false),
            //            IdobjetivoAvtividad = c.Int(nullable: false),
            //            Hito = c.String(nullable: false, maxLength: 2000),
            //            Meta_actividad = c.Double(nullable: false),
            //            Meta_Resultado = c.Double(nullable: false),
            //            Meta_Proposito = c.Double(nullable: false),
            //            Idperiodo = c.Long(nullable: false),
            //            Base_Hito = c.Double(nullable: false),
            //            IdIndicador = c.Int(nullable: false),
            //            Meta_Hito = c.Double(nullable: false),
            //            id = c.Long(),
            //            Proyecto = c.String(maxLength: 500),
            //            Fecha_de_Inicio = c.DateTime(),
            //            Fecha_de_Vencimiento = c.DateTime(),
            //            IdProposito = c.Int(),
            //            Proposito = c.String(maxLength: 2000),
            //            Entregable = c.String(maxLength: 2000),
            //            IdClaseResultdo = c.Int(),
            //            Actividad = c.String(maxLength: 50),
            //            Descripcion_Actividad = c.String(maxLength: 2000),
            //            Fecha_de_Inicio_Actividad = c.DateTime(),
            //            IdClaseActividad = c.Int(),
            //            Fecha_de_Inicio_Resultado = c.DateTime(),
            //            PondereadoProposito = c.Double(),
            //            PonderedoResultado = c.Double(),
            //            PonderedoActividad = c.Double(),
            //            Ponderado_Hito = c.Double(),
            //            Ponderado_Avance_Hito = c.Double(),
            //            Obserbaciones_ED = c.String(maxLength: 2000),
            //            Observaciones_URIP = c.String(maxLength: 2000),
            //            ADH = c.Decimal(precision: 18, scale: 2),
            //            CV = c.Decimal(precision: 18, scale: 2),
            //        })
            //    .PrimaryKey(t => new { t.IdProyecto, t.Periodo, t.IdobjetivoResultado, t.IdobjetivoAvtividad, t.Hito, t.Meta_actividad, t.Meta_Resultado, t.Meta_Proposito, t.Idperiodo, t.Base_Hito, t.IdIndicador, t.Meta_Hito });
            
            //CreateTable(
            //    "dbo.View_InfromeDetalleEjecucionGasto",
            //    c => new
            //        {
            //            IdProyecto = c.Int(nullable: false),
            //            Pais = c.String(nullable: false, maxLength: 50),
            //            Ejecutor = c.String(nullable: false, maxLength: 256),
            //            Periodo_Movimiento = c.String(nullable: false, maxLength: 50),
            //            ObjetivoProposito = c.Int(nullable: false),
            //            ObjetivoResultado = c.Int(nullable: false),
            //            ObjetivoActividad = c.Int(nullable: false),
            //            IdPartidaGasto = c.Int(nullable: false),
            //            Partida_Gasto = c.String(nullable: false, maxLength: 50),
            //            Taza_Cambio = c.Decimal(nullable: false, precision: 18, scale: 2),
            //            Cheque_Operacion = c.Int(nullable: false),
            //            Numero_Comprobante = c.String(nullable: false, maxLength: 9),
            //            id = c.Long(),
            //            Proyecto = c.String(maxLength: 500),
            //            Fecha_de_Inicio = c.DateTime(),
            //            Fecha_de_Vencimiento = c.DateTime(),
            //            Proposito = c.String(maxLength: 2000),
            //            Presupuesto_Proposito = c.Double(),
            //            Resultado = c.String(maxLength: 2000),
            //            Actividad = c.String(maxLength: 50),
            //            Descripcion_de_Actividad = c.String(maxLength: 2000),
            //            Presupuesto_Actividad = c.Double(),
            //            IdPresupuestoActividad = c.String(maxLength: 150),
            //            Monto_Movimiento = c.Double(),
            //            Tipo_Presupuesto_Actividad = c.Int(),
            //            Beneficiario = c.String(maxLength: 150),
            //            Aportes = c.Decimal(precision: 18, scale: 2),
            //            Contrapartida = c.Decimal(precision: 18, scale: 2),
            //            Fecha_Pago = c.DateTime(),
            //        })
            //    .PrimaryKey(t => new { t.IdProyecto, t.Pais, t.Ejecutor, t.Periodo_Movimiento, t.ObjetivoProposito, t.ObjetivoResultado, t.ObjetivoActividad, t.IdPartidaGasto, t.Partida_Gasto, t.Taza_Cambio, t.Cheque_Operacion, t.Numero_Comprobante });
            
            //CreateTable(
            //    "dbo.View_ppto_resultado_tipo",
            //    c => new
            //        {
            //            idproyecto = c.Int(nullable: false),
            //            tipopresupuesto = c.Int(nullable: false),
            //            idobjetivo = c.Int(),
            //            Codigo = c.String(maxLength: 50),
            //            Descripcion = c.String(maxLength: 2000),
            //            presupuesto = c.Decimal(precision: 18, scale: 2),
            //        })
            //    .PrimaryKey(t => new { t.idproyecto, t.tipopresupuesto });
            
            //CreateTable(
            //    "dbo.View_saldoppto_resultado_tipo",
            //    c => new
            //        {
            //            idproyecto = c.Int(nullable: false),
            //            tipopresupuesto = c.Int(nullable: false),
            //            idobjetivo = c.Int(),
            //            Codigo = c.String(maxLength: 50),
            //            Descripcion = c.String(maxLength: 2000),
            //            presupuesto = c.Decimal(precision: 18, scale: 2),
            //            ejecutado = c.Decimal(precision: 18, scale: 2),
            //            anio = c.Int(),
            //        })
            //    .PrimaryKey(t => new { t.idproyecto, t.tipopresupuesto });
            
            //CreateTable(
            //    "dbo.AspNetUserRoles",
            //    c => new
            //        {
            //            RoleId = c.String(nullable: false, maxLength: 128),
            //            UserId = c.String(nullable: false, maxLength: 128),
            //        })
            //    .PrimaryKey(t => new { t.RoleId, t.UserId })
            //    .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
            //    .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
            //    .Index(t => t.RoleId)
            //    .Index(t => t.UserId);
            
            //CreateTable(
            //    "dbo.AspNetRolesAcciones",
            //    c => new
            //        {
            //            AccionesId = c.Int(nullable: false),
            //            RoleId = c.String(nullable: false, maxLength: 128),
            //        })
            //    .PrimaryKey(t => new { t.AccionesId, t.RoleId })
            //    .ForeignKey("dbo.Acciones", t => t.AccionesId, cascadeDelete: true)
            //    .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
            //    .Index(t => t.AccionesId)
            //    .Index(t => t.RoleId);
            
            //CreateTable(
            //    "dbo.Sys_UsuariosOrg_Empresas",
            //    c => new
            //        {
            //            Sys_Usuarios_IdUsuario = c.Int(nullable: false),
            //            Org_Empresas_IdEmpresa = c.Int(nullable: false),
            //        })
            //    .PrimaryKey(t => new { t.Sys_Usuarios_IdUsuario, t.Org_Empresas_IdEmpresa })
            //    .ForeignKey("dbo.Sys_Usuarios", t => t.Sys_Usuarios_IdUsuario, cascadeDelete: true)
            //    .ForeignKey("dbo.Org_Empresas", t => t.Org_Empresas_IdEmpresa, cascadeDelete: true)
            //    .Index(t => t.Sys_Usuarios_IdUsuario)
            //    .Index(t => t.Org_Empresas_IdEmpresa);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Sys_Usuarios_Empresas", "IdUsuario", "dbo.Sys_Usuarios");
            DropForeignKey("dbo.Sys_Usuarios_Empresas", "IdEmpresa", "dbo.Org_Empresas");
            DropForeignKey("dbo.Cms_MenuNodos", "IdMenu", "dbo.Cms_Menus");
            DropForeignKey("dbo.Org_Empresas", "IdCliente", "dbo.Sys_Clientes");
            DropForeignKey("dbo.Org_Empresas", "IdIdentificacionTipo", "dbo.Org_IdentificacionTipos");
            DropForeignKey("dbo.Org_Donantes", "Org_Empresas_IdEmpresa", "dbo.Org_Empresas");
            DropForeignKey("dbo.Org_Areas", "IdEmpresa", "dbo.Org_Empresas");
            DropForeignKey("dbo.Org_Empleados", "IdUsuario", "dbo.Sys_Usuarios");
            DropForeignKey("dbo.Org_Empleados", "IdIdentificacionTipo", "dbo.Org_IdentificacionTipos");
            DropForeignKey("dbo.Org_Proveedores", "IdIdentificacionTipo", "dbo.Org_IdentificacionTipos");
            DropForeignKey("dbo.Org_Proveedores", "IdEmpresa", "dbo.Org_Empresas");
            DropForeignKey("dbo.Sys_Usuarios_Donantes", "IdUsuario", "dbo.Sys_Usuarios");
            DropForeignKey("dbo.Sys_Usuarios_Donantes", "IdDonante", "dbo.Org_Donantes");
            DropForeignKey("dbo.Org_Donantes", "IdCliente", "dbo.Sys_Clientes");
            DropForeignKey("dbo.Pry_CalendarioDonaciones", "IdProyecto", "dbo.Pry_Proyectos");
            DropForeignKey("dbo.Pry_Proyectos", "IdUsuarioDigitador", "dbo.Sys_Usuarios");
            DropForeignKey("dbo.Pry_Proyectos", "IdUsuarioResponsable", "dbo.Sys_Usuarios");
            DropForeignKey("dbo.Pry_Proyectos", "IdUsuarioEvaluador", "dbo.Sys_Usuarios");
            DropForeignKey("dbo.Pry_Proyectos", "CustomerId", "dbo.Sys_Clientes");
            DropForeignKey("dbo.Pry_Proyectos", "IdTipo", "dbo.Pry_ProyectosTipos");
            DropForeignKey("dbo.Pry_Proyectos", "IdEstado", "dbo.Pry_ProyectosEstados");
            DropForeignKey("dbo.Pry_Proyectos", "IDPROYECTOPADRE", "dbo.Pry_Proyectos");
            DropForeignKey("dbo.Pry_Proyectos_Donantes", "IdUsuarioResponsable", "dbo.Sys_Usuarios");
            DropForeignKey("dbo.Tar_Bitacora", "IdVisita", "dbo.Tar_Visitas");
            DropForeignKey("dbo.Tar_Visitas", "IdTarea", "dbo.Tar_Tareas");
            DropForeignKey("dbo.Tar_Tareas", "IdLista", "dbo.Tar_Listas");
            DropForeignKey("dbo.Tar_Listas", "IdUsuarioModificacion", "dbo.Sys_Usuarios");
            DropForeignKey("dbo.Tar_Listas", "IdUsuarioCreacion", "dbo.Sys_Usuarios");
            DropForeignKey("dbo.Tar_Listas", "IdProyecto", "dbo.Pry_Proyectos");
            DropForeignKey("dbo.Tar_Tareas", "IdUsuarioCompletado", "dbo.Sys_Usuarios");
            DropForeignKey("dbo.Tar_Tareas", "IdUsuarioModificacion", "dbo.Sys_Usuarios");
            DropForeignKey("dbo.Tar_Tareas", "IdUsuarioCreacion", "dbo.Sys_Usuarios");
            DropForeignKey("dbo.Tar_Tareas", "IdResponsable", "dbo.Sys_Usuarios");
            DropForeignKey("dbo.Documentos_Tareas", "IdTarea", "dbo.Tar_Tareas");
            DropForeignKey("dbo.Documentos_Tareas", "IdDocumento", "dbo.Doc_Documentos");
            DropForeignKey("dbo.Doc_Documentos", "IdCategoria", "dbo.Doc_Categorias");
            DropForeignKey("dbo.Doc_Clientes_Categorias", "IdCliente", "dbo.Sys_Clientes");
            DropForeignKey("dbo.Doc_Clientes_Categorias", "IdCategoria", "dbo.Doc_Categorias");
            DropForeignKey("dbo.Doc_Documentos", "IdTipoArchivo", "dbo.Doc_ArchivosTipos");
            DropForeignKey("dbo.Tar_Permisos_Bitacora", "IdVisita", "dbo.Tar_Visitas");
            DropForeignKey("dbo.Tar_Permisos_Bitacora", "IdUsuario", "dbo.Sys_Usuarios");
            DropForeignKey("dbo.Tar_Bitacora", "IdUsuario", "dbo.Sys_Usuarios");
            DropForeignKey("dbo.Sys_UsuariosOrg_Empresas", "Org_Empresas_IdEmpresa", "dbo.Org_Empresas");
            DropForeignKey("dbo.Sys_UsuariosOrg_Empresas", "Sys_Usuarios_IdUsuario", "dbo.Sys_Usuarios");
            DropForeignKey("dbo.Org_Donantes", "Sys_Usuarios_IdUsuario", "dbo.Sys_Usuarios");
            DropForeignKey("dbo.Com_Mensajes", "IdUsuarioRemitente", "dbo.Sys_Usuarios");
            DropForeignKey("dbo.Com_Mensajes", "IdEstado", "dbo.Com_MensajesEstado");
            DropForeignKey("dbo.Pry_Proyectos_Donantes", "IdProyecto", "dbo.Pry_Proyectos");
            DropForeignKey("dbo.Pry_Proyectos_Donantes", "IdDonante", "dbo.Org_Donantes");
            DropForeignKey("dbo.Pry_Proyectos", "IdProposito", "dbo.Pry_Objetivos");
            DropForeignKey("dbo.Pry_Bitacoras", "IdProyecto", "dbo.Pry_Proyectos");
            DropForeignKey("dbo.Pry_Proyectos", "IdMoneda", "dbo.M_Monedas");
            DropForeignKey("dbo.Pry_Movimientos", "IdPresupuesto", "dbo.Pry_Presupuesto");
            DropForeignKey("dbo.Pry_Movimientos", "IdPeriodo", "dbo.PRY_PERIODOSPROYECTOS");
            DropForeignKey("dbo.Pry_Movimientos", "IDPARTIDAGASTO", "dbo.PRY_PARTIDAGASTOS");
            DropForeignKey("dbo.Pry_Recursos", "IDPARTIDAGASTO", "dbo.PRY_PARTIDAGASTOS");
            DropForeignKey("dbo.Pry_Recursos", "IdObjetivo", "dbo.Pry_Objetivos");
            DropForeignKey("dbo.Pry_Objetivos", "IdObjetivoClase", "dbo.Pry_ObjetivosClase");
            DropForeignKey("dbo.PRY_EVALUACIONESACTIVIDADESPERIODO", "IDOBJETIVO", "dbo.Pry_Objetivos");
            DropForeignKey("dbo.PRY_EVALUACIONESACTIVIDADESPERIODO", new[] { "IDPERIODO", "IDPROYECTO" }, "dbo.PRY_EVALUACIONPROYECTOPERIODO");
            DropForeignKey("dbo.PRY_EVALUACIONPROYECTOPERIODO", "IDPROYECTO", "dbo.Pry_Proyectos");
            DropForeignKey("dbo.PRY_EVALUACIONPROYECTOPERIODO", "IDPERIODO", "dbo.PRY_PERIODOSPROYECTOS");
            DropForeignKey("dbo.PRY_PERIODOSPROYECTOS", "IdProyecto", "dbo.Pry_Proyectos");
            DropForeignKey("dbo.Pry_DatosMuestras", "IdPeriodo", "dbo.PRY_PERIODOSPROYECTOS");
            DropForeignKey("dbo.Pry_DatosMuestras", "IdNivelAceptacionEfectividad", "dbo.Pry_NivelAceptacion");
            DropForeignKey("dbo.Pry_DatosMuestras", "IdIndicador", "dbo.Pry_Indicadores");
            DropForeignKey("dbo.Pry_DatosVariables", "IdVariable", "dbo.Pry_Variables");
            DropForeignKey("dbo.Pry_Indicadores_Variables", "IdIndicador", "dbo.Pry_Variables");
            DropForeignKey("dbo.Pry_Indicadores_Variables", "IdVariable", "dbo.Pry_Indicadores");
            DropForeignKey("dbo.PRY_INFORMESICAINDICADORES", "IDINFORME", "dbo.PRY_INFORMESICA");
            DropForeignKey("dbo.PRY_INFORMESICA", "IDPROYECTO", "dbo.Pry_Proyectos");
            DropForeignKey("dbo.PRY_INFORMESICA", "PERIODOFINAL", "dbo.PRY_PERIODOSPROYECTOS");
            DropForeignKey("dbo.PRY_INFORMESICA", "PERIODOINICIAL", "dbo.PRY_PERIODOSPROYECTOS");
            DropForeignKey("dbo.PRY_INFORMESICA", "IDTIPO", "dbo.PRY_INFORMESICATIPOS");
            DropForeignKey("dbo.PRY_INFORMESICAOBJETIVOS", "IDOBJETIVO", "dbo.Pry_Objetivos");
            DropForeignKey("dbo.PRY_INFORMESICAOBJETIVOS", "IDINFORME", "dbo.PRY_INFORMESICA");
            DropForeignKey("dbo.PRY_INFORMESICA", "IDESTADO", "dbo.PRY_INFORMESICAESTADOS");
            DropForeignKey("dbo.PRY_INFORMESICADOCUMENTOS", "IDINFORME", "dbo.PRY_INFORMESICA");
            DropForeignKey("dbo.PRY_INFORMESICADETALLE", "IDINFORME", "dbo.PRY_INFORMESICA");
            DropForeignKey("dbo.PRY_INFORMESICAINDICADORES", "IDINDICADOR", "dbo.Pry_Indicadores");
            DropForeignKey("dbo.Pry_Informes_Indicador", "Evaluacion", "dbo.Pry_NivelAceptacion");
            DropForeignKey("dbo.Pry_Informes_Indicador", "IdInforme", "dbo.Pry_Informes");
            DropForeignKey("dbo.Pry_Informes", "IdProyecto", "dbo.Pry_Proyectos");
            DropForeignKey("dbo.Pry_Informes", "EvaluacionComponentes", "dbo.Pry_NivelAceptacion");
            DropForeignKey("dbo.Pry_Informes", "EvaluacionProposito", "dbo.Pry_NivelAceptacion");
            DropForeignKey("dbo.Pry_Informes", "IdEstado", "dbo.Pry_InformesEstados");
            DropForeignKey("dbo.Pry_Informes_Supuestos", "IdSupuesto", "dbo.Pry_Supuestos");
            DropForeignKey("dbo.Pry_Supuestos", "IdObjetivo", "dbo.Pry_Objetivos");
            DropForeignKey("dbo.Pry_Informes_Supuestos", "IdInforme", "dbo.Pry_Informes");
            DropForeignKey("dbo.Pry_Informes_Presupuestos", "IdPresupuesto", "dbo.Pry_Presupuesto");
            DropForeignKey("dbo.Pry_Presupuesto", "IdProyecto", "dbo.Pry_Proyectos");
            DropForeignKey("dbo.Pry_Presupuesto", "IdTipoPresupuesto", "dbo.Pry_PresupuestoTipo");
            DropForeignKey("dbo.Pry_Informes_Presupuestos", "Evaluacion", "dbo.Pry_NivelAceptacion");
            DropForeignKey("dbo.Pry_Proyectos_NivelAceptacion", "IdProyecto", "dbo.Pry_Proyectos");
            DropForeignKey("dbo.Pry_Proyectos_NivelAceptacion", "IdNivelAceptacion", "dbo.Pry_NivelAceptacion");
            DropForeignKey("dbo.Pry_Informes_Presupuestos", "IdInforme", "dbo.Pry_Informes");
            DropForeignKey("dbo.Pry_Informes_Encuestas", "IdInforme", "dbo.Pry_Informes");
            DropForeignKey("dbo.Pry_Informes_Encuestas", "IdPregunta", "dbo.M_Preguntas");
            DropForeignKey("dbo.M_PosiblesRespuestas", "IdPregunta", "dbo.M_Preguntas");
            DropForeignKey("dbo.M_Preguntas", "IdEncuesta", "dbo.M_Encuestas");
            DropForeignKey("dbo.M_Encuestas", "IdIdioma", "dbo.M_Idiomas");
            DropForeignKey("dbo.M_ValoresRespuesta", "IdPreguntaResuelta", "dbo.M_PreguntasResueltas");
            DropForeignKey("dbo.M_PreguntasResueltas", "IdPregunta", "dbo.M_Preguntas");
            DropForeignKey("dbo.M_PreguntasResueltas", "IdEncuestaResuelta", "dbo.M_EncuestasResueltas");
            DropForeignKey("dbo.M_EncuestasResueltas", "IdEncuesta", "dbo.M_Encuestas");
            DropForeignKey("dbo.Pry_Informes_Donantes", "IdInforme", "dbo.Pry_Informes");
            DropForeignKey("dbo.Pry_Informes_Donantes", "IdDonante", "dbo.Org_Donantes");
            DropForeignKey("dbo.Pry_Informes_Indicador", "IdIndicador", "dbo.Pry_Indicadores");
            DropForeignKey("dbo.Pry_Informes_Indicador", "IdDatosMuestra", "dbo.Pry_DatosMuestras");
            DropForeignKey("dbo.Pry_IndicadoresVerificadores", "IdIndicador", "dbo.Pry_Indicadores");
            DropForeignKey("dbo.Pry_DatosVerificadores", "IdVerificador", "dbo.Pry_IndicadoresVerificadores");
            DropForeignKey("dbo.Pry_DatosVerificadores", "IdDatosMuestra", "dbo.Pry_DatosMuestras");
            DropForeignKey("dbo.Pry_Indicadores", "IdTipo", "dbo.Pry_IndicadoresTipos");
            DropForeignKey("dbo.Pry_Indicadores", "IdSubTipo", "dbo.Pry_IndicadoresTipos");
            DropForeignKey("dbo.Pry_IndicadoresProyecto_Programa", "IdIndicadorProyecto", "dbo.Pry_Indicadores");
            DropForeignKey("dbo.PRY_EVALUACIONINDICADORESPERIODO", "IdProyecto", "dbo.Pry_Proyectos");
            DropForeignKey("dbo.PRY_EVALUACIONINDICADORESPERIODO", "IdPeriodo", "dbo.PRY_PERIODOSPROYECTOS");
            DropForeignKey("dbo.PRY_EVALUACIONINDICADORESPERIODO", "IdResultado", "dbo.Pry_Objetivos");
            DropForeignKey("dbo.PRY_EVALUACIONINDICADORESPERIODO", "IdHito", "dbo.Pry_Indicadores");
            DropForeignKey("dbo.Pry_EvaluacionHitos", "IdProyecto", "dbo.Pry_Proyectos");
            DropForeignKey("dbo.Pry_EvaluacionHitos", "IdPeriodo", "dbo.PRY_PERIODOSPROYECTOS");
            DropForeignKey("dbo.Pry_EvaluacionHitos", "IdActividad", "dbo.Pry_Objetivos");
            DropForeignKey("dbo.Pry_EvaluacionHitos", "IdResultado", "dbo.Pry_Objetivos");
            DropForeignKey("dbo.Pry_EvaluacionHitos", "IdHito", "dbo.Pry_Indicadores");
            DropForeignKey("dbo.Pry_Indicadores", "IdResponsableIndicador", "dbo.Org_Empleados");
            DropForeignKey("dbo.Pry_DatosVariables", "IdDatosMuestra", "dbo.Pry_DatosMuestras");
            DropForeignKey("dbo.Pry_ProductividadBeneficiario", "IdBeneficiario", "dbo.Pry_Beneficiarios");
            DropForeignKey("dbo.Pry_Beneficiarios", "IdObjetivo", "dbo.Pry_Objetivos");
            DropForeignKey("dbo.Pry_CapacitacionBeneficiario", "IdCapacitacion", "dbo.Pry_Capacitaciones");
            DropForeignKey("dbo.Pry_Capacitaciones", "IdFacilitador", "dbo.Pry_Facilitadores");
            DropForeignKey("dbo.Pry_CapacitacionBeneficiario", "IdBeneficiario", "dbo.Pry_Beneficiarios");
            DropForeignKey("dbo.Pry_Objetivos", "IdEmpresa", "dbo.Org_Empresas");
            DropForeignKey("dbo.Pry_MontoDonacion", "IdMovimiento", "dbo.Pry_Movimientos");
            DropForeignKey("dbo.Pry_Movimientos", "MONEDALOCAL", "dbo.M_Monedas");
            DropForeignKey("dbo.m_TipCambio", "M_Monedas_IdMoneda", "dbo.M_Monedas");
            DropForeignKey("dbo.m_TipCambio", "idMoneda", "dbo.M_Monedas");
            DropForeignKey("dbo.Pry_CalendarioDonaciones", "IdDonante", "dbo.Org_Donantes");
            DropForeignKey("dbo.Org_Donantes", "IdIdentificacionTipo", "dbo.Org_IdentificacionTipos");
            DropForeignKey("dbo.Org_Donantes_Empresas", "IdEmpresa", "dbo.Org_Empresas");
            DropForeignKey("dbo.Org_Donantes_Empresas", "IdDonante", "dbo.Org_Donantes");
            DropForeignKey("dbo.Org_EmpleadosCargosHistorico", "IdEmpleado", "dbo.Org_Empleados");
            DropForeignKey("dbo.Org_EmpleadosCargosHistorico", "IdCargo", "dbo.Org_Cargos");
            DropForeignKey("dbo.Org_Empleados", "IdCargo", "dbo.Org_Cargos");
            DropForeignKey("dbo.Org_Cargos", "IdArea", "dbo.Org_Areas");
            DropForeignKey("dbo.Org_Empresas", "IdPais", "dbo.M_Paises");
            DropForeignKey("dbo.Org_Empresas", "IdMenuPanel", "dbo.Cms_Menus");
            DropForeignKey("dbo.Org_Empresas", "IdMenuIzquierdo", "dbo.Cms_Menus");
            DropForeignKey("dbo.Org_Empresas", "IdMenuSuperior", "dbo.Cms_Menus");
            DropForeignKey("dbo.Acciones", "ModuloId", "dbo.Moduloes");
            DropForeignKey("dbo.AspNetRolesAcciones", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.AspNetRolesAcciones", "AccionesId", "dbo.Acciones");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.Sys_UsuariosOrg_Empresas", new[] { "Org_Empresas_IdEmpresa" });
            DropIndex("dbo.Sys_UsuariosOrg_Empresas", new[] { "Sys_Usuarios_IdUsuario" });
            DropIndex("dbo.AspNetRolesAcciones", new[] { "RoleId" });
            DropIndex("dbo.AspNetRolesAcciones", new[] { "AccionesId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.Sys_Usuarios_Empresas", new[] { "IdEmpresa" });
            DropIndex("dbo.Sys_Usuarios_Empresas", new[] { "IdUsuario" });
            DropIndex("dbo.Org_Proveedores", new[] { "IdIdentificacionTipo" });
            DropIndex("dbo.Org_Proveedores", new[] { "IdEmpresa" });
            DropIndex("dbo.Sys_Usuarios_Donantes", new[] { "IdDonante" });
            DropIndex("dbo.Sys_Usuarios_Donantes", new[] { "IdUsuario" });
            DropIndex("dbo.Tar_Listas", new[] { "IdUsuarioModificacion" });
            DropIndex("dbo.Tar_Listas", new[] { "IdUsuarioCreacion" });
            DropIndex("dbo.Tar_Listas", new[] { "IdProyecto" });
            DropIndex("dbo.Doc_Clientes_Categorias", new[] { "IdCategoria" });
            DropIndex("dbo.Doc_Clientes_Categorias", new[] { "IdCliente" });
            DropIndex("dbo.Doc_Documentos", new[] { "IdTipoArchivo" });
            DropIndex("dbo.Doc_Documentos", new[] { "IdCategoria" });
            DropIndex("dbo.Documentos_Tareas", new[] { "IdTarea" });
            DropIndex("dbo.Documentos_Tareas", new[] { "IdDocumento" });
            DropIndex("dbo.Tar_Tareas", new[] { "IdUsuarioCompletado" });
            DropIndex("dbo.Tar_Tareas", new[] { "IdUsuarioModificacion" });
            DropIndex("dbo.Tar_Tareas", new[] { "IdUsuarioCreacion" });
            DropIndex("dbo.Tar_Tareas", new[] { "IdResponsable" });
            DropIndex("dbo.Tar_Tareas", new[] { "IdLista" });
            DropIndex("dbo.Tar_Permisos_Bitacora", new[] { "IdVisita" });
            DropIndex("dbo.Tar_Permisos_Bitacora", new[] { "IdUsuario" });
            DropIndex("dbo.Tar_Visitas", new[] { "IdTarea" });
            DropIndex("dbo.Tar_Bitacora", new[] { "IdUsuario" });
            DropIndex("dbo.Tar_Bitacora", new[] { "IdVisita" });
            DropIndex("dbo.Com_Mensajes", new[] { "IdEstado" });
            DropIndex("dbo.Com_Mensajes", new[] { "IdUsuarioRemitente" });
            DropIndex("dbo.Pry_Proyectos_Donantes", new[] { "IdUsuarioResponsable" });
            DropIndex("dbo.Pry_Proyectos_Donantes", new[] { "IdDonante" });
            DropIndex("dbo.Pry_Proyectos_Donantes", new[] { "IdProyecto" });
            DropIndex("dbo.Pry_Bitacoras", new[] { "IdProyecto" });
            DropIndex("dbo.PRY_INFORMESICAOBJETIVOS", new[] { "IDOBJETIVO" });
            DropIndex("dbo.PRY_INFORMESICAOBJETIVOS", new[] { "IDINFORME" });
            DropIndex("dbo.PRY_INFORMESICADOCUMENTOS", new[] { "IDINFORME" });
            DropIndex("dbo.PRY_INFORMESICADETALLE", new[] { "IDINFORME" });
            DropIndex("dbo.PRY_INFORMESICA", new[] { "PERIODOFINAL" });
            DropIndex("dbo.PRY_INFORMESICA", new[] { "PERIODOINICIAL" });
            DropIndex("dbo.PRY_INFORMESICA", new[] { "IDESTADO" });
            DropIndex("dbo.PRY_INFORMESICA", new[] { "IDTIPO" });
            DropIndex("dbo.PRY_INFORMESICA", new[] { "IDPROYECTO" });
            DropIndex("dbo.PRY_INFORMESICAINDICADORES", new[] { "IDINDICADOR" });
            DropIndex("dbo.PRY_INFORMESICAINDICADORES", new[] { "IDINFORME" });
            DropIndex("dbo.Pry_Supuestos", new[] { "IdObjetivo" });
            DropIndex("dbo.Pry_Informes_Supuestos", new[] { "IdSupuesto" });
            DropIndex("dbo.Pry_Informes_Supuestos", new[] { "IdInforme" });
            DropIndex("dbo.Pry_Presupuesto", new[] { "IdProyecto" });
            DropIndex("dbo.Pry_Presupuesto", new[] { "IdTipoPresupuesto" });
            DropIndex("dbo.Pry_Proyectos_NivelAceptacion", new[] { "IdNivelAceptacion" });
            DropIndex("dbo.Pry_Proyectos_NivelAceptacion", new[] { "IdProyecto" });
            DropIndex("dbo.Pry_Informes_Presupuestos", new[] { "Evaluacion" });
            DropIndex("dbo.Pry_Informes_Presupuestos", new[] { "IdPresupuesto" });
            DropIndex("dbo.Pry_Informes_Presupuestos", new[] { "IdInforme" });
            DropIndex("dbo.M_PosiblesRespuestas", new[] { "IdPregunta" });
            DropIndex("dbo.M_ValoresRespuesta", new[] { "IdPreguntaResuelta" });
            DropIndex("dbo.M_PreguntasResueltas", new[] { "IdPregunta" });
            DropIndex("dbo.M_PreguntasResueltas", new[] { "IdEncuestaResuelta" });
            DropIndex("dbo.M_EncuestasResueltas", new[] { "IdEncuesta" });
            DropIndex("dbo.M_Encuestas", new[] { "IdIdioma" });
            DropIndex("dbo.M_Preguntas", new[] { "IdEncuesta" });
            DropIndex("dbo.Pry_Informes_Encuestas", new[] { "IdPregunta" });
            DropIndex("dbo.Pry_Informes_Encuestas", new[] { "IdInforme" });
            DropIndex("dbo.Pry_Informes_Donantes", new[] { "IdDonante" });
            DropIndex("dbo.Pry_Informes_Donantes", new[] { "IdInforme" });
            DropIndex("dbo.Pry_Informes", new[] { "IdEstado" });
            DropIndex("dbo.Pry_Informes", new[] { "EvaluacionProposito" });
            DropIndex("dbo.Pry_Informes", new[] { "EvaluacionComponentes" });
            DropIndex("dbo.Pry_Informes", new[] { "IdProyecto" });
            DropIndex("dbo.Pry_Informes_Indicador", new[] { "Evaluacion" });
            DropIndex("dbo.Pry_Informes_Indicador", new[] { "IdDatosMuestra" });
            DropIndex("dbo.Pry_Informes_Indicador", new[] { "IdIndicador" });
            DropIndex("dbo.Pry_Informes_Indicador", new[] { "IdInforme" });
            DropIndex("dbo.Pry_DatosVerificadores", new[] { "IdVerificador" });
            DropIndex("dbo.Pry_DatosVerificadores", new[] { "IdDatosMuestra" });
            DropIndex("dbo.Pry_IndicadoresVerificadores", new[] { "IdIndicador" });
            DropIndex("dbo.Pry_IndicadoresProyecto_Programa", new[] { "IdIndicadorProyecto" });
            DropIndex("dbo.PRY_EVALUACIONINDICADORESPERIODO", new[] { "IdHito" });
            DropIndex("dbo.PRY_EVALUACIONINDICADORESPERIODO", new[] { "IdResultado" });
            DropIndex("dbo.PRY_EVALUACIONINDICADORESPERIODO", new[] { "IdPeriodo" });
            DropIndex("dbo.PRY_EVALUACIONINDICADORESPERIODO", new[] { "IdProyecto" });
            DropIndex("dbo.Pry_EvaluacionHitos", new[] { "IdHito" });
            DropIndex("dbo.Pry_EvaluacionHitos", new[] { "IdActividad" });
            DropIndex("dbo.Pry_EvaluacionHitos", new[] { "IdResultado" });
            DropIndex("dbo.Pry_EvaluacionHitos", new[] { "IdPeriodo" });
            DropIndex("dbo.Pry_EvaluacionHitos", new[] { "IdProyecto" });
            DropIndex("dbo.Pry_Indicadores", new[] { "IdResponsableIndicador" });
            DropIndex("dbo.Pry_Indicadores", new[] { "IdSubTipo" });
            DropIndex("dbo.Pry_Indicadores", new[] { "IdTipo" });
            DropIndex("dbo.Pry_Indicadores_Variables", new[] { "IdVariable" });
            DropIndex("dbo.Pry_Indicadores_Variables", new[] { "IdIndicador" });
            DropIndex("dbo.Pry_DatosVariables", new[] { "IdVariable" });
            DropIndex("dbo.Pry_DatosVariables", new[] { "IdDatosMuestra" });
            DropIndex("dbo.Pry_DatosMuestras", new[] { "IdPeriodo" });
            DropIndex("dbo.Pry_DatosMuestras", new[] { "IdNivelAceptacionEfectividad" });
            DropIndex("dbo.Pry_DatosMuestras", new[] { "IdIndicador" });
            DropIndex("dbo.PRY_PERIODOSPROYECTOS", new[] { "IdProyecto" });
            DropIndex("dbo.PRY_EVALUACIONPROYECTOPERIODO", new[] { "IDPROYECTO" });
            DropIndex("dbo.PRY_EVALUACIONPROYECTOPERIODO", new[] { "IDPERIODO" });
            DropIndex("dbo.PRY_EVALUACIONESACTIVIDADESPERIODO", new[] { "IDPERIODO", "IDPROYECTO" });
            DropIndex("dbo.PRY_EVALUACIONESACTIVIDADESPERIODO", new[] { "IDOBJETIVO" });
            DropIndex("dbo.Pry_ProductividadBeneficiario", new[] { "IdBeneficiario" });
            DropIndex("dbo.Pry_Capacitaciones", new[] { "IdFacilitador" });
            DropIndex("dbo.Pry_CapacitacionBeneficiario", new[] { "IdBeneficiario" });
            DropIndex("dbo.Pry_CapacitacionBeneficiario", new[] { "IdCapacitacion" });
            DropIndex("dbo.Pry_Beneficiarios", new[] { "IdObjetivo" });
            DropIndex("dbo.Pry_Objetivos", new[] { "IdEmpresa" });
            DropIndex("dbo.Pry_Objetivos", new[] { "IdObjetivoClase" });
            DropIndex("dbo.Pry_Recursos", new[] { "IDPARTIDAGASTO" });
            DropIndex("dbo.Pry_Recursos", new[] { "IdObjetivo" });
            DropIndex("dbo.Pry_MontoDonacion", new[] { "IdMovimiento" });
            DropIndex("dbo.Pry_Movimientos", new[] { "MONEDALOCAL" });
            DropIndex("dbo.Pry_Movimientos", new[] { "IDPARTIDAGASTO" });
            DropIndex("dbo.Pry_Movimientos", new[] { "IdPeriodo" });
            DropIndex("dbo.Pry_Movimientos", new[] { "IdPresupuesto" });
            DropIndex("dbo.m_TipCambio", new[] { "M_Monedas_IdMoneda" });
            DropIndex("dbo.m_TipCambio", new[] { "idMoneda" });
            DropIndex("dbo.Pry_Proyectos", new[] { "IDPROYECTOPADRE" });
            DropIndex("dbo.Pry_Proyectos", new[] { "IdTipo" });
            DropIndex("dbo.Pry_Proyectos", new[] { "CustomerId" });
            DropIndex("dbo.Pry_Proyectos", new[] { "IdEstado" });
            DropIndex("dbo.Pry_Proyectos", new[] { "IdProposito" });
            DropIndex("dbo.Pry_Proyectos", new[] { "IdMoneda" });
            DropIndex("dbo.Pry_Proyectos", new[] { "IdUsuarioEvaluador" });
            DropIndex("dbo.Pry_Proyectos", new[] { "IdUsuarioDigitador" });
            DropIndex("dbo.Pry_Proyectos", new[] { "IdUsuarioResponsable" });
            DropIndex("dbo.Pry_CalendarioDonaciones", new[] { "IdDonante" });
            DropIndex("dbo.Pry_CalendarioDonaciones", new[] { "IdProyecto" });
            DropIndex("dbo.Org_Donantes_Empresas", new[] { "IdEmpresa" });
            DropIndex("dbo.Org_Donantes_Empresas", new[] { "IdDonante" });
            DropIndex("dbo.Org_Donantes", new[] { "Org_Empresas_IdEmpresa" });
            DropIndex("dbo.Org_Donantes", new[] { "Sys_Usuarios_IdUsuario" });
            DropIndex("dbo.Org_Donantes", new[] { "IdCliente" });
            DropIndex("dbo.Org_Donantes", new[] { "IdIdentificacionTipo" });
            DropIndex("dbo.Org_EmpleadosCargosHistorico", new[] { "IdCargo" });
            DropIndex("dbo.Org_EmpleadosCargosHistorico", new[] { "IdEmpleado" });
            DropIndex("dbo.Org_Empleados", new[] { "IdUsuario" });
            DropIndex("dbo.Org_Empleados", new[] { "IdIdentificacionTipo" });
            DropIndex("dbo.Org_Empleados", new[] { "IdCargo" });
            DropIndex("dbo.Org_Cargos", new[] { "IdArea" });
            DropIndex("dbo.Org_Areas", new[] { "IdEmpresa" });
            DropIndex("dbo.Org_Empresas", new[] { "IdCliente" });
            DropIndex("dbo.Org_Empresas", new[] { "IdMenuPanel" });
            DropIndex("dbo.Org_Empresas", new[] { "IdMenuIzquierdo" });
            DropIndex("dbo.Org_Empresas", new[] { "IdMenuSuperior" });
            DropIndex("dbo.Org_Empresas", new[] { "IdPais" });
            DropIndex("dbo.Org_Empresas", new[] { "IdIdentificacionTipo" });
            DropIndex("dbo.Cms_MenuNodos", new[] { "IdMenu" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.Acciones", new[] { "ModuloId" });
            DropTable("dbo.Sys_UsuariosOrg_Empresas");
            DropTable("dbo.AspNetRolesAcciones");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.View_saldoppto_resultado_tipo");
            DropTable("dbo.View_ppto_resultado_tipo");
            DropTable("dbo.View_InfromeDetalleEjecucionGasto");
            DropTable("dbo.View_InformeTecnicoAvanceHitos");
            DropTable("dbo.View_InformeRendicionGastos1fer");
            DropTable("dbo.View_InformeRendicionGastos1");
            DropTable("dbo.View_InformeCronogramaHitos1");
            DropTable("dbo.View_InformeCronogramaHitos");
            DropTable("dbo.View_InformeAvanceHitos");
            DropTable("dbo.View_InformeAdministrativoITFUNIP");
            DropTable("dbo.View_Informe_Saldos_FER");
            DropTable("dbo.View_Informe ITFSemestral");
            DropTable("dbo.View_Informe de Saldos");
            DropTable("dbo.View_ejecutado_resultado_tipo");
            DropTable("dbo.Tenants");
            DropTable("dbo.sysdiagrams");
            DropTable("dbo.Sys_Usuarios_Empresas");
            DropTable("dbo.M_Temas");
            DropTable("dbo.M_Plantillas");
            DropTable("dbo.M_Periodos");
            DropTable("dbo.Org_Proveedores");
            DropTable("dbo.Sys_Usuarios_Donantes");
            DropTable("dbo.Pry_ProyectosTipos");
            DropTable("dbo.Pry_ProyectosEstados");
            DropTable("dbo.Tar_Listas");
            DropTable("dbo.Sys_Clientes");
            DropTable("dbo.Doc_Clientes_Categorias");
            DropTable("dbo.Doc_Categorias");
            DropTable("dbo.Doc_ArchivosTipos");
            DropTable("dbo.Doc_Documentos");
            DropTable("dbo.Documentos_Tareas");
            DropTable("dbo.Tar_Tareas");
            DropTable("dbo.Tar_Permisos_Bitacora");
            DropTable("dbo.Tar_Visitas");
            DropTable("dbo.Tar_Bitacora");
            DropTable("dbo.Com_MensajesEstado");
            DropTable("dbo.Com_Mensajes");
            DropTable("dbo.Sys_Usuarios");
            DropTable("dbo.Pry_Proyectos_Donantes");
            DropTable("dbo.Pry_Bitacoras");
            DropTable("dbo.Pry_ObjetivosClase");
            DropTable("dbo.PRY_INFORMESICATIPOS");
            DropTable("dbo.PRY_INFORMESICAOBJETIVOS");
            DropTable("dbo.PRY_INFORMESICAESTADOS");
            DropTable("dbo.PRY_INFORMESICADOCUMENTOS");
            DropTable("dbo.PRY_INFORMESICADETALLE");
            DropTable("dbo.PRY_INFORMESICA");
            DropTable("dbo.PRY_INFORMESICAINDICADORES");
            DropTable("dbo.Pry_InformesEstados");
            DropTable("dbo.Pry_Supuestos");
            DropTable("dbo.Pry_Informes_Supuestos");
            DropTable("dbo.Pry_PresupuestoTipo");
            DropTable("dbo.Pry_Presupuesto");
            DropTable("dbo.Pry_Proyectos_NivelAceptacion");
            DropTable("dbo.Pry_NivelAceptacion");
            DropTable("dbo.Pry_Informes_Presupuestos");
            DropTable("dbo.M_PosiblesRespuestas");
            DropTable("dbo.M_Idiomas");
            DropTable("dbo.M_ValoresRespuesta");
            DropTable("dbo.M_PreguntasResueltas");
            DropTable("dbo.M_EncuestasResueltas");
            DropTable("dbo.M_Encuestas");
            DropTable("dbo.M_Preguntas");
            DropTable("dbo.Pry_Informes_Encuestas");
            DropTable("dbo.Pry_Informes_Donantes");
            DropTable("dbo.Pry_Informes");
            DropTable("dbo.Pry_Informes_Indicador");
            DropTable("dbo.Pry_DatosVerificadores");
            DropTable("dbo.Pry_IndicadoresVerificadores");
            DropTable("dbo.Pry_IndicadoresTipos");
            DropTable("dbo.Pry_IndicadoresProyecto_Programa");
            DropTable("dbo.PRY_EVALUACIONINDICADORESPERIODO");
            DropTable("dbo.Pry_EvaluacionHitos");
            DropTable("dbo.Pry_Indicadores");
            DropTable("dbo.Pry_Indicadores_Variables");
            DropTable("dbo.Pry_Variables");
            DropTable("dbo.Pry_DatosVariables");
            DropTable("dbo.Pry_DatosMuestras");
            DropTable("dbo.PRY_PERIODOSPROYECTOS");
            DropTable("dbo.PRY_EVALUACIONPROYECTOPERIODO");
            DropTable("dbo.PRY_EVALUACIONESACTIVIDADESPERIODO");
            DropTable("dbo.Pry_ProductividadBeneficiario");
            DropTable("dbo.Pry_Facilitadores");
            DropTable("dbo.Pry_Capacitaciones");
            DropTable("dbo.Pry_CapacitacionBeneficiario");
            DropTable("dbo.Pry_Beneficiarios");
            DropTable("dbo.Pry_Objetivos");
            DropTable("dbo.Pry_Recursos");
            DropTable("dbo.PRY_PARTIDAGASTOS");
            DropTable("dbo.Pry_MontoDonacion");
            DropTable("dbo.Pry_Movimientos");
            DropTable("dbo.m_TipCambio");
            DropTable("dbo.M_Monedas");
            DropTable("dbo.Pry_Proyectos");
            DropTable("dbo.Pry_CalendarioDonaciones");
            DropTable("dbo.Org_Donantes_Empresas");
            DropTable("dbo.Org_Donantes");
            DropTable("dbo.Org_IdentificacionTipos");
            DropTable("dbo.Org_EmpleadosCargosHistorico");
            DropTable("dbo.Org_Empleados");
            DropTable("dbo.Org_Cargos");
            DropTable("dbo.Org_Areas");
            DropTable("dbo.M_Paises");
            DropTable("dbo.Org_Empresas");
            DropTable("dbo.Cms_Menus");
            DropTable("dbo.Cms_MenuNodos");
            DropTable("dbo.Moduloes");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Acciones");
        }
    }
}
