using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;

namespace PdfWithConsol
{
	internal class Program
	{
		static void Main(string[] args)
		{
			String path = @"D:\C#\PdfCreate\PdfCreate\Document\invoice.pdf";
			PdfWriter writer = new PdfWriter(path);
			PdfDocument pdf = new PdfDocument(writer);
            Document document = new Document(pdf);
			document.Add(new Paragraph("Hello World"));
			document.Close();
			
		}
	}
}