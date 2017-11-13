using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Navegador
{
    public partial class frmHistorial : Form
    {
        private List<string> listaPaginas;
        public const string ARCHIVO_HISTORIAL = "historico.dat";

        public frmHistorial()
        {
            InitializeComponent();
        }

        private void frmHistorial_Load(object sender, EventArgs e)
        {
            Archivos.Texto archivos = new Archivos.Texto(frmHistorial.ARCHIVO_HISTORIAL);
            try
            {
                archivos.Leer(out listaPaginas);
                foreach(string s in listaPaginas)
                {
                    this.lstHistorial.Items.Add(s);
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
