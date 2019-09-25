using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using VideoGameStore2.Models;

[assembly: HostingStartup(typeof(VideoGameStore2.Areas.Identity.IdentityHostingStartup))]
namespace VideoGameStore2.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<GameStoreDBContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("GameStoreDBContext")));

                services.AddDefaultIdentity<GameStoreUser>()
                    .AddEntityFrameworkStores<GameStoreDBContext>();
            });
        }
    }
}