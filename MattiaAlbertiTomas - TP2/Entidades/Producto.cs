using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades_2017
{
    /// <summary>
    /// La clase Producto será abstracta, evitando que se instancien elementos de este tipo.
    /// </summary>
    public abstract class Producto
    {
        public enum EMarca
        {
            Serenisima, Campagnola, Arcor, Ilolay, Sancor, Pepsico
        }
        EMarca _marca;
        string _codigoDeBarras;
        ConsoleColor _colorPrimarioEmpaque;

        public Producto(string codigoDeBarras, EMarca marca, ConsoleColor color)
        {
            this._marca = marca;
            this._codigoDeBarras = codigoDeBarras;
            this._colorPrimarioEmpaque = color;
        }

        /// <summary>
        /// ReadOnly: Retornará la cantidad de calorias del producto
        /// </summary>
        protected abstract short CantidadCalorias { get; }

        /// <summary>
        /// Publica todos los datos del Producto.
        /// </summary>
        /// <returns>string con todos los datos genericos del producto</returns>
        public virtual string Mostrar()
        {
            return ((string)this);
        }

        public static explicit operator string(Producto p)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("CODIGO DE BARRAS: "+p._codigoDeBarras);
            sb.AppendLine("MARCA          : " + p._marca.ToString());
            sb.AppendLine("COLOR EMPAQUE  : " + p._colorPrimarioEmpaque.ToString());
            sb.AppendLine("---------------------");
            
            return sb.ToString();
        }

        /// <summary>
        /// Dos productos son iguales si comparten el mismo código de barras
        /// </summary>
        /// <param name="p1">un producto</param>
        /// <param name="p2">un producto</param>
        /// <returns>true si comparten el codigo de barras/ false en caso contrario</returns>
        public static bool operator ==(Producto p1, Producto p2)
        {
            return (p1._codigoDeBarras == p2._codigoDeBarras);
        }
        /// <summary>
        /// Dos productos son distintos si su código de barras es distinto
        /// </summary>
        /// <param name="p1">un producto</param>
        /// <param name="p2">un producto</param>
        /// <returns>true si no comparten el codigo de barras/ false en caso contrario</returns>
        public static bool operator !=(Producto p1, Producto p2)
        {
            return !(p1._codigoDeBarras == p2._codigoDeBarras);
        }
    }
}
