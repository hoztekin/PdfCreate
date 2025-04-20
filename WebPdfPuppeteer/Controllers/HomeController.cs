using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using PuppeteerSharp.Media;
using PuppeteerSharp;
using WebPdfPuppeteer.Models;

namespace WebPdfPuppeteer.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> GeneratePdf()
        {
            await new BrowserFetcher().DownloadAsync();

            // Taray�c�y� ba�lat
            await using var browser = await Puppeteer.LaunchAsync(new LaunchOptions
            {
                Headless = true
            });

            #region Chrome Ind�rme yava�lat�yorsa bununla devam
            //// Mevcut Chrome taray�c�s�n� kullanmak i�in
            //await using var browser = await Puppeteer.LaunchAsync(new LaunchOptions
            //{
            //    Headless = true,
            //    ExecutablePath = @"C:\Program Files\Google\Chrome\Application\chrome.exe" // Chrome yolunuzu buraya yaz�n
            //}); 
            #endregion

            // Yeni bir sayfa a�
            await using var page = await browser.NewPageAsync();

            // Sitenizin URL'si - localhost adresinizi ve port numaran�z� kullan�n
            string url = "https://localhost:7051/"; // Kendi port numaran�z� kullan�n
            await page.GoToAsync(url, WaitUntilNavigation.Networkidle0);

            // PDF olu�tur
            string pdfPath = "D:/C#/PdfCreate/outputPuppeteerSharp.pdf";
            await page.PdfAsync(pdfPath, new PdfOptions
            {
                Format = PaperFormat.A4,
                PrintBackground = true,
                MarginOptions = new MarginOptions
                {
                    Top = "20px",
                    Right = "20px",
                    Bottom = "20px",
                    Left = "20px"
                }
            });

            // PDF'i indir veya g�r�nt�le
            var fileBytes = System.IO.File.ReadAllBytes(pdfPath);
            return File(fileBytes, "application/pdf", "websitePdf.pdf");
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
