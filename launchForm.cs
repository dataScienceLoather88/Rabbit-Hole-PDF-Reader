using Newtonsoft.Json;
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
        private Dictionary<string, string> recentsMap = new Dictionary<string, string>();

        public launchForm()
        {
            InitializeComponent();
            LoadRecentsList();
            this.Text = "Rabbit Hole Launcher";
        }

        private void comboRecents_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedName = comboRecents.SelectedItem as string;

            if (selectedName != null && recentsMap.TryGetValue(selectedName, out string fullPath))
            {
                if (File.Exists(fullPath))
                {
                    Form1 mainForm = new Form1(1);
                    mainForm.LoadPDF(fullPath); // You may need to expose LoadPDF() or use constructor injection
                    this.Hide();
                    mainForm.ShowDialog();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("File not found.");
                }
            }
        }



        private void LoadRecentsList()
        {
            string recentsPath = Path.Combine(Application.StartupPath, "recent.json");

            if (File.Exists(recentsPath))
            {
                try
                {
                    var recents = JsonConvert.DeserializeObject<List<string>>(File.ReadAllText(recentsPath));
                    if (recents != null)
                    {   
                        comboRecents.Items.Clear();
                        recentsMap.Clear();

                        foreach (string fullPath in recents)
                        {
                            string fileName = Path.GetFileName(fullPath);
                            recentsMap[fileName] = fullPath;
                            comboRecents.Items.Add(fileName); // only show file name
                        }
                    }
                }
                catch
                {
                    // Optional: Show/log error loading recent files
                }
            }
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
