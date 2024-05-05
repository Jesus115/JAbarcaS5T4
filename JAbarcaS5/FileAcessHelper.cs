using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JAbarcaS5
{
	public class FileAcessHelper
	{
		public FileAcessHelper()
		{
		}
        public static string GetLocalFilePath(string filname)
        {
            return System.IO.Path.Combine(FileSystem.AppDataDirectory, filname);
        }
    }
	
}

