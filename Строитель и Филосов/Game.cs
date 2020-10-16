using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Строитель_и_Филосов
{
    public partial class Game : Form
    {
        #region variables
        /// <summary>
        /// Выбранное для игры слово
        /// </summary>
        string selectedWord;
        /// <summary>
        /// Строковая перем. с алфавитом
        /// </summary>
        string alphabet = "АБВГДЕЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯ";
        /// <summary>
        /// Изображения домика по кадрам
        /// </summary>
        string[] houseImgs = { "data/House/house.png","data/House/house_1.png","data/House/house_2.png","data/House/house_3.png","data/House/house_4.png","data/House/house_5.png","data/House/house_6.png","data/House/house_7.png","data/House/house_8.png","data/House/house_9.png",};
        /// <summary>
        /// Кол-во "жизней" игрока
        /// </summary>
        int lives = 9;
        /// <summary>
        /// Кол-во ходов
        /// </summary>
        int clickCount = 0;
        /// <summary>
        /// Кол-во неверных ходов
        /// </summary>
        int wrongClick = 0;
        /// <summary>
        /// Кол-во отгаданных пользователем букв
        /// </summary>
        int guessedLetterCount = 0;
        /// <summary>
        /// "Массив времени" :D - ч/м/с
        /// </summary>
        int[] time = {0,0,0};
        /// <summary>
        /// Массив кнопок-букв (Для ввода с клавиатуры)
        /// </summary>
        object[] letterButtons = new object[32];
        /// <summary>
        /// Коды клавиш русского алфвита отсортированные
        /// </summary>
        int[] keys = { 70, 188, 68, 85, 76, 84, 186, 80, 66, 81, 82, 75, 86, 89, 74, 71, 72, 67, 78, 69, 65, 219, 87, 88, 73, 79, 221, 83, 77, 222, 190, 90 };
        /// <summary>
        /// Подсказки
        /// </summary>
        ToolTip Tips = new ToolTip();
        #endregion variables

        public Game()
        {
            InitializeComponent();//Инициализация компонентов
        }

        private void Game_Load(object sender, EventArgs e)
        {
            DialogResult choose = new chooseCat().ShowDialog();//Показ формы ввода Имени пользователя
            if (choose == DialogResult.No)//Отлов исключения
                Close();
            selectedWord = Properties.Settings.Default.selectedWord;//Перевод выбранного слова в переменную
            label1.Text = "Угадайте слово из категории\n\"" + Properties.Settings.Default.selectedCategory + "\"";
            label1.Location = new System.Drawing.Point(250 - (label1.Width / 2), 24);//Размещаем элемент по центру формы
        }

        /// <summary>
        /// Подготовка формы к игре.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Game_Shown(object sender, EventArgs e)
        {
            #region wordInit
            if (selectedWord == "") Close();//Если выбранное слово пусто - закрываем форму (Обработка ошибки)
            word.ColumnCount = selectedWord.Length;//Задание кол-ва столбцов у DataGridView
            for (int i =0; i<selectedWord.Length;i++)
            {
                word[i, 0].ToolTipText = "Подсказать букву";
            }
            word.RowCount = 1;//задание кол-ва строк у DataGridView
            int widthW = word.Columns.Count * 35; // инициализируем удобную ширину для DataGridView
            word.Width = widthW;// задаем удобную ширину для DataGridView
            word.Location = new System.Drawing.Point(250 - (widthW / 2), 77);//Размещаем элемент по центру формы
            word.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;//Задаем режим подбора ширины столбцов
            #endregion wordInit
            #region characterButtonsInit
            int posX = 3, posY = 350;//начальные позиции первой строки букв
            for (int i = 0; i < alphabet.Count(); i++)//создание цикла
            {
                Button button = new Button();//метод создания новой кнопки
                button.BackColor = Color.White;//цвет кнопки
                button.TabIndex = 0;//Индекс кнопки
                button.Text = alphabet[i] + "";//присваивает значение след.буквы
                button.Font = new Font("Tahoma", 10);//Установка шрифта кнопик
                button.FlatStyle = FlatStyle.Flat;//Стиль кнопки
                button.FlatAppearance.BorderColor = Color.Gray;//Цвет рамки у кнопки
                button.Click += new EventHandler(button_Click);//Обработчик события Клик
                button.KeyDown += new KeyEventHandler(Game_KeyDown);//Обработчик события нажатия клавиши
                button.Location = new System.Drawing.Point(posX, posY);//рисование кнопки
                button.Size = new System.Drawing.Size(60, 35);//задание размера кнопки
                Controls.Add(button);//добавление кнопки
                posX += button.Width+2;//ширина кнопки + расстояние межд ними
                if ((i + 1) % 8 == 0)
                {
                    posX = 3;
                    posY += button.Height + 2;//высота кнопки
                }
                letterButtons[i] = button;//Добавляем объект в массив кнопок
            }
            #endregion characterButtonsInit
            timer1.Start();    
        }

        /// <summary>
        /// Нажатие на кнопку с буквой
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_Click(object sender, EventArgs e)
        {
            clickCount++;//Увеличение кол-ва ходов
            Button letter_btn = sender as Button;//Сама кнопка(объект)
            if (letter_btn.Enabled)
            {
                letter_btn.Enabled = false;//Исключаем возможность дальнейшего взаимодействия пользователя с текущей кнопкой
                if (IsInTheWord(letter_btn.Text))//Проверка на вхождение буквы в слово
                {
                    letter_btn.BackColor = Color.LightGreen;//Меняем фон кнопки
                    addLetter(Convert.ToChar(letter_btn.Text.ToLower()));//Добавление буквы в DataGridView
                }
                else if (!IsInTheWord(letter_btn.Text))
                {
                    letter_btn.BackColor = Color.LightCoral;//Меняем фон кнопки
                    buildHouse(true);//"строим" дом
                }
            }
        }

        /// <summary>
        /// Проверяет наличие буквы в выбранном слове.
        /// </summary>
        /// <param name="letter">Проверяемая буква.</param>
        /// <returns></returns>
        private bool IsInTheWord(string letter)
        {
            if (selectedWord.Contains(letter.ToLower()))//Если слово содержит переданную букву
                return true;
            else
                return false;
        }

        /// <summary>
        /// Добавление буквы в клетку
        /// </summary>
        /// <param name="letter">Добавляемая буква</param>
        private void addLetter(char letter)
        {
            for (int i = 0; i < selectedWord.Length; i++)//объявление массива
            {
                if (letter == selectedWord[i])//нахождение местоположения буквы в слове
                {
                    guessedLetterCount++;//Увеличиваем число отгаданных пользователем букв
                    word[i, 0].Value = char.ToUpper(letter);//Выводим данную букву в DataGridView
                    word[i, 0].ToolTipText = null;
                    if (guessedLetterCount == selectedWord.Length)//Если отгаданы все буквы
                        EndOfGame(true);//Завершаем игру с параметром "Won"
                }
            }
        }

        /// <summary>
        /// Ввод букв с клавиатуры
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Game_KeyDown(object sender, KeyEventArgs e)
        {
            for (int i = 0; i < letterButtons.Count(); i++)
            {
                if (e.KeyValue == keys[i])
                {
                    button_Click(letterButtons[i], EventArgs.Empty);
                    break;
                }
            }
        }

        /// <summary>
        /// Отслеживает врямя игры
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer1_Tick(object sender, EventArgs e)
        {
            time[2]++;
            if (time[2] >= 60)
            {
                time[1]++;
                time[2] = 0;
            }
            if (time[1] >= 60)
            {
                time[0]++;
                time[1] = 0;
            }
        }

        /// <summary>
        /// "Постройка" домика
        /// </summary>
        /// <param name="upCount">Увеличивать счетчик неверных ходов?</param>
        private void buildHouse( bool upCount)
        {
            if(upCount)
                wrongClick++;//Увеличиваем чило неверных ходов
            if (lives == 1) EndOfGame(false);//если жизни закончились - завершаем ишру с параметром "not Won"
            houseP.Load(houseImgs[10-lives]);//Рисуем домик
            lives--;//Уменьшаем кол-во жизней игрока
        }

        /// <summary>
        /// Конец игры
        /// </summary>
        /// <param name="won">Определяет победил пользователь или проиграл</param>
        private void EndOfGame(bool won)
        {
            timer1.Stop();//Останавливаем таймер
            houseP.Load(houseImgs[0]);//Ставим финальное изображение домика
            MessageBox.Show(Properties.Settings.Default.UserName +//Выводим сообщение
                ", " + (won ? "Вы выиграли!" : "Вы проиграли.") + "\nПравильный ответ - " +
                selectedWord.ToUpper() + "\nКоличество ходов: " +
                clickCount + "\nНеверных ходов: " +
                wrongClick + "\nВремя игры: " +
                time[0].ToString("D2") + "ч. " + time[1].ToString("D2") + "м. " + time[2].ToString("D2") + "с.\n",
                (won ? "Победа!" : "Поражение."));
            if (won && !Properties.Settings.Default.leaders.Contains("Время игры: " +
                time[0] + "ч. " + time[1] + "м. " + time[2] + "с.\n" + "Количество ходов: " +
                clickCount + "\nНеверных ходов: " +
                wrongClick))
                Properties.Settings.Default.leaders += "Время игры: " +
                time[0].ToString("D2") + " : " + time[1].ToString("D2") + " : " + time[2].ToString("D2") + "   Слово: " + Properties.Settings.Default.selectedWord +  "   Количество ходов: " +
                clickCount + "   Неверных ходов: " +
                wrongClick + " -- " + Properties.Settings.Default.UserName + "/";
            Properties.Settings.Default.prevWord = selectedWord;
            Properties.Settings.Default.Save();
            Close();//Закрываем форму с игрой
        }

        /// <summary>
        /// Нажатие на ячейку в слове
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void word_Click(object sender, EventArgs e)
        {
            if (word.CurrentCell.Value == null && lives > 1)
            {
                DialogResult areSure = MessageBox.Show("При использовании подсказки Вы потеряете 2 жизни" +
                "\nПродолжить?", "Показать букву", MessageBoxButtons.OKCancel);
                if (areSure == DialogResult.OK)
                {
                    object neededBtn = new object();
                    for (int i = 0; i < alphabet.Length; i++)
                        if (Char.ToUpper(selectedWord[word.CurrentCellAddress.X]) == alphabet[i])
                        {
                            neededBtn = letterButtons[i];
                            break;
                        }
                    button_Click(neededBtn, EventArgs.Empty);
                    buildHouse(false);
                    buildHouse(false);
                }
            }
            word.CurrentCell.Selected = false;
        }
    }
}
