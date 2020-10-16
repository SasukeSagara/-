using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Строитель_и_Филосов
{
    public partial class chooseCat : Form
    {

        public chooseCat()
        {
            InitializeComponent();
            toolTip1.SetToolTip(errMark, "Имя не может быть пустым");
            toolTip1.SetToolTip(errMark2, "Для продолжения необходимо выбрать категорию");
        }

        private void registration_Load(object sender, EventArgs e)
        {
            try
            {
                string[] categoryList = Directory.GetFiles(Path.Combine(Application.StartupPath, @"data/Dictionary/"), "*.txt");//Извлекаем список категорий
                int numCat = categoryList.Count();//кол-во категорий
                for (int i = 0; i < numCat; i++)//Для каждого текстового файла
                {
                    categoryList[i] = categoryList[i].Split('/')[2].Split('.')[0];//Оставляем только название категории
                    categoryListDropdown.Items.Add(categoryList[i]);//Добавляем элемент в выпадающий список
                }
                nickName.Text = Properties.Settings.Default.UserName;//Предлагаем предыдущее введенное имя пользователя
                categoryListDropdown.SelectedItem = Properties.Settings.Default.selectedCategory;//Предлагаем предыдущую выбранную категорию
            }
            catch
            {
                MessageBox.Show("Были повреждены или отсутствуют необходимые для работы программы файлы.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);//Вывод сообщения пользователю
                DialogResult = DialogResult.No;//Отправляем ответ форме-родителю(обработка ошбок)
                Close();
            }  
        }

        /// <summary>
        /// Нажатие на кнопку "Далее"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void next_Click(object sender, EventArgs e)
        {
            if (nickName.Text == "" && categoryListDropdown.Text == "")//Если поля пустые
                errMark.Visible = errMark2.Visible = true;//Помечаем ошибки
            else if (nickName.Text == "" && categoryListDropdown.Text != "") errMark.Visible = true;//Если не введено имя пользователя
            else if (nickName.Text != "" && categoryListDropdown.Text == "") errMark2.Visible = true;//Если не выбрана категоря
            else
            {
                Properties.Settings.Default.UserName = nickName.Text;//Записываем имя пользователя в файл настроек приложения
                do
                {
                    pickWord(categoryListDropdown.Text);//Выбираем слово
                }
                while (Properties.Settings.Default.selectedWord == Properties.Settings.Default.prevWord);//Предотвращаем выбор отдного и того де слово 2 раза подряд
                Properties.Settings.Default.Save();//Сохраняем измененные настройки

                Close();//Закрываем форму
            }

        }

        /// <summary>
        /// Нажате клавиши в поле ввода Имени пользователя
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void nickName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)//Если нажата клавиша "Enter"
            {
                next_Click(sender, e);//Имитируем нажате на кнопку "Далее"
            }
        }

        /// <summary>
        /// Выбор слова из словаря
        /// </summary>
        /// <returns></returns>
        static void pickWord(string category)
        {
            Properties.Settings.Default.selectedCategory = category;//Запоминаем выбранную категорию
            try//Пробуем
            {
                string[] wordList = File.ReadAllLines("data/Dictionary/" + category + ".txt");//Забиваем строковой массив словами из файла
                Random randomGen = new Random();//инициализируем генератор случайных чисел
                Properties.Settings.Default.selectedWord = wordList[randomGen.Next(wordList.Count())];//Рандомно выбираем слово из массива
            }
            catch//Если не получилось (Обработка ошибок)
            {
                MessageBox.Show("Не удалось выбрать слово, возможно поврежден словарь.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);//Вывод сообщения пользователю
            }
        }
    }
}
