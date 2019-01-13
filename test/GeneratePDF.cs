using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using iTextSharp.awt;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace Spoon.Tools.TemplatePrint.test
{
    class GeneratePDF
    {
        public GeneratePDF()
        {
            var doc =new Document(PageSize.A4);
            //doc.Open();
            var stream = new System.IO.FileStream(Environment.CurrentDirectory+"\\demo.pdf",System.IO.FileMode.Create);
            var write = PdfWriter.GetInstance(doc,stream);
            doc.OpenDocument();
            PdfContentByte dc = write.DirectContent;

            dc.SetColorStroke(CMYKColor.RED);
            dc.SetColorFill(CMYKColor.YELLOW);
            var cb = dc;

            cb.MoveTo(70, 200);

            cb.LineTo(170, 200);

            cb.LineTo(170, 300);

            cb.LineTo(70, 300);

            //Path closed and stroked

            cb.ClosePathStroke();


            cb.MoveTo(190, 200);

            cb.LineTo(290, 200);

            cb.LineTo(290, 300);

            cb.LineTo(190, 300);

            //Filled, but not stroked or closed

            cb.Fill();

            cb.MoveTo(310, 200);

            cb.LineTo(410, 200);

            cb.LineTo(410, 300);

            cb.LineTo(310, 300);

            //Filled, stroked, but path not closed

            cb.FillStroke();

            cb.MoveTo(430, 200);

            cb.LineTo(530, 200);

            cb.LineTo(530, 300);

            cb.LineTo(430, 300);

            //Path closed, stroked and filled
            
            cb.ClosePathFillStroke();
            doc.NewPage();

            var img1 = new System.Drawing.Bitmap(400, 400);
            var g = System.Drawing.Graphics.FromImage(img1);
            g.Clear(System.Drawing.Color.Yellow);
            g.FillRectangle(System.Drawing.Brushes.Red, new System.Drawing.RectangleF(0, 0, 100, 100));

            
            //Image img = Image.GetInstance(Environment.CurrentDirectory+ "\\hello.jpg");
            var img = Image.GetInstance(img1,BaseColor.WHITE);
            img.ScalePercent(50);
            doc.Add(img);
            write.Flush();
            doc.CloseDocument();
        }
    }
}
