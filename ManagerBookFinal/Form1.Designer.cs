
namespace ManagerBookFinal
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.TabView = new System.Windows.Forms.TabControl();
            this.Temporadas = new System.Windows.Forms.TabPage();
            this.MainView = new ManagerBookFinal.Component.View.Content();
            this.Libros = new System.Windows.Forms.TabPage();
            this.BookView = new ManagerBookFinal.Component.View.Content();
            this.Lectura = new System.Windows.Forms.TabPage();
            this.ReadView = new ManagerBookFinal.Component.View.ContentR();
            this.panel1.SuspendLayout();
            this.TabView.SuspendLayout();
            this.Temporadas.SuspendLayout();
            this.Libros.SuspendLayout();
            this.Lectura.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.TabView);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(10);
            this.panel1.Size = new System.Drawing.Size(928, 524);
            this.panel1.TabIndex = 0;
            // 
            // TabView
            // 
            this.TabView.Controls.Add(this.Temporadas);
            this.TabView.Controls.Add(this.Libros);
            this.TabView.Controls.Add(this.Lectura);
            this.TabView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TabView.Location = new System.Drawing.Point(10, 10);
            this.TabView.Name = "TabView";
            this.TabView.SelectedIndex = 0;
            this.TabView.Size = new System.Drawing.Size(908, 504);
            this.TabView.TabIndex = 0;
            // 
            // Temporadas
            // 
            this.Temporadas.BackColor = System.Drawing.Color.WhiteSmoke;
            this.Temporadas.CausesValidation = false;
            this.Temporadas.Controls.Add(this.MainView);
            this.Temporadas.Location = new System.Drawing.Point(4, 24);
            this.Temporadas.Name = "Temporadas";
            this.Temporadas.Padding = new System.Windows.Forms.Padding(3);
            this.Temporadas.Size = new System.Drawing.Size(900, 476);
            this.Temporadas.TabIndex = 0;
            this.Temporadas.Text = "Temporadas";
            // 
            // MainView
            // 
            this.MainView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainView.Location = new System.Drawing.Point(3, 3);
            this.MainView.Name = "MainView";
            this.MainView.Size = new System.Drawing.Size(894, 470);
            this.MainView.TabIndex = 0;
            // 
            // Libros
            // 
            this.Libros.BackColor = System.Drawing.Color.WhiteSmoke;
            this.Libros.Controls.Add(this.BookView);
            this.Libros.Location = new System.Drawing.Point(4, 24);
            this.Libros.Name = "Libros";
            this.Libros.Padding = new System.Windows.Forms.Padding(3);
            this.Libros.Size = new System.Drawing.Size(900, 476);
            this.Libros.TabIndex = 1;
            this.Libros.Text = "Libros";
            // 
            // BookView
            // 
            this.BookView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BookView.Enabled = false;
            this.BookView.Location = new System.Drawing.Point(3, 3);
            this.BookView.Name = "BookView";
            this.BookView.Size = new System.Drawing.Size(894, 470);
            this.BookView.TabIndex = 0;
            // 
            // Lectura
            // 
            this.Lectura.BackColor = System.Drawing.Color.WhiteSmoke;
            this.Lectura.Controls.Add(this.ReadView);
            this.Lectura.Location = new System.Drawing.Point(4, 24);
            this.Lectura.Name = "Lectura";
            this.Lectura.Padding = new System.Windows.Forms.Padding(3);
            this.Lectura.Size = new System.Drawing.Size(900, 476);
            this.Lectura.TabIndex = 2;
            this.Lectura.Text = "Lectura";
            // 
            // ReadView
            // 
            this.ReadView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ReadView.Location = new System.Drawing.Point(3, 3);
            this.ReadView.Name = "ReadView";
            this.ReadView.Size = new System.Drawing.Size(894, 470);
            this.ReadView.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(928, 524);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.panel1.ResumeLayout(false);
            this.TabView.ResumeLayout(false);
            this.Temporadas.ResumeLayout(false);
            this.Libros.ResumeLayout(false);
            this.Lectura.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TabControl TabView;
        private System.Windows.Forms.TabPage Temporadas;
        private System.Windows.Forms.TabPage Libros;
        private Component.View.Content MainView;
        private System.Windows.Forms.TabPage Lectura;
        private Component.View.Content BookView;
        private Component.View.ContentR ReadView;
    }
}

