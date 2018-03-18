/*
 * Copyright (C) 2016-2018
 * 由SharpDevelop创建。
 * 作者: Byron Gong
 * 日期: 03/09/2018 时间: 9:59
 * 邮箱: 1032066879@QQ.com
 * 描述: 图片框编辑
 *
 */ 
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Spoon.Tools.TemplatePrint.Editer
{
	/// <summary>
	/// Description of wImageEditer.
	/// </summary>
	public partial class wImageEditer : wControlEditer
	{
		public new Controls.wImage Control{
			get{return m_control as Controls.wImage;}
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
		
		public wImageEditer()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
		}
		
		public wImageEditer(Controls.wImage control):base(control){
			InitializeComponent();
			Control=control;
		}
		
		new void OnPropertyChanged(object sender,EventArgs args){
			if(Control==null){
				return;
			}
			base.OnPropertyChanged(sender,args);
			txtImagePath.Text=Control.ImagePath;
		}
		void BtnPathClick(object sender, EventArgs e)
		{
			using (var ofd=new OpenFileDialog()) {
				ofd.Filter="图片文件(*.jpeg;*.jpg;*.png;*.bmp;*.gif)|*.jpeg;*.jpg;*.png;*.bmp;*.gif|所有文件(*.*)|*.*";
				if(ofd.ShowDialog()==DialogResult.OK){
					txtImagePath.Text=ofd.FileName;
					Control.ImagePath=ofd.FileName;
				}
			}
		}
		void TxtImagePathLeave(object sender, EventArgs e)
		{
//			Control.ImagePath=txtImagePath.Text;
		}
	}
}
