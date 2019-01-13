/*
 * Copyright (C) 2016-2018
 * 由SharpDevelop创建。
 * 作者: Byron Gong
 * 日期: 03/15/2018 时间: 13:39
 * 邮箱: 1032066879@QQ.com
 * 描述: 二维码控件
 *
 */ 
using System;
using System.Drawing;

namespace Spoon.Tools.TemplatePrint.Controls
{
	/// <summary>
	/// Description of wQRCoder.
	/// </summary>
	public class wQRCoder:wControl
	{
		private string m_text="qrcode";
		private QRCoder.QRCodeGenerator.ECCLevel m_level=QRCoder.QRCodeGenerator.ECCLevel.Q;
		private int m_pixelsPerModule=3;
		
		private Image m_image=null;
		
		/// <summary>
		/// 显示内容
		/// </summary>
		public string Text{
			get{return m_text;}
			set{
				m_text=value;
				GenerateImage();
				OnPropertyChanged(EventArgs.Empty);
			}
		}
		
		/// <summary>
		/// 兼容性级别
		/// </summary>
		public QRCoder.QRCodeGenerator.ECCLevel Level{
			get{return m_level;}
			set{
				m_level=value;
				GenerateImage();
				OnPropertyChanged(EventArgs.Empty);
			}
		}
		
		/// <summary>
		/// 像素宽度
		/// </summary>
		public int PixelsPerModule{
			get{return m_pixelsPerModule;}
			set{
				m_pixelsPerModule=value;
				GenerateImage();
				OnPropertyChanged(EventArgs.Empty);
			}
		}
		
		public wQRCoder()
		{
			ShowBorder=false;
		}
		
		public wQRCoder(System.Xml.XmlNode node):base(node){
			Text=node.Attributes["text"].Value;
			PixelsPerModule=int.Parse(node.Attributes["pixels"].Value);
			QRCoder.QRCodeGenerator.ECCLevel level;
			Enum.TryParse<QRCoder.QRCodeGenerator.ECCLevel>(node.Attributes["level"].Value,out level);
			Level=level;
		}
		
		protected override void OnSizeChanged(EventArgs e)
		{
			base.OnSizeChanged(e);
			if(m_image!=null){
				Size=m_image.Size;
			}
		}
		
		public override void Paint(Graphics g)
		{
			base.Paint(g);
			if(m_image!=null){
				var rect=Rectangle;
				rect.Offset(1,1);
				rect.Width-=1;
				rect.Height-=1;
				g.DrawImageUnscaledAndClipped(m_image,rect);
			}
		}
		
		public override void DoPrintJson(Newtonsoft.Json.Linq.JToken json, Spoon.Tools.TemplatePrint.Helper.PrintHelper.wPrintEventArgs e)
		{
			base.DoPrintJson(json, e);
			var jo=json as Newtonsoft.Json.Linq.JObject;
			if(jo!=null && jo.ContainsKey(Name)){
				GenerateImage(jo[Name].ToString());
			}
			var rect=Rectangle;
			rect.Offset(1,1);
			rect.Width-=1;
			rect.Height-=1;
			rect.Offset(e.Offset);
			if(m_image!=null){
				e.Graphics.DrawImageUnscaledAndClipped(m_image,rect);
			}
			GenerateImage();
		}
		
		public override void DoPrint(System.Collections.Generic.Dictionary<string, object> datalist, Helper.PrintHelper.wPrintEventArgs e)
		{
			base.DoPrint(datalist, e);
			if(datalist!=null && datalist.ContainsKey(Name)){
				GenerateImage(datalist[Name].ToString());
			}
			var rect=Rectangle;
			rect.Offset(1,1);
			rect.Width-=1;
			rect.Height-=1;
			rect.Offset(e.Offset);
			if(m_image!=null){
				e.Graphics.DrawImageUnscaledAndClipped(m_image,rect);
			}
			GenerateImage();
		}
		
		public override object Clone()
		{
			var ctl=new wQRCoder();
			ctl.Name=Name;
			ctl.Rectangle=Rectangle;
			ctl.Level=Level;
			ctl.Text=Text;
			ctl.ShowBorder=ShowBorder;
			ctl.Parent=Parent;
			return ctl;
		}
		
		public override System.Xml.XmlNode ToXml(System.Xml.XmlNode node)
		{
			var ctl=node.OwnerDocument.CreateElement("qrcoder");
			Helper.XmlHelper.AddAttribute("text",Text,ctl);
			Helper.XmlHelper.AddAttribute("level",Level.ToString(),ctl);
			Helper.XmlHelper.AddAttribute("pixels",PixelsPerModule.ToString(),ctl);
			return base.ToXml(ctl);
		}
		
		private void GenerateImage(){
			GenerateImage(m_text);
		}
		
		private void GenerateImage(string text){
			if(m_image!=null){
				m_image.Dispose();
				m_image=null;
			}
			if(m_text!=string.Empty){
				using(var qg=new QRCoder.QRCodeGenerator()){
					var qr=new QRCoder.QRCode(qg.CreateQrCode(text,m_level));
					m_image=qr.GetGraphic(m_pixelsPerModule);
					Size=m_image.Size;
					qr.Dispose();
				}
			}
		}
	}
}
