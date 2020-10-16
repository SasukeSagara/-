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
    public partial class infoF : Form
    {
        Point movePoint = Point.Empty;
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
        #region drag
        private void Form_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)//если нажата не ЛКМ - завершаем обработку события
                return;
            movePoint = new Point(e.X, e.Y);//Если ЛКМ - Ловим начальную позицию перемещения
        }

        private void Form_MouseMove(object sender, MouseEventArgs e)
        {
            if (movePoint == Point.Empty)//Если позиция начала перемещения не отловлена - завершаем обработку события
                return;
            Point location = new Point//Отслеживаем перемещение мыши с зажатой ЛКМ
                (this.Left + e.X - movePoint.X, Top + e.Y - movePoint.Y);
            Location = location;//Перетаскиваем форму вслед за курсором
        }

        private void Form_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)//если отпустили не ЛКМ - завершаем обработку события
                return;
            movePoint = Point.Empty;//Сбрасываем значение
        }
        #endregion drag
    }
}
