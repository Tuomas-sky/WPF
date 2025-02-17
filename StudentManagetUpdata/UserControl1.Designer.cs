namespace StudentManagetUpdata
{
    partial class UserControl1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.old = new System.Windows.Forms.Label();
            this.new1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(283, 246);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(310, 112);
            this.button1.TabIndex = 0;
            this.button1.Text = "Old";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(283, 455);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(310, 112);
            this.button2.TabIndex = 1;
            this.button2.Text = "New";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 23);
            this.label1.TabIndex = 0;
            // 
            // old
            // 
            this.old.AutoSize = true;
            this.old.Location = new System.Drawing.Point(720, 279);
            this.old.Name = "old";
            this.old.Size = new System.Drawing.Size(68, 27);
            this.old.TabIndex = 2;
            this.old.Text = " old";
            // 
            // new1
            // 
            this.new1.AutoSize = true;
            this.new1.Location = new System.Drawing.Point(720, 509);
            this.new1.Name = "new1";
            this.new1.Size = new System.Drawing.Size(54, 27);
            this.new1.TabIndex = 3;
            this.new1.Text = "new";
            // 
            // UserControl1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(14F, 27F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.new1);
            this.Controls.Add(this.old);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Name = "UserControl1";
            this.Size = new System.Drawing.Size(2311, 1169);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label old;
        private System.Windows.Forms.Label new1;
    }
}
