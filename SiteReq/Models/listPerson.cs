using Microsoft.EntityFrameworkCore;
using SiteReq.Data;
using SiteReq.Models;

namespace RazorPagesMovie.Models;

public static class SeedData
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using (var context = new SiteReqContext(
            serviceProvider.GetRequiredService<
                DbContextOptions<SiteReqContext>>()))
        {
            if (context == null || context.Person == null)
            {
                throw new ArgumentNullException("Null RazorPagesMovieContext");
            }

            // Look for any movies.
            if (context.Person.Any())
            {
                return;   // DB has been seeded
            }

            
            context.SaveChanges();
        }
    }
}