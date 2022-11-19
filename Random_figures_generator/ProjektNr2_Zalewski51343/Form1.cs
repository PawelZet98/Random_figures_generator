using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace ProjektNr2_Zalewski51343
{
    public partial class FiguryGeometryczne : Form
    {
        const int Margines = 20;
        Graphics Rysownica;
        Punkt[] TFG;
        int IndexTFG;

        public FiguryGeometryczne()
        {
            InitializeComponent();

            this.Left = Screen.PrimaryScreen.Bounds.Left + Margines;
            this.Top = Screen.PrimaryScreen.Bounds.Top + Margines;
            this.Width = (int)(Screen.PrimaryScreen.Bounds.Width * 0.95F);
            this.Height = (int)(Screen.PrimaryScreen.Bounds.Height * 0.85F);
            this.StartPosition = FormStartPosition.Manual;

            label1.Location = new Point(this.Left + Margines / 2, this.Top + 2 * Margines);
            txtN.Location = new Point(label1.Location.X + Margines, label1.Location.Y + label1.Height + Margines);
            btnStart.Location = new Point(txtN.Location.X - Margines, txtN.Location.Y + txtN.Height + Margines);

            pbRysownica.Location = new Point(label1.Location.X + label1.Width, label1.Location.Y);
            pbRysownica.Width = (int)(this.Width * 0.6F);
            pbRysownica.Height = (int)(this.Height * 0.7F);
            pbRysownica.BackColor = Color.Beige;
            pbRysownica.BorderStyle = BorderStyle.Fixed3D;
            pbRysownica.Image = new Bitmap(pbRysownica.Width, pbRysownica.Height);
            Rysownica = Graphics.FromImage(pbRysownica.Image);
            label2.Location = new Point(pbRysownica.Location.X + pbRysownica.Width + Margines, pbRysownica.Location.Y);
            chlbFiguryGeometryczne.Location = new Point(label2.Location.X, label2.Location.Y + label2.Height + Margines);
        }

        public class Punkt
        {
            protected const int RozmiarPunktu = 20;
            protected int pzX;
            protected int pzY;
            protected Color KolorLinii;
            protected int GrubośćLinii;
            protected DashStyle StylLinii;
            protected bool Widoczność;



            public Punkt(int pzx, int pzy)
            {
                pzX = pzx; pzY = pzy;
                Random r = new Random();
                KolorLinii = Color.FromArgb(r.Next(120, 256), r.Next(0, 90), 0);
                StylLinii = DashStyle.Solid;
                GrubośćLinii = RozmiarPunktu;
                Widoczność = false;
            }
            public Punkt(int pzx, int pzy, Color KolorPunktu)
            {
                pzX = pzx; pzY = pzy;
                Random r = new Random();
                KolorLinii = Color.FromArgb(r.Next(99, 256), r.Next(0, 180), 0);
                StylLinii = DashStyle.Solid;
                GrubośćLinii = RozmiarPunktu;
                Widoczność = false;
            }
            public Punkt(int pzx, int pzy, Color KolorPunktu, int RozmiarPunktu)
            {
                pzX = pzx; pzY = pzy;
                Random r = new Random();
                KolorLinii = Color.FromArgb(r.Next(11,256),r.Next(0,120),0);
                StylLinii = DashStyle.Solid;
                GrubośćLinii = RozmiarPunktu;
                Widoczność = false;
            }

            public virtual void Wykreśl(Graphics PowierzchniaGraficzna)
            {
                using (SolidBrush Pędzel = new SolidBrush(KolorLinii))
                {
                    PowierzchniaGraficzna.FillEllipse(Pędzel, pzX - GrubośćLinii / 2, pzY - GrubośćLinii / 2, GrubośćLinii, GrubośćLinii);
                    Widoczność = true;
                }
            }
            public virtual void Wymaż(Control Kontrolka, Graphics PowierzchniaGraficzan)
            {
                if (this.Widoczność)
                {
                    using (SolidBrush Pedzel = new SolidBrush(Kontrolka.BackColor))
                    {
                        PowierzchniaGraficzan.FillEllipse(Pedzel, pzX - GrubośćLinii / 2, -GrubośćLinii / 2, GrubośćLinii, GrubośćLinii);
                        this.Widoczność = false;
                    }
                }

            }
            public void PrzesuńDoNowegoXY(Control Kontrolka, Graphics PowierzchniaGraficzna, int x, int y)
            {
                this.pzX = x;
                this.pzY = y;
                Wykreśl(PowierzchniaGraficzna);

            }
        }
        public class Linia : Punkt
        {
            int pzXk, pzYk;

            public Linia(int pzXp, int pzYp, int pzXk, int pzYk) : base(pzXp, pzYp)
            {
                this.pzXk = pzXk;
                this.pzYk = pzYk;
            }
            public Linia(int pzXp, int pzYp, int pzXk, int pzYk, Color KolorLinii, DashStyle StylLinii, int GrubośćLinii) : base(pzXp, pzYp, KolorLinii, GrubośćLinii)
            {
                this.pzXk = pzXk;
                this.pzYk = pzYk;
                this.StylLinii = StylLinii;
            }
            public override void Wykreśl(Graphics PowierzchniaGraficzna)
            {
                using (Pen Pióro = new Pen(KolorLinii, GrubośćLinii))
                {
                    Pióro.DashStyle = StylLinii;
                    PowierzchniaGraficzna.DrawLine(Pióro, pzX, pzY, pzXk, pzYk);
                    Widoczność = true;
                }
            }

            public override void Wymaż(Control Kontrolka, Graphics PowierzchniaGraficzan)
            {
                if (Widoczność)
                {
                    using (Pen Pióro = new Pen(Kontrolka.BackColor, GrubośćLinii))
                    {
                        Pióro.DashStyle = StylLinii;
                        PowierzchniaGraficzan.DrawLine(Pióro, pzX, pzY, pzXk, pzYk);
                        Widoczność = false;
                    }
                }
            }
        }

        public class Elipsa : Punkt
        {
            protected int OśDuża, OśMała;

            public Elipsa(int pzx, int pzy, int OśDuża, int OśMała) : base(pzx, pzy)
            {
                this.OśDuża = OśDuża;
                this.OśMała = OśMała;
            }
            public Elipsa(int pzx, int pzy, int OśDuża, int OśMała, Color KolorLinii, DashStyle StylLinii, int GrubośćLinii) : base(pzx, pzy, KolorLinii, GrubośćLinii)
            {
                this.OśDuża = OśDuża;
                this.OśMała = OśMała;
                this.StylLinii = StylLinii;
            }
            public override void Wykreśl(Graphics PowierzchniaGraficzna)
            {
                using (Pen Pióro = new Pen(KolorLinii, GrubośćLinii))
                {
                    Pióro.DashStyle = StylLinii;
                    PowierzchniaGraficzna.DrawEllipse(Pióro, pzX - OśDuża / 2, pzY - OśMała / 2, OśDuża, OśMała);
                    Widoczność = true;
                }
            }
            public override void Wymaż(Control Kontrolka, Graphics PowierzchniaGraficzna)
            { if (this.Widoczność)
                {
                    using (Pen Pióro = new Pen(Kontrolka.BackColor, GrubośćLinii))
                    {
                        Pióro.DashStyle = StylLinii;
                        PowierzchniaGraficzna.DrawEllipse(Pióro, pzX - OśDuża / 2, pzY - OśMała / 2, OśDuża, OśMała);
                        Widoczność = false;
                    }
                }

            }
        }

        public class Prostokąt : Punkt
        {
            protected int pzWysokość;
            protected int pzSzerokość;

            public Prostokąt(int pzx, int pzy, int pzWysokość, int pzSzerokość) : base(pzx, pzy)
            {
                this.pzWysokość = pzWysokość;
                this.pzSzerokość = pzSzerokość;
            }
            public Prostokąt(int pzx, int pzy, int pzWysokość, int pzSzerokość, Color KolorLinii, DashStyle StylLinii, int GrubośćLinii) : base(pzx, pzy, KolorLinii, GrubośćLinii)
            {
                this.pzWysokość = pzWysokość;
                this.pzSzerokość = pzSzerokość;
                this.StylLinii = StylLinii;
            }
            public override void Wykreśl(Graphics PowierzchniaGraficzna)
            {
                using (Pen Pióro = new Pen(KolorLinii, GrubośćLinii))
                {
                    Pióro.DashStyle = StylLinii;
                    PowierzchniaGraficzna.DrawRectangle(Pióro, pzX - pzWysokość, pzY - pzSzerokość, pzWysokość, pzSzerokość);
                    Widoczność = true;
                }
            }

            public override void Wymaż(Control Kontrolka, Graphics PowierzchniaGraficzan)
            {
                if (Widoczność)
                {
                    using (Pen Pióro = new Pen(Kontrolka.BackColor, GrubośćLinii))
                    {
                        Pióro.DashStyle = StylLinii;
                        PowierzchniaGraficzan.DrawLine(Pióro, pzX, pzY, pzWysokość, pzSzerokość);
                        Widoczność = false;
                    }
                }
            }
        }

        public class Kwadrat : Punkt
        {
            int pzBok;

            public Kwadrat(int pzx, int pzy, int pzBok) : base(pzx, pzx)
            {
                this.pzBok = pzBok;
            }
            public Kwadrat(int pzx, int pzy, int pzBok, Color KolorLinii, DashStyle StylLinii, int GrubośćLinii) : base(pzx, pzy, KolorLinii, GrubośćLinii)
            {
                this.pzBok = pzBok;
                this.StylLinii = StylLinii;
            }
            public override void Wykreśl(Graphics PowierzchniaGraficzna)
            {
                using (Pen Pióro = new Pen(KolorLinii, GrubośćLinii)) // kolor linii nie działa
                {
                    Pióro.DashStyle = StylLinii;
                    PowierzchniaGraficzna.DrawRectangle(Pióro, pzX, pzY, pzBok, pzBok);
                    Widoczność = true;
                }
            }

            public override void Wymaż(Control Kontrolka, Graphics PowierzchniaGraficzan)
            {
                if (this.Widoczność)
                {
                    using (Pen Pióro = new Pen(Kontrolka.BackColor, GrubośćLinii))
                    {
                        Pióro.DashStyle = StylLinii;
                        PowierzchniaGraficzan.DrawLine(Pióro, pzX, pzY, pzBok / 2, pzBok / 2);
                        Widoczność = false;
                    }
                }
            }
        }

        public class Okrąg : Elipsa
        {
            protected int Promień;

            public Okrąg(int pzx, int pzy, int Promień) : base(pzx, pzy, 2 * Promień, 2 * Promień)
            {
                this.Promień = Promień;
            }
            public Okrąg(int pzx, int pzy, int Promień, Color KolorLinii, DashStyle StylLinii, int GrubośćLinii) : base(pzx, pzy, 2 * Promień, 2 * Promień, KolorLinii, StylLinii, GrubośćLinii)
            {
                this.Promień = Promień;
            }
            public override void Wykreśl(Graphics PowierzchniaGraficzna)
            {
                using (Pen Pióro = new Pen(KolorLinii, GrubośćLinii)) 
                {
                    Pióro.DashStyle = StylLinii;
                    PowierzchniaGraficzna.DrawEllipse(Pióro, pzX - Promień, pzY - Promień, 2 * Promień, 2 * Promień);
                    Widoczność = true;
                }
            }

            public override void Wymaż(Control Kontrolka, Graphics PowierzchniaGraficzan)
            {
                if (this.Widoczność)
                {
                    using (Pen Pióro = new Pen(Kontrolka.BackColor, GrubośćLinii))
                    {
                        Pióro.DashStyle = StylLinii;
                        PowierzchniaGraficzan.DrawEllipse(Pióro, pzX - Promień, pzY - Promień, 2 * Promień, 2 * Promień);
                        Widoczność = false;
                    }
                }
            }
        }

        class WielokątForemny : Punkt
        {
            protected int PromieńOkręgu;
            protected int StopieńWielokąta;
            protected Point[] TablicaWierzchołkówWielokąta;
            protected float KątPołożeniaPierwszegoWierzchołka;

            public WielokątForemny(int StopieńWielokąta, int pzx, int pzy, int PromieńOkręgu) : base(pzx, pzy)
            {
                this.PromieńOkręgu = PromieńOkręgu;
                this.StopieńWielokąta = StopieńWielokąta;
                this.KątPołożeniaPierwszegoWierzchołka = 0.0F;
                TablicaWierzchołkówWielokąta = new Point[StopieńWielokąta + 1];
                for (int i = 0; i < StopieńWielokąta; i++)
                    TablicaWierzchołkówWielokąta[i] = new Point();
            }

            public WielokątForemny(int StopieńWielokąta, int pzx, int pzy, int PromieńOkręgu, Color KolorLinii, DashStyle StylLinii, int GrubośćLinii) : base(pzx, pzy, KolorLinii)
            {
                this.PromieńOkręgu = PromieńOkręgu;
                this.StopieńWielokąta = StopieńWielokąta;
                this.KątPołożeniaPierwszegoWierzchołka = 0.0F;
                base.StylLinii = StylLinii;
                base.GrubośćLinii = GrubośćLinii;

                TablicaWierzchołkówWielokąta = new Point[StopieńWielokąta + 1];
                for (int i = 0; i < StopieńWielokąta; i++)
                    TablicaWierzchołkówWielokąta[i] = new Point();
            }
            public override void Wykreśl(Graphics PowierzchniaGraficzna)
            {
                using (Pen Pióro = new Pen(KolorLinii, GrubośćLinii))
                {
                    Pióro.DashStyle = StylLinii;
                    float KatMiedzyWierzcholkami = 360F / StopieńWielokąta;
                    for (int i = 0; i <= StopieńWielokąta; i++)
                    {
                        TablicaWierzchołkówWielokąta[i].X = (int)(this.pzX + PromieńOkręgu * Math.Cos(Math.PI * 
                            (KątPołożeniaPierwszegoWierzchołka + i * KatMiedzyWierzcholkami) / 180));
                        TablicaWierzchołkówWielokąta[i].Y = (int)(this.pzY - PromieńOkręgu * Math.Sin(Math.PI * 
                            (KątPołożeniaPierwszegoWierzchołka + i * KatMiedzyWierzcholkami) / 180));

                    }
                    for (int i = 0; i < this.StopieńWielokąta; i++)
                    PowierzchniaGraficzna.DrawLine(Pióro, TablicaWierzchołkówWielokąta[i].X, TablicaWierzchołkówWielokąta[i].Y,
                    TablicaWierzchołkówWielokąta[i + 1].X, TablicaWierzchołkówWielokąta[i + 1].Y);
                    
                    Widoczność = true;
                    //PowierzchniaGraficzna.DrawPolygon(Pióro, TablicaWierzchołkówWielokąta);
                }
            }
            public override void Wymaż(Control Kontrolka, Graphics PowierzchniaGraficzna)
            {
                if (this.Widoczność)
                {
                    using (Pen Pióro = new Pen(Kontrolka.BackColor, this.GrubośćLinii)) //grubosc nie dziala
                    {
                        Pióro.DashStyle = this.StylLinii;
                        for (int i = 0; i < this.StopieńWielokąta; i++)
                            PowierzchniaGraficzna.DrawLine(Pióro, TablicaWierzchołkówWielokąta[i].X, TablicaWierzchołkówWielokąta[i].Y, 
                                TablicaWierzchołkówWielokąta[i + 1].X, TablicaWierzchołkówWielokąta[i + 1].Y);
                        Widoczność = false;

                    }
                }
            }
        }


        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (chlbFiguryGeometryczne.SelectedItems.Count < 0)
            {
                errorProvider1.SetError(chlbFiguryGeometryczne, "ERROR: musisz wybrać (zaznaczyć) figury geometryczne do wizualizacji");
                return;
            }
            else
                errorProvider1.Dispose();
            ushort N;
            while ((!ushort.TryParse(txtN.Text, out N)) || (N <= 0))
            {
                errorProvider1.SetError(txtN, "ERROR: musisz podać liczbę figut" + "geometrycznych lub wystąpił niedozwolony znak w jej zapisie!");
                return;
            }
            chlbFiguryGeometryczne.Enabled = false;
            txtN.Enabled = false;
            TFG = new Punkt[N];
            IndexTFG = 0;

            CheckedListBox.CheckedItemCollection WybraneFigury = chlbFiguryGeometryczne.CheckedItems;

            int pzXmax = pbRysownica.Width;
            int pzYmax = pbRysownica.Height;

            Random LiczbaLosowa = new Random();

            Color KolorLinii;
            Color KolorTła;
            int GrubośćLinii;
            DashStyle StylLinii;
            int pzXp, pzYp;

            for (int i = 0; i < N; i++)
            {
                pzXp = LiczbaLosowa.Next(Margines, pzXmax - Margines);
                pzYp = LiczbaLosowa.Next(Margines, pzYmax - Margines);
                KolorLinii = Color.FromArgb(LiczbaLosowa.Next(0, 255), LiczbaLosowa.Next(0, 255), LiczbaLosowa.Next(0, 255));
                KolorTła = Color.FromArgb(LiczbaLosowa.Next(0, 255), LiczbaLosowa.Next(0, 255), LiczbaLosowa.Next(0, 255));

                switch (LiczbaLosowa.Next(1, 6))
                {
                    case 1: StylLinii = DashStyle.Dash; break;
                    case 2: StylLinii = DashStyle.DashDot; break;
                    case 3: StylLinii = DashStyle.DashDotDot; break;
                    case 4: StylLinii = DashStyle.Dot; break;
                    case 5: StylLinii = DashStyle.Solid; break;
                    default: StylLinii = DashStyle.Solid; break;
                }
                GrubośćLinii = LiczbaLosowa.Next(1, 10);

                string WylosowanaFigura = WybraneFigury[LiczbaLosowa.Next(WybraneFigury.Count)].ToString();
                switch (WylosowanaFigura)
                {
                    case "Punkt":
                        TFG[IndexTFG] = new Punkt(pzXp, pzYp, KolorLinii);
                        TFG[IndexTFG].Wykreśl(Rysownica);
                        IndexTFG++;
                        break;
                    case "Linia":
                        int Xk = LiczbaLosowa.Next(Margines, pzXmax - Margines);
                        int Yk = LiczbaLosowa.Next(Margines, pzYmax - Margines);
                        TFG[IndexTFG] = new Linia(pzXp, pzYp, Xk, Yk, KolorLinii, StylLinii, GrubośćLinii);
                        TFG[IndexTFG].Wykreśl(Rysownica);
                        IndexTFG++;
                        break;
                    case "Elipsa":
                        int OśDuża = LiczbaLosowa.Next(Margines, pzXmax / 4 - Margines);
                        int OśMała = LiczbaLosowa.Next(Margines, pzYmax / 4 - Margines);
                        TFG[IndexTFG] = new Elipsa(pzXp, pzYp, OśDuża, OśMała, KolorLinii, StylLinii, GrubośćLinii);
                        TFG[IndexTFG].Wykreśl(Rysownica);
                        IndexTFG++;
                        break;
                    case "Okrąg":
                        int Promien = LiczbaLosowa.Next(Margines, pzYmax / 4);
                        TFG[IndexTFG] = new Okrąg(pzXp, pzYp, Promien, KolorLinii, StylLinii, GrubośćLinii);
                        TFG[IndexTFG].Wykreśl(Rysownica);
                        IndexTFG++;
                        break;
                    case "Prostokąt":
                        int Wysokość = LiczbaLosowa.Next(Margines, pzXmax/4);
                        int Szerokość = LiczbaLosowa.Next(Margines, pzYmax/4);
                        TFG[IndexTFG] = new Prostokąt(pzXp, pzYp, Wysokość, Szerokość, KolorLinii, StylLinii, GrubośćLinii);
                        TFG[IndexTFG].Wykreśl(Rysownica);
                        IndexTFG++;
                        break;
                    case "Kwadrat":
                        int Bok = LiczbaLosowa.Next(Margines, pzXmax/4);
                        TFG[IndexTFG] = new Kwadrat(pzXp, pzYp, Bok, KolorLinii, StylLinii, GrubośćLinii);
                        TFG[IndexTFG].Wykreśl(Rysownica);
                        IndexTFG++;
                        break;
                    case "Wielokąt foremny":
                        int Rokręgu;
                        Rokręgu = LiczbaLosowa.Next(1, pzYmax / 3);
                        int StopieńWielokąta = LiczbaLosowa.Next(3, 21);
                        TFG[IndexTFG] = new WielokątForemny(StopieńWielokąta, pzXp, pzYp, Rokręgu, KolorLinii, StylLinii, GrubośćLinii);
                        TFG[IndexTFG].Wykreśl(Rysownica);
                        IndexTFG++;
                        break;
                    default:
                        errorProvider1.SetError(btnStart, "ERROR: figura o nazwie:" + WylosowanaFigura + " nie może być jeszcze wykreślona!!!");
                        return;
                }
            }
            pbRysownica.Refresh();
            btnStart.Enabled = false;

        }

        private void chlbFiguryGeometryczne_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnPrzesuńFigury_Click(object sender, EventArgs e)
        {
            int pzXp, pzYp;
            Rysownica.Clear(pbRysownica.BackColor);
            int Xmax = pbRysownica.Width; int Ymax = pbRysownica.Height;
            Random LiczbaLosowa = new Random();

            for (int i = 0; i < TFG.Length; i++)
            {
                pzXp = LiczbaLosowa.Next(Margines, Xmax - Margines);
                pzYp = LiczbaLosowa.Next(Margines, Ymax - Margines);
                TFG[i].PrzesuńDoNowegoXY(pbRysownica, Rysownica, pzXp, pzYp);
            }
            pbRysownica.Refresh();
        }

    }
}
