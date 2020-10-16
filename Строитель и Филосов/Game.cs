using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Строитель_и_Филосов
{
    public partial class Game : Form
    {
        #region variables
        string selectedWord;//выбранное слово из словаря
        string alphabet = "АБВГДЕЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯ";//строковая перем. с алфавитом
        int lives = 9, //кол-во "жизней" игрока
            guessedLetterCount = 0; //Счетчик отгаданных пользователем букв
        #endregion variables


        public Game()
        {
            InitializeComponent();//Инициализация компонентов
        }

        private void Game_Load(object sender, EventArgs e)
        {
            selectedWord = pickWord();//Вызов функции по выбору слова
        }

        /// <summary>
        /// Подготовка формы к игре.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Game_Shown(object sender, EventArgs e)
        {
            if (selectedWord == "") Close();//Если выбранное слово пусто - закрываем форму (Обработка ошибки)
            word.ColumnCount = selectedWord.Length;//Задание кол-ва столбцов у DataGridView
            word.RowCount = 1;//задание кол-ва строк у DataGridView
            int widthW = word.Columns.Count * 27; // инициализируем удобную ширину для DataGridView
            word.Width = widthW;// задаем удобную ширину для DataGridView
            word.Location = new System.Drawing.Point(250-(widthW/2), 71);//Размещаем элемент по центру формы
            word.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;//Задаем режим подбора ширины столбцов


            int posX = 20, posY = 335;//начальные позиции первой строки букв
            for (int i = 0; i < alphabet.Count(); i++)//создание цикла
            {
                Button button = new Button();//метод создания новой кнопки
                button.BackColor = Color.White;//цвет кнопки
                button.TabIndex = 0;//Индекс кнопки
                button.Text = alphabet[i] + "";//присваивает значение след.буквы
                button.FlatStyle = FlatStyle.Flat;//Стиль кнопки
                button.FlatAppearance.BorderColor = Color.Gray;//Цвет рамки у кнопки
                button.Click += new EventHandler(this.button_Click);//Обработчик события
                button.Location = new System.Drawing.Point(posX, posY);//рисование кнопки
                button.Size = new System.Drawing.Size(57, 35);//задание размера кнопки
                this.Controls.Add(button);//добавление кнопки
                posX += button.Width;//ширина кнопки
                if ((i + 1) % 8 == 0)
                {
                    posX = 20;
                    posY += button.Height;//высота кнопки
                }
            }

        }

        /// <summary>
        /// Нажатие на кнопку с буквой
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_Click(object sender, EventArgs e)
        {
            Button letter_btn = sender as Button;
            if (IsInTheWord(letter_btn.Text))//Проверка на вхождение буквы в слово
            {
                log("Такая буква в слове есть.");//Пояснительная информация для пользователя
                addLetter(Convert.ToChar(letter_btn.Text.ToLower()));//Добавление буквы в DataGridView
            }
            else if (!IsInTheWord(letter_btn.Text))
            {
                log("Такой буквы в слове нет.");//Пояснительная информация для пользователя
                buildHouse();//"строим" дом
            }
            letter_btn.Enabled = false;//Исключаем возможность дальнейшего взаимодействия пользователя с текущей кнопкой
            letter_btn.BackColor = Color.Gray;//Меняем фон кнопки
            letter_btn.FlatAppearance.BorderColor = Color.Gray;//меняем цвет рамки вокруг кнопки
        }

        /// <summary>
        /// Вывод информации пользователю
        /// </summary>
        /// <param name="text">Сообщение</param>
        private void log(string text)
        {
            txt.Text = text;//Вывод сообщения в поле txt
            txt.Location = new System.Drawing.Point(250 - (txt.Width / 2), 315);//Размещение сообщения в цетре формы
        }

        /// <summary>
        /// Выбор слова из словаря
        /// </summary>
        /// <returns></returns>
        static string pickWord()
        {
            try//Пробуем
            {
                string[] wordList = File.ReadAllLines("data/Dictionary.txt");//Забиваем строковой массив словами из файла
                Random randomGen = new Random();//инициализируем генератор случайных чисел
                return wordList[randomGen.Next(wordList.Count())];//Рандомно выбираем слово из массива
            }
            catch//Если не получилось (Обработка ошибок)
            {
                MessageBox.Show("Не удалось выбрать слово, возможно поврежден словарь.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);//Вывод сообщения пользователю
                return "";//Возвращение пустой строки для дальнейшей обработки ошибок
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
            for(int i = 0; i < selectedWord.Length; i++)//объявление массива
            {
                if (letter == selectedWord[i])//нахождение местоположения буквы в слове
                {
                    guessedLetterCount++;//Увеличиваем число отгаданных пользователем букв
                    word[i, 0].Value = char.ToUpper(letter);//Выводим данную букву в DataGridView
                    if (guessedLetterCount == selectedWord.Length)//Если отгаданы все буквы
                        EndOfGame(true);//Завершаем игру с параметром "Won"
                }
            }
        }

        /// <summary>
        /// "Постройка" домика
        /// </summary>
        private void buildHouse()
        {
            if (lives == 1) EndOfGame(false);//если жизни закончились - завершаем ишру с параметром "not Won"
            houseP.Load(@"data/House/house_" + (10 - lives) + ".png");//Рисуем домик
            lives--;//Уменьшаем кол-во жизней игрока
        }

        /// <summary>
        /// Конец игры
        /// </summary>
        /// <param name="won">Определяет победил пользователь или проиграл</param>
        private void EndOfGame(bool won)
        {
            houseP.Load(@"data/House/house.png");//Ставим финальное изображение домика
            if (won)//Если игра завершена с попедой
                MessageBox.Show("Вы выиграли!\nПравильное слово: " + 
                    selectedWord, "Победа!");
            else//Если игра завершена с поражением
                MessageBox.Show("Вы проиграли.\nПравильное слово: " + 
                    selectedWord , "Поражение");
            Close();//Закрываем форму с игрой
        }
    }
}
