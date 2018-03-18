/*
 * Copyright (C) 2016-2018
 * 由SharpDevelop创建。
 * 作者: Byron Gong
 * 日期: 03/15/2018 时间: 14:22
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
	/// Description of wQRCoderEditer.
	/// </summary>
	public partial class wQRCoderEditer : wControlEditer
	{
		public new Controls.wQRCoder Control{
			get{return m_control as Controls.wQRCoder;}
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
			for (int i = 0; i < cbLevelType.Items.Count; i++) {
				if(Control.Level.ToString()==cbLevelType.Items[i].ToString()){
					cbLevelType.SelectedIndex=i;
					break;
				}
			}
			nudPixel.Value=Control.PixelsPerModule;
			txtValue.Text=Control.Text;
		}
		
		public wQRCoderEditer()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			m_propertyEvent=new Spoon.Tools.TemplatePrint.Controls.wControl.PropertyChangedEventHandler(OnPropertyChanged);
			InitLevelType();
		}
		
		public wQRCoderEditer(Controls.wQRCoder control)
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			m_propertyEvent=new Spoon.Tools.TemplatePrint.Controls.wControl.PropertyChangedEventHandler(OnPropertyChanged);
			InitLevelType();
			Control=control;
		}
		
		private void InitLevelType(){
			cbLevelType.Items.Clear();
			foreach (var item in Enum.GetValues(typeof(QRCoder.QRCodeGenerator.ECCLevel))) {
				cbLevelType.Items.Add(item);
			}
		}
		
		void CbLevelTypeSelectedIndexChanged(object sender, EventArgs e)
		{
			if(Control!=null){
				QRCoder.QRCodeGenerator.ECCLevel tp;
				Enum.TryParse<QRCoder.QRCodeGenerator.ECCLevel>(cbLevelType.Text,out tp);
				Control.Level=tp;
				Control.Refresh();
			}
		}
		void OnTextBoxLeave(object sender, EventArgs e)
		{
			if(Control==null){
				return;
			}
			var txt=sender as TextBox;
			switch (txt.Name) {
				case "txtValue":
					Control.Text=txt.Text;
					break;
			}
			Control.Refresh();
		}
		void OnTextBoxKeyDown(object sender, KeyEventArgs e)
		{
			if(e.Control && e.KeyCode==Keys.Enter){
				e.Handled=true;
				e.SuppressKeyPress=true;
				OnTextBoxLeave(sender,EventArgs.Empty);
			}
		}
		void NudPixelValueChanged(object sender, EventArgs e)
		{
			if(Control!=null){
				Control.PixelsPerModule=(int)nudPixel.Value;
				Control.Refresh();
			}
		}
		
	}
}
