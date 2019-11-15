using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Text;

namespace IEXSharp.Helper
{
	internal class ExecutorBase
	{
		protected readonly string pk;

		protected ExecutorBase(string pk)
		{
			this.pk = pk;
		}

		protected static void ValidateParams(ref string urlPattern, ref NameValueCollection pathNVC, ref QueryStringBuilder qsb)
		{
			if (string.IsNullOrWhiteSpace(urlPattern))
			{
				throw new ArgumentException("urlPattern cannot be null");
			}
			else if (pathNVC == null)
			{
				throw new ArgumentException("pathNVC cannot be null");
			}
			else if (qsb == null)
			{
				throw new ArgumentException("qsb cannot be null");
			}

			if (pathNVC.Count > 0)
			{
				foreach (string key in pathNVC.Keys)
				{
					if (string.IsNullOrWhiteSpace(key))
					{
						throw new ArgumentException("pathNVC cannot be null");
					}
					else if (string.IsNullOrWhiteSpace(pathNVC[key]))
					{
						throw new ArgumentException($"pathNVC {key} value cannot be null");
					}
					else if (urlPattern.IndexOf($"[{key}]") < 0)
					{
						throw new ArgumentException($"urlPattern doesn't contain key [{key}]");
					}
					else
					{
						urlPattern = urlPattern.Replace($"[{key}]", pathNVC[key]);
					}
				}
			}
		}
	}
}
