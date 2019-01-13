/*
 * Copyright (C) 2016-2018
 * 由SharpDevelop创建。
 * 作者: Byron Gong
 * 日期: 03/05/2018 时间: 10:54
 * 邮箱: 1032066879@QQ.com
 * 描述: 控件基类
 *
 */ 
using System;
using System.Drawing;

namespace Spoon.Tools.TemplatePrint.Controls
{
	/// <summary>
	/// 控件基类
	/// </summary>
	public abstract class wControl:IwSerializable,IwPrint
	{
		public delegate void SizeChangedEventHandler(object sender,EventArgs args);
		public event SizeChangedEventHandler SizeChangedEvent;
		
		public delegate void LocationChangedEventHandler(object sender,EventArgs args);
		public event LocationChangedEventHandler LocationChangeedEvent;
		
		public delegate void PropertyChangedEventHandler(object sender,EventArgs args);
		public event PropertyChangedEventHandler PropertyChangedEvent;
		
		private string m_name=string.Empty;
		private Rectangle m_rect=new Rectangle(0,0,80,50);
		private bool m_showBorder=true;
		private System.Windows.Forms.Control m_parent=null;
		
		protected virtual void OnSizeChanged(EventArgs e){
			var handler=SizeChangedEvent;
			if(handler!=null){
				handler(this,e);
			}
		}
		
		protected virtual void OnLocationChanged(EventArgs e){
			var handler=LocationChangeedEvent;
			if(handler!=null){
				handler(this,e);
			}
		}
		
		protected virtual void OnPropertyChanged(EventArgs e){
			var handler=PropertyChangedEvent;
			if(handler!=null){
				handler(this,e);
			}
		}
		/// <summary>
		/// 名称
		/// </summary>
		public string Name{
			get{return m_name;}
			set{
				if(m_name!=value){
					m_name=value;
					OnPropertyChanged(EventArgs.Empty);
				}
			}
		}
		
		/// <summary>
		/// 左侧位置
		/// </summary>
		public int Left{
			get{return m_rect.X;}
			set{
				if(m_rect.X!=value){
					m_rect.X=value;
					OnLocationChanged(EventArgs.Empty);
					OnPropertyChanged(EventArgs.Empty);
				}
			}
		}
		
		/// <summary>
		/// 顶部位置
		/// </summary>
		public int Top{
			get{return m_rect.Y;}
			set{
				if(m_rect.Y!=value){
					m_rect.Y=value;
					OnLocationChanged(EventArgs.Empty);
					OnPropertyChanged(EventArgs.Empty);
				}
			}
		}
		
		/// <summary>
		/// 右侧位置
		/// </summary>
		public int Right{
			get{return m_rect.Right;}
		}
		
		/// <summary>
		/// 底部位置
		/// </summary>
		public int Bottom{
			get{return m_rect.Bottom;}
		}
		
		/// <summary>
		/// 宽度
		/// </summary>
		public int Width{
			get{return m_rect.Width;}
			set{
				if(value>0 && m_rect.Width!=value){
					m_rect.Width=value;
					OnSizeChanged(EventArgs.Empty);
					OnPropertyChanged(EventArgs.Empty);
				}
			}
		}
		
		/// <summary>
		/// 高度
		/// </summary>
		public int Height{
			get{return m_rect.Height;}
			set{
				if(value>0 && m_rect.Height!=value){
					m_rect.Height=value;
					OnSizeChanged(EventArgs.Empty);
					OnPropertyChanged(EventArgs.Empty);
				}
			}
		}
		/// <summary>
		/// 位置
		/// </summary>
		public Point Location{
			get{return m_rect.Location;}
			set{
				if(m_rect.Location!=value){
					m_rect.Location=value;
					OnLocationChanged(EventArgs.Empty);
					OnPropertyChanged(EventArgs.Empty);
				}
			}
		}
		
		/// <summary>
		/// 尺寸
		/// </summary>
		public Size Size{
			get{return m_rect.Size;}
			set{
				if(value.Width>0 && value.Height>0 && m_rect.Size!=value){
					m_rect.Size=value;
					OnSizeChanged(EventArgs.Empty);
					OnPropertyChanged(EventArgs.Empty);
				}
			}
		}
		
		/// <summary>
		/// 绘制矩形
		/// </summary>
		public Rectangle Rectangle{
			get{return m_rect;}
			set{
				if(m_rect.Width>0 && m_rect.Height>0 && m_rect!=value){
					m_rect=value;
					OnSizeChanged(EventArgs.Empty);
					OnLocationChanged(EventArgs.Empty);
					OnPropertyChanged(EventArgs.Empty);
				}
			}
		}
		
		/// <summary>
		/// 显示边框
		/// </summary>
		public bool ShowBorder{
			get{return m_showBorder;}
			set{
				if(m_showBorder!=value){
					m_showBorder=value;
					OnPropertyChanged(EventArgs.Empty);
				}
			}
		}
		
		/// <summary>
		/// 父控件
		/// </summary>
		public System.Windows.Forms.Control Parent{
			get{return m_parent;}
			set{
				if(m_parent!=value){
					m_parent=value;
					OnPropertyChanged(EventArgs.Empty);
				}
			}
		}
		
		protected wControl()
		{
		}
		
		public void Refresh(){
			if(m_parent!=null){
				m_parent.Refresh();
			}
		}
		/// <summary>
		/// 反序列化
		/// </summary>
		/// <param name="node"></param>
		protected wControl(System.Xml.XmlNode node){
//			if(node.Name!="control"){
//				throw new Exception("无法解析");
//			}
			Name=node.Attributes["name"].Value;
			Location=new Point(int.Parse(node.Attributes["left"].Value),int.Parse(node.Attributes["top"].Value));
			Size=new Size(int.Parse(node.Attributes["width"].Value),int.Parse(node.Attributes["height"].Value));
			ShowBorder=bool.Parse(node.Attributes["border-visible"].Value);
		}
		
		/// <summary>
		/// 绘图函数
		/// </summary>
		/// <param name="g"></param>
		public virtual void Paint(Graphics g){
			g.FillRectangle(new SolidBrush(Color.FromArgb(150,0,255,60)),Rectangle);
			//绘制边框
			if(m_showBorder){
                g.DrawRectangle(Pens.Black, m_rect);
                //g.DrawRectangle(Pens.Black,new Rectangle( m_rect.X-1,m_rect.Y-1,m_rect.Width+1,m_rect.Height+1));
			}
			//绘制名称
			var WordSize=g.MeasureString("["+Name+"]",SystemFonts.DefaultFont);
			g.FillRectangle(Brushes.LightPink,Rectangle.X,Rectangle.Y-16,WordSize.Width,WordSize.Height);
			g.DrawString("["+Name+"]",SystemFonts.DefaultFont,Brushes.DarkBlue,Rectangle.X,Rectangle.Y-16);
			
		}

		public virtual void DoPrintJson(Newtonsoft.Json.Linq.JToken json, Spoon.Tools.TemplatePrint.Helper.PrintHelper.wPrintEventArgs e)
		{
			if(m_showBorder){
				var rect=m_rect;
				rect.Offset(e.Offset);
				e.Graphics.DrawRectangle(Pens.Black,rect);
			}
		}

		/// <summary>
		/// 打印过程
		/// </summary>
		/// <param name="datalist"></param>
		/// <param name="e"></param>
		public virtual void DoPrint(System.Collections.Generic.Dictionary<string,object> datalist,Helper.PrintHelper.wPrintEventArgs e){
			if(m_showBorder){
				var rect=m_rect;
				rect.Offset(e.Offset);
				e.Graphics.DrawRectangle(Pens.Black,rect);
			}
		}
		/// <summary>
		/// 复制
		/// </summary>
		/// <returns></returns>
		public virtual object Clone(){
			return null;
		}
		
		#region IwSerializable implementation
		public virtual System.Xml.XmlNode ToXml(System.Xml.XmlNode node)
		{
			if(node==null){
				 node=node.OwnerDocument.CreateElement("control");
			}
			Helper.XmlHelper.AddAttribute("name",Name,node);
			Helper.XmlHelper.AddAttribute("border-visible",ShowBorder.ToString(),node);
			Helper.XmlHelper.AddRectangleAttribute(Rectangle,node);
			
			return node;
		}
		#endregion
	}
}
