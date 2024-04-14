using JobBoard.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace JobBoard.Controllers
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
           /* string tekst =
                "Litwo! Ojczyzno moja! ty jesteœ jak zdrowie.\r\n\r\nIle ciê trzeba ceniæ, ten tylko siê dowie,\r\n\r\nKto ciê straci³. Dziœ piêknoœæ tw¹ w ca³ej ozdobie\r\n\r\nWidzê i opisujê, bo têskniê po tobie.\r\n\r\n \r\n\r\nPanno Œwiêta, co Jasnej bronisz Czêstochowy\r\n\r\nI w Ostrej œwiecisz Bramie! Ty, co gród zamkowy\r\n\r\nNowogródzki ochraniasz z jego wiernym ludem!\r\n\r\nJak mnie dziecko do zdrowia powróci³aœ cudem\r\n\r\n(Gdy od p³acz¹cej matki pod Twojê opiekê\r\n\r\nOfiarowany, martw¹ podnios³em powiekê\r\n\r\nI zaraz mog³em pieszo do Twych œwi¹tyñ progu\r\n\r\nIœæ za wrócone ¿ycie podziêkowaæ Bogu),\r\n\r\nTak nas powrócisz cudem na Ojczyzny ³ono.\r\n\r\nTymczasem przenoœ mojê duszê utêsknion¹\r\n\r\nDo tych pagórków leœnych, do tych ³¹k zielonych,\r\n\r\nSzeroko nad b³êkitnym Niemnem rozci¹gnionych;\r\n\r\nDo tych pól malowanych zbo¿em rozmaitem,\r\n\r\nWyz³acanych pszenic¹, posrebrzanych ¿ytem;\r\n\r\nGdzie bursztynowy œwierzop, gryka jak œnieg bia³a,\r\n\r\nGdzie panieñskim rumieñcem dziêcielina pa³a,\r\n\r\nA wszystko przepasane, jakby wstêg¹, miedz¹\r\n\r\nZielon¹, na niej z rzadka ciche grusze siedz¹.\r\n\r\n";
            string GotowyTekst="";

            tekst.Replace("\r\n\r\n"," \n") .Split(' ').ToList().ForEach(t =>
            {
                if(t.Length>0)
                    GotowyTekst += t[0] + ((t.Length>1) ? new string('_', t.Length - 1) + " ": " ");
            });

            ViewData["tekst"] = GotowyTekst;*/
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
