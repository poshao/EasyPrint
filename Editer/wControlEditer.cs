/*
 * Copyright (C) 2016-2018
 * 由SharpDevelop创建。
 * 作者: Byron Gong
 * 日期: 03/07/2018 时间: 16:45
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
	/// Description of wControlEditer.
	/// </summary>
	public partial class wControlEditer : UserControl
	{
		protected Controls.wControl m_control=null;
		protected Controls.wControl.PropertyChangedEventHandler m_propertyEvent=null;
		
		public int wLeft{
			get{return m_control.Left;}
			set{
				m_control.Left=value;
				txtLeftPixel.Text=value.ToString();
				txtLeftMm.Text=Helper.PrintHelper.DisplayToMm(value).ToString();
			}
		}
		public int wTop{
			get{return m_control.Top;}
			set{
				m_control.Top=value;
				txtTopPixel.Text=value.ToString();
				txtTopMm.Text=Helper.PrintHelper.DisplayToMm(value).ToString();
			}
		}
		public int wWidth{
			get{return m_control.Width;}
			set{
				m_control.Width=value;
				txtWidthPixel.Text=value.ToString();
				txtWidthMm.Text=Helper.PrintHelper.DisplayToMm(value).ToString();
			}
		}
		public int wHeight{
			get{return m_control.Height;}
			set{
				m_control.Height=value;
				txtHeightPixel.Text=value.ToString();
				txtHeightMm.Text=Helper.PrintHelper.DisplayToMm(value).ToString();
			}
		}
		public Controls.wControl Control{
			get{return m_control;}
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
		
		public wControlEditer(){
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
		}
		
		public wControlEditer(Controls.wControl control)
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			m_propertyEvent=new Controls.wControl.PropertyChangedEventHandler(OnPropertyChanged);
			Control=control;
		}
		
		protected void OnPropertyChanged(object sender,EventArgs args){
			txtName.Text=m_control.Name;
			wLeft=m_control.Left;
			wTop=m_control.Top;
			wWidth=m_control.Width;
			wHeight=m_control.Height;
			cbShowBorder.Checked=m_control.ShowBorder;
		}
		
		void OnTextBoxLeave(object sender, EventArgs e)
		{
			var txt=sender as TextBox;
			switch (txt.Name) {
				case "txtName":
					m_control.Name=txt.Text;
					break;
				case "txtLeftPixel":
					wLeft=int.Parse(txt.Text);
					break;
				case "txtTopPixel":
					wTop=int.Parse(txt.Text);
					break;
				case "txtWidthPixel":
					wWidth=int.Parse(txt.Text);
					break;
				case "txtHeightPixel":
					wHeight=int.Parse(txt.Text);
					break;
				case "txtLeftMm":
					wLeft=Helper.PrintHelper.MmToDisplay(float.Parse(txt.Text));
					break;
				case "txtTopMm":
					wTop=Helper.PrintHelper.MmToDisplay(float.Parse(txt.Text));
					break;
				case "txtWidthMm":
					wWidth=Helper.PrintHelper.MmToDisplay(float.Parse(txt.Text));
					break;
				case "txtHeightMm":
					wHeight=Helper.PrintHelper.MmToDisplay(float.Parse(txt.Text));
					break;
			}
			m_control.Refresh();
		}
		
		void OnTextBoxLeaveKeyDown(object sender, KeyEventArgs e){
			if(e.KeyCode==Keys.Enter){
				OnTextBoxLeave(sender, EventArgs.Empty);
			}
		}
		
		void CbShowBorderCheckStateChanged(object sender, EventArgs e)
		{
			m_control.ShowBorder=cbShowBorder.Checked;
			m_control.Refresh();
		}
	}
}
