/*
 * Copyright (C) 2016-2018
 * 由SharpDevelop创建。
 * 作者: Byron Gong
 * 日期: 03/15/2018 时间: 14:22
 * 邮箱: 1032066879@QQ.com
 * 描述: 
 *
 */ 
namespace Spoon.Tools.TemplatePrint.Editer
{
	partial class wQRCoderEditer
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.ComboBox cbLevelType;
		private System.Windows.Forms.TextBox txtValue;
		private System.Windows.Forms.NumericUpDown nudPixel;
		private System.Windows.Forms.Label label10;
		
		/// <summary>
		/// Disposes resources used by the control.
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
			this.label8 = new System.Windows.Forms.Label();
			this.label9 = new System.Windows.Forms.Label();
			this.cbLevelType = new System.Windows.Forms.ComboBox();
			this.txtValue = new System.Windows.Forms.TextBox();
			this.nudPixel = new System.Windows.Forms.NumericUpDown();
			this.label10 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.nudPixel)).BeginInit();
			this.SuspendLayout();
			// 
			// label8
			// 
			this.label8.Location = new System.Drawing.Point(14, 219);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(46, 13);
			this.label8.TabIndex = 10;
			this.label8.Text = "Value";
			// 
			// label9
			// 
			this.label9.Location = new System.Drawing.Point(14, 192);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(46, 13);
			this.label9.TabIndex = 10;
			this.label9.Text = "Level";
			// 
			// cbLevelType
			// 
			this.cbLevelType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbLevelType.FormattingEnabled = true;
			this.cbLevelType.Location = new System.Drawing.Point(59, 189);
			this.cbLevelType.Name = "cbLevelType";
			this.cbLevelType.Size = new System.Drawing.Size(161, 21);
			this.cbLevelType.TabIndex = 11;
			this.cbLevelType.SelectedIndexChanged += new System.EventHandler(this.CbLevelTypeSelectedIndexChanged);
			// 
			// txtValue
			// 
			this.txtValue.Location = new System.Drawing.Point(59, 216);
			this.txtValue.Multiline = true;
			this.txtValue.Name = "txtValue";
			this.txtValue.Size = new System.Drawing.Size(161, 72);
			this.txtValue.TabIndex = 12;
			this.txtValue.KeyDown += new System.Windows.Forms.KeyEventHandler(this.OnTextBoxKeyDown);
			this.txtValue.Leave += new System.EventHandler(this.OnTextBoxLeave);
			// 
			// nudPixel
			// 
			this.nudPixel.Location = new System.Drawing.Point(59, 163);
			this.nudPixel.Name = "nudPixel";
			this.nudPixel.Size = new System.Drawing.Size(161, 20);
			this.nudPixel.TabIndex = 13;
			this.nudPixel.Value = new decimal(new int[] {
			2,
			0,
			0,
			0});
			this.nudPixel.ValueChanged += new System.EventHandler(this.NudPixelValueChanged);
			// 
			// label10
			// 
			this.label10.Location = new System.Drawing.Point(14, 165);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(46, 13);
			this.label10.TabIndex = 10;
			this.label10.Text = "Pixel";
			// 
			// wQRCoderEditer
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.nudPixel);
			this.Controls.Add(this.txtValue);
			this.Controls.Add(this.cbLevelType);
			this.Controls.Add(this.label10);
			this.Controls.Add(this.label9);
			this.Controls.Add(this.label8);
			this.Name = "wQRCoderEditer";
			this.Size = new System.Drawing.Size(241, 309);
			this.Controls.SetChildIndex(this.label8, 0);
			this.Controls.SetChildIndex(this.label9, 0);
			this.Controls.SetChildIndex(this.label10, 0);
			this.Controls.SetChildIndex(this.cbLevelType, 0);
			this.Controls.SetChildIndex(this.txtValue, 0);
			this.Controls.SetChildIndex(this.nudPixel, 0);
			((System.ComponentModel.ISupportInitialize)(this.nudPixel)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}
	}
}
