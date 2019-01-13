/*
 * Copyright (C) 2016-2018
 * 由SharpDevelop创建。
 * 作者: Byron Gong
 * 日期: 05/14/2018 时间: 10:50
 * 邮箱: 1032066879@QQ.com
 * 描述: 表格控件
 *
 */ 
using System;
using System.Drawing;
using Newtonsoft.Json.Linq;
namespace Spoon.Tools.TemplatePrint.Controls
{
	public class wColumn{
		
		public string Title{
			get;set;
		}
		
		public string Name{
			get;set;
		}
		
		public int ColumnWidth{
			get;set;
		}
		
		public Font Font{
			get;set;
		}
		
		private void init(){
			Title="Title";
			Name="col";
			Font=SystemFonts.DefaultFont;
			ColumnWidth=40;
		}
		
		public wColumn(){
			init();
		}
		
		public wColumn(string name,string title,int width){
			init();
			Name=name;
			Title=title;
			ColumnWidth=width;
		}
		
		public wColumn(string name,string title,int width,Font font){
			Name=name;
			Title=title;
			ColumnWidth=width;
			Font=font;
		}
	}

    /// <summary>
    /// Description of wTable.
    /// </summary>
    public class wTable : wControl
    {
        private int _rowCount;

        /// <summary>
        /// 列标题高度
        /// </summary>
        public int TitleHeight { get; set; }

        /// <summary>
        /// 行高
        /// </summary>
        public int RowHeight { get; set; }

        /// <summary>
        /// 行数
        /// </summary>
        public int RowCount
        {
            get => _rowCount;
            set
            {
                _rowCount = value;
            }
        }

        /// <summary>
        /// 行字体
        /// </summary>
        public Font RowFont { get; set; }

        /// <summary>
        /// 显示标题
        /// </summary>
        public bool ShowTableTitle { get; set; } = false;

        /// <summary>
        /// 显示边框
        /// </summary>
        public bool ShowTableBorder { get; set; } = true;

        /// <summary>
        /// 表格列
        /// </summary>
        public System.Collections.Generic.List<wColumn> Columns { get; set; }

        public void ReCalcSize()
        {
            this.Height = TitleHeight + RowHeight * RowCount + 1;
            int w = 0;
            foreach(wColumn col in Columns)
            {
                w += col.ColumnWidth;
            }
            Width = w<30 ? 30 : w;
            Refresh();
        }

        public wTable()
        {
            RowFont = SystemFonts.DefaultFont;
            TitleHeight = 30;
            RowHeight = 20;
            RowCount = 1;
            Columns = new System.Collections.Generic.List<wColumn>();
            Columns.Add(new wColumn("Column", "Column", 50));
            base.ShowBorder = false;
            ReCalcSize();
        }

        public wTable(System.Xml.XmlNode node) : base(node)
        {
            TitleHeight = int.Parse(node.Attributes["titleheight"].Value);
            RowHeight = int.Parse(node.Attributes["rowheight"].Value);
            RowCount = int.Parse(node.Attributes["rowcount"].Value);
            if(node.Attributes["showtabletitle"] != null)
            {
                ShowTableTitle = bool.Parse(node.Attributes["showtabletitle"].Value);
            }
            if (node.Attributes["showtableborder"] != null)
            {
                ShowTableBorder = bool.Parse(node.Attributes["showtableborder"].Value);
            }
            var cols = node.SelectSingleNode("columns");
            Columns = new System.Collections.Generic.List<wColumn>();
            var fc = new FontConverter();
            RowFont = fc.ConvertFromString(node.Attributes["rowfont"].Value) as Font;
            foreach (System.Xml.XmlNode col in cols.ChildNodes)
            {
                string name = col.Attributes["name"].Value;
                string title = col.Attributes["title"].Value;
                int columnwidth = int.Parse(col.Attributes["width"].Value);
                Font f = fc.ConvertFromString(col.Attributes["font"].Value) as Font;
                //Columns.Add(name,new wColumn(name,title,columnwidth,f));
                Columns.Add(new wColumn(name, title, columnwidth, f));
            }
            ReCalcSize();
        }

        public override void Paint(System.Drawing.Graphics g)
        {
            base.Paint(g);

            if (Columns == null)
            {
                return;
            }

            int y = base.Top;
            int x = base.Left;
            if (ShowTableTitle)
            {
                //绘制列标题
                foreach (wColumn col in Columns)
                {
                    var cell_rect = new Rectangle(x, y, col.ColumnWidth, TitleHeight);
                    g.DrawRectangle(Pens.Black, cell_rect);
                    //绘制内容
                    g.DrawString(col.Title, col.Font, Brushes.Black, cell_rect, new StringFormat(StringFormatFlags.NoWrap));
                    x += col.ColumnWidth;
                }

                y += TitleHeight;
            }
            //绘制行
            for (int i = 0; i < RowCount; i++)
            {
                x = base.Left;
                foreach (wColumn col in Columns)
                {
                    var cell_rect = new Rectangle(x, y, col.ColumnWidth, RowHeight);
                    if(ShowTableBorder) g.DrawRectangle(Pens.Black, cell_rect);
                    //绘制内容
                    g.DrawString("Test01", RowFont, Brushes.Black, cell_rect, new StringFormat(StringFormatFlags.NoWrap));

                    x += col.ColumnWidth;
                }
                y += RowHeight;
            }

        }

        public override void DoPrintJson(JToken json, Spoon.Tools.TemplatePrint.Helper.PrintHelper.wPrintEventArgs e)
        {
            base.DoPrintJson(json, e);
            var g = e.Graphics;

            if (Columns == null)
            {
                return;
            }

            int y = base.Top;
            int x = base.Left;
            //绘制列标题
            if (ShowTableTitle)
            {
                foreach (wColumn col in Columns)
                {
                    var cell_rect = new Rectangle(x, y, col.ColumnWidth, TitleHeight);
                    cell_rect.Offset(e.Offset);
                    //g.DrawRectangle(Pens.Black, cell_rect);
                    //绘制内容
                    //g.DrawString(col.Title, col.Font, Brushes.Black, cell_rect, new StringFormat(StringFormatFlags.NoWrap));
                    g.DrawString(col.Title, col.Font, Brushes.Black, cell_rect);
                    x += col.ColumnWidth;
                }
                y += TitleHeight;
            }

            var jo = json as Newtonsoft.Json.Linq.JObject;
            JArray rows = null;

            if(jo!=null && jo.ContainsKey(Name) && (jo[Name] as JObject).ContainsKey("rows"))
            {
                rows = jo[Name]["rows"] as Newtonsoft.Json.Linq.JArray;
            }
            //var ja = jo[Name]["rows"] as Newtonsoft.Json.Linq.JArray;

            //for (int i = 0; i < ja.Count; i++)
            for (int i = 0; i < RowCount; i++)
            {
                x = base.Left;
                foreach (wColumn col in Columns)
                {
                    var cell_rect = new Rectangle(x, y, col.ColumnWidth, RowHeight);
                    cell_rect.Offset(e.Offset);
                    if(ShowTableBorder) g.DrawRectangle(Pens.Black, cell_rect);
                    if (rows!=null && i<rows.Count && (rows[i] as JObject).ContainsKey(col.Name))
                    {
                        //绘制内容
                        //g.DrawString(rows[i][col.Name].ToString(),RowFont, Brushes.Black, cell_rect, new StringFormat(StringFormatFlags.NoWrap));
                        g.DrawString(rows[i][col.Name].ToString(),RowFont, Brushes.Black, cell_rect);
                    }

                    x += col.ColumnWidth;
                }
                y += RowHeight;
            }
        }

        public override void DoPrint(System.Collections.Generic.Dictionary<string, object> datalist, Spoon.Tools.TemplatePrint.Helper.PrintHelper.wPrintEventArgs e)
        {
            base.DoPrint(datalist, e);
            var g = e.Graphics;

            if (Columns == null)
            {
                return;
            }

            int y = base.Top;
            int x = base.Left;
            //绘制列标题

            //foreach (System.Collections.Generic.KeyValuePair<string,wColumn> item in Columns) {
            //	var col=item.Value;
            if (ShowTableTitle)
            {
                foreach (wColumn col in Columns)
                {
                    var cell_rect = new Rectangle(x, y, col.ColumnWidth, TitleHeight);
                    cell_rect.Offset(e.Offset);
                    g.DrawRectangle(Pens.Black, cell_rect);
                    //绘制内容
                    //g.DrawString(col.Title, col.Font, Brushes.Black, cell_rect, new StringFormat(StringFormatFlags.NoWrap));
                    g.DrawString(col.Title, col.Font, Brushes.Black, cell_rect);
                    x += col.ColumnWidth;
                }

                if (datalist == null || !datalist.ContainsKey(Name))
                {
                    return;
                }

                y += TitleHeight;
            }

            var ja = Newtonsoft.Json.Linq.JArray.Parse(datalist[Name].ToString());


            for (int i = 0; i < ja.Count; i++)
            {
                x = base.Left;
                //foreach (System.Collections.Generic.KeyValuePair<string,wColumn> item in Columns) {
                foreach (wColumn col in Columns)
                {
                    //var col=item.Value;
                    //					var row=m_rows[i] as wRow;

                    var cell_rect = new Rectangle(x, y, col.ColumnWidth, RowHeight);
                    cell_rect.Offset(e.Offset);
                    if (ShowTableBorder)
                    {
                        g.DrawRectangle(Pens.Black, cell_rect);
                    }
                    //绘制内容
                    g.DrawString(ja[i][col.Name].ToString(), SystemFonts.DefaultFont, Brushes.Black, cell_rect, new StringFormat(StringFormatFlags.NoWrap));

                    x += col.ColumnWidth;
                }
                y += RowHeight;
            }
        }

        public override System.Xml.XmlNode ToXml(System.Xml.XmlNode node)
        {
            var fc = new FontConverter();
            var ctl = node.OwnerDocument.CreateElement("table");
            Helper.XmlHelper.AddAttribute("rowheight", RowHeight.ToString(), ctl);
            Helper.XmlHelper.AddAttribute("titleheight", TitleHeight.ToString(), ctl);
            Helper.XmlHelper.AddAttribute("rowfont", fc.ConvertToString(RowFont), ctl);
            Helper.XmlHelper.AddAttribute("rowcount", RowCount.ToString(), ctl);
            Helper.XmlHelper.AddAttribute("showtabletitle",ShowTableTitle.ToString(), ctl);
            Helper.XmlHelper.AddAttribute("showtableborder", ShowTableBorder.ToString(), ctl);

            var cols = node.OwnerDocument.CreateElement("columns");
            ctl.AppendChild(cols);

            //foreach (System.Collections.Generic.KeyValuePair<string,wColumn> item in Columns) {
            foreach (wColumn col in Columns)
            {
                //var col= Columns[i];
                var c = node.OwnerDocument.CreateElement("column");
                Helper.XmlHelper.AddAttribute("name", col.Name, c);
                Helper.XmlHelper.AddAttribute("title", col.Title, c);
                Helper.XmlHelper.AddAttribute("width", col.ColumnWidth.ToString(), c);
                Helper.XmlHelper.AddAttribute("font", fc.ConvertToString(col.Font), c);
                cols.AppendChild(c);
            }
            return base.ToXml(ctl);
        }
    }
}
