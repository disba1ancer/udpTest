namespace server
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.txChat = new System.Windows.Forms.TextBox();
            this.btSend = new System.Windows.Forms.Button();
            this.txMessage = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txChat
            // 
            this.txChat.Location = new System.Drawing.Point(12, 12);
            this.txChat.Multiline = true;
            this.txChat.Name = "txChat";
            this.txChat.ReadOnly = true;
            this.txChat.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txChat.Size = new System.Drawing.Size(260, 208);
            this.txChat.TabIndex = 0;
            // 
            // btSend
            // 
            this.btSend.Location = new System.Drawing.Point(197, 226);
            this.btSend.Name = "btSend";
            this.btSend.Size = new System.Drawing.Size(75, 23);
            this.btSend.TabIndex = 1;
            this.btSend.Text = "Send";
            this.btSend.UseVisualStyleBackColor = true;
            this.btSend.Click += new System.EventHandler(this.btSend_Click);
            // 
            // txMessage
            // 
            this.txMessage.Location = new System.Drawing.Point(12, 228);
            this.txMessage.Name = "txMessage";
            this.txMessage.Size = new System.Drawing.Size(179, 20);
            this.txMessage.TabIndex = 2;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.txMessage);
            this.Controls.Add(this.btSend);
            this.Controls.Add(this.txChat);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txChat;
        private System.Windows.Forms.Button btSend;
        private System.Windows.Forms.TextBox txMessage;
    }
}

