
namespace ManagerBookFinal.Component.View
{
    partial class ContentR
    {
        /// <summary> 
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.Lectura = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.ContainerControlReading = new System.Windows.Forms.TableLayoutPanel();
            this.BtnResetReading = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.FechaInicioLectura = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.FechaFinLectura = new System.Windows.Forms.DateTimePicker();
            this.BtnCreateRead = new System.Windows.Forms.Button();
            this.ContentMain = new ManagerBookFinal.Component.View.Content();
            this.tableLayoutPanel3.SuspendLayout();
            this.ContainerControlReading.SuspendLayout();
            this.SuspendLayout();
            // 
            // Lectura
            // 
            this.Lectura.BackColor = System.Drawing.Color.WhiteSmoke;
            this.Lectura.Location = new System.Drawing.Point(0, 0);
            this.Lectura.Name = "Lectura";
            this.Lectura.Size = new System.Drawing.Size(200, 100);
            this.Lectura.TabIndex = 0;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 1;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Controls.Add(this.ContainerControlReading, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.ContentMain, 0, 1);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.663865F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 90.33614F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(900, 476);
            this.tableLayoutPanel3.TabIndex = 0;
            // 
            // ContainerControlReading
            // 
            this.ContainerControlReading.ColumnCount = 6;
            this.ContainerControlReading.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.ContainerControlReading.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 231F));
            this.ContainerControlReading.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 38F));
            this.ContainerControlReading.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 235F));
            this.ContainerControlReading.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 140F));
            this.ContainerControlReading.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 94F));
            this.ContainerControlReading.Controls.Add(this.BtnResetReading, 5, 0);
            this.ContainerControlReading.Controls.Add(this.label4, 0, 0);
            this.ContainerControlReading.Controls.Add(this.FechaInicioLectura, 1, 0);
            this.ContainerControlReading.Controls.Add(this.label5, 2, 0);
            this.ContainerControlReading.Controls.Add(this.FechaFinLectura, 3, 0);
            this.ContainerControlReading.Controls.Add(this.BtnCreateRead, 4, 0);
            this.ContainerControlReading.Enabled = false;
            this.ContainerControlReading.Location = new System.Drawing.Point(3, 3);
            this.ContainerControlReading.Name = "ContainerControlReading";
            this.ContainerControlReading.Padding = new System.Windows.Forms.Padding(5);
            this.ContainerControlReading.RowCount = 1;
            this.ContainerControlReading.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.ContainerControlReading.Size = new System.Drawing.Size(888, 38);
            this.ContainerControlReading.TabIndex = 2;
            // 
            // BtnResetReading
            // 
            this.BtnResetReading.BackColor = System.Drawing.SystemColors.Menu;
            this.BtnResetReading.Enabled = false;
            this.BtnResetReading.Location = new System.Drawing.Point(799, 8);
            this.BtnResetReading.Margin = new System.Windows.Forms.Padding(10, 3, 3, 3);
            this.BtnResetReading.Name = "BtnResetReading";
            this.BtnResetReading.Size = new System.Drawing.Size(71, 22);
            this.BtnResetReading.TabIndex = 5;
            this.BtnResetReading.Text = "Resetear";
            this.BtnResetReading.UseVisualStyleBackColor = false;
            this.BtnResetReading.Click += new System.EventHandler(this.BtnResetReading_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(8, 5);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(134, 28);
            this.label4.TabIndex = 0;
            this.label4.Text = "Datos de lectura:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FechaInicioLectura
            // 
            this.FechaInicioLectura.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FechaInicioLectura.Enabled = false;
            this.FechaInicioLectura.Location = new System.Drawing.Point(148, 8);
            this.FechaInicioLectura.Name = "FechaInicioLectura";
            this.FechaInicioLectura.Size = new System.Drawing.Size(225, 23);
            this.FechaInicioLectura.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label5.Location = new System.Drawing.Point(379, 5);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(32, 28);
            this.label5.TabIndex = 2;
            this.label5.Text = "al";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FechaFinLectura
            // 
            this.FechaFinLectura.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FechaFinLectura.Location = new System.Drawing.Point(417, 8);
            this.FechaFinLectura.Name = "FechaFinLectura";
            this.FechaFinLectura.Size = new System.Drawing.Size(229, 23);
            this.FechaFinLectura.TabIndex = 3;
            // 
            // BtnCreateRead
            // 
            this.BtnCreateRead.AutoSize = true;
            this.BtnCreateRead.BackColor = System.Drawing.SystemColors.Menu;
            this.BtnCreateRead.Location = new System.Drawing.Point(659, 8);
            this.BtnCreateRead.Margin = new System.Windows.Forms.Padding(10, 3, 3, 3);
            this.BtnCreateRead.Name = "BtnCreateRead";
            this.BtnCreateRead.Size = new System.Drawing.Size(127, 22);
            this.BtnCreateRead.TabIndex = 4;
            this.BtnCreateRead.Text = "Crear temporada";
            this.BtnCreateRead.UseVisualStyleBackColor = false;
            this.BtnCreateRead.Click += new System.EventHandler(this.BtnCreateRead_Click);
            // 
            // ContentMain
            // 
            this.ContentMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ContentMain.Location = new System.Drawing.Point(3, 48);
            this.ContentMain.Name = "ContentMain";
            this.ContentMain.Size = new System.Drawing.Size(894, 425);
            this.ContentMain.TabIndex = 3;
            // 
            // ContentR
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel3);
            this.Name = "ContentR";
            this.Size = new System.Drawing.Size(900, 476);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.ContainerControlReading.ResumeLayout(false);
            this.ContainerControlReading.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TabPage Lectura;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.TableLayoutPanel ContainerControlReading;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker FechaFinLectura;
        private System.Windows.Forms.Button BtnCreateRead;
        private System.Windows.Forms.Button BtnResetReading;
        private System.Windows.Forms.DateTimePicker FechaInicioLectura;
        private System.Windows.Forms.Label label4;
        private Content ContentMain;
    }
}
