﻿namespace BankingKiosk
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
            this.components = new System.ComponentModel.Container();
            this.depositButton = new System.Windows.Forms.Button();
            this.withdrawButton = new System.Windows.Forms.Button();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.amountInput = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // depositButton
            // 
            this.depositButton.Location = new System.Drawing.Point(245, 191);
            this.depositButton.Name = "depositButton";
            this.depositButton.Size = new System.Drawing.Size(75, 23);
            this.depositButton.TabIndex = 0;
            this.depositButton.Text = "Deposit";
            this.depositButton.UseVisualStyleBackColor = true;
            this.depositButton.Click += new System.EventHandler(this.depositButton_Click);
            // 
            // withdrawButton
            // 
            this.withdrawButton.Location = new System.Drawing.Point(407, 191);
            this.withdrawButton.Name = "withdrawButton";
            this.withdrawButton.Size = new System.Drawing.Size(75, 23);
            this.withdrawButton.TabIndex = 1;
            this.withdrawButton.Text = "Withdraw";
            this.withdrawButton.UseVisualStyleBackColor = true;
            this.withdrawButton.Click += new System.EventHandler(this.withdrawButton_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // amountInput
            // 
            this.amountInput.Location = new System.Drawing.Point(325, 134);
            this.amountInput.Name = "amountInput";
            this.amountInput.Size = new System.Drawing.Size(100, 23);
            this.amountInput.TabIndex = 3;
            this.amountInput.Text = "10";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(376, 261);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.ShowMessage);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.amountInput);
            this.Controls.Add(this.withdrawButton);
            this.Controls.Add(this.depositButton);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button depositButton;
        private Button withdrawButton;
        private ContextMenuStrip contextMenuStrip1;
        private TextBox amountInput;
        private Button button1;
    }
}