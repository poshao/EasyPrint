/*
 * Copyright (C) 2016-2018
 * 由SharpDevelop创建。
 * 作者: Byron Gong
 * 日期: 03/05/2018 时间: 11:23
 * 邮箱: 1032066879@QQ.com
 * 描述: 文本框
 *
 */ 
using System;
using System.Drawing;

namespace Spoon.Tools.TemplatePrint.Controls
{
	[Serializable]
	/// <summary>
	/// Description of wLabel.
	/// </summary>
	public sealed class wLabel:wControl
	{
		private string m_value=string.Empty;
		private Font m_font=SystemFonts.DefaultFont;
		private StringAlignment m_alignHorizontal=StringAlignment.Near;
		private StringAlignment m_alignVetical=StringAlignment.Near;
		
		/// <summary>
		/// 显示内容
		/// </summary>
		public string Text{
			get{return m_value;}
			set{m_value=value;base.OnPropertyChanged(EventArgs.Empty);}
		}
		
		/// <summary>
		/// 对齐方式
		/// </summary>
		public StringAlignment HorizontalAlignment{
			get{return m_alignHorizontal;}
			set{m_alignHorizontal=value;OnPropertyChanged(EventArgs.Empty);}
		}
		
		/// <summary>
		/// 对齐方式
		/// </summary>
		public StringAlignment VeticalAlignment{
			get{return m_alignVetical;}
			set{m_alignVetical=value;OnPropertyChanged(EventArgs.Empty);}
		}
		
		/// <summary>
		/// 字体
		/// </summary>
		public Font Font{
			get{return m_font;}
			set{m_font=value;OnPropertyChanged(EventArgs.Empty);}
		}
		
		public wLabel()
		{
			ShowBorder=true;
			Name="Label";
		}
		
		public wLabel(System.Xml.XmlNode node):base(node){
			FontConverter fc=new FontConverter();
			Text=node.Attributes["text"].Value;
			Font=fc.ConvertFromString(node.Attributes["font"].Value)as Font;
			
			StringAlignment h,v;
			Enum.TryParse<StringAlignment>(node.Attributes["horizontal-alignment"].Value,out h);
			Enum.TryParse<StringAlignment>(node.Attributes["vetical-alignment"].Value,out v);
			
			HorizontalAlignment=h;
			VeticalAlignment=v;
		}
		
		/// <summary>
		/// 绘图
		/// </summary>
		/// <param name="g"></param>
		public override void Paint(Graphics g)
		{
			base.Paint(g);
			var rect=Rectangle;
			rect.Offset(1,1);
			rect.Width-=1;
			rect.Height-=1;
			var sf=new StringFormat();
			sf.Alignment=m_alignHorizontal;
			sf.LineAlignment=m_alignVetical;
			g.DrawString(m_value,m_font,Brushes.Black,new RectangleF(rect.Location,rect.Size),sf);
		}
		
		public override void DoPrint(System.Collections.Generic.Dictionary<string, string> datalist,Helper.PrintHelper.wPrintEventArgs e)
		{
			base.DoPrint(datalist,e);
			var txt=m_value;
			if(datalist!=null && datalist.ContainsKey(Name)){
				txt=datalist[Name];
			}
			var rect=Rectangle;
			rect.Offset(1,1);
			rect.Width-=1;
			rect.Height-=1;
			rect.Offset(e.Offset);
			var sf=new StringFormat();
			sf.Alignment=m_alignHorizontal;
			sf.LineAlignment=m_alignVetical;
			e.Graphics.DrawString(txt,m_font,Brushes.Black,new RectangleF(rect.Location,rect.Size),sf);
		}
		
		public override object Clone()
		{
			var lbl=new wLabel();
			lbl.Rectangle=Rectangle;
			lbl.Name=Name;
			lbl.Text=Text;
			lbl.Parent=Parent;
			lbl.Font=Font;
			lbl.HorizontalAlignment=HorizontalAlignment;
			lbl.VeticalAlignment=VeticalAlignment;
			return lbl;
		}
		
		public override System.Xml.XmlNode ToXml(System.Xml.XmlNode node)
		{
			var ctl=node.OwnerDocument.CreateElement("label");
			Helper.XmlHelper.AddAttribute("text",Text,ctl);
			Helper.XmlHelper.AddAttribute("horizontal-alignment",HorizontalAlignment.ToString(),ctl);
			Helper.XmlHelper.AddAttribute("vetical-alignment",VeticalAlignment.ToString(),ctl);
			var fc=new FontConverter();
			Helper.XmlHelper.AddAttribute("font",fc.ConvertToString(Font),ctl);
			return base.ToXml(ctl);
		}
	}
}
