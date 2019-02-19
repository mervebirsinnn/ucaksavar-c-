using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace ucaksavar
{
    class Mermi:Sekiller
    {
        Image resim;
        private int x;
        private int y;
        private int genislik;
       
       
        public Mermi()
        {
            resim = Image.FromFile("mermi.png");

            Genislik = 25;
        }


        public int X
        {
            get
            {
                return x;
            }

            set
            {
                x = value;
            }
        }

        public int Y
        {
            get
            {
                return y;
            }

            set
            {
                y = value;
            }
        }

        public int Genislik
        {
            get
            {
                return genislik;
            }

            set
            {
                genislik = value;
            }
        }

        public void yukariGit()
        {
            Y -= 5;
        }
        public override void Ciz(Graphics a)
        {
            
            a.DrawImage(resim, X, Y, Genislik, 25);
           
        }
       
    }
}
