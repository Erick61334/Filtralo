
namespace Filtramelo
{
    partial class Form2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form2));
            this.dgv_Usuarios = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Funcionando = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UltimoGuardado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Localidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btn_Reset1 = new System.Windows.Forms.Button();
            this.btn_Reset2 = new System.Windows.Forms.Button();
            this.btn_Reset3 = new System.Windows.Forms.Button();
            this.btn_Reset4 = new System.Windows.Forms.Button();
            this.btn_Reset5 = new System.Windows.Forms.Button();
            this.btn_SaveAndQui = new System.Windows.Forms.Button();
            this.lab_Estado1 = new System.Windows.Forms.Label();
            this.lab_Estado2 = new System.Windows.Forms.Label();
            this.btn_SalirSinGuardar = new System.Windows.Forms.Button();
            this.lab_HFE = new System.Windows.Forms.Label();
            this.lab_TE = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Usuarios)).BeginInit();
            this.SuspendLayout();
            // 
            // dgv_Usuarios
            // 
            this.dgv_Usuarios.AllowUserToAddRows = false;
            this.dgv_Usuarios.AllowUserToDeleteRows = false;
            this.dgv_Usuarios.BackgroundColor = System.Drawing.SystemColors.Highlight;
            this.dgv_Usuarios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Usuarios.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Funcionando,
            this.UltimoGuardado,
            this.Localidad});
            this.dgv_Usuarios.GridColor = System.Drawing.SystemColors.HotTrack;
            this.dgv_Usuarios.Location = new System.Drawing.Point(25, 12);
            this.dgv_Usuarios.Name = "dgv_Usuarios";
            this.dgv_Usuarios.ReadOnly = true;
            this.dgv_Usuarios.RowHeadersVisible = false;
            this.dgv_Usuarios.Size = new System.Drawing.Size(491, 329);
            this.dgv_Usuarios.TabIndex = 0;
            // 
            // Column1
            // 
            this.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Column1.HeaderText = "°";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column1.Width = 70;
            // 
            // Funcionando
            // 
            this.Funcionando.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Funcionando.HeaderText = "Celular";
            this.Funcionando.Name = "Funcionando";
            this.Funcionando.ReadOnly = true;
            this.Funcionando.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // UltimoGuardado
            // 
            this.UltimoGuardado.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.UltimoGuardado.HeaderText = "Compañia";
            this.UltimoGuardado.Name = "UltimoGuardado";
            this.UltimoGuardado.ReadOnly = true;
            this.UltimoGuardado.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Localidad
            // 
            this.Localidad.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Localidad.HeaderText = "Localidad";
            this.Localidad.Name = "Localidad";
            this.Localidad.ReadOnly = true;
            this.Localidad.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // btn_Reset1
            // 
            this.btn_Reset1.BackColor = System.Drawing.SystemColors.Control;
            this.btn_Reset1.Location = new System.Drawing.Point(543, 12);
            this.btn_Reset1.Name = "btn_Reset1";
            this.btn_Reset1.Size = new System.Drawing.Size(75, 23);
            this.btn_Reset1.TabIndex = 1;
            this.btn_Reset1.Text = "Filtro 1";
            this.btn_Reset1.UseVisualStyleBackColor = false;
            this.btn_Reset1.Click += new System.EventHandler(this.btn_Reset1_Click);
            // 
            // btn_Reset2
            // 
            this.btn_Reset2.Location = new System.Drawing.Point(542, 41);
            this.btn_Reset2.Name = "btn_Reset2";
            this.btn_Reset2.Size = new System.Drawing.Size(75, 23);
            this.btn_Reset2.TabIndex = 2;
            this.btn_Reset2.Text = "Filtro 2";
            this.btn_Reset2.UseVisualStyleBackColor = true;
            this.btn_Reset2.Click += new System.EventHandler(this.btn_Reset2_Click);
            // 
            // btn_Reset3
            // 
            this.btn_Reset3.Location = new System.Drawing.Point(542, 70);
            this.btn_Reset3.Name = "btn_Reset3";
            this.btn_Reset3.Size = new System.Drawing.Size(75, 23);
            this.btn_Reset3.TabIndex = 3;
            this.btn_Reset3.Text = "Filtro 3";
            this.btn_Reset3.UseVisualStyleBackColor = true;
            this.btn_Reset3.Click += new System.EventHandler(this.btn_Reset3_Click);
            // 
            // btn_Reset4
            // 
            this.btn_Reset4.Location = new System.Drawing.Point(542, 99);
            this.btn_Reset4.Name = "btn_Reset4";
            this.btn_Reset4.Size = new System.Drawing.Size(75, 23);
            this.btn_Reset4.TabIndex = 4;
            this.btn_Reset4.Text = "Filtro 4";
            this.btn_Reset4.UseVisualStyleBackColor = true;
            this.btn_Reset4.Click += new System.EventHandler(this.btn_Reset4_Click);
            // 
            // btn_Reset5
            // 
            this.btn_Reset5.Location = new System.Drawing.Point(542, 128);
            this.btn_Reset5.Name = "btn_Reset5";
            this.btn_Reset5.Size = new System.Drawing.Size(75, 23);
            this.btn_Reset5.TabIndex = 5;
            this.btn_Reset5.Text = "Filtro 5";
            this.btn_Reset5.UseVisualStyleBackColor = true;
            this.btn_Reset5.Click += new System.EventHandler(this.btn_Reset5_Click);
            // 
            // btn_SaveAndQui
            // 
            this.btn_SaveAndQui.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_SaveAndQui.Location = new System.Drawing.Point(533, 344);
            this.btn_SaveAndQui.Name = "btn_SaveAndQui";
            this.btn_SaveAndQui.Size = new System.Drawing.Size(96, 23);
            this.btn_SaveAndQui.TabIndex = 6;
            this.btn_SaveAndQui.Text = "Guardar y salir";
            this.btn_SaveAndQui.UseVisualStyleBackColor = true;
            this.btn_SaveAndQui.Click += new System.EventHandler(this.btn_SaveAndQui_Click);
            // 
            // lab_Estado1
            // 
            this.lab_Estado1.AutoSize = true;
            this.lab_Estado1.Location = new System.Drawing.Point(22, 349);
            this.lab_Estado1.Name = "lab_Estado1";
            this.lab_Estado1.Size = new System.Drawing.Size(46, 13);
            this.lab_Estado1.TabIndex = 7;
            this.lab_Estado1.Text = "Estado: ";
            // 
            // lab_Estado2
            // 
            this.lab_Estado2.AutoSize = true;
            this.lab_Estado2.Location = new System.Drawing.Point(63, 349);
            this.lab_Estado2.Name = "lab_Estado2";
            this.lab_Estado2.Size = new System.Drawing.Size(55, 13);
            this.lab_Estado2.TabIndex = 8;
            this.lab_Estado2.Text = "En espera";
            // 
            // btn_SalirSinGuardar
            // 
            this.btn_SalirSinGuardar.Location = new System.Drawing.Point(421, 344);
            this.btn_SalirSinGuardar.Name = "btn_SalirSinGuardar";
            this.btn_SalirSinGuardar.Size = new System.Drawing.Size(95, 23);
            this.btn_SalirSinGuardar.TabIndex = 9;
            this.btn_SalirSinGuardar.Text = "Salir sin guardar";
            this.btn_SalirSinGuardar.UseVisualStyleBackColor = true;
            this.btn_SalirSinGuardar.Click += new System.EventHandler(this.btn_SalirSinGuardar_Click);
            // 
            // lab_HFE
            // 
            this.lab_HFE.AutoSize = true;
            this.lab_HFE.Location = new System.Drawing.Point(519, 315);
            this.lab_HFE.Name = "lab_HFE";
            this.lab_HFE.Size = new System.Drawing.Size(115, 13);
            this.lab_HFE.TabIndex = 11;
            this.lab_HFE.Text = "(Falta lista de numeros)";
            // 
            // lab_TE
            // 
            this.lab_TE.AutoSize = true;
            this.lab_TE.Location = new System.Drawing.Point(519, 293);
            this.lab_TE.Name = "lab_TE";
            this.lab_TE.Size = new System.Drawing.Size(90, 13);
            this.lab_TE.TabIndex = 10;
            this.lab_TE.Text = "Tiempo estimado:";
            // 
            // Form2
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.ClientSize = new System.Drawing.Size(642, 370);
            this.Controls.Add(this.lab_HFE);
            this.Controls.Add(this.lab_TE);
            this.Controls.Add(this.btn_SalirSinGuardar);
            this.Controls.Add(this.lab_Estado2);
            this.Controls.Add(this.lab_Estado1);
            this.Controls.Add(this.btn_SaveAndQui);
            this.Controls.Add(this.btn_Reset5);
            this.Controls.Add(this.btn_Reset4);
            this.Controls.Add(this.btn_Reset3);
            this.Controls.Add(this.btn_Reset2);
            this.Controls.Add(this.btn_Reset1);
            this.Controls.Add(this.dgv_Usuarios);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Filtralo!!!";
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.Form2_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.Form2_DragEnter);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Usuarios)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv_Usuarios;
        private System.Windows.Forms.Button btn_Reset1;
        private System.Windows.Forms.Button btn_Reset2;
        private System.Windows.Forms.Button btn_Reset3;
        private System.Windows.Forms.Button btn_Reset4;
        private System.Windows.Forms.Button btn_Reset5;
        private System.Windows.Forms.Button btn_SaveAndQui;
        private System.Windows.Forms.Label lab_Estado1;
        private System.Windows.Forms.Label lab_Estado2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Funcionando;
        private System.Windows.Forms.DataGridViewTextBoxColumn UltimoGuardado;
        private System.Windows.Forms.DataGridViewTextBoxColumn Localidad;
        private System.Windows.Forms.Button btn_SalirSinGuardar;
        private System.Windows.Forms.Label lab_HFE;
        private System.Windows.Forms.Label lab_TE;
    }
}