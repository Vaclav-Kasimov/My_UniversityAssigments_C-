
namespace WinFormsApp1
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
            this.Plus_Button = new System.Windows.Forms.Button();
            this.Minus_Button = new System.Windows.Forms.Button();
            this.Scalar_Button = new System.Windows.Forms.Button();
            this.Mult_Button = new System.Windows.Forms.Button();
            this.TextBox_N = new System.Windows.Forms.TextBox();
            this.Length_Button = new System.Windows.Forms.Button();
            this.Ugol_Button = new System.Windows.Forms.Button();
            this.Collinear_Button = new System.Windows.Forms.Button();
            this.Sort_Button = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.TextBox_X2 = new System.Windows.Forms.TextBox();
            this.TextBox_Y2 = new System.Windows.Forms.TextBox();
            this.TextBox_Y1 = new System.Windows.Forms.TextBox();
            this.TextBox_X1 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // Plus_Button
            // 
            this.Plus_Button.Location = new System.Drawing.Point(102, 141);
            this.Plus_Button.Name = "Plus_Button";
            this.Plus_Button.Size = new System.Drawing.Size(84, 23);
            this.Plus_Button.TabIndex = 0;
            this.Plus_Button.Text = "+";
            this.Plus_Button.UseVisualStyleBackColor = true;
            this.Plus_Button.Click += new System.EventHandler(this.Plus_Button_Click);
            // 
            // Minus_Button
            // 
            this.Minus_Button.Location = new System.Drawing.Point(102, 170);
            this.Minus_Button.Name = "Minus_Button";
            this.Minus_Button.Size = new System.Drawing.Size(84, 23);
            this.Minus_Button.TabIndex = 1;
            this.Minus_Button.Text = "-";
            this.Minus_Button.UseVisualStyleBackColor = true;
            this.Minus_Button.Click += new System.EventHandler(this.Minus_Button_Click);
            // 
            // Scalar_Button
            // 
            this.Scalar_Button.Location = new System.Drawing.Point(102, 83);
            this.Scalar_Button.Name = "Scalar_Button";
            this.Scalar_Button.Size = new System.Drawing.Size(84, 52);
            this.Scalar_Button.TabIndex = 2;
            this.Scalar_Button.Text = "Скалярное умножение";
            this.Scalar_Button.UseVisualStyleBackColor = true;
            this.Scalar_Button.Click += new System.EventHandler(this.Scalar_Button_Click);
            // 
            // Mult_Button
            // 
            this.Mult_Button.Location = new System.Drawing.Point(192, 141);
            this.Mult_Button.Name = "Mult_Button";
            this.Mult_Button.Size = new System.Drawing.Size(84, 52);
            this.Mult_Button.TabIndex = 3;
            this.Mult_Button.Text = "Умножить на число:";
            this.Mult_Button.UseVisualStyleBackColor = true;
            this.Mult_Button.Click += new System.EventHandler(this.Mult_Button_Click);
            // 
            // TextBox_N
            // 
            this.TextBox_N.Location = new System.Drawing.Point(282, 157);
            this.TextBox_N.Name = "TextBox_N";
            this.TextBox_N.Size = new System.Drawing.Size(84, 23);
            this.TextBox_N.TabIndex = 4;
            this.TextBox_N.Text = "10";
            // 
            // Length_Button
            // 
            this.Length_Button.Location = new System.Drawing.Point(12, 170);
            this.Length_Button.Name = "Length_Button";
            this.Length_Button.Size = new System.Drawing.Size(84, 52);
            this.Length_Button.TabIndex = 5;
            this.Length_Button.Text = "Узнать длину";
            this.Length_Button.UseVisualStyleBackColor = true;
            this.Length_Button.Click += new System.EventHandler(this.Length_Button_Click);
            // 
            // Ugol_Button
            // 
            this.Ugol_Button.Location = new System.Drawing.Point(12, 83);
            this.Ugol_Button.Name = "Ugol_Button";
            this.Ugol_Button.Size = new System.Drawing.Size(84, 81);
            this.Ugol_Button.TabIndex = 6;
            this.Ugol_Button.Text = "Узнать угол между векторами";
            this.Ugol_Button.UseVisualStyleBackColor = true;
            this.Ugol_Button.Click += new System.EventHandler(this.Ugol_Button_Click);
            // 
            // Collinear_Button
            // 
            this.Collinear_Button.Location = new System.Drawing.Point(192, 83);
            this.Collinear_Button.Name = "Collinear_Button";
            this.Collinear_Button.Size = new System.Drawing.Size(174, 52);
            this.Collinear_Button.TabIndex = 7;
            this.Collinear_Button.Text = "Определить коллинеарность векторов";
            this.Collinear_Button.UseVisualStyleBackColor = true;
            this.Collinear_Button.Click += new System.EventHandler(this.Collinear_Button_Click);
            // 
            // Sort_Button
            // 
            this.Sort_Button.Location = new System.Drawing.Point(102, 199);
            this.Sort_Button.Name = "Sort_Button";
            this.Sort_Button.Size = new System.Drawing.Size(264, 23);
            this.Sort_Button.TabIndex = 8;
            this.Sort_Button.Text = "Отсортировать массив по убыванию длины";
            this.Sort_Button.UseVisualStyleBackColor = true;
            this.Sort_Button.Click += new System.EventHandler(this.Sort_Button_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 15);
            this.label1.TabIndex = 9;
            this.label1.Text = "Основной вектор ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(222, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(144, 15);
            this.label2.TabIndex = 10;
            this.label2.Text = "Дополнительный вектор";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 33);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(22, 15);
            this.label3.TabIndex = 11;
            this.label3.Text = "X=";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(222, 33);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(22, 15);
            this.label4.TabIndex = 12;
            this.label4.Text = "X=";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 57);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(22, 15);
            this.label5.TabIndex = 13;
            this.label5.Text = "Y=";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(222, 57);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(22, 15);
            this.label6.TabIndex = 13;
            this.label6.Text = "Y=";
            // 
            // TextBox_X2
            // 
            this.TextBox_X2.Location = new System.Drawing.Point(250, 30);
            this.TextBox_X2.Name = "TextBox_X2";
            this.TextBox_X2.Size = new System.Drawing.Size(116, 23);
            this.TextBox_X2.TabIndex = 14;
            this.TextBox_X2.Text = "0";
            // 
            // TextBox_Y2
            // 
            this.TextBox_Y2.Location = new System.Drawing.Point(250, 54);
            this.TextBox_Y2.Name = "TextBox_Y2";
            this.TextBox_Y2.Size = new System.Drawing.Size(116, 23);
            this.TextBox_Y2.TabIndex = 14;
            this.TextBox_Y2.Text = "1";
            // 
            // TextBox_Y1
            // 
            this.TextBox_Y1.Location = new System.Drawing.Point(40, 54);
            this.TextBox_Y1.Name = "TextBox_Y1";
            this.TextBox_Y1.Size = new System.Drawing.Size(116, 23);
            this.TextBox_Y1.TabIndex = 15;
            this.TextBox_Y1.Text = "0";
            // 
            // TextBox_X1
            // 
            this.TextBox_X1.Location = new System.Drawing.Point(40, 30);
            this.TextBox_X1.Name = "TextBox_X1";
            this.TextBox_X1.Size = new System.Drawing.Size(116, 23);
            this.TextBox_X1.TabIndex = 16;
            this.TextBox_X1.Text = "1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(384, 240);
            this.Controls.Add(this.TextBox_Y1);
            this.Controls.Add(this.TextBox_X1);
            this.Controls.Add(this.TextBox_Y2);
            this.Controls.Add(this.TextBox_X2);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Sort_Button);
            this.Controls.Add(this.Collinear_Button);
            this.Controls.Add(this.Ugol_Button);
            this.Controls.Add(this.Length_Button);
            this.Controls.Add(this.TextBox_N);
            this.Controls.Add(this.Mult_Button);
            this.Controls.Add(this.Scalar_Button);
            this.Controls.Add(this.Minus_Button);
            this.Controls.Add(this.Plus_Button);
            this.Name = "Form1";
            this.Text = "Векторный калькулятор";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Plus_Button;
        private System.Windows.Forms.Button Minus_Button;
        private System.Windows.Forms.Button Scalar_Button;
        private System.Windows.Forms.Button Mult_Button;
        private System.Windows.Forms.TextBox TextBox_N;
        private System.Windows.Forms.Button Length_Button;
        private System.Windows.Forms.Button Ugol_Button;
        private System.Windows.Forms.Button Collinear_Button;
        private System.Windows.Forms.Button Sort_Button;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox TextBox_X2;
        private System.Windows.Forms.TextBox TextBox_Y2;
        private System.Windows.Forms.TextBox TextBox_Y1;
        private System.Windows.Forms.TextBox TextBox_X1;
    }
}

