using System;

namespace Строитель_и_Филосов
{
    public partial class rulesFcs : BaseForm
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
