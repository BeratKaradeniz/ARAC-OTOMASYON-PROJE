namespace AracOtomasyon
{
    partial class KrediHesap
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(KrediHesap));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.bank = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.KrediName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.faiz = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.aylik = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toplam = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.basvuru = new System.Windows.Forms.DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.bank,
            this.KrediName,
            this.faiz,
            this.aylik,
            this.toplam,
            this.basvuru});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(800, 450);
            this.dataGridView1.TabIndex = 4;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // bank
            // 
            this.bank.HeaderText = "Banka";
            this.bank.Name = "bank";
            this.bank.ReadOnly = true;
            // 
            // KrediName
            // 
            this.KrediName.HeaderText = "Kredi";
            this.KrediName.Name = "KrediName";
            this.KrediName.ReadOnly = true;
            // 
            // faiz
            // 
            this.faiz.HeaderText = "Faiz Oranı";
            this.faiz.Name = "faiz";
            this.faiz.ReadOnly = true;
            // 
            // aylik
            // 
            this.aylik.HeaderText = "Aylık Taksit";
            this.aylik.Name = "aylik";
            this.aylik.ReadOnly = true;
            // 
            // toplam
            // 
            this.toplam.HeaderText = "Toplam Ödeme";
            this.toplam.Name = "toplam";
            this.toplam.ReadOnly = true;
            // 
            // basvuru
            // 
            this.basvuru.HeaderText = "Başvuru URL";
            this.basvuru.Name = "basvuru";
            this.basvuru.ReadOnly = true;
            this.basvuru.Text = "Hemen Başvur";
            // 
            // KrediHesap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dataGridView1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "KrediHesap";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Kredi";
            this.Load += new System.EventHandler(this.KrediHesap_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn bank;
        private System.Windows.Forms.DataGridViewTextBoxColumn KrediName;
        private System.Windows.Forms.DataGridViewTextBoxColumn faiz;
        private System.Windows.Forms.DataGridViewTextBoxColumn aylik;
        private System.Windows.Forms.DataGridViewTextBoxColumn toplam;
        private System.Windows.Forms.DataGridViewButtonColumn basvuru;
    }
}