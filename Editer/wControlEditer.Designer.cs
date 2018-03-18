/*
 * Copyright (C) 2016-2018
 * 由SharpDevelop创建。
 * 作者: Byron Gong
 * 日期: 03/07/2018 时间: 16:45
 * 邮箱: 1032066879@QQ.com
 * 描述: 
 *
 */ 
namespace Spoon.Tools.TemplatePrint.Editer
{
	partial class wControlEditer
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox txtName;
		private System.Windows.Forms.CheckBox cbShowBorder;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox txtLeftPixel;
		private System.Windows.Forms.TextBox txtTopPixel;
		private System.Windows.Forms.TextBox txtWidthPixel;
		private System.Windows.Forms.TextBox txtHeightPixel;
		private System.Windows.Forms.TextBox txtLeftMm;
		private System.Windows.Forms.TextBox txtTopMm;
		private System.Windows.Forms.TextBox txtWidthMm;
		private System.Windows.Forms.TextBox txtHeightMm;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label7;
		
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
			this.label1 = new System.Windows.Forms.Label();
			this.txtName = new System.Windows.Forms.TextBox();
			this.cbShowBorder = new System.Windows.Forms.CheckBox();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.txtLeftPixel = new System.Windows.Forms.TextBox();
			this.txtTopPixel = new System.Windows.Forms.TextBox();
			this.txtWidthPixel = new System.Windows.Forms.TextBox();
			this.txtHeightPixel = new System.Windows.Forms.TextBox();
			this.txtLeftMm = new System.Windows.Forms.TextBox();
			this.txtTopMm = new System.Windows.Forms.TextBox();
			this.txtWidthMm = new System.Windows.Forms.TextBox();
			this.txtHeightMm = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(14, 15);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(46, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "Name";
			// 
			// txtName
			// 
			this.txtName.Location = new System.Drawing.Point(59, 12);
			this.txtName.Name = "txtName";
			this.txtName.Size = new System.Drawing.Size(72, 20);
			this.txtName.TabIndex = 0;
			this.txtName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.OnTextBoxLeaveKeyDown);
			this.txtName.Leave += new System.EventHandler(this.OnTextBoxLeave);
			// 
			// cbShowBorder
			// 
			this.cbShowBorder.Location = new System.Drawing.Point(148, 9);
			this.cbShowBorder.Name = "cbShowBorder";
			this.cbShowBorder.Size = new System.Drawing.Size(86, 26);
			this.cbShowBorder.TabIndex = 1;
			this.cbShowBorder.Text = "显示边框";
			this.cbShowBorder.UseVisualStyleBackColor = true;
			this.cbShowBorder.CheckStateChanged += new System.EventHandler(this.CbShowBorderCheckStateChanged);
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(14, 62);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(46, 13);
			this.label2.TabIndex = 3;
			this.label2.Text = "Left";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(14, 88);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(46, 13);
			this.label3.TabIndex = 3;
			this.label3.Text = "Top";
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(14, 114);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(46, 13);
			this.label4.TabIndex = 3;
			this.label4.Text = "Width";
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(14, 140);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(46, 13);
			this.label5.TabIndex = 3;
			this.label5.Text = "Height";
			// 
			// txtLeftPixel
			// 
			this.txtLeftPixel.Location = new System.Drawing.Point(59, 59);
			this.txtLeftPixel.Name = "txtLeftPixel";
			this.txtLeftPixel.Size = new System.Drawing.Size(72, 20);
			this.txtLeftPixel.TabIndex = 2;
			this.txtLeftPixel.KeyDown += new System.Windows.Forms.KeyEventHandler(this.OnTextBoxLeaveKeyDown);
			this.txtLeftPixel.Leave += new System.EventHandler(this.OnTextBoxLeave);
			// 
			// txtTopPixel
			// 
			this.txtTopPixel.Location = new System.Drawing.Point(59, 85);
			this.txtTopPixel.Name = "txtTopPixel";
			this.txtTopPixel.Size = new System.Drawing.Size(72, 20);
			this.txtTopPixel.TabIndex = 3;
			this.txtTopPixel.KeyDown += new System.Windows.Forms.KeyEventHandler(this.OnTextBoxLeaveKeyDown);
			this.txtTopPixel.Leave += new System.EventHandler(this.OnTextBoxLeave);
			// 
			// txtWidthPixel
			// 
			this.txtWidthPixel.Location = new System.Drawing.Point(59, 111);
			this.txtWidthPixel.Name = "txtWidthPixel";
			this.txtWidthPixel.Size = new System.Drawing.Size(72, 20);
			this.txtWidthPixel.TabIndex = 4;
			this.txtWidthPixel.KeyDown += new System.Windows.Forms.KeyEventHandler(this.OnTextBoxLeaveKeyDown);
			this.txtWidthPixel.Leave += new System.EventHandler(this.OnTextBoxLeave);
			// 
			// txtHeightPixel
			// 
			this.txtHeightPixel.Location = new System.Drawing.Point(59, 137);
			this.txtHeightPixel.Name = "txtHeightPixel";
			this.txtHeightPixel.Size = new System.Drawing.Size(72, 20);
			this.txtHeightPixel.TabIndex = 5;
			this.txtHeightPixel.KeyDown += new System.Windows.Forms.KeyEventHandler(this.OnTextBoxLeaveKeyDown);
			this.txtHeightPixel.Leave += new System.EventHandler(this.OnTextBoxLeave);
			// 
			// txtLeftMm
			// 
			this.txtLeftMm.Location = new System.Drawing.Point(148, 59);
			this.txtLeftMm.Name = "txtLeftMm";
			this.txtLeftMm.Size = new System.Drawing.Size(72, 20);
			this.txtLeftMm.TabIndex = 6;
			this.txtLeftMm.KeyDown += new System.Windows.Forms.KeyEventHandler(this.OnTextBoxLeaveKeyDown);
			this.txtLeftMm.Leave += new System.EventHandler(this.OnTextBoxLeave);
			// 
			// txtTopMm
			// 
			this.txtTopMm.Location = new System.Drawing.Point(148, 85);
			this.txtTopMm.Name = "txtTopMm";
			this.txtTopMm.Size = new System.Drawing.Size(72, 20);
			this.txtTopMm.TabIndex = 7;
			this.txtTopMm.KeyDown += new System.Windows.Forms.KeyEventHandler(this.OnTextBoxLeaveKeyDown);
			this.txtTopMm.Leave += new System.EventHandler(this.OnTextBoxLeave);
			// 
			// txtWidthMm
			// 
			this.txtWidthMm.Location = new System.Drawing.Point(148, 111);
			this.txtWidthMm.Name = "txtWidthMm";
			this.txtWidthMm.Size = new System.Drawing.Size(72, 20);
			this.txtWidthMm.TabIndex = 8;
			this.txtWidthMm.KeyDown += new System.Windows.Forms.KeyEventHandler(this.OnTextBoxLeaveKeyDown);
			this.txtWidthMm.Leave += new System.EventHandler(this.OnTextBoxLeave);
			// 
			// txtHeightMm
			// 
			this.txtHeightMm.Location = new System.Drawing.Point(148, 137);
			this.txtHeightMm.Name = "txtHeightMm";
			this.txtHeightMm.Size = new System.Drawing.Size(72, 20);
			this.txtHeightMm.TabIndex = 9;
			this.txtHeightMm.KeyDown += new System.Windows.Forms.KeyEventHandler(this.OnTextBoxLeaveKeyDown);
			this.txtHeightMm.Leave += new System.EventHandler(this.OnTextBoxLeave);
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(59, 43);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(46, 13);
			this.label6.TabIndex = 3;
			this.label6.Text = "像素";
			// 
			// label7
			// 
			this.label7.Location = new System.Drawing.Point(148, 43);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(46, 13);
			this.label7.TabIndex = 3;
			this.label7.Text = "毫米";
			// 
			// wControlEditer
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.txtHeightMm);
			this.Controls.Add(this.txtHeightPixel);
			this.Controls.Add(this.txtWidthMm);
			this.Controls.Add(this.txtWidthPixel);
			this.Controls.Add(this.txtTopMm);
			this.Controls.Add(this.txtTopPixel);
			this.Controls.Add(this.txtLeftMm);
			this.Controls.Add(this.txtLeftPixel);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.cbShowBorder);
			this.Controls.Add(this.txtName);
			this.Controls.Add(this.label1);
			this.MinimumSize = new System.Drawing.Size(241, 179);
			this.Name = "wControlEditer";
			this.Size = new System.Drawing.Size(241, 179);
			this.ResumeLayout(false);
			this.PerformLayout();

		}
	}
}
