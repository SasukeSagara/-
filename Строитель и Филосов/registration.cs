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
    public partial class registration : Form
    {

        public registration()
        {
            InitializeComponent();
        }

        private void registration_Load(object sender, EventArgs e)
        {
            try
            {
                string[] categoryList = Directory.GetFiles(@"data/Dictionary/", "*.txt");//Извлекаем список категорий
                int numCat = categoryList.Count();//кол-во категорий
                for (int i = 0; i < numCat; i++)
                {
                    categoryList[i] = categoryList[i].Split('/')[2].Split('.')[0];//Оставляем только название категории
                    categoryListDropdown.Items.Add(categoryList[i]);
                }
                nickName.Text = Properties.Settings.Default.UserName;
                categoryListDropdown.SelectedItem = Properties.Settings.Default.selectedCategory;
            }
            catch
            {
                MessageBox.Show("Были повреждены или отсутствуют необходимые для работы программы файлы.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);//Вывод сообщения пользователю
                DialogResult = DialogResult.No;
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
            if (nickName.Text != "" && categoryListDropdown.Text != "")
            {
                Properties.Settings.Default.UserName = nickName.Text;//Записываем имя пользователя в файл настроек приложения
                pickWord(categoryListDropdown.Text);//Выбираем слово
                Properties.Settings.Default.Save();//Сохраняем измененные настройки
                Close();//Закрываем форму
            }
            else if (nickName.Text == "" && categoryListDropdown.Text != "") errMark.Visible = true;
            else if (nickName.Text != "" && categoryListDropdown.Text == "") errMark2.Visible = true;
            else
            {
                errMark.Visible = true;
                errMark2.Visible = true;
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
            Properties.Settings.Default.selectedCategory = category;
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
