using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CPJ_Universal.janelas
{
    public partial class sobre : Form
    {
        public sobre()
        {
            InitializeComponent();
            // Centralizar no monitor
            this.StartPosition = FormStartPosition.CenterScreen;

            // Impedir maximização
            this.MaximizeBox = false;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
        }
    }
}
