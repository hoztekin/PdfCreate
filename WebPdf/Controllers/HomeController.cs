using System.Diagnostics;
using iText.Html2pdf;
using iText.Kernel.Pdf;
using iText.Layout;
using Microsoft.AspNetCore.Mvc;
using WebPdf.Models;
using WebPdf.Helper;

namespace WebPdf.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            string htmlContent = await this.RenderViewToStringAsync<object>("Index", null);
            string pdfDosyaYolu = @"D:\C#\PdfCreate\outputRazorHtml.pdf";
            PdfWriter writer = new PdfWriter(pdfDosyaYolu);
            PdfDocument pdf = new PdfDocument(writer);
            Document document = new Document(pdf);
            // HTML'i PDF'e dönüþtürme - doðru metod çaðrýsý
            ConverterProperties converterProperties = new ConverterProperties();
            HtmlConverter.ConvertToPdf(htmlContent, pdf, converterProperties);

            document.Close();

            return View();
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
