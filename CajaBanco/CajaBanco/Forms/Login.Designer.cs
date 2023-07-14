namespace CajaBanco
{
    partial class Login
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            this.panel1 = new System.Windows.Forms.Panel();
            this.minimizeBT = new System.Windows.Forms.Button();
            this.exitBT = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.UserTxt = new System.Windows.Forms.TextBox();
            this.PassTxt = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.LoginBT = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(93)))), ((int)(((byte)(109)))), ((int)(((byte)(126)))));
            this.panel1.Controls.Add(this.minimizeBT);
            this.panel1.Controls.Add(this.exitBT);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(312, 75);
            this.panel1.TabIndex = 0;
            // 
            // minimizeBT
            // 
            this.minimizeBT.BackColor = System.Drawing.Color.Transparent;
            this.minimizeBT.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.minimizeBT.ForeColor = System.Drawing.SystemColors.ActiveBorder;
            this.minimizeBT.Location = new System.Drawing.Point(251, 3);
            this.minimizeBT.Name = "minimizeBT";
            this.minimizeBT.Size = new System.Drawing.Size(26, 20);
            this.minimizeBT.TabIndex = 2;
            this.minimizeBT.Text = "-";
            this.minimizeBT.UseVisualStyleBackColor = false;
            this.minimizeBT.Click += new System.EventHandler(this.button2_Click);
            // 
            // exitBT
            // 
            this.exitBT.BackColor = System.Drawing.Color.Transparent;
            this.exitBT.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exitBT.ForeColor = System.Drawing.SystemColors.ActiveBorder;
            this.exitBT.Location = new System.Drawing.Point(283, 3);
            this.exitBT.Name = "exitBT";
            this.exitBT.Size = new System.Drawing.Size(26, 20);
            this.exitBT.TabIndex = 1;
            this.exitBT.Text = "X";
            this.exitBT.UseVisualStyleBackColor = false;
            this.exitBT.Click += new System.EventHandler(this.button1_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(47)))), ((int)(((byte)(60)))));
            this.label3.Location = new System.Drawing.Point(3, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(158, 55);
            this.label3.TabIndex = 0;
            this.label3.Text = "Log In";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(31, 130);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(241, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "_______________________________________";
            // 
            // UserTxt
            // 
            this.UserTxt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(245)))), ((int)(((byte)(251)))));
            this.UserTxt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.UserTxt.Font = new System.Drawing.Font("Microsoft Tai Le", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UserTxt.Location = new System.Drawing.Point(34, 121);
            this.UserTxt.Name = "UserTxt";
            this.UserTxt.Size = new System.Drawing.Size(238, 20);
            this.UserTxt.TabIndex = 2;
            this.UserTxt.Text = "Ingrese su usuario";
            this.UserTxt.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            this.UserTxt.Enter += new System.EventHandler(this.UserTxt_Enter);
            this.UserTxt.Leave += new System.EventHandler(this.UserTxt_Leave);
            // 
            // PassTxt
            // 
            this.PassTxt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(245)))), ((int)(((byte)(251)))));
            this.PassTxt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.PassTxt.Font = new System.Drawing.Font("Microsoft Tai Le", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PassTxt.Location = new System.Drawing.Point(34, 194);
            this.PassTxt.Name = "PassTxt";
            this.PassTxt.Size = new System.Drawing.Size(238, 20);
            this.PassTxt.TabIndex = 4;
            this.PassTxt.Text = "Ingrese su contraseña";
            this.PassTxt.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            this.PassTxt.Enter += new System.EventHandler(this.PassTxt_Enter);
            this.PassTxt.Leave += new System.EventHandler(this.PassTxt_Leave);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(31, 203);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(241, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "_______________________________________";
            // 
            // LoginBT
            // 
            this.LoginBT.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(216)))), ((int)(((byte)(220)))));
            this.LoginBT.FlatAppearance.BorderSize = 0;
            this.LoginBT.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LoginBT.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(139)))), ((int)(((byte)(150)))));
            this.LoginBT.Location = new System.Drawing.Point(34, 267);
            this.LoginBT.Margin = new System.Windows.Forms.Padding(0);
            this.LoginBT.Name = "LoginBT";
            this.LoginBT.Size = new System.Drawing.Size(230, 48);
            this.LoginBT.TabIndex = 5;
            this.LoginBT.Text = "Iniciar Sesión";
            this.LoginBT.UseVisualStyleBackColor = false;
            this.LoginBT.Click += new System.EventHandler(this.LoginBT_Click);
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(245)))), ((int)(((byte)(251)))));
            this.ClientSize = new System.Drawing.Size(312, 379);
            this.Controls.Add(this.LoginBT);
            this.Controls.Add(this.PassTxt);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.UserTxt);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            this.Load += new System.EventHandler(this.Login_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox UserTxt;
        private System.Windows.Forms.TextBox PassTxt;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button LoginBT;
        private System.Windows.Forms.Button exitBT;
        private System.Windows.Forms.Button minimizeBT;
    }
}