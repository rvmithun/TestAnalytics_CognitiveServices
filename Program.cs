using System;
using Azure;
using System.Configuration;
using Azure.AI.TextAnalytics;
using System.Runtime.CompilerServices;
/*
This is a test code developed to prove the outcome of using an Azure cognitive services. 

The below program makes sure whether a feedback that is being provided is a postive/negative or a neutral feedback
     */

namespace TestAnalytics
{
    class Program
    {
        
        static void Main(string[] args)
        {
            var key = ConfigurationManager.AppSettings["azureSubscriptionKey"];
           var endpointKey= ConfigurationManager.AppSettings["azureEndPoint"];
            var credentials = new AzureKeyCredential(key);
            var endpoint = new Uri(endpointKey);
           CarryOutTestAnalysis(credentials, endpoint);          
        }

        /*
         * The below method gets the user inputs and lets us know the nature of the feedback
         */
        private static void CarryOutTestAnalysis(AzureKeyCredential credentials, Uri endpoint)
        {
            var client = new TextAnalyticsClient(endpoint, credentials);
            Console.WriteLine("Please provide your comments");
            var inputText = Console.ReadLine();
            DocumentSentiment documentSentiment = client.AnalyzeSentiment(inputText);
            Console.WriteLine($"Feedback level: {documentSentiment.Sentiment} feedback\n");
            Console.ReadLine();

        }

        
    }
}
