using System.Drawing;
using System.Windows.Forms;

namespace Строитель_и_Филосов
{
    public partial class BaseForm : Form
    {

        Point movePoint = Point.Empty; //Инициализация объекта "точка"
        public BaseForm()
        {
            InitializeComponent();
        }

        #region drag
        public void Form_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)//если нажата не ЛКМ - завершаем обработку события
                return;
            movePoint = new Point(e.X, e.Y);//Если ЛКМ - Ловим начальную позицию перемещения
        }

        public void Form_MouseMove(object sender, MouseEventArgs e)
        {
            if (movePoint == Point.Empty)//Если позиция начала перемещения не отловлена - завершаем обработку события
                return;
            Point location = new Point//Отслеживаем перемещение мыши с зажатой ЛКМ
                (this.Left + e.X - movePoint.X, Top + e.Y - movePoint.Y);
            Location = location;//Перетаскиваем форму вслед за курсором
        }

        public void Form_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)//если отпустили не ЛКМ - завершаем обработку события
                return;
            movePoint = Point.Empty;//Сбрасываем значение
        }
        #endregion drag
    }
}
