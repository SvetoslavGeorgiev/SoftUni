namespace SchoolMealsOrderingSystem.Controllers
{
    using Microsoft.AspNetCore.Localization;
    using Microsoft.AspNetCore.Mvc;

    public class LangController : Controller
    {
        public async Task<IActionResult> ChangeLanguage(string culture)
        {
            Console.WriteLine("new selected language: " + culture);

            if (!string.IsNullOrEmpty(culture))
            {
                Response.Cookies.Append(
                    CookieRequestCultureProvider.DefaultCookieName,
                    CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)),
                    new CookieOptions { Expires = DateTimeOffset.UtcNow.AddYears(1) }
                );
            }

            var returnUrl = Request.Headers["Referer"].ToString() ?? "/";

            return Redirect(returnUrl);
        }
    }
}
