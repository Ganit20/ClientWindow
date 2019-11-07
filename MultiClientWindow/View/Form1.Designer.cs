using System;
using System.Windows.Forms;

namespace MultiClientWindow
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
            this.Nickname = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.listView1 = new System.Windows.Forms.ListView();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.listView2 = new System.Windows.Forms.ListView();
            this.button2 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.listView3 = new System.Windows.Forms.ListView();
            this.SuspendLayout();
            // 
            // Nickname
            // 
            this.Nickname.AccessibleDescription = "Nickname";
            this.Nickname.AccessibleName = "Nickname";
            this.Nickname.Location = new System.Drawing.Point(79, 4);
            this.Nickname.Name = "Nickname";
            this.Nickname.Size = new System.Drawing.Size(140, 22);
            this.Nickname.TabIndex = 0;
            this.Nickname.TextChanged += new System.EventHandler(this.TextBox1_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(-1, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Nickname:";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(225, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(134, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Set And Connect";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // listView1
            // 
            this.listView1.AccessibleDescription = "Users";
            this.listView1.AccessibleName = "User List";
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(787, 12);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(140, 407);
            this.listView1.TabIndex = 3;
            this.listView1.UseCompatibleStateImageBehavior = false;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(12, 397);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(640, 22);
            this.textBox3.TabIndex = 5;
            // 
            // listView2
            // 
            this.listView2.AccessibleDescription = "Console";
            this.listView2.AccessibleName = "Events";
            this.listView2.HideSelection = false;
            this.listView2.Location = new System.Drawing.Point(933, 12);
            this.listView2.Name = "listView2";
            this.listView2.Size = new System.Drawing.Size(138, 407);
            this.listView2.TabIndex = 6;
            this.listView2.UseCompatibleStateImageBehavior = false;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(658, 397);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(109, 23);
            this.button2.TabIndex = 7;
            this.button2.Text = "Send";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.Button2_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(12, 32);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.textBox1.Size = new System.Drawing.Size(158, 359);
            this.textBox1.TabIndex = 8;
            this.textBox1.Text = "LOL";
            // 
            // listView3
            // 
            this.listView3.HideSelection = false;
            this.listView3.Location = new System.Drawing.Point(176, 33);
            this.listView3.Name = "listView3";
            this.listView3.Size = new System.Drawing.Size(591, 358);
            this.listView3.TabIndex = 9;
            this.listView3.UseCompatibleStateImageBehavior = false;
            this.listView3.SelectedIndexChanged += new System.EventHandler(this.ListView3_SelectedIndexChanged_1);
            this.listView3.Columns.Add("Time" ,- 2, HorizontalAlignment.Left);
            this.listView3.Columns.Add("Nick", -2, HorizontalAlignment.Left);
            this.listView3.Columns.Add("Message", -2, HorizontalAlignment.Left);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1083, 480);
            this.Controls.Add(this.listView3);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.listView2);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Nickname);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }



        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.ListView listView2;
        public System.Windows.Forms.TextBox Nickname;
        private System.Windows.Forms.Button button2;
        public  System.Windows.Forms.TextBox textBox1;
        public System.Windows.Forms.ListView listView3;
    }
}

