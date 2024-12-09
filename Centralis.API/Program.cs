using Centralis.Core.Interfaces;
using Centralis.Core.Services;
using Centralis.Data.Clients;
using Centralis.Data.Interfaces;
using Centralis.Data.Interfaces.Clients;
using Centralis.Data.Repositories;

namespace Centralis.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            var configuration = builder.Configuration;

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddSingleton<IDbClient>(provider => new DbClient(configuration["ConnectionString"]));

            builder.Services.AddSingleton<IDataRepository, DataRepository>();
            builder.Services.AddSingleton<IPatientRepository, PatientRepository>();

            builder.Services.AddSingleton<IDataService, DataService>();
            builder.Services.AddSingleton<IPatientService, PatientService>();

            var app = builder.Build();

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
    }
}
