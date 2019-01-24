﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FacturacionSIM.Models.Entidades;

namespace FacturacionSIM.Models.Logica
{
	public class LUsuario
	{
		public static Usuario IniciarSesion(string login, string contrasena)
		{
			try
			{
				using (var BD = new FacturacionSIM.Models.Data.USER.FACTURAUSEREntities())
				{

					var usr = BD.Usuarios.FirstOrDefault(x => x.UsuarioLogin == login && x.UsuarioContrasena == contrasena);
					if (usr == null)
					{
						throw new Exception("Usuario y/o contraseña inválida");
					}
					if (usr.UsuarioHabilitado == false)
					{
						throw new Exception("El usuario no tiene acceso al sistema");
					}
					var lr = LUsuario.DataToEntidad(usr, false);
					return lr;
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
		public static bool add(Entidades.Usuario us)
		{
			using (var db = new FacturacionSIM.Models.Data.USER.FACTURAUSEREntities())
			{
				using (var trx = db.Database.BeginTransaction())
				{
					try
					{

						var usu = new Data.USER.Usuario()
						{
							UsuarioApellido1 = us.Apellido1,
							UsuarioApellido2 = us.Apellido2,
							UsuarioContrasena = us.Contrasena,
							UsuarioCambiarContrasena = us.CambiarContrasena,
							UsuarioEmail = us.Email,
							UsuarioEsSuperAdmin = us.EsSuperAdmin,
							UsuarioHabilitado = us.Habilitado,
							UsuarioLogin = us.Login,
							UsuarioNombre = us.Nombre,
							UsuarioTelefono = us.Telefono,
							UsuarioID = Convert.ToInt32(us.ID)
						};

						db.Usuarios.Add(usu);
						
						db.SaveChanges();
						trx.Commit();
						return true;
					}
					catch (Exception)
					{
						trx.Rollback();
						return false;

					}
				}
			}
		}
		public static bool update(Entidades.Usuario us)
		{
			using (var db = new FacturacionSIM.Models.Data.USER.FACTURAUSEREntities())
			{
				try
				{

					var usu = new Data.USER.Usuario()
					{
						UsuarioApellido1 = us.Apellido1,
						UsuarioApellido2 = us.Apellido2,
						UsuarioContrasena = us.Contrasena,
						UsuarioCambiarContrasena = us.CambiarContrasena,
						UsuarioEmail = us.Email,
						UsuarioEsSuperAdmin = us.EsSuperAdmin,
						UsuarioHabilitado = us.Habilitado,
						UsuarioLogin = us.Login,
						UsuarioNombre = us.Nombre,
						UsuarioTelefono = us.Nombre,
						UsuarioID = Convert.ToInt32(us.ID)
					};

					db.Usuarios.Add(usu);
					db.SaveChanges();
					return true;
				}
				catch (Exception)
				{
					return false;

				}

			}
		}
		public static bool delet(Entidades.Usuario us)
		{
			return false;
		}
		public static bool add(Entidades.Usuario us, int perfrilid, int faseid)
		{
			try
			{
				using (var db = new FacturacionSIM.Models.Data.USER.FACTURAUSEREntities())
				{
					using (var trx = db.Database.BeginTransaction())
					{
						var perfil = db.Perfils.Find(perfrilid);
						var usu = new Data.USER.Usuario()
						{
							UsuarioApellido1 = us.Apellido1,
							UsuarioApellido2 = us.Apellido2,
							UsuarioContrasena = us.Contrasena,
							UsuarioCambiarContrasena = us.CambiarContrasena,
							UsuarioEmail = us.Email,
							UsuarioEsSuperAdmin = us.EsSuperAdmin,
							UsuarioHabilitado = us.Habilitado,
							UsuarioLogin = us.Login,
							UsuarioNombre = us.Nombre,
							UsuarioTelefono = us.Nombre,
							UsuarioID = Convert.ToInt32(us.ID),

						};
						usu.Perfils.Add(perfil);
						db.Usuarios.Add(usu);
					
						db.SaveChanges();
						trx.Commit();

						return true;
					}
				}

			}
			catch (Exception ex)
			{

				throw new Exception("Logica add", ex);
			}


		}
		public static List<Entidades.Usuario> toListaUsuario()
		{
			using (var db = new FacturacionSIM.Models.Data.USER.FACTURAUSEREntities())
			{
				var _list = db.Usuarios.ToList();
				List<Entidades.Usuario> _listfinal = new List<Usuario>();
				Entidades.Usuario obj;
				foreach (var item in _list)
				{

					obj = DataToEntidad(item);
					_listfinal.Add(obj);
				}
				return _listfinal;
			}
			;
		}
		public static List<Entidades.Usuario> toListUsuariosParaAsignar()
		{
			using (var db = new FacturacionSIM.Models.Data.USER.FACTURAUSEREntities())
			{
				var _list = db.Usuarios.ToList();
				List<Entidades.Usuario> _listfinal = new List<Usuario>();
				Entidades.Usuario obj;
				foreach (var item in _list)
				{
					obj = DataToEntidad(item);
					//obj.IdFase = db.FaseUsuarios.Where(x => x.Idusuario == obj.ID).Select(x => x.Idfase.Value).FirstOrDefault();
					//obj.NombreFase = GetNombreFase(obj.IdFase);
					_listfinal.Add(obj);
				}
				return _listfinal;
			}
			;
		}

		//private static string GetNombreFase(int idFase)
		//{
		//	try
		//	{
		//		using (var db = new WebGanaderia.Models.Data.USER.GANADERIAUSEREntities())
		//		{
		//			var fase = db.Fases.Where(s => s.ID == idFase).Select(s => s.Descripcion).FirstOrDefault();
		//			return fase;
		//		}
		//	}
		//	catch (Exception ex)
		//	{

		//		throw new Exception("Logica:GetnombreFase", ex);
		//	}
		//}

		public static Entidades.Usuario DataToEntidad(Data.USER.Usuario d, bool Listado = true)
		{
			var perfiles = new List<Entidades.Perfil>();
			var permisos = new List<Entidades.Permiso>();
		

			if (!Listado)
			{
				foreach (var p in d.Perfils)
				{
					perfiles.Add(LPerfil.DataToEntidad(p, false));
				}
				foreach (var p in d.Permisoes)
				{
					permisos.Add(LPermiso.DataToEntidad(p, false));
				}

			}
			else
			{
				foreach (var p in d.Perfils)
				{
					perfiles.Add(LPerfil.DataToEntidad(p, true));
				}
			}
			return new Entidades.Usuario()
			{
				Apellido1 = d.UsuarioApellido1,
				Apellido2 = d.UsuarioApellido2,
				Contrasena = "",
				Email = d.UsuarioEmail,
				EsSuperAdmin = d.UsuarioEsSuperAdmin.Value,
				Habilitado = d.UsuarioHabilitado.Value,
				ID = d.UsuarioID,
				Login = d.UsuarioLogin,
				Nombre = d.UsuarioNombre,
				Perfiles = perfiles,
				Permisos = permisos,
				Telefono = d.UsuarioTelefono,
				CambiarContrasena = d.UsuarioCambiarContrasena.Value


			};
		}
	}
}