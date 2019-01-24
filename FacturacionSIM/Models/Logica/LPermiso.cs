
using System;
using System.Collections.Generic;
using System.Linq;
using FacturacionSIM.Models.Entidades;

namespace FacturacionSIM.Models.Logica
{
	public class LPermiso
	{
		/// <summary>
		/// Obtiene un listado de todos los permisos
		/// </summary>
		/// <returns></returns>
		public static List<Permiso> ObtenerPermisos()
		{
			try
			{
				var listaPermisos = new List<Permiso>();
				using (var BD = new Data.USER.FACTURAUSEREntities())
				{
					var permisos = (from p in BD.Permisoes select p).ToList();

					foreach (var permiso in permisos.Where(x => x.PermisoPadreID == null))
					{
						listaPermisos.Add(DataToEntidad(permiso));
					}
					return listaPermisos;
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}


		public static Permiso DataToEntidad(Data.USER.Permiso d, bool conHijos = true)
		{
			var hijos = new List<Permiso>();
			if (conHijos)
			{
				if (d.Permiso1.Count > 0)
				{
					foreach (var h in d.Permiso1)
					{
						hijos.Add(DataToEntidad(h));
					}
				}
			}
			return new Permiso()
			{
				Checked = false,
				Hijos = hijos,
				ID = d.PermisoID,
				MenuID = d.PermisoMenuID,
				Menu = d.PermisoMenuID.HasValue ? LMenu.DataToEntidad(d.Menu) : null,
				Nombre = d.PermisoNombre,
				Orden = d.PermisoOrden,
				PadreID = d.PermisoPadreID
			};
		}
	}
}
