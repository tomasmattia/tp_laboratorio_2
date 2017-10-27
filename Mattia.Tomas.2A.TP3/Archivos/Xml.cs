using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;
using Excepciones;

namespace Archivos
{
    public class Xml<T>:IArchivos<T>
    {
        public bool Guardar(string archivo, T datos)
        {
            try
            {
                XmlSerializer serializa = new XmlSerializer(typeof(T));
                TextWriter escritor = new StreamWriter(archivo, false);
                serializa.Serialize(escritor, datos);
                return true;
            }
            catch (Exception e)
            {

                throw new ArchivosException(e);
            }

        }
        public bool Leer(string archivo, out T datos)
        {
            try
            {
                XmlSerializer deserializa = new XmlSerializer(typeof(T));
                TextReader lector = new StreamReader(archivo);
                datos = (T)deserializa.Deserialize(lector);
                return true;
            }
            catch (Exception e)
            {
                throw new ArchivosException(e);
            }
        }
    }
}
