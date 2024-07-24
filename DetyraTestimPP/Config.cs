using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DetyraTestimPP
{
    public class Config
    {
        
        public static string BaseUrl = "https://www.riinvest.net/";
        public static string ScreenshotDir = @"C:\Users\pleur\Desktop\DetyraTestimPP\DetyraTestimPP\bin\Debug\Screenshots";

 
        public static string Filma24 = "https://www.filma24.ai/";
        public static string MerrJep = "https://www.merrjep.com/";
        public static string Netflix = "https://www.netflix.com/rs/";
        public static string Kallxo = "https://kallxo.com/";
        public static string RealEstate = "https://arbk.rks-gov.net/";
        public static string CurrencyCalculator = "https://www.calculator.net/";
        public static string UnitConverter = "https://www.unitconverters.net/";
        public static string KuPoHajna = "https://www.kupohajna.com/";


        public static class Credentials
        {
            public static class Valid
            {
                public static string Username = "xxxxx";
                public static string Password = "xxxxx";
            }
            public static class Invalid
            {
                public static string Username = "xxxxx";
                public static string Password = "xxxxx";
            }

            //MerrJep Data
            public static class MerrJepData
            {
                public static string VideoFile = @"C:\Users\pleur\Desktop\Cartoon.jpg";
                public static string Email = "xxxxx";
                public static string Password = "xxxxx";
                public static string Money = "369";
            }

            //Filma24 Data
            public static class Filma24Data
            {
                public static string FilmName = "Tenet";
            }

            //Netflix Data
            public static class NetflixData
            {
                public static string Username = "xxxxx";
                public static string Password = "xxxxx";
            }

            //BusinessRegistrationData ARBK Data
            public static class BusinessRegistrationData
            {
                public static string BussinesName = "Riinvest";
                public static string Confirm = "Rrezultatet e Bizneseve";
            }

            //Currency Data
            public static class CurrencyConverterData
            {
                public static string PriceValue = "100";
                public static string FromEuro = "EUR";
                public static string ToUSD = "USD";
                public static string KeyWord = "Result";
            }

            //UnitConverterData Data
            public static class UnitConverterData
            {
                public static string MeasureValue = "130";
                public static string RevMeasure = "100";
                public static string ConfirmPage = "Result:";
            }

            //Kallxo Data
            public static class KallxoData
            {
                public static string CompareValue = "Vdekja në karantinë";
            }

            //KuPoHajna Data
            public static class KuPoHajnaData
            {
                public static string Food = "Dyner";
                public static string KeyWord = "Vazhdo";
            }

        }

 
        public static class AlertMessages
        {
            public static string ValidLink = "Linku eshte valid";
            public static string InvalidLink = "Linku nuk eshte valid";

            //Filma24
            public static string Carosel = "movie-box-1";
            public static string CompareLink = "http://short24.pw/c7vzN";

            //MerrJep
            public static string DeleteKeyWord = "Fshij";

            //Netflix
            public static string NotAvailable = "This channel is not available.";

            //Telegrafi
            public static string NotFound = "Faqja qe po kerkoni nuk egziston!.";

            // Vlera per D.K.
            public static string ValidCredentials = "Pleurat";
            public static string InvalidCredentials = "Përdoruesi ose Fjalëkalimi është gabim.";
        }
    }
}
