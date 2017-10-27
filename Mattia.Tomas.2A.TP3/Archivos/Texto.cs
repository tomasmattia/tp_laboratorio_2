using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;
using System.IO;

namespace Archivos
{
    public class Texto:IArchivos<string>
    {
        public bool Guardar(string archivo, string datos)
        {
            try
            {
                StreamWriter escritor = new StreamWriter(archivo, true);
                escritor.WriteLine(datos);
                escritor.Close();
                return true;
            }
            catch (Exception e)
            {
                throw new ArchivosException(e);
            }

        }

        public bool Leer(string archivo, out string datos)
        {
            if(File.Exists(archivo))
            {
                StreamReader lector = new StreamReader(archivo);
                datos = lector.ReadToEnd();
                lector.Close();
                return true;
            }
            throw new ArchivosException(new Exception());
        }
    }
}
