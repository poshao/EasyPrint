/*
 * Copyright (C) 2016-2018
 * 由SharpDevelop创建。
 * 作者: Byron Gong
 * 日期: 03/08/2018 时间: 16:35
 * 邮箱: 1032066879@QQ.com
 * 描述: 
 *
 */ 
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Spoon.Tools.TemplatePrint.Editer
{
	/// <summary>
	/// Description of wLabelEditer.
	/// </summary>
	public partial class wLabelEditer : wControlEditer
	{
		private Button m_selectedAlignButton=null;
		
		public new Controls.wLabel Control{
			get{return m_control as Controls.wLabel;}
			set{
				if(m_control!=null){
					m_control.PropertyChangedEvent-=m_propertyEvent;
				}
				m_control=value;
				if(value!=null){
					value.PropertyChangedEvent+=m_propertyEvent;
					OnPropertyChanged(value,EventArgs.Empty);
				}
			}
		}
		
		new void OnPropertyChanged(object sender,EventArgs args){
			if(Control==null){
				return;
			}
			base.OnPropertyChanged(sender,args);
			txtFont.Text=Control.Font.ToString();
			txtValue.Text=Control.Text;
			//对齐方式
			string btnName=string.Empty;
			switch (Control.HorizontalAlignment) {
				case StringAlignment.Near:
					btnName="L";
					break;
				case StringAlignment.Center:
					btnName="C";
					break;
				case StringAlignment.Far:
					btnName="R";
					break;
			}
			switch (Control.VeticalAlignment) {
				case StringAlignment.Near:
					btnName+="T";
					break;
				case StringAlignment.Center:
					btnName+="M";
					break;
				case StringAlignment.Far:
					btnName+="B";
					break;
			}
			var btn=groupBox1.Controls["btn"+btnName];
			OnAlignButtonClick(btn,EventArgs.Empty);
		}
		
		public wLabelEditer()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
		}
		public wLabelEditer(Controls.wLabel control):base(control){
			InitializeComponent();
			Control=control;
		}
		
		
		/// <summary>
		/// 对齐按钮事件
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void OnAlignButtonClick(object sender,EventArgs e){
			if(Control==null){
				return;
			}
			
			var btn=sender as Button;
			if(m_selectedAlignButton!=null && m_selectedAlignButton!=btn){
				m_selectedAlignButton.Text=string.Empty;
			}
			btn.Text="n";
			m_selectedAlignButton=btn;
			
			var ctl=Control;
			switch (btn.Name) {
				case "btnLT":
					ctl.HorizontalAlignment=StringAlignment.Near;
					ctl.VeticalAlignment=StringAlignment.Near;
					break;
				case "btnCT":
					ctl.HorizontalAlignment=StringAlignment.Center;
					ctl.VeticalAlignment=StringAlignment.Near;
					break;
				case "btnRT":
					ctl.HorizontalAlignment=StringAlignment.Far;
					ctl.VeticalAlignment=StringAlignment.Near;
					break;
				case "btnLM":
					ctl.HorizontalAlignment=StringAlignment.Near;
					ctl.VeticalAlignment=StringAlignment.Center;
					break;
				case "btnCM":
					ctl.HorizontalAlignment=StringAlignment.Center;
					ctl.VeticalAlignment=StringAlignment.Center;
					break;
				case "btnRM":
					ctl.HorizontalAlignment=StringAlignment.Far;
					ctl.VeticalAlignment=StringAlignment.Center;
					break;
				case "btnLB":
					ctl.HorizontalAlignment=StringAlignment.Near;
					ctl.VeticalAlignment=StringAlignment.Far;
					break;
				case "btnCB":
					ctl.HorizontalAlignment=StringAlignment.Center;
					ctl.VeticalAlignment=StringAlignment.Far;
					break;
				case "btnRB":
					ctl.HorizontalAlignment=StringAlignment.Far;
					ctl.VeticalAlignment=StringAlignment.Far;
					break;
			}
			ctl.Refresh();
		}
		void BtnFontClick(object sender, EventArgs e)
		{
			using (var fd=new FontDialog()) {
				var lbl=m_control as Controls.wLabel;
				fd.Font=lbl.Font;
				if(fd.ShowDialog()==DialogResult.OK){
					txtFont.Text=fd.Font.ToString();
					lbl.Font=fd.Font;
					Control.Refresh();
				}
			}
		}
		void TxtValueLeave(object sender, EventArgs e)
		{
			Control.Text=txtValue.Text;
			Control.Refresh();
		}
	}
}
