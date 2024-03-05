using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SiteReq.Data;
using SiteReq.Models;


namespace SiteReq.Pages.Persons
{


    public class IndexModel : PageModel
    {
        private readonly SiteReq.Data.SiteReqContext _context;

        public IndexModel(SiteReq.Data.SiteReqContext context)
        {
            _context = context;
        }

        public IList<Person> Person { get;set; } = default!;


        [BindProperty(SupportsGet = true)]
        public string? SearchString { get; set; }

      //  public SelectList? Genres { get; set; }

       // [BindProperty(SupportsGet = true)]
        //public string? MovieGenre { get; set; }



        public async Task OnGetAsync()
        {
            var movies = from m in _context.Person
                         select m;
            if (!string.IsNullOrEmpty(SearchString))
            {
                movies = movies.Where(s => s.NameProject.Contains(SearchString));
            }

            Person = await movies.ToListAsync();
        }


       

    }
    public class YourPageModel : PageModel
    {
        private readonly IHttpClientFactory _clientFactory;

        public YourPageModel(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task OnGet()
        {
            var client = _clientFactory.CreateClient();
            var response = await client.GetAsync("https://api.github.com/search/repositories?q=subject");

            if (response.IsSuccessStatusCode)
            {
                var responseString = await response.Content.ReadAsStringAsync();
                ViewData["ResponseData"] = responseString; // Сохраняем полученные данные в ViewData

            }
            else
            {
                ViewData["Error"] = "Ошибка при выполнении запроса";
                // Обработка ошибки, если запрос не удался
            }
        }
    }
}
