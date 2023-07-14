namespace CajaBanco.Forms
{
    partial class Home
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.DepostioBT = new System.Windows.Forms.Button();
            this.retirobt = new System.Windows.Forms.Button();
            this.TransferenciaBt = new System.Windows.Forms.Button();
            this.AddmoneyBt = new System.Windows.Forms.Button();
            this.StartTrunoBt = new System.Windows.Forms.Button();
            this.CloseTrunoBt = new System.Windows.Forms.Button();
            this.minimizeBT = new System.Windows.Forms.Button();
            this.exitBT = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(93)))), ((int)(((byte)(109)))), ((int)(((byte)(126)))));
            this.panel1.Controls.Add(this.minimizeBT);
            this.panel1.Controls.Add(this.exitBT);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 59);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // DepostioBT
            // 
            this.DepostioBT.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(216)))), ((int)(((byte)(220)))));
            this.DepostioBT.FlatAppearance.BorderSize = 0;
            this.DepostioBT.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DepostioBT.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(139)))), ((int)(((byte)(150)))));
            this.DepostioBT.Location = new System.Drawing.Point(30, 80);
            this.DepostioBT.Margin = new System.Windows.Forms.Padding(0);
            this.DepostioBT.Name = "DepostioBT";
            this.DepostioBT.Size = new System.Drawing.Size(230, 48);
            this.DepostioBT.TabIndex = 6;
            this.DepostioBT.Text = "Deposito";
            this.DepostioBT.UseVisualStyleBackColor = false;
            // 
            // retirobt
            // 
            this.retirobt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(216)))), ((int)(((byte)(220)))));
            this.retirobt.FlatAppearance.BorderSize = 0;
            this.retirobt.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.retirobt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(139)))), ((int)(((byte)(150)))));
            this.retirobt.Location = new System.Drawing.Point(30, 155);
            this.retirobt.Margin = new System.Windows.Forms.Padding(0);
            this.retirobt.Name = "retirobt";
            this.retirobt.Size = new System.Drawing.Size(230, 48);
            this.retirobt.TabIndex = 7;
            this.retirobt.Text = "Retiro";
            this.retirobt.UseVisualStyleBackColor = false;
            // 
            // TransferenciaBt
            // 
            this.TransferenciaBt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(216)))), ((int)(((byte)(220)))));
            this.TransferenciaBt.FlatAppearance.BorderSize = 0;
            this.TransferenciaBt.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TransferenciaBt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(139)))), ((int)(((byte)(150)))));
            this.TransferenciaBt.Location = new System.Drawing.Point(30, 237);
            this.TransferenciaBt.Margin = new System.Windows.Forms.Padding(0);
            this.TransferenciaBt.Name = "TransferenciaBt";
            this.TransferenciaBt.Size = new System.Drawing.Size(230, 48);
            this.TransferenciaBt.TabIndex = 8;
            this.TransferenciaBt.Text = "Transferencia";
            this.TransferenciaBt.UseVisualStyleBackColor = false;
            // 
            // AddmoneyBt
            // 
            this.AddmoneyBt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(216)))), ((int)(((byte)(220)))));
            this.AddmoneyBt.FlatAppearance.BorderSize = 0;
            this.AddmoneyBt.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddmoneyBt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(139)))), ((int)(((byte)(150)))));
            this.AddmoneyBt.Location = new System.Drawing.Point(30, 334);
            this.AddmoneyBt.Margin = new System.Windows.Forms.Padding(0);
            this.AddmoneyBt.Name = "AddmoneyBt";
            this.AddmoneyBt.Size = new System.Drawing.Size(230, 48);
            this.AddmoneyBt.TabIndex = 9;
            this.AddmoneyBt.Text = "Agregar Dinero";
            this.AddmoneyBt.UseVisualStyleBackColor = false;
            // 
            // StartTrunoBt
            // 
            this.StartTrunoBt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(238)))), ((int)(((byte)(188)))));
            this.StartTrunoBt.FlatAppearance.BorderSize = 0;
            this.StartTrunoBt.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StartTrunoBt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(139)))), ((int)(((byte)(150)))));
            this.StartTrunoBt.Location = new System.Drawing.Point(326, 298);
            this.StartTrunoBt.Margin = new System.Windows.Forms.Padding(0);
            this.StartTrunoBt.Name = "StartTrunoBt";
            this.StartTrunoBt.Size = new System.Drawing.Size(230, 84);
            this.StartTrunoBt.TabIndex = 10;
            this.StartTrunoBt.Text = "Iniciar Turno";
            this.StartTrunoBt.UseVisualStyleBackColor = false;
            // 
            // CloseTrunoBt
            // 
            this.CloseTrunoBt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(188)))), ((int)(((byte)(188)))));
            this.CloseTrunoBt.FlatAppearance.BorderSize = 0;
            this.CloseTrunoBt.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CloseTrunoBt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(139)))), ((int)(((byte)(150)))));
            this.CloseTrunoBt.Location = new System.Drawing.Point(326, 188);
            this.CloseTrunoBt.Margin = new System.Windows.Forms.Padding(0);
            this.CloseTrunoBt.Name = "CloseTrunoBt";
            this.CloseTrunoBt.Size = new System.Drawing.Size(230, 84);
            this.CloseTrunoBt.TabIndex = 11;
            this.CloseTrunoBt.Text = "Cerrar Turno";
            this.CloseTrunoBt.UseVisualStyleBackColor = false;
            // 
            // minimizeBT
            // 
            this.minimizeBT.BackColor = System.Drawing.Color.Transparent;
            this.minimizeBT.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.minimizeBT.ForeColor = System.Drawing.SystemColors.ActiveBorder;
            this.minimizeBT.Location = new System.Drawing.Point(739, 3);
            this.minimizeBT.Name = "minimizeBT";
            this.minimizeBT.Size = new System.Drawing.Size(26, 20);
            this.minimizeBT.TabIndex = 13;
            this.minimizeBT.Text = "-";
            this.minimizeBT.UseVisualStyleBackColor = false;
            // 
            // exitBT
            // 
            this.exitBT.BackColor = System.Drawing.Color.Transparent;
            this.exitBT.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exitBT.ForeColor = System.Drawing.SystemColors.ActiveBorder;
            this.exitBT.Location = new System.Drawing.Point(771, 3);
            this.exitBT.Name = "exitBT";
            this.exitBT.Size = new System.Drawing.Size(26, 20);
            this.exitBT.TabIndex = 12;
            this.exitBT.Text = "X";
            this.exitBT.UseVisualStyleBackColor = false;
            // 
            // Home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.CloseTrunoBt);
            this.Controls.Add(this.StartTrunoBt);
            this.Controls.Add(this.AddmoneyBt);
            this.Controls.Add(this.TransferenciaBt);
            this.Controls.Add(this.retirobt);
            this.Controls.Add(this.DepostioBT);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Home";
            this.Text = "Home";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button DepostioBT;
        private System.Windows.Forms.Button retirobt;
        private System.Windows.Forms.Button TransferenciaBt;
        private System.Windows.Forms.Button AddmoneyBt;
        private System.Windows.Forms.Button StartTrunoBt;
        private System.Windows.Forms.Button CloseTrunoBt;
        private System.Windows.Forms.Button minimizeBT;
        private System.Windows.Forms.Button exitBT;
    }
}