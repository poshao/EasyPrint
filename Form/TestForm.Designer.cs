/*
 * Copyright (C) 2016-2018
 * 由SharpDevelop创建。
 * 作者: Byron Gong
 * 日期: 03/16/2018 时间: 10:54
 * 邮箱: 1032066879@QQ.com
 * 描述: 
 *
 */ 
namespace Spoon.Tools.TemplatePrint
{
	partial class TestForm
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.Button btnReadExcel;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
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
			this.btnReadExcel = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// btnReadExcel
			// 
			this.btnReadExcel.Location = new System.Drawing.Point(37, 31);
			this.btnReadExcel.Name = "btnReadExcel";
			this.btnReadExcel.Size = new System.Drawing.Size(78, 34);
			this.btnReadExcel.TabIndex = 0;
			this.btnReadExcel.Text = "ReadExcel";
			this.btnReadExcel.UseVisualStyleBackColor = true;
			this.btnReadExcel.Click += new System.EventHandler(this.BtnReadExcelClick);
			// 
			// TestForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(435, 321);
			this.Controls.Add(this.btnReadExcel);
			this.Name = "TestForm";
			this.Text = "TestForm";
			this.ResumeLayout(false);

		}
	}
}
