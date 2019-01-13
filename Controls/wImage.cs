/*
 * Copyright (C) 2016-2018
 * 由SharpDevelop创建。
 * 作者: Byron Gong
 * 日期: 03/05/2018 时间: 14:50
 * 邮箱: 1032066879@QQ.com
 * 描述: 图片控件
 *
 */ 
using System;
using System.Drawing;

namespace Spoon.Tools.TemplatePrint.Controls
{
	/// <summary>
	/// 图片控件
	/// </summary>
	public class wImage:wControl
	{
		private string m_src=string.Empty;
		private Image m_img=null;
		
		/// <summary>
		/// 图片路径
		/// </summary>
		public string ImagePath{
			get{return m_src;}
			set{
				if(!System.IO.File.Exists(value)){
					throw new Exception("无效路径");
				}
				m_src=value;
				var img=Image.FromFile(m_src);
				m_img=new Bitmap(img);
				img.Dispose();
			}
		}
		
		public wImage()
		{
			Size=new Size(100,100);
		}
		
		public wImage(System.Xml.XmlNode node):base(node){
			ImagePath=node.Attributes["src"].Value;
		}
		
		public override void Paint(Graphics g)
		{
			base.Paint(g);
			var rect=Rectangle;
			rect.Offset(1,1);
			rect.Width-=1;
			rect.Height-=1;
			if(m_img!=null){
				g.DrawImage(m_img,rect);
			}else{
				using (var pen=new Pen(Color.Red)) {
					pen.Width=3;
					g.DrawLine(pen,rect.X,rect.Y,rect.Right,rect.Bottom);
					g.DrawLine(pen,rect.X,rect.Bottom,rect.Right,rect.Top);
					
				}
			}
		}
		
		public override void DoPrintJson(Newtonsoft.Json.Linq.JToken json, Spoon.Tools.TemplatePrint.Helper.PrintHelper.wPrintEventArgs e)
		{
			base.DoPrintJson(json, e);
			var img=m_img;
			var jo=json as Newtonsoft.Json.Linq.JObject;
			if(jo!=null && jo.ContainsKey(Name)){
				var img2=Image.FromFile(jo[Name].ToString());
				img=new Bitmap(img2);
				img2.Dispose();
			}
			var rect=Rectangle;
			rect.Offset(1,1);
			rect.Width-=1;
			rect.Height-=1;
			rect.Offset(e.Offset);
			if(img!=null){
				e.Graphics.DrawImage(img,rect);
			}
		}
		
		public override void DoPrint(System.Collections.Generic.Dictionary<string, object> datalist,Helper.PrintHelper.wPrintEventArgs e)
		{
			base.DoPrint(datalist,e);
			var img=m_img;
			if(datalist!=null && datalist.ContainsKey(Name)){
				var img2=Image.FromFile(datalist[Name].ToString());
				img=new Bitmap(img2);
				img2.Dispose();
			}
			var rect=Rectangle;
			rect.Offset(1,1);
			rect.Width-=1;
			rect.Height-=1;
			rect.Offset(e.Offset);
			if(img!=null){
				e.Graphics.DrawImage(img,rect);
			}
		}
		
		public override object Clone()
		{
			var img=new wImage();
			img.Name=Name;
			img.ShowBorder=ShowBorder;
			img.Rectangle=Rectangle;
			img.ImagePath=ImagePath;
			img.Parent=Parent;
			return img;
		}
		
		public override System.Xml.XmlNode ToXml(System.Xml.XmlNode node)
		{
			var ctl=node.OwnerDocument.CreateElement("image");
			Helper.XmlHelper.AddAttribute("src",ImagePath,ctl);
			return base.ToXml(ctl);
		}
	}
}
