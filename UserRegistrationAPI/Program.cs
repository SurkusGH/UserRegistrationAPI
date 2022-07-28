using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserRegistrationAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            #region Serilog
            Log.Logger = new LoggerConfiguration() // <- initiate logger
               .WriteTo.File(
                    path: "d:\\UserRegistationAPI\\logs\\log-.txt", // <- set where the logger creates log file
                    outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} [{level:u3}] {Message:lj}{NewLine}{Exception}",// <- Formating
                    rollingInterval: RollingInterval.Day, // <- indicates how often "log-[index] file is created, current setting one-eachDay"
                    restrictedToMinimumLevel: LogEventLevel.Information // <- using Serilog.Events; 
                    ).CreateLogger(); // <- creates logger w/ aforementioned parameters
            try
            {
                Log.Information("Application is starting..."); // <- with this we log the fact that application launches in a log file
                CreateHostBuilder(args).Build().Run();
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "(!) Application Failed to start..."); // <- with this we log the fact that application launch failed in a log file
            }
            finally
            {
                Log.CloseAndFlush();
            }
            #endregion
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .UseSerilog()
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}

#region DataStructure
// Þmogaus uþregistravimo sistema
//
// User informacija:
//                  Username
//                  Password
//                  Salt
//                  Role
//                  Þmogaus Informacijos sàryðis
//
// Þmogaus informacija:
//                     Vardas
//                     Pavardë
//                     Asmens kodas
//                     Telefono numeris
//                     El. paðtas
//                     Profilio nuotrauka
//                     Gyvenamoji vieta
//
//Gyvenamoji vieta:
//                 Miestas
//                 Gatvë
//                 Namo numeris
//                 Buto numeris
#endregion

#region Assignemt
// Eiga:
//  (1) Vartotojas turi galëti uþsiregistruoti.
//
//  (2) Uþsiregistravus sukuriamas User'is su default'ine role 'User'.
//
//  (3) Useris turi galëti sukelti apie save informacijà, kurioje VISI laukai privalomi (Þmogaus informacija),
//      vartotojas neturi galëti sukelti informacijos apie daugiau nei vienà þmogø.
//
//  (4) Turi bûti skirtingi endpoint atnaujint KIEKVIENÀ ið laukø, pvz.: Vardà, asmens kodà,
//      telefono numerá, miestà(negalima atnaujinti á tuðèià laukà arba whitespace)
//
//  (5) Registruojant þmogø turi bûti privaloma ákelti profilio nuotraukà, jos dydis turi bûti sumaþintas iki 200x200
//      (jeigu nuotrauka per maþa tai jà iðtemps iki 200x200).
//
//  (6) Turi bûti galimybë gauti visà informacijà apie ákeltà þmogø pagal jo ID(nuotrauka gràþinama byte masyvu).
//
//  (7) Useris neturi galëti atnaujint ne savo þmogaus informacijos, palengvinimo dëlëi sakykime,
//      kad su kiekvienu requestu "ið frontend" ateis User'io ID.
//
//  (8) Taip pat turi bûti 'Admin' rolë, kuri bus nustatoma per duomenø bazæ ir ji turës endpoint'à
//      per kurá galës iðtrinti user'á pagal ID (iðtrinant user’á iðtrinam ir þmogaus info)
//
//  (9) Neprisijungus turi bûti galima tik registruotis ir prisijungti
//
// (10) Autentifikacija ir Autorizacija daroma su Json Web Token'ais.
//
// (11) Naudojama Mssql duomenø bazë.
//
// (12) Naudojamas Entity Framework.
#endregion