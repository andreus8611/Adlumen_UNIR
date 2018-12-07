
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, and Azure
-- --------------------------------------------------
-- Date Created: 06/23/2015 22:05:09
-- Generated from EDMX file: C:\Users\Usuario\Source\Repos\Migracion a MVC\AdlumenMVC.Models\Model\Model.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [Adlumen2Soc_diaconia];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_Cms_MenuNodes_Cms_Menu]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Cms_MenuNodos] DROP CONSTRAINT [FK_Cms_MenuNodes_Cms_Menu];
GO
IF OBJECT_ID(N'[dbo].[FK_Com_Mensajes_Sys_Usuarios]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Com_Mensajes] DROP CONSTRAINT [FK_Com_Mensajes_Sys_Usuarios];
GO
IF OBJECT_ID(N'[dbo].[FK_Doc_Clientes_Categorias_Doc_Categorias]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Doc_Clientes_Categorias] DROP CONSTRAINT [FK_Doc_Clientes_Categorias_Doc_Categorias];
GO
IF OBJECT_ID(N'[dbo].[FK_Doc_Clientes_Categorias_Sys_Clientes]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Doc_Clientes_Categorias] DROP CONSTRAINT [FK_Doc_Clientes_Categorias_Sys_Clientes];
GO
IF OBJECT_ID(N'[dbo].[FK_Doc_Documentos_Doc_ArchivosTipos]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Doc_Documentos] DROP CONSTRAINT [FK_Doc_Documentos_Doc_ArchivosTipos];
GO
IF OBJECT_ID(N'[dbo].[FK_Doc_Documentos_Doc_Categorias]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Doc_Documentos] DROP CONSTRAINT [FK_Doc_Documentos_Doc_Categorias];
GO
IF OBJECT_ID(N'[dbo].[FK_M_Preguntas_M_Encuestas]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[M_Preguntas] DROP CONSTRAINT [FK_M_Preguntas_M_Encuestas];
GO
IF OBJECT_ID(N'[dbo].[FK_Mod_Messages_Mod_MessagesStatus]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Com_Mensajes] DROP CONSTRAINT [FK_Mod_Messages_Mod_MessagesStatus];
GO
IF OBJECT_ID(N'[dbo].[FK_Org_Areas_Org_Empresas]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Org_Areas] DROP CONSTRAINT [FK_Org_Areas_Org_Empresas];
GO
IF OBJECT_ID(N'[dbo].[FK_Org_Cargos_Org_Areas]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Org_Cargos] DROP CONSTRAINT [FK_Org_Cargos_Org_Areas];
GO
IF OBJECT_ID(N'[dbo].[FK_Org_Donantes_Empresas_Org_Donantes]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Org_Donantes_Empresas] DROP CONSTRAINT [FK_Org_Donantes_Empresas_Org_Donantes];
GO
IF OBJECT_ID(N'[dbo].[FK_Org_Donantes_Empresas_Org_Empresas]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Org_Donantes_Empresas] DROP CONSTRAINT [FK_Org_Donantes_Empresas_Org_Empresas];
GO
IF OBJECT_ID(N'[dbo].[FK_Org_Donantes_Org_IdentificacionTipos]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Org_Donantes] DROP CONSTRAINT [FK_Org_Donantes_Org_IdentificacionTipos];
GO
IF OBJECT_ID(N'[dbo].[FK_Org_Donantes_Sys_Clientes]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Org_Donantes] DROP CONSTRAINT [FK_Org_Donantes_Sys_Clientes];
GO
IF OBJECT_ID(N'[dbo].[FK_Org_Empleados_Org_Cargos]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Org_Empleados] DROP CONSTRAINT [FK_Org_Empleados_Org_Cargos];
GO
IF OBJECT_ID(N'[dbo].[FK_Org_Empleados_Org_IdentificacionTipos]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Org_Empleados] DROP CONSTRAINT [FK_Org_Empleados_Org_IdentificacionTipos];
GO
IF OBJECT_ID(N'[dbo].[FK_Org_Empleados_Sys_Usuarios]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Org_Empleados] DROP CONSTRAINT [FK_Org_Empleados_Sys_Usuarios];
GO
IF OBJECT_ID(N'[dbo].[FK_Org_EmpleadosCargosHistorico_Org_Cargos]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Org_EmpleadosCargosHistorico] DROP CONSTRAINT [FK_Org_EmpleadosCargosHistorico_Org_Cargos];
GO
IF OBJECT_ID(N'[dbo].[FK_Org_EmpleadosCargosHistorico_Org_Empleados]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Org_EmpleadosCargosHistorico] DROP CONSTRAINT [FK_Org_EmpleadosCargosHistorico_Org_Empleados];
GO
IF OBJECT_ID(N'[dbo].[FK_Org_Empresas_Cms_Menus]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Org_Empresas] DROP CONSTRAINT [FK_Org_Empresas_Cms_Menus];
GO
IF OBJECT_ID(N'[dbo].[FK_Org_Empresas_Cms_Menus1]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Org_Empresas] DROP CONSTRAINT [FK_Org_Empresas_Cms_Menus1];
GO
IF OBJECT_ID(N'[dbo].[FK_Org_Empresas_Cms_Menus2]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Org_Empresas] DROP CONSTRAINT [FK_Org_Empresas_Cms_Menus2];
GO
IF OBJECT_ID(N'[dbo].[FK_Org_Empresas_M_Paises]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Org_Empresas] DROP CONSTRAINT [FK_Org_Empresas_M_Paises];
GO
IF OBJECT_ID(N'[dbo].[FK_Org_Empresas_Org_IdentificacionTipos]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Org_Empresas] DROP CONSTRAINT [FK_Org_Empresas_Org_IdentificacionTipos];
GO
IF OBJECT_ID(N'[dbo].[FK_Org_Empresas_Sys_Clientes]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Org_Empresas] DROP CONSTRAINT [FK_Org_Empresas_Sys_Clientes];
GO
IF OBJECT_ID(N'[dbo].[FK_Org_Proveedores_Org_Empresas]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Org_Proveedores] DROP CONSTRAINT [FK_Org_Proveedores_Org_Empresas];
GO
IF OBJECT_ID(N'[dbo].[FK_Org_Proveedores_Org_IdentificacionTipos]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Org_Proveedores] DROP CONSTRAINT [FK_Org_Proveedores_Org_IdentificacionTipos];
GO
IF OBJECT_ID(N'[dbo].[FK_Pro_Proyectos_Donantes_Org_Donantes]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Pry_Proyectos_Donantes] DROP CONSTRAINT [FK_Pro_Proyectos_Donantes_Org_Donantes];
GO
IF OBJECT_ID(N'[dbo].[FK_Pro_Proyectos_Donantes_Pro_Proyectos]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Pry_Proyectos_Donantes] DROP CONSTRAINT [FK_Pro_Proyectos_Donantes_Pro_Proyectos];
GO
IF OBJECT_ID(N'[dbo].[FK_Pry_Bitacoras_Pry_Proyectos]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Pry_Bitacoras] DROP CONSTRAINT [FK_Pry_Bitacoras_Pry_Proyectos];
GO
IF OBJECT_ID(N'[dbo].[FK_Pry_Calendario_Donaciones_Org_Donantes]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Pry_CalendarioDonaciones] DROP CONSTRAINT [FK_Pry_Calendario_Donaciones_Org_Donantes];
GO
IF OBJECT_ID(N'[dbo].[FK_Pry_Calendario_Donaciones_Pry_Proyectos]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Pry_CalendarioDonaciones] DROP CONSTRAINT [FK_Pry_Calendario_Donaciones_Pry_Proyectos];
GO
IF OBJECT_ID(N'[dbo].[FK_Pry_DatosMuestras_Pry_Indicadores]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Pry_DatosMuestras] DROP CONSTRAINT [FK_Pry_DatosMuestras_Pry_Indicadores];
GO
IF OBJECT_ID(N'[dbo].[FK_Pry_DatosMuestras_Pry_NivelAceptacion]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Pry_DatosMuestras] DROP CONSTRAINT [FK_Pry_DatosMuestras_Pry_NivelAceptacion];
GO
IF OBJECT_ID(N'[dbo].[FK_Pry_DatosMuestras_PRY_PERIODOS]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Pry_DatosMuestras] DROP CONSTRAINT [FK_Pry_DatosMuestras_PRY_PERIODOS];
GO
IF OBJECT_ID(N'[dbo].[FK_Pry_DatosVariables_Pry_DatosMuestras]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Pry_DatosVariables] DROP CONSTRAINT [FK_Pry_DatosVariables_Pry_DatosMuestras];
GO
IF OBJECT_ID(N'[dbo].[FK_Pry_DatosVariables_Pry_Variables]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Pry_DatosVariables] DROP CONSTRAINT [FK_Pry_DatosVariables_Pry_Variables];
GO
IF OBJECT_ID(N'[dbo].[FK_Pry_DatosVerificadores_Pry_DatosMuestras]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Pry_DatosVerificadores] DROP CONSTRAINT [FK_Pry_DatosVerificadores_Pry_DatosMuestras];
GO
IF OBJECT_ID(N'[dbo].[FK_Pry_DatosVerificadores_Pry_IndicadoresVerificadores]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Pry_DatosVerificadores] DROP CONSTRAINT [FK_Pry_DatosVerificadores_Pry_IndicadoresVerificadores];
GO
IF OBJECT_ID(N'[dbo].[FK_PRY_EVALUACIONESACTIVIDADESPERIODO_PRY_EVALUACIONPROYECTOPERIODO]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PRY_EVALUACIONESACTIVIDADESPERIODO] DROP CONSTRAINT [FK_PRY_EVALUACIONESACTIVIDADESPERIODO_PRY_EVALUACIONPROYECTOPERIODO];
GO
IF OBJECT_ID(N'[dbo].[FK_PRY_EVALUACIONESACTIVIDADESPERIODO_Pry_Objetivos]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PRY_EVALUACIONESACTIVIDADESPERIODO] DROP CONSTRAINT [FK_PRY_EVALUACIONESACTIVIDADESPERIODO_Pry_Objetivos];
GO
IF OBJECT_ID(N'[dbo].[FK_Pry_EvaluacionHitos_Pry_Indicadores]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Pry_EvaluacionHitos] DROP CONSTRAINT [FK_Pry_EvaluacionHitos_Pry_Indicadores];
GO
IF OBJECT_ID(N'[dbo].[FK_Pry_EvaluacionHitos_Pry_Objetivos]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Pry_EvaluacionHitos] DROP CONSTRAINT [FK_Pry_EvaluacionHitos_Pry_Objetivos];
GO
IF OBJECT_ID(N'[dbo].[FK_Pry_EvaluacionHitos_Pry_Objetivos1]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Pry_EvaluacionHitos] DROP CONSTRAINT [FK_Pry_EvaluacionHitos_Pry_Objetivos1];
GO
IF OBJECT_ID(N'[dbo].[FK_Pry_EvaluacionHitos_PRY_PERIODOS]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Pry_EvaluacionHitos] DROP CONSTRAINT [FK_Pry_EvaluacionHitos_PRY_PERIODOS];
GO
IF OBJECT_ID(N'[dbo].[FK_Pry_EvaluacionHitos_Pry_Proyectos]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Pry_EvaluacionHitos] DROP CONSTRAINT [FK_Pry_EvaluacionHitos_Pry_Proyectos];
GO
IF OBJECT_ID(N'[dbo].[FK_PRY_EVALUACIONINDICADORESPERIODO_Pry_Indicadores]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PRY_EVALUACIONINDICADORESPERIODO] DROP CONSTRAINT [FK_PRY_EVALUACIONINDICADORESPERIODO_Pry_Indicadores];
GO
IF OBJECT_ID(N'[dbo].[FK_PRY_EVALUACIONINDICADORESPERIODO_Pry_Objetivos]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PRY_EVALUACIONINDICADORESPERIODO] DROP CONSTRAINT [FK_PRY_EVALUACIONINDICADORESPERIODO_Pry_Objetivos];
GO
IF OBJECT_ID(N'[dbo].[FK_PRY_EVALUACIONINDICADORESPERIODO_PRY_PERIODOS]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PRY_EVALUACIONINDICADORESPERIODO] DROP CONSTRAINT [FK_PRY_EVALUACIONINDICADORESPERIODO_PRY_PERIODOS];
GO
IF OBJECT_ID(N'[dbo].[FK_PRY_EVALUACIONINDICADORESPERIODO_Pry_Proyectos]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PRY_EVALUACIONINDICADORESPERIODO] DROP CONSTRAINT [FK_PRY_EVALUACIONINDICADORESPERIODO_Pry_Proyectos];
GO
IF OBJECT_ID(N'[dbo].[FK_PRY_EVALUACIONPROYECTOPERIODO_PRY_PERIODOS]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PRY_EVALUACIONPROYECTOPERIODO] DROP CONSTRAINT [FK_PRY_EVALUACIONPROYECTOPERIODO_PRY_PERIODOS];
GO
IF OBJECT_ID(N'[dbo].[FK_PRY_EVALUACIONPROYECTOPERIODO_Pry_Proyectos]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PRY_EVALUACIONPROYECTOPERIODO] DROP CONSTRAINT [FK_PRY_EVALUACIONPROYECTOPERIODO_Pry_Proyectos];
GO
IF OBJECT_ID(N'[dbo].[FK_Pry_Indicadores_Org_Empleados]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Pry_Indicadores] DROP CONSTRAINT [FK_Pry_Indicadores_Org_Empleados];
GO
IF OBJECT_ID(N'[dbo].[FK_Pry_Indicadores_Pry_IndicadoresTipos]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Pry_Indicadores] DROP CONSTRAINT [FK_Pry_Indicadores_Pry_IndicadoresTipos];
GO
IF OBJECT_ID(N'[dbo].[FK_Pry_Indicadores_Pry_IndicadoresTipos1]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Pry_Indicadores] DROP CONSTRAINT [FK_Pry_Indicadores_Pry_IndicadoresTipos1];
GO
IF OBJECT_ID(N'[dbo].[FK_Pry_Indicadores_Variables_Pry_Indicadores]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Pry_Indicadores_Variables] DROP CONSTRAINT [FK_Pry_Indicadores_Variables_Pry_Indicadores];
GO
IF OBJECT_ID(N'[dbo].[FK_Pry_Indicadores_Variables_Pry_Variables]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Pry_Indicadores_Variables] DROP CONSTRAINT [FK_Pry_Indicadores_Variables_Pry_Variables];
GO
IF OBJECT_ID(N'[dbo].[FK_Pry_IndicadoresProyecto_Programa_Pry_Indicadores]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Pry_IndicadoresProyecto_Programa] DROP CONSTRAINT [FK_Pry_IndicadoresProyecto_Programa_Pry_Indicadores];
GO
IF OBJECT_ID(N'[dbo].[FK_Pry_IndicadoresVerificadores_Pry_Indicadores]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Pry_IndicadoresVerificadores] DROP CONSTRAINT [FK_Pry_IndicadoresVerificadores_Pry_Indicadores];
GO
IF OBJECT_ID(N'[dbo].[FK_Pry_Informes_Donantes_Org_Donantes]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Pry_Informes_Donantes] DROP CONSTRAINT [FK_Pry_Informes_Donantes_Org_Donantes];
GO
IF OBJECT_ID(N'[dbo].[FK_Pry_Informes_Donantes_Pry_Informes]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Pry_Informes_Donantes] DROP CONSTRAINT [FK_Pry_Informes_Donantes_Pry_Informes];
GO
IF OBJECT_ID(N'[dbo].[FK_Pry_Informes_Encuestas_M_Preguntas]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Pry_Informes_Encuestas] DROP CONSTRAINT [FK_Pry_Informes_Encuestas_M_Preguntas];
GO
IF OBJECT_ID(N'[dbo].[FK_Pry_Informes_Encuestas_Pry_Informes]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Pry_Informes_Encuestas] DROP CONSTRAINT [FK_Pry_Informes_Encuestas_Pry_Informes];
GO
IF OBJECT_ID(N'[dbo].[FK_Pry_Informes_Indicador_Pry_DatosMuestras]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Pry_Informes_Indicador] DROP CONSTRAINT [FK_Pry_Informes_Indicador_Pry_DatosMuestras];
GO
IF OBJECT_ID(N'[dbo].[FK_Pry_Informes_Indicador_Pry_Indicadores]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Pry_Informes_Indicador] DROP CONSTRAINT [FK_Pry_Informes_Indicador_Pry_Indicadores];
GO
IF OBJECT_ID(N'[dbo].[FK_Pry_Informes_Indicador_Pry_Informes]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Pry_Informes_Indicador] DROP CONSTRAINT [FK_Pry_Informes_Indicador_Pry_Informes];
GO
IF OBJECT_ID(N'[dbo].[FK_Pry_Informes_Indicador_Pry_NivelAceptacion]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Pry_Informes_Indicador] DROP CONSTRAINT [FK_Pry_Informes_Indicador_Pry_NivelAceptacion];
GO
IF OBJECT_ID(N'[dbo].[FK_Pry_Informes_Presupuestos_Pry_Informes]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Pry_Informes_Presupuestos] DROP CONSTRAINT [FK_Pry_Informes_Presupuestos_Pry_Informes];
GO
IF OBJECT_ID(N'[dbo].[FK_Pry_Informes_Presupuestos_Pry_NivelAceptacion]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Pry_Informes_Presupuestos] DROP CONSTRAINT [FK_Pry_Informes_Presupuestos_Pry_NivelAceptacion];
GO
IF OBJECT_ID(N'[dbo].[FK_Pry_Informes_Presupuestos_Pry_Presupuesto]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Pry_Informes_Presupuestos] DROP CONSTRAINT [FK_Pry_Informes_Presupuestos_Pry_Presupuesto];
GO
IF OBJECT_ID(N'[dbo].[FK_Pry_Informes_Pry_InformesEstados]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Pry_Informes] DROP CONSTRAINT [FK_Pry_Informes_Pry_InformesEstados];
GO
IF OBJECT_ID(N'[dbo].[FK_Pry_Informes_Pry_NivelAceptacion]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Pry_Informes] DROP CONSTRAINT [FK_Pry_Informes_Pry_NivelAceptacion];
GO
IF OBJECT_ID(N'[dbo].[FK_Pry_Informes_Pry_NivelAceptacion1]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Pry_Informes] DROP CONSTRAINT [FK_Pry_Informes_Pry_NivelAceptacion1];
GO
IF OBJECT_ID(N'[dbo].[FK_Pry_Informes_Pry_Proyectos]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Pry_Informes] DROP CONSTRAINT [FK_Pry_Informes_Pry_Proyectos];
GO
IF OBJECT_ID(N'[dbo].[FK_Pry_Informes_Supuestos_Pry_Informes]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Pry_Informes_Supuestos] DROP CONSTRAINT [FK_Pry_Informes_Supuestos_Pry_Informes];
GO
IF OBJECT_ID(N'[dbo].[FK_Pry_Informes_Supuestos_Pry_Supuestos]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Pry_Informes_Supuestos] DROP CONSTRAINT [FK_Pry_Informes_Supuestos_Pry_Supuestos];
GO
IF OBJECT_ID(N'[dbo].[FK_PRY_INFORMESICA_PRY_INFORMESICAESTADOS]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PRY_INFORMESICA] DROP CONSTRAINT [FK_PRY_INFORMESICA_PRY_INFORMESICAESTADOS];
GO
IF OBJECT_ID(N'[dbo].[FK_PRY_INFORMESICA_PRY_INFORMESICATIPOS]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PRY_INFORMESICA] DROP CONSTRAINT [FK_PRY_INFORMESICA_PRY_INFORMESICATIPOS];
GO
IF OBJECT_ID(N'[dbo].[FK_PRY_INFORMESICA_PRY_PERIODOS]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PRY_INFORMESICA] DROP CONSTRAINT [FK_PRY_INFORMESICA_PRY_PERIODOS];
GO
IF OBJECT_ID(N'[dbo].[FK_PRY_INFORMESICA_PRY_PERIODOS1]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PRY_INFORMESICA] DROP CONSTRAINT [FK_PRY_INFORMESICA_PRY_PERIODOS1];
GO
IF OBJECT_ID(N'[dbo].[FK_PRY_INFORMESICA_Pry_Proyectos]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PRY_INFORMESICA] DROP CONSTRAINT [FK_PRY_INFORMESICA_Pry_Proyectos];
GO
IF OBJECT_ID(N'[dbo].[FK_PRY_INFORMESICADETALLE_PRY_INFORMESICA]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PRY_INFORMESICADETALLE] DROP CONSTRAINT [FK_PRY_INFORMESICADETALLE_PRY_INFORMESICA];
GO
IF OBJECT_ID(N'[dbo].[FK_PRY_INFORMESICADOCUMENTOS_PRY_INFORMESICA]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PRY_INFORMESICADOCUMENTOS] DROP CONSTRAINT [FK_PRY_INFORMESICADOCUMENTOS_PRY_INFORMESICA];
GO
IF OBJECT_ID(N'[dbo].[FK_PRY_INFORMESICAINDICADORES_Pry_Indicadores]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PRY_INFORMESICAINDICADORES] DROP CONSTRAINT [FK_PRY_INFORMESICAINDICADORES_Pry_Indicadores];
GO
IF OBJECT_ID(N'[dbo].[FK_PRY_INFORMESICAINDICADORES_PRY_INFORMESICA]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PRY_INFORMESICAINDICADORES] DROP CONSTRAINT [FK_PRY_INFORMESICAINDICADORES_PRY_INFORMESICA];
GO
IF OBJECT_ID(N'[dbo].[FK_PRY_INFORMESICAOBJETIVOS_PRY_INFORMESICA]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PRY_INFORMESICAOBJETIVOS] DROP CONSTRAINT [FK_PRY_INFORMESICAOBJETIVOS_PRY_INFORMESICA];
GO
IF OBJECT_ID(N'[dbo].[FK_PRY_INFORMESICAOBJETIVOS_Pry_Objetivos]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PRY_INFORMESICAOBJETIVOS] DROP CONSTRAINT [FK_PRY_INFORMESICAOBJETIVOS_Pry_Objetivos];
GO
IF OBJECT_ID(N'[dbo].[FK_Pry_Movimientos_M_Monedas]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Pry_Movimientos] DROP CONSTRAINT [FK_Pry_Movimientos_M_Monedas];
GO
IF OBJECT_ID(N'[dbo].[FK_Pry_Movimientos_PRY_PARTIDAGASTOS]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Pry_Movimientos] DROP CONSTRAINT [FK_Pry_Movimientos_PRY_PARTIDAGASTOS];
GO
IF OBJECT_ID(N'[dbo].[FK_Pry_Movimientos_PRY_PERIODOS]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Pry_Movimientos] DROP CONSTRAINT [FK_Pry_Movimientos_PRY_PERIODOS];
GO
IF OBJECT_ID(N'[dbo].[FK_Pry_Movimientos_Pry_Presupuesto]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Pry_Movimientos] DROP CONSTRAINT [FK_Pry_Movimientos_Pry_Presupuesto];
GO
IF OBJECT_ID(N'[dbo].[FK_Pry_Objetivos_Org_Empresas]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Pry_Objetivos] DROP CONSTRAINT [FK_Pry_Objetivos_Org_Empresas];
GO
IF OBJECT_ID(N'[dbo].[FK_Pry_Objetivos_Pry_ObjetivosClase]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Pry_Objetivos] DROP CONSTRAINT [FK_Pry_Objetivos_Pry_ObjetivosClase];
GO
IF OBJECT_ID(N'[dbo].[FK_PRY_PERIODOSPROYECTOS_Pry_Proyectos]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PRY_PERIODOSPROYECTOS] DROP CONSTRAINT [FK_PRY_PERIODOSPROYECTOS_Pry_Proyectos];
GO
IF OBJECT_ID(N'[dbo].[FK_Pry_Presupuesto_Pry_PresupuestoTipo]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Pry_Presupuesto] DROP CONSTRAINT [FK_Pry_Presupuesto_Pry_PresupuestoTipo];
GO
IF OBJECT_ID(N'[dbo].[FK_Pry_Presupuesto_Pry_Proyectos]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Pry_Presupuesto] DROP CONSTRAINT [FK_Pry_Presupuesto_Pry_Proyectos];
GO
IF OBJECT_ID(N'[dbo].[FK_Pry_Proyectos_Donantes_Sys_Usuarios]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Pry_Proyectos_Donantes] DROP CONSTRAINT [FK_Pry_Proyectos_Donantes_Sys_Usuarios];
GO
IF OBJECT_ID(N'[dbo].[FK_Pry_Proyectos_M_Monedas]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Pry_Proyectos] DROP CONSTRAINT [FK_Pry_Proyectos_M_Monedas];
GO
IF OBJECT_ID(N'[dbo].[FK_Pry_Proyectos_NivelAceptacion_Pry_NivelAceptacion]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Pry_Proyectos_NivelAceptacion] DROP CONSTRAINT [FK_Pry_Proyectos_NivelAceptacion_Pry_NivelAceptacion];
GO
IF OBJECT_ID(N'[dbo].[FK_Pry_Proyectos_NivelAceptacion_Pry_Proyectos]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Pry_Proyectos_NivelAceptacion] DROP CONSTRAINT [FK_Pry_Proyectos_NivelAceptacion_Pry_Proyectos];
GO
IF OBJECT_ID(N'[dbo].[FK_Pry_Proyectos_Pry_Objetivos]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Pry_Proyectos] DROP CONSTRAINT [FK_Pry_Proyectos_Pry_Objetivos];
GO
IF OBJECT_ID(N'[dbo].[FK_Pry_Proyectos_Pry_Proyectos]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Pry_Proyectos] DROP CONSTRAINT [FK_Pry_Proyectos_Pry_Proyectos];
GO
IF OBJECT_ID(N'[dbo].[FK_Pry_Proyectos_Pry_ProyectosEstados]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Pry_Proyectos] DROP CONSTRAINT [FK_Pry_Proyectos_Pry_ProyectosEstados];
GO
IF OBJECT_ID(N'[dbo].[FK_Pry_Proyectos_Pry_ProyectosTipos]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Pry_Proyectos] DROP CONSTRAINT [FK_Pry_Proyectos_Pry_ProyectosTipos];
GO
IF OBJECT_ID(N'[dbo].[FK_Pry_Proyectos_Sys_Clientes]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Pry_Proyectos] DROP CONSTRAINT [FK_Pry_Proyectos_Sys_Clientes];
GO
IF OBJECT_ID(N'[dbo].[FK_Pry_Proyectos_Sys_Usuarios]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Pry_Proyectos] DROP CONSTRAINT [FK_Pry_Proyectos_Sys_Usuarios];
GO
IF OBJECT_ID(N'[dbo].[FK_Pry_Proyectos_Sys_Usuarios1]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Pry_Proyectos] DROP CONSTRAINT [FK_Pry_Proyectos_Sys_Usuarios1];
GO
IF OBJECT_ID(N'[dbo].[FK_Pry_Proyectos_Sys_Usuarios2]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Pry_Proyectos] DROP CONSTRAINT [FK_Pry_Proyectos_Sys_Usuarios2];
GO
IF OBJECT_ID(N'[dbo].[FK_Pry_Recursos_Pry_Objetivos]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Pry_Recursos] DROP CONSTRAINT [FK_Pry_Recursos_Pry_Objetivos];
GO
IF OBJECT_ID(N'[dbo].[FK_Pry_Recursos_PRY_PARTIDAGASTOS]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Pry_Recursos] DROP CONSTRAINT [FK_Pry_Recursos_PRY_PARTIDAGASTOS];
GO
IF OBJECT_ID(N'[dbo].[FK_Pry_Supuestos_Pry_Objetivos]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Pry_Supuestos] DROP CONSTRAINT [FK_Pry_Supuestos_Pry_Objetivos];
GO
IF OBJECT_ID(N'[dbo].[FK_Sys_Usuarios_Donantes_Org_Donantes]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Sys_Usuarios_Donantes] DROP CONSTRAINT [FK_Sys_Usuarios_Donantes_Org_Donantes];
GO
IF OBJECT_ID(N'[dbo].[FK_Sys_Usuarios_Donantes_Sys_Usuarios]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Sys_Usuarios_Donantes] DROP CONSTRAINT [FK_Sys_Usuarios_Donantes_Sys_Usuarios];
GO
IF OBJECT_ID(N'[dbo].[FK_Sys_Usuarios_Empresas_Org_Empresas]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Sys_Usuarios_Empresas] DROP CONSTRAINT [FK_Sys_Usuarios_Empresas_Org_Empresas];
GO
IF OBJECT_ID(N'[dbo].[FK_Sys_Usuarios_Empresas_Sys_Usuarios]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Sys_Usuarios_Empresas] DROP CONSTRAINT [FK_Sys_Usuarios_Empresas_Sys_Usuarios];
GO
IF OBJECT_ID(N'[dbo].[FK_Tar_Listas_Pry_Proyectos]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Tar_Listas] DROP CONSTRAINT [FK_Tar_Listas_Pry_Proyectos];
GO
IF OBJECT_ID(N'[dbo].[FK_Tar_Listas_Sys_Usuarios]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Tar_Listas] DROP CONSTRAINT [FK_Tar_Listas_Sys_Usuarios];
GO
IF OBJECT_ID(N'[dbo].[FK_Tar_Listas_Sys_Usuarios1]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Tar_Listas] DROP CONSTRAINT [FK_Tar_Listas_Sys_Usuarios1];
GO
IF OBJECT_ID(N'[dbo].[FK_Tar_Tareas_Sys_Usuarios]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Tar_Tareas] DROP CONSTRAINT [FK_Tar_Tareas_Sys_Usuarios];
GO
IF OBJECT_ID(N'[dbo].[FK_Tar_Tareas_Sys_Usuarios1]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Tar_Tareas] DROP CONSTRAINT [FK_Tar_Tareas_Sys_Usuarios1];
GO
IF OBJECT_ID(N'[dbo].[FK_Tar_Tareas_Sys_Usuarios2]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Tar_Tareas] DROP CONSTRAINT [FK_Tar_Tareas_Sys_Usuarios2];
GO
IF OBJECT_ID(N'[dbo].[FK_Tar_Tareas_Sys_Usuarios3]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Tar_Tareas] DROP CONSTRAINT [FK_Tar_Tareas_Sys_Usuarios3];
GO
IF OBJECT_ID(N'[dbo].[FK_Tar_Tareas_Tar_Listas]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Tar_Tareas] DROP CONSTRAINT [FK_Tar_Tareas_Tar_Listas];
GO
IF OBJECT_ID(N'[dbo].[FK_KEY_PRY_BENEFICIARIO_CAPACITACIONES]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Pry_CapacitacionBeneficiario] DROP CONSTRAINT [FK_KEY_PRY_BENEFICIARIO_CAPACITACIONES];
GO
IF OBJECT_ID(N'[dbo].[FK_KEY_PRY_BENEFICIARIOS]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Pry_Beneficiarios] DROP CONSTRAINT [FK_KEY_PRY_BENEFICIARIOS];
GO
IF OBJECT_ID(N'[dbo].[FK_KEY_PRY_CAPACITACIONES]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Pry_Capacitaciones] DROP CONSTRAINT [FK_KEY_PRY_CAPACITACIONES];
GO
IF OBJECT_ID(N'[dbo].[FK_KEY_PRY_CAPACITACIONES_BENEFICIARIO]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Pry_CapacitacionBeneficiario] DROP CONSTRAINT [FK_KEY_PRY_CAPACITACIONES_BENEFICIARIO];
GO
IF OBJECT_ID(N'[dbo].[FK_KEY_PRY_PRODUCTIVIDAD_BENEFICIARIO]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Pry_ProductividadBeneficiario] DROP CONSTRAINT [FK_KEY_PRY_PRODUCTIVIDAD_BENEFICIARIO];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Cms_MenuNodos]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Cms_MenuNodos];
GO
IF OBJECT_ID(N'[dbo].[Cms_Menus]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Cms_Menus];
GO
IF OBJECT_ID(N'[dbo].[Com_Mensajes]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Com_Mensajes];
GO
IF OBJECT_ID(N'[dbo].[Com_MensajesEstado]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Com_MensajesEstado];
GO
IF OBJECT_ID(N'[dbo].[Doc_ArchivosTipos]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Doc_ArchivosTipos];
GO
IF OBJECT_ID(N'[dbo].[Doc_Categorias]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Doc_Categorias];
GO
IF OBJECT_ID(N'[dbo].[Doc_Clientes_Categorias]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Doc_Clientes_Categorias];
GO
IF OBJECT_ID(N'[dbo].[Doc_Documentos]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Doc_Documentos];
GO
IF OBJECT_ID(N'[dbo].[M_Encuestas]', 'U') IS NOT NULL
    DROP TABLE [dbo].[M_Encuestas];
GO
IF OBJECT_ID(N'[dbo].[M_Idiomas]', 'U') IS NOT NULL
    DROP TABLE [dbo].[M_Idiomas];
GO
IF OBJECT_ID(N'[dbo].[M_Monedas]', 'U') IS NOT NULL
    DROP TABLE [dbo].[M_Monedas];
GO
IF OBJECT_ID(N'[dbo].[M_Paises]', 'U') IS NOT NULL
    DROP TABLE [dbo].[M_Paises];
GO
IF OBJECT_ID(N'[dbo].[M_Periodos]', 'U') IS NOT NULL
    DROP TABLE [dbo].[M_Periodos];
GO
IF OBJECT_ID(N'[dbo].[M_Preguntas]', 'U') IS NOT NULL
    DROP TABLE [dbo].[M_Preguntas];
GO
IF OBJECT_ID(N'[dbo].[M_Temas]', 'U') IS NOT NULL
    DROP TABLE [dbo].[M_Temas];
GO
IF OBJECT_ID(N'[dbo].[Org_Areas]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Org_Areas];
GO
IF OBJECT_ID(N'[dbo].[Org_Cargos]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Org_Cargos];
GO
IF OBJECT_ID(N'[dbo].[Org_Donantes]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Org_Donantes];
GO
IF OBJECT_ID(N'[dbo].[Org_Donantes_Empresas]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Org_Donantes_Empresas];
GO
IF OBJECT_ID(N'[dbo].[Org_Empleados]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Org_Empleados];
GO
IF OBJECT_ID(N'[dbo].[Org_EmpleadosCargosHistorico]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Org_EmpleadosCargosHistorico];
GO
IF OBJECT_ID(N'[dbo].[Org_Empresas]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Org_Empresas];
GO
IF OBJECT_ID(N'[dbo].[Org_IdentificacionTipos]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Org_IdentificacionTipos];
GO
IF OBJECT_ID(N'[dbo].[Org_Proveedores]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Org_Proveedores];
GO
IF OBJECT_ID(N'[dbo].[Pry_Beneficiarios]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Pry_Beneficiarios];
GO
IF OBJECT_ID(N'[dbo].[Pry_Bitacoras]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Pry_Bitacoras];
GO
IF OBJECT_ID(N'[dbo].[Pry_CalendarioDonaciones]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Pry_CalendarioDonaciones];
GO
IF OBJECT_ID(N'[dbo].[Pry_CapacitacionBeneficiario]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Pry_CapacitacionBeneficiario];
GO
IF OBJECT_ID(N'[dbo].[Pry_Capacitaciones]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Pry_Capacitaciones];
GO
IF OBJECT_ID(N'[dbo].[Pry_DatosMuestras]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Pry_DatosMuestras];
GO
IF OBJECT_ID(N'[dbo].[Pry_DatosVariables]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Pry_DatosVariables];
GO
IF OBJECT_ID(N'[dbo].[Pry_DatosVerificadores]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Pry_DatosVerificadores];
GO
IF OBJECT_ID(N'[dbo].[PRY_EVALUACIONESACTIVIDADESPERIODO]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PRY_EVALUACIONESACTIVIDADESPERIODO];
GO
IF OBJECT_ID(N'[dbo].[Pry_EvaluacionHitos]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Pry_EvaluacionHitos];
GO
IF OBJECT_ID(N'[dbo].[PRY_EVALUACIONINDICADORESPERIODO]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PRY_EVALUACIONINDICADORESPERIODO];
GO
IF OBJECT_ID(N'[dbo].[PRY_EVALUACIONPROYECTOPERIODO]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PRY_EVALUACIONPROYECTOPERIODO];
GO
IF OBJECT_ID(N'[dbo].[Pry_Facilitadores]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Pry_Facilitadores];
GO
IF OBJECT_ID(N'[dbo].[Pry_Indicadores]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Pry_Indicadores];
GO
IF OBJECT_ID(N'[dbo].[Pry_Indicadores_Variables]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Pry_Indicadores_Variables];
GO
IF OBJECT_ID(N'[dbo].[Pry_IndicadoresProyecto_Programa]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Pry_IndicadoresProyecto_Programa];
GO
IF OBJECT_ID(N'[dbo].[Pry_IndicadoresTipos]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Pry_IndicadoresTipos];
GO
IF OBJECT_ID(N'[dbo].[Pry_IndicadoresVerificadores]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Pry_IndicadoresVerificadores];
GO
IF OBJECT_ID(N'[dbo].[Pry_Informes]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Pry_Informes];
GO
IF OBJECT_ID(N'[dbo].[Pry_Informes_Donantes]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Pry_Informes_Donantes];
GO
IF OBJECT_ID(N'[dbo].[Pry_Informes_Encuestas]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Pry_Informes_Encuestas];
GO
IF OBJECT_ID(N'[dbo].[Pry_Informes_Indicador]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Pry_Informes_Indicador];
GO
IF OBJECT_ID(N'[dbo].[Pry_Informes_Presupuestos]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Pry_Informes_Presupuestos];
GO
IF OBJECT_ID(N'[dbo].[Pry_Informes_Supuestos]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Pry_Informes_Supuestos];
GO
IF OBJECT_ID(N'[dbo].[Pry_InformesEstados]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Pry_InformesEstados];
GO
IF OBJECT_ID(N'[dbo].[PRY_INFORMESICA]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PRY_INFORMESICA];
GO
IF OBJECT_ID(N'[dbo].[PRY_INFORMESICADETALLE]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PRY_INFORMESICADETALLE];
GO
IF OBJECT_ID(N'[dbo].[PRY_INFORMESICADOCUMENTOS]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PRY_INFORMESICADOCUMENTOS];
GO
IF OBJECT_ID(N'[dbo].[PRY_INFORMESICAESTADOS]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PRY_INFORMESICAESTADOS];
GO
IF OBJECT_ID(N'[dbo].[PRY_INFORMESICAINDICADORES]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PRY_INFORMESICAINDICADORES];
GO
IF OBJECT_ID(N'[dbo].[PRY_INFORMESICAOBJETIVOS]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PRY_INFORMESICAOBJETIVOS];
GO
IF OBJECT_ID(N'[dbo].[PRY_INFORMESICATIPOS]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PRY_INFORMESICATIPOS];
GO
IF OBJECT_ID(N'[dbo].[Pry_Movimientos]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Pry_Movimientos];
GO
IF OBJECT_ID(N'[dbo].[Pry_NivelAceptacion]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Pry_NivelAceptacion];
GO
IF OBJECT_ID(N'[dbo].[Pry_Objetivos]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Pry_Objetivos];
GO
IF OBJECT_ID(N'[dbo].[Pry_ObjetivosClase]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Pry_ObjetivosClase];
GO
IF OBJECT_ID(N'[dbo].[PRY_PARTIDAGASTOS]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PRY_PARTIDAGASTOS];
GO
IF OBJECT_ID(N'[dbo].[PRY_PERIODOSPROYECTOS]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PRY_PERIODOSPROYECTOS];
GO
IF OBJECT_ID(N'[dbo].[Pry_Presupuesto]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Pry_Presupuesto];
GO
IF OBJECT_ID(N'[dbo].[Pry_PresupuestoTipo]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Pry_PresupuestoTipo];
GO
IF OBJECT_ID(N'[dbo].[Pry_ProductividadBeneficiario]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Pry_ProductividadBeneficiario];
GO
IF OBJECT_ID(N'[dbo].[Pry_Proyectos]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Pry_Proyectos];
GO
IF OBJECT_ID(N'[dbo].[Pry_Proyectos_Donantes]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Pry_Proyectos_Donantes];
GO
IF OBJECT_ID(N'[dbo].[Pry_Proyectos_NivelAceptacion]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Pry_Proyectos_NivelAceptacion];
GO
IF OBJECT_ID(N'[dbo].[Pry_ProyectosEstados]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Pry_ProyectosEstados];
GO
IF OBJECT_ID(N'[dbo].[Pry_ProyectosTipos]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Pry_ProyectosTipos];
GO
IF OBJECT_ID(N'[dbo].[Pry_Recursos]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Pry_Recursos];
GO
IF OBJECT_ID(N'[dbo].[Pry_Supuestos]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Pry_Supuestos];
GO
IF OBJECT_ID(N'[dbo].[Pry_Variables]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Pry_Variables];
GO
IF OBJECT_ID(N'[dbo].[Sys_Clientes]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Sys_Clientes];
GO
IF OBJECT_ID(N'[dbo].[Sys_Usuarios]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Sys_Usuarios];
GO
IF OBJECT_ID(N'[dbo].[Sys_Usuarios_Donantes]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Sys_Usuarios_Donantes];
GO
IF OBJECT_ID(N'[dbo].[Sys_Usuarios_Empresas]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Sys_Usuarios_Empresas];
GO
IF OBJECT_ID(N'[dbo].[sysdiagrams]', 'U') IS NOT NULL
    DROP TABLE [dbo].[sysdiagrams];
GO
IF OBJECT_ID(N'[dbo].[Tar_Listas]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Tar_Listas];
GO
IF OBJECT_ID(N'[dbo].[Tar_Tareas]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Tar_Tareas];
GO
IF OBJECT_ID(N'[Adlumen2SocModelStoreContainer].[View_ejecutado_resultado_tipo]', 'U') IS NOT NULL
    DROP TABLE [Adlumen2SocModelStoreContainer].[View_ejecutado_resultado_tipo];
GO
IF OBJECT_ID(N'[Adlumen2SocModelStoreContainer].[View_Informe de Saldos]', 'U') IS NOT NULL
    DROP TABLE [Adlumen2SocModelStoreContainer].[View_Informe de Saldos];
GO
IF OBJECT_ID(N'[Adlumen2SocModelStoreContainer].[View_Informe ITFSemestral]', 'U') IS NOT NULL
    DROP TABLE [Adlumen2SocModelStoreContainer].[View_Informe ITFSemestral];
GO
IF OBJECT_ID(N'[Adlumen2SocModelStoreContainer].[View_Informe_Saldos_FER]', 'U') IS NOT NULL
    DROP TABLE [Adlumen2SocModelStoreContainer].[View_Informe_Saldos_FER];
GO
IF OBJECT_ID(N'[Adlumen2SocModelStoreContainer].[View_InformeAdministrativoITFUNIP]', 'U') IS NOT NULL
    DROP TABLE [Adlumen2SocModelStoreContainer].[View_InformeAdministrativoITFUNIP];
GO
IF OBJECT_ID(N'[Adlumen2SocModelStoreContainer].[View_InformeAvanceHitos]', 'U') IS NOT NULL
    DROP TABLE [Adlumen2SocModelStoreContainer].[View_InformeAvanceHitos];
GO
IF OBJECT_ID(N'[Adlumen2SocModelStoreContainer].[View_InformeCronogramaHitos]', 'U') IS NOT NULL
    DROP TABLE [Adlumen2SocModelStoreContainer].[View_InformeCronogramaHitos];
GO
IF OBJECT_ID(N'[Adlumen2SocModelStoreContainer].[View_InformeCronogramaHitos1]', 'U') IS NOT NULL
    DROP TABLE [Adlumen2SocModelStoreContainer].[View_InformeCronogramaHitos1];
GO
IF OBJECT_ID(N'[Adlumen2SocModelStoreContainer].[View_InformeRendicionGastos1]', 'U') IS NOT NULL
    DROP TABLE [Adlumen2SocModelStoreContainer].[View_InformeRendicionGastos1];
GO
IF OBJECT_ID(N'[Adlumen2SocModelStoreContainer].[View_InformeRendicionGastos1fer]', 'U') IS NOT NULL
    DROP TABLE [Adlumen2SocModelStoreContainer].[View_InformeRendicionGastos1fer];
GO
IF OBJECT_ID(N'[Adlumen2SocModelStoreContainer].[View_InformeTecnicoAvanceHitos]', 'U') IS NOT NULL
    DROP TABLE [Adlumen2SocModelStoreContainer].[View_InformeTecnicoAvanceHitos];
GO
IF OBJECT_ID(N'[Adlumen2SocModelStoreContainer].[View_InfromeDetalleEjecucionGasto]', 'U') IS NOT NULL
    DROP TABLE [Adlumen2SocModelStoreContainer].[View_InfromeDetalleEjecucionGasto];
GO
IF OBJECT_ID(N'[Adlumen2SocModelStoreContainer].[View_ppto_resultado_tipo]', 'U') IS NOT NULL
    DROP TABLE [Adlumen2SocModelStoreContainer].[View_ppto_resultado_tipo];
GO
IF OBJECT_ID(N'[Adlumen2SocModelStoreContainer].[View_saldoppto_resultado_tipo]', 'U') IS NOT NULL
    DROP TABLE [Adlumen2SocModelStoreContainer].[View_saldoppto_resultado_tipo];
GO
IF OBJECT_ID(N'[Adlumen2SocModelStoreContainer].[vw_aspnet_Applications]', 'U') IS NOT NULL
    DROP TABLE [Adlumen2SocModelStoreContainer].[vw_aspnet_Applications];
GO
IF OBJECT_ID(N'[Adlumen2SocModelStoreContainer].[vw_aspnet_MembershipUsers]', 'U') IS NOT NULL
    DROP TABLE [Adlumen2SocModelStoreContainer].[vw_aspnet_MembershipUsers];
GO
IF OBJECT_ID(N'[Adlumen2SocModelStoreContainer].[vw_aspnet_Profiles]', 'U') IS NOT NULL
    DROP TABLE [Adlumen2SocModelStoreContainer].[vw_aspnet_Profiles];
GO
IF OBJECT_ID(N'[Adlumen2SocModelStoreContainer].[vw_aspnet_Roles]', 'U') IS NOT NULL
    DROP TABLE [Adlumen2SocModelStoreContainer].[vw_aspnet_Roles];
GO
IF OBJECT_ID(N'[Adlumen2SocModelStoreContainer].[vw_aspnet_Users]', 'U') IS NOT NULL
    DROP TABLE [Adlumen2SocModelStoreContainer].[vw_aspnet_Users];
GO
IF OBJECT_ID(N'[Adlumen2SocModelStoreContainer].[vw_aspnet_UsersInRoles]', 'U') IS NOT NULL
    DROP TABLE [Adlumen2SocModelStoreContainer].[vw_aspnet_UsersInRoles];
GO
IF OBJECT_ID(N'[Adlumen2SocModelStoreContainer].[vw_aspnet_WebPartState_Paths]', 'U') IS NOT NULL
    DROP TABLE [Adlumen2SocModelStoreContainer].[vw_aspnet_WebPartState_Paths];
GO
IF OBJECT_ID(N'[Adlumen2SocModelStoreContainer].[vw_aspnet_WebPartState_Shared]', 'U') IS NOT NULL
    DROP TABLE [Adlumen2SocModelStoreContainer].[vw_aspnet_WebPartState_Shared];
GO
IF OBJECT_ID(N'[Adlumen2SocModelStoreContainer].[vw_aspnet_WebPartState_User]', 'U') IS NOT NULL
    DROP TABLE [Adlumen2SocModelStoreContainer].[vw_aspnet_WebPartState_User];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Cms_MenuNodos'
CREATE TABLE [dbo].[Cms_MenuNodos] (
    [IdNodo] int IDENTITY(1,1) NOT NULL,
    [IdMenu] int  NOT NULL,
    [IdPadre] int  NOT NULL,
    [Posicion] int  NULL,
    [Destino] nvarchar(50)  NULL,
    [Url] nvarchar(256)  NOT NULL,
    [Nombre] nvarchar(256)  NULL,
    [Descripcion] nvarchar(256)  NULL,
    [IconoUrl] nvarchar(256)  NULL,
    [Estado] bit  NULL,
    [FechaCreacion] datetime  NULL,
    [UsuarioCreacion] nvarchar(256)  NULL,
    [FechaModificacion] datetime  NULL,
    [UsuarioModificacion] nvarchar(256)  NULL,
    [Roles] nvarchar(100)  NULL,
    [RutaXml] varchar(max)  NULL
);
GO

-- Creating table 'Cms_Menus'
CREATE TABLE [dbo].[Cms_Menus] (
    [IdMenu] int IDENTITY(1,1) NOT NULL,
    [Nombre] nvarchar(256)  NOT NULL,
    [Estado] bit  NOT NULL
);
GO

-- Creating table 'Com_Mensajes'
CREATE TABLE [dbo].[Com_Mensajes] (
    [IdMensaje] int IDENTITY(1,1) NOT NULL,
    [IdUsuarioRemitente] int  NOT NULL,
    [IdUsuarioDestinatario] int  NOT NULL,
    [IdEstado] int  NOT NULL,
    [Asunto] varchar(100)  NOT NULL,
    [Mensaje] varchar(max)  NOT NULL,
    [Prioridad] bit  NOT NULL,
    [FechaEnvio] datetime  NOT NULL,
    [FechaLectura] datetime  NULL,
    [FechaBorrado] datetime  NULL
);
GO

-- Creating table 'Com_MensajesEstado'
CREATE TABLE [dbo].[Com_MensajesEstado] (
    [IdEstado] int IDENTITY(1,1) NOT NULL,
    [Nombre] varchar(50)  NOT NULL,
    [Observaciones] varchar(100)  NULL
);
GO

-- Creating table 'Doc_ArchivosTipos'
CREATE TABLE [dbo].[Doc_ArchivosTipos] (
    [IdTipoArchivo] int IDENTITY(1,1) NOT NULL,
    [Nombre] nvarchar(256)  NOT NULL,
    [Mime_Type] nvarchar(50)  NOT NULL
);
GO

-- Creating table 'Doc_Categorias'
CREATE TABLE [dbo].[Doc_Categorias] (
    [IdCategoria] int IDENTITY(1,1) NOT NULL,
    [IdPadre] int  NULL,
    [Nombre] nvarchar(50)  NOT NULL,
    [Descripcion] nvarchar(200)  NULL,
    [Ruta] nvarchar(256)  NULL,
    [UsuarioCreacion] nvarchar(256)  NOT NULL,
    [FechaCreacion] datetime  NOT NULL,
    [UsuarioModificacion] nvarchar(256)  NULL,
    [FechaModificacion] datetime  NULL,
    [Estado] bit  NULL,
    [IdTipo] int  NULL,
    [IdEmpresa] int  NULL
);
GO

-- Creating table 'Doc_Documentos'
CREATE TABLE [dbo].[Doc_Documentos] (
    [IdDocumento] int IDENTITY(1,1) NOT NULL,
    [IdCategoria] int  NOT NULL,
    [IdTipoArchivo] int  NOT NULL,
    [Titulo] nvarchar(100)  NOT NULL,
    [PalabrasClaves] nvarchar(256)  NOT NULL,
    [Resumen] nvarchar(500)  NOT NULL,
    [Url] nvarchar(256)  NOT NULL,
    [UsuarioCreacion] nvarchar(256)  NOT NULL,
    [FechaCreacion] datetime  NOT NULL,
    [UsuarioModificacion] nvarchar(256)  NULL,
    [FechaModificacion] datetime  NULL,
    [Roles] nvarchar(256)  NULL
);
GO

-- Creating table 'M_Encuestas'
CREATE TABLE [dbo].[M_Encuestas] (
    [IdEncuesta] int IDENTITY(1,1) NOT NULL,
    [Descripcion] nvarchar(100)  NULL,
    [FechaCreacion] datetime  NULL
);
GO

-- Creating table 'M_Idiomas'
CREATE TABLE [dbo].[M_Idiomas] (
    [IdIdioma] int IDENTITY(1,1) NOT NULL,
    [Nombre] nvarchar(50)  NOT NULL,
    [Mime] nvarchar(8)  NULL
);
GO

-- Creating table 'M_Monedas'
CREATE TABLE [dbo].[M_Monedas] (
    [IdMoneda] int IDENTITY(1,1) NOT NULL,
    [Nombre] nvarchar(50)  NOT NULL,
    [Representacion] nchar(10)  NULL
);
GO

-- Creating table 'M_Paises'
CREATE TABLE [dbo].[M_Paises] (
    [IdPais] int IDENTITY(1,1) NOT NULL,
    [Nombre] varchar(50)  NOT NULL
);
GO

-- Creating table 'M_Periodos'
CREATE TABLE [dbo].[M_Periodos] (
    [IdPeriodo] int  NOT NULL,
    [Descripcion] nvarchar(50)  NULL,
    [ValorDias] int  NULL
);
GO

-- Creating table 'M_Preguntas'
CREATE TABLE [dbo].[M_Preguntas] (
    [IdPregunta] int IDENTITY(1,1) NOT NULL,
    [IdEncuesta] int  NULL,
    [Pregunta] varchar(max)  NULL
);
GO

-- Creating table 'M_Temas'
CREATE TABLE [dbo].[M_Temas] (
    [IdTema] int IDENTITY(1,1) NOT NULL,
    [Nombre] nvarchar(256)  NOT NULL
);
GO

-- Creating table 'Org_Areas'
CREATE TABLE [dbo].[Org_Areas] (
    [IdArea] int IDENTITY(1,1) NOT NULL,
    [IdPadre] int  NOT NULL,
    [IdEmpresa] int  NOT NULL,
    [IdResponsable] int  NULL,
    [Nombre] nvarchar(256)  NOT NULL,
    [Objetivo] nvarchar(max)  NULL,
    [Descripcion] nvarchar(max)  NULL,
    [UsuarioCreacion] nvarchar(256)  NOT NULL,
    [FechaCreacion] datetime  NOT NULL,
    [UsuarioModificacion] nvarchar(256)  NULL,
    [FechaModificacion] datetime  NULL,
    [Eliminado] bit  NOT NULL
);
GO

-- Creating table 'Org_Cargos'
CREATE TABLE [dbo].[Org_Cargos] (
    [IdCargo] int IDENTITY(1,1) NOT NULL,
    [IdArea] int  NOT NULL,
    [Nombre] nvarchar(256)  NOT NULL,
    [IdPadre] int  NULL,
    [Descripcion] nvarchar(max)  NULL,
    [Perfil] nvarchar(max)  NULL,
    [UsuarioCreacion] nvarchar(256)  NOT NULL,
    [FechaCreacion] datetime  NOT NULL,
    [UsuarioModificacion] nvarchar(256)  NULL,
    [FechaModificacion] datetime  NULL,
    [Eliminado] bit  NOT NULL
);
GO

-- Creating table 'Org_Donantes'
CREATE TABLE [dbo].[Org_Donantes] (
    [IdDonante] int IDENTITY(1,1) NOT NULL,
    [Nombre] nvarchar(256)  NOT NULL,
    [IdIdentificacionTipo] int  NOT NULL,
    [Identificacion] varchar(50)  NOT NULL,
    [Contacto] nvarchar(256)  NULL,
    [Telefono] varchar(20)  NULL,
    [Ubicacion] varchar(100)  NULL,
    [Correo] nvarchar(256)  NULL,
    [URL] nvarchar(256)  NULL,
    [HojaVida] nvarchar(256)  NULL,
    [FechaCreacion] datetime  NOT NULL,
    [UsuarioCreacion] nvarchar(256)  NOT NULL,
    [FechaModificacion] datetime  NULL,
    [UsuarioModificacion] nvarchar(256)  NULL,
    [Eliminado] bit  NOT NULL,
    [IdCliente] int  NULL,
    [IdPrograma] int  NULL
);
GO

-- Creating table 'Org_Empleados'
CREATE TABLE [dbo].[Org_Empleados] (
    [IdEmpleado] int IDENTITY(1,1) NOT NULL,
    [IdCargo] int  NULL,
    [Nombre] nvarchar(256)  NOT NULL,
    [Apellido] nvarchar(256)  NULL,
    [IdIdentificacionTipo] int  NOT NULL,
    [Identificacion] varchar(50)  NOT NULL,
    [Foto] nvarchar(256)  NULL,
    [Correo] varchar(50)  NULL,
    [Observaciones] nvarchar(max)  NULL,
    [Competencias] nvarchar(max)  NULL,
    [HojaVida] nvarchar(256)  NULL,
    [UsuarioCreacion] nvarchar(256)  NOT NULL,
    [FechaCreacion] datetime  NOT NULL,
    [UsuarioModificacion] nvarchar(256)  NULL,
    [FechaModificacion] datetime  NULL,
    [Retirado] bit  NOT NULL,
    [IdUsuario] int  NULL
);
GO

-- Creating table 'Org_EmpleadosCargosHistorico'
CREATE TABLE [dbo].[Org_EmpleadosCargosHistorico] (
    [IdEmpleadoCargo] int IDENTITY(1,1) NOT NULL,
    [IdEmpleado] int  NOT NULL,
    [IdCargo] int  NOT NULL,
    [FechaInicioCargo] datetime  NOT NULL,
    [FechaFinCargo] datetime  NULL,
    [UsuarioCreacion] nvarchar(256)  NOT NULL,
    [FechaCreacion] datetime  NOT NULL,
    [UsuarioModificacion] nvarchar(256)  NULL,
    [FechaModificacion] datetime  NULL
);
GO

-- Creating table 'Org_Empresas'
CREATE TABLE [dbo].[Org_Empresas] (
    [IdEmpresa] int IDENTITY(1,1) NOT NULL,
    [Nombre] nvarchar(256)  NOT NULL,
    [Ubicacion] nvarchar(256)  NULL,
    [URL] nvarchar(256)  NULL,
    [Telefono] nvarchar(50)  NULL,
    [Logo] nvarchar(256)  NULL,
    [IdIdentificacionTipo] int  NOT NULL,
    [Identificacion] nvarchar(50)  NOT NULL,
    [IdPais] int  NOT NULL,
    [IdMenuAdministracion] int  NULL,
    [IdMenuSuperior] int  NULL,
    [IdMenuIzquierdo] int  NULL,
    [IdMenuPanel] int  NULL,
    [FechaCreacion] datetime  NOT NULL,
    [UsuarioCreacion] nvarchar(256)  NOT NULL,
    [FechaModificacion] datetime  NULL,
    [UsuarioModificacion] nvarchar(256)  NULL,
    [Eliminado] bit  NOT NULL,
    [IdMenuSLDerecho] int  NULL,
    [IdMenuReportes] int  NULL,
    [Latitude] float  NULL,
    [Longitude] float  NULL,
    [IdCliente] int  NULL,
    [IdCategoriaDocumentos] int  NULL
);
GO

-- Creating table 'Org_IdentificacionTipos'
CREATE TABLE [dbo].[Org_IdentificacionTipos] (
    [IdIdentificacionTipo] int IDENTITY(1,1) NOT NULL,
    [Nombre] nvarchar(256)  NOT NULL
);
GO

-- Creating table 'Org_Proveedores'
CREATE TABLE [dbo].[Org_Proveedores] (
    [IdProveedor] int IDENTITY(1,1) NOT NULL,
    [IdEmpresa] int  NOT NULL,
    [Nombre] nvarchar(256)  NOT NULL,
    [IdIdentificacionTipo] int  NOT NULL,
    [Identificacion] varchar(50)  NOT NULL,
    [Telefono] varchar(20)  NULL,
    [Correo] nvarchar(256)  NULL,
    [Ubicacion] varchar(100)  NULL,
    [HojaVida] nvarchar(256)  NULL,
    [FechaCreacion] datetime  NOT NULL,
    [UsuarioCreacion] nvarchar(256)  NOT NULL,
    [FechaModificacion] datetime  NULL,
    [UsuarioModificacion] nvarchar(256)  NULL,
    [Eliminado] bit  NOT NULL
);
GO

-- Creating table 'Pry_Bitacoras'
CREATE TABLE [dbo].[Pry_Bitacoras] (
    [IdBitacora] int IDENTITY(1,1) NOT NULL,
    [IdProyecto] int  NULL,
    [Titulo] nvarchar(250)  NULL,
    [Text] nvarchar(max)  NULL,
    [Url] nvarchar(250)  NULL,
    [UsuarioCreacion] nvarchar(256)  NOT NULL,
    [FechaCreacion] datetime  NOT NULL,
    [UsuarioModificacion] nvarchar(256)  NULL,
    [FechaModificacion] datetime  NULL
);
GO

-- Creating table 'Pry_CalendarioDonaciones'
CREATE TABLE [dbo].[Pry_CalendarioDonaciones] (
    [IdDonacion] int IDENTITY(1,1) NOT NULL,
    [IdProyecto] int  NOT NULL,
    [IdDonante] int  NOT NULL,
    [Monto] float  NOT NULL,
    [FechaProgramada] datetime  NOT NULL
);
GO

-- Creating table 'Pry_DatosMuestras'
CREATE TABLE [dbo].[Pry_DatosMuestras] (
    [IdDatosMuestra] int IDENTITY(1,1) NOT NULL,
    [IdIndicador] int  NULL,
    [Fecha] datetime  NULL,
    [Logro] float  NULL,
    [Observaciones] nvarchar(500)  NULL,
    [Efectividad] float  NULL,
    [IdNivelAceptacionEfectividad] int  NULL,
    [Eficacia] float  NULL,
    [IdNivelAceptacionEficacia] int  NULL,
    [IdPeriodo] bigint  NULL,
    [USUARIOCREACION] nvarchar(256)  NULL,
    [FECHACREACION] datetime  NULL,
    [USUARIOMODIFICACION] nvarchar(256)  NULL,
    [FECHAMODIFICACION] datetime  NULL
);
GO

-- Creating table 'Pry_DatosVariables'
CREATE TABLE [dbo].[Pry_DatosVariables] (
    [IdDatosMuestra] int  NOT NULL,
    [IdVariable] int  NOT NULL,
    [Valor] float  NULL
);
GO

-- Creating table 'Pry_DatosVerificadores'
CREATE TABLE [dbo].[Pry_DatosVerificadores] (
    [IdDatosFuentes] int IDENTITY(1,1) NOT NULL,
    [IdDatosMuestra] int  NULL,
    [IdVerificador] int  NULL,
    [Url] nvarchar(250)  NULL
);
GO

-- Creating table 'PRY_EVALUACIONESACTIVIDADESPERIODO'
CREATE TABLE [dbo].[PRY_EVALUACIONESACTIVIDADESPERIODO] (
    [IDOBJETIVO] int  NOT NULL,
    [IDPERIODO] bigint  NOT NULL,
    [IDPROYECTO] int  NOT NULL,
    [OBSERVACIONES] nvarchar(2000)  NULL
);
GO

-- Creating table 'Pry_EvaluacionHitos'
CREATE TABLE [dbo].[Pry_EvaluacionHitos] (
    [IdProyecto] int  NOT NULL,
    [IdPeriodo] bigint  NOT NULL,
    [IdResultado] int  NOT NULL,
    [IdActividad] int  NOT NULL,
    [IdHito] int  NOT NULL,
    [HitoEfectividad] decimal(5,2)  NULL,
    [ObservacionED] nvarchar(2000)  NULL,
    [ADH] decimal(5,2)  NULL,
    [CV] decimal(4,2)  NULL,
    [ObservacionUrip] nvarchar(2000)  NULL
);
GO

-- Creating table 'PRY_EVALUACIONINDICADORESPERIODO'
CREATE TABLE [dbo].[PRY_EVALUACIONINDICADORESPERIODO] (
    [IdProyecto] int  NOT NULL,
    [IdPeriodo] bigint  NOT NULL,
    [IdResultado] int  NOT NULL,
    [IdHito] int  NOT NULL,
    [HitoEfectividad] decimal(5,2)  NULL,
    [ObservacionED] nvarchar(2000)  NULL,
    [ADH] decimal(5,2)  NULL,
    [CV] decimal(4,2)  NULL,
    [ObservacionUrip] nvarchar(2000)  NULL
);
GO

-- Creating table 'PRY_EVALUACIONPROYECTOPERIODO'
CREATE TABLE [dbo].[PRY_EVALUACIONPROYECTOPERIODO] (
    [IDPERIODO] bigint  NOT NULL,
    [IDPROYECTO] int  NOT NULL,
    [DATOSFINANCIEROS] nvarchar(2000)  NULL,
    [OBSERVACIONES] nvarchar(2000)  NULL,
    [RECOMENDACIONES] nvarchar(2000)  NULL
);
GO

-- Creating table 'Pry_Indicadores'
CREATE TABLE [dbo].[Pry_Indicadores] (
    [IdIndicador] int IDENTITY(1,1) NOT NULL,
    [IdObjetivo] int  NULL,
    [Codigo] nvarchar(50)  NULL,
    [IdTipo] int  NOT NULL,
    [IdSubTipo] int  NOT NULL,
    [Descripcion] nvarchar(2000)  NOT NULL,
    [Definicion] nvarchar(500)  NULL,
    [Objetivo] nvarchar(500)  NULL,
    [Cualidades] nvarchar(500)  NULL,
    [UnidadMedida] nvarchar(250)  NULL,
    [Cobertura] nvarchar(250)  NULL,
    [IdResponsableIndicador] int  NULL,
    [UnidadOperativa] nvarchar(500)  NULL,
    [UnidadOperativaId] nvarchar(500)  NULL,
    [FechaInicio] datetime  NULL,
    [FechaFin] datetime  NULL,
    [Base] float  NOT NULL,
    [Meta] float  NOT NULL,
    [Porcentual] bit  NOT NULL,
    [Ponderado] float  NULL,
    [IdDatosMuestra] int  NULL,
    [EfectividadNotificada] bit  NOT NULL,
    [PalabrasClave] nvarchar(max)  NULL,
    [IdPeriodo] bigint  NULL
);
GO

-- Creating table 'Pry_IndicadoresProyecto_Programa'
CREATE TABLE [dbo].[Pry_IndicadoresProyecto_Programa] (
    [IdIndicadorProyecto] int  NOT NULL,
    [IdIndicadorPrograma] int  NOT NULL
);
GO

-- Creating table 'Pry_IndicadoresTipos'
CREATE TABLE [dbo].[Pry_IndicadoresTipos] (
    [IdTipo] int  NOT NULL,
    [Descripcion] nvarchar(500)  NOT NULL,
    [IdPadre] int  NULL,
    [Myme] nvarchar(2)  NULL
);
GO

-- Creating table 'Pry_IndicadoresVerificadores'
CREATE TABLE [dbo].[Pry_IndicadoresVerificadores] (
    [IdVerificador] int IDENTITY(1,1) NOT NULL,
    [IdIndicador] int  NOT NULL,
    [Descripcion] nvarchar(500)  NOT NULL
);
GO

-- Creating table 'Pry_Informes'
CREATE TABLE [dbo].[Pry_Informes] (
    [IdInforme] int IDENTITY(1,1) NOT NULL,
    [IdProyecto] int  NULL,
    [Descripcion] nvarchar(500)  NULL,
    [FechaProgramada] datetime  NULL,
    [FechaInforme] datetime  NULL,
    [PresupuestoMeta] float  NULL,
    [PresupuestoEjecutado] float  NULL,
    [AvanceMeta] float  NULL,
    [AvanceEjecutado] float  NULL,
    [DescripcionSupuestos] nvarchar(max)  NULL,
    [Informe] nvarchar(max)  NULL,
    [EvaluacionComponentes] int  NULL,
    [EvaluacionComponentesDes] nvarchar(max)  NULL,
    [EvaluacionProposito] int  NULL,
    [EvaluacionPropositoDes] nvarchar(max)  NULL,
    [Lecciones] nvarchar(max)  NULL,
    [Acciones] nvarchar(max)  NULL,
    [IdEstado] int  NULL,
    [IdEstadoNotificado] bit  NULL
);
GO

-- Creating table 'Pry_Informes_Donantes'
CREATE TABLE [dbo].[Pry_Informes_Donantes] (
    [IdInforme] int  NOT NULL,
    [IdDonante] int  NOT NULL,
    [Donacion] float  NULL,
    [FechaPrimeraDonacion] datetime  NULL,
    [FechaUltimaDonacion] datetime  NULL
);
GO

-- Creating table 'Pry_Informes_Encuestas'
CREATE TABLE [dbo].[Pry_Informes_Encuestas] (
    [IdInforme] int  NOT NULL,
    [IdPregunta] int  NOT NULL,
    [Respuesta] bit  NULL,
    [Descripcion] nvarchar(250)  NULL
);
GO

-- Creating table 'Pry_Informes_Indicador'
CREATE TABLE [dbo].[Pry_Informes_Indicador] (
    [IdInforme] int  NOT NULL,
    [IdIndicador] int  NOT NULL,
    [Meta] float  NULL,
    [IdDatosMuestra] int  NULL,
    [Evaluacion] int  NULL
);
GO

-- Creating table 'Pry_Informes_Presupuestos'
CREATE TABLE [dbo].[Pry_Informes_Presupuestos] (
    [IdInforme] int  NOT NULL,
    [IdPresupuesto] int  NOT NULL,
    [Ejecutado] float  NULL,
    [Utilizacion] float  NULL,
    [Evaluacion] int  NULL
);
GO

-- Creating table 'Pry_Informes_Supuestos'
CREATE TABLE [dbo].[Pry_Informes_Supuestos] (
    [IdInforme] int  NOT NULL,
    [IdSupuesto] int  NOT NULL,
    [Valor] bit  NOT NULL,
    [Tipo] nvarchar(15)  NULL
);
GO

-- Creating table 'Pry_InformesEstados'
CREATE TABLE [dbo].[Pry_InformesEstados] (
    [IdEstado] int IDENTITY(1,1) NOT NULL,
    [Descripcion] nvarchar(250)  NOT NULL
);
GO

-- Creating table 'PRY_INFORMESICA'
CREATE TABLE [dbo].[PRY_INFORMESICA] (
    [IDINFORME] int IDENTITY(1,1) NOT NULL,
    [IDPROYECTO] int  NOT NULL,
    [IDTIPO] int  NOT NULL,
    [FECHA] datetime  NOT NULL,
    [IDESTADO] int  NOT NULL,
    [PERIODOINICIAL] bigint  NOT NULL,
    [PERIODOFINAL] bigint  NOT NULL
);
GO

-- Creating table 'PRY_INFORMESICADETALLE'
CREATE TABLE [dbo].[PRY_INFORMESICADETALLE] (
    [IDDETALLE] int IDENTITY(1,1) NOT NULL,
    [IDINFORME] int  NOT NULL,
    [DATOSFINANCIEROS] nvarchar(4000)  NULL,
    [OBSERVACIONES] nvarchar(4000)  NULL,
    [LOGROSPRINCIPALES] nvarchar(4000)  NULL,
    [PROBLEMASYACCIONES] nvarchar(4000)  NULL,
    [SUPUESTOS] nvarchar(4000)  NULL,
    [RECOMENDACIONES] nvarchar(4000)  NULL,
    [FACTORESEXITO] nvarchar(4000)  NULL,
    [FACTORESLIMITANTES] nvarchar(4000)  NULL,
    [CONDICIONALIDAD] nvarchar(4000)  NULL,
    [SOSTENIBILIDAD] nvarchar(4000)  NULL,
    [EFICACIAPROYECTO] nvarchar(4000)  NULL,
    [EFICACIARESULTADOS] nvarchar(4000)  NULL,
    [RELEVANCIAOBJETIVOS] nvarchar(4000)  NULL,
    [RELEVANCIAEXTERNA] nvarchar(4000)  NULL,
    [SOSTENIBILIDADBENEFICIOS] nvarchar(4000)  NULL,
    [SOSTENIBILIDADCAPACIDADES] nvarchar(4000)  NULL,
    [SOSTENIBILIDADPERTENECIA] nvarchar(4000)  NULL,
    [SOSTENIBILIDADOREPLICAS] nvarchar(4000)  NULL,
    [IMPACTOOBJETIVOS] nvarchar(4000)  NULL,
    [IMPACTOGENERAL] nvarchar(4000)  NULL,
    [IMPACTOALIANZAS] nvarchar(4000)  NULL,
    [IMPACTODIALOGO] nvarchar(4000)  NULL
);
GO

-- Creating table 'PRY_INFORMESICADOCUMENTOS'
CREATE TABLE [dbo].[PRY_INFORMESICADOCUMENTOS] (
    [IDDOCUMENTO] uniqueidentifier  NOT NULL,
    [IDINFORME] int  NOT NULL,
    [DESCRIPCION] nvarchar(250)  NULL,
    [URL] nvarchar(500)  NOT NULL,
    [NOMBRE] nvarchar(250)  NOT NULL,
    [TIPO] int  NOT NULL
);
GO

-- Creating table 'PRY_INFORMESICAESTADOS'
CREATE TABLE [dbo].[PRY_INFORMESICAESTADOS] (
    [IDESTADO] int IDENTITY(1,1) NOT NULL,
    [DESCRIPCION] nvarchar(50)  NULL
);
GO

-- Creating table 'PRY_INFORMESICAINDICADORES'
CREATE TABLE [dbo].[PRY_INFORMESICAINDICADORES] (
    [IDINFORME] int  NOT NULL,
    [IDINDICADOR] int  NOT NULL,
    [LOGROS] nvarchar(4000)  NULL
);
GO

-- Creating table 'PRY_INFORMESICAOBJETIVOS'
CREATE TABLE [dbo].[PRY_INFORMESICAOBJETIVOS] (
    [IDINFORME] int  NOT NULL,
    [IDOBJETIVO] int  NOT NULL,
    [LOGROS] nvarchar(4000)  NULL
);
GO

-- Creating table 'PRY_INFORMESICATIPOS'
CREATE TABLE [dbo].[PRY_INFORMESICATIPOS] (
    [IDTIPO] int IDENTITY(1,1) NOT NULL,
    [DESCRIPCION] nvarchar(50)  NULL
);
GO

-- Creating table 'Pry_Movimientos'
CREATE TABLE [dbo].[Pry_Movimientos] (
    [IdMovimiento] int IDENTITY(1,1) NOT NULL,
    [IdPresupuesto] int  NULL,
    [IdProveedor] int  NULL,
    [Monto] float  NULL,
    [Fecha] datetime  NULL,
    [Observaciones] nvarchar(500)  NULL,
    [UrlSoporte] nvarchar(250)  NULL,
    [IdPeriodo] bigint  NULL,
    [BENEFICIARIO] nvarchar(150)  NULL,
    [MEDIOPAGO] nvarchar(50)  NULL,
    [CONTRAPARTIDA] decimal(18,2)  NULL,
    [APORTEPROGRAMA] decimal(18,2)  NULL,
    [IDPARTIDAGASTO] int  NULL,
    [USUARIOCREACION] nvarchar(256)  NULL,
    [FECHACREACION] datetime  NULL,
    [USUARIOMODIFICACION] nvarchar(256)  NULL,
    [FECHAMODIFICACION] datetime  NULL,
    [MONEDALOCAL] int  NULL,
    [APORTEMONEDALOCAL] decimal(18,2)  NULL
);
GO

-- Creating table 'Pry_NivelAceptacion'
CREATE TABLE [dbo].[Pry_NivelAceptacion] (
    [IdNivelAceptacion] int IDENTITY(1,1) NOT NULL,
    [Nombre] nvarchar(10)  NOT NULL,
    [Descripcion] nvarchar(100)  NULL,
    [Color] nvarchar(15)  NULL
);
GO

-- Creating table 'Pry_Objetivos'
CREATE TABLE [dbo].[Pry_Objetivos] (
    [IdObjetivo] int IDENTITY(1,1) NOT NULL,
    [IdPadre] int  NULL,
    [IdObjetivoClase] int  NULL,
    [Codigo] nvarchar(50)  NULL,
    [Descripcion] nvarchar(2000)  NULL,
    [Eliminado] bit  NULL,
    [IdEmpresa] int  NULL,
    [IdResponsable] int  NULL,
    [FechaInicio] datetime  NULL,
    [FechaFin] datetime  NULL,
    [Ponderado] float  NULL,
    [Progreso] float  NULL,
    [IdNivelAceptacion] int  NULL,
    [Efectividad] float  NULL,
    [Eficacia] float  NULL,
    [Eficiencia] float  NULL,
    [Costo] float  NULL,
    [IdNivelAceptacionEfectividad] int  NULL,
    [IdNivelAceptacionEficacia] int  NULL,
    [IdNivelAceptacionEficiencia] int  NULL,
    [IdNivelAceptacionCosto] int  NULL,
    [CostoNotificado] bit  NOT NULL,
    [EfectividadNotificada] bit  NOT NULL,
    [CustomerId] int  NULL
);
GO

-- Creating table 'Pry_ObjetivosClase'
CREATE TABLE [dbo].[Pry_ObjetivosClase] (
    [IdObjetivoClase] int IDENTITY(1,1) NOT NULL,
    [Descripcion] nvarchar(50)  NULL
);
GO

-- Creating table 'PRY_PARTIDAGASTOS'
CREATE TABLE [dbo].[PRY_PARTIDAGASTOS] (
    [IDPARTIDAGASTO] int IDENTITY(1,1) NOT NULL,
    [ABREVIATURA] nvarchar(50)  NOT NULL,
    [CODIGO] nvarchar(50)  NOT NULL,
    [NOMBRE] nvarchar(50)  NOT NULL
);
GO

-- Creating table 'Pry_Presupuesto'
CREATE TABLE [dbo].[Pry_Presupuesto] (
    [IdPresupuesto] int IDENTITY(1,1) NOT NULL,
    [IdTipoPresupuesto] int  NULL,
    [IdObjetivo] int  NULL,
    [IdProyecto] int  NULL,
    [Monto] float  NULL,
    [IdDonante] int  NULL,
    [UsuarioCreacion] nvarchar(256)  NOT NULL,
    [FechaCreacion] datetime  NOT NULL,
    [UsuarioModificacion] nvarchar(256)  NULL,
    [FechaModificacion] datetime  NULL
);
GO

-- Creating table 'Pry_PresupuestoTipo'
CREATE TABLE [dbo].[Pry_PresupuestoTipo] (
    [IdTipo] int IDENTITY(1,1) NOT NULL,
    [Descripcion] nvarchar(50)  NULL
);
GO

-- Creating table 'Pry_Proyectos'
CREATE TABLE [dbo].[Pry_Proyectos] (
    [IdProyecto] int IDENTITY(1,1) NOT NULL,
    [IdUsuarioResponsable] int  NULL,
    [IdUsuarioDigitador] int  NULL,
    [IdUsuarioEvaluador] int  NULL,
    [Codigo] nvarchar(50)  NULL,
    [Nombre] nvarchar(500)  NULL,
    [Descripcion] nvarchar(2000)  NULL,
    [Problema] varchar(max)  NULL,
    [DescripcionProblema] varchar(max)  NULL,
    [Justificacion] varchar(max)  NULL,
    [IdCategoriaDocumentos] int  NULL,
    [IdCategoriaSupuestos] int  NULL,
    [Beneficiarios] nvarchar(256)  NULL,
    [Region] nvarchar(256)  NULL,
    [DiasNotificacion] int  NOT NULL,
    [IdMoneda] int  NULL,
    [Eliminado] bit  NOT NULL,
    [IdProposito] int  NULL,
    [Area] nvarchar(256)  NULL,
    [FechaInicio] datetime  NULL,
    [FechaFin] datetime  NULL,
    [Presupuesto] float  NULL,
    [Logo] nvarchar(250)  NULL,
    [IdEstado] int  NULL,
    [Latitude] float  NULL,
    [Longitude] float  NULL,
    [CustomerId] int  NOT NULL,
    [IdEmpresa] int  NULL,
    [IdTipo] int  NOT NULL,
    [IDPROYECTOPADRE] int  NULL,
    [MONTOFINANCIAMIENTO] float  NULL,
    [MONTOCONTRAPARTIDA] float  NULL
);
GO

-- Creating table 'Pry_Proyectos_Donantes'
CREATE TABLE [dbo].[Pry_Proyectos_Donantes] (
    [IdProyecto] int  NOT NULL,
    [IdDonante] int  NOT NULL,
    [IdUsuarioResponsable] int  NULL,
    [Monto] float  NULL,
    [UsuarioCreacion] nvarchar(256)  NOT NULL,
    [FechaCreacion] datetime  NOT NULL,
    [UsuarioModificacion] nvarchar(256)  NULL,
    [FechaModificacion] datetime  NULL
);
GO

-- Creating table 'Pry_Proyectos_NivelAceptacion'
CREATE TABLE [dbo].[Pry_Proyectos_NivelAceptacion] (
    [IdProyecto] int  NOT NULL,
    [IdNivelAceptacion] int  NOT NULL,
    [Valor] float  NOT NULL
);
GO

-- Creating table 'Pry_ProyectosEstados'
CREATE TABLE [dbo].[Pry_ProyectosEstados] (
    [IdEstado] int IDENTITY(1,1) NOT NULL,
    [Descripcion] nvarchar(50)  NULL
);
GO

-- Creating table 'Pry_ProyectosTipos'
CREATE TABLE [dbo].[Pry_ProyectosTipos] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Descripcion] nvarchar(50)  NULL
);
GO

-- Creating table 'Pry_Recursos'
CREATE TABLE [dbo].[Pry_Recursos] (
    [IdRecurso] int IDENTITY(1,1) NOT NULL,
    [IdObjetivo] int  NOT NULL,
    [Codigo] nvarchar(50)  NULL,
    [Descripcion] nvarchar(500)  NOT NULL,
    [Tipo] nvarchar(100)  NULL,
    [Cantidad] float  NULL,
    [UnidadMedida] nvarchar(50)  NULL,
    [ValorUnitario] float  NULL,
    [Monto] float  NULL,
    [IDPARTIDAGASTO] int  NULL,
    [CONTRAPARTIDA] decimal(18,2)  NULL,
    [APORTEPROGRAMA] decimal(18,2)  NULL
);
GO

-- Creating table 'Pry_Supuestos'
CREATE TABLE [dbo].[Pry_Supuestos] (
    [IdSupuesto] int IDENTITY(1,1) NOT NULL,
    [IdObjetivo] int  NULL,
    [Descripcion] nvarchar(2000)  NOT NULL,
    [Impacto] bit  NULL,
    [PlanContingencia] nvarchar(250)  NULL
);
GO

-- Creating table 'Pry_Variables'
CREATE TABLE [dbo].[Pry_Variables] (
    [IdVariable] int IDENTITY(1,1) NOT NULL,
    [Nombre] nvarchar(50)  NULL,
    [FuenteInformacion] nvarchar(250)  NULL
);
GO

-- Creating table 'Sys_Clientes'
CREATE TABLE [dbo].[Sys_Clientes] (
    [Id] int  NOT NULL,
    [Name] nvarchar(250)  NULL
);
GO

-- Creating table 'Sys_Usuarios'
CREATE TABLE [dbo].[Sys_Usuarios] (
    [IdUsuario] int IDENTITY(1,1) NOT NULL,
    [UserName] nvarchar(256)  NOT NULL,
    [Nombre] nvarchar(250)  NULL,
    [Correo] nvarchar(250)  NULL,
    [CustomerId] int  NULL
);
GO

-- Creating table 'sysdiagrams'
CREATE TABLE [dbo].[sysdiagrams] (
    [name] nvarchar(128)  NOT NULL,
    [principal_id] int  NOT NULL,
    [diagram_id] int IDENTITY(1,1) NOT NULL,
    [version] int  NULL,
    [definition] varbinary(max)  NULL
);
GO

-- Creating table 'Tar_Listas'
CREATE TABLE [dbo].[Tar_Listas] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [IdProyecto] int  NULL,
    [Descripcion] nvarchar(2000)  NOT NULL,
    [IdUsuarioCreacion] int  NOT NULL,
    [FechaCreacion] datetime  NOT NULL,
    [IdUsuarioModificacion] int  NULL,
    [FechaModificacion] datetime  NULL,
    [IdPadre] int  NULL
);
GO

-- Creating table 'Tar_Tareas'
CREATE TABLE [dbo].[Tar_Tareas] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [IdLista] int  NULL,
    [Descripcion] nvarchar(2000)  NULL,
    [FechaInicio] datetime  NULL,
    [FechaFin] datetime  NULL,
    [IdResponsable] int  NULL,
    [IdUsuarioCreacion] int  NULL,
    [FechaCreacion] datetime  NULL,
    [IdUsuarioModificacion] int  NULL,
    [FechaModificacion] datetime  NULL,
    [Prioridad] bit  NULL,
    [Estado] bit  NULL,
    [FechaCompletado] datetime  NULL,
    [IdUsuarioCompletado] int  NULL
);
GO

-- Creating table 'View_ejecutado_resultado_tipo'
CREATE TABLE [dbo].[View_ejecutado_resultado_tipo] (
    [IdProyecto] int  NULL,
    [idobjetivo] int  NULL,
    [Codigo] nvarchar(50)  NULL,
    [Descripcion] nvarchar(2000)  NULL,
    [tipopresupuesto] int  NOT NULL,
    [ejecutado] decimal(38,2)  NULL,
    [anio] int  NULL
);
GO

-- Creating table 'View_Informe_de_Saldos'
CREATE TABLE [dbo].[View_Informe_de_Saldos] (
    [id] bigint  NULL,
    [Proyecto] nvarchar(500)  NULL,
    [IdProyecto] int  NOT NULL,
    [Ejecutor] nvarchar(256)  NOT NULL,
    [Pais] varchar(50)  NOT NULL,
    [Fecha_de_Vencimiento] datetime  NULL,
    [Fecha_de_Inicio] datetime  NULL,
    [ObjetivoProposito] int  NOT NULL,
    [Presupuesto_Proposito] float  NULL,
    [Proposito] nvarchar(2000)  NULL,
    [Presupuesto_de_Resultado] float  NULL,
    [Tipo_Presupuesto_Resultado] int  NULL,
    [ObjetivoResultado] int  NOT NULL,
    [Resultado] nvarchar(2000)  NULL,
    [ObjetivoActividad] int  NOT NULL,
    [Actividad] nvarchar(50)  NULL,
    [Descripcion_de_Actividad] nvarchar(2000)  NULL,
    [IdPresupuestoActividad] int  NOT NULL,
    [Tipo_de_Presupuesto_Actividad] int  NULL,
    [Presupuesto_de_Actividad] float  NULL,
    [Monto_Movimiento] float  NULL,
    [Fecha_Gasto] datetime  NOT NULL,
    [Año] int  NULL,
    [Descripcion_Monto] nvarchar(500)  NULL,
    [IdMovimiento] int  NOT NULL
);
GO

-- Creating table 'View_Informe_ITFSemestral'
CREATE TABLE [dbo].[View_Informe_ITFSemestral] (
    [id] bigint  NULL,
    [Proyecto] nvarchar(500)  NULL,
    [IdProyecto] int  NOT NULL,
    [Codigo] nvarchar(50)  NULL,
    [Pais] varchar(50)  NOT NULL,
    [Ejecutor] nvarchar(256)  NOT NULL,
    [Periodo] nvarchar(50)  NOT NULL,
    [IdPeriodo] bigint  NOT NULL,
    [LogrosPrincipales] nvarchar(4000)  NULL,
    [Observaciones] nvarchar(4000)  NULL,
    [Factores_Exito] nvarchar(4000)  NULL,
    [Factores_Limitantes] nvarchar(4000)  NULL,
    [Condiicionalidad] nvarchar(4000)  NULL,
    [Sostenibilidad] nvarchar(4000)  NULL,
    [Problemas_y_Acciones] nvarchar(4000)  NULL,
    [Sostenibilidad_Replicas] nvarchar(4000)  NULL,
    [ObjetivoProposito] int  NULL,
    [Proposito] nvarchar(2000)  NULL,
    [Logros_Comentarios_Proproposito] nvarchar(4000)  NULL,
    [CantidadPro] float  NOT NULL,
    [CantidadResul] float  NOT NULL,
    [Indicadores_Proposito] nvarchar(2000)  NOT NULL,
    [IdIndicadorproposito] int  NOT NULL,
    [Explicacion_Logros_Proposito] nvarchar(4000)  NULL,
    [ObjetivoResultado] int  NOT NULL,
    [Resultado] nvarchar(2000)  NULL,
    [Logros_Comentarios_Resultado] nvarchar(4000)  NULL,
    [Recomendaciones] nvarchar(4000)  NULL,
    [Replicas] nvarchar(4000)  NULL,
    [Avance_Principal] nvarchar(4000)  NULL,
    [Cambios_Internos] nvarchar(4000)  NULL,
    [Tipo_Informe] int  NOT NULL,
    [Objetivo_General] nvarchar(2000)  NULL,
    [Fecha_Fin] datetime  NULL,
    [Fecha_Inicio] datetime  NULL,
    [Indicadores_Resultado] nvarchar(2000)  NOT NULL,
    [Explicacion_logros_Resultado] nvarchar(4000)  NULL,
    [Idindicadorresultado] int  NOT NULL,
    [Base_Proposito] float  NOT NULL,
    [Base_Resultado] float  NOT NULL
);
GO

-- Creating table 'View_Informe_Saldos_FER'
CREATE TABLE [dbo].[View_Informe_Saldos_FER] (
    [IdProyecto] int  NULL,
    [CodigoPRY] nvarchar(50)  NULL,
    [NombrePRY] nvarchar(500)  NULL,
    [FechaInicio] datetime  NULL,
    [FechaFin] datetime  NULL,
    [idobjetivo] int  NULL,
    [codigo] nvarchar(50)  NULL,
    [descripcion] nvarchar(2000)  NULL,
    [tipopresupuesto] int  NOT NULL,
    [anio] int  NULL,
    [presupuesto] decimal(38,2)  NULL,
    [ejecutado] decimal(38,2)  NULL,
    [NombreEMP] nvarchar(256)  NULL,
    [pais] varchar(50)  NULL,
    [moneda] nvarchar(50)  NULL,
    [simbolomnd] nchar(10)  NULL
);
GO

-- Creating table 'View_InformeAdministrativoITFUNIP'
CREATE TABLE [dbo].[View_InformeAdministrativoITFUNIP] (
    [Programa] nvarchar(500)  NULL,
    [IdProyecto] int  NOT NULL,
    [Proyecto] nvarchar(500)  NULL,
    [Codigo] nvarchar(50)  NULL,
    [Fecha_de_Inicio] datetime  NULL,
    [Fecha_de_Vencimiento] datetime  NULL,
    [Pais] varchar(50)  NOT NULL,
    [Entidad_Desarrolladora] nvarchar(256)  NOT NULL,
    [IdPeriodo] bigint  NOT NULL,
    [Periodo] nvarchar(50)  NOT NULL,
    [ObjetivoActividad] int  NULL,
    [Actividad] nvarchar(50)  NULL,
    [Descripcion_de_Actividad] nvarchar(2000)  NULL,
    [Observacion_de_la_Actividad] nvarchar(2000)  NULL,
    [Recomendaciones] nvarchar(2000)  NULL,
    [Observaciones_Generales] nvarchar(2000)  NULL,
    [Datos_Financieros] nvarchar(2000)  NULL
);
GO

-- Creating table 'View_InformeAvanceHitos'
CREATE TABLE [dbo].[View_InformeAvanceHitos] (
    [id] bigint  NULL,
    [Proyecto] nvarchar(500)  NULL,
    [IdProyecto] int  NOT NULL,
    [Fecha_de_Inicio] datetime  NULL,
    [Fecha_de_Vencimiento] datetime  NULL,
    [Periodo] nvarchar(50)  NOT NULL,
    [IdProposito] int  NULL,
    [Proposito] nvarchar(2000)  NULL,
    [IdobjetivoResultado] int  NOT NULL,
    [Entregable] nvarchar(2000)  NULL,
    [IdClaseResultdo] int  NULL,
    [IdobjetivoAvtividad] int  NOT NULL,
    [Actividad] nvarchar(50)  NULL,
    [Descripcion_Actividad] nvarchar(2000)  NULL,
    [Fecha_de_Inicio_Actividad] datetime  NULL,
    [IdClaseActividad] int  NULL,
    [Fecha_de_Inicio_Resultado] datetime  NULL,
    [Hito] nvarchar(2000)  NOT NULL,
    [PondereadoProposito] float  NULL,
    [PonderedoResultado] float  NULL,
    [PonderedoActividad] float  NULL,
    [Ponderado_Hito] float  NULL,
    [Meta_actividad] float  NOT NULL,
    [Meta_Resultado] float  NOT NULL,
    [Meta_Proposito] float  NOT NULL,
    [Idperiodo] bigint  NOT NULL,
    [Ponderado_Avance_Hito] float  NULL,
    [Base_Hito] float  NOT NULL,
    [Meta_Hito] float  NOT NULL
);
GO

-- Creating table 'View_InformeCronogramaHitos'
CREATE TABLE [dbo].[View_InformeCronogramaHitos] (
    [idproyecto] varchar(7)  NOT NULL,
    [nombreproyecto] varchar(111)  NOT NULL,
    [idejcutor] varchar(11)  NOT NULL,
    [nombreejecutor] varchar(6)  NOT NULL,
    [nombrepais] varchar(4)  NOT NULL,
    [fechainicio] varchar(10)  NOT NULL,
    [fechafin] varchar(10)  NOT NULL,
    [resultadoid] int  NOT NULL,
    [porcentajeresultado] int  NOT NULL,
    [nombreresultado] varchar(18)  NOT NULL,
    [actividadid] decimal(2,1)  NOT NULL,
    [actividadDes] varchar(85)  NOT NULL,
    [porcentajeact] int  NOT NULL,
    [Idhito] int  NOT NULL,
    [hito] varchar(47)  NOT NULL,
    [porcentajehito] int  NOT NULL,
    [porcentajeperiodo] int  NOT NULL,
    [periodo] int  NOT NULL
);
GO

-- Creating table 'View_InformeCronogramaHitos1'
CREATE TABLE [dbo].[View_InformeCronogramaHitos1] (
    [id] bigint  NULL,
    [Proyecto] nvarchar(500)  NULL,
    [IdProyecto] int  NOT NULL,
    [Fecha_de_Inicio] datetime  NULL,
    [Fecha_de_Vencimiento] datetime  NULL,
    [Periodo] nvarchar(50)  NOT NULL,
    [IdProposito] int  NULL,
    [Proposito] nvarchar(2000)  NULL,
    [IdobjetivoResultado] int  NOT NULL,
    [Entregable] nvarchar(2000)  NULL,
    [IdClaseResultdo] int  NULL,
    [IdobjetivoAvtividad] int  NOT NULL,
    [Actividad] nvarchar(50)  NULL,
    [Descripcion_Actividad] nvarchar(2000)  NULL,
    [Fecha_de_Inicio_Actividad] datetime  NULL,
    [IdClaseActividad] int  NULL,
    [Fecha_de_Inicio_Resultado] datetime  NULL,
    [Hito] nvarchar(2000)  NOT NULL,
    [PondereadoProposito] float  NULL,
    [PonderedoResultado] float  NULL,
    [PonderedoActividad] float  NULL,
    [Ponderado_Hito] float  NULL,
    [Meta_actividad] float  NOT NULL,
    [Meta_Resultado] float  NOT NULL,
    [Meta_Proposito] float  NOT NULL,
    [Idperiodo] bigint  NOT NULL,
    [IdobjetivoProducto] int  NOT NULL,
    [Descripcion_Producto] nvarchar(2000)  NULL,
    [PonderedoProducto] float  NULL,
    [Producto] nvarchar(50)  NULL
);
GO

-- Creating table 'View_InformeRendicionGastos1'
CREATE TABLE [dbo].[View_InformeRendicionGastos1] (
    [id] bigint  NULL,
    [Ejecutor] nvarchar(256)  NOT NULL,
    [Pais] varchar(50)  NOT NULL,
    [IdProyecto] int  NOT NULL,
    [Proyecto] nvarchar(500)  NULL,
    [Fecha_de_Inicio] datetime  NULL,
    [Fecha_de_Vencimiento] datetime  NULL,
    [ObjetivoProposito] int  NOT NULL,
    [Proposito] nvarchar(2000)  NULL,
    [Presupuesto_Proposito] float  NULL,
    [ObjetivoResultado] int  NOT NULL,
    [Resultado] nvarchar(2000)  NULL,
    [ObjetivoActividad] int  NOT NULL,
    [Actividad] nvarchar(50)  NULL,
    [Descripcion_de_Actividad] nvarchar(2000)  NULL,
    [IdPresupuestoActividad] int  NOT NULL,
    [Tipo_Presupuesto_Actividad] int  NULL,
    [Presupuesto_Actividad] float  NULL,
    [Monto_Movimiento] float  NULL,
    [Periodo_id] bigint  NOT NULL,
    [Periodo_Movimiento] nvarchar(50)  NOT NULL,
    [IdPartidaGasto] int  NOT NULL,
    [Partida_Gasto] nvarchar(50)  NOT NULL,
    [Descripcion] nvarchar(500)  NULL,
    [Aportes] decimal(18,2)  NULL,
    [Contrapartida] decimal(18,2)  NULL,
    [Aporte_Moneda_Local] decimal(18,2)  NULL,
    [Taza_Cambio] decimal(38,20)  NULL,
    [Numero_Comprobante] nvarchar(50)  NULL,
    [Fecha_Pago] datetime  NULL,
    [Moneda] nvarchar(61)  NULL,
    [Beneficiario] nvarchar(150)  NULL
);
GO

-- Creating table 'View_InformeRendicionGastos1fer'
CREATE TABLE [dbo].[View_InformeRendicionGastos1fer] (
    [id] bigint  NULL,
    [Proyecto] nvarchar(500)  NULL,
    [IdProyecto] int  NOT NULL,
    [Ejecutor] nvarchar(256)  NOT NULL,
    [Pais] varchar(50)  NOT NULL,
    [Fecha_de_Vencimiento] datetime  NULL,
    [Fecha_de_Inicio] datetime  NULL,
    [ObjetivoProposito] int  NOT NULL,
    [Presupuesto_Proposito] float  NULL,
    [Proposito] nvarchar(2000)  NULL,
    [ObjetivoResultado] int  NOT NULL,
    [Resultado] nvarchar(2000)  NULL,
    [ObjetivoActividad] int  NOT NULL,
    [Actividad] nvarchar(50)  NULL,
    [Descripcion_de_Actividad] nvarchar(2000)  NULL,
    [IdPresupuestoActividad] int  NOT NULL,
    [Tipo_Presupuesto_Actividad] int  NULL,
    [Presupuesto_Actividad] float  NULL,
    [Monto_Movimiento] float  NULL,
    [Periodo_id] bigint  NOT NULL,
    [Periodo_Movimiento] nvarchar(50)  NOT NULL,
    [IdPartidaGasto] int  NOT NULL,
    [Partida_Gasto] nvarchar(50)  NOT NULL,
    [Beneficiario] nvarchar(150)  NULL,
    [Contrapartida] decimal(18,2)  NULL,
    [Fecha_Pago] datetime  NULL,
    [Aportes] decimal(18,2)  NULL,
    [Aporte_Moneda_Local] decimal(18,2)  NULL,
    [Taza_Cambio] decimal(38,20)  NULL,
    [Numero_Comprobante] nvarchar(50)  NULL,
    [Descripcion] nvarchar(500)  NULL,
    [Moneda] nvarchar(61)  NULL
);
GO

-- Creating table 'View_InformeTecnicoAvanceHitos'
CREATE TABLE [dbo].[View_InformeTecnicoAvanceHitos] (
    [id] bigint  NULL,
    [Proyecto] nvarchar(500)  NULL,
    [IdProyecto] int  NOT NULL,
    [Fecha_de_Inicio] datetime  NULL,
    [Fecha_de_Vencimiento] datetime  NULL,
    [Periodo] nvarchar(50)  NOT NULL,
    [IdProposito] int  NULL,
    [Proposito] nvarchar(2000)  NULL,
    [IdobjetivoResultado] int  NOT NULL,
    [Entregable] nvarchar(2000)  NULL,
    [IdClaseResultdo] int  NULL,
    [IdobjetivoAvtividad] int  NOT NULL,
    [Actividad] nvarchar(50)  NULL,
    [Descripcion_Actividad] nvarchar(2000)  NULL,
    [Fecha_de_Inicio_Actividad] datetime  NULL,
    [IdClaseActividad] int  NULL,
    [Fecha_de_Inicio_Resultado] datetime  NULL,
    [Hito] nvarchar(2000)  NOT NULL,
    [PondereadoProposito] float  NULL,
    [PonderedoResultado] float  NULL,
    [PonderedoActividad] float  NULL,
    [Ponderado_Hito] float  NULL,
    [Meta_actividad] float  NOT NULL,
    [Meta_Resultado] float  NOT NULL,
    [Meta_Proposito] float  NOT NULL,
    [Idperiodo] bigint  NOT NULL,
    [Ponderado_Avance_Hito] float  NULL,
    [Base_Hito] float  NOT NULL,
    [IdIndicador] int  NOT NULL,
    [Meta_Hito] float  NOT NULL,
    [Obserbaciones_ED] nvarchar(2000)  NULL,
    [Observaciones_URIP] nvarchar(2000)  NULL,
    [ADH] decimal(5,2)  NULL,
    [CV] decimal(4,2)  NULL
);
GO

-- Creating table 'View_InfromeDetalleEjecucionGasto'
CREATE TABLE [dbo].[View_InfromeDetalleEjecucionGasto] (
    [id] bigint  NULL,
    [Proyecto] nvarchar(500)  NULL,
    [IdProyecto] int  NOT NULL,
    [Pais] varchar(50)  NOT NULL,
    [Ejecutor] nvarchar(256)  NOT NULL,
    [Fecha_de_Inicio] datetime  NULL,
    [Fecha_de_Vencimiento] datetime  NULL,
    [Periodo_Movimiento] nvarchar(50)  NOT NULL,
    [ObjetivoProposito] int  NOT NULL,
    [Proposito] nvarchar(2000)  NULL,
    [Presupuesto_Proposito] float  NULL,
    [ObjetivoResultado] int  NOT NULL,
    [Resultado] nvarchar(2000)  NULL,
    [ObjetivoActividad] int  NOT NULL,
    [Actividad] nvarchar(50)  NULL,
    [Descripcion_de_Actividad] nvarchar(2000)  NULL,
    [Presupuesto_Actividad] float  NULL,
    [IdPresupuestoActividad] nvarchar(150)  NULL,
    [Monto_Movimiento] float  NULL,
    [Tipo_Presupuesto_Actividad] int  NULL,
    [IdPartidaGasto] int  NOT NULL,
    [Partida_Gasto] nvarchar(50)  NOT NULL,
    [Beneficiario] nvarchar(150)  NULL,
    [Aportes] decimal(18,2)  NULL,
    [Contrapartida] decimal(18,2)  NULL,
    [Fecha_Pago] datetime  NULL,
    [Taza_Cambio] decimal(2,1)  NOT NULL,
    [Cheque_Operacion] int  NOT NULL,
    [Numero_Comprobante] varchar(9)  NOT NULL
);
GO

-- Creating table 'View_ppto_resultado_tipo'
CREATE TABLE [dbo].[View_ppto_resultado_tipo] (
    [idproyecto] int  NOT NULL,
    [idobjetivo] int  NULL,
    [Codigo] nvarchar(50)  NULL,
    [Descripcion] nvarchar(2000)  NULL,
    [tipopresupuesto] int  NOT NULL,
    [presupuesto] decimal(38,2)  NULL
);
GO

-- Creating table 'View_saldoppto_resultado_tipo'
CREATE TABLE [dbo].[View_saldoppto_resultado_tipo] (
    [idproyecto] int  NOT NULL,
    [idobjetivo] int  NULL,
    [Codigo] nvarchar(50)  NULL,
    [Descripcion] nvarchar(2000)  NULL,
    [tipopresupuesto] int  NOT NULL,
    [presupuesto] decimal(38,2)  NULL,
    [ejecutado] decimal(38,2)  NULL,
    [anio] int  NULL
);
GO

-- Creating table 'vw_aspnet_Applications'
CREATE TABLE [dbo].[vw_aspnet_Applications] (
    [ApplicationName] nvarchar(256)  NOT NULL,
    [LoweredApplicationName] nvarchar(256)  NOT NULL,
    [ApplicationId] uniqueidentifier  NOT NULL,
    [Description] nvarchar(256)  NULL
);
GO

-- Creating table 'vw_aspnet_MembershipUsers'
CREATE TABLE [dbo].[vw_aspnet_MembershipUsers] (
    [UserId] uniqueidentifier  NOT NULL,
    [PasswordFormat] int  NOT NULL,
    [MobilePIN] nvarchar(16)  NULL,
    [Email] nvarchar(256)  NULL,
    [LoweredEmail] nvarchar(256)  NULL,
    [PasswordQuestion] nvarchar(256)  NULL,
    [PasswordAnswer] nvarchar(128)  NULL,
    [IsApproved] bit  NOT NULL,
    [IsLockedOut] bit  NOT NULL,
    [CreateDate] datetime  NOT NULL,
    [LastLoginDate] datetime  NOT NULL,
    [LastPasswordChangedDate] datetime  NOT NULL,
    [LastLockoutDate] datetime  NOT NULL,
    [FailedPasswordAttemptCount] int  NOT NULL,
    [FailedPasswordAttemptWindowStart] datetime  NOT NULL,
    [FailedPasswordAnswerAttemptCount] int  NOT NULL,
    [FailedPasswordAnswerAttemptWindowStart] datetime  NOT NULL,
    [Comment] nvarchar(max)  NULL,
    [ApplicationId] uniqueidentifier  NOT NULL,
    [UserName] nvarchar(256)  NOT NULL,
    [MobileAlias] nvarchar(16)  NULL,
    [IsAnonymous] bit  NOT NULL,
    [LastActivityDate] datetime  NOT NULL
);
GO

-- Creating table 'vw_aspnet_Profiles'
CREATE TABLE [dbo].[vw_aspnet_Profiles] (
    [UserId] uniqueidentifier  NOT NULL,
    [LastUpdatedDate] datetime  NOT NULL,
    [DataSize] int  NULL
);
GO

-- Creating table 'vw_aspnet_Roles'
CREATE TABLE [dbo].[vw_aspnet_Roles] (
    [ApplicationId] uniqueidentifier  NOT NULL,
    [RoleId] uniqueidentifier  NOT NULL,
    [RoleName] nvarchar(256)  NOT NULL,
    [LoweredRoleName] nvarchar(256)  NOT NULL,
    [Description] nvarchar(256)  NULL
);
GO

-- Creating table 'vw_aspnet_Users'
CREATE TABLE [dbo].[vw_aspnet_Users] (
    [ApplicationId] uniqueidentifier  NOT NULL,
    [UserId] uniqueidentifier  NOT NULL,
    [UserName] nvarchar(256)  NOT NULL,
    [LoweredUserName] nvarchar(256)  NOT NULL,
    [MobileAlias] nvarchar(16)  NULL,
    [IsAnonymous] bit  NOT NULL,
    [LastActivityDate] datetime  NOT NULL
);
GO

-- Creating table 'vw_aspnet_UsersInRoles'
CREATE TABLE [dbo].[vw_aspnet_UsersInRoles] (
    [UserId] uniqueidentifier  NOT NULL,
    [RoleId] uniqueidentifier  NOT NULL
);
GO

-- Creating table 'vw_aspnet_WebPartState_Paths'
CREATE TABLE [dbo].[vw_aspnet_WebPartState_Paths] (
    [ApplicationId] uniqueidentifier  NOT NULL,
    [PathId] uniqueidentifier  NOT NULL,
    [Path] nvarchar(256)  NOT NULL,
    [LoweredPath] nvarchar(256)  NOT NULL
);
GO

-- Creating table 'vw_aspnet_WebPartState_Shared'
CREATE TABLE [dbo].[vw_aspnet_WebPartState_Shared] (
    [PathId] uniqueidentifier  NOT NULL,
    [DataSize] int  NULL,
    [LastUpdatedDate] datetime  NOT NULL
);
GO

-- Creating table 'vw_aspnet_WebPartState_User'
CREATE TABLE [dbo].[vw_aspnet_WebPartState_User] (
    [PathId] uniqueidentifier  NULL,
    [UserId] uniqueidentifier  NULL,
    [DataSize] int  NULL,
    [LastUpdatedDate] datetime  NOT NULL
);
GO

-- Creating table 'Pry_Beneficiarios'
CREATE TABLE [dbo].[Pry_Beneficiarios] (
    [IdBeneficiario] int IDENTITY(1,1) NOT NULL,
    [IdObjetivo] int  NOT NULL,
    [Nombre] nvarchar(250)  NOT NULL,
    [Email] nvarchar(100)  NOT NULL,
    [Telefono] nvarchar(20)  NULL,
    [Direccion] nvarchar(250)  NULL,
    [Status] tinyint  NOT NULL
);
GO

-- Creating table 'Pry_CapacitacionBeneficiario'
CREATE TABLE [dbo].[Pry_CapacitacionBeneficiario] (
    [IdCapacitacionBeneficiario] int IDENTITY(1,1) NOT NULL,
    [IdCapacitacion] int  NOT NULL,
    [IdBeneficiario] int  NOT NULL,
    [FechaInscripcion] datetime  NOT NULL,
    [Status] tinyint  NOT NULL
);
GO

-- Creating table 'Pry_Capacitaciones'
CREATE TABLE [dbo].[Pry_Capacitaciones] (
    [IdCapacitacion] int IDENTITY(1,1) NOT NULL,
    [IdFacilitador] int  NOT NULL,
    [NombreCapacitacion] nvarchar(200)  NOT NULL,
    [DescripcionCapacitacion] nvarchar(1000)  NULL,
    [FechaInicio] datetime  NOT NULL,
    [FechaFinal] datetime  NOT NULL,
    [Status] tinyint  NOT NULL
);
GO

-- Creating table 'Pry_Facilitadores'
CREATE TABLE [dbo].[Pry_Facilitadores] (
    [IdFacilitador] int IDENTITY(1,1) NOT NULL,
    [Nombre] nvarchar(250)  NOT NULL,
    [Email] nvarchar(100)  NOT NULL,
    [Telefono] nvarchar(20)  NULL,
    [Direccion] nvarchar(250)  NULL,
    [Status] tinyint  NOT NULL
);
GO

-- Creating table 'Pry_ProductividadBeneficiario'
CREATE TABLE [dbo].[Pry_ProductividadBeneficiario] (
    [IdProductividadBeneficiario] int IDENTITY(1,1) NOT NULL,
    [IdBeneficiario] int  NOT NULL,
    [Area] decimal(18,2)  NOT NULL,
    [CantidadSembrada] decimal(18,2)  NOT NULL,
    [ProduccionCultivo] decimal(18,2)  NOT NULL
);
GO

-- Creating table 'PRY_PERIODOSPROYECTOS'
CREATE TABLE [dbo].[PRY_PERIODOSPROYECTOS] (
    [IdPeriodo] bigint IDENTITY(1,1) NOT NULL,
    [Nombre] nvarchar(50)  NOT NULL,
    [FechaInicio] datetime  NOT NULL,
    [FechaFin] datetime  NOT NULL,
    [IdProyecto] int  NULL,
    [Activo] bit  NULL
);
GO

-- Creating table 'Doc_Clientes_Categorias'
CREATE TABLE [dbo].[Doc_Clientes_Categorias] (
    [Doc_Categorias_IdCategoria] int  NOT NULL,
    [Sys_Clientes_Id] int  NOT NULL
);
GO

-- Creating table 'Org_Donantes_Empresas'
CREATE TABLE [dbo].[Org_Donantes_Empresas] (
    [Org_Donantes_IdDonante] int  NOT NULL,
    [Org_Empresas_IdEmpresa] int  NOT NULL
);
GO

-- Creating table 'Pry_Indicadores_Variables'
CREATE TABLE [dbo].[Pry_Indicadores_Variables] (
    [Pry_Indicadores_IdIndicador] int  NOT NULL,
    [Pry_Variables_IdVariable] int  NOT NULL
);
GO

-- Creating table 'Sys_Usuarios_Donantes'
CREATE TABLE [dbo].[Sys_Usuarios_Donantes] (
    [Org_Donantes_IdDonante] int  NOT NULL,
    [Sys_Usuarios_IdUsuario] int  NOT NULL
);
GO

-- Creating table 'Sys_Usuarios_Empresas'
CREATE TABLE [dbo].[Sys_Usuarios_Empresas] (
    [Org_Empresas_IdEmpresa] int  NOT NULL,
    [Sys_Usuarios_IdUsuario] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [IdNodo] in table 'Cms_MenuNodos'
ALTER TABLE [dbo].[Cms_MenuNodos]
ADD CONSTRAINT [PK_Cms_MenuNodos]
    PRIMARY KEY CLUSTERED ([IdNodo] ASC);
GO

-- Creating primary key on [IdMenu] in table 'Cms_Menus'
ALTER TABLE [dbo].[Cms_Menus]
ADD CONSTRAINT [PK_Cms_Menus]
    PRIMARY KEY CLUSTERED ([IdMenu] ASC);
GO

-- Creating primary key on [IdMensaje] in table 'Com_Mensajes'
ALTER TABLE [dbo].[Com_Mensajes]
ADD CONSTRAINT [PK_Com_Mensajes]
    PRIMARY KEY CLUSTERED ([IdMensaje] ASC);
GO

-- Creating primary key on [IdEstado] in table 'Com_MensajesEstado'
ALTER TABLE [dbo].[Com_MensajesEstado]
ADD CONSTRAINT [PK_Com_MensajesEstado]
    PRIMARY KEY CLUSTERED ([IdEstado] ASC);
GO

-- Creating primary key on [IdTipoArchivo] in table 'Doc_ArchivosTipos'
ALTER TABLE [dbo].[Doc_ArchivosTipos]
ADD CONSTRAINT [PK_Doc_ArchivosTipos]
    PRIMARY KEY CLUSTERED ([IdTipoArchivo] ASC);
GO

-- Creating primary key on [IdCategoria] in table 'Doc_Categorias'
ALTER TABLE [dbo].[Doc_Categorias]
ADD CONSTRAINT [PK_Doc_Categorias]
    PRIMARY KEY CLUSTERED ([IdCategoria] ASC);
GO

-- Creating primary key on [IdDocumento] in table 'Doc_Documentos'
ALTER TABLE [dbo].[Doc_Documentos]
ADD CONSTRAINT [PK_Doc_Documentos]
    PRIMARY KEY CLUSTERED ([IdDocumento] ASC);
GO

-- Creating primary key on [IdEncuesta] in table 'M_Encuestas'
ALTER TABLE [dbo].[M_Encuestas]
ADD CONSTRAINT [PK_M_Encuestas]
    PRIMARY KEY CLUSTERED ([IdEncuesta] ASC);
GO

-- Creating primary key on [IdIdioma] in table 'M_Idiomas'
ALTER TABLE [dbo].[M_Idiomas]
ADD CONSTRAINT [PK_M_Idiomas]
    PRIMARY KEY CLUSTERED ([IdIdioma] ASC);
GO

-- Creating primary key on [IdMoneda] in table 'M_Monedas'
ALTER TABLE [dbo].[M_Monedas]
ADD CONSTRAINT [PK_M_Monedas]
    PRIMARY KEY CLUSTERED ([IdMoneda] ASC);
GO

-- Creating primary key on [IdPais] in table 'M_Paises'
ALTER TABLE [dbo].[M_Paises]
ADD CONSTRAINT [PK_M_Paises]
    PRIMARY KEY CLUSTERED ([IdPais] ASC);
GO

-- Creating primary key on [IdPeriodo] in table 'M_Periodos'
ALTER TABLE [dbo].[M_Periodos]
ADD CONSTRAINT [PK_M_Periodos]
    PRIMARY KEY CLUSTERED ([IdPeriodo] ASC);
GO

-- Creating primary key on [IdPregunta] in table 'M_Preguntas'
ALTER TABLE [dbo].[M_Preguntas]
ADD CONSTRAINT [PK_M_Preguntas]
    PRIMARY KEY CLUSTERED ([IdPregunta] ASC);
GO

-- Creating primary key on [IdTema] in table 'M_Temas'
ALTER TABLE [dbo].[M_Temas]
ADD CONSTRAINT [PK_M_Temas]
    PRIMARY KEY CLUSTERED ([IdTema] ASC);
GO

-- Creating primary key on [IdArea] in table 'Org_Areas'
ALTER TABLE [dbo].[Org_Areas]
ADD CONSTRAINT [PK_Org_Areas]
    PRIMARY KEY CLUSTERED ([IdArea] ASC);
GO

-- Creating primary key on [IdCargo] in table 'Org_Cargos'
ALTER TABLE [dbo].[Org_Cargos]
ADD CONSTRAINT [PK_Org_Cargos]
    PRIMARY KEY CLUSTERED ([IdCargo] ASC);
GO

-- Creating primary key on [IdDonante] in table 'Org_Donantes'
ALTER TABLE [dbo].[Org_Donantes]
ADD CONSTRAINT [PK_Org_Donantes]
    PRIMARY KEY CLUSTERED ([IdDonante] ASC);
GO

-- Creating primary key on [IdEmpleado] in table 'Org_Empleados'
ALTER TABLE [dbo].[Org_Empleados]
ADD CONSTRAINT [PK_Org_Empleados]
    PRIMARY KEY CLUSTERED ([IdEmpleado] ASC);
GO

-- Creating primary key on [IdEmpleadoCargo] in table 'Org_EmpleadosCargosHistorico'
ALTER TABLE [dbo].[Org_EmpleadosCargosHistorico]
ADD CONSTRAINT [PK_Org_EmpleadosCargosHistorico]
    PRIMARY KEY CLUSTERED ([IdEmpleadoCargo] ASC);
GO

-- Creating primary key on [IdEmpresa] in table 'Org_Empresas'
ALTER TABLE [dbo].[Org_Empresas]
ADD CONSTRAINT [PK_Org_Empresas]
    PRIMARY KEY CLUSTERED ([IdEmpresa] ASC);
GO

-- Creating primary key on [IdIdentificacionTipo] in table 'Org_IdentificacionTipos'
ALTER TABLE [dbo].[Org_IdentificacionTipos]
ADD CONSTRAINT [PK_Org_IdentificacionTipos]
    PRIMARY KEY CLUSTERED ([IdIdentificacionTipo] ASC);
GO

-- Creating primary key on [IdProveedor] in table 'Org_Proveedores'
ALTER TABLE [dbo].[Org_Proveedores]
ADD CONSTRAINT [PK_Org_Proveedores]
    PRIMARY KEY CLUSTERED ([IdProveedor] ASC);
GO

-- Creating primary key on [IdBitacora] in table 'Pry_Bitacoras'
ALTER TABLE [dbo].[Pry_Bitacoras]
ADD CONSTRAINT [PK_Pry_Bitacoras]
    PRIMARY KEY CLUSTERED ([IdBitacora] ASC);
GO

-- Creating primary key on [IdDonacion] in table 'Pry_CalendarioDonaciones'
ALTER TABLE [dbo].[Pry_CalendarioDonaciones]
ADD CONSTRAINT [PK_Pry_CalendarioDonaciones]
    PRIMARY KEY CLUSTERED ([IdDonacion] ASC);
GO

-- Creating primary key on [IdDatosMuestra] in table 'Pry_DatosMuestras'
ALTER TABLE [dbo].[Pry_DatosMuestras]
ADD CONSTRAINT [PK_Pry_DatosMuestras]
    PRIMARY KEY CLUSTERED ([IdDatosMuestra] ASC);
GO

-- Creating primary key on [IdDatosMuestra], [IdVariable] in table 'Pry_DatosVariables'
ALTER TABLE [dbo].[Pry_DatosVariables]
ADD CONSTRAINT [PK_Pry_DatosVariables]
    PRIMARY KEY CLUSTERED ([IdDatosMuestra], [IdVariable] ASC);
GO

-- Creating primary key on [IdDatosFuentes] in table 'Pry_DatosVerificadores'
ALTER TABLE [dbo].[Pry_DatosVerificadores]
ADD CONSTRAINT [PK_Pry_DatosVerificadores]
    PRIMARY KEY CLUSTERED ([IdDatosFuentes] ASC);
GO

-- Creating primary key on [IDOBJETIVO], [IDPERIODO], [IDPROYECTO] in table 'PRY_EVALUACIONESACTIVIDADESPERIODO'
ALTER TABLE [dbo].[PRY_EVALUACIONESACTIVIDADESPERIODO]
ADD CONSTRAINT [PK_PRY_EVALUACIONESACTIVIDADESPERIODO]
    PRIMARY KEY CLUSTERED ([IDOBJETIVO], [IDPERIODO], [IDPROYECTO] ASC);
GO

-- Creating primary key on [IdProyecto], [IdPeriodo], [IdResultado], [IdActividad], [IdHito] in table 'Pry_EvaluacionHitos'
ALTER TABLE [dbo].[Pry_EvaluacionHitos]
ADD CONSTRAINT [PK_Pry_EvaluacionHitos]
    PRIMARY KEY CLUSTERED ([IdProyecto], [IdPeriodo], [IdResultado], [IdActividad], [IdHito] ASC);
GO

-- Creating primary key on [IdProyecto], [IdPeriodo], [IdResultado], [IdHito] in table 'PRY_EVALUACIONINDICADORESPERIODO'
ALTER TABLE [dbo].[PRY_EVALUACIONINDICADORESPERIODO]
ADD CONSTRAINT [PK_PRY_EVALUACIONINDICADORESPERIODO]
    PRIMARY KEY CLUSTERED ([IdProyecto], [IdPeriodo], [IdResultado], [IdHito] ASC);
GO

-- Creating primary key on [IDPERIODO], [IDPROYECTO] in table 'PRY_EVALUACIONPROYECTOPERIODO'
ALTER TABLE [dbo].[PRY_EVALUACIONPROYECTOPERIODO]
ADD CONSTRAINT [PK_PRY_EVALUACIONPROYECTOPERIODO]
    PRIMARY KEY CLUSTERED ([IDPERIODO], [IDPROYECTO] ASC);
GO

-- Creating primary key on [IdIndicador] in table 'Pry_Indicadores'
ALTER TABLE [dbo].[Pry_Indicadores]
ADD CONSTRAINT [PK_Pry_Indicadores]
    PRIMARY KEY CLUSTERED ([IdIndicador] ASC);
GO

-- Creating primary key on [IdIndicadorProyecto], [IdIndicadorPrograma] in table 'Pry_IndicadoresProyecto_Programa'
ALTER TABLE [dbo].[Pry_IndicadoresProyecto_Programa]
ADD CONSTRAINT [PK_Pry_IndicadoresProyecto_Programa]
    PRIMARY KEY CLUSTERED ([IdIndicadorProyecto], [IdIndicadorPrograma] ASC);
GO

-- Creating primary key on [IdTipo] in table 'Pry_IndicadoresTipos'
ALTER TABLE [dbo].[Pry_IndicadoresTipos]
ADD CONSTRAINT [PK_Pry_IndicadoresTipos]
    PRIMARY KEY CLUSTERED ([IdTipo] ASC);
GO

-- Creating primary key on [IdVerificador] in table 'Pry_IndicadoresVerificadores'
ALTER TABLE [dbo].[Pry_IndicadoresVerificadores]
ADD CONSTRAINT [PK_Pry_IndicadoresVerificadores]
    PRIMARY KEY CLUSTERED ([IdVerificador] ASC);
GO

-- Creating primary key on [IdInforme] in table 'Pry_Informes'
ALTER TABLE [dbo].[Pry_Informes]
ADD CONSTRAINT [PK_Pry_Informes]
    PRIMARY KEY CLUSTERED ([IdInforme] ASC);
GO

-- Creating primary key on [IdInforme], [IdDonante] in table 'Pry_Informes_Donantes'
ALTER TABLE [dbo].[Pry_Informes_Donantes]
ADD CONSTRAINT [PK_Pry_Informes_Donantes]
    PRIMARY KEY CLUSTERED ([IdInforme], [IdDonante] ASC);
GO

-- Creating primary key on [IdInforme], [IdPregunta] in table 'Pry_Informes_Encuestas'
ALTER TABLE [dbo].[Pry_Informes_Encuestas]
ADD CONSTRAINT [PK_Pry_Informes_Encuestas]
    PRIMARY KEY CLUSTERED ([IdInforme], [IdPregunta] ASC);
GO

-- Creating primary key on [IdInforme], [IdIndicador] in table 'Pry_Informes_Indicador'
ALTER TABLE [dbo].[Pry_Informes_Indicador]
ADD CONSTRAINT [PK_Pry_Informes_Indicador]
    PRIMARY KEY CLUSTERED ([IdInforme], [IdIndicador] ASC);
GO

-- Creating primary key on [IdInforme], [IdPresupuesto] in table 'Pry_Informes_Presupuestos'
ALTER TABLE [dbo].[Pry_Informes_Presupuestos]
ADD CONSTRAINT [PK_Pry_Informes_Presupuestos]
    PRIMARY KEY CLUSTERED ([IdInforme], [IdPresupuesto] ASC);
GO

-- Creating primary key on [IdInforme], [IdSupuesto] in table 'Pry_Informes_Supuestos'
ALTER TABLE [dbo].[Pry_Informes_Supuestos]
ADD CONSTRAINT [PK_Pry_Informes_Supuestos]
    PRIMARY KEY CLUSTERED ([IdInforme], [IdSupuesto] ASC);
GO

-- Creating primary key on [IdEstado] in table 'Pry_InformesEstados'
ALTER TABLE [dbo].[Pry_InformesEstados]
ADD CONSTRAINT [PK_Pry_InformesEstados]
    PRIMARY KEY CLUSTERED ([IdEstado] ASC);
GO

-- Creating primary key on [IDINFORME] in table 'PRY_INFORMESICA'
ALTER TABLE [dbo].[PRY_INFORMESICA]
ADD CONSTRAINT [PK_PRY_INFORMESICA]
    PRIMARY KEY CLUSTERED ([IDINFORME] ASC);
GO

-- Creating primary key on [IDDETALLE] in table 'PRY_INFORMESICADETALLE'
ALTER TABLE [dbo].[PRY_INFORMESICADETALLE]
ADD CONSTRAINT [PK_PRY_INFORMESICADETALLE]
    PRIMARY KEY CLUSTERED ([IDDETALLE] ASC);
GO

-- Creating primary key on [IDDOCUMENTO] in table 'PRY_INFORMESICADOCUMENTOS'
ALTER TABLE [dbo].[PRY_INFORMESICADOCUMENTOS]
ADD CONSTRAINT [PK_PRY_INFORMESICADOCUMENTOS]
    PRIMARY KEY CLUSTERED ([IDDOCUMENTO] ASC);
GO

-- Creating primary key on [IDESTADO] in table 'PRY_INFORMESICAESTADOS'
ALTER TABLE [dbo].[PRY_INFORMESICAESTADOS]
ADD CONSTRAINT [PK_PRY_INFORMESICAESTADOS]
    PRIMARY KEY CLUSTERED ([IDESTADO] ASC);
GO

-- Creating primary key on [IDINFORME], [IDINDICADOR] in table 'PRY_INFORMESICAINDICADORES'
ALTER TABLE [dbo].[PRY_INFORMESICAINDICADORES]
ADD CONSTRAINT [PK_PRY_INFORMESICAINDICADORES]
    PRIMARY KEY CLUSTERED ([IDINFORME], [IDINDICADOR] ASC);
GO

-- Creating primary key on [IDINFORME], [IDOBJETIVO] in table 'PRY_INFORMESICAOBJETIVOS'
ALTER TABLE [dbo].[PRY_INFORMESICAOBJETIVOS]
ADD CONSTRAINT [PK_PRY_INFORMESICAOBJETIVOS]
    PRIMARY KEY CLUSTERED ([IDINFORME], [IDOBJETIVO] ASC);
GO

-- Creating primary key on [IDTIPO] in table 'PRY_INFORMESICATIPOS'
ALTER TABLE [dbo].[PRY_INFORMESICATIPOS]
ADD CONSTRAINT [PK_PRY_INFORMESICATIPOS]
    PRIMARY KEY CLUSTERED ([IDTIPO] ASC);
GO

-- Creating primary key on [IdMovimiento] in table 'Pry_Movimientos'
ALTER TABLE [dbo].[Pry_Movimientos]
ADD CONSTRAINT [PK_Pry_Movimientos]
    PRIMARY KEY CLUSTERED ([IdMovimiento] ASC);
GO

-- Creating primary key on [IdNivelAceptacion] in table 'Pry_NivelAceptacion'
ALTER TABLE [dbo].[Pry_NivelAceptacion]
ADD CONSTRAINT [PK_Pry_NivelAceptacion]
    PRIMARY KEY CLUSTERED ([IdNivelAceptacion] ASC);
GO

-- Creating primary key on [IdObjetivo] in table 'Pry_Objetivos'
ALTER TABLE [dbo].[Pry_Objetivos]
ADD CONSTRAINT [PK_Pry_Objetivos]
    PRIMARY KEY CLUSTERED ([IdObjetivo] ASC);
GO

-- Creating primary key on [IdObjetivoClase] in table 'Pry_ObjetivosClase'
ALTER TABLE [dbo].[Pry_ObjetivosClase]
ADD CONSTRAINT [PK_Pry_ObjetivosClase]
    PRIMARY KEY CLUSTERED ([IdObjetivoClase] ASC);
GO

-- Creating primary key on [IDPARTIDAGASTO] in table 'PRY_PARTIDAGASTOS'
ALTER TABLE [dbo].[PRY_PARTIDAGASTOS]
ADD CONSTRAINT [PK_PRY_PARTIDAGASTOS]
    PRIMARY KEY CLUSTERED ([IDPARTIDAGASTO] ASC);
GO

-- Creating primary key on [IdPresupuesto] in table 'Pry_Presupuesto'
ALTER TABLE [dbo].[Pry_Presupuesto]
ADD CONSTRAINT [PK_Pry_Presupuesto]
    PRIMARY KEY CLUSTERED ([IdPresupuesto] ASC);
GO

-- Creating primary key on [IdTipo] in table 'Pry_PresupuestoTipo'
ALTER TABLE [dbo].[Pry_PresupuestoTipo]
ADD CONSTRAINT [PK_Pry_PresupuestoTipo]
    PRIMARY KEY CLUSTERED ([IdTipo] ASC);
GO

-- Creating primary key on [IdProyecto] in table 'Pry_Proyectos'
ALTER TABLE [dbo].[Pry_Proyectos]
ADD CONSTRAINT [PK_Pry_Proyectos]
    PRIMARY KEY CLUSTERED ([IdProyecto] ASC);
GO

-- Creating primary key on [IdProyecto], [IdDonante] in table 'Pry_Proyectos_Donantes'
ALTER TABLE [dbo].[Pry_Proyectos_Donantes]
ADD CONSTRAINT [PK_Pry_Proyectos_Donantes]
    PRIMARY KEY CLUSTERED ([IdProyecto], [IdDonante] ASC);
GO

-- Creating primary key on [IdProyecto], [IdNivelAceptacion] in table 'Pry_Proyectos_NivelAceptacion'
ALTER TABLE [dbo].[Pry_Proyectos_NivelAceptacion]
ADD CONSTRAINT [PK_Pry_Proyectos_NivelAceptacion]
    PRIMARY KEY CLUSTERED ([IdProyecto], [IdNivelAceptacion] ASC);
GO

-- Creating primary key on [IdEstado] in table 'Pry_ProyectosEstados'
ALTER TABLE [dbo].[Pry_ProyectosEstados]
ADD CONSTRAINT [PK_Pry_ProyectosEstados]
    PRIMARY KEY CLUSTERED ([IdEstado] ASC);
GO

-- Creating primary key on [Id] in table 'Pry_ProyectosTipos'
ALTER TABLE [dbo].[Pry_ProyectosTipos]
ADD CONSTRAINT [PK_Pry_ProyectosTipos]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [IdRecurso] in table 'Pry_Recursos'
ALTER TABLE [dbo].[Pry_Recursos]
ADD CONSTRAINT [PK_Pry_Recursos]
    PRIMARY KEY CLUSTERED ([IdRecurso] ASC);
GO

-- Creating primary key on [IdSupuesto] in table 'Pry_Supuestos'
ALTER TABLE [dbo].[Pry_Supuestos]
ADD CONSTRAINT [PK_Pry_Supuestos]
    PRIMARY KEY CLUSTERED ([IdSupuesto] ASC);
GO

-- Creating primary key on [IdVariable] in table 'Pry_Variables'
ALTER TABLE [dbo].[Pry_Variables]
ADD CONSTRAINT [PK_Pry_Variables]
    PRIMARY KEY CLUSTERED ([IdVariable] ASC);
GO

-- Creating primary key on [Id] in table 'Sys_Clientes'
ALTER TABLE [dbo].[Sys_Clientes]
ADD CONSTRAINT [PK_Sys_Clientes]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [IdUsuario] in table 'Sys_Usuarios'
ALTER TABLE [dbo].[Sys_Usuarios]
ADD CONSTRAINT [PK_Sys_Usuarios]
    PRIMARY KEY CLUSTERED ([IdUsuario] ASC);
GO

-- Creating primary key on [diagram_id] in table 'sysdiagrams'
ALTER TABLE [dbo].[sysdiagrams]
ADD CONSTRAINT [PK_sysdiagrams]
    PRIMARY KEY CLUSTERED ([diagram_id] ASC);
GO

-- Creating primary key on [Id] in table 'Tar_Listas'
ALTER TABLE [dbo].[Tar_Listas]
ADD CONSTRAINT [PK_Tar_Listas]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Tar_Tareas'
ALTER TABLE [dbo].[Tar_Tareas]
ADD CONSTRAINT [PK_Tar_Tareas]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [tipopresupuesto] in table 'View_ejecutado_resultado_tipo'
ALTER TABLE [dbo].[View_ejecutado_resultado_tipo]
ADD CONSTRAINT [PK_View_ejecutado_resultado_tipo]
    PRIMARY KEY CLUSTERED ([tipopresupuesto] ASC);
GO

-- Creating primary key on [IdProyecto], [Ejecutor], [Pais], [ObjetivoProposito], [ObjetivoResultado], [ObjetivoActividad], [IdPresupuestoActividad], [Fecha_Gasto], [IdMovimiento] in table 'View_Informe_de_Saldos'
ALTER TABLE [dbo].[View_Informe_de_Saldos]
ADD CONSTRAINT [PK_View_Informe_de_Saldos]
    PRIMARY KEY CLUSTERED ([IdProyecto], [Ejecutor], [Pais], [ObjetivoProposito], [ObjetivoResultado], [ObjetivoActividad], [IdPresupuestoActividad], [Fecha_Gasto], [IdMovimiento] ASC);
GO

-- Creating primary key on [IdProyecto], [Pais], [Ejecutor], [Periodo], [IdPeriodo], [CantidadPro], [CantidadResul], [Indicadores_Proposito], [IdIndicadorproposito], [ObjetivoResultado], [Tipo_Informe], [Indicadores_Resultado], [Idindicadorresultado], [Base_Proposito], [Base_Resultado] in table 'View_Informe_ITFSemestral'
ALTER TABLE [dbo].[View_Informe_ITFSemestral]
ADD CONSTRAINT [PK_View_Informe_ITFSemestral]
    PRIMARY KEY CLUSTERED ([IdProyecto], [Pais], [Ejecutor], [Periodo], [IdPeriodo], [CantidadPro], [CantidadResul], [Indicadores_Proposito], [IdIndicadorproposito], [ObjetivoResultado], [Tipo_Informe], [Indicadores_Resultado], [Idindicadorresultado], [Base_Proposito], [Base_Resultado] ASC);
GO

-- Creating primary key on [tipopresupuesto] in table 'View_Informe_Saldos_FER'
ALTER TABLE [dbo].[View_Informe_Saldos_FER]
ADD CONSTRAINT [PK_View_Informe_Saldos_FER]
    PRIMARY KEY CLUSTERED ([tipopresupuesto] ASC);
GO

-- Creating primary key on [IdProyecto], [Pais], [Entidad_Desarrolladora], [IdPeriodo], [Periodo] in table 'View_InformeAdministrativoITFUNIP'
ALTER TABLE [dbo].[View_InformeAdministrativoITFUNIP]
ADD CONSTRAINT [PK_View_InformeAdministrativoITFUNIP]
    PRIMARY KEY CLUSTERED ([IdProyecto], [Pais], [Entidad_Desarrolladora], [IdPeriodo], [Periodo] ASC);
GO

-- Creating primary key on [IdProyecto], [Periodo], [IdobjetivoResultado], [IdobjetivoAvtividad], [Hito], [Meta_actividad], [Meta_Resultado], [Meta_Proposito], [Idperiodo], [Base_Hito], [Meta_Hito] in table 'View_InformeAvanceHitos'
ALTER TABLE [dbo].[View_InformeAvanceHitos]
ADD CONSTRAINT [PK_View_InformeAvanceHitos]
    PRIMARY KEY CLUSTERED ([IdProyecto], [Periodo], [IdobjetivoResultado], [IdobjetivoAvtividad], [Hito], [Meta_actividad], [Meta_Resultado], [Meta_Proposito], [Idperiodo], [Base_Hito], [Meta_Hito] ASC);
GO

-- Creating primary key on [idproyecto], [nombreproyecto], [idejcutor], [nombreejecutor], [nombrepais], [fechainicio], [fechafin], [resultadoid], [porcentajeresultado], [nombreresultado], [actividadid], [actividadDes], [porcentajeact], [Idhito], [hito], [porcentajehito], [porcentajeperiodo], [periodo] in table 'View_InformeCronogramaHitos'
ALTER TABLE [dbo].[View_InformeCronogramaHitos]
ADD CONSTRAINT [PK_View_InformeCronogramaHitos]
    PRIMARY KEY CLUSTERED ([idproyecto], [nombreproyecto], [idejcutor], [nombreejecutor], [nombrepais], [fechainicio], [fechafin], [resultadoid], [porcentajeresultado], [nombreresultado], [actividadid], [actividadDes], [porcentajeact], [Idhito], [hito], [porcentajehito], [porcentajeperiodo], [periodo] ASC);
GO

-- Creating primary key on [IdProyecto], [Periodo], [IdobjetivoResultado], [IdobjetivoAvtividad], [Hito], [Meta_actividad], [Meta_Resultado], [Meta_Proposito], [Idperiodo], [IdobjetivoProducto] in table 'View_InformeCronogramaHitos1'
ALTER TABLE [dbo].[View_InformeCronogramaHitos1]
ADD CONSTRAINT [PK_View_InformeCronogramaHitos1]
    PRIMARY KEY CLUSTERED ([IdProyecto], [Periodo], [IdobjetivoResultado], [IdobjetivoAvtividad], [Hito], [Meta_actividad], [Meta_Resultado], [Meta_Proposito], [Idperiodo], [IdobjetivoProducto] ASC);
GO

-- Creating primary key on [Ejecutor], [Pais], [IdProyecto], [ObjetivoProposito], [ObjetivoResultado], [ObjetivoActividad], [IdPresupuestoActividad], [Periodo_id], [Periodo_Movimiento], [IdPartidaGasto], [Partida_Gasto] in table 'View_InformeRendicionGastos1'
ALTER TABLE [dbo].[View_InformeRendicionGastos1]
ADD CONSTRAINT [PK_View_InformeRendicionGastos1]
    PRIMARY KEY CLUSTERED ([Ejecutor], [Pais], [IdProyecto], [ObjetivoProposito], [ObjetivoResultado], [ObjetivoActividad], [IdPresupuestoActividad], [Periodo_id], [Periodo_Movimiento], [IdPartidaGasto], [Partida_Gasto] ASC);
GO

-- Creating primary key on [IdProyecto], [Ejecutor], [Pais], [ObjetivoProposito], [ObjetivoResultado], [ObjetivoActividad], [IdPresupuestoActividad], [Periodo_id], [Periodo_Movimiento], [IdPartidaGasto], [Partida_Gasto] in table 'View_InformeRendicionGastos1fer'
ALTER TABLE [dbo].[View_InformeRendicionGastos1fer]
ADD CONSTRAINT [PK_View_InformeRendicionGastos1fer]
    PRIMARY KEY CLUSTERED ([IdProyecto], [Ejecutor], [Pais], [ObjetivoProposito], [ObjetivoResultado], [ObjetivoActividad], [IdPresupuestoActividad], [Periodo_id], [Periodo_Movimiento], [IdPartidaGasto], [Partida_Gasto] ASC);
GO

-- Creating primary key on [IdProyecto], [Periodo], [IdobjetivoResultado], [IdobjetivoAvtividad], [Hito], [Meta_actividad], [Meta_Resultado], [Meta_Proposito], [Idperiodo], [Base_Hito], [IdIndicador], [Meta_Hito] in table 'View_InformeTecnicoAvanceHitos'
ALTER TABLE [dbo].[View_InformeTecnicoAvanceHitos]
ADD CONSTRAINT [PK_View_InformeTecnicoAvanceHitos]
    PRIMARY KEY CLUSTERED ([IdProyecto], [Periodo], [IdobjetivoResultado], [IdobjetivoAvtividad], [Hito], [Meta_actividad], [Meta_Resultado], [Meta_Proposito], [Idperiodo], [Base_Hito], [IdIndicador], [Meta_Hito] ASC);
GO

-- Creating primary key on [IdProyecto], [Pais], [Ejecutor], [Periodo_Movimiento], [ObjetivoProposito], [ObjetivoResultado], [ObjetivoActividad], [IdPartidaGasto], [Partida_Gasto], [Taza_Cambio], [Cheque_Operacion], [Numero_Comprobante] in table 'View_InfromeDetalleEjecucionGasto'
ALTER TABLE [dbo].[View_InfromeDetalleEjecucionGasto]
ADD CONSTRAINT [PK_View_InfromeDetalleEjecucionGasto]
    PRIMARY KEY CLUSTERED ([IdProyecto], [Pais], [Ejecutor], [Periodo_Movimiento], [ObjetivoProposito], [ObjetivoResultado], [ObjetivoActividad], [IdPartidaGasto], [Partida_Gasto], [Taza_Cambio], [Cheque_Operacion], [Numero_Comprobante] ASC);
GO

-- Creating primary key on [idproyecto], [tipopresupuesto] in table 'View_ppto_resultado_tipo'
ALTER TABLE [dbo].[View_ppto_resultado_tipo]
ADD CONSTRAINT [PK_View_ppto_resultado_tipo]
    PRIMARY KEY CLUSTERED ([idproyecto], [tipopresupuesto] ASC);
GO

-- Creating primary key on [idproyecto], [tipopresupuesto] in table 'View_saldoppto_resultado_tipo'
ALTER TABLE [dbo].[View_saldoppto_resultado_tipo]
ADD CONSTRAINT [PK_View_saldoppto_resultado_tipo]
    PRIMARY KEY CLUSTERED ([idproyecto], [tipopresupuesto] ASC);
GO

-- Creating primary key on [ApplicationName], [LoweredApplicationName], [ApplicationId] in table 'vw_aspnet_Applications'
ALTER TABLE [dbo].[vw_aspnet_Applications]
ADD CONSTRAINT [PK_vw_aspnet_Applications]
    PRIMARY KEY CLUSTERED ([ApplicationName], [LoweredApplicationName], [ApplicationId] ASC);
GO

-- Creating primary key on [UserId], [PasswordFormat], [IsApproved], [IsLockedOut], [CreateDate], [LastLoginDate], [LastPasswordChangedDate], [LastLockoutDate], [FailedPasswordAttemptCount], [FailedPasswordAttemptWindowStart], [FailedPasswordAnswerAttemptCount], [FailedPasswordAnswerAttemptWindowStart], [ApplicationId], [UserName], [IsAnonymous], [LastActivityDate] in table 'vw_aspnet_MembershipUsers'
ALTER TABLE [dbo].[vw_aspnet_MembershipUsers]
ADD CONSTRAINT [PK_vw_aspnet_MembershipUsers]
    PRIMARY KEY CLUSTERED ([UserId], [PasswordFormat], [IsApproved], [IsLockedOut], [CreateDate], [LastLoginDate], [LastPasswordChangedDate], [LastLockoutDate], [FailedPasswordAttemptCount], [FailedPasswordAttemptWindowStart], [FailedPasswordAnswerAttemptCount], [FailedPasswordAnswerAttemptWindowStart], [ApplicationId], [UserName], [IsAnonymous], [LastActivityDate] ASC);
GO

-- Creating primary key on [UserId], [LastUpdatedDate] in table 'vw_aspnet_Profiles'
ALTER TABLE [dbo].[vw_aspnet_Profiles]
ADD CONSTRAINT [PK_vw_aspnet_Profiles]
    PRIMARY KEY CLUSTERED ([UserId], [LastUpdatedDate] ASC);
GO

-- Creating primary key on [ApplicationId], [RoleId], [RoleName], [LoweredRoleName] in table 'vw_aspnet_Roles'
ALTER TABLE [dbo].[vw_aspnet_Roles]
ADD CONSTRAINT [PK_vw_aspnet_Roles]
    PRIMARY KEY CLUSTERED ([ApplicationId], [RoleId], [RoleName], [LoweredRoleName] ASC);
GO

-- Creating primary key on [ApplicationId], [UserId], [UserName], [LoweredUserName], [IsAnonymous], [LastActivityDate] in table 'vw_aspnet_Users'
ALTER TABLE [dbo].[vw_aspnet_Users]
ADD CONSTRAINT [PK_vw_aspnet_Users]
    PRIMARY KEY CLUSTERED ([ApplicationId], [UserId], [UserName], [LoweredUserName], [IsAnonymous], [LastActivityDate] ASC);
GO

-- Creating primary key on [UserId], [RoleId] in table 'vw_aspnet_UsersInRoles'
ALTER TABLE [dbo].[vw_aspnet_UsersInRoles]
ADD CONSTRAINT [PK_vw_aspnet_UsersInRoles]
    PRIMARY KEY CLUSTERED ([UserId], [RoleId] ASC);
GO

-- Creating primary key on [ApplicationId], [PathId], [Path], [LoweredPath] in table 'vw_aspnet_WebPartState_Paths'
ALTER TABLE [dbo].[vw_aspnet_WebPartState_Paths]
ADD CONSTRAINT [PK_vw_aspnet_WebPartState_Paths]
    PRIMARY KEY CLUSTERED ([ApplicationId], [PathId], [Path], [LoweredPath] ASC);
GO

-- Creating primary key on [PathId], [LastUpdatedDate] in table 'vw_aspnet_WebPartState_Shared'
ALTER TABLE [dbo].[vw_aspnet_WebPartState_Shared]
ADD CONSTRAINT [PK_vw_aspnet_WebPartState_Shared]
    PRIMARY KEY CLUSTERED ([PathId], [LastUpdatedDate] ASC);
GO

-- Creating primary key on [LastUpdatedDate] in table 'vw_aspnet_WebPartState_User'
ALTER TABLE [dbo].[vw_aspnet_WebPartState_User]
ADD CONSTRAINT [PK_vw_aspnet_WebPartState_User]
    PRIMARY KEY CLUSTERED ([LastUpdatedDate] ASC);
GO

-- Creating primary key on [IdBeneficiario] in table 'Pry_Beneficiarios'
ALTER TABLE [dbo].[Pry_Beneficiarios]
ADD CONSTRAINT [PK_Pry_Beneficiarios]
    PRIMARY KEY CLUSTERED ([IdBeneficiario] ASC);
GO

-- Creating primary key on [IdCapacitacionBeneficiario] in table 'Pry_CapacitacionBeneficiario'
ALTER TABLE [dbo].[Pry_CapacitacionBeneficiario]
ADD CONSTRAINT [PK_Pry_CapacitacionBeneficiario]
    PRIMARY KEY CLUSTERED ([IdCapacitacionBeneficiario] ASC);
GO

-- Creating primary key on [IdCapacitacion] in table 'Pry_Capacitaciones'
ALTER TABLE [dbo].[Pry_Capacitaciones]
ADD CONSTRAINT [PK_Pry_Capacitaciones]
    PRIMARY KEY CLUSTERED ([IdCapacitacion] ASC);
GO

-- Creating primary key on [IdFacilitador] in table 'Pry_Facilitadores'
ALTER TABLE [dbo].[Pry_Facilitadores]
ADD CONSTRAINT [PK_Pry_Facilitadores]
    PRIMARY KEY CLUSTERED ([IdFacilitador] ASC);
GO

-- Creating primary key on [IdProductividadBeneficiario] in table 'Pry_ProductividadBeneficiario'
ALTER TABLE [dbo].[Pry_ProductividadBeneficiario]
ADD CONSTRAINT [PK_Pry_ProductividadBeneficiario]
    PRIMARY KEY CLUSTERED ([IdProductividadBeneficiario] ASC);
GO

-- Creating primary key on [IdPeriodo] in table 'PRY_PERIODOSPROYECTOS'
ALTER TABLE [dbo].[PRY_PERIODOSPROYECTOS]
ADD CONSTRAINT [PK_PRY_PERIODOSPROYECTOS]
    PRIMARY KEY CLUSTERED ([IdPeriodo] ASC);
GO

-- Creating primary key on [Doc_Categorias_IdCategoria], [Sys_Clientes_Id] in table 'Doc_Clientes_Categorias'
ALTER TABLE [dbo].[Doc_Clientes_Categorias]
ADD CONSTRAINT [PK_Doc_Clientes_Categorias]
    PRIMARY KEY NONCLUSTERED ([Doc_Categorias_IdCategoria], [Sys_Clientes_Id] ASC);
GO

-- Creating primary key on [Org_Donantes_IdDonante], [Org_Empresas_IdEmpresa] in table 'Org_Donantes_Empresas'
ALTER TABLE [dbo].[Org_Donantes_Empresas]
ADD CONSTRAINT [PK_Org_Donantes_Empresas]
    PRIMARY KEY NONCLUSTERED ([Org_Donantes_IdDonante], [Org_Empresas_IdEmpresa] ASC);
GO

-- Creating primary key on [Pry_Indicadores_IdIndicador], [Pry_Variables_IdVariable] in table 'Pry_Indicadores_Variables'
ALTER TABLE [dbo].[Pry_Indicadores_Variables]
ADD CONSTRAINT [PK_Pry_Indicadores_Variables]
    PRIMARY KEY NONCLUSTERED ([Pry_Indicadores_IdIndicador], [Pry_Variables_IdVariable] ASC);
GO

-- Creating primary key on [Org_Donantes_IdDonante], [Sys_Usuarios_IdUsuario] in table 'Sys_Usuarios_Donantes'
ALTER TABLE [dbo].[Sys_Usuarios_Donantes]
ADD CONSTRAINT [PK_Sys_Usuarios_Donantes]
    PRIMARY KEY NONCLUSTERED ([Org_Donantes_IdDonante], [Sys_Usuarios_IdUsuario] ASC);
GO

-- Creating primary key on [Org_Empresas_IdEmpresa], [Sys_Usuarios_IdUsuario] in table 'Sys_Usuarios_Empresas'
ALTER TABLE [dbo].[Sys_Usuarios_Empresas]
ADD CONSTRAINT [PK_Sys_Usuarios_Empresas]
    PRIMARY KEY NONCLUSTERED ([Org_Empresas_IdEmpresa], [Sys_Usuarios_IdUsuario] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [IdMenu] in table 'Cms_MenuNodos'
ALTER TABLE [dbo].[Cms_MenuNodos]
ADD CONSTRAINT [FK_Cms_MenuNodes_Cms_Menu]
    FOREIGN KEY ([IdMenu])
    REFERENCES [dbo].[Cms_Menus]
        ([IdMenu])
    ON DELETE CASCADE ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Cms_MenuNodes_Cms_Menu'
CREATE INDEX [IX_FK_Cms_MenuNodes_Cms_Menu]
ON [dbo].[Cms_MenuNodos]
    ([IdMenu]);
GO

-- Creating foreign key on [IdMenuSuperior] in table 'Org_Empresas'
ALTER TABLE [dbo].[Org_Empresas]
ADD CONSTRAINT [FK_Org_Empresas_Cms_Menus]
    FOREIGN KEY ([IdMenuSuperior])
    REFERENCES [dbo].[Cms_Menus]
        ([IdMenu])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Org_Empresas_Cms_Menus'
CREATE INDEX [IX_FK_Org_Empresas_Cms_Menus]
ON [dbo].[Org_Empresas]
    ([IdMenuSuperior]);
GO

-- Creating foreign key on [IdMenuIzquierdo] in table 'Org_Empresas'
ALTER TABLE [dbo].[Org_Empresas]
ADD CONSTRAINT [FK_Org_Empresas_Cms_Menus1]
    FOREIGN KEY ([IdMenuIzquierdo])
    REFERENCES [dbo].[Cms_Menus]
        ([IdMenu])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Org_Empresas_Cms_Menus1'
CREATE INDEX [IX_FK_Org_Empresas_Cms_Menus1]
ON [dbo].[Org_Empresas]
    ([IdMenuIzquierdo]);
GO

-- Creating foreign key on [IdMenuPanel] in table 'Org_Empresas'
ALTER TABLE [dbo].[Org_Empresas]
ADD CONSTRAINT [FK_Org_Empresas_Cms_Menus2]
    FOREIGN KEY ([IdMenuPanel])
    REFERENCES [dbo].[Cms_Menus]
        ([IdMenu])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Org_Empresas_Cms_Menus2'
CREATE INDEX [IX_FK_Org_Empresas_Cms_Menus2]
ON [dbo].[Org_Empresas]
    ([IdMenuPanel]);
GO

-- Creating foreign key on [IdUsuarioRemitente] in table 'Com_Mensajes'
ALTER TABLE [dbo].[Com_Mensajes]
ADD CONSTRAINT [FK_Com_Mensajes_Sys_Usuarios]
    FOREIGN KEY ([IdUsuarioRemitente])
    REFERENCES [dbo].[Sys_Usuarios]
        ([IdUsuario])
    ON DELETE CASCADE ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Com_Mensajes_Sys_Usuarios'
CREATE INDEX [IX_FK_Com_Mensajes_Sys_Usuarios]
ON [dbo].[Com_Mensajes]
    ([IdUsuarioRemitente]);
GO

-- Creating foreign key on [IdEstado] in table 'Com_Mensajes'
ALTER TABLE [dbo].[Com_Mensajes]
ADD CONSTRAINT [FK_Mod_Messages_Mod_MessagesStatus]
    FOREIGN KEY ([IdEstado])
    REFERENCES [dbo].[Com_MensajesEstado]
        ([IdEstado])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Mod_Messages_Mod_MessagesStatus'
CREATE INDEX [IX_FK_Mod_Messages_Mod_MessagesStatus]
ON [dbo].[Com_Mensajes]
    ([IdEstado]);
GO

-- Creating foreign key on [IdTipoArchivo] in table 'Doc_Documentos'
ALTER TABLE [dbo].[Doc_Documentos]
ADD CONSTRAINT [FK_Doc_Documentos_Doc_ArchivosTipos]
    FOREIGN KEY ([IdTipoArchivo])
    REFERENCES [dbo].[Doc_ArchivosTipos]
        ([IdTipoArchivo])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Doc_Documentos_Doc_ArchivosTipos'
CREATE INDEX [IX_FK_Doc_Documentos_Doc_ArchivosTipos]
ON [dbo].[Doc_Documentos]
    ([IdTipoArchivo]);
GO

-- Creating foreign key on [IdCategoria] in table 'Doc_Documentos'
ALTER TABLE [dbo].[Doc_Documentos]
ADD CONSTRAINT [FK_Doc_Documentos_Doc_Categorias]
    FOREIGN KEY ([IdCategoria])
    REFERENCES [dbo].[Doc_Categorias]
        ([IdCategoria])
    ON DELETE CASCADE ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Doc_Documentos_Doc_Categorias'
CREATE INDEX [IX_FK_Doc_Documentos_Doc_Categorias]
ON [dbo].[Doc_Documentos]
    ([IdCategoria]);
GO

-- Creating foreign key on [IdEncuesta] in table 'M_Preguntas'
ALTER TABLE [dbo].[M_Preguntas]
ADD CONSTRAINT [FK_M_Preguntas_M_Encuestas]
    FOREIGN KEY ([IdEncuesta])
    REFERENCES [dbo].[M_Encuestas]
        ([IdEncuesta])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_M_Preguntas_M_Encuestas'
CREATE INDEX [IX_FK_M_Preguntas_M_Encuestas]
ON [dbo].[M_Preguntas]
    ([IdEncuesta]);
GO

-- Creating foreign key on [MONEDALOCAL] in table 'Pry_Movimientos'
ALTER TABLE [dbo].[Pry_Movimientos]
ADD CONSTRAINT [FK_Pry_Movimientos_M_Monedas]
    FOREIGN KEY ([MONEDALOCAL])
    REFERENCES [dbo].[M_Monedas]
        ([IdMoneda])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Pry_Movimientos_M_Monedas'
CREATE INDEX [IX_FK_Pry_Movimientos_M_Monedas]
ON [dbo].[Pry_Movimientos]
    ([MONEDALOCAL]);
GO

-- Creating foreign key on [IdMoneda] in table 'Pry_Proyectos'
ALTER TABLE [dbo].[Pry_Proyectos]
ADD CONSTRAINT [FK_Pry_Proyectos_M_Monedas]
    FOREIGN KEY ([IdMoneda])
    REFERENCES [dbo].[M_Monedas]
        ([IdMoneda])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Pry_Proyectos_M_Monedas'
CREATE INDEX [IX_FK_Pry_Proyectos_M_Monedas]
ON [dbo].[Pry_Proyectos]
    ([IdMoneda]);
GO

-- Creating foreign key on [IdPais] in table 'Org_Empresas'
ALTER TABLE [dbo].[Org_Empresas]
ADD CONSTRAINT [FK_Org_Empresas_M_Paises]
    FOREIGN KEY ([IdPais])
    REFERENCES [dbo].[M_Paises]
        ([IdPais])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Org_Empresas_M_Paises'
CREATE INDEX [IX_FK_Org_Empresas_M_Paises]
ON [dbo].[Org_Empresas]
    ([IdPais]);
GO

-- Creating foreign key on [IdPregunta] in table 'Pry_Informes_Encuestas'
ALTER TABLE [dbo].[Pry_Informes_Encuestas]
ADD CONSTRAINT [FK_Pry_Informes_Encuestas_M_Preguntas]
    FOREIGN KEY ([IdPregunta])
    REFERENCES [dbo].[M_Preguntas]
        ([IdPregunta])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Pry_Informes_Encuestas_M_Preguntas'
CREATE INDEX [IX_FK_Pry_Informes_Encuestas_M_Preguntas]
ON [dbo].[Pry_Informes_Encuestas]
    ([IdPregunta]);
GO

-- Creating foreign key on [IdEmpresa] in table 'Org_Areas'
ALTER TABLE [dbo].[Org_Areas]
ADD CONSTRAINT [FK_Org_Areas_Org_Empresas]
    FOREIGN KEY ([IdEmpresa])
    REFERENCES [dbo].[Org_Empresas]
        ([IdEmpresa])
    ON DELETE CASCADE ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Org_Areas_Org_Empresas'
CREATE INDEX [IX_FK_Org_Areas_Org_Empresas]
ON [dbo].[Org_Areas]
    ([IdEmpresa]);
GO

-- Creating foreign key on [IdArea] in table 'Org_Cargos'
ALTER TABLE [dbo].[Org_Cargos]
ADD CONSTRAINT [FK_Org_Cargos_Org_Areas]
    FOREIGN KEY ([IdArea])
    REFERENCES [dbo].[Org_Areas]
        ([IdArea])
    ON DELETE CASCADE ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Org_Cargos_Org_Areas'
CREATE INDEX [IX_FK_Org_Cargos_Org_Areas]
ON [dbo].[Org_Cargos]
    ([IdArea]);
GO

-- Creating foreign key on [IdCargo] in table 'Org_Empleados'
ALTER TABLE [dbo].[Org_Empleados]
ADD CONSTRAINT [FK_Org_Empleados_Org_Cargos]
    FOREIGN KEY ([IdCargo])
    REFERENCES [dbo].[Org_Cargos]
        ([IdCargo])
    ON DELETE CASCADE ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Org_Empleados_Org_Cargos'
CREATE INDEX [IX_FK_Org_Empleados_Org_Cargos]
ON [dbo].[Org_Empleados]
    ([IdCargo]);
GO

-- Creating foreign key on [IdCargo] in table 'Org_EmpleadosCargosHistorico'
ALTER TABLE [dbo].[Org_EmpleadosCargosHistorico]
ADD CONSTRAINT [FK_Org_EmpleadosCargosHistorico_Org_Cargos]
    FOREIGN KEY ([IdCargo])
    REFERENCES [dbo].[Org_Cargos]
        ([IdCargo])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Org_EmpleadosCargosHistorico_Org_Cargos'
CREATE INDEX [IX_FK_Org_EmpleadosCargosHistorico_Org_Cargos]
ON [dbo].[Org_EmpleadosCargosHistorico]
    ([IdCargo]);
GO

-- Creating foreign key on [IdIdentificacionTipo] in table 'Org_Donantes'
ALTER TABLE [dbo].[Org_Donantes]
ADD CONSTRAINT [FK_Org_Donantes_Org_IdentificacionTipos]
    FOREIGN KEY ([IdIdentificacionTipo])
    REFERENCES [dbo].[Org_IdentificacionTipos]
        ([IdIdentificacionTipo])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Org_Donantes_Org_IdentificacionTipos'
CREATE INDEX [IX_FK_Org_Donantes_Org_IdentificacionTipos]
ON [dbo].[Org_Donantes]
    ([IdIdentificacionTipo]);
GO

-- Creating foreign key on [IdCliente] in table 'Org_Donantes'
ALTER TABLE [dbo].[Org_Donantes]
ADD CONSTRAINT [FK_Org_Donantes_Sys_Clientes]
    FOREIGN KEY ([IdCliente])
    REFERENCES [dbo].[Sys_Clientes]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Org_Donantes_Sys_Clientes'
CREATE INDEX [IX_FK_Org_Donantes_Sys_Clientes]
ON [dbo].[Org_Donantes]
    ([IdCliente]);
GO

-- Creating foreign key on [IdDonante] in table 'Pry_Proyectos_Donantes'
ALTER TABLE [dbo].[Pry_Proyectos_Donantes]
ADD CONSTRAINT [FK_Pro_Proyectos_Donantes_Org_Donantes]
    FOREIGN KEY ([IdDonante])
    REFERENCES [dbo].[Org_Donantes]
        ([IdDonante])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Pro_Proyectos_Donantes_Org_Donantes'
CREATE INDEX [IX_FK_Pro_Proyectos_Donantes_Org_Donantes]
ON [dbo].[Pry_Proyectos_Donantes]
    ([IdDonante]);
GO

-- Creating foreign key on [IdDonante] in table 'Pry_CalendarioDonaciones'
ALTER TABLE [dbo].[Pry_CalendarioDonaciones]
ADD CONSTRAINT [FK_Pry_Calendario_Donaciones_Org_Donantes]
    FOREIGN KEY ([IdDonante])
    REFERENCES [dbo].[Org_Donantes]
        ([IdDonante])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Pry_Calendario_Donaciones_Org_Donantes'
CREATE INDEX [IX_FK_Pry_Calendario_Donaciones_Org_Donantes]
ON [dbo].[Pry_CalendarioDonaciones]
    ([IdDonante]);
GO

-- Creating foreign key on [IdDonante] in table 'Pry_Informes_Donantes'
ALTER TABLE [dbo].[Pry_Informes_Donantes]
ADD CONSTRAINT [FK_Pry_Informes_Donantes_Org_Donantes]
    FOREIGN KEY ([IdDonante])
    REFERENCES [dbo].[Org_Donantes]
        ([IdDonante])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Pry_Informes_Donantes_Org_Donantes'
CREATE INDEX [IX_FK_Pry_Informes_Donantes_Org_Donantes]
ON [dbo].[Pry_Informes_Donantes]
    ([IdDonante]);
GO

-- Creating foreign key on [IdIdentificacionTipo] in table 'Org_Empleados'
ALTER TABLE [dbo].[Org_Empleados]
ADD CONSTRAINT [FK_Org_Empleados_Org_IdentificacionTipos]
    FOREIGN KEY ([IdIdentificacionTipo])
    REFERENCES [dbo].[Org_IdentificacionTipos]
        ([IdIdentificacionTipo])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Org_Empleados_Org_IdentificacionTipos'
CREATE INDEX [IX_FK_Org_Empleados_Org_IdentificacionTipos]
ON [dbo].[Org_Empleados]
    ([IdIdentificacionTipo]);
GO

-- Creating foreign key on [IdUsuario] in table 'Org_Empleados'
ALTER TABLE [dbo].[Org_Empleados]
ADD CONSTRAINT [FK_Org_Empleados_Sys_Usuarios]
    FOREIGN KEY ([IdUsuario])
    REFERENCES [dbo].[Sys_Usuarios]
        ([IdUsuario])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Org_Empleados_Sys_Usuarios'
CREATE INDEX [IX_FK_Org_Empleados_Sys_Usuarios]
ON [dbo].[Org_Empleados]
    ([IdUsuario]);
GO

-- Creating foreign key on [IdEmpleado] in table 'Org_EmpleadosCargosHistorico'
ALTER TABLE [dbo].[Org_EmpleadosCargosHistorico]
ADD CONSTRAINT [FK_Org_EmpleadosCargosHistorico_Org_Empleados]
    FOREIGN KEY ([IdEmpleado])
    REFERENCES [dbo].[Org_Empleados]
        ([IdEmpleado])
    ON DELETE CASCADE ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Org_EmpleadosCargosHistorico_Org_Empleados'
CREATE INDEX [IX_FK_Org_EmpleadosCargosHistorico_Org_Empleados]
ON [dbo].[Org_EmpleadosCargosHistorico]
    ([IdEmpleado]);
GO

-- Creating foreign key on [IdResponsableIndicador] in table 'Pry_Indicadores'
ALTER TABLE [dbo].[Pry_Indicadores]
ADD CONSTRAINT [FK_Pry_Indicadores_Org_Empleados]
    FOREIGN KEY ([IdResponsableIndicador])
    REFERENCES [dbo].[Org_Empleados]
        ([IdEmpleado])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Pry_Indicadores_Org_Empleados'
CREATE INDEX [IX_FK_Pry_Indicadores_Org_Empleados]
ON [dbo].[Pry_Indicadores]
    ([IdResponsableIndicador]);
GO

-- Creating foreign key on [IdIdentificacionTipo] in table 'Org_Empresas'
ALTER TABLE [dbo].[Org_Empresas]
ADD CONSTRAINT [FK_Org_Empresas_Org_IdentificacionTipos]
    FOREIGN KEY ([IdIdentificacionTipo])
    REFERENCES [dbo].[Org_IdentificacionTipos]
        ([IdIdentificacionTipo])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Org_Empresas_Org_IdentificacionTipos'
CREATE INDEX [IX_FK_Org_Empresas_Org_IdentificacionTipos]
ON [dbo].[Org_Empresas]
    ([IdIdentificacionTipo]);
GO

-- Creating foreign key on [IdCliente] in table 'Org_Empresas'
ALTER TABLE [dbo].[Org_Empresas]
ADD CONSTRAINT [FK_Org_Empresas_Sys_Clientes]
    FOREIGN KEY ([IdCliente])
    REFERENCES [dbo].[Sys_Clientes]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Org_Empresas_Sys_Clientes'
CREATE INDEX [IX_FK_Org_Empresas_Sys_Clientes]
ON [dbo].[Org_Empresas]
    ([IdCliente]);
GO

-- Creating foreign key on [IdEmpresa] in table 'Org_Proveedores'
ALTER TABLE [dbo].[Org_Proveedores]
ADD CONSTRAINT [FK_Org_Proveedores_Org_Empresas]
    FOREIGN KEY ([IdEmpresa])
    REFERENCES [dbo].[Org_Empresas]
        ([IdEmpresa])
    ON DELETE CASCADE ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Org_Proveedores_Org_Empresas'
CREATE INDEX [IX_FK_Org_Proveedores_Org_Empresas]
ON [dbo].[Org_Proveedores]
    ([IdEmpresa]);
GO

-- Creating foreign key on [IdEmpresa] in table 'Pry_Objetivos'
ALTER TABLE [dbo].[Pry_Objetivos]
ADD CONSTRAINT [FK_Pry_Objetivos_Org_Empresas]
    FOREIGN KEY ([IdEmpresa])
    REFERENCES [dbo].[Org_Empresas]
        ([IdEmpresa])
    ON DELETE CASCADE ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Pry_Objetivos_Org_Empresas'
CREATE INDEX [IX_FK_Pry_Objetivos_Org_Empresas]
ON [dbo].[Pry_Objetivos]
    ([IdEmpresa]);
GO

-- Creating foreign key on [IdIdentificacionTipo] in table 'Org_Proveedores'
ALTER TABLE [dbo].[Org_Proveedores]
ADD CONSTRAINT [FK_Org_Proveedores_Org_IdentificacionTipos]
    FOREIGN KEY ([IdIdentificacionTipo])
    REFERENCES [dbo].[Org_IdentificacionTipos]
        ([IdIdentificacionTipo])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Org_Proveedores_Org_IdentificacionTipos'
CREATE INDEX [IX_FK_Org_Proveedores_Org_IdentificacionTipos]
ON [dbo].[Org_Proveedores]
    ([IdIdentificacionTipo]);
GO

-- Creating foreign key on [IdProyecto] in table 'Pry_Bitacoras'
ALTER TABLE [dbo].[Pry_Bitacoras]
ADD CONSTRAINT [FK_Pry_Bitacoras_Pry_Proyectos]
    FOREIGN KEY ([IdProyecto])
    REFERENCES [dbo].[Pry_Proyectos]
        ([IdProyecto])
    ON DELETE CASCADE ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Pry_Bitacoras_Pry_Proyectos'
CREATE INDEX [IX_FK_Pry_Bitacoras_Pry_Proyectos]
ON [dbo].[Pry_Bitacoras]
    ([IdProyecto]);
GO

-- Creating foreign key on [IdProyecto] in table 'Pry_CalendarioDonaciones'
ALTER TABLE [dbo].[Pry_CalendarioDonaciones]
ADD CONSTRAINT [FK_Pry_Calendario_Donaciones_Pry_Proyectos]
    FOREIGN KEY ([IdProyecto])
    REFERENCES [dbo].[Pry_Proyectos]
        ([IdProyecto])
    ON DELETE CASCADE ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Pry_Calendario_Donaciones_Pry_Proyectos'
CREATE INDEX [IX_FK_Pry_Calendario_Donaciones_Pry_Proyectos]
ON [dbo].[Pry_CalendarioDonaciones]
    ([IdProyecto]);
GO

-- Creating foreign key on [IdIndicador] in table 'Pry_DatosMuestras'
ALTER TABLE [dbo].[Pry_DatosMuestras]
ADD CONSTRAINT [FK_Pry_DatosMuestras_Pry_Indicadores]
    FOREIGN KEY ([IdIndicador])
    REFERENCES [dbo].[Pry_Indicadores]
        ([IdIndicador])
    ON DELETE CASCADE ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Pry_DatosMuestras_Pry_Indicadores'
CREATE INDEX [IX_FK_Pry_DatosMuestras_Pry_Indicadores]
ON [dbo].[Pry_DatosMuestras]
    ([IdIndicador]);
GO

-- Creating foreign key on [IdNivelAceptacionEfectividad] in table 'Pry_DatosMuestras'
ALTER TABLE [dbo].[Pry_DatosMuestras]
ADD CONSTRAINT [FK_Pry_DatosMuestras_Pry_NivelAceptacion]
    FOREIGN KEY ([IdNivelAceptacionEfectividad])
    REFERENCES [dbo].[Pry_NivelAceptacion]
        ([IdNivelAceptacion])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Pry_DatosMuestras_Pry_NivelAceptacion'
CREATE INDEX [IX_FK_Pry_DatosMuestras_Pry_NivelAceptacion]
ON [dbo].[Pry_DatosMuestras]
    ([IdNivelAceptacionEfectividad]);
GO

-- Creating foreign key on [IdDatosMuestra] in table 'Pry_DatosVariables'
ALTER TABLE [dbo].[Pry_DatosVariables]
ADD CONSTRAINT [FK_Pry_DatosVariables_Pry_DatosMuestras]
    FOREIGN KEY ([IdDatosMuestra])
    REFERENCES [dbo].[Pry_DatosMuestras]
        ([IdDatosMuestra])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [IdDatosMuestra] in table 'Pry_DatosVerificadores'
ALTER TABLE [dbo].[Pry_DatosVerificadores]
ADD CONSTRAINT [FK_Pry_DatosVerificadores_Pry_DatosMuestras]
    FOREIGN KEY ([IdDatosMuestra])
    REFERENCES [dbo].[Pry_DatosMuestras]
        ([IdDatosMuestra])
    ON DELETE CASCADE ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Pry_DatosVerificadores_Pry_DatosMuestras'
CREATE INDEX [IX_FK_Pry_DatosVerificadores_Pry_DatosMuestras]
ON [dbo].[Pry_DatosVerificadores]
    ([IdDatosMuestra]);
GO

-- Creating foreign key on [IdDatosMuestra] in table 'Pry_Informes_Indicador'
ALTER TABLE [dbo].[Pry_Informes_Indicador]
ADD CONSTRAINT [FK_Pry_Informes_Indicador_Pry_DatosMuestras]
    FOREIGN KEY ([IdDatosMuestra])
    REFERENCES [dbo].[Pry_DatosMuestras]
        ([IdDatosMuestra])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Pry_Informes_Indicador_Pry_DatosMuestras'
CREATE INDEX [IX_FK_Pry_Informes_Indicador_Pry_DatosMuestras]
ON [dbo].[Pry_Informes_Indicador]
    ([IdDatosMuestra]);
GO

-- Creating foreign key on [IdVariable] in table 'Pry_DatosVariables'
ALTER TABLE [dbo].[Pry_DatosVariables]
ADD CONSTRAINT [FK_Pry_DatosVariables_Pry_Variables]
    FOREIGN KEY ([IdVariable])
    REFERENCES [dbo].[Pry_Variables]
        ([IdVariable])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Pry_DatosVariables_Pry_Variables'
CREATE INDEX [IX_FK_Pry_DatosVariables_Pry_Variables]
ON [dbo].[Pry_DatosVariables]
    ([IdVariable]);
GO

-- Creating foreign key on [IdVerificador] in table 'Pry_DatosVerificadores'
ALTER TABLE [dbo].[Pry_DatosVerificadores]
ADD CONSTRAINT [FK_Pry_DatosVerificadores_Pry_IndicadoresVerificadores]
    FOREIGN KEY ([IdVerificador])
    REFERENCES [dbo].[Pry_IndicadoresVerificadores]
        ([IdVerificador])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Pry_DatosVerificadores_Pry_IndicadoresVerificadores'
CREATE INDEX [IX_FK_Pry_DatosVerificadores_Pry_IndicadoresVerificadores]
ON [dbo].[Pry_DatosVerificadores]
    ([IdVerificador]);
GO

-- Creating foreign key on [IDPERIODO], [IDPROYECTO] in table 'PRY_EVALUACIONESACTIVIDADESPERIODO'
ALTER TABLE [dbo].[PRY_EVALUACIONESACTIVIDADESPERIODO]
ADD CONSTRAINT [FK_PRY_EVALUACIONESACTIVIDADESPERIODO_PRY_EVALUACIONPROYECTOPERIODO]
    FOREIGN KEY ([IDPERIODO], [IDPROYECTO])
    REFERENCES [dbo].[PRY_EVALUACIONPROYECTOPERIODO]
        ([IDPERIODO], [IDPROYECTO])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_PRY_EVALUACIONESACTIVIDADESPERIODO_PRY_EVALUACIONPROYECTOPERIODO'
CREATE INDEX [IX_FK_PRY_EVALUACIONESACTIVIDADESPERIODO_PRY_EVALUACIONPROYECTOPERIODO]
ON [dbo].[PRY_EVALUACIONESACTIVIDADESPERIODO]
    ([IDPERIODO], [IDPROYECTO]);
GO

-- Creating foreign key on [IDOBJETIVO] in table 'PRY_EVALUACIONESACTIVIDADESPERIODO'
ALTER TABLE [dbo].[PRY_EVALUACIONESACTIVIDADESPERIODO]
ADD CONSTRAINT [FK_PRY_EVALUACIONESACTIVIDADESPERIODO_Pry_Objetivos]
    FOREIGN KEY ([IDOBJETIVO])
    REFERENCES [dbo].[Pry_Objetivos]
        ([IdObjetivo])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [IdHito] in table 'Pry_EvaluacionHitos'
ALTER TABLE [dbo].[Pry_EvaluacionHitos]
ADD CONSTRAINT [FK_Pry_EvaluacionHitos_Pry_Indicadores]
    FOREIGN KEY ([IdHito])
    REFERENCES [dbo].[Pry_Indicadores]
        ([IdIndicador])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Pry_EvaluacionHitos_Pry_Indicadores'
CREATE INDEX [IX_FK_Pry_EvaluacionHitos_Pry_Indicadores]
ON [dbo].[Pry_EvaluacionHitos]
    ([IdHito]);
GO

-- Creating foreign key on [IdResultado] in table 'Pry_EvaluacionHitos'
ALTER TABLE [dbo].[Pry_EvaluacionHitos]
ADD CONSTRAINT [FK_Pry_EvaluacionHitos_Pry_Objetivos]
    FOREIGN KEY ([IdResultado])
    REFERENCES [dbo].[Pry_Objetivos]
        ([IdObjetivo])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Pry_EvaluacionHitos_Pry_Objetivos'
CREATE INDEX [IX_FK_Pry_EvaluacionHitos_Pry_Objetivos]
ON [dbo].[Pry_EvaluacionHitos]
    ([IdResultado]);
GO

-- Creating foreign key on [IdActividad] in table 'Pry_EvaluacionHitos'
ALTER TABLE [dbo].[Pry_EvaluacionHitos]
ADD CONSTRAINT [FK_Pry_EvaluacionHitos_Pry_Objetivos1]
    FOREIGN KEY ([IdActividad])
    REFERENCES [dbo].[Pry_Objetivos]
        ([IdObjetivo])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Pry_EvaluacionHitos_Pry_Objetivos1'
CREATE INDEX [IX_FK_Pry_EvaluacionHitos_Pry_Objetivos1]
ON [dbo].[Pry_EvaluacionHitos]
    ([IdActividad]);
GO

-- Creating foreign key on [IdProyecto] in table 'Pry_EvaluacionHitos'
ALTER TABLE [dbo].[Pry_EvaluacionHitos]
ADD CONSTRAINT [FK_Pry_EvaluacionHitos_Pry_Proyectos]
    FOREIGN KEY ([IdProyecto])
    REFERENCES [dbo].[Pry_Proyectos]
        ([IdProyecto])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [IdHito] in table 'PRY_EVALUACIONINDICADORESPERIODO'
ALTER TABLE [dbo].[PRY_EVALUACIONINDICADORESPERIODO]
ADD CONSTRAINT [FK_PRY_EVALUACIONINDICADORESPERIODO_Pry_Indicadores]
    FOREIGN KEY ([IdHito])
    REFERENCES [dbo].[Pry_Indicadores]
        ([IdIndicador])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_PRY_EVALUACIONINDICADORESPERIODO_Pry_Indicadores'
CREATE INDEX [IX_FK_PRY_EVALUACIONINDICADORESPERIODO_Pry_Indicadores]
ON [dbo].[PRY_EVALUACIONINDICADORESPERIODO]
    ([IdHito]);
GO

-- Creating foreign key on [IdResultado] in table 'PRY_EVALUACIONINDICADORESPERIODO'
ALTER TABLE [dbo].[PRY_EVALUACIONINDICADORESPERIODO]
ADD CONSTRAINT [FK_PRY_EVALUACIONINDICADORESPERIODO_Pry_Objetivos]
    FOREIGN KEY ([IdResultado])
    REFERENCES [dbo].[Pry_Objetivos]
        ([IdObjetivo])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_PRY_EVALUACIONINDICADORESPERIODO_Pry_Objetivos'
CREATE INDEX [IX_FK_PRY_EVALUACIONINDICADORESPERIODO_Pry_Objetivos]
ON [dbo].[PRY_EVALUACIONINDICADORESPERIODO]
    ([IdResultado]);
GO

-- Creating foreign key on [IdProyecto] in table 'PRY_EVALUACIONINDICADORESPERIODO'
ALTER TABLE [dbo].[PRY_EVALUACIONINDICADORESPERIODO]
ADD CONSTRAINT [FK_PRY_EVALUACIONINDICADORESPERIODO_Pry_Proyectos]
    FOREIGN KEY ([IdProyecto])
    REFERENCES [dbo].[Pry_Proyectos]
        ([IdProyecto])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [IDPROYECTO] in table 'PRY_EVALUACIONPROYECTOPERIODO'
ALTER TABLE [dbo].[PRY_EVALUACIONPROYECTOPERIODO]
ADD CONSTRAINT [FK_PRY_EVALUACIONPROYECTOPERIODO_Pry_Proyectos]
    FOREIGN KEY ([IDPROYECTO])
    REFERENCES [dbo].[Pry_Proyectos]
        ([IdProyecto])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_PRY_EVALUACIONPROYECTOPERIODO_Pry_Proyectos'
CREATE INDEX [IX_FK_PRY_EVALUACIONPROYECTOPERIODO_Pry_Proyectos]
ON [dbo].[PRY_EVALUACIONPROYECTOPERIODO]
    ([IDPROYECTO]);
GO

-- Creating foreign key on [IdSubTipo] in table 'Pry_Indicadores'
ALTER TABLE [dbo].[Pry_Indicadores]
ADD CONSTRAINT [FK_Pry_Indicadores_Pry_IndicadoresTipos]
    FOREIGN KEY ([IdSubTipo])
    REFERENCES [dbo].[Pry_IndicadoresTipos]
        ([IdTipo])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Pry_Indicadores_Pry_IndicadoresTipos'
CREATE INDEX [IX_FK_Pry_Indicadores_Pry_IndicadoresTipos]
ON [dbo].[Pry_Indicadores]
    ([IdSubTipo]);
GO

-- Creating foreign key on [IdTipo] in table 'Pry_Indicadores'
ALTER TABLE [dbo].[Pry_Indicadores]
ADD CONSTRAINT [FK_Pry_Indicadores_Pry_IndicadoresTipos1]
    FOREIGN KEY ([IdTipo])
    REFERENCES [dbo].[Pry_IndicadoresTipos]
        ([IdTipo])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Pry_Indicadores_Pry_IndicadoresTipos1'
CREATE INDEX [IX_FK_Pry_Indicadores_Pry_IndicadoresTipos1]
ON [dbo].[Pry_Indicadores]
    ([IdTipo]);
GO

-- Creating foreign key on [IdIndicadorProyecto] in table 'Pry_IndicadoresProyecto_Programa'
ALTER TABLE [dbo].[Pry_IndicadoresProyecto_Programa]
ADD CONSTRAINT [FK_Pry_IndicadoresProyecto_Programa_Pry_Indicadores]
    FOREIGN KEY ([IdIndicadorProyecto])
    REFERENCES [dbo].[Pry_Indicadores]
        ([IdIndicador])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [IdIndicador] in table 'Pry_IndicadoresVerificadores'
ALTER TABLE [dbo].[Pry_IndicadoresVerificadores]
ADD CONSTRAINT [FK_Pry_IndicadoresVerificadores_Pry_Indicadores]
    FOREIGN KEY ([IdIndicador])
    REFERENCES [dbo].[Pry_Indicadores]
        ([IdIndicador])
    ON DELETE CASCADE ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Pry_IndicadoresVerificadores_Pry_Indicadores'
CREATE INDEX [IX_FK_Pry_IndicadoresVerificadores_Pry_Indicadores]
ON [dbo].[Pry_IndicadoresVerificadores]
    ([IdIndicador]);
GO

-- Creating foreign key on [IdIndicador] in table 'Pry_Informes_Indicador'
ALTER TABLE [dbo].[Pry_Informes_Indicador]
ADD CONSTRAINT [FK_Pry_Informes_Indicador_Pry_Indicadores]
    FOREIGN KEY ([IdIndicador])
    REFERENCES [dbo].[Pry_Indicadores]
        ([IdIndicador])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Pry_Informes_Indicador_Pry_Indicadores'
CREATE INDEX [IX_FK_Pry_Informes_Indicador_Pry_Indicadores]
ON [dbo].[Pry_Informes_Indicador]
    ([IdIndicador]);
GO

-- Creating foreign key on [IDINDICADOR] in table 'PRY_INFORMESICAINDICADORES'
ALTER TABLE [dbo].[PRY_INFORMESICAINDICADORES]
ADD CONSTRAINT [FK_PRY_INFORMESICAINDICADORES_Pry_Indicadores]
    FOREIGN KEY ([IDINDICADOR])
    REFERENCES [dbo].[Pry_Indicadores]
        ([IdIndicador])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_PRY_INFORMESICAINDICADORES_Pry_Indicadores'
CREATE INDEX [IX_FK_PRY_INFORMESICAINDICADORES_Pry_Indicadores]
ON [dbo].[PRY_INFORMESICAINDICADORES]
    ([IDINDICADOR]);
GO

-- Creating foreign key on [IdInforme] in table 'Pry_Informes_Donantes'
ALTER TABLE [dbo].[Pry_Informes_Donantes]
ADD CONSTRAINT [FK_Pry_Informes_Donantes_Pry_Informes]
    FOREIGN KEY ([IdInforme])
    REFERENCES [dbo].[Pry_Informes]
        ([IdInforme])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [IdInforme] in table 'Pry_Informes_Encuestas'
ALTER TABLE [dbo].[Pry_Informes_Encuestas]
ADD CONSTRAINT [FK_Pry_Informes_Encuestas_Pry_Informes]
    FOREIGN KEY ([IdInforme])
    REFERENCES [dbo].[Pry_Informes]
        ([IdInforme])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [IdInforme] in table 'Pry_Informes_Indicador'
ALTER TABLE [dbo].[Pry_Informes_Indicador]
ADD CONSTRAINT [FK_Pry_Informes_Indicador_Pry_Informes]
    FOREIGN KEY ([IdInforme])
    REFERENCES [dbo].[Pry_Informes]
        ([IdInforme])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [IdInforme] in table 'Pry_Informes_Presupuestos'
ALTER TABLE [dbo].[Pry_Informes_Presupuestos]
ADD CONSTRAINT [FK_Pry_Informes_Presupuestos_Pry_Informes]
    FOREIGN KEY ([IdInforme])
    REFERENCES [dbo].[Pry_Informes]
        ([IdInforme])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [IdEstado] in table 'Pry_Informes'
ALTER TABLE [dbo].[Pry_Informes]
ADD CONSTRAINT [FK_Pry_Informes_Pry_InformesEstados]
    FOREIGN KEY ([IdEstado])
    REFERENCES [dbo].[Pry_InformesEstados]
        ([IdEstado])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Pry_Informes_Pry_InformesEstados'
CREATE INDEX [IX_FK_Pry_Informes_Pry_InformesEstados]
ON [dbo].[Pry_Informes]
    ([IdEstado]);
GO

-- Creating foreign key on [EvaluacionProposito] in table 'Pry_Informes'
ALTER TABLE [dbo].[Pry_Informes]
ADD CONSTRAINT [FK_Pry_Informes_Pry_NivelAceptacion]
    FOREIGN KEY ([EvaluacionProposito])
    REFERENCES [dbo].[Pry_NivelAceptacion]
        ([IdNivelAceptacion])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Pry_Informes_Pry_NivelAceptacion'
CREATE INDEX [IX_FK_Pry_Informes_Pry_NivelAceptacion]
ON [dbo].[Pry_Informes]
    ([EvaluacionProposito]);
GO

-- Creating foreign key on [EvaluacionComponentes] in table 'Pry_Informes'
ALTER TABLE [dbo].[Pry_Informes]
ADD CONSTRAINT [FK_Pry_Informes_Pry_NivelAceptacion1]
    FOREIGN KEY ([EvaluacionComponentes])
    REFERENCES [dbo].[Pry_NivelAceptacion]
        ([IdNivelAceptacion])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Pry_Informes_Pry_NivelAceptacion1'
CREATE INDEX [IX_FK_Pry_Informes_Pry_NivelAceptacion1]
ON [dbo].[Pry_Informes]
    ([EvaluacionComponentes]);
GO

-- Creating foreign key on [IdProyecto] in table 'Pry_Informes'
ALTER TABLE [dbo].[Pry_Informes]
ADD CONSTRAINT [FK_Pry_Informes_Pry_Proyectos]
    FOREIGN KEY ([IdProyecto])
    REFERENCES [dbo].[Pry_Proyectos]
        ([IdProyecto])
    ON DELETE CASCADE ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Pry_Informes_Pry_Proyectos'
CREATE INDEX [IX_FK_Pry_Informes_Pry_Proyectos]
ON [dbo].[Pry_Informes]
    ([IdProyecto]);
GO

-- Creating foreign key on [IdInforme] in table 'Pry_Informes_Supuestos'
ALTER TABLE [dbo].[Pry_Informes_Supuestos]
ADD CONSTRAINT [FK_Pry_Informes_Supuestos_Pry_Informes]
    FOREIGN KEY ([IdInforme])
    REFERENCES [dbo].[Pry_Informes]
        ([IdInforme])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Evaluacion] in table 'Pry_Informes_Indicador'
ALTER TABLE [dbo].[Pry_Informes_Indicador]
ADD CONSTRAINT [FK_Pry_Informes_Indicador_Pry_NivelAceptacion]
    FOREIGN KEY ([Evaluacion])
    REFERENCES [dbo].[Pry_NivelAceptacion]
        ([IdNivelAceptacion])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Pry_Informes_Indicador_Pry_NivelAceptacion'
CREATE INDEX [IX_FK_Pry_Informes_Indicador_Pry_NivelAceptacion]
ON [dbo].[Pry_Informes_Indicador]
    ([Evaluacion]);
GO

-- Creating foreign key on [Evaluacion] in table 'Pry_Informes_Presupuestos'
ALTER TABLE [dbo].[Pry_Informes_Presupuestos]
ADD CONSTRAINT [FK_Pry_Informes_Presupuestos_Pry_NivelAceptacion]
    FOREIGN KEY ([Evaluacion])
    REFERENCES [dbo].[Pry_NivelAceptacion]
        ([IdNivelAceptacion])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Pry_Informes_Presupuestos_Pry_NivelAceptacion'
CREATE INDEX [IX_FK_Pry_Informes_Presupuestos_Pry_NivelAceptacion]
ON [dbo].[Pry_Informes_Presupuestos]
    ([Evaluacion]);
GO

-- Creating foreign key on [IdPresupuesto] in table 'Pry_Informes_Presupuestos'
ALTER TABLE [dbo].[Pry_Informes_Presupuestos]
ADD CONSTRAINT [FK_Pry_Informes_Presupuestos_Pry_Presupuesto]
    FOREIGN KEY ([IdPresupuesto])
    REFERENCES [dbo].[Pry_Presupuesto]
        ([IdPresupuesto])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Pry_Informes_Presupuestos_Pry_Presupuesto'
CREATE INDEX [IX_FK_Pry_Informes_Presupuestos_Pry_Presupuesto]
ON [dbo].[Pry_Informes_Presupuestos]
    ([IdPresupuesto]);
GO

-- Creating foreign key on [IdSupuesto] in table 'Pry_Informes_Supuestos'
ALTER TABLE [dbo].[Pry_Informes_Supuestos]
ADD CONSTRAINT [FK_Pry_Informes_Supuestos_Pry_Supuestos]
    FOREIGN KEY ([IdSupuesto])
    REFERENCES [dbo].[Pry_Supuestos]
        ([IdSupuesto])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Pry_Informes_Supuestos_Pry_Supuestos'
CREATE INDEX [IX_FK_Pry_Informes_Supuestos_Pry_Supuestos]
ON [dbo].[Pry_Informes_Supuestos]
    ([IdSupuesto]);
GO

-- Creating foreign key on [IDESTADO] in table 'PRY_INFORMESICA'
ALTER TABLE [dbo].[PRY_INFORMESICA]
ADD CONSTRAINT [FK_PRY_INFORMESICA_PRY_INFORMESICAESTADOS]
    FOREIGN KEY ([IDESTADO])
    REFERENCES [dbo].[PRY_INFORMESICAESTADOS]
        ([IDESTADO])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_PRY_INFORMESICA_PRY_INFORMESICAESTADOS'
CREATE INDEX [IX_FK_PRY_INFORMESICA_PRY_INFORMESICAESTADOS]
ON [dbo].[PRY_INFORMESICA]
    ([IDESTADO]);
GO

-- Creating foreign key on [IDTIPO] in table 'PRY_INFORMESICA'
ALTER TABLE [dbo].[PRY_INFORMESICA]
ADD CONSTRAINT [FK_PRY_INFORMESICA_PRY_INFORMESICATIPOS]
    FOREIGN KEY ([IDTIPO])
    REFERENCES [dbo].[PRY_INFORMESICATIPOS]
        ([IDTIPO])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_PRY_INFORMESICA_PRY_INFORMESICATIPOS'
CREATE INDEX [IX_FK_PRY_INFORMESICA_PRY_INFORMESICATIPOS]
ON [dbo].[PRY_INFORMESICA]
    ([IDTIPO]);
GO

-- Creating foreign key on [IDPROYECTO] in table 'PRY_INFORMESICA'
ALTER TABLE [dbo].[PRY_INFORMESICA]
ADD CONSTRAINT [FK_PRY_INFORMESICA_Pry_Proyectos]
    FOREIGN KEY ([IDPROYECTO])
    REFERENCES [dbo].[Pry_Proyectos]
        ([IdProyecto])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_PRY_INFORMESICA_Pry_Proyectos'
CREATE INDEX [IX_FK_PRY_INFORMESICA_Pry_Proyectos]
ON [dbo].[PRY_INFORMESICA]
    ([IDPROYECTO]);
GO

-- Creating foreign key on [IDINFORME] in table 'PRY_INFORMESICADETALLE'
ALTER TABLE [dbo].[PRY_INFORMESICADETALLE]
ADD CONSTRAINT [FK_PRY_INFORMESICADETALLE_PRY_INFORMESICA]
    FOREIGN KEY ([IDINFORME])
    REFERENCES [dbo].[PRY_INFORMESICA]
        ([IDINFORME])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_PRY_INFORMESICADETALLE_PRY_INFORMESICA'
CREATE INDEX [IX_FK_PRY_INFORMESICADETALLE_PRY_INFORMESICA]
ON [dbo].[PRY_INFORMESICADETALLE]
    ([IDINFORME]);
GO

-- Creating foreign key on [IDINFORME] in table 'PRY_INFORMESICADOCUMENTOS'
ALTER TABLE [dbo].[PRY_INFORMESICADOCUMENTOS]
ADD CONSTRAINT [FK_PRY_INFORMESICADOCUMENTOS_PRY_INFORMESICA]
    FOREIGN KEY ([IDINFORME])
    REFERENCES [dbo].[PRY_INFORMESICA]
        ([IDINFORME])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_PRY_INFORMESICADOCUMENTOS_PRY_INFORMESICA'
CREATE INDEX [IX_FK_PRY_INFORMESICADOCUMENTOS_PRY_INFORMESICA]
ON [dbo].[PRY_INFORMESICADOCUMENTOS]
    ([IDINFORME]);
GO

-- Creating foreign key on [IDINFORME] in table 'PRY_INFORMESICAINDICADORES'
ALTER TABLE [dbo].[PRY_INFORMESICAINDICADORES]
ADD CONSTRAINT [FK_PRY_INFORMESICAINDICADORES_PRY_INFORMESICA]
    FOREIGN KEY ([IDINFORME])
    REFERENCES [dbo].[PRY_INFORMESICA]
        ([IDINFORME])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [IDINFORME] in table 'PRY_INFORMESICAOBJETIVOS'
ALTER TABLE [dbo].[PRY_INFORMESICAOBJETIVOS]
ADD CONSTRAINT [FK_PRY_INFORMESICAOBJETIVOS_PRY_INFORMESICA]
    FOREIGN KEY ([IDINFORME])
    REFERENCES [dbo].[PRY_INFORMESICA]
        ([IDINFORME])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [IDOBJETIVO] in table 'PRY_INFORMESICAOBJETIVOS'
ALTER TABLE [dbo].[PRY_INFORMESICAOBJETIVOS]
ADD CONSTRAINT [FK_PRY_INFORMESICAOBJETIVOS_Pry_Objetivos]
    FOREIGN KEY ([IDOBJETIVO])
    REFERENCES [dbo].[Pry_Objetivos]
        ([IdObjetivo])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_PRY_INFORMESICAOBJETIVOS_Pry_Objetivos'
CREATE INDEX [IX_FK_PRY_INFORMESICAOBJETIVOS_Pry_Objetivos]
ON [dbo].[PRY_INFORMESICAOBJETIVOS]
    ([IDOBJETIVO]);
GO

-- Creating foreign key on [IDPARTIDAGASTO] in table 'Pry_Movimientos'
ALTER TABLE [dbo].[Pry_Movimientos]
ADD CONSTRAINT [FK_Pry_Movimientos_PRY_PARTIDAGASTOS]
    FOREIGN KEY ([IDPARTIDAGASTO])
    REFERENCES [dbo].[PRY_PARTIDAGASTOS]
        ([IDPARTIDAGASTO])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Pry_Movimientos_PRY_PARTIDAGASTOS'
CREATE INDEX [IX_FK_Pry_Movimientos_PRY_PARTIDAGASTOS]
ON [dbo].[Pry_Movimientos]
    ([IDPARTIDAGASTO]);
GO

-- Creating foreign key on [IdPresupuesto] in table 'Pry_Movimientos'
ALTER TABLE [dbo].[Pry_Movimientos]
ADD CONSTRAINT [FK_Pry_Movimientos_Pry_Presupuesto]
    FOREIGN KEY ([IdPresupuesto])
    REFERENCES [dbo].[Pry_Presupuesto]
        ([IdPresupuesto])
    ON DELETE CASCADE ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Pry_Movimientos_Pry_Presupuesto'
CREATE INDEX [IX_FK_Pry_Movimientos_Pry_Presupuesto]
ON [dbo].[Pry_Movimientos]
    ([IdPresupuesto]);
GO

-- Creating foreign key on [IdNivelAceptacion] in table 'Pry_Proyectos_NivelAceptacion'
ALTER TABLE [dbo].[Pry_Proyectos_NivelAceptacion]
ADD CONSTRAINT [FK_Pry_Proyectos_NivelAceptacion_Pry_NivelAceptacion]
    FOREIGN KEY ([IdNivelAceptacion])
    REFERENCES [dbo].[Pry_NivelAceptacion]
        ([IdNivelAceptacion])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Pry_Proyectos_NivelAceptacion_Pry_NivelAceptacion'
CREATE INDEX [IX_FK_Pry_Proyectos_NivelAceptacion_Pry_NivelAceptacion]
ON [dbo].[Pry_Proyectos_NivelAceptacion]
    ([IdNivelAceptacion]);
GO

-- Creating foreign key on [IdObjetivoClase] in table 'Pry_Objetivos'
ALTER TABLE [dbo].[Pry_Objetivos]
ADD CONSTRAINT [FK_Pry_Objetivos_Pry_ObjetivosClase]
    FOREIGN KEY ([IdObjetivoClase])
    REFERENCES [dbo].[Pry_ObjetivosClase]
        ([IdObjetivoClase])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Pry_Objetivos_Pry_ObjetivosClase'
CREATE INDEX [IX_FK_Pry_Objetivos_Pry_ObjetivosClase]
ON [dbo].[Pry_Objetivos]
    ([IdObjetivoClase]);
GO

-- Creating foreign key on [IdProposito] in table 'Pry_Proyectos'
ALTER TABLE [dbo].[Pry_Proyectos]
ADD CONSTRAINT [FK_Pry_Proyectos_Pry_Objetivos]
    FOREIGN KEY ([IdProposito])
    REFERENCES [dbo].[Pry_Objetivos]
        ([IdObjetivo])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Pry_Proyectos_Pry_Objetivos'
CREATE INDEX [IX_FK_Pry_Proyectos_Pry_Objetivos]
ON [dbo].[Pry_Proyectos]
    ([IdProposito]);
GO

-- Creating foreign key on [IdObjetivo] in table 'Pry_Recursos'
ALTER TABLE [dbo].[Pry_Recursos]
ADD CONSTRAINT [FK_Pry_Recursos_Pry_Objetivos]
    FOREIGN KEY ([IdObjetivo])
    REFERENCES [dbo].[Pry_Objetivos]
        ([IdObjetivo])
    ON DELETE CASCADE ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Pry_Recursos_Pry_Objetivos'
CREATE INDEX [IX_FK_Pry_Recursos_Pry_Objetivos]
ON [dbo].[Pry_Recursos]
    ([IdObjetivo]);
GO

-- Creating foreign key on [IdObjetivo] in table 'Pry_Supuestos'
ALTER TABLE [dbo].[Pry_Supuestos]
ADD CONSTRAINT [FK_Pry_Supuestos_Pry_Objetivos]
    FOREIGN KEY ([IdObjetivo])
    REFERENCES [dbo].[Pry_Objetivos]
        ([IdObjetivo])
    ON DELETE CASCADE ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Pry_Supuestos_Pry_Objetivos'
CREATE INDEX [IX_FK_Pry_Supuestos_Pry_Objetivos]
ON [dbo].[Pry_Supuestos]
    ([IdObjetivo]);
GO

-- Creating foreign key on [IDPARTIDAGASTO] in table 'Pry_Recursos'
ALTER TABLE [dbo].[Pry_Recursos]
ADD CONSTRAINT [FK_Pry_Recursos_PRY_PARTIDAGASTOS]
    FOREIGN KEY ([IDPARTIDAGASTO])
    REFERENCES [dbo].[PRY_PARTIDAGASTOS]
        ([IDPARTIDAGASTO])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Pry_Recursos_PRY_PARTIDAGASTOS'
CREATE INDEX [IX_FK_Pry_Recursos_PRY_PARTIDAGASTOS]
ON [dbo].[Pry_Recursos]
    ([IDPARTIDAGASTO]);
GO

-- Creating foreign key on [IdTipoPresupuesto] in table 'Pry_Presupuesto'
ALTER TABLE [dbo].[Pry_Presupuesto]
ADD CONSTRAINT [FK_Pry_Presupuesto_Pry_PresupuestoTipo]
    FOREIGN KEY ([IdTipoPresupuesto])
    REFERENCES [dbo].[Pry_PresupuestoTipo]
        ([IdTipo])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Pry_Presupuesto_Pry_PresupuestoTipo'
CREATE INDEX [IX_FK_Pry_Presupuesto_Pry_PresupuestoTipo]
ON [dbo].[Pry_Presupuesto]
    ([IdTipoPresupuesto]);
GO

-- Creating foreign key on [IdProyecto] in table 'Pry_Presupuesto'
ALTER TABLE [dbo].[Pry_Presupuesto]
ADD CONSTRAINT [FK_Pry_Presupuesto_Pry_Proyectos]
    FOREIGN KEY ([IdProyecto])
    REFERENCES [dbo].[Pry_Proyectos]
        ([IdProyecto])
    ON DELETE CASCADE ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Pry_Presupuesto_Pry_Proyectos'
CREATE INDEX [IX_FK_Pry_Presupuesto_Pry_Proyectos]
ON [dbo].[Pry_Presupuesto]
    ([IdProyecto]);
GO

-- Creating foreign key on [IdProyecto] in table 'Pry_Proyectos_Donantes'
ALTER TABLE [dbo].[Pry_Proyectos_Donantes]
ADD CONSTRAINT [FK_Pro_Proyectos_Donantes_Pro_Proyectos]
    FOREIGN KEY ([IdProyecto])
    REFERENCES [dbo].[Pry_Proyectos]
        ([IdProyecto])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [IdProyecto] in table 'Pry_Proyectos_NivelAceptacion'
ALTER TABLE [dbo].[Pry_Proyectos_NivelAceptacion]
ADD CONSTRAINT [FK_Pry_Proyectos_NivelAceptacion_Pry_Proyectos]
    FOREIGN KEY ([IdProyecto])
    REFERENCES [dbo].[Pry_Proyectos]
        ([IdProyecto])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [IDPROYECTOPADRE] in table 'Pry_Proyectos'
ALTER TABLE [dbo].[Pry_Proyectos]
ADD CONSTRAINT [FK_Pry_Proyectos_Pry_Proyectos]
    FOREIGN KEY ([IDPROYECTOPADRE])
    REFERENCES [dbo].[Pry_Proyectos]
        ([IdProyecto])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Pry_Proyectos_Pry_Proyectos'
CREATE INDEX [IX_FK_Pry_Proyectos_Pry_Proyectos]
ON [dbo].[Pry_Proyectos]
    ([IDPROYECTOPADRE]);
GO

-- Creating foreign key on [IdEstado] in table 'Pry_Proyectos'
ALTER TABLE [dbo].[Pry_Proyectos]
ADD CONSTRAINT [FK_Pry_Proyectos_Pry_ProyectosEstados]
    FOREIGN KEY ([IdEstado])
    REFERENCES [dbo].[Pry_ProyectosEstados]
        ([IdEstado])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Pry_Proyectos_Pry_ProyectosEstados'
CREATE INDEX [IX_FK_Pry_Proyectos_Pry_ProyectosEstados]
ON [dbo].[Pry_Proyectos]
    ([IdEstado]);
GO

-- Creating foreign key on [IdTipo] in table 'Pry_Proyectos'
ALTER TABLE [dbo].[Pry_Proyectos]
ADD CONSTRAINT [FK_Pry_Proyectos_Pry_ProyectosTipos]
    FOREIGN KEY ([IdTipo])
    REFERENCES [dbo].[Pry_ProyectosTipos]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Pry_Proyectos_Pry_ProyectosTipos'
CREATE INDEX [IX_FK_Pry_Proyectos_Pry_ProyectosTipos]
ON [dbo].[Pry_Proyectos]
    ([IdTipo]);
GO

-- Creating foreign key on [CustomerId] in table 'Pry_Proyectos'
ALTER TABLE [dbo].[Pry_Proyectos]
ADD CONSTRAINT [FK_Pry_Proyectos_Sys_Clientes]
    FOREIGN KEY ([CustomerId])
    REFERENCES [dbo].[Sys_Clientes]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Pry_Proyectos_Sys_Clientes'
CREATE INDEX [IX_FK_Pry_Proyectos_Sys_Clientes]
ON [dbo].[Pry_Proyectos]
    ([CustomerId]);
GO

-- Creating foreign key on [IdUsuarioEvaluador] in table 'Pry_Proyectos'
ALTER TABLE [dbo].[Pry_Proyectos]
ADD CONSTRAINT [FK_Pry_Proyectos_Sys_Usuarios]
    FOREIGN KEY ([IdUsuarioEvaluador])
    REFERENCES [dbo].[Sys_Usuarios]
        ([IdUsuario])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Pry_Proyectos_Sys_Usuarios'
CREATE INDEX [IX_FK_Pry_Proyectos_Sys_Usuarios]
ON [dbo].[Pry_Proyectos]
    ([IdUsuarioEvaluador]);
GO

-- Creating foreign key on [IdUsuarioResponsable] in table 'Pry_Proyectos'
ALTER TABLE [dbo].[Pry_Proyectos]
ADD CONSTRAINT [FK_Pry_Proyectos_Sys_Usuarios1]
    FOREIGN KEY ([IdUsuarioResponsable])
    REFERENCES [dbo].[Sys_Usuarios]
        ([IdUsuario])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Pry_Proyectos_Sys_Usuarios1'
CREATE INDEX [IX_FK_Pry_Proyectos_Sys_Usuarios1]
ON [dbo].[Pry_Proyectos]
    ([IdUsuarioResponsable]);
GO

-- Creating foreign key on [IdUsuarioDigitador] in table 'Pry_Proyectos'
ALTER TABLE [dbo].[Pry_Proyectos]
ADD CONSTRAINT [FK_Pry_Proyectos_Sys_Usuarios2]
    FOREIGN KEY ([IdUsuarioDigitador])
    REFERENCES [dbo].[Sys_Usuarios]
        ([IdUsuario])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Pry_Proyectos_Sys_Usuarios2'
CREATE INDEX [IX_FK_Pry_Proyectos_Sys_Usuarios2]
ON [dbo].[Pry_Proyectos]
    ([IdUsuarioDigitador]);
GO

-- Creating foreign key on [IdProyecto] in table 'Tar_Listas'
ALTER TABLE [dbo].[Tar_Listas]
ADD CONSTRAINT [FK_Tar_Listas_Pry_Proyectos]
    FOREIGN KEY ([IdProyecto])
    REFERENCES [dbo].[Pry_Proyectos]
        ([IdProyecto])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Tar_Listas_Pry_Proyectos'
CREATE INDEX [IX_FK_Tar_Listas_Pry_Proyectos]
ON [dbo].[Tar_Listas]
    ([IdProyecto]);
GO

-- Creating foreign key on [IdUsuarioResponsable] in table 'Pry_Proyectos_Donantes'
ALTER TABLE [dbo].[Pry_Proyectos_Donantes]
ADD CONSTRAINT [FK_Pry_Proyectos_Donantes_Sys_Usuarios]
    FOREIGN KEY ([IdUsuarioResponsable])
    REFERENCES [dbo].[Sys_Usuarios]
        ([IdUsuario])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Pry_Proyectos_Donantes_Sys_Usuarios'
CREATE INDEX [IX_FK_Pry_Proyectos_Donantes_Sys_Usuarios]
ON [dbo].[Pry_Proyectos_Donantes]
    ([IdUsuarioResponsable]);
GO

-- Creating foreign key on [IdUsuarioCreacion] in table 'Tar_Listas'
ALTER TABLE [dbo].[Tar_Listas]
ADD CONSTRAINT [FK_Tar_Listas_Sys_Usuarios]
    FOREIGN KEY ([IdUsuarioCreacion])
    REFERENCES [dbo].[Sys_Usuarios]
        ([IdUsuario])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Tar_Listas_Sys_Usuarios'
CREATE INDEX [IX_FK_Tar_Listas_Sys_Usuarios]
ON [dbo].[Tar_Listas]
    ([IdUsuarioCreacion]);
GO

-- Creating foreign key on [IdUsuarioModificacion] in table 'Tar_Listas'
ALTER TABLE [dbo].[Tar_Listas]
ADD CONSTRAINT [FK_Tar_Listas_Sys_Usuarios1]
    FOREIGN KEY ([IdUsuarioModificacion])
    REFERENCES [dbo].[Sys_Usuarios]
        ([IdUsuario])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Tar_Listas_Sys_Usuarios1'
CREATE INDEX [IX_FK_Tar_Listas_Sys_Usuarios1]
ON [dbo].[Tar_Listas]
    ([IdUsuarioModificacion]);
GO

-- Creating foreign key on [IdResponsable] in table 'Tar_Tareas'
ALTER TABLE [dbo].[Tar_Tareas]
ADD CONSTRAINT [FK_Tar_Tareas_Sys_Usuarios]
    FOREIGN KEY ([IdResponsable])
    REFERENCES [dbo].[Sys_Usuarios]
        ([IdUsuario])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Tar_Tareas_Sys_Usuarios'
CREATE INDEX [IX_FK_Tar_Tareas_Sys_Usuarios]
ON [dbo].[Tar_Tareas]
    ([IdResponsable]);
GO

-- Creating foreign key on [IdUsuarioCreacion] in table 'Tar_Tareas'
ALTER TABLE [dbo].[Tar_Tareas]
ADD CONSTRAINT [FK_Tar_Tareas_Sys_Usuarios1]
    FOREIGN KEY ([IdUsuarioCreacion])
    REFERENCES [dbo].[Sys_Usuarios]
        ([IdUsuario])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Tar_Tareas_Sys_Usuarios1'
CREATE INDEX [IX_FK_Tar_Tareas_Sys_Usuarios1]
ON [dbo].[Tar_Tareas]
    ([IdUsuarioCreacion]);
GO

-- Creating foreign key on [IdUsuarioModificacion] in table 'Tar_Tareas'
ALTER TABLE [dbo].[Tar_Tareas]
ADD CONSTRAINT [FK_Tar_Tareas_Sys_Usuarios2]
    FOREIGN KEY ([IdUsuarioModificacion])
    REFERENCES [dbo].[Sys_Usuarios]
        ([IdUsuario])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Tar_Tareas_Sys_Usuarios2'
CREATE INDEX [IX_FK_Tar_Tareas_Sys_Usuarios2]
ON [dbo].[Tar_Tareas]
    ([IdUsuarioModificacion]);
GO

-- Creating foreign key on [IdUsuarioCompletado] in table 'Tar_Tareas'
ALTER TABLE [dbo].[Tar_Tareas]
ADD CONSTRAINT [FK_Tar_Tareas_Sys_Usuarios3]
    FOREIGN KEY ([IdUsuarioCompletado])
    REFERENCES [dbo].[Sys_Usuarios]
        ([IdUsuario])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Tar_Tareas_Sys_Usuarios3'
CREATE INDEX [IX_FK_Tar_Tareas_Sys_Usuarios3]
ON [dbo].[Tar_Tareas]
    ([IdUsuarioCompletado]);
GO

-- Creating foreign key on [IdLista] in table 'Tar_Tareas'
ALTER TABLE [dbo].[Tar_Tareas]
ADD CONSTRAINT [FK_Tar_Tareas_Tar_Listas]
    FOREIGN KEY ([IdLista])
    REFERENCES [dbo].[Tar_Listas]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Tar_Tareas_Tar_Listas'
CREATE INDEX [IX_FK_Tar_Tareas_Tar_Listas]
ON [dbo].[Tar_Tareas]
    ([IdLista]);
GO

-- Creating foreign key on [Doc_Categorias_IdCategoria] in table 'Doc_Clientes_Categorias'
ALTER TABLE [dbo].[Doc_Clientes_Categorias]
ADD CONSTRAINT [FK_Doc_Clientes_Categorias_Doc_Categorias]
    FOREIGN KEY ([Doc_Categorias_IdCategoria])
    REFERENCES [dbo].[Doc_Categorias]
        ([IdCategoria])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Sys_Clientes_Id] in table 'Doc_Clientes_Categorias'
ALTER TABLE [dbo].[Doc_Clientes_Categorias]
ADD CONSTRAINT [FK_Doc_Clientes_Categorias_Sys_Clientes]
    FOREIGN KEY ([Sys_Clientes_Id])
    REFERENCES [dbo].[Sys_Clientes]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Doc_Clientes_Categorias_Sys_Clientes'
CREATE INDEX [IX_FK_Doc_Clientes_Categorias_Sys_Clientes]
ON [dbo].[Doc_Clientes_Categorias]
    ([Sys_Clientes_Id]);
GO

-- Creating foreign key on [Org_Donantes_IdDonante] in table 'Org_Donantes_Empresas'
ALTER TABLE [dbo].[Org_Donantes_Empresas]
ADD CONSTRAINT [FK_Org_Donantes_Empresas_Org_Donantes]
    FOREIGN KEY ([Org_Donantes_IdDonante])
    REFERENCES [dbo].[Org_Donantes]
        ([IdDonante])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Org_Empresas_IdEmpresa] in table 'Org_Donantes_Empresas'
ALTER TABLE [dbo].[Org_Donantes_Empresas]
ADD CONSTRAINT [FK_Org_Donantes_Empresas_Org_Empresas]
    FOREIGN KEY ([Org_Empresas_IdEmpresa])
    REFERENCES [dbo].[Org_Empresas]
        ([IdEmpresa])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Org_Donantes_Empresas_Org_Empresas'
CREATE INDEX [IX_FK_Org_Donantes_Empresas_Org_Empresas]
ON [dbo].[Org_Donantes_Empresas]
    ([Org_Empresas_IdEmpresa]);
GO

-- Creating foreign key on [Pry_Indicadores_IdIndicador] in table 'Pry_Indicadores_Variables'
ALTER TABLE [dbo].[Pry_Indicadores_Variables]
ADD CONSTRAINT [FK_Pry_Indicadores_Variables_Pry_Indicadores]
    FOREIGN KEY ([Pry_Indicadores_IdIndicador])
    REFERENCES [dbo].[Pry_Indicadores]
        ([IdIndicador])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Pry_Variables_IdVariable] in table 'Pry_Indicadores_Variables'
ALTER TABLE [dbo].[Pry_Indicadores_Variables]
ADD CONSTRAINT [FK_Pry_Indicadores_Variables_Pry_Variables]
    FOREIGN KEY ([Pry_Variables_IdVariable])
    REFERENCES [dbo].[Pry_Variables]
        ([IdVariable])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Pry_Indicadores_Variables_Pry_Variables'
CREATE INDEX [IX_FK_Pry_Indicadores_Variables_Pry_Variables]
ON [dbo].[Pry_Indicadores_Variables]
    ([Pry_Variables_IdVariable]);
GO

-- Creating foreign key on [Org_Donantes_IdDonante] in table 'Sys_Usuarios_Donantes'
ALTER TABLE [dbo].[Sys_Usuarios_Donantes]
ADD CONSTRAINT [FK_Sys_Usuarios_Donantes_Org_Donantes]
    FOREIGN KEY ([Org_Donantes_IdDonante])
    REFERENCES [dbo].[Org_Donantes]
        ([IdDonante])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Sys_Usuarios_IdUsuario] in table 'Sys_Usuarios_Donantes'
ALTER TABLE [dbo].[Sys_Usuarios_Donantes]
ADD CONSTRAINT [FK_Sys_Usuarios_Donantes_Sys_Usuarios]
    FOREIGN KEY ([Sys_Usuarios_IdUsuario])
    REFERENCES [dbo].[Sys_Usuarios]
        ([IdUsuario])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Sys_Usuarios_Donantes_Sys_Usuarios'
CREATE INDEX [IX_FK_Sys_Usuarios_Donantes_Sys_Usuarios]
ON [dbo].[Sys_Usuarios_Donantes]
    ([Sys_Usuarios_IdUsuario]);
GO

-- Creating foreign key on [Org_Empresas_IdEmpresa] in table 'Sys_Usuarios_Empresas'
ALTER TABLE [dbo].[Sys_Usuarios_Empresas]
ADD CONSTRAINT [FK_Sys_Usuarios_Empresas_Org_Empresas]
    FOREIGN KEY ([Org_Empresas_IdEmpresa])
    REFERENCES [dbo].[Org_Empresas]
        ([IdEmpresa])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Sys_Usuarios_IdUsuario] in table 'Sys_Usuarios_Empresas'
ALTER TABLE [dbo].[Sys_Usuarios_Empresas]
ADD CONSTRAINT [FK_Sys_Usuarios_Empresas_Sys_Usuarios]
    FOREIGN KEY ([Sys_Usuarios_IdUsuario])
    REFERENCES [dbo].[Sys_Usuarios]
        ([IdUsuario])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Sys_Usuarios_Empresas_Sys_Usuarios'
CREATE INDEX [IX_FK_Sys_Usuarios_Empresas_Sys_Usuarios]
ON [dbo].[Sys_Usuarios_Empresas]
    ([Sys_Usuarios_IdUsuario]);
GO

-- Creating foreign key on [IdBeneficiario] in table 'Pry_CapacitacionBeneficiario'
ALTER TABLE [dbo].[Pry_CapacitacionBeneficiario]
ADD CONSTRAINT [FK_KEY_PRY_BENEFICIARIO_CAPACITACIONES]
    FOREIGN KEY ([IdBeneficiario])
    REFERENCES [dbo].[Pry_Beneficiarios]
        ([IdBeneficiario])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_KEY_PRY_BENEFICIARIO_CAPACITACIONES'
CREATE INDEX [IX_FK_KEY_PRY_BENEFICIARIO_CAPACITACIONES]
ON [dbo].[Pry_CapacitacionBeneficiario]
    ([IdBeneficiario]);
GO

-- Creating foreign key on [IdObjetivo] in table 'Pry_Beneficiarios'
ALTER TABLE [dbo].[Pry_Beneficiarios]
ADD CONSTRAINT [FK_KEY_PRY_BENEFICIARIOS]
    FOREIGN KEY ([IdObjetivo])
    REFERENCES [dbo].[Pry_Objetivos]
        ([IdObjetivo])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_KEY_PRY_BENEFICIARIOS'
CREATE INDEX [IX_FK_KEY_PRY_BENEFICIARIOS]
ON [dbo].[Pry_Beneficiarios]
    ([IdObjetivo]);
GO

-- Creating foreign key on [IdBeneficiario] in table 'Pry_ProductividadBeneficiario'
ALTER TABLE [dbo].[Pry_ProductividadBeneficiario]
ADD CONSTRAINT [FK_KEY_PRY_PRODUCTIVIDAD_BENEFICIARIO]
    FOREIGN KEY ([IdBeneficiario])
    REFERENCES [dbo].[Pry_Beneficiarios]
        ([IdBeneficiario])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_KEY_PRY_PRODUCTIVIDAD_BENEFICIARIO'
CREATE INDEX [IX_FK_KEY_PRY_PRODUCTIVIDAD_BENEFICIARIO]
ON [dbo].[Pry_ProductividadBeneficiario]
    ([IdBeneficiario]);
GO

-- Creating foreign key on [IdCapacitacion] in table 'Pry_CapacitacionBeneficiario'
ALTER TABLE [dbo].[Pry_CapacitacionBeneficiario]
ADD CONSTRAINT [FK_KEY_PRY_CAPACITACIONES_BENEFICIARIO]
    FOREIGN KEY ([IdCapacitacion])
    REFERENCES [dbo].[Pry_Capacitaciones]
        ([IdCapacitacion])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_KEY_PRY_CAPACITACIONES_BENEFICIARIO'
CREATE INDEX [IX_FK_KEY_PRY_CAPACITACIONES_BENEFICIARIO]
ON [dbo].[Pry_CapacitacionBeneficiario]
    ([IdCapacitacion]);
GO

-- Creating foreign key on [IdFacilitador] in table 'Pry_Capacitaciones'
ALTER TABLE [dbo].[Pry_Capacitaciones]
ADD CONSTRAINT [FK_KEY_PRY_CAPACITACIONES]
    FOREIGN KEY ([IdFacilitador])
    REFERENCES [dbo].[Pry_Facilitadores]
        ([IdFacilitador])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_KEY_PRY_CAPACITACIONES'
CREATE INDEX [IX_FK_KEY_PRY_CAPACITACIONES]
ON [dbo].[Pry_Capacitaciones]
    ([IdFacilitador]);
GO

-- Creating foreign key on [IdPeriodo] in table 'Pry_DatosMuestras'
ALTER TABLE [dbo].[Pry_DatosMuestras]
ADD CONSTRAINT [FK_Pry_DatosMuestras_PRY_PERIODOS]
    FOREIGN KEY ([IdPeriodo])
    REFERENCES [dbo].[PRY_PERIODOSPROYECTOS]
        ([IdPeriodo])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Pry_DatosMuestras_PRY_PERIODOS'
CREATE INDEX [IX_FK_Pry_DatosMuestras_PRY_PERIODOS]
ON [dbo].[Pry_DatosMuestras]
    ([IdPeriodo]);
GO

-- Creating foreign key on [IdPeriodo] in table 'Pry_EvaluacionHitos'
ALTER TABLE [dbo].[Pry_EvaluacionHitos]
ADD CONSTRAINT [FK_Pry_EvaluacionHitos_PRY_PERIODOS]
    FOREIGN KEY ([IdPeriodo])
    REFERENCES [dbo].[PRY_PERIODOSPROYECTOS]
        ([IdPeriodo])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Pry_EvaluacionHitos_PRY_PERIODOS'
CREATE INDEX [IX_FK_Pry_EvaluacionHitos_PRY_PERIODOS]
ON [dbo].[Pry_EvaluacionHitos]
    ([IdPeriodo]);
GO

-- Creating foreign key on [IdPeriodo] in table 'PRY_EVALUACIONINDICADORESPERIODO'
ALTER TABLE [dbo].[PRY_EVALUACIONINDICADORESPERIODO]
ADD CONSTRAINT [FK_PRY_EVALUACIONINDICADORESPERIODO_PRY_PERIODOS]
    FOREIGN KEY ([IdPeriodo])
    REFERENCES [dbo].[PRY_PERIODOSPROYECTOS]
        ([IdPeriodo])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_PRY_EVALUACIONINDICADORESPERIODO_PRY_PERIODOS'
CREATE INDEX [IX_FK_PRY_EVALUACIONINDICADORESPERIODO_PRY_PERIODOS]
ON [dbo].[PRY_EVALUACIONINDICADORESPERIODO]
    ([IdPeriodo]);
GO

-- Creating foreign key on [IDPERIODO] in table 'PRY_EVALUACIONPROYECTOPERIODO'
ALTER TABLE [dbo].[PRY_EVALUACIONPROYECTOPERIODO]
ADD CONSTRAINT [FK_PRY_EVALUACIONPROYECTOPERIODO_PRY_PERIODOS]
    FOREIGN KEY ([IDPERIODO])
    REFERENCES [dbo].[PRY_PERIODOSPROYECTOS]
        ([IdPeriodo])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [PERIODOINICIAL] in table 'PRY_INFORMESICA'
ALTER TABLE [dbo].[PRY_INFORMESICA]
ADD CONSTRAINT [FK_PRY_INFORMESICA_PRY_PERIODOS]
    FOREIGN KEY ([PERIODOINICIAL])
    REFERENCES [dbo].[PRY_PERIODOSPROYECTOS]
        ([IdPeriodo])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_PRY_INFORMESICA_PRY_PERIODOS'
CREATE INDEX [IX_FK_PRY_INFORMESICA_PRY_PERIODOS]
ON [dbo].[PRY_INFORMESICA]
    ([PERIODOINICIAL]);
GO

-- Creating foreign key on [PERIODOFINAL] in table 'PRY_INFORMESICA'
ALTER TABLE [dbo].[PRY_INFORMESICA]
ADD CONSTRAINT [FK_PRY_INFORMESICA_PRY_PERIODOS1]
    FOREIGN KEY ([PERIODOFINAL])
    REFERENCES [dbo].[PRY_PERIODOSPROYECTOS]
        ([IdPeriodo])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_PRY_INFORMESICA_PRY_PERIODOS1'
CREATE INDEX [IX_FK_PRY_INFORMESICA_PRY_PERIODOS1]
ON [dbo].[PRY_INFORMESICA]
    ([PERIODOFINAL]);
GO

-- Creating foreign key on [IdPeriodo] in table 'Pry_Movimientos'
ALTER TABLE [dbo].[Pry_Movimientos]
ADD CONSTRAINT [FK_Pry_Movimientos_PRY_PERIODOS]
    FOREIGN KEY ([IdPeriodo])
    REFERENCES [dbo].[PRY_PERIODOSPROYECTOS]
        ([IdPeriodo])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Pry_Movimientos_PRY_PERIODOS'
CREATE INDEX [IX_FK_Pry_Movimientos_PRY_PERIODOS]
ON [dbo].[Pry_Movimientos]
    ([IdPeriodo]);
GO

-- Creating foreign key on [IdProyecto] in table 'PRY_PERIODOSPROYECTOS'
ALTER TABLE [dbo].[PRY_PERIODOSPROYECTOS]
ADD CONSTRAINT [FK_PRY_PERIODOSPROYECTOS_Pry_Proyectos]
    FOREIGN KEY ([IdProyecto])
    REFERENCES [dbo].[Pry_Proyectos]
        ([IdProyecto])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_PRY_PERIODOSPROYECTOS_Pry_Proyectos'
CREATE INDEX [IX_FK_PRY_PERIODOSPROYECTOS_Pry_Proyectos]
ON [dbo].[PRY_PERIODOSPROYECTOS]
    ([IdProyecto]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------