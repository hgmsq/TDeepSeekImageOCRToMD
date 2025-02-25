namespace TDeepSeekImageOCRDemo
{
    partial class Form1
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

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.btnFirst = new System.Windows.Forms.Button();
            this.txtTaskId = new System.Windows.Forms.TextBox();
            this.btnResult = new System.Windows.Forms.Button();
            this.txtDocumentUrl = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.txtFileUrl = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // treeView1
            // 
            this.treeView1.Location = new System.Drawing.Point(92, 155);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(534, 236);
            this.treeView1.TabIndex = 0;
            // 
            // btnFirst
            // 
            this.btnFirst.Location = new System.Drawing.Point(636, 72);
            this.btnFirst.Name = "btnFirst";
            this.btnFirst.Size = new System.Drawing.Size(132, 23);
            this.btnFirst.TabIndex = 1;
            this.btnFirst.Text = "创建文档解析任务";
            this.btnFirst.UseVisualStyleBackColor = true;
            this.btnFirst.Click += new System.EventHandler(this.btnFirst_Click);
            // 
            // txtTaskId
            // 
            this.txtTaskId.Location = new System.Drawing.Point(92, 74);
            this.txtTaskId.Name = "txtTaskId";
            this.txtTaskId.Size = new System.Drawing.Size(534, 21);
            this.txtTaskId.TabIndex = 2;
            // 
            // btnResult
            // 
            this.btnResult.Location = new System.Drawing.Point(636, 280);
            this.btnResult.Name = "btnResult";
            this.btnResult.Size = new System.Drawing.Size(132, 23);
            this.btnResult.TabIndex = 3;
            this.btnResult.Text = "获取解析结果";
            this.btnResult.UseVisualStyleBackColor = true;
            this.btnResult.Click += new System.EventHandler(this.btnResult_Click);
            // 
            // txtDocumentUrl
            // 
            this.txtDocumentUrl.Location = new System.Drawing.Point(92, 109);
            this.txtDocumentUrl.Name = "txtDocumentUrl";
            this.txtDocumentUrl.Size = new System.Drawing.Size(534, 21);
            this.txtDocumentUrl.TabIndex = 5;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(636, 109);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(132, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "获取解析文档URL";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtFileUrl
            // 
            this.txtFileUrl.Location = new System.Drawing.Point(92, 12);
            this.txtFileUrl.Multiline = true;
            this.txtFileUrl.Name = "txtFileUrl";
            this.txtFileUrl.Size = new System.Drawing.Size(534, 50);
            this.txtFileUrl.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 12);
            this.label1.TabIndex = 7;
            this.label1.Text = "图片URL";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(29, 77);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 8;
            this.label2.Text = "TaskId";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 114);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 12);
            this.label3.TabIndex = 9;
            this.label3.Text = "解析结果文档";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(794, 403);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtFileUrl);
            this.Controls.Add(this.txtDocumentUrl);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnResult);
            this.Controls.Add(this.txtTaskId);
            this.Controls.Add(this.btnFirst);
            this.Controls.Add(this.treeView1);
            this.Name = "Form1";
            this.Text = "图片识别为MarkDown";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.Button btnFirst;
        private System.Windows.Forms.TextBox txtTaskId;
        private System.Windows.Forms.Button btnResult;
        private System.Windows.Forms.TextBox txtDocumentUrl;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtFileUrl;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}

