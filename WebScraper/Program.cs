using HtmlAgilityPack;
using System;
using System.Net.Http;

namespace WebScraper
{
    class Program
    {
        static void Main()
        {
            //Enviar requisição get para weather.com
            String url = "https://weather.com/pt-BR/clima/hoje/l/BRXX0043:1:BR?Goto=Redirected";
            var httpClient = new HttpClient();
            var html = httpClient.GetStringAsync(url).Result;
            var htmlDocument = new HtmlDocument();
            htmlDocument.LoadHtml(html);

            //Temperatura
            var temperatureElement = htmlDocument.DocumentNode.SelectSingleNode("//span[@class='CurrentConditions--tempValue--MHmYY']");
            var temperature = temperatureElement.InnerText.Trim();
            Console.WriteLine("Temperatura: " + temperature);

            //Condições 
            var conditionElement = htmlDocument.DocumentNode.SelectSingleNode("//div[@class='CurrentConditions--phraseValue--mZC_p']");
            var condition = conditionElement.InnerText.Trim();
            Console.WriteLine("Condição: " + condition);

            //Localização
            var locationElement = htmlDocument.DocumentNode.SelectSingleNode("//h1[@class='CurrentConditions--location--1YWj_']");
            var timeElement = htmlDocument.DocumentNode.SelectSingleNode("//span[@class='CurrentConditions--timestamp--1ybTk']");
            var time = timeElement.InnerText.Trim();
            var location = locationElement.InnerText.Trim();
            Console.WriteLine("Localização: " + location + " " + time);
        }
    }
}