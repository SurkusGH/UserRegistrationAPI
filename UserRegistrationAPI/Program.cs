using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Serilog;
using Serilog.Events;
using System;

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
// �mogaus u�registravimo sistema
//
// User informacija:
//                  Username
//                  Password
//                  Salt
//                  Role
//                  �mogaus Informacijos s�ry�is
//
// �mogaus informacija:
//                     Vardas
//                     Pavard�
//                     Asmens kodas
//                     Telefono numeris
//                     El. pa�tas
//                     Profilio nuotrauka
//                     Gyvenamoji vieta
//
//Gyvenamoji vieta:
//                 Miestas
//                 Gatv�
//                 Namo numeris
//                 Buto numeris
#endregion

#region Assignemt
// Eiga:
//  (1) Vartotojas turi gal�ti u�siregistruoti.
//
//  (2) U�siregistravus sukuriamas User'is su default'ine role 'User'.
//
//  (3) Useris turi gal�ti sukelti apie save informacij�, kurioje VISI laukai privalomi (�mogaus informacija),
//      vartotojas neturi gal�ti sukelti informacijos apie daugiau nei vien� �mog�.
//
//  (4) Turi b�ti skirtingi endpoint atnaujint KIEKVIEN� i� lauk�, pvz.: Vard�, asmens kod�,
//      telefono numer�, miest�(negalima atnaujinti � tu��i� lauk� arba whitespace)
//
//  (5) Registruojant �mog� turi b�ti privaloma �kelti profilio nuotrauk�, jos dydis turi b�ti suma�intas iki 200x200
//      (jeigu nuotrauka per ma�a tai j� i�temps iki 200x200).
//
//  (6) Turi b�ti galimyb� gauti vis� informacij� apie �kelt� �mog� pagal jo ID(nuotrauka gr��inama byte masyvu).
//
//  (7) Useris neturi gal�ti atnaujint ne savo �mogaus informacijos, palengvinimo d�l�i sakykime,
//      kad su kiekvienu requestu "i� frontend" ateis User'io ID.
//
//  (8) Taip pat turi b�ti 'Admin' rol�, kuri bus nustatoma per duomen� baz� ir ji tur�s endpoint'�
//      per kur� gal�s i�trinti user'� pagal ID (i�trinant user�� i�trinam ir �mogaus info)
//
//  (9) Neprisijungus turi b�ti galima tik registruotis ir prisijungti
//
// (10) Autentifikacija ir Autorizacija daroma su Json Web Token'ais.
//
// (11) Naudojama Mssql duomen� baz�.
//
// (12) Naudojamas Entity Framework.
#endregion