using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EbookReaderTest
{
    public partial class launchForm : Form
    {
        public launchForm()
        {
            InitializeComponent();
            this.Text = "Rabbit Hole Launcher";
        }
    

    private void JUMP_Click(object sender, EventArgs e)
        {
            Form1 mainForm = new Form1();
            this.Hide();
            mainForm.ShowDialog();
            this.Close();
        }
    }
}
