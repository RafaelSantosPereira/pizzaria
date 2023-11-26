namespace M10e11_progeto_final
{
    partial class form_lista
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
            this.ingredientes = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // ingredientes
            // 
            this.ingredientes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ingredientes.Font = new System.Drawing.Font("Microsoft YaHei", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ingredientes.FormattingEnabled = true;
            this.ingredientes.ItemHeight = 20;
            this.ingredientes.Location = new System.Drawing.Point(0, 0);
            this.ingredientes.Name = "ingredientes";
            this.ingredientes.Size = new System.Drawing.Size(120, 95);
            this.ingredientes.TabIndex = 0;
            // 
            // form_lista
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.ClientSize = new System.Drawing.Size(120, 95);
            this.Controls.Add(this.ingredientes);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "form_lista";
            this.Text = "Ingredientes";
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.ListBox ingredientes;
    }
}