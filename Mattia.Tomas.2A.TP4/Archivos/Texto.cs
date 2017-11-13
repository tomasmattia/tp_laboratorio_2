using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Archivos
{
    public class Texto : IArchivo<string>
    {
        private string nombreArchivo;

        public Texto(string archivo)
        {
            this.nombreArchivo = archivo;
        }

        public bool Guardar(string texto)
        {
            try
            {
                TextWriter escritor = new StreamWriter(this.nombreArchivo,true);
                escritor.WriteLine(texto);
                escritor.Close();
                return true;
            }
            catch(Exception e)
            {
                throw e;
            }
        }

        public bool Leer(out List<string>listaPaginas)
        {
            try
            {
                listaPaginas = new List<string>();
                StreamReader lector = new StreamReader(nombreArchivo);
                while(!lector.EndOfStream)
                {
                    listaPaginas.Add(lector.ReadLine());
                }
                lector.Close();
                return true;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
