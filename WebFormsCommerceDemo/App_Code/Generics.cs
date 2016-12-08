using System.Security.Cryptography;
using System.Text;

namespace WebFormsCommerceDemo
{
	public static class Generics
	{
		public static byte[] MakeHash(string text)
		{
			return (SHA256Managed.Create()).ComputeHash(Encoding.ASCII.GetBytes(text));
		}

		public static bool CompareBinaries(byte[] b1, byte[] b2)
		{
			bool t = false;
			if (b1.Length == b2.Length)
			{
				for (int ix = 0; ix < b1.Length; ix++)
				{
					if (!(b1[ix] == b2[ix])) break;
				}
				t = true;
			}
			return t;
		}

		public static string IfNullString(object text)
		{
			string s = string.Empty;
			try
			{
				s = text.ToString().Trim();
			}
			catch
			{
				s = string.Empty;
			}
			return s;
		}
	}
}

