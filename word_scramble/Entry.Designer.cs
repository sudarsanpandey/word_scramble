namespace word_scramble
{
    partial class Entry
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.word_tf = new System.Windows.Forms.TextBox();
            this.meaning_tf = new System.Windows.Forms.TextBox();
            this.usage_tf = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.last_word_label = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(62, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "Word :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(31, 107);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 24);
            this.label2.TabIndex = 1;
            this.label2.Text = "Meaning :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(53, 159);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 24);
            this.label3.TabIndex = 2;
            this.label3.Text = "Usage :";
            // 
            // word_tf
            // 
            this.word_tf.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.word_tf.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.word_tf.Location = new System.Drawing.Point(140, 58);
            this.word_tf.Name = "word_tf";
            this.word_tf.Size = new System.Drawing.Size(162, 28);
            this.word_tf.TabIndex = 3;
            // 
            // meaning_tf
            // 
            this.meaning_tf.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.meaning_tf.ForeColor = System.Drawing.Color.Green;
            this.meaning_tf.Location = new System.Drawing.Point(140, 110);
            this.meaning_tf.Name = "meaning_tf";
            this.meaning_tf.Size = new System.Drawing.Size(342, 28);
            this.meaning_tf.TabIndex = 4;
            // 
            // usage_tf
            // 
            this.usage_tf.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.usage_tf.ForeColor = System.Drawing.Color.Blue;
            this.usage_tf.Location = new System.Drawing.Point(140, 160);
            this.usage_tf.Name = "usage_tf";
            this.usage_tf.Size = new System.Drawing.Size(342, 28);
            this.usage_tf.TabIndex = 5;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(82, 208);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(128, 56);
            this.button1.TabIndex = 6;
            this.button1.Text = "CANCEL";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(361, 208);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(121, 56);
            this.button2.TabIndex = 7;
            this.button2.Text = "SUBMIT";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Georgia", 10.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label4.Location = new System.Drawing.Point(136, 20);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(295, 20);
            this.label4.TabIndex = 8;
            this.label4.Text = "Enter the Word in the Database";
            // 
            // last_word_label
            // 
            this.last_word_label.AutoSize = true;
            this.last_word_label.Location = new System.Drawing.Point(334, 68);
            this.last_word_label.Name = "last_word_label";
            this.last_word_label.Size = new System.Drawing.Size(0, 17);
            this.last_word_label.TabIndex = 9;
            // 
            // Entry
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(526, 279);
            this.Controls.Add(this.last_word_label);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.usage_tf);
            this.Controls.Add(this.meaning_tf);
            this.Controls.Add(this.word_tf);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Entry";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Entry";
            this.Load += new System.EventHandler(this.Entry_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox word_tf;
        private System.Windows.Forms.TextBox meaning_tf;
        private System.Windows.Forms.TextBox usage_tf;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label last_word_label;
    }
}