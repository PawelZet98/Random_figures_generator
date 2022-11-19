namespace ProjektNr2_Zalewski51343
{
    partial class FiguryGeometryczne
    {
        /// <summary>
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod generowany przez Projektanta formularzy systemu Windows

        /// <summary>
        /// Metoda wymagana do obsługi projektanta — nie należy modyfikować
        /// jej zawartości w edytorze kodu.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.txtN = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnPrzesuńFigury = new System.Windows.Forms.Button();
            this.chlbFiguryGeometryczne = new System.Windows.Forms.CheckedListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.pbRysownica = new System.Windows.Forms.PictureBox();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pbRysownica)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // txtN
            // 
            this.txtN.Location = new System.Drawing.Point(35, 61);
            this.txtN.Name = "txtN";
            this.txtN.Size = new System.Drawing.Size(100, 20);
            this.txtN.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(32, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(167, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Podaj liczbę figur geometrycznych";
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(35, 100);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 2;
            this.btnStart.Text = "START";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnPrzesuńFigury
            // 
            this.btnPrzesuńFigury.Location = new System.Drawing.Point(35, 199);
            this.btnPrzesuńFigury.Name = "btnPrzesuńFigury";
            this.btnPrzesuńFigury.Size = new System.Drawing.Size(128, 37);
            this.btnPrzesuńFigury.TabIndex = 3;
            this.btnPrzesuńFigury.Text = "Zmień lokalizację figur geometrycznych";
            this.btnPrzesuńFigury.UseVisualStyleBackColor = true;
            this.btnPrzesuńFigury.Click += new System.EventHandler(this.btnPrzesuńFigury_Click);
            // 
            // chlbFiguryGeometryczne
            // 
            this.chlbFiguryGeometryczne.FormattingEnabled = true;
            this.chlbFiguryGeometryczne.Items.AddRange(new object[] {
            "Punkt",
            "Linia",
            "Elipsa",
            "Okrąg",
            "Prostokąt",
            "Kwadrat",
            "Wielokąt foremny"});
            this.chlbFiguryGeometryczne.Location = new System.Drawing.Point(740, 100);
            this.chlbFiguryGeometryczne.Name = "chlbFiguryGeometryczne";
            this.chlbFiguryGeometryczne.Size = new System.Drawing.Size(208, 169);
            this.chlbFiguryGeometryczne.TabIndex = 4;
            this.chlbFiguryGeometryczne.SelectedIndexChanged += new System.EventHandler(this.chlbFiguryGeometryczne_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(737, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(167, 44);
            this.label2.TabIndex = 5;
            this.label2.Text = "Zaznacz figury geometryczne, które mają być losowane i wyświetlane na planszy gra" +
    "ficznej";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // pbRysownica
            // 
            this.pbRysownica.BackColor = System.Drawing.Color.Transparent;
            this.pbRysownica.Location = new System.Drawing.Point(205, 61);
            this.pbRysownica.Name = "pbRysownica";
            this.pbRysownica.Size = new System.Drawing.Size(526, 381);
            this.pbRysownica.TabIndex = 6;
            this.pbRysownica.TabStop = false;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // FiguryGeometryczne
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(997, 537);
            this.Controls.Add(this.pbRysownica);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.chlbFiguryGeometryczne);
            this.Controls.Add(this.btnPrzesuńFigury);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtN);
            this.Name = "FiguryGeometryczne";
            this.Text = "Losowa prezentacja wybranych figur geometrycznych";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbRysownica)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtN;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnPrzesuńFigury;
        private System.Windows.Forms.CheckedListBox chlbFiguryGeometryczne;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pbRysownica;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Timer timer1;
    }
}

