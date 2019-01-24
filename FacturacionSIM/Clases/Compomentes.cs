using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.IO.Compression;
using System.Text;
using System.Text.RegularExpressions;
using System.Numerics;
using System.Xml;

namespace FacturacionSIM.Clases
{
	public class Compomentes:ICompomentes
	{
		public string calculaDigitoMod11(string dado, int numDig, int limMult, bool x10)
		{
			int mult, soma, i, n, dig;
			if (!x10) numDig = 1;
			for (n = 1; n <= numDig; n++)
			{
				soma = 0;
				mult = 2;
				for (i = dado.Length - 1; i >= 0; i--)
				{
					string dat = dado.Substring(i, 1);
					soma += (mult * Convert.ToInt32(dat));
					if (++mult > limMult) mult = 2;
				}
				if (x10)
				{
					dig = ((soma * 10) % 11) % 10;
				}
				else
				{
					dig = soma % 11;
				}
				if (dig == 10)
				{
					dado += "1";
				}
				if (dig == 11)
				{
					dado += "0";
				}
				if (dig < 10)
				{
					dado += Convert.ToString(dig);
				}
			}
			return dado.Substring(dado.Length - numDig, 1);
		}
		public string ObtenerModulo11(string pcadena)
		{
			string vDigito = calculaDigitoMod11(pcadena, 1, 9, false);
			return vDigito;
		}
		public string GetCuf(string pcadena)
		{
			BigInteger nums = BigInteger.Parse(pcadena);
			BigInteger divisor = 16;
			BigInteger mod = 0;
			BigInteger div = 0;
			Stack<int> pila = new Stack<int>();
			string result = "";
			while (nums > 16)
			{
				mod = nums % divisor;
				div = nums / divisor;
				nums = div;

				pila.Push(int.Parse(mod.ToString()));
			}
			pila.Push(int.Parse(nums.ToString()));
			foreach (var item in pila)
			{
				switch (item)
				{
					case 10:
						result += "A";
						break;
					case 11:
						result += "B";
						break;
					case 12:
						result += "C";
						break;
					case 13:
						result += "D";
						break;
					case 14:
						result += "E";
						break;
					case 15:
						result += "F";
						break;
					default:
						result += Convert.ToString(item);
						break;
				}
			}
			return result;
		}
		public string algoritmoHash(byte[] pArchivo, string algorithm)
		{
			Chilkat.Crypt2 crypt = new Chilkat.Crypt2();
			bool succes = crypt.UnlockComponent("Anything for 30-day trial");
			if (succes != true)
			{
				Console.WriteLine(crypt.LastErrorText);
				return "";
			}
			//  Set the name of the hash algorithm.
			//  Other choices include "sha1", "sha256", "sha384", "sha512", "md2", "md5", and "haval".
			crypt.HashAlgorithm = algorithm;

			//  EncodingMode specifies the encoding of the hash output.
			//  It may be "hex", "url", "base64", or "quoted-printable".
			crypt.EncodingMode = "hex";

			//  Files of any type may be hashed -- it doesn't matter
			//  if the file is binary or text...
			string hashStr;
			hashStr = crypt.HashBytesENC(pArchivo);
			if (crypt.LastMethodSuccess != true)
			{
				Console.WriteLine(crypt.LastErrorText);
				return "";
			}

			Console.WriteLine(hashStr);
			return hashStr;
		}
		public string ObtenerMD5(byte[] archivo)
		{
			string vHash = algoritmoHash(archivo, "MD5");
			return vHash;
		}
		public string ObtenerSHA2(byte[] archivo)
		{
			string vHash2 = algoritmoHash(archivo, "SHA-256");
			return vHash2;
		}
		public void gzipComprimir()
		{
			FileInfo fileToBeGZipped = new FileInfo(@"c:\gzip\logfile.txt");
			FileInfo gzipFileName = new FileInfo(string.Concat(fileToBeGZipped.FullName, ".gz"));

			using (FileStream fileToBeZippedAsStream = fileToBeGZipped.OpenRead())
			{
				using (FileStream gzipTargetAsStream = gzipFileName.Create())
				{
					using (GZipStream gzipStream = new GZipStream(gzipTargetAsStream, CompressionMode.Compress))
					{
						try
						{
							fileToBeZippedAsStream.CopyTo(gzipStream);
						}
						catch (Exception ex)
						{
							Console.WriteLine(ex.Message);
						}
					}
				}
			}
		}
		public XmlDocument GenerateXml(object cabecera, List<object> listDetalle, string asigValue, string certifiacte)
		{
			string xmldetalle = "";// aqui va ir el detalle.

			XmlDocument doc = new XmlDocument();
			doc.LoadXml("<?xml version=\"1.0\" encoding=\"ISO-8859\"?>  \n" +
			"<factura xsi:noNomespaceSchemaLocation=\"facturaElectronica.xsd\"> \n" +
			"<cabecera> \n" +
			"</cabecera> \n" +
			xmldetalle +
			"<Signature> \n" +
			"</Signature> \n" +
			"</factura>");
			return doc;
		}
		public void ComprimirFichero(string Rutafichero)
		{
			using (FileStream ficheroSalida = File.Create(String.Format("{0}.zip", Rutafichero)))
			{
				using (GZipStream zip = new GZipStream(ficheroSalida, CompressionMode.Compress))
				{
					using (FileStream ficheroEntrada = File.OpenRead(Rutafichero))
					{
						ficheroEntrada.CopyTo(zip);
					}
				}
			}
		}
		public void DescomprimirFichero(string ficheraComprimido, string rutaDestino)
		{
			using (FileStream ficheroSalida = File.Create(rutaDestino))
			{
				using (FileStream ficheroEntrada = File.OpenRead(ficheraComprimido))
				{
					using (GZipStream zip = new GZipStream(ficheroEntrada, CompressionMode.Decompress))
					{
						zip.CopyTo(ficheroSalida);
					}
				}
			}
		}
		public void GZipRemoveFileName(string fn)
		{
			// Read in GZIP
			byte[] b = File.ReadAllBytes(fn);

			// See if the file name is set.
			// We don't deal with the file if any other flags are set.
			if (b[3] == 8)
			{
				// Allocate the copy bytes
				List<byte> copy = new List<byte>(b.Length);

				// The flag byte will be set to 0
				b[3] = 0;

				// Add the first ten bytes
				for (int i = 0; i < 10; i++)
				{
					copy.Add(b[i]);
				}
				// Ignore all non-null name characters
				int a = 10;
				while (b[a] != 0)
				{
					a++;
				}
				// Ignore the null
				a++;
				// Add the rest of the file
				for (int i = a; i < b.Length; i++)
				{
					copy.Add(b[i]);
				}
				// Write the new byte array
				File.WriteAllBytes(fn, copy.ToArray());
			}
			else
			{
				// Note that we could not rewrite the file
				Console.WriteLine("Flag invalid: {0}", fn);
			}
		}
	}
}