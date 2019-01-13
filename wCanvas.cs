/*
 * Copyright (C) 2016-2018
 * 由SharpDevelop创建。
 * 作者: Byron Gong
 * 日期: 03/06/2018 时间: 9:46
 * 邮箱: 1032066879@QQ.com
 * 描述: 画布类
 *
 */
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Spoon.Tools.TemplatePrint
{
	
	enum SizeType{
		SizeNone,
		SizeM,
		SizeL,
		SizeT,
		SizeR,
		SizeB,
		SizeLT,
		SizeRT,
		SizeRB,
		SizeLB
	}
	/// <summary>
	/// 画布类
	/// </summary>
	public class wCanvas:System.Windows.Forms.UserControl,IwSerializable,IwPrint
	{
		public event EventHandler SelectControlChangedEvent;

		/// <summary>
		/// 文件版本
		/// </summary>
		public const string version="1.0.1.0";
		
		/// <summary>
		/// 控件集合
		/// </summary>
		private wControlCollection m_collection=null;
		
		/// <summary>
		/// 当前选中控件
		/// </summary>
		private Controls.wControl m_selectControl=null;

        /// <summary>
        /// 移动前的控件
        /// </summary>
        private Controls.wControl m_originControl = null;

		/// <summary>
		/// 复制控件
		/// </summary>
		private Controls.wControl m_copyControl=null;

        //		/// <summary>
        //		/// 当前选中控件集
        //		/// </summary>
        //private wControlCollection m_selectControls = null;

        /// <summary>
        /// 选中控件初始位置
        /// </summary>
        private Rectangle m_selectControlRect = Rectangle.Empty;

        /// <summary>
        /// 鼠标点击位置
        /// </summary>
        private Point m_mousedownPos=Point.Empty;
		
		/// <summary>
		/// 尺寸位置编辑状态
		/// </summary>
		private SizeType m_selectControlPressedType=SizeType.SizeNone;
		
		/// <summary>
		/// 背景缩放比例
		/// </summary>
		private float m_backgroundScale=0F;
		
		/// <summary>
		/// 显示背景图片
		/// </summary>
		private bool m_showBackground=true;
		
		/// <summary>
		/// 背景图片显示位置
		/// </summary>
		private Rectangle m_backgroundRect=Rectangle.Empty;
		
		/// <summary>
		/// 背景文件路径
		/// </summary>
		private string m_backgroungPath=string.Empty;
		
		/// <summary>
		/// 图片
		/// </summary>
		private Image m_backgroundImage=null;
		
		/// <summary>
		/// 绘制人
		/// </summary>
		private string m_author=Environment.GetEnvironmentVariable("username");
		
		/// <summary>
		/// 创建时间
		/// </summary>
		private DateTime m_createtime=DateTime.Now;

        private SizeF m_sizef = new SizeF();
        /// <summary>
        /// 画布尺寸
        /// </summary>
        public SizeF SizeF {
            get {
                return m_sizef;
            }
            set
            {
                m_sizef = value;
                Size =new Size((int)value.Width,(int)value.Height);
            }
        }

		/// <summary>
		/// 内部控件
		/// </summary>
		public new wControlCollection Controls{
			get{return m_collection;}
		}
		
		/// <summary>
		/// 构造函数
		/// </summary>
		public wCanvas()
		{
			base.DoubleBuffered=true;
			m_collection=new wControlCollection(this);
		}
		
		public wCanvas(System.Xml.XmlDocument doc){
			base.DoubleBuffered=true;
			m_collection=new wControlCollection(this);
			Init(doc);
		}
		
		public void Init(System.Xml.XmlDocument doc){
			Controls.Clear();
			var layout=doc.SelectSingleNode("/layout");
			if(layout==null){
				throw new Exception("无效参数");
			}
			if(layout.Attributes["version"].Value!=version){
				throw new Exception("文件版本不一致");
			}
			var author=layout.SelectSingleNode("property/author");
			this.Author=author.Attributes["name"].Value;
			
			var canvas=layout.SelectSingleNode("property/canvas");
			this.SizeF=new SizeF(float.Parse(canvas.Attributes["width"].Value), float.Parse(canvas.Attributes["height"].Value));
			
			var background=layout.SelectSingleNode("property/background");
			if(background!=null){
				this.BackgroundRect=new Rectangle(
					int.Parse(background.Attributes["left"].Value),
					int.Parse(background.Attributes["top"].Value),
					int.Parse(background.Attributes["width"].Value),
					int.Parse(background.Attributes["height"].Value)
				);
				this.BackgroundPath=background.Attributes["src"].Value;
                this.ShowBackground = bool.Parse(background.Attributes["visible"].Value);
                
			}else{
				this.BackgroundPath=string.Empty;
			}
			
			var datetime=layout.SelectSingleNode("property/datetime");
			this.CreateTime=DateTime.Parse(datetime.Attributes["createtime"].Value);
			
			var items=layout.SelectSingleNode("items");
			foreach (System.Xml.XmlNode item in items.ChildNodes) {
				Controls.wControl ctl=null;
				switch (item.Name) {
					case "label":
						ctl=new Controls.wLabel(item);
						break;
					case "image":
						ctl=new Controls.wImage(item);
						break;
					case "barcode":
						ctl=new Controls.wBarcode(item);
						break;
					case "qrcoder":
						ctl=new Controls.wQRCoder(item);
						break;
					case "table":
						ctl=new Controls.wTable(item);
						break;
				}
				if(ctl!=null){
					this.Controls.Add(ctl);
				}
			}
			SelectControl=null;
			Refresh();
		}
		
		#region 属性
		/// <summary>
		/// 绘制人
		/// </summary>
		public string Author{
			get{return m_author;}
			set{
				if(value==string.Empty){
					m_author=Environment.GetEnvironmentVariable("username");
				}else{
					m_author=value;
				}
			}
		}
		
		/// <summary>
		/// 创建时间
		/// </summary>
		public DateTime CreateTime{
			get{return m_createtime;}
			set{m_createtime=value;}
		}
		
		/// <summary>
		/// 背景缩放
		/// </summary>
		public float BackgroundScale{
			get{return m_backgroundScale;}
			set{m_backgroundScale=value;}
		}
		
		/// <summary>
		/// 显示背景图片
		/// </summary>
		public bool ShowBackground{
			get{return m_showBackground;}
			set{
				m_showBackground=value;
				Refresh();
			}
		}
		
		/// <summary>
		/// 背景图片文件
		/// </summary>
		public string BackgroundPath{
			get{return m_backgroungPath;}
			set{
				if(System.IO.File.Exists(value)){
					m_backgroungPath=value;
					var img=Image.FromFile(m_backgroungPath);
					BackgroundImage=new Bitmap(img);
					img.Dispose();
				}else{
					m_backgroungPath=string.Empty;
					BackgroundImage=null;
				}
			}
		}
		
		/// <summary>
		/// 背景显示区域
		/// </summary>
		public Rectangle BackgroundRect{
			get{return m_backgroundRect;}
			set{m_backgroundRect=value;}
		}
		
		/// <summary>
		/// 背景图片
		/// </summary>
		public new Image BackgroundImage{
			get{return m_backgroundImage;}
			set{
				if(m_backgroundImage!=null){
					m_backgroundImage.Dispose();
					m_backgroundImage=null;
				}
				m_backgroundImage=value;
			}
		}
		
		/// <summary>
		/// 当前选中控件
		/// </summary>
		public Controls.wControl SelectControl{
			get{return m_selectControl;}
			set{
				if(m_selectControl!=value){
					m_selectControl=value;
					Controls.SetFront(value);
					OnSelectControlChanged(EventArgs.Empty);
				}
			}
		}
		#endregion
		
		#region 属性事件
		protected virtual void OnSelectControlChanged(EventArgs e)
		{
			var handler = SelectControlChangedEvent;
			if (handler != null)
				handler(this, e);
		}
		
		#endregion
		
		/// <summary>
		/// 通过点坐标获取对象
		/// </summary>
		/// <param name="point"></param>
		/// <returns>若找不到相应元素 返回null</returns>
		public new Controls.wControl GetChildAtPoint(System.Drawing.Point point){
			for (int i = m_collection.Count-1; i >-1; i--) {
				if(m_collection[i].Rectangle.Contains(point)){
					return m_collection[i];
				}
			}
			return null;
		}
		
		/// <summary>
		/// 调整偏移
		/// </summary>
		/// <param name="x"></param>
		/// <param name="y"></param>
		public void Offset(int x,int y){
			if(BackgroundPath!=string.Empty){
				m_backgroundRect.Offset(x,y);
			}
			foreach (var ctl in m_collection) {
				ctl.Left+=x;
				ctl.Top+=y;
			}
			Refresh();
		}
		
		/// <summary>
		/// 清除选中
		/// </summary>
		protected void ClearSelect(){
			SelectControl=null;
			m_selectControlPressedType=SizeType.SizeNone;
			m_selectControlRect=Rectangle.Empty;
		}

        /// <summary>
        /// 字符类按键判定
        /// </summary>
        /// <param name="keyData"></param>
        /// <returns></returns>
        protected override bool IsInputKey(Keys keyData)
		{
			if(keyData==Keys.Up || keyData==Keys.Right || keyData==Keys.Down || keyData==Keys.Left){
				return true;
			}
			return base.IsInputKey(keyData);
		}
		
		protected override void OnKeyDown(KeyEventArgs e)
		{
			base.OnKeyDown(e);
			if(m_selectControl!=null){
				switch (e.KeyCode) {
					case Keys.Escape:
						ClearSelect();
						Refresh();
						break;
					case Keys.Delete:
						Controls.Remove(m_selectControl);
						ClearSelect();
						Refresh();
						break;
					case Keys.Up:
						m_selectControl.Top-=1;
						break;
					case Keys.Down:
						m_selectControl.Top+=1;
						break;
					case Keys.Left:
						m_selectControl.Left-=1;
						break;
					case Keys.Right:
						m_selectControl.Left+=1;
						break;
				}
				Refresh();
			}
			
//			System.Diagnostics.Debug.WriteLine(e.KeyCode.ToString());
		}
		
		protected override void OnKeyUp(KeyEventArgs e)
		{
			base.OnKeyUp(e);
			switch (e.KeyCode) {
				case Keys.ControlKey:
					if(MouseButtons==MouseButtons.Left){
						var orgControl=GetChildAtPoint(PointToClient(m_mousedownPos));
						if(orgControl!=null){
							orgControl.Rectangle=m_selectControl.Rectangle;
                            //SelectControl = orgControl;
                            m_selectControl = orgControl;
                        }
						if(m_copyControl!=null){
							Controls.Remove(m_copyControl);
						}
					}
					m_copyControl=null;
					break;
			}
		}
		
		protected override void OnMouseDown(System.Windows.Forms.MouseEventArgs e)
		{
			base.OnMouseDown(e);
			m_mousedownPos=MousePosition;// e.Location;
			if(SelectControl!=null){
				m_selectControlRect=m_selectControl.Rectangle;
			}
			
			if(SelectControl!=null){
				var pos = this.PointToClient(MousePosition);
				if (GetCornerRect(SizeType.SizeLT).Contains(pos)) {
					m_selectControlPressedType = SizeType.SizeLT;
				} else if (GetCornerRect(SizeType.SizeL).Contains(pos)) {
					m_selectControlPressedType = SizeType.SizeL;
				} else if (GetCornerRect(SizeType.SizeLB).Contains(pos)) {
					m_selectControlPressedType = SizeType.SizeLB;
				} else if (GetCornerRect(SizeType.SizeT).Contains(pos)) {
					m_selectControlPressedType = SizeType.SizeT;
				} else if (GetCornerRect(SizeType.SizeB).Contains(pos)) {
					m_selectControlPressedType = SizeType.SizeB;
				} else if (GetCornerRect(SizeType.SizeRT).Contains(pos)) {
					m_selectControlPressedType = SizeType.SizeRT;
				} else if (GetCornerRect(SizeType.SizeR).Contains(pos)) {
					m_selectControlPressedType = SizeType.SizeR;
				} else if (GetCornerRect(SizeType.SizeRB).Contains(pos)) {
					m_selectControlPressedType = SizeType.SizeRB;
				} else if (GetCornerRect(SizeType.SizeM).Contains(pos)) {
					m_selectControlPressedType = SizeType.SizeM;
				} else {
					m_selectControlPressedType = SizeType.SizeNone;
				}
				Refresh();
			}else{
				m_selectControlPressedType=SizeType.SizeNone;
			}
			
			if(m_selectControlPressedType==SizeType.SizeNone){
				SelectControl=GetChildAtPoint(PointToClient(m_mousedownPos));
				Controls.SetFront(SelectControl);
				Refresh();
			}
		}

        protected override void OnMouseUp(System.Windows.Forms.MouseEventArgs e)
        {
            base.OnMouseUp(e);
            m_mousedownPos = Point.Empty;
            m_selectControlPressedType = SizeType.SizeNone;
            if (!ModifierKeys.HasFlag(Keys.Control) && m_originControl!=null) {
                SelectControl = m_originControl;
            }
            m_copyControl = null;
            m_originControl = null;
        }
		
		protected override void OnMouseMove(System.Windows.Forms.MouseEventArgs e)
		{
			base.OnMouseMove(e);
			//更改鼠标箭头
			if (m_selectControl != null && e.Button.Equals(MouseButtons.None)) {
				if(GetCornerRect(SizeType.SizeLT).Contains(e.Location) || GetCornerRect(SizeType.SizeRB).Contains(e.Location)){
					this.Cursor=Cursors.SizeNWSE;
				}else if(GetCornerRect(SizeType.SizeL).Contains(e.Location) || GetCornerRect(SizeType.SizeR).Contains(e.Location)){
					this.Cursor=Cursors.SizeWE;
				}else if(GetCornerRect(SizeType.SizeLB).Contains(e.Location) || GetCornerRect(SizeType.SizeRT).Contains(e.Location)){
					this.Cursor=Cursors.SizeNESW;
				}else if(GetCornerRect(SizeType.SizeT).Contains(e.Location) || GetCornerRect(SizeType.SizeB).Contains(e.Location)){
					this.Cursor=Cursors.SizeNS;
				}else{
					this.Cursor=Cursors.Default;
				}
			}
			
			//调整尺寸
			if(e.Button.HasFlag(System.Windows.Forms.MouseButtons.Left) && m_selectControl!=null){
				switch (m_selectControlPressedType) {
					case SizeType.SizeLT:
						m_selectControl.Left=m_selectControlRect.Left-m_mousedownPos.X+MousePosition.X;
						m_selectControl.Top=m_selectControlRect.Top-m_mousedownPos.Y+MousePosition.Y;
						m_selectControl.Width=m_selectControlRect.Width+m_mousedownPos.X-MousePosition.X;
						m_selectControl.Height=m_selectControlRect.Height+m_mousedownPos.Y-MousePosition.Y;
						break;
					case SizeType.SizeL:
						m_selectControl.Left=m_selectControlRect.Left-m_mousedownPos.X+MousePosition.X;
						m_selectControl.Width=m_selectControlRect.Width+m_mousedownPos.X-MousePosition.X;
						break;
					case SizeType.SizeLB:
						m_selectControl.Left=m_selectControlRect.Left-m_mousedownPos.X+MousePosition.X;
						m_selectControl.Width=m_selectControlRect.Width+m_mousedownPos.X-MousePosition.X;
						m_selectControl.Height=m_selectControlRect.Height-m_mousedownPos.Y+MousePosition.Y;
						break;
					case SizeType.SizeT:
						m_selectControl.Top=m_selectControlRect.Top-m_mousedownPos.Y+MousePosition.Y;
						m_selectControl.Height=m_selectControlRect.Height+m_mousedownPos.Y-MousePosition.Y;
						break;
					case SizeType.SizeB:
						m_selectControl.Height=m_selectControlRect.Height-m_mousedownPos.Y+MousePosition.Y;
						break;
					case SizeType.SizeRT:
						m_selectControl.Top=m_selectControlRect.Top-m_mousedownPos.Y+MousePosition.Y;
						m_selectControl.Width=m_selectControlRect.Width-m_mousedownPos.X+MousePosition.X;
						m_selectControl.Height=m_selectControlRect.Height+m_mousedownPos.Y-MousePosition.Y;
						break;
					case SizeType.SizeR:
						m_selectControl.Width=m_selectControlRect.Width-m_mousedownPos.X+MousePosition.X;
						break;
					case SizeType.SizeRB:
						m_selectControl.Width=m_selectControlRect.Width-m_mousedownPos.X+MousePosition.X;
						m_selectControl.Height=m_selectControlRect.Height-m_mousedownPos.Y+MousePosition.Y;
						break;
					case SizeType.SizeM:
						//支持复制
						if(ModifierKeys.HasFlag(Keys.Control)){
							if(/*m_selectControl is Controls.wLabel &&*/ m_copyControl==null){
                                m_originControl = m_selectControl;
								m_copyControl=m_selectControl.Clone() as Controls.wControl;
//								
								m_copyControl.Rectangle=m_selectControl.Rectangle;
								m_selectControl.Rectangle=m_selectControlRect;
//								
								Controls.Add(m_copyControl);
                                SelectControl = m_copyControl;
                                //m_selectControl=m_copyControl;
                            }
						}
						m_selectControl.Left=m_selectControlRect.Left-m_mousedownPos.X+MousePosition.X;
						m_selectControl.Top=m_selectControlRect.Top-m_mousedownPos.Y+MousePosition.Y;
						
						break;
				}
				Refresh();
			}
		}
		
		/// <summary>
		/// 绘图
		/// </summary>
		/// <param name="e"></param>
		protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
		{
			var g=e.Graphics;
//			base.OnPaint(e);
//			g.Clear(BackColor);
			
			//绘制背景
			if(BackgroundImage!=null && ShowBackground){
				g.DrawImage(BackgroundImage,m_backgroundRect.Equals(Rectangle.Empty)?new Rectangle(new Point(0,0),BackgroundImage.Size):m_backgroundRect);
			}
			
			//绘制元素
			if(m_collection!=null){
				foreach (var ctl in m_collection) {
					ctl.Paint(g);
				}
			}
			
			//绘制选中框边线
			if(m_selectControl!=null){
				var select_rect=new Rectangle(m_selectControl.Rectangle.Left-1,m_selectControl.Rectangle.Top-1,m_selectControl.Rectangle.Width+1,m_selectControl.Rectangle.Height+1);
				var select_pen=new Pen(Color.Gray);
				select_pen.DashStyle=System.Drawing.Drawing2D.DashStyle.Dot;
				g.DrawRectangle(select_pen,select_rect);
				
				//绘制定位小方框
				g.FillRectangle(Brushes.White,GetCornerRect(SizeType.SizeLT));
				g.FillRectangle(Brushes.White,GetCornerRect(SizeType.SizeL));
				g.FillRectangle(Brushes.White,GetCornerRect(SizeType.SizeLB));
				g.FillRectangle(Brushes.White,GetCornerRect(SizeType.SizeT));
				g.FillRectangle(Brushes.White,GetCornerRect(SizeType.SizeB));
				g.FillRectangle(Brushes.White,GetCornerRect(SizeType.SizeRT));
				g.FillRectangle(Brushes.White,GetCornerRect(SizeType.SizeR));
				g.FillRectangle(Brushes.White,GetCornerRect(SizeType.SizeRB));
				
				g.DrawRectangle(Pens.Black,GetCornerRect(SizeType.SizeLT));
				g.DrawRectangle(Pens.Black,GetCornerRect(SizeType.SizeL));
				g.DrawRectangle(Pens.Black,GetCornerRect(SizeType.SizeLB));
				g.DrawRectangle(Pens.Black,GetCornerRect(SizeType.SizeT));
				g.DrawRectangle(Pens.Black,GetCornerRect(SizeType.SizeB));
				g.DrawRectangle(Pens.Black,GetCornerRect(SizeType.SizeRT));
				g.DrawRectangle(Pens.Black,GetCornerRect(SizeType.SizeR));
				g.DrawRectangle(Pens.Black,GetCornerRect(SizeType.SizeRB));
				
			}
		}

		public void DoPrintJson(Newtonsoft.Json.Linq.JToken json, Spoon.Tools.TemplatePrint.Helper.PrintHelper.wPrintEventArgs e)
		{
			var g=e.Graphics;
			g.Clear(Color.White);
			//绘制背景
			if(BackgroundImage!=null && ShowBackground){
				var rect=m_backgroundRect.Equals(Rectangle.Empty)?new Rectangle(new Point(0,0),BackgroundImage.Size):m_backgroundRect;
				rect.Offset(e.Offset);
				g.DrawImage(BackgroundImage,rect);
			}
			//绘制元素
			if(m_collection!=null){
				foreach (var ctl in m_collection) {
					ctl.DoPrintJson(json,e);
				}
			}
		}
		
		public void DoPrint(System.Collections.Generic.Dictionary<string,object> datalist,Helper.PrintHelper.wPrintEventArgs e){
			var g=e.Graphics;
			g.Clear(Color.White);
			//绘制背景
			if(BackgroundImage!=null && ShowBackground){
				var rect=m_backgroundRect.Equals(Rectangle.Empty)?new Rectangle(new Point(0,0),BackgroundImage.Size):m_backgroundRect;
				rect.Offset(e.Offset);
				g.DrawImage(BackgroundImage,rect);
			}
			//绘制元素
			if(m_collection!=null){
				foreach (var ctl in m_collection) {
					ctl.DoPrint(datalist,e);
				}
			}
		}
		/// <summary>
		/// 获取指定区域的矩形坐标
		/// </summary>
		/// <param name="sz"></param>
		/// <returns></returns>
		private Rectangle GetCornerRect(SizeType sz){
			if(m_selectControl==null){
				return Rectangle.Empty;
			}
			switch (sz) {
				case SizeType.SizeLT:
					return new Rectangle(m_selectControl.Left-6,m_selectControl.Top-6,5,5);
				case SizeType.SizeL:
					return new Rectangle(m_selectControl.Left-6,m_selectControl.Top-4+m_selectControl.Height/2,5,5);
				case SizeType.SizeLB:
					return new Rectangle(m_selectControl.Left-6,m_selectControl.Bottom,5,5);
				case SizeType.SizeT:
					return new Rectangle(m_selectControl.Left-4+m_selectControl.Width/2,m_selectControl.Top-6,5,5);
				case SizeType.SizeB:
					return new Rectangle(m_selectControl.Left-4+m_selectControl.Width/2,m_selectControl.Bottom,5,5);
				case SizeType.SizeRT:
					return new Rectangle(m_selectControl.Right,m_selectControl.Top-6,5,5);
				case SizeType.SizeR:
					return new Rectangle(m_selectControl.Right,m_selectControl.Top-4+m_selectControl.Height/2,5,5);
				case SizeType.SizeRB:
					return new Rectangle(m_selectControl.Right,m_selectControl.Bottom,5,5);
				case SizeType.SizeM:
					return new Rectangle(m_selectControl.Left+1,m_selectControl.Top+1,m_selectControl.Width-1,m_selectControl.Height-1);
				default:
					return Rectangle.Empty;
			}
		}
		
		#region IwSerializable implementation
		public System.Xml.XmlNode ToXml(System.Xml.XmlDocument doc){
			var layout=doc.CreateElement("layout");
			Helper.XmlHelper.AddAttribute("version",version,layout);
			
			var property=doc.CreateElement("property");
			
			//绘制人
			var author=doc.CreateElement("author");
			Helper.XmlHelper.AddAttribute("name",Author,author);
			property.AppendChild(author);
			
			//尺寸
			var canvas=doc.CreateElement("canvas");
			Helper.XmlHelper.AddSizeAttribute(SizeF,canvas);
			property.AppendChild(canvas);
			
			//背景[可选]
			if(m_backgroungPath!=string.Empty){
				var background=doc.CreateElement("background");
				Helper.XmlHelper.AddRectangleAttribute(BackgroundRect,background);
				Helper.XmlHelper.AddAttribute("src",BackgroundPath,background);
                Helper.XmlHelper.AddAttribute("visible", ShowBackground.ToString(), background);
				property.AppendChild(background);
			}
			
			//时间
			var datetime=doc.CreateElement("datetime");
			Helper.XmlHelper.AddAttribute("createtime",CreateTime.ToString(),datetime);
			Helper.XmlHelper.AddAttribute("updatetime",DateTime.Now.ToString(),datetime);
			property.AppendChild(datetime);
			
			layout.AppendChild(property);
			
			//序列化控件
			var items=doc.CreateElement("items");
			if(m_collection!=null){
				foreach (var ctl in m_collection) {
					items.AppendChild(ctl.ToXml(items));
				}
			}
			layout.AppendChild(items);
			
			return layout;
		}
		
		public System.Xml.XmlNode ToXml(System.Xml.XmlNode node)
		{
			var doc=node.OwnerDocument;
			return ToXml(doc);
		}

		#endregion
	}
}
