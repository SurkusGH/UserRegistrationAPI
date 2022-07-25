using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
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
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
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