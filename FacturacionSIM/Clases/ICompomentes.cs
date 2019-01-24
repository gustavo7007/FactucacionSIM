using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Xml;

namespace FacturacionSIM.Clases
{
 	public interface ICompomentes
	{
		string ObtenerModulo11(string pcadena);
		string GetCuf(string pcadena);
		string ObtenerMD5(byte[] archivo);
		string ObtenerSHA2(byte[] archivo);
		XmlDocument GenerateXml(object cabecera, List<object> listDatalle, string asigValue, string certificate);
	}
}
