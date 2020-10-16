using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Строитель_и_Филосов
{
    public partial class rulesFcs : Form
    {
        public rulesFcs()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Нажатие кнопки "Вернуться на главную"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            //Закрываем форму
            Close();
        }
    }
}
