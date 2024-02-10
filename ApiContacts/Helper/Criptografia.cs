using System;
using System.Security.Cryptography;
using System.Text;

namespace ApiContacts.Helper
{
	public static class Criptografia
	{
		public static string GerarHash(this string senha)
		{
			var hash = SHA1.Create();

			var encoding = new ASCIIEncoding();

			var arr = encoding.GetBytes(senha);

			arr = hash.ComputeHash(arr);

			var strHex = new StringBuilder();

			foreach (var item in arr)
			{
				strHex.Append(item.ToString("x2"));
			}

			return strHex.ToString();
        }
	}
}

