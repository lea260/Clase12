namespace Presentacion.Formularios
{
    partial class Principal
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
            this.lblbienvenido = new System.Windows.Forms.Label();
            this.lblusuario = new System.Windows.Forms.Label();
            this.btnAgregarPoductos = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblbienvenido
            // 
            this.lblbienvenido.AutoSize = true;
            this.lblbienvenido.Location = new System.Drawing.Point(135, 61);
            this.lblbienvenido.Name = "lblbienvenido";
            this.lblbienvenido.Size = new System.Drawing.Size(82, 17);
            this.lblbienvenido.TabIndex = 0;
            this.lblbienvenido.Text = "Bienvenido:";
            // 
            // lblusuario
            // 
            this.lblusuario.AutoSize = true;
            this.lblusuario.Location = new System.Drawing.Point(242, 61);
            this.lblusuario.Name = "lblusuario";
            this.lblusuario.Size = new System.Drawing.Size(46, 17);
            this.lblusuario.TabIndex = 1;
            this.lblusuario.Text = "label2";
            this.lblusuario.Click += new System.EventHandler(this.lblusuario_Click);
            // 
            // btnAgregarPoductos
            // 
            this.btnAgregarPoductos.Location = new System.Drawing.Point(493, 54);
            this.btnAgregarPoductos.Name = "btnAgregarPoductos";
            this.btnAgregarPoductos.Size = new System.Drawing.Size(195, 23);
            this.btnAgregarPoductos.TabIndex = 2;
            this.btnAgregarPoductos.Text = "Agregar Poductos";
            this.btnAgregarPoductos.UseVisualStyleBackColor = true;
            // 
            // Principal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnAgregarPoductos);
            this.Controls.Add(this.lblusuario);
            this.Controls.Add(this.lblbienvenido);
            this.Name = "Principal";
            this.Text = "Principal";
            this.Load += new System.EventHandler(this.Principal_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblbienvenido;
        private System.Windows.Forms.Label lblusuario;
        private System.Windows.Forms.Button btnAgregarPoductos;
    }
}