/*
 * Copyright (C) 2016-2018
 * 由SharpDevelop创建。
 * 作者: Byron Gong
 * 日期: 03/09/2018 时间: 16:29
 * 邮箱: 1032066879@QQ.com
 * 描述: 画布属性编辑
 *
 */ 
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Spoon.Tools.TemplatePrint.Editer
{
	/// <summary>
	/// Description of wCanvasEditer.
	/// </summary>
	public partial class wCanvasEditer : UserControl
	{
		protected wCanvas m_control=null;
		protected EventHandler m_propertyEvent=null;
		
		public wCanvas Control{
			get{return m_control;}
			set{
				m_control=value;
				if(value!=null){
					InitData();
				}
			}
		}
		
		public int bLeft{
			get{return m_control.BackgroundRect.X;}
			set{
				var rect=m_control.BackgroundRect;
//				if(rect.X!=value){
					rect.X=value;
					Control.BackgroundRect=rect;
					txtLeftPixel.Text=value.ToString();
					txtLeftMm.Text=PrintHelper.DisplayToMm(value).ToString();
					m_control.Refresh();
//				}
			}
		}
		
		public int bTop{
			get{return m_control.BackgroundRect.Top;}
			set{
				var rect=m_control.BackgroundRect;
//				if(rect.Y!=value){
					rect.Y=value;
					Control.BackgroundRect=rect;
					txtTopPixel.Text=value.ToString();
					txtTopMm.Text=PrintHelper.DisplayToMm(value).ToString();
					m_control.Refresh();
//				}
			}
		}
		
		public int bWidth{
			get{return m_control.BackgroundRect.Width;}
			set{
				var rect=m_control.BackgroundRect;
//				if(rect.Width!=value){
					rect.Width=value;
					Control.BackgroundRect=rect;
					txtWidthPixel.Text=value.ToString();
					txtWidthMm.Text=PrintHelper.DisplayToMm(value).ToString();
					m_control.Refresh();
//				}
			}
		}
		
		public int bHeight{
			get{return m_control.BackgroundRect.Height;}
			set{
				var rect=m_control.BackgroundRect;
//				if(rect.Height!=value){
					rect.Height=value;
					Control.BackgroundRect=rect;
					txtHeightPixel.Text=value.ToString();
					txtHeightMm.Text=PrintHelper.DisplayToMm(value).ToString();
					m_control.Refresh();
//				}
			}
		}
		
		public int cWidth{
			get{return m_control.Width;}
			set{
				m_control.Width=value;
				txtSizeWidthPixel.Text=value.ToString();
				txtSizeWidthMm.Text=PrintHelper.DisplayToMm(value).ToString();
			}
		}
		
		public int cHeight{
			get{return m_control.Height;}
			set{
				m_control.Height=value;
				txtSizeHeightPixel.Text=value.ToString();
				txtSizeHeightMm.Text=PrintHelper.DisplayToMm(value).ToString();
			}
		}
		
		protected void InitData(){
			if(Control==null) return;
			
			txtPath.Text=Control.BackgroundPath;
			bLeft=Control.BackgroundRect.Left;
			bTop=Control.BackgroundRect.Top;
			bWidth=Control.BackgroundRect.Width;
			bHeight=Control.BackgroundRect.Height;
			
			if(Control.BackgroundScale==0){
				ckScale.Checked=false;
				txtScale.Text="0";
			}else{
				ckScale.Checked=true;
				txtScale.Text=Control.BackgroundScale.ToString();
			}
			
			ckShowBackground.Checked=Control.ShowBackground;
			
			cWidth=Control.Width;
			cHeight=Control.Height;
			
			txtAuthor.Text=Control.Author;
			txtCreate.Text=Control.CreateTime.ToString();
		}
		
		public wCanvasEditer()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
		}
		
		public wCanvasEditer(wCanvas control){
			InitializeComponent();
			Control=control;			
		}
		
		void OnTextBoxLeave(object sender,EventArgs e){
			var txt = sender as TextBox;
			if(Control==null || txt==null) return;
			
			switch (txt.Name) {
				case "txtPath":
					Control.BackgroundPath=txt.Text;
					break;
				case "txtScale":
					float scale;
					if(!float.TryParse(txt.Text,out scale)){
						MessageBox.Show("请输入有效的数值");
						txt.Focus();
						return;
					}
					bWidth=(int)(scale*Control.BackgroundImage.Width);
					bHeight=(int)(scale*Control.BackgroundImage.Height);
					Control.BackgroundScale=scale;
					Control.Refresh();
					break;
				case "txtLeftPixel":
					bLeft=int.Parse(txt.Text);
					break;
				case "txtTopPixel":
					bTop=int.Parse(txt.Text);
					break;
				case "txtWidthPixel":
					bWidth=int.Parse(txt.Text);
					break;
				case "txtHeightPixel":
					bHeight=int.Parse(txt.Text);
					break;
				case "txtLeftMm":
					bLeft=PrintHelper.MmToDisplay(float.Parse(txt.Text));
					break;
				case "txtTopMm":
					bTop=PrintHelper.MmToDisplay(float.Parse(txt.Text));
					break;
				case "txtWidthMm":
					bWidth=PrintHelper.MmToDisplay(float.Parse(txt.Text));
					break;
				case "txtHeightMm":
					bHeight=PrintHelper.MmToDisplay(float.Parse(txt.Text));
					break;
				case "txtSizeWidthPixel":
					cWidth=int.Parse(txt.Text);
					break;
				case "txtSizeHeightPixel":
					cHeight=int.Parse(txt.Text);
					break;
				case "txtSizeWidthMm":
					cWidth=PrintHelper.MmToDisplay(float.Parse(txt.Text));
					break;
				case "txtSizeHeightMm":
					cHeight=PrintHelper.MmToDisplay(float.Parse(txt.Text));
					break;
				case "txtAuthor":
					Control.Author=txt.Text;
					break;
			}
		}
		
		void OnTextBoxKeyDown(object sender,KeyEventArgs arg){
			if(arg.KeyCode==Keys.Enter){
				OnTextBoxLeave(sender,EventArgs.Empty);
			}
		}
		
		void BtnPathClick(object sender, EventArgs e)
		{
			if(Control==null){
				return;
			}
			using (var ofd=new OpenFileDialog()) {
				ofd.Filter="图片文件(*.jpeg;*.jpg;*.png;*.bmp;*.gif)|*.jpeg;*.jpg;*.png;*.bmp;*.gif|所有文件(*.*)|*.*";
				if(ofd.ShowDialog()==DialogResult.OK){
					txtPath.Text=ofd.FileName;
					Control.BackgroundPath=ofd.FileName;
				}
			}
		}
		
		void CkShowBackgroundCheckStateChanged(object sender, EventArgs e)
		{
			Control.ShowBackground=ckShowBackground.Checked;
		}
		
		void CkScaleCheckStateChanged(object sender, EventArgs e)
		{
			if(ckScale.Checked){
				txtWidthPixel.Enabled=false;
				txtWidthMm.Enabled=false;
				txtHeightPixel.Enabled=false;
				txtHeightMm.Enabled=false;
				txtScale.Enabled=true;
				txtScale.Focus();
				
			}else{
				txtWidthPixel.Enabled=true;
				txtWidthMm.Enabled=true;
				txtHeightPixel.Enabled=true;
				txtHeightMm.Enabled=true;
				txtScale.Enabled=false;
				
			}
		}

	}
}
