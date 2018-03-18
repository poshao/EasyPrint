/*
 * Copyright (C) 2016-2018
 * 由SharpDevelop创建。
 * 作者: Byron Gong
 * 日期: 03/09/2018 时间: 9:59
 * 邮箱: 1032066879@QQ.com
 * 描述: 
 *
 */ 
namespace Spoon.Tools.TemplatePrint.Editer
{
	partial class wImageEditer
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.TextBox txtImagePath;
		private System.Windows.Forms.Button btnPath;
		
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
			this.txtImagePath = new System.Windows.Forms.TextBox();
			this.btnPath = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// txtImagePath
			// 
			this.txtImagePath.Location = new System.Drawing.Point(59, 163);
			this.txtImagePath.Multiline = true;
			this.txtImagePath.Name = "txtImagePath";
			this.txtImagePath.Size = new System.Drawing.Size(161, 50);
			this.txtImagePath.TabIndex = 6;
			this.txtImagePath.Leave += new System.EventHandler(this.TxtImagePathLeave);
			// 
			// btnPath
			// 
			this.btnPath.Location = new System.Drawing.Point(14, 163);
			this.btnPath.Name = "btnPath";
			this.btnPath.Size = new System.Drawing.Size(39, 25);
			this.btnPath.TabIndex = 7;
			this.btnPath.Text = "Path";
			this.btnPath.UseVisualStyleBackColor = true;
			this.btnPath.Click += new System.EventHandler(this.BtnPathClick);
			// 
			// wImageEditer
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.btnPath);
			this.Controls.Add(this.txtImagePath);
			this.MinimumSize = new System.Drawing.Size(241, 235);
			this.Name = "wImageEditer";
			this.Size = new System.Drawing.Size(241, 235);
			this.Controls.SetChildIndex(this.txtImagePath, 0);
			this.Controls.SetChildIndex(this.btnPath, 0);
			this.ResumeLayout(false);
			this.PerformLayout();

		}
	}
}
