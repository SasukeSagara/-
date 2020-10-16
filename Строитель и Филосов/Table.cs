using System;
using System.Linq;
using System.Windows.Forms;

namespace Строитель_и_Филосов
{
    public partial class Table : BaseForm
    {
        public Table()
        {
            InitializeComponent();
        }

        private void Table_Load(object sender, EventArgs e)
        {
            string[] leads = Properties.Settings.Default.leaders.Split('/');
            for(int i =0; i< leads.Count() - 1; i ++)
            {
                listBox1.Items.Add(leads[i]);
            }
        }
        private void button1_Click_1(object sender, EventArgs e)
        {
            Close();
        }

        private void listBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Control && e.KeyCode == Keys.D)
            {
                Properties.Settings.Default.leaders = "";
                Properties.Settings.Default.Save();
            }
        }
    }
}
