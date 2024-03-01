using Microsoft.EntityFrameworkCore;
using WebApi.Interfaces.Repositories;
using WebApi.Repositories;

namespace WebApi
{
    public class Program
    {
        private static WebApplicationBuilder? _builder { get; set; }
        private static ConfigurationManager? _config { get; set; }
        public static void Main(string[] args)
        {
            _builder = WebApplication.CreateBuilder(args);
            _config = _builder.Configuration;

            // Add services to the container.

            AddServices(_builder.Services);

            var app = _builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();

        }

        private static void AddServices(IServiceCollection services)
        {
            services.AddDbContext<HeroContext>(options =>
                options.UseSqlServer(_config?.GetConnectionString("FightingHeroesDb")));

            services.AddControllers();

            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

            // CORS enabled
            services.AddCors();
            services.AddScoped<IRepositoryWrapper, RepositoryWrapper>();
        }
    }
}

