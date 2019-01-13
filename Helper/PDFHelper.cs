using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace TestUtil.src
{
    class PDFHelper: IDisposable
    {
        #region 内部变量

        private iTextSharp.text.Document m_doc = null;
        private System.IO.MemoryStream m_stream = null;
        private iTextSharp.text.pdf.PdfWriter m_writer = null;
        private iTextSharp.text.pdf.PdfContentByte m_canvas = null;
        private float m_width = 0;
        private float m_height = 0;
        #endregion

        #region 属性
        public float Width {
            get {return m_width; }
        }
        public float Height {
            get { return m_height; }
        }
        public iTextSharp.text.pdf.PdfWriter Writer
        {
            get { return m_writer; }
        }
        public iTextSharp.text.pdf.PdfContentByte Canvas
        {
            get { return m_canvas; }
        }
        #endregion

        public PDFHelper(float width,float height)
        {
            m_width = width;
            m_height = height;

            m_doc = new iTextSharp.text.Document(new iTextSharp.text.Rectangle(0, 0, Width, Height));
            m_stream = new System.IO.MemoryStream();
            m_writer = iTextSharp.text.pdf.PdfWriter.GetInstance(m_doc, m_stream);
            m_doc.OpenDocument();
            m_canvas = Writer.DirectContent;
            Canvas.SetColorStroke(BaseColor.BLACK);
            Canvas.SetColorFill(BaseColor.WHITE);
        }

        #region 文字绘制
        public void DrawString(string text, System.Drawing.Rectangle rect)
        {
            var bf = iTextSharp.text.pdf.BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1250, false);
            var f = new Font(bf, 12);
            var p = new iTextSharp.text.Paragraph(text);
            p.Font = f;
            var ct = new ColumnText(Canvas);
            ct.SetSimpleColumn(Transform2(rect));
            ct.AddElement(p);
            ct.Go();
        }

        public void DrawString(string text, System.Drawing.Rectangle rect, float fontsize, System.Drawing.Color color)
        {
            Canvas.SetRGBColorFill(color.R, color.G, color.B);
            var bf = iTextSharp.text.pdf.BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1250, false);
            var f = new Font(bf, fontsize);

            var p = new iTextSharp.text.Paragraph(text);

            p.Font = f;
            p.Leading = fontsize;
            var ct = new ColumnText(Canvas);
            ct.SetSimpleColumn(Transform2(rect));
            ct.AddElement(p);
            ct.Go();
        }
        #endregion

        #region 图形绘制
        /// <summary>
        /// 使用黑色绘制矩形
        /// </summary>
        /// <param name="rect"></param>
        public void DrawRectangle(System.Drawing.Rectangle rect)
        {
            DrawRectangle(rect, System.Drawing.Color.Black);
        }

        public void DrawRectangle(System.Drawing.Rectangle rect, System.Drawing.Color color)
        {
            Canvas.SetRGBColorStroke(color.R, color.G, color.B);
            var r = Transform2(rect);
            Canvas.Rectangle(r.Left, r.Bottom, r.Width, r.Height);
            Canvas.Stroke();
            //Canvas.RestoreState();
        }

        public void FillRectangle(System.Drawing.Rectangle rect, System.Drawing.Color color)
        {
            Canvas.SetRGBColorFill(color.R, color.G, color.B);
            var r = Transform2(rect);
            Canvas.Rectangle(r.Left, r.Bottom, r.Width, r.Height);
            Canvas.Fill();
            //Canvas.RestoreState();
        }
        #endregion

        #region 条码
        public void Barcode(string text, bool showText, System.Drawing.Rectangle rect)
        {
            var barcode = new Barcode128();
            barcode.CodeType = Barcode128.CODE128;
            if (!showText) barcode.AltText = "";//显示文本

            //barcode.AltText = "qqq";
            barcode.Code = text;

            //计算X值
            if (barcode.X * (11 * text.Length + 35) < rect.Width)
            {
                barcode.X = 1.0F * rect.Width / (11 * text.Length + 35);
            }
            barcode.BarHeight = rect.Height - barcode.BarHeight;
            var rect2 = Transform2(rect);
            //System.Diagnostics.Debug.WriteLine(barcode.X);
            //System.Diagnostics.Debug.WriteLine(barcode.N);
            //barcode.X = 2; //像素单位 单个字母宽度为X的11倍
            //barcode.N = 20;
            //System.Diagnostics.Debug.WriteLine(barcode.BarcodeSize.Width);
            var img = barcode.CreateImageWithBarcode(Canvas, BaseColor.BLACK, BaseColor.BLUE);
            img.SetAbsolutePosition(rect2.Left, rect2.Top);
            Canvas.AddImage(img);
        }

        /// <summary>
        /// 二维码
        /// </summary>
        /// <param name="text"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public void QRCode(string text, int x, int y)
        {
            var qr = new BarcodeQRCode(text, 100, 100, null);
            var img = qr.GetImage();
            var pos = Transform(x, y);
            img.SetAbsolutePosition(pos.X, pos.Y);
            Canvas.AddImage(img);
        }
        #endregion
        /// <summary>
        /// 绘制图像(等比例缩放)
        /// </summary>
        /// <param name="image"></param>
        /// <param name="rect"></param>
        public void DrawImage(System.Drawing.Image image, System.Drawing.Rectangle rect)
        {
            //缩放图像
            var rateW = 1.0F * rect.Width / image.Width;
            var rateH = 1.0F * rect.Height / image.Height;
            var rate = rateW < rateH ? rateW : rateH;

            var ms = new System.IO.MemoryStream();
            var img = new System.Drawing.Bitmap((int)(image.Width * rate), (int)(image.Height * rate));
            var g = System.Drawing.Graphics.FromImage(img);
            g.DrawImage(image, new System.Drawing.Rectangle(0, 0, (int)(image.Width * rate), (int)(image.Height * rate)));
            img.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
            ms.Flush();

            var r = Transform2(rect);
            var img2 = Image.GetInstance(ms.GetBuffer());
            img2.SetAbsolutePosition(r.Left, r.Top);

            Canvas.AddImage(img2);

            ms.Dispose();
            img.Dispose();
        }

        public void NewPage()
        {
            m_doc.NewPage();
        }

        /// <summary>
        /// 保存PDF文件
        /// </summary>
        /// <param name="filename"></param>
        public void Save(string filename)
        {
            m_doc.CloseDocument();
            m_stream.Flush();
            System.IO.File.WriteAllBytes(filename, m_stream.GetBuffer());
        }

        #region 转换函数
        public System.Drawing.Point Transform(int x, int y)
        {
            return new System.Drawing.Point(x, (int)Height - y);
        }

        public System.Drawing.Point Transform(System.Drawing.Point point)
        {
            return Transform(point.X, point.Y);
        }

        public System.Drawing.PointF Transform(float x, float y)
        {
            return new System.Drawing.PointF(x, Height - y);
        }

        public System.Drawing.PointF Transform(System.Drawing.PointF point)
        {
            return Transform(point.X, point.Y);
        }

        public System.Drawing.Rectangle Transform(int x, int y, int width, int height)
        {
            return new System.Drawing.Rectangle(Transform(x, y), new System.Drawing.Size(width, height));
        }

        public System.Drawing.Rectangle Transform(System.Drawing.Rectangle rect)
        {
            return Transform(rect.X, rect.Y, rect.Width, rect.Height);
        }

        public System.Drawing.RectangleF Transform(float x, float y, float width, float height)
        {
            return new System.Drawing.RectangleF(Transform(x, y), new System.Drawing.SizeF(width, height));
        }

        public iTextSharp.text.Rectangle Transform2(int x, int y, int width, int height)
        {
            return new iTextSharp.text.Rectangle(x, Height - y, x + width, Height - y - height);
        }

        public iTextSharp.text.Rectangle Transform2(float x, float y, float width, float height)
        {
            return new iTextSharp.text.Rectangle(x, Height - y, x + width, Height - y - height);
        }

        public iTextSharp.text.Rectangle Transform2(System.Drawing.Rectangle rect)
        {
            return Transform2(rect.X, rect.Y, rect.Width, rect.Height);
        }

        public iTextSharp.text.Rectangle Transform2(System.Drawing.RectangleF rect)
        {
            return Transform2(rect.X, rect.Y, rect.Width, rect.Height);
        }
        #endregion

        #region 资源释放
        private bool disposedValue = false; // 要检测冗余调用

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: 释放托管状态(托管对象)。
                    if (m_doc != null) m_doc.Dispose();
                    if (m_stream != null) m_stream.Dispose();
                }

                // TODO: 释放未托管的资源(未托管的对象)并在以下内容中替代终结器。
                // TODO: 将大型字段设置为 null。

                disposedValue = true;
            }
        }

        // TODO: 仅当以上 Dispose(bool disposing) 拥有用于释放未托管资源的代码时才替代终结器。
        // ~PDFHelper2() {
        //   // 请勿更改此代码。将清理代码放入以上 Dispose(bool disposing) 中。
        //   Dispose(false);
        // }

        // 添加此代码以正确实现可处置模式。
        void IDisposable.Dispose()
        {
            // 请勿更改此代码。将清理代码放入以上 Dispose(bool disposing) 中。
            Dispose(true);
            // TODO: 如果在以上内容中替代了终结器，则取消注释以下行。
            // GC.SuppressFinalize(this);
        }
        #endregion
    }
}