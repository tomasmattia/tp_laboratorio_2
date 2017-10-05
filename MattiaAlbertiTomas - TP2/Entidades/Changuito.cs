using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades_2017
{
    /// <summary>
    /// No podrá tener clases heredadas.
    /// </summary>
    public sealed class Changuito
    {
        List<Producto> _productos;
        int _espacioDisponible;
        public enum ETipo
        {
            Dulce, Leche, Snacks, Todos
        }

        #region "Constructores"
        private Changuito()
        {
            this._productos = new List<Producto>();
        }
        public Changuito(int espacioDisponible) : this()
        {
            this._espacioDisponible = espacioDisponible;
        }
        #endregion

        #region "Sobrecargas"
        /// <summary>
        /// Muestro el changuito y TODOS los Productos que contiene
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return Changuito.Mostrar(this, ETipo.Todos);
        }
        #endregion

        #region "Métodos"

        /// <summary>
        /// Expone los datos del elemento y su lista (incluidas sus herencias)
        /// SOLO del tipo requerido
        /// </summary>
        /// <param name="c">Elemento a exponer</param>
        /// <param name="ETipo">Tipos de ítems de la lista a mostrar</param>
        /// <returns></returns>
        public static string Mostrar(Changuito consesionaria, ETipo tipoDeChanguito)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat("Tenemos {0} lugares ocupados de un total de {1} disponibles", consesionaria._productos.Count, consesionaria._espacioDisponible);
            sb.AppendLine("");
            foreach (Producto productoEnChanguito in consesionaria._productos)
            {
                switch (tipoDeChanguito)
                {
                    case ETipo.Snacks:
                        if(productoEnChanguito is Snacks)
                        {
                            sb.AppendLine(productoEnChanguito.Mostrar());
                        }
                        break;
                    case ETipo.Dulce:
                        if (productoEnChanguito is Dulce)
                        {
                            sb.AppendLine(productoEnChanguito.Mostrar());
                        }
                        break;
                    case ETipo.Leche:
                        if (productoEnChanguito is Leche)
                        {
                            sb.AppendLine(productoEnChanguito.Mostrar());
                        }
                        break;
                    default:
                        sb.AppendLine(productoEnChanguito.Mostrar());
                        break;
                }
                //if (productoEnChanguito is Snacks && (tipoDeChanguito == ETipo.Snacks || tipoDeChanguito == ETipo.Todos))
                //{
                //    sb.AppendLine(productoEnChanguito.Mostrar());
                //}
                //else
                //{
                //    if (productoEnChanguito is Dulce && (tipoDeChanguito == ETipo.Dulce || tipoDeChanguito == ETipo.Todos))
                //    {
                //        sb.AppendLine(productoEnChanguito.Mostrar());
                //    }
                //    else
                //    {
                //        if (productoEnChanguito is Leche && (tipoDeChanguito == ETipo.Leche || tipoDeChanguito == ETipo.Todos))
                //        {
                //            sb.AppendLine(productoEnChanguito.Mostrar());
                //        }
                //    }
                //}
            }

            return sb.ToString() ;
        }
        #endregion

        #region "Operadores"
        /// <summary>
        /// Agregará un elemento a la lista
        /// </summary>
        /// <param name="c">Objeto donde se agregará el elemento</param>
        /// <param name="p">Objeto a agregar</param>
        /// <returns></returns>
        public static Changuito operator +(Changuito changuito, Producto producto)
        {
            if((changuito._productos.Count+1)<= changuito._espacioDisponible)
            {
                foreach (Producto productoEnChanguito in changuito._productos)
                {
                    if (productoEnChanguito == producto)
                    {
                        return changuito;
                    }
                }
                changuito._productos.Add(producto);
            }
            return changuito;
        }
        /// <summary>
        /// Quitará un elemento de la lista
        /// </summary>
        /// <param name="c">Objeto donde se quitará el elemento</param>
        /// <param name="p">Objeto a quitar</param>
        /// <returns></returns>
        public static Changuito operator -(Changuito changuito, Producto producto)
        {
            foreach (Producto productoEnChanguito in changuito._productos)
            {
                if (productoEnChanguito == producto)
                {
                    changuito._productos.Remove(productoEnChanguito);
                    break;
                }
            }

            return changuito;
        }
        #endregion
    }
}
