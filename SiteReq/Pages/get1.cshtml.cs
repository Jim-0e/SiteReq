using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NuGet.Protocol;

namespace SiteReq.Pages
{
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
                ViewData["ResponseData"] = responseString.ToJson(); // Сохраняем полученные данные в ViewData

            }
            else
            {
                ViewData["Error"] = "Ошибка при выполнении запроса";
                // Обработка ошибки, если запрос не удался
            }
        }
    }
}
