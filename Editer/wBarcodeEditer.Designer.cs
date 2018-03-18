/*
 * Copyright (C) 2016-2018
 * 由SharpDevelop创建。
 * 作者: Byron Gong
 * 日期: 03/09/2018 时间: 11:28
 * 邮箱: 1032066879@QQ.com
 * 描述: 
 *
 */ 
namespace Spoon.Tools.TemplatePrint.Editer
{
	partial class wBarcodeEditer
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.ComboBox cbEncodingType;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.TextBox txtValue;
		private System.Windows.Forms.CheckBox ckShowText;
		
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
			this.cbEncodingType = new System.Windows.Forms.ComboBox();
			this.label9 = new System.Windows.Forms.Label();
			this.txtValue = new System.Windows.Forms.TextBox();
			this.ckShowText = new System.Windows.Forms.CheckBox();
			this.SuspendLayout();
			// 
			// label8
			// 
			this.label8.Location = new System.Drawing.Point(14, 166);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(46, 13);
			this.label8.TabIndex = 5;
			this.label8.Text = "Type";
			// 
			// cbEncodingType
			// 
			this.cbEncodingType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbEncodingType.FormattingEnabled = true;
			this.cbEncodingType.Location = new System.Drawing.Point(59, 163);
			this.cbEncodingType.Name = "cbEncodingType";
			this.cbEncodingType.Size = new System.Drawing.Size(161, 21);
			this.cbEncodingType.TabIndex = 6;
			this.cbEncodingType.SelectedIndexChanged += new System.EventHandler(this.CbEncodingTypeSelectedIndexChanged);
			// 
			// label9
			// 
			this.label9.Location = new System.Drawing.Point(14, 193);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(46, 13);
			this.label9.TabIndex = 5;
			this.label9.Text = "Value";
			// 
			// txtValue
			// 
			this.txtValue.Location = new System.Drawing.Point(59, 190);
			this.txtValue.Name = "txtValue";
			this.txtValue.Size = new System.Drawing.Size(161, 20);
			this.txtValue.TabIndex = 7;
			this.txtValue.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtValueKeyDown);
			this.txtValue.Leave += new System.EventHandler(this.TxtValueLeave);
			// 
			// ckShowText
			// 
			this.ckShowText.Location = new System.Drawing.Point(146, 216);
			this.ckShowText.Name = "ckShowText";
			this.ckShowText.Size = new System.Drawing.Size(74, 19);
			this.ckShowText.TabIndex = 8;
			this.ckShowText.Text = "显示文本";
			this.ckShowText.UseVisualStyleBackColor = true;
			this.ckShowText.CheckStateChanged += new System.EventHandler(this.CkShowTextCheckStateChanged);
			// 
			// wBarcodeEditer
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.ckShowText);
			this.Controls.Add(this.txtValue);
			this.Controls.Add(this.cbEncodingType);
			this.Controls.Add(this.label9);
			this.Controls.Add(this.label8);
			this.Name = "wBarcodeEditer";
			this.Size = new System.Drawing.Size(241, 256);
			this.Controls.SetChildIndex(this.label8, 0);
			this.Controls.SetChildIndex(this.label9, 0);
			this.Controls.SetChildIndex(this.cbEncodingType, 0);
			this.Controls.SetChildIndex(this.txtValue, 0);
			this.Controls.SetChildIndex(this.ckShowText, 0);
			this.ResumeLayout(false);
			this.PerformLayout();

		}
	}
}
