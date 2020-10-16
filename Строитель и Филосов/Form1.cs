using System;

namespace Строитель_и_Филосов
{
    public partial class Form1 : BaseForm
    {

        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Нажатие на кнопку "Начать игру"
        /// </summary>
        /// <param name="sender">Объект</param>
        /// <param name="e"></param>
        private void startGame_Click(object sender, EventArgs e)
        {
            Hide();//Скрываем основное окно
            new Game().ShowDialog();//Открываем форму с игрой
            Show();//По завершении игры - показываем основную форму
        }

        /// <summary>
        /// Нажатие на кнопку "Справка"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void info_Click(object sender, EventArgs e)
        {
            Hide();//Скрываем основную форму
            new infoF().ShowDialog();//Открываем форму "справка"
            Show();//По завершении - показываем основную форму
        }

        /// <summary>
        /// Нажате на кнопку "Правила"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            Hide();//Скрываем основную форму
            new rulesFcs().ShowDialog();//Открываем форму "Правила"
            Show();//По завершении - показываем основную форму
        }

        /// <summary>
        /// Нажатие на кнопку "Выход"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void exit_Click(object sender, EventArgs e)
        {
            //Закрываем приложение
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Hide();//Скрываем основную форму
            new Table().ShowDialog();
            Show();//По завершении - показываем основную форму
        }
    }
}
