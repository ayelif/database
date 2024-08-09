namespace database2
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
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            textBoxTelefon = new TextBox();
            textBoxUrunAdi = new TextBox();
            textBoxTutar = new TextBox();
            textBoxOdenenTutar = new TextBox();
            dateTimePicker1 = new DateTimePicker();
            button1 = new Button();
            button2 = new Button();
            buttonSil = new Button();
            listBox1 = new ListBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            SuspendLayout();
            // 
            // textBox1
            // 
            textBox1.Location = new Point(126, 18);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(125, 27);
            textBox1.TabIndex = 0;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(126, 85);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(125, 27);
            textBox2.TabIndex = 1;
            // 
            // textBoxTelefon
            // 
            textBoxTelefon.Location = new Point(126, 143);
            textBoxTelefon.Name = "textBoxTelefon";
            textBoxTelefon.Size = new Size(125, 27);
            textBoxTelefon.TabIndex = 2;
            // 
            // textBoxUrunAdi
            // 
            textBoxUrunAdi.Location = new Point(126, 210);
            textBoxUrunAdi.Name = "textBoxUrunAdi";
            textBoxUrunAdi.Size = new Size(125, 27);
            textBoxUrunAdi.TabIndex = 3;
            // 
            // textBoxTutar
            // 
            textBoxTutar.Location = new Point(126, 264);
            textBoxTutar.Name = "textBoxTutar";
            textBoxTutar.Size = new Size(125, 27);
            textBoxTutar.TabIndex = 4;
            // 
            // textBoxOdenenTutar
            // 
            textBoxOdenenTutar.Location = new Point(126, 333);
            textBoxOdenenTutar.Name = "textBoxOdenenTutar";
            textBoxOdenenTutar.Size = new Size(125, 27);
            textBoxOdenenTutar.TabIndex = 5;
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Location = new Point(126, 383);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(250, 27);
            dateTimePicker1.TabIndex = 6;
            // 
            // button1
            // 
            button1.Location = new Point(465, 89);
            button1.Name = "button1";
            button1.Size = new Size(94, 29);
            button1.TabIndex = 7;
            button1.Text = "Ekle";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(465, 141);
            button2.Name = "button2";
            button2.Size = new Size(94, 29);
            button2.TabIndex = 8;
            button2.Text = "Ara";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // buttonSil
            // 
            buttonSil.Location = new Point(465, 208);
            buttonSil.Name = "buttonSil";
            buttonSil.Size = new Size(94, 29);
            buttonSil.TabIndex = 9;
            buttonSil.Text = "Sil";
            buttonSil.UseVisualStyleBackColor = true;
            buttonSil.Click += buttonSil_Click;
            // 
            // listBox1
            // 
            listBox1.FormattingEnabled = true;
            listBox1.ItemHeight = 20;
            listBox1.Location = new Point(126, 445);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(497, 104);
            listBox1.TabIndex = 10;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(46, 18);
            label1.Name = "label1";
            label1.Size = new Size(28, 20);
            label1.TabIndex = 11;
            label1.Text = "Ad";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(46, 85);
            label2.Name = "label2";
            label2.Size = new Size(50, 20);
            label2.TabIndex = 12;
            label2.Text = "Soyad";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(46, 141);
            label3.Name = "label3";
            label3.Size = new Size(58, 20);
            label3.TabIndex = 13;
            label3.Text = "Telefon";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(46, 212);
            label4.Name = "label4";
            label4.Size = new Size(40, 20);
            label4.TabIndex = 14;
            label4.Text = "Ürün";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(46, 271);
            label5.Name = "label5";
            label5.Size = new Size(43, 20);
            label5.TabIndex = 15;
            label5.Text = "Tutar";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(21, 340);
            label6.Name = "label6";
            label6.Size = new Size(99, 20);
            label6.TabIndex = 16;
            label6.Text = "Ödenen Tutar";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 561);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(listBox1);
            Controls.Add(buttonSil);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(dateTimePicker1);
            Controls.Add(textBoxOdenenTutar);
            Controls.Add(textBoxTutar);
            Controls.Add(textBoxUrunAdi);
            Controls.Add(textBoxTelefon);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBox1;
        private TextBox textBox2;
        private TextBox textBoxTelefon;
        private TextBox textBoxUrunAdi;
        private TextBox textBoxTutar;
        private TextBox textBoxOdenenTutar;
        private DateTimePicker dateTimePicker1;
        private Button button1;
        private Button button2;
        private Button buttonSil;
        private ListBox listBox1;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
    }
}
