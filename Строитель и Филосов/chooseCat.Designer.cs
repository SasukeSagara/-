namespace Строитель_и_Филосов
{
    partial class chooseCat
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(chooseCat));
            this.nickName = new System.Windows.Forms.TextBox();
            this.next = new System.Windows.Forms.Button();
            this.errMark = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.errMark2 = new System.Windows.Forms.Label();
            this.categoryListDropdown = new System.Windows.Forms.ComboBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.SuspendLayout();
            // 
            // nickName
            // 
            this.nickName.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.nickName.Location = new System.Drawing.Point(84, 95);
            this.nickName.MaxLength = 25;
            this.nickName.Name = "nickName";
            this.nickName.Size = new System.Drawing.Size(330, 24);
            this.nickName.TabIndex = 1;
            this.nickName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nickName.WordWrap = false;
            this.nickName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.nickName_KeyDown);
            // 
            // next
            // 
            this.next.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.next.Location = new System.Drawing.Point(207, 355);
            this.next.Name = "next";
            this.next.Size = new System.Drawing.Size(84, 27);
            this.next.TabIndex = 0;
            this.next.Text = "Играть";
            this.next.UseVisualStyleBackColor = true;
            this.next.Click += new System.EventHandler(this.next_Click);
            // 
            // errMark
            // 
            this.errMark.AutoSize = true;
            this.errMark.BackColor = System.Drawing.Color.Transparent;
            this.errMark.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.errMark.ForeColor = System.Drawing.Color.Red;
            this.errMark.Location = new System.Drawing.Point(62, 97);
            this.errMark.Name = "errMark";
            this.errMark.Size = new System.Drawing.Size(20, 25);
            this.errMark.TabIndex = 0;
            this.errMark.Text = "*";
            this.errMark.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(79, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(174, 19);
            this.label1.TabIndex = 2;
            this.label1.Text = "Введите Ваше имя:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(79, 194);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(238, 19);
            this.label2.TabIndex = 0;
            this.label2.Text = "Выберите категорию слов:";
            // 
            // errMark2
            // 
            this.errMark2.AutoSize = true;
            this.errMark2.BackColor = System.Drawing.Color.Transparent;
            this.errMark2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.errMark2.ForeColor = System.Drawing.Color.Red;
            this.errMark2.Location = new System.Drawing.Point(62, 242);
            this.errMark2.Name = "errMark2";
            this.errMark2.Size = new System.Drawing.Size(20, 25);
            this.errMark2.TabIndex = 0;
            this.errMark2.Text = "*";
            this.errMark2.Visible = false;
            // 
            // categoryListDropdown
            // 
            this.categoryListDropdown.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.categoryListDropdown.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.categoryListDropdown.Font = new System.Drawing.Font("Tahoma", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.categoryListDropdown.FormattingEnabled = true;
            this.categoryListDropdown.Location = new System.Drawing.Point(84, 238);
            this.categoryListDropdown.Margin = new System.Windows.Forms.Padding(2);
            this.categoryListDropdown.MaxDropDownItems = 20;
            this.categoryListDropdown.Name = "categoryListDropdown";
            this.categoryListDropdown.Size = new System.Drawing.Size(330, 24);
            this.categoryListDropdown.Sorted = true;
            this.categoryListDropdown.TabIndex = 2;
            // 
            // chooseCat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Строитель_и_Филосов.Properties.Resources.back0;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(500, 400);
            this.Controls.Add(this.categoryListDropdown);
            this.Controls.Add(this.errMark2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.errMark);
            this.Controls.Add(this.next);
            this.Controls.Add(this.nickName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "chooseCat";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Выбор категрии";
            this.Load += new System.EventHandler(this.registration_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox nickName;
        private System.Windows.Forms.Button next;
        private System.Windows.Forms.Label errMark;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label errMark2;
        private System.Windows.Forms.ComboBox categoryListDropdown;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}