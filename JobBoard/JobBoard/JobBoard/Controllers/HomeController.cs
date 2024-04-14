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
                "Litwo! Ojczyzno moja! ty jeste� jak zdrowie.\r\n\r\nIle ci� trzeba ceni�, ten tylko si� dowie,\r\n\r\nKto ci� straci�. Dzi� pi�kno�� tw� w ca�ej ozdobie\r\n\r\nWidz� i opisuj�, bo t�skni� po tobie.\r\n\r\n \r\n\r\nPanno �wi�ta, co Jasnej bronisz Cz�stochowy\r\n\r\nI w Ostrej �wiecisz Bramie! Ty, co gr�d zamkowy\r\n\r\nNowogr�dzki ochraniasz z jego wiernym ludem!\r\n\r\nJak mnie dziecko do zdrowia powr�ci�a� cudem\r\n\r\n(Gdy od p�acz�cej matki pod Twoj� opiek�\r\n\r\nOfiarowany, martw� podnios�em powiek�\r\n\r\nI zaraz mog�em pieszo do Twych �wi�ty� progu\r\n\r\nI�� za wr�cone �ycie podzi�kowa� Bogu),\r\n\r\nTak nas powr�cisz cudem na Ojczyzny �ono.\r\n\r\nTymczasem przeno� moj� dusz� ut�sknion�\r\n\r\nDo tych pag�rk�w le�nych, do tych ��k zielonych,\r\n\r\nSzeroko nad b��kitnym Niemnem rozci�gnionych;\r\n\r\nDo tych p�l malowanych zbo�em rozmaitem,\r\n\r\nWyz�acanych pszenic�, posrebrzanych �ytem;\r\n\r\nGdzie bursztynowy �wierzop, gryka jak �nieg bia�a,\r\n\r\nGdzie panie�skim rumie�cem dzi�cielina pa�a,\r\n\r\nA wszystko przepasane, jakby wst�g�, miedz�\r\n\r\nZielon�, na niej z rzadka ciche grusze siedz�.\r\n\r\n";
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
