
namespace ManagerBookFinal.Component.View
{
    partial class ItemN
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.Number = new System.Windows.Forms.Label();
            this.Title = new System.Windows.Forms.Label();
            this.BtnEditNote = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 22.31638F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 77.68362F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tableLayoutPanel1.Controls.Add(this.Number, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.Title, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.BtnEditNote, 2, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(352, 57);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // Number
            // 
            this.Number.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Number.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.Number.Location = new System.Drawing.Point(3, 0);
            this.Number.Name = "Number";
            this.Number.Size = new System.Drawing.Size(66, 57);
            this.Number.TabIndex = 0;
            this.Number.Text = "#1";
            this.Number.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Title
            // 
            this.Title.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Title.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Title.Location = new System.Drawing.Point(75, 0);
            this.Title.Name = "Title";
            this.Title.Size = new System.Drawing.Size(245, 57);
            this.Title.TabIndex = 1;
            this.Title.Text = "Titulo";
            this.Title.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // BtnEditNote
            // 
            this.BtnEditNote.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BtnEditNote.Location = new System.Drawing.Point(326, 3);
            this.BtnEditNote.Name = "BtnEditNote";
            this.BtnEditNote.Size = new System.Drawing.Size(23, 51);
            this.BtnEditNote.TabIndex = 2;
            this.BtnEditNote.Text = "✏";
            this.BtnEditNote.UseVisualStyleBackColor = true;
            this.BtnEditNote.Click += new System.EventHandler(this.BtnEditNote_Click);
            // 
            // ItemN
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "ItemN";
            this.Size = new System.Drawing.Size(352, 57);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label Number;
        private System.Windows.Forms.Label Title;
        private System.Windows.Forms.Button BtnEditNote;
    }
}
