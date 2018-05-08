using System;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;
using HAT = Haskell_Atlanta_Types;

namespace Haskell_Atlanta_Print
{
    public class PrintPDF
    {
        public static void Write(HAT.MenuItem menuItem, string fileName, string installDirectory)
        {
            if(menuItem == null)
            {
                return;
            }

            //Gets the parent project title
            HAT.MenuItem mItem = menuItem;
            while (mItem.GetParent() != null)
            {
                mItem = mItem.GetParent();
            }
            string project = mItem.Title;
            string equipment;
            if(menuItem.GetParent().Title.Equals(project))
            {
                equipment = "N/A";
            }
            else
            {
                equipment = menuItem.GetParent().Title;
            }

            float[] widthPercentages;
            PdfPTable table;
            PdfPCell cell;

            FileStream fs = new FileStream(fileName, FileMode.Create, FileAccess.Write, FileShare.None);
            Rectangle pageSize = new Rectangle(PageSize.LETTER);
            Document doc = new Document(pageSize, 36, 36, 36, 36);      //72dpi = 1 inch
            PdfWriter writer = PdfWriter.GetInstance(doc, fs);

            doc.Open();
            //Debugging
            //Image haskell_logo = Image.GetInstance(@"C:\Users\acduniga\Pictures\Haskell-Logo.png");
            //Final            
            Image haskell_logo = Image.GetInstance(installDirectory + @"\Resources\Icons\Haskell_Logo.png");
            haskell_logo.Alignment = iTextSharp.text.Image.ALIGN_LEFT;
            haskell_logo.ScalePercent(8f);

            widthPercentages = new float[] {40f, 20f, 40f};
            table = new PdfPTable(3);
            table.WidthPercentage = 100;
            table.SetWidths(widthPercentages);

            cell = new PdfPCell();

            //Add Haskell Logo to table            
            cell.HorizontalAlignment = Element.ALIGN_LEFT;
            cell.BorderColor = BaseColor.WHITE;
            cell.AddElement(haskell_logo);
            table.AddCell(cell);

            //Add document title to table
            Paragraph p = new Paragraph(menuItem.Title);
            p.Alignment = Element.ALIGN_CENTER;
            cell = new PdfPCell();
            cell.BorderColor = BaseColor.WHITE;
            cell.AddElement(p);  
            table.AddCell(cell);

            //Add empty space to last column of table
            cell = new PdfPCell();
            cell.BorderColor = BaseColor.WHITE;
            table.AddCell(cell);

            //Add table to document
            doc.Add(table);

            //Add vertical whitespace to document
            doc.Add(new Paragraph(" "));

            //Setup table for checklist information
            widthPercentages = new float[] { 30f, 70f };
            table = new PdfPTable(2);
            table.WidthPercentage = 100;
            table.SetWidths(widthPercentages);

            //Project cell identifier
            cell = new PdfPCell();
            p = new Paragraph("Project: ");
            p.Alignment = Element.ALIGN_RIGHT;
            cell.BorderColor = BaseColor.WHITE;
            cell.AddElement(p);
            table.AddCell(cell);            
            
            //Inserts project title
            cell = new PdfPCell();
            p = new Paragraph(project);
            cell.AddElement(p);
            cell.Border = Rectangle.BOTTOM_BORDER;
            table.AddCell(cell);

            //Equipment cell identifier
            cell = new PdfPCell();
            p = new Paragraph("Equipment: ");
            p.Alignment = Element.ALIGN_RIGHT;
            cell.BorderColor = BaseColor.WHITE;
            cell.AddElement(p);
            table.AddCell(cell); 

            //Inserts equipment title
            cell = new PdfPCell();
            p = new Paragraph(equipment);
            cell.AddElement(p);
            cell.Border = Rectangle.BOTTOM_BORDER;
            table.AddCell(cell);
            
            //Add table to document
            doc.Add(table);

            //Add vertical whitespace to document
            doc.Add(new Paragraph(" "));

            p = new Paragraph("Checklist items:");
            p.SpacingAfter = 5f;
            doc.Add(p);

            //Setup table for checklist items
            widthPercentages = new float[] { 5f, 65f, 10f, 10f };
            table = new PdfPTable(4);
            table.WidthPercentage = 100;
            table.SetWidths(widthPercentages);
            Font headerFont = FontFactory.GetFont("Calibri", 11.0f, Font.BOLD, BaseColor.BLACK);
            Font font = FontFactory.GetFont("Calibri", 11.0f, BaseColor.BLACK);
            //Table headers
            cell = new PdfPCell();
            p = new Paragraph("#");
            p.Font = headerFont;
            cell.AddElement(p);
            table.AddCell(cell);
            cell = new PdfPCell();
            p = new Paragraph("Description");
            p.Font = headerFont;
            cell.AddElement(p);
            table.AddCell(cell);
            cell = new PdfPCell();
            p = new Paragraph("Initials");
            p.Font = headerFont;
            cell.AddElement(p);
            table.AddCell(cell);
            cell = new PdfPCell();
            p = new Paragraph("Date");
            p.Font = headerFont;
            cell.AddElement(p);
            table.AddCell(cell);
            //Loops through each checklist item and adds a row to the table
            foreach(HAT.ChecklistItem clItem in menuItem.Checklist)
            {
                //Add item number cell
                cell = new PdfPCell();
                p = new Paragraph(clItem.Number.ToString());
                p.Font = font;
                cell.AddElement(p);
                //cell.Border = Rectangle.BOTTOM_BORDER;
                table.AddCell(cell);

                //Add item description cell
                cell = new PdfPCell();
                p = new Paragraph(clItem.Description);
                p.Font = font;
                cell.AddElement(p);
                //cell.Border = Rectangle.BOTTOM_BORDER;
                table.AddCell(cell);

                //Add item description cell
                cell = new PdfPCell();
                p = new Paragraph(clItem.Initials);
                p.Font = font;
                cell.AddElement(p);
                //cell.Border = Rectangle.BOTTOM_BORDER;
                table.AddCell(cell);

                //Add item description cell
                cell = new PdfPCell();
                p = new Paragraph(clItem.CompletedDate);
                p.Font = font;
                cell.AddElement(p);
                //cell.Border = Rectangle.BOTTOM_BORDER;
                table.AddCell(cell);
            }

            doc.Add(table);

            //Add vertical whitespace to document
            doc.Add(new Paragraph(" "));

            //Notes header
            p = new Paragraph("Notes and Comments:");
            p.SpacingAfter = 5f;
            doc.Add(p);

            //Table for notes and comments
            table = new PdfPTable(1);
            table.WidthPercentage = 100;
            p = new Paragraph(" ");
            cell = new PdfPCell();
            cell.AddElement(p);
            cell.Border = Rectangle.BOTTOM_BORDER;
            //Iterate over number of desired spaces for notes and comments
            for (int i = 0; i < 5; i++)
            {
                table.AddCell(cell);
            }
            doc.Add(table);

            doc.Close();
        }
    }
}
