using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace ucaksavar
{
    class jetler:Sekiller
    {
        Image rsm;
       
        private int x;
        private int y;
        private int genislik;

        Random rnd = new Random();
        public jetler()
        {
            genislik = 34;
            rsm = Image.FromFile("op.png");
            Y = 0;
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

        public void KonumAyarla(int a,int b)
        {
            X = rnd.Next(a, b);
          
          
        }
        public void Asagit()
        {
            Y += 1;
        }
        public override void Ciz(Graphics j)
        {
            j.DrawImage(rsm, X, Y, Genislik, 34);
        }

    }
}
