using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ucaksavar
{
   
    class AnaPencere:Form
    {
        uSavar u;

      //  SoundPlayer player = new SoundPlayer();
        SoundPlayer mermisesi = new SoundPlayer();
 
         Timer jetUretTimer;
        Timer mermiUretTimer;
        List<jetler> jetler = new List<jetler>();
        List<Mermi> mermiler = new List<Mermi>();

       
        private int geriSayim = 50;
        public AnaPencere(int genislik, int yukseklik)
        {
            Width = genislik;
            Height = yukseklik;
       
            
            Paint += AnaPencere_Paint;
            KeyDown += AnaPencere_KeyDown;
      
           
            DoubleBuffered = true;
            jetUretTimer = new Timer();
            mermiUretTimer = new Timer();
            mermiUretTimer.Interval = 1;
            jetUretTimer.Interval = 10;
            jetUretTimer.Tick += jetUretTimer_Tick;
            mermiUretTimer.Tick += MermiUretTimer_Tick;
           
            u = new uSavar();
            
       
        }

        private void MermiUretTimer_Tick(object sender, EventArgs e)
        {


            foreach (var siradaki1 in mermiler)
            {
                siradaki1.yukariGit();
                
            }
                Invalidate();

        }
        private void jetUretTimer_Tick(object sender, EventArgs e)
        {

            if (geriSayim == 0)
            {
                jetler jet = new jetler();
                jet.KonumAyarla(100, 700);
                jetler.Add(jet);
                geriSayim = 50;
            }

            geriSayim--;
            Carpisma();
           
            foreach (var siradaki in jetler)
            {
                siradaki.Asagit();


            }
            for (int i = 0; i < jetler.Count; i++)
            {
                if (jetler[i].Y > u.Y)
                {

                    mermiUretTimer.Stop();
                    mermisesi.Stop();          
                    jetUretTimer.Stop();
                    MessageBox.Show("Oyun bitti.Yeni oyun için Enter a basınız.");


                }
            }
           
            Invalidate();
        }


        public void Carpisma()
        {
            for (int i = 0; i < jetler.Count; i++)
            {
                for (int k = 0; k < mermiler.Count; k++)
                {
                    if (jetler[i].X < mermiler[k].X+mermiler[k].Genislik && 
                        (jetler[i].X+jetler[i].Genislik>mermiler[k].X) && 
                        (jetler[i].Y < mermiler[k].Genislik +mermiler[k].Y)&&
                        (jetler[i].Genislik+jetler[i].Y>mermiler[k].Y))
                    {
                        jetler.Remove(jetler[i]);
                        mermiler.Remove(mermiler[k]);
                        return;
                    }
                }

            }
        }
        private void AnaPencere_KeyDown(object sender, KeyEventArgs e)
        {
          
            switch (e.KeyCode)
            {
                case Keys.Right:
                    {
                        u.SagaGit();
                        break;
                    }
                case Keys.Left:
                    {
                        u.SolaGit();
                        break;
                    }
                case Keys.Space:
                    {
                        Mermi m = new Mermi();
                        m.X = u.X + 24;
                        m.Y = u.Y - 16;

                        mermiler.Add(m);
                        mermisesi.SoundLocation= @"C:\Users\dell\Documents\Visual Studio 2015\Projects\ucaksavar\ucaksavar\bin\Debug\44.wav";
                        mermisesi.Play();
                        

                        break;
                    }
                case Keys.Enter:
                    {
                        mermiUretTimer.Start();
                        jetUretTimer.Start();
                        // player.SoundLocation = @"C:\Users\dell\Documents\Visual Studio 2015\Projects\ucaksavar\ucaksavar\bin\Debug\plane.wav";
                        // player.Play();
                        jetler.Clear();

                        break;
                    }
                case Keys.Escape:
                    {
                        Application.Exit();
                        break;
                    }
                
            }
            Invalidate();
        }

      

        private void AnaPencere_Paint(object sender, PaintEventArgs e)
        {
           

            u.Ciz(e.Graphics);
            
            foreach (var siradaki in jetler)
                siradaki.Ciz(e.Graphics);
            foreach (var siradaki in mermiler)
                siradaki.Ciz(e.Graphics);

        }
    }
}
