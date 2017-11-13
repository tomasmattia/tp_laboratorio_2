using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.ComponentModel;

namespace Hilo
{
    public delegate void ProgresoEvento(int progreso);

    public delegate void FinEvento(string html);

    public class Descargador
    {
        private string html;
        private Uri direccion;

        public event ProgresoEvento ProgresoDelEvento;

        public event FinEvento FinDelEvento;

        public Descargador(Uri direccion)
        {
            html = "";
            this.direccion = direccion;
        }

        public void IniciarDescarga()
        {
            try
            {
                WebClient cliente = new WebClient();
                cliente.DownloadProgressChanged += new DownloadProgressChangedEventHandler(WebClientDownloadProgressChanged);
                cliente.DownloadStringCompleted += new DownloadStringCompletedEventHandler(WebClientDownloadCompleted);

                cliente.DownloadStringAsync(direccion) ;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        private void WebClientDownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            this.ProgresoDelEvento(e.ProgressPercentage);
        }

        private void WebClientDownloadCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            html = e.Result;
            FinDelEvento(html);
        }

        
    }
}
