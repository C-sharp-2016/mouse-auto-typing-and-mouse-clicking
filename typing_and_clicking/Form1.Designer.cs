namespace typing_and_clicking
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.timer3 = new System.Windows.Forms.Timer(this.components);
            this.label7 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.sound_duration_label8 = new System.Windows.Forms.Label();
            this.sound_duration_textBox5 = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.sounds_time_play_value_textBox5 = new System.Windows.Forms.TextBox();
            this.sounds_time_play_type_comboBox1 = new System.Windows.Forms.ComboBox();
            this.keypressed_label = new System.Windows.Forms.Label();
            this.ctr_plug_tab_checkbox1 = new System.Windows.Forms.CheckBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(115, 39);
            this.button1.TabIndex = 0;
            this.button1.Text = "Start";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(144, 12);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(112, 39);
            this.button2.TabIndex = 1;
            this.button2.Text = "Pause";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(84, 120);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(13, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 120);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Typing Times:";
            // 
            // timer2
            // 
            this.timer2.Interval = 1000;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 139);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Clicking Times:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(91, 140);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(13, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "0";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(123, 159);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(62, 20);
            this.textBox1.TabIndex = 6;
            this.textBox1.Text = "100";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(199, 159);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(63, 20);
            this.textBox2.TabIndex = 7;
            this.textBox2.Text = "2000";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(124, 189);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(64, 20);
            this.textBox3.TabIndex = 9;
            this.textBox3.Text = "100";
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(200, 189);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(63, 20);
            this.textBox4.TabIndex = 8;
            this.textBox4.Text = "3000";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 159);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(80, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Typing Interval:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(14, 189);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(85, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Clicking Interval:";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(12, 57);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(244, 37);
            this.button3.TabIndex = 12;
            this.button3.Text = "Reset";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // timer3
            // 
            this.timer3.Interval = 1000;
            this.timer3.Tick += new System.EventHandler(this.timer3_Tick);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 102);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(33, 13);
            this.label7.TabIndex = 14;
            this.label7.Text = "Time:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(44, 103);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(61, 13);
            this.label10.TabIndex = 16;
            this.label10.Text = "00 : 00 : 00";
            // 
            // sound_duration_label8
            // 
            this.sound_duration_label8.AutoSize = true;
            this.sound_duration_label8.Location = new System.Drawing.Point(15, 255);
            this.sound_duration_label8.Name = "sound_duration_label8";
            this.sound_duration_label8.Size = new System.Drawing.Size(84, 13);
            this.sound_duration_label8.TabIndex = 17;
            this.sound_duration_label8.Text = "Sound Duration:";
            // 
            // sound_duration_textBox5
            // 
            this.sound_duration_textBox5.Location = new System.Drawing.Point(125, 255);
            this.sound_duration_textBox5.Name = "sound_duration_textBox5";
            this.sound_duration_textBox5.Size = new System.Drawing.Size(63, 20);
            this.sound_duration_textBox5.TabIndex = 18;
            this.sound_duration_textBox5.Text = "2000";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(15, 220);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(96, 13);
            this.label8.TabIndex = 19;
            this.label8.Text = "Play Sounds Every";
            // 
            // sounds_time_play_value_textBox5
            // 
            this.sounds_time_play_value_textBox5.Location = new System.Drawing.Point(200, 221);
            this.sounds_time_play_value_textBox5.Name = "sounds_time_play_value_textBox5";
            this.sounds_time_play_value_textBox5.Size = new System.Drawing.Size(63, 20);
            this.sounds_time_play_value_textBox5.TabIndex = 20;
            this.sounds_time_play_value_textBox5.Text = "10";
            // 
            // sounds_time_play_type_comboBox1
            // 
            this.sounds_time_play_type_comboBox1.FormattingEnabled = true;
            this.sounds_time_play_type_comboBox1.Items.AddRange(new object[] {
            "Hours",
            "Minutes",
            "Seconds"});
            this.sounds_time_play_type_comboBox1.Location = new System.Drawing.Point(125, 220);
            this.sounds_time_play_type_comboBox1.Name = "sounds_time_play_type_comboBox1";
            this.sounds_time_play_type_comboBox1.Size = new System.Drawing.Size(61, 21);
            this.sounds_time_play_type_comboBox1.TabIndex = 21;
            this.sounds_time_play_type_comboBox1.Text = "Hours";
            // 
            // keypressed_label
            // 
            this.keypressed_label.AutoSize = true;
            this.keypressed_label.Location = new System.Drawing.Point(191, 103);
            this.keypressed_label.Name = "keypressed_label";
            this.keypressed_label.Size = new System.Drawing.Size(65, 13);
            this.keypressed_label.TabIndex = 22;
            this.keypressed_label.Text = "Not Pressed";
            // 
            // ctr_plug_tab_checkbox1
            // 
            this.ctr_plug_tab_checkbox1.AutoSize = true;
            this.ctr_plug_tab_checkbox1.Location = new System.Drawing.Point(126, 282);
            this.ctr_plug_tab_checkbox1.Name = "ctr_plug_tab_checkbox1";
            this.ctr_plug_tab_checkbox1.Size = new System.Drawing.Size(15, 14);
            this.ctr_plug_tab_checkbox1.TabIndex = 23;
            this.ctr_plug_tab_checkbox1.UseVisualStyleBackColor = true;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(15, 279);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(107, 13);
            this.label9.TabIndex = 24;
            this.label9.Text = "Enable Auto ctr + tab";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(126, 102);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(62, 13);
            this.label11.TabIndex = 25;
            this.label11.Text = "App Status:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(268, 310);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.ctr_plug_tab_checkbox1);
            this.Controls.Add(this.keypressed_label);
            this.Controls.Add(this.sounds_time_play_type_comboBox1);
            this.Controls.Add(this.sounds_time_play_value_textBox5);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.sound_duration_textBox5);
            this.Controls.Add(this.sound_duration_label8);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.ShowIcon = false;
            this.Text = "...";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Timer timer3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label sound_duration_label8;
        private System.Windows.Forms.TextBox sound_duration_textBox5;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox sounds_time_play_value_textBox5;
        private System.Windows.Forms.ComboBox sounds_time_play_type_comboBox1;
        private System.Windows.Forms.Label keypressed_label;
        private System.Windows.Forms.CheckBox ctr_plug_tab_checkbox1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label11;
    }
}

