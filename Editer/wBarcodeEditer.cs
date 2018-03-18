/*
 * Copyright (C) 2016-2018
 * 由SharpDevelop创建。
 * 作者: Byron Gong
 * 日期: 03/09/2018 时间: 11:28
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
	/// Description of wBarcodeEditer.
	/// </summary>
	public partial class wBarcodeEditer : wControlEditer
	{
		public new Controls.wBarcode Control{
			get{return m_control as Controls.wBarcode;}
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
			for (int i = 0; i < cbEncodingType.Items.Count; i++) {
				if(Control.EncodeType.ToString()==cbEncodingType.Items[i].ToString()){
					cbEncodingType.SelectedIndex=i;
					break;
				}
			}
			
			txtValue.Text=Control.Text;
			ckShowText.Checked=Control.ShowText;
		}
		
		public wBarcodeEditer()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			InitEncodingType();
		}
		
		public wBarcodeEditer(Controls.wBarcode control):base(control){
			InitializeComponent();
			InitEncodingType();
			Control=control;
		}
		
		void InitEncodingType(){
			cbEncodingType.Items.Clear();
			foreach (var item in Enum.GetValues(typeof(BarcodeLib.TYPE))) {
				cbEncodingType.Items.Add(item);
			}
		}
		
		void TxtValueLeave(object sender, EventArgs e)
		{
			if(Control!=null){
				Control.Text=txtValue.Text;
				Control.Refresh();
			}
		}
		void CkShowTextCheckStateChanged(object sender, EventArgs e)
		{
			if(Control!=null){
				Control.ShowText=ckShowText.Checked;
				Control.Refresh();
			}
		}
		void CbEncodingTypeSelectedIndexChanged(object sender, EventArgs e)
		{
			if(Control!=null){
				BarcodeLib.TYPE tp;
				Enum.TryParse<BarcodeLib.TYPE>(cbEncodingType.Text,out tp);
				Control.EncodeType=tp;
				Control.Refresh();
			}
		}
		void TxtValueKeyDown(object sender, KeyEventArgs e)
		{
			if(e.KeyCode==Keys.Enter){
				TxtValueLeave(sender,EventArgs.Empty);
			}
		}
	}
}
