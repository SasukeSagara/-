using System;

namespace Строитель_и_Филосов
{
    public partial class infoF : BaseForm
    {
        public infoF()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Нажате на кнопку "Вернуться на главную"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            //Закрываем окно
            Close();
        }
    }
}
