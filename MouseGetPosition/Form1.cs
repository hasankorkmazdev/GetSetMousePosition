using System;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

namespace MouseGetPosition
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public struct Kordinat
        {
            public int x;
            public int y;
        }
        [DllImport("user32.dll")]
        private static extern int GetCursorPos(ref Kordinat lpPoint);
        
        private Kordinat Kor_1 = new Kordinat();
        /// <summary>
        ///Bu Metot 2 tane değer döndürür bu değerleri out ile fırlatır
        ///metodu çağıran karşı tarafta out ile verilen değerleri out ile yakalamalıdır
        /// </summary>
        /// <param name="MouseXPosition">Mouse X Pozisyonundaki Değeri</param>
        /// <param name="MouseYPosition">Mouse Y Pozisyonundaki Değeri</param>
        public void GetMyCursorPos(out int MouseXPosition, out int MouseYPosition)
        {
            GetCursorPos(ref Kor_1);
            MouseXPosition = Kor_1.x;
            MouseYPosition = Kor_1.y;
           
        }
        public void printt()
        {
                GetMyCursorPos(out int MouseXPosition, out int MouseYPosition);
                label1.Text = MouseXPosition.ToString();
                label2.Text = MouseYPosition.ToString();
        }

        [DllImport("user32.dll")]
        private static extern bool SetCursorPos(int X, int Y);


        private void button3_Click(object sender, EventArgs e)
        {
            SetCursorPos(300, 300);
        }

        }
}
