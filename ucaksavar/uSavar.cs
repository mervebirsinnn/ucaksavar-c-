using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace ucaksavar
{
    class uSavar:Sekiller
    {
        Image resim;
        private int x;
        private int y;

        public uSavar()
        {
            resim = Image.FromFile("top.png");
            y = 500;
            x = 350;
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

        public void  SolaGit()
        {
            if(X>0)
            X -= 10;
        }
        public void SagaGit()
        {
            if(X<700)
            X+= 10;
        }
        public override void Ciz(Graphics g)
        {

            g.DrawImage(resim, X,Y, 64, 64);
            
        }
       
    }
}
