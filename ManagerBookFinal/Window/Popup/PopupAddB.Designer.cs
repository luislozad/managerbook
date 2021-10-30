
namespace ManagerBookFinal.Window.Popup
{
    partial class PopupAddB
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
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.Image = new ManagerBookFinal.Component.View.ImageCover();
            this.CardNumber = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.BtnAddFileURL = new System.Windows.Forms.Button();
            this.Url = new System.Windows.Forms.TextBox();
            this.LblUrl = new System.Windows.Forms.Label();
            this.CheckAutoDateLimit = new System.Windows.Forms.CheckBox();
            this.PaginaCompl = new System.Windows.Forms.NumericUpDown();
            this.LblPagTotal = new System.Windows.Forms.Label();
            this.Paginas = new System.Windows.Forms.NumericUpDown();
            this.LblPag = new System.Windows.Forms.Label();
            this.CapituloCompl = new System.Windows.Forms.NumericUpDown();
            this.LblCapTotal = new System.Windows.Forms.Label();
            this.Capitulos = new System.Windows.Forms.NumericUpDown();
            this.LblCap = new System.Windows.Forms.Label();
            this.DateLimit = new System.Windows.Forms.DateTimePicker();
            this.LblDateLimit = new System.Windows.Forms.Label();
            this.Title = new System.Windows.Forms.TextBox();
            this.LblTitle = new System.Windows.Forms.Label();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.BtnNewNote = new System.Windows.Forms.Button();
            this.NotesGrill = new System.Windows.Forms.FlowLayoutPanel();
            this.BtnCancelAdd = new ManagerBookFinal.Component.Button.BtnAdd();
            this.OpenFileDialogURL = new System.Windows.Forms.OpenFileDialog();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PaginaCompl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Paginas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CapituloCompl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Capitulos)).BeginInit();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel3, 0, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(112, 37);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 57.58065F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 42.41935F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(583, 620);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 13.53383F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 86.46616F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 209F));
            this.tableLayoutPanel2.Controls.Add(this.Image, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.CardNumber, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.panel1, 1, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(577, 351);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // Image
            // 
            this.Image.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Image.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Image.Location = new System.Drawing.Point(370, 3);
            this.Image.Name = "Image";
            this.Image.Size = new System.Drawing.Size(204, 345);
            this.Image.TabIndex = 0;
            // 
            // CardNumber
            // 
            this.CardNumber.AutoSize = true;
            this.CardNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CardNumber.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.CardNumber.Location = new System.Drawing.Point(3, 0);
            this.CardNumber.Name = "CardNumber";
            this.CardNumber.Size = new System.Drawing.Size(36, 27);
            this.CardNumber.TabIndex = 0;
            this.CardNumber.Text = "#1";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.BtnAddFileURL);
            this.panel1.Controls.Add(this.Url);
            this.panel1.Controls.Add(this.LblUrl);
            this.panel1.Controls.Add(this.CheckAutoDateLimit);
            this.panel1.Controls.Add(this.PaginaCompl);
            this.panel1.Controls.Add(this.LblPagTotal);
            this.panel1.Controls.Add(this.Paginas);
            this.panel1.Controls.Add(this.LblPag);
            this.panel1.Controls.Add(this.CapituloCompl);
            this.panel1.Controls.Add(this.LblCapTotal);
            this.panel1.Controls.Add(this.Capitulos);
            this.panel1.Controls.Add(this.LblCap);
            this.panel1.Controls.Add(this.DateLimit);
            this.panel1.Controls.Add(this.LblDateLimit);
            this.panel1.Controls.Add(this.Title);
            this.panel1.Controls.Add(this.LblTitle);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(52, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(312, 345);
            this.panel1.TabIndex = 1;
            // 
            // BtnAddFileURL
            // 
            this.BtnAddFileURL.Location = new System.Drawing.Point(282, 72);
            this.BtnAddFileURL.Name = "BtnAddFileURL";
            this.BtnAddFileURL.Size = new System.Drawing.Size(30, 27);
            this.BtnAddFileURL.TabIndex = 16;
            this.BtnAddFileURL.Text = "+";
            this.BtnAddFileURL.UseVisualStyleBackColor = true;
            this.BtnAddFileURL.Click += new System.EventHandler(this.BtnAddFileURL_Click);
            // 
            // Url
            // 
            this.Url.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Url.Location = new System.Drawing.Point(1, 72);
            this.Url.Name = "Url";
            this.Url.Size = new System.Drawing.Size(281, 27);
            this.Url.TabIndex = 15;
            // 
            // LblUrl
            // 
            this.LblUrl.AutoSize = true;
            this.LblUrl.Location = new System.Drawing.Point(3, 54);
            this.LblUrl.Name = "LblUrl";
            this.LblUrl.Size = new System.Drawing.Size(86, 15);
            this.LblUrl.TabIndex = 14;
            this.LblUrl.Text = "Url del archivo:";
            // 
            // CheckAutoDateLimit
            // 
            this.CheckAutoDateLimit.AutoSize = true;
            this.CheckAutoDateLimit.Location = new System.Drawing.Point(83, 106);
            this.CheckAutoDateLimit.Name = "CheckAutoDateLimit";
            this.CheckAutoDateLimit.Size = new System.Drawing.Size(15, 14);
            this.CheckAutoDateLimit.TabIndex = 13;
            this.CheckAutoDateLimit.UseVisualStyleBackColor = true;
            this.CheckAutoDateLimit.CheckedChanged += new System.EventHandler(this.CheckAutoDateLimit_CheckedChanged);
            // 
            // PaginaCompl
            // 
            this.PaginaCompl.Location = new System.Drawing.Point(3, 318);
            this.PaginaCompl.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.PaginaCompl.Name = "PaginaCompl";
            this.PaginaCompl.Size = new System.Drawing.Size(162, 23);
            this.PaginaCompl.TabIndex = 12;
            // 
            // LblPagTotal
            // 
            this.LblPagTotal.AutoSize = true;
            this.LblPagTotal.Location = new System.Drawing.Point(4, 300);
            this.LblPagTotal.Name = "LblPagTotal";
            this.LblPagTotal.Size = new System.Drawing.Size(122, 15);
            this.LblPagTotal.TabIndex = 11;
            this.LblPagTotal.Text = "Paginas completadas:";
            // 
            // Paginas
            // 
            this.Paginas.Location = new System.Drawing.Point(3, 270);
            this.Paginas.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.Paginas.Name = "Paginas";
            this.Paginas.Size = new System.Drawing.Size(162, 23);
            this.Paginas.TabIndex = 10;
            // 
            // LblPag
            // 
            this.LblPag.AutoSize = true;
            this.LblPag.Location = new System.Drawing.Point(4, 252);
            this.LblPag.Name = "LblPag";
            this.LblPag.Size = new System.Drawing.Size(95, 15);
            this.LblPag.TabIndex = 9;
            this.LblPag.Text = "Total de paginas:";
            // 
            // CapituloCompl
            // 
            this.CapituloCompl.Location = new System.Drawing.Point(2, 222);
            this.CapituloCompl.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.CapituloCompl.Name = "CapituloCompl";
            this.CapituloCompl.Size = new System.Drawing.Size(162, 23);
            this.CapituloCompl.TabIndex = 8;
            // 
            // LblCapTotal
            // 
            this.LblCapTotal.AutoSize = true;
            this.LblCapTotal.Location = new System.Drawing.Point(3, 204);
            this.LblCapTotal.Name = "LblCapTotal";
            this.LblCapTotal.Size = new System.Drawing.Size(132, 15);
            this.LblCapTotal.TabIndex = 7;
            this.LblCapTotal.Text = "Capitulos completados:";
            // 
            // Capitulos
            // 
            this.Capitulos.Location = new System.Drawing.Point(2, 173);
            this.Capitulos.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.Capitulos.Name = "Capitulos";
            this.Capitulos.Size = new System.Drawing.Size(162, 23);
            this.Capitulos.TabIndex = 6;
            // 
            // LblCap
            // 
            this.LblCap.AutoSize = true;
            this.LblCap.Location = new System.Drawing.Point(3, 155);
            this.LblCap.Name = "LblCap";
            this.LblCap.Size = new System.Drawing.Size(102, 15);
            this.LblCap.TabIndex = 5;
            this.LblCap.Text = "Total de capitulos:";
            // 
            // DateLimit
            // 
            this.DateLimit.Enabled = false;
            this.DateLimit.Location = new System.Drawing.Point(0, 123);
            this.DateLimit.Name = "DateLimit";
            this.DateLimit.Size = new System.Drawing.Size(312, 23);
            this.DateLimit.TabIndex = 4;
            // 
            // LblDateLimit
            // 
            this.LblDateLimit.AutoSize = true;
            this.LblDateLimit.Location = new System.Drawing.Point(3, 105);
            this.LblDateLimit.Name = "LblDateLimit";
            this.LblDateLimit.Size = new System.Drawing.Size(77, 15);
            this.LblDateLimit.TabIndex = 3;
            this.LblDateLimit.Text = "Fecha Limite:";
            // 
            // Title
            // 
            this.Title.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Title.Location = new System.Drawing.Point(0, 21);
            this.Title.Name = "Title";
            this.Title.Size = new System.Drawing.Size(312, 27);
            this.Title.TabIndex = 2;
            // 
            // LblTitle
            // 
            this.LblTitle.AutoSize = true;
            this.LblTitle.Location = new System.Drawing.Point(2, 3);
            this.LblTitle.Name = "LblTitle";
            this.LblTitle.Size = new System.Drawing.Size(40, 15);
            this.LblTitle.TabIndex = 1;
            this.LblTitle.Text = "Titulo:";
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 1;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Controls.Add(this.tableLayoutPanel4, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.NotesGrill, 0, 1);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 360);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.39689F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 85.60311F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(577, 257);
            this.tableLayoutPanel3.TabIndex = 1;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 2;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 82.66199F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 17.338F));
            this.tableLayoutPanel4.Controls.Add(this.BtnNewNote, 1, 0);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 1;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(571, 31);
            this.tableLayoutPanel4.TabIndex = 0;
            // 
            // BtnNewNote
            // 
            this.BtnNewNote.Location = new System.Drawing.Point(475, 3);
            this.BtnNewNote.Name = "BtnNewNote";
            this.BtnNewNote.Size = new System.Drawing.Size(93, 23);
            this.BtnNewNote.TabIndex = 0;
            this.BtnNewNote.Text = "+Nueva nota";
            this.BtnNewNote.UseVisualStyleBackColor = true;
            this.BtnNewNote.Click += new System.EventHandler(this.BtnNewNote_Click);
            // 
            // NotesGrill
            // 
            this.NotesGrill.AutoScroll = true;
            this.NotesGrill.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.NotesGrill.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.NotesGrill.Location = new System.Drawing.Point(3, 40);
            this.NotesGrill.MaximumSize = new System.Drawing.Size(571, 214);
            this.NotesGrill.Name = "NotesGrill";
            this.NotesGrill.Size = new System.Drawing.Size(571, 214);
            this.NotesGrill.TabIndex = 1;
            this.NotesGrill.WrapContents = false;
            // 
            // BtnCancelAdd
            // 
            this.BtnCancelAdd.Location = new System.Drawing.Point(274, 663);
            this.BtnCancelAdd.Name = "BtnCancelAdd";
            this.BtnCancelAdd.Size = new System.Drawing.Size(226, 61);
            this.BtnCancelAdd.TabIndex = 1;
            // 
            // PopupAddB
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 735);
            this.Controls.Add(this.BtnCancelAdd);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PopupAddB";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "PopupAddB";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PaginaCompl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Paginas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CapituloCompl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Capitulos)).EndInit();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private Component.Button.BtnAdd BtnCancelAdd;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private Component.View.ImageCover Image;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label CardNumber;
        private System.Windows.Forms.Label LblTitle;
        private System.Windows.Forms.TextBox Title;
        private System.Windows.Forms.Label LblDateLimit;
        private System.Windows.Forms.DateTimePicker DateLimit;
        private System.Windows.Forms.Label LblCap;
        private System.Windows.Forms.NumericUpDown Capitulos;
        private System.Windows.Forms.NumericUpDown CapituloCompl;
        private System.Windows.Forms.Label LblCapTotal;
        private System.Windows.Forms.NumericUpDown Paginas;
        private System.Windows.Forms.Label LblPag;
        private System.Windows.Forms.NumericUpDown PaginaCompl;
        private System.Windows.Forms.Label LblPagTotal;
        private System.Windows.Forms.CheckBox CheckAutoDateLimit;
        private System.Windows.Forms.TextBox Url;
        private System.Windows.Forms.Label LblUrl;
        private System.Windows.Forms.OpenFileDialog OpenFileDialogURL;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.Button BtnNewNote;
        private System.Windows.Forms.FlowLayoutPanel NotesGrill;
        private System.Windows.Forms.Button BtnAddFileURL;
    }
}