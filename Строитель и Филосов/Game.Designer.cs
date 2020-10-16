namespace Строитель_и_Филосов
{
    partial class Game
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Game));
            this.houseP = new System.Windows.Forms.PictureBox();
            this.word = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.txt = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.houseP)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.word)).BeginInit();
            this.SuspendLayout();
            // 
            // houseP
            // 
            this.houseP.BackColor = System.Drawing.Color.Transparent;
            this.houseP.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.houseP.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.houseP.Location = new System.Drawing.Point(144, 118);
            this.houseP.Name = "houseP";
            this.houseP.Size = new System.Drawing.Size(209, 192);
            this.houseP.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.houseP.TabIndex = 0;
            this.houseP.TabStop = false;
            // 
            // word
            // 
            this.word.AllowUserToDeleteRows = false;
            this.word.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.word.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.word.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.word.BackgroundColor = System.Drawing.Color.White;
            this.word.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.word.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.word.ColumnHeadersVisible = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.word.DefaultCellStyle = dataGridViewCellStyle1;
            this.word.Enabled = false;
            this.word.Location = new System.Drawing.Point(151, 70);
            this.word.MultiSelect = false;
            this.word.Name = "word";
            this.word.ReadOnly = true;
            this.word.RowHeadersVisible = false;
            this.word.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.word.Size = new System.Drawing.Size(194, 24);
            this.word.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Tahoma", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(86, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(339, 24);
            this.label1.TabIndex = 2;
            this.label1.Text = "Отгадайте загаданное слово ;-)";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txt
            // 
            this.txt.AutoSize = true;
            this.txt.BackColor = System.Drawing.Color.Transparent;
            this.txt.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txt.ForeColor = System.Drawing.SystemColors.InfoText;
            this.txt.Location = new System.Drawing.Point(139, 312);
            this.txt.Name = "txt";
            this.txt.Size = new System.Drawing.Size(0, 13);
            this.txt.TabIndex = 3;
            this.txt.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Game
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(500, 500);
            this.Controls.Add(this.txt);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.word);
            this.Controls.Add(this.houseP);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "Game";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Строитель и Философ";
            this.Load += new System.EventHandler(this.Game_Load);
            this.Shown += new System.EventHandler(this.Game_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.houseP)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.word)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox houseP;
        private System.Windows.Forms.DataGridView word;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label txt;
    }
}