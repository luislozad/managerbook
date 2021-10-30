
namespace ManagerBookFinal.Window.Popup
{
    partial class PopupAddT
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.Image = new ManagerBookFinal.Component.View.ImageCover();
            this.panel2 = new System.Windows.Forms.Panel();
            this.LblTitulo = new System.Windows.Forms.Label();
            this.Title = new System.Windows.Forms.TextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.DateLimit = new System.Windows.Forms.DateTimePicker();
            this.LblDateLimit = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.BtnAdd = new ManagerBookFinal.Component.Button.BtnAdd();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel3, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.panel4, 0, 3);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(98, 37);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 77.61732F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 22.38267F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 55F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 91F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(588, 424);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.Image);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(582, 209);
            this.panel1.TabIndex = 0;
            // 
            // Image
            // 
            this.Image.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Image.Location = new System.Drawing.Point(129, 2);
            this.Image.Name = "Image";
            this.Image.Size = new System.Drawing.Size(322, 207);
            this.Image.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.LblTitulo);
            this.panel2.Controls.Add(this.Title);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 218);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(582, 56);
            this.panel2.TabIndex = 1;
            // 
            // LblTitulo
            // 
            this.LblTitulo.AutoSize = true;
            this.LblTitulo.Location = new System.Drawing.Point(127, 9);
            this.LblTitulo.Name = "LblTitulo";
            this.LblTitulo.Size = new System.Drawing.Size(40, 15);
            this.LblTitulo.TabIndex = 1;
            this.LblTitulo.Text = "Titulo:";
            // 
            // Title
            // 
            this.Title.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Title.Location = new System.Drawing.Point(127, 27);
            this.Title.Name = "Title";
            this.Title.Size = new System.Drawing.Size(324, 29);
            this.Title.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.DateLimit);
            this.panel3.Controls.Add(this.LblDateLimit);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(3, 280);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(582, 49);
            this.panel3.TabIndex = 2;
            // 
            // DateLimit
            // 
            this.DateLimit.Location = new System.Drawing.Point(127, 23);
            this.DateLimit.Name = "DateLimit";
            this.DateLimit.Size = new System.Drawing.Size(324, 23);
            this.DateLimit.TabIndex = 4;
            // 
            // LblDateLimit
            // 
            this.LblDateLimit.AutoSize = true;
            this.LblDateLimit.Location = new System.Drawing.Point(127, 5);
            this.LblDateLimit.Name = "LblDateLimit";
            this.LblDateLimit.Size = new System.Drawing.Size(74, 15);
            this.LblDateLimit.TabIndex = 3;
            this.LblDateLimit.Text = "Fecha limite:";
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.BtnAdd);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(3, 335);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(582, 86);
            this.panel4.TabIndex = 3;
            // 
            // BtnAdd
            // 
            this.BtnAdd.Location = new System.Drawing.Point(169, 22);
            this.BtnAdd.Name = "BtnAdd";
            this.BtnAdd.Size = new System.Drawing.Size(226, 61);
            this.BtnAdd.TabIndex = 0;
            // 
            // PopupAddT
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 495);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PopupAddT";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "PopupAddT";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox Title;
        private System.Windows.Forms.Label LblTitulo;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label LblDateLimit;
        private System.Windows.Forms.DateTimePicker DateLimit;
        private System.Windows.Forms.Panel panel4;
        private Component.Button.BtnAdd BtnAdd;
        private Component.View.ImageCover Image;
    }
}