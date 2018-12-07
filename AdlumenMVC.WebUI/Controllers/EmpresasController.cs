using AdlumenMVC.Bussiness.AbstractRepositories;
using AdlumenMVC.Models.Model;
using AdlumenMVC.WebUI.Infrastructure;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AdlumenMVC.WebUI.Controllers
{
    public class EmpresasController : ApiController
    {
        private IEmpresasRepository Context;

        public EmpresasController(IEmpresasRepository _Context)
        {
            Context = _Context;
        }

        [ClaimsAuthorization(Modulo = "Empresa", ActionName = "Lectura")]
        // GET api/empresas
        public IEnumerable<Object> GetAll()
        {
            return Context.GetEmpresasActivas();
        }

        [ClaimsAuthorization(Modulo = "Empresa", ActionName = "Lectura")]
        // GET api/empresas/5
        public Object Get(int id)
        {
            return Context.GetEmpresaById(id);
        }

        [ClaimsAuthorization(Modulo = "Empresa", ActionName = "Escritura")]
        // POST api/empresas
        public void Post(JObject value)
        {
            dynamic data = value;
            string action = (string)data.action;
            string userName = null;
            Sys_Usuarios user = null;
            if (data.userId != null)
            {
                user = Context.GetUsuarioById((int)data.userId);
                userName = user.UserName;
            }

            switch (action)
            {
                case "addGeneral":
                    {
                        var category = new Doc_Categorias()
                        {
                            IdPadre = 0,
                            Nombre = "Publicaciones",
                            Descripcion = "Publicaciones",
                            Estado = true,
                            FechaCreacion = DateTime.Now,
                            IdTipo = 1,
                            UsuarioCreacion = userName
                        };
                        Context.addCategoria(category);

                        Org_Empresas empresa = new Org_Empresas()
                        {
                            Nombre = (string)data.nombre,
                            Ubicacion = (string)data.ubicacion,
                            IdIdentificacionTipo = (int)data.idIdentificacionTipo,
                            Identificacion = (string)data.identificacion,
                            IdPais = (int)data.idPais,
                            URL = data.url != null ? (string)data.url : null,
                            Telefono = data.telefono != null ? (string)data.telefono : null,
                            Logo = (string)data.logo,
                            FechaCreacion = DateTime.Now,
                            UsuarioCreacion = userName,
                            IdCategoriaDocumentos = category.IdCategoria
                        };

                        using (var db = new Adlumen2SocEntities())
                        {
                            var syscliente = db.Sys_Clientes.FirstOrDefault();
                            if (syscliente != null)
                            {
                                empresa.IdCliente = syscliente.Id;
                            }
                        }
                        Context.addEmpresa(empresa);

                        category.IdEmpresa = empresa.IdEmpresa;
                        if (user != null && user.idEmpresa == 0)
                        {
                            user.idEmpresa = empresa.IdEmpresa;
                            Context.addUsuarioEmpresa(empresa, user);
                        }
                        //TODO: agregar transaccion
                        Context.modifyCategoria();
                    }
                    break;
                case "modifyGeneral":
                    {
                        Org_Empresas empresa = Context.GetEmpresa((int)data.idEmpresa);
                        bool modified = false;
                        if (!empresa.Nombre.Equals((string)data.nombre))
                        {
                            empresa.Nombre = (string)data.nombre;
                            modified = true;
                        }
                        if (!empresa.Ubicacion.Equals((string)data.ubicacion))
                        {
                            empresa.Ubicacion = (string)data.ubicacion;
                            modified = true;
                        }
                        if (empresa.URL != (string)data.url)
                        {
                            empresa.URL = (string)data.url;
                            modified = true;
                        }
                        if (empresa.Telefono != (string)data.telefono)
                        {
                            empresa.Telefono = (string)data.telefono;
                            modified = true;
                        }
                        if (empresa.Identificacion != (string)data.identificacion)
                        {
                            empresa.Identificacion = (string)data.identificacion;
                            modified = true;
                        }
                        if (empresa.IdIdentificacionTipo != (int)data.idIdentificacionTipo)
                        {
                            empresa.IdIdentificacionTipo = (int)data.idIdentificacionTipo;
                            modified = true;
                        }
                        if (empresa.IdPais != (int)data.idPais)
                        {
                            empresa.IdPais = (int)data.idPais;
                            modified = true;
                        }
                        if (empresa.Latitude != (double?)data.latitude)
                        {
                            empresa.Latitude = (double?)data.latitude;
                            modified = true;
                        }
                        if (empresa.Longitude != (double?)data.longitude)
                        {
                            empresa.Longitude = (double?)data.longitude;
                            modified = true;
                        }
                        if (empresa.Logo != (string)data.logo)
                        {
                            empresa.Logo = (string)data.logo;
                            modified = true;
                        }
                        if (modified)
                        {
                            empresa.FechaModificacion = DateTime.Now;
                            empresa.UsuarioModificacion = userName;
                        }
                        Context.modifyEmpresa();
                    }
                    break;
                case "deleteEmpresa":
                    {
                        Org_Empresas empresa = Context.GetEmpresa((int)data.idEmpresa);
                        Context.deleteEmpresa(empresa);
                    }
                    break;
                case "addArea":
                    {
                        Org_Areas area = new Org_Areas()
                        {
                            IdPadre = (int)data.idPadre,
                            IdEmpresa = (int)data.idEmpresa,
                            IdResponsable = data.idResponsable != null ? (int)data.idResponsable : (int?)null,
                            Nombre = (string)data.nombre,
                            Objetivo = (string)data.objetivo,
                            Descripcion = (string)data.descripcion,
                            Eliminado = false,
                            FechaCreacion = DateTime.Now,
                            UsuarioCreacion = userName
                        };
                        Context.addArea(area);
                    }
                    break;
                case "modifyArea":
                    {
                        Org_Areas area = Context.GetAreaById((int)data.idArea);
                        bool modified = false;
                        if (area.IdPadre != (int)data.idPadre)
                        {
                            area.IdPadre = (int)data.idPadre;
                            modified = true;
                        }
                        if (data.idResponsable != null && area.IdResponsable != (int)data.idResponsable)
                        {
                            area.IdResponsable = (int)data.idResponsable;
                            modified = true;
                        }
                        if (!area.Nombre.Equals((string)data.nombre))
                        {
                            area.Nombre = (string)data.nombre;
                            modified = true;
                        }
                        if (!area.Objetivo.Equals((string)data.objetivo))
                        {
                            area.Objetivo = (string)data.objetivo;
                            modified = true;
                        }
                        if (area.Descripcion != (string)data.descripcion)
                        {
                            area.Descripcion = (string)data.descripcion;
                            modified = true;
                        }
                        if (area.Eliminado != (bool)data.eliminado)
                        {
                            area.Eliminado = (bool)data.eliminado;
                            modified = true;
                        }
                        if (modified)
                        {
                            area.FechaModificacion = DateTime.Now;
                            area.UsuarioModificacion = userName;
                        }
                        Context.modifyArea();
                    }
                    break;
                case "deleteArea":
                    {
                        Org_Areas area = Context.GetAreaById((int)data.idArea);
                        area.Eliminado = true;
                        area.FechaModificacion = DateTime.Now;
                        area.UsuarioModificacion = userName;
                        Context.modifyArea();
                    }
                    break;
                case "addCargo":
                    {
                        Org_Cargos cargo = new Org_Cargos()
                        {
                            IdPadre = (int)data.idPadre,
                            IdArea = (int)data.idArea,
                            Nombre = (string)data.nombre,
                            Descripcion = (string)data.descripcion,
                            Perfil = (string)data.perfil,
                            Eliminado = false,
                            FechaCreacion = DateTime.Now,
                            UsuarioCreacion = userName
                        };
                        Context.addCargo(cargo);
                    }
                    break;
                case "modifyCargo":
                    {
                        Org_Cargos cargo = Context.GetCargoById((int)data.idCargo);
                        bool modified = false;
                        if (cargo.IdPadre != (int)data.idPadre)
                        {
                            cargo.IdPadre = (int)data.idPadre;
                            modified = true;
                        }
                        if (cargo.IdArea != (int)data.idArea)
                        {
                            cargo.IdArea = (int)data.idArea;
                            modified = true;
                        }
                        if (!cargo.Nombre.Equals((string)data.nombre))
                        {
                            cargo.Nombre = (string)data.nombre;
                            modified = true;
                        }
                        if (cargo.Descripcion != (string)data.descripcion)
                        {
                            cargo.Descripcion = (string)data.descripcion;
                            modified = true;
                        }
                        if (cargo.Perfil != (string)data.perfil)
                        {
                            cargo.Perfil = (string)data.perfil;
                            modified = true;
                        }
                        if (cargo.Eliminado != (bool)data.eliminado)
                        {
                            cargo.Eliminado = (bool)data.eliminado;
                            modified = true;
                        }
                        if (modified)
                        {
                            cargo.FechaModificacion = DateTime.Now;
                            cargo.UsuarioModificacion = userName;
                        }
                        Context.modifyCargo();
                    }
                    break;
                case "deleteCargo":
                    {
                        var db = new Adlumen2SocEntities();
                        int positionId = (int)data.idCargo;

                        void DeletePosition(Org_Cargos position)
                        {
                            position.Eliminado = true;
                            position.FechaModificacion = DateTime.UtcNow;
                            position.UsuarioModificacion = userName;

                            var employees = db.Org_Empleados.Where(x => x.IdCargo == position.IdCargo);
                            foreach (var employee in employees)
                            {
                                employee.Retirado = true;
                                employee.FechaModificacion = DateTime.Now;
                                employee.UsuarioModificacion = userName;
                            }

                            var subpositions = db.Org_Cargos.Where(x => x.IdPadre == position.IdCargo);
                            foreach (var subposition in subpositions)
                            {
                                DeletePosition(subposition);
                            }
                        }

                        using (var tx = db.Database.BeginTransaction())
                        {
                            try
                            {
                                var position = db.Org_Cargos.FirstOrDefault(x => x.IdCargo == positionId);
                                DeletePosition(position);

                                db.SaveChanges();
                                tx.Commit();
                            }
                            catch (Exception)
                            {
                                tx.Rollback();
                                throw;
                            }
                        }

                        //Org_Cargos cargo = Context.GetCargoById((int)data.idCargo);
                        //cargo.Eliminado = true;
                        //cargo.FechaModificacion = DateTime.Now;
                        //cargo.UsuarioModificacion = userName;
                        //Context.modifyCargo();
                        
                        //var employees = Context.GetEmployeesByCargo(cargo.IdCargo);
                        //foreach (var employee in employees)
                        //{
                        //    employee.Retirado = true;
                        //    employee.FechaModificacion = DateTime.Now;
                        //    employee.UsuarioModificacion = userName;
                        //    Context.modifyEmpleado();
                        //}
                    }
                    break;
                case "addEmpleado":
                    {
                        Org_Empleados empleado = new Org_Empleados()
                        {
                            IdCargo = (int)data.titleId,
                            Nombre = (string)data.name,
                            Apellido = (string)data.lastName,
                            Correo = (string)data.email,
                            IdIdentificacionTipo = (int)data.idType,
                            Identificacion = (string)data.idNumber,
                            Observaciones = (string)data.observations,
                            Competencias = (string)data.competencies,
                            HojaVida = (string)data.cv,
                            Foto = (string)data.foto,
                            FechaCreacion = DateTime.Now,
                            UsuarioCreacion = userName
                        };
                        Context.addEmpleado(empleado);
                    }
                    break;
                case "modifyEmpleado":
                    {
                        Org_Empleados empleado = Context.GetEmpleadoById((int)data.employeeId);
                        bool modified = false;
                        if (empleado.IdCargo != (int)data.titleId)
                        {
                            empleado.IdCargo = (int)data.titleId;
                            modified = true;
                        }
                        if (!empleado.Nombre.Equals((string)data.name))
                        {
                            empleado.Nombre = (string)data.name;
                            modified = true;
                        }
                        if (!empleado.Apellido.Equals((string)data.lastName))
                        {
                            empleado.Apellido = (string)data.lastName;
                            modified = true;
                        }
                        if (empleado.Correo != (string)data.email)
                        {
                            empleado.Correo = (string)data.email;
                            modified = true;
                        }
                        if (empleado.IdIdentificacionTipo != (int)data.idType)
                        {
                            empleado.IdIdentificacionTipo = (int)data.idType;
                            modified = true;
                        }
                        if (empleado.Identificacion != (string)data.idNumber)
                        {
                            empleado.Identificacion = (string)data.idNumber;
                            modified = true;
                        }
                        if (empleado.Retirado != (bool)data.retired)
                        {
                            empleado.Retirado = (bool)data.retired;
                            modified = true;
                        }
                        if (empleado.Observaciones != (string)data.observations)
                        {
                            empleado.Observaciones = (string)data.observations;
                            modified = true;
                        }
                        if (empleado.Competencias != (string)data.competencies)
                        {
                            empleado.Competencias = (string)data.competencies;
                            modified = true;
                        }
                        if (empleado.HojaVida != (string)data.cv)
                        {
                            empleado.HojaVida = (string)data.cv;
                            modified = true;
                        }
                        var foto = (string)data.foto;
                        if (string.IsNullOrWhiteSpace(foto))
                        {
                            foto = (string)data.picture;
                        }
                        if (empleado.Foto != foto)
                        {
                            empleado.Foto = (string)data.foto;
                            modified = true;
                        }
                        if (modified)
                        {
                            empleado.FechaModificacion = DateTime.Now;
                            empleado.UsuarioModificacion = userName;
                        }
                        Context.modifyEmpleado();
                    }
                    break;
                case "deleteEmpleado":
                    {
                        Org_Empleados empleado = Context.GetEmpleadoById((int)data.employeeId);
                        empleado.Retirado = true;
                        empleado.FechaModificacion = DateTime.Now;
                        empleado.UsuarioModificacion = userName;
                        Context.modifyEmpleado();
                    }
                    break;
                case "addProveedor":
                    {
                        Org_Proveedores proveedor = new Org_Proveedores()
                        {
                            IdEmpresa = (int)data.idCompany,
                            Nombre = (string)data.name,
                            IdIdentificacionTipo = (int)data.idIdentification,
                            Identificacion = (string)data.identification,
                            Telefono = (string)data.phone,
                            Ubicacion = (string)data.location,
                            Correo = (string)data.mail,
                            HojaVida = (string)data.cv,
                            FechaCreacion = DateTime.Now,
                            UsuarioCreacion = userName
                        };
                        Context.addProveedor(proveedor);
                    }
                    break;
                case "modifyProveedor":
                    {
                        Org_Proveedores proveedor = Context.GetProveedorById((int)data.id);
                        bool modified = false;
                        if (proveedor.IdEmpresa != (int)data.idCompany)
                        {
                            proveedor.IdEmpresa = (int)data.idCompany;
                            modified = true;
                        }
                        if (!proveedor.Nombre.Equals((string)data.name))
                        {
                            proveedor.Nombre = (string)data.name;
                            modified = true;
                        }
                        if (proveedor.IdIdentificacionTipo != (int)data.idIdentification)
                        {
                            proveedor.IdIdentificacionTipo = (int)data.idIdentification;
                            modified = true;
                        }
                        if (proveedor.Identificacion != (string)data.identification)
                        {
                            proveedor.Identificacion = (string)data.identification;
                            modified = true;
                        }
                        if (proveedor.Telefono != (string)data.phone)
                        {
                            proveedor.Telefono = (string)data.phone;
                            modified = true;
                        }
                        if (proveedor.Ubicacion != (string)data.location)
                        {
                            proveedor.Ubicacion = (string)data.location;
                            modified = true;
                        }
                        if (proveedor.Correo != (string)data.mail)
                        {
                            proveedor.Correo = (string)data.mail;
                            modified = true;
                        }
                        if (proveedor.HojaVida != (string)data.cv)
                        {
                            proveedor.HojaVida = (string)data.cv;
                            modified = true;
                        }
                        if (proveedor.Eliminado != (bool)data.deleted)
                        {
                            proveedor.Eliminado = (bool)data.deleted;
                            modified = true;
                        }
                        if (modified)
                        {
                            proveedor.FechaModificacion = DateTime.Now;
                            proveedor.UsuarioModificacion = userName;
                        }
                        Context.modifyProveedor();
                    }
                    break;
                case "deleteProveedor":
                    {
                        Org_Proveedores proveedor = Context.GetProveedorById((int)data.id);
                        proveedor.Eliminado = true;
                        proveedor.FechaModificacion = DateTime.Now;
                        proveedor.UsuarioModificacion = userName;
                        Context.modifyProveedor();
                    }
                    break;
                case "modifyUsuarios":
                    {
                        Org_Empresas empresa = Context.GetEmpresa((int)data.idEmpresa);
                        Context.deleteUsuariosEmpresa(empresa);

                        JArray usuarios = (JArray)data.usuarios;
                        foreach (JObject oUsuario in usuarios)
                        {
                            dynamic dataUsuario = oUsuario;
                            if ((bool)dataUsuario.include)
                            {
                                Sys_Usuarios usuario = Context.GetUsuarioById((int)dataUsuario.idUsuario);
                                Context.addUsuarioEmpresa(empresa, usuario);
                            }
                        }
                    }
                    break;
                case "addCategoria":
                    {
                        Doc_Categorias categoria = new Doc_Categorias()
                        {
                            IdPadre = (int)data.parentId,
                            Nombre = (string)data.name,
                            Descripcion = (string)data.description,
                            Estado = (bool)data.status,
                            FechaCreacion = DateTime.Now,
                            UsuarioCreacion = userName
                        };
                        Context.addCategoria(categoria);
                    }
                    break;
                case "modifyCategoria":
                    {
                        Doc_Categorias categoria = Context.GetCategoriaById((int)data.id);
                        bool modified = false;
                        if (categoria.IdPadre != (int)data.parentId)
                        {
                            categoria.IdPadre = (int)data.idPadre;
                            modified = true;
                        }
                        if (!categoria.Nombre.Equals((string)data.name))
                        {
                            categoria.Nombre = (string)data.name;
                            modified = true;
                        }
                        if (categoria.Descripcion != (string)data.description)
                        {
                            categoria.Descripcion = (string)data.description;
                            modified = true;
                        }
                        if (categoria.Estado != (bool)data.status)
                        {
                            categoria.Estado = (bool)data.status;
                            modified = true;
                        }
                        if (modified)
                        {
                            categoria.FechaModificacion = DateTime.Now;
                            categoria.UsuarioModificacion = userName;
                        }
                        Context.modifyCategoria();
                    }
                    break;
                case "deleteCategoria":
                    {
                        Doc_Categorias categoria = Context.GetCategoriaById((int)data.id);
                        Context.deleteCategoria(categoria);
                    }
                    break;
                case "addDocumento":
                    {
                        Doc_Documentos documento = new Doc_Documentos()
                        {
                            IdCategoria = (int)data.categoryId,
                            Titulo = (string)data.title,
                            PalabrasClaves = (string)data.keyWords,
                            Resumen = (string)data.resume,
                            Url = (string)data.url,
                            IdTipoArchivo = (int)data.fileTypeId,
                            Roles = (string)data.roles,
                            FechaCreacion = DateTime.Now,
                            UsuarioCreacion = userName
                        };
                        Context.addDocumento(documento);
                        if ((bool)data.generaTarea)
                        {
                            Tar_Tareas tarea = new Tar_Tareas()
                            {
                                IdLista = (int)data.idLista,
                                IdResponsable = (int)data.idResponsable,
                                Descripcion = (string)data.tarea,
                                FechaInicio = DateTime.Now,
                                FechaFin = DateTime.Now,
                                FechaCreacion = DateTime.Now,
                                IdUsuarioCreacion = data.userId != null ? (int)data.userId : (int?)null
                            };
                            Context.addTarea(tarea);
                        }
                    }
                    break;
                case "modifyDocumento":
                    {
                        Doc_Documentos documento = Context.GetDocumentoById((int)data.id);
                        bool modified = false;
                        if (documento.IdCategoria != (int)data.categoryId)
                        {
                            documento.IdCategoria = (int)data.categoryId;
                            modified = true;
                        }
                        if (documento.Titulo != (string)data.title)
                        {
                            documento.Titulo = (string)data.title;
                            modified = true;
                        }
                        if (documento.PalabrasClaves != (string)data.keyWords)
                        {
                            documento.PalabrasClaves = (string)data.keyWords;
                            modified = true;
                        }
                        if (documento.Resumen != (string)data.resume)
                        {
                            documento.Resumen = (string)data.resume;
                            modified = true;
                        }
                        if (documento.Url != (string)data.url)
                        {
                            documento.Url = (string)data.url;
                            modified = true;
                        }
                        if (documento.IdTipoArchivo != (int)data.fileTypeId)
                        {
                            documento.IdTipoArchivo = (int)data.fileTypeId;
                            modified = true;
                        }
                        if (documento.Roles != (string)data.roles)
                        {
                            documento.Roles = (string)data.roles;
                            modified = true;
                        }
                        if (modified)
                        {
                            documento.FechaModificacion = DateTime.Now;
                            documento.UsuarioModificacion = userName;
                        }
                        Context.modifyDocumento();
                        if ((bool)data.generaTarea)
                        {
                            Tar_Tareas tarea = new Tar_Tareas()
                            {
                                IdLista = (int)data.idLista,
                                IdResponsable = (int)data.idResponsable,
                                Descripcion = (string)data.tarea,
                                FechaInicio = DateTime.Now,
                                FechaFin = DateTime.Now,
                                FechaCreacion = DateTime.Now,
                                IdUsuarioCreacion = data.userId != null ? (int)data.userId : (int?)null
                            };
                            Context.addTarea(tarea);
                        }
                    }
                    break;
                case "deleteDocumento":
                    {
                        Doc_Documentos documento = Context.GetDocumentoById((int)data.id);
                        Context.deleteDocumento(documento);
                    }
                    break;
            }
        }

        // PUT api/empresas/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/empresas/5
        public void Delete(int id)
        {
        }
    }
}
