/*
 * Copyright (C) 2016-2018
 * 由SharpDevelop创建。
 * 作者: Byron Gong
 * 日期: 03/05/2018 时间: 15:18
 * 邮箱: 1032066879@QQ.com
 * 描述: 条形码
 *
 */ 
using System;
using System.Drawing;

namespace Spoon.Tools.TemplatePrint.Controls
{
	/// <summary>
	/// 条形码控件
	/// </summary>
	public class wBarcode:wControl
	{
		private string m_value=string.Empty;
		private BarcodeLib.TYPE m_type=BarcodeLib.TYPE.CODE128;
		private bool m_showText=true;
		private Image m_image=null;
		
		/// <summary>
		/// 文本
		/// </summary>
		public string Text{
			get{return m_value;}
			set{
				m_value=value;
				GenerateImage();
			}
		}
		
		/// <summary>
		/// 编码格式
		/// </summary>
		public BarcodeLib.TYPE EncodeType{
			get{return m_type;}
			set{
				m_type=value;
				GenerateImage();
			}
		}
		
		/// <summary>
		/// 显示文本
		/// </summary>
		public bool ShowText{
			get{return m_showText;}
			set{
				m_showText=value;
				GenerateImage();
			}
		}
		
		public wBarcode()
		{
			ShowBorder=false;
			Size=new Size(150,50);
		}
		
		public wBarcode(System.Xml.XmlNode node):base(node){
			ShowText=bool.Parse(node.Attributes["text-visible"].Value);
			BarcodeLib.TYPE tp;
			Enum.TryParse<BarcodeLib.TYPE>(node.Attributes["encoding"].Value,out tp);
			EncodeType=tp;
			Text=node.Attributes["text"].Value;
		}
		
		protected override void OnSizeChanged(EventArgs e)
		{
			base.OnSizeChanged(e);
			if(Height<10){
				Height=10;
			}
			try {
				GenerateImage();
			} catch (Exception err) {
				if(err.Message.StartsWith("EGENERATE_IMAGE-2",StringComparison.CurrentCulture)){
					Width+=5;
					OnSizeChanged(EventArgs.Empty);
				}
			}
			
		}
		/// <summary>
		/// 绘图
		/// </summary>
		/// <param name="g"></param>
		public override void Paint(System.Drawing.Graphics g)
		{
			base.Paint(g);
			if(m_image!=null){
				var rect=Rectangle;
				rect.Offset(1,1);
				rect.Width-=1;
				rect.Height-=1;
				g.DrawImage(m_image,rect);
			}
			
		}
		
		public override void DoPrintJson(Newtonsoft.Json.Linq.JToken json, Spoon.Tools.TemplatePrint.Helper.PrintHelper.wPrintEventArgs e)
		{
			base.DoPrintJson(json, e);
			var txt=Text;
			var jo=json as Newtonsoft.Json.Linq.JObject;
			
			if(jo!=null && jo.ContainsKey(Name)){
				Text=jo[Name].ToString();
			}
			if(m_image!=null){
				var rect=Rectangle;
				rect.Offset(1,1);
				rect.Width-=1;
				rect.Height-=1;
				rect.Offset(e.Offset);
				e.Graphics.DrawImage(m_image,rect);
			}
			Text=txt;
		}
		
		public override void DoPrint(System.Collections.Generic.Dictionary<string, object> datalist,Helper.PrintHelper.wPrintEventArgs e)
		{
			base.DoPrint(datalist,e);
			var txt=Text;
			if(datalist!=null && datalist.ContainsKey(Name)){
				Text=datalist[Name].ToString();
			}
			if(m_image!=null){
				var rect=Rectangle;
				rect.Offset(1,1);
				rect.Width-=1;
				rect.Height-=1;
				rect.Offset(e.Offset);
				e.Graphics.DrawImage(m_image,rect);
			}
			Text=txt;
		}
		
		public override object Clone()
		{
			var code=new wBarcode();
			code.Name=Name;
			code.Rectangle=Rectangle;
			code.Text=Text;
			code.EncodeType=EncodeType;
			code.Parent=Parent;
			code.ShowBorder=ShowBorder;
			code.ShowText=ShowText;
			return code;
		}
		
		public override System.Xml.XmlNode ToXml(System.Xml.XmlNode node)
		{
			var ctl=node.OwnerDocument.CreateElement("barcode");
			Helper.XmlHelper.AddAttribute("encoding",EncodeType.ToString(),ctl);
			Helper.XmlHelper.AddAttribute("text",Text,ctl);
			Helper.XmlHelper.AddAttribute("text-visible",ShowText.ToString(),ctl);
			return base.ToXml(ctl);
		}
		
		/// <summary>
		/// 生成图片
		/// </summary>
		private void GenerateImage(){
			if(m_value!=string.Empty){
				m_image=BarcodeLib.Barcode.DoEncode(m_type,m_value,m_showText,Color.Black,Color.Transparent,Size.Width-1,Size.Height-1);
			}else{
				m_image=null;
			}
		}
	}
}
