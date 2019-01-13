/*
 * Copyright (C) 2016-2018
 * 由SharpDevelop创建。
 * 作者: Byron Gong
 * 日期: 03/08/2018 时间: 16:35
 * 邮箱: 1032066879@QQ.com
 * 描述: 
 *
 */ 
namespace Spoon.Tools.TemplatePrint.Editer
{
	partial class wLabelEditer
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.TextBox txtValue;
		private System.Windows.Forms.TextBox txtFont;
		private System.Windows.Forms.Button btnFont;
		private System.Windows.Forms.Button btnRM;
		private System.Windows.Forms.Button btnCM;
		private System.Windows.Forms.Button btnRT;
		private System.Windows.Forms.Button btnLM;
		private System.Windows.Forms.Button btnCT;
		private System.Windows.Forms.Button btnLT;
		private System.Windows.Forms.Button btnLB;
		private System.Windows.Forms.Button btnCB;
		private System.Windows.Forms.Button btnRB;
		
		/// <summary>
		/// Disposes resources used by the control.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
					if(m_control!=null){
						Control=null;
					}
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnRB = new System.Windows.Forms.Button();
            this.btnRM = new System.Windows.Forms.Button();
            this.btnCB = new System.Windows.Forms.Button();
            this.btnCM = new System.Windows.Forms.Button();
            this.btnRT = new System.Windows.Forms.Button();
            this.btnLM = new System.Windows.Forms.Button();
            this.btnLB = new System.Windows.Forms.Button();
            this.btnLT = new System.Windows.Forms.Button();
            this.btnCT = new System.Windows.Forms.Button();
            this.txtValue = new System.Windows.Forms.TextBox();
            this.txtFont = new System.Windows.Forms.TextBox();
            this.btnFont = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(14, 166);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(46, 13);
            this.label8.TabIndex = 5;
            this.label8.Text = "Value";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnRB);
            this.groupBox1.Controls.Add(this.btnRM);
            this.groupBox1.Controls.Add(this.btnCB);
            this.groupBox1.Controls.Add(this.btnCM);
            this.groupBox1.Controls.Add(this.btnRT);
            this.groupBox1.Controls.Add(this.btnLM);
            this.groupBox1.Controls.Add(this.btnLB);
            this.groupBox1.Controls.Add(this.btnLT);
            this.groupBox1.Controls.Add(this.btnCT);
            this.groupBox1.Location = new System.Drawing.Point(14, 215);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(206, 123);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "对齐方式";
            // 
            // btnRB
            // 
            this.btnRB.Font = new System.Drawing.Font("Wingdings", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.btnRB.ForeColor = System.Drawing.Color.Blue;
            this.btnRB.Location = new System.Drawing.Point(145, 83);
            this.btnRB.Margin = new System.Windows.Forms.Padding(20, 3, 3, 3);
            this.btnRB.Name = "btnRB";
            this.btnRB.Size = new System.Drawing.Size(44, 25);
            this.btnRB.TabIndex = 0;
            this.btnRB.UseVisualStyleBackColor = true;
            this.btnRB.Click += new System.EventHandler(this.OnAlignButtonClick);
            // 
            // btnRM
            // 
            this.btnRM.Font = new System.Drawing.Font("Wingdings", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.btnRM.ForeColor = System.Drawing.Color.Blue;
            this.btnRM.Location = new System.Drawing.Point(145, 52);
            this.btnRM.Margin = new System.Windows.Forms.Padding(20, 3, 3, 3);
            this.btnRM.Name = "btnRM";
            this.btnRM.Size = new System.Drawing.Size(44, 25);
            this.btnRM.TabIndex = 0;
            this.btnRM.UseVisualStyleBackColor = true;
            this.btnRM.Click += new System.EventHandler(this.OnAlignButtonClick);
            // 
            // btnCB
            // 
            this.btnCB.Font = new System.Drawing.Font("Wingdings", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.btnCB.ForeColor = System.Drawing.Color.Blue;
            this.btnCB.Location = new System.Drawing.Point(81, 83);
            this.btnCB.Margin = new System.Windows.Forms.Padding(20, 3, 3, 3);
            this.btnCB.Name = "btnCB";
            this.btnCB.Size = new System.Drawing.Size(44, 25);
            this.btnCB.TabIndex = 0;
            this.btnCB.UseVisualStyleBackColor = true;
            this.btnCB.Click += new System.EventHandler(this.OnAlignButtonClick);
            // 
            // btnCM
            // 
            this.btnCM.Font = new System.Drawing.Font("Wingdings", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.btnCM.ForeColor = System.Drawing.Color.Blue;
            this.btnCM.Location = new System.Drawing.Point(81, 52);
            this.btnCM.Margin = new System.Windows.Forms.Padding(20, 3, 3, 3);
            this.btnCM.Name = "btnCM";
            this.btnCM.Size = new System.Drawing.Size(44, 25);
            this.btnCM.TabIndex = 0;
            this.btnCM.UseVisualStyleBackColor = true;
            this.btnCM.Click += new System.EventHandler(this.OnAlignButtonClick);
            // 
            // btnRT
            // 
            this.btnRT.Font = new System.Drawing.Font("Wingdings", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.btnRT.ForeColor = System.Drawing.Color.Blue;
            this.btnRT.Location = new System.Drawing.Point(145, 21);
            this.btnRT.Margin = new System.Windows.Forms.Padding(20, 3, 3, 3);
            this.btnRT.Name = "btnRT";
            this.btnRT.Size = new System.Drawing.Size(44, 25);
            this.btnRT.TabIndex = 0;
            this.btnRT.UseVisualStyleBackColor = true;
            this.btnRT.Click += new System.EventHandler(this.OnAlignButtonClick);
            // 
            // btnLM
            // 
            this.btnLM.Font = new System.Drawing.Font("Wingdings", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.btnLM.ForeColor = System.Drawing.Color.Blue;
            this.btnLM.Location = new System.Drawing.Point(17, 52);
            this.btnLM.Name = "btnLM";
            this.btnLM.Size = new System.Drawing.Size(44, 25);
            this.btnLM.TabIndex = 0;
            this.btnLM.UseVisualStyleBackColor = true;
            this.btnLM.Click += new System.EventHandler(this.OnAlignButtonClick);
            // 
            // btnLB
            // 
            this.btnLB.Font = new System.Drawing.Font("Wingdings", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.btnLB.ForeColor = System.Drawing.Color.Blue;
            this.btnLB.Location = new System.Drawing.Point(17, 83);
            this.btnLB.Name = "btnLB";
            this.btnLB.Size = new System.Drawing.Size(44, 25);
            this.btnLB.TabIndex = 0;
            this.btnLB.UseVisualStyleBackColor = true;
            this.btnLB.Click += new System.EventHandler(this.OnAlignButtonClick);
            // 
            // btnLT
            // 
            this.btnLT.Font = new System.Drawing.Font("Wingdings", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.btnLT.ForeColor = System.Drawing.Color.Blue;
            this.btnLT.Location = new System.Drawing.Point(17, 21);
            this.btnLT.Margin = new System.Windows.Forms.Padding(20, 3, 3, 3);
            this.btnLT.Name = "btnLT";
            this.btnLT.Size = new System.Drawing.Size(44, 25);
            this.btnLT.TabIndex = 0;
            this.btnLT.UseVisualStyleBackColor = true;
            this.btnLT.Click += new System.EventHandler(this.OnAlignButtonClick);
            // 
            // btnCT
            // 
            this.btnCT.Font = new System.Drawing.Font("Wingdings", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.btnCT.ForeColor = System.Drawing.Color.Blue;
            this.btnCT.Location = new System.Drawing.Point(81, 21);
            this.btnCT.Margin = new System.Windows.Forms.Padding(20, 3, 3, 3);
            this.btnCT.Name = "btnCT";
            this.btnCT.Size = new System.Drawing.Size(44, 25);
            this.btnCT.TabIndex = 0;
            this.btnCT.UseVisualStyleBackColor = true;
            this.btnCT.Click += new System.EventHandler(this.OnAlignButtonClick);
            // 
            // txtValue
            // 
            this.txtValue.Location = new System.Drawing.Point(59, 163);
            this.txtValue.Name = "txtValue";
            this.txtValue.Size = new System.Drawing.Size(161, 20);
            this.txtValue.TabIndex = 7;
            this.txtValue.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtValue_KeyDown);
            this.txtValue.Leave += new System.EventHandler(this.TxtValueLeave);
            // 
            // txtFont
            // 
            this.txtFont.Location = new System.Drawing.Point(59, 189);
            this.txtFont.Name = "txtFont";
            this.txtFont.ReadOnly = true;
            this.txtFont.Size = new System.Drawing.Size(161, 20);
            this.txtFont.TabIndex = 8;
            // 
            // btnFont
            // 
            this.btnFont.Location = new System.Drawing.Point(14, 187);
            this.btnFont.Name = "btnFont";
            this.btnFont.Size = new System.Drawing.Size(39, 22);
            this.btnFont.TabIndex = 9;
            this.btnFont.Text = "Font";
            this.btnFont.UseVisualStyleBackColor = true;
            this.btnFont.Click += new System.EventHandler(this.BtnFontClick);
            // 
            // wLabelEditer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnFont);
            this.Controls.Add(this.txtFont);
            this.Controls.Add(this.txtValue);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label8);
            this.MinimumSize = new System.Drawing.Size(241, 354);
            this.Name = "wLabelEditer";
            this.Size = new System.Drawing.Size(241, 354);
            this.Controls.SetChildIndex(this.label8, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.txtValue, 0);
            this.Controls.SetChildIndex(this.txtFont, 0);
            this.Controls.SetChildIndex(this.btnFont, 0);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

		}
	}
}
