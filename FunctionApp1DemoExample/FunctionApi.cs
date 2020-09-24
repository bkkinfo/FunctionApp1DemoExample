using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using FunctionApp1DemoExample.Repository;
using FunctionApp1DemoExample.Data;

namespace FunctionApp1DemoExample
{
    // public static class FunctionApi
    public class FunctionApi
    {
        //private readonly LibraryDbContext _libraryDbContext;
        private readonly IBookRepository _booksRepository;

        public FunctionApi(/** LibraryDbContext libraryDbContext , **/IBookRepository booksRepository)
        {
            //_libraryDbContext = libraryDbContext;
            _booksRepository = booksRepository;
        }
        [FunctionName("FunctionApi")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger:- Azure Function Example");

            string name = req.Query["name"];

            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            dynamic data = JsonConvert.DeserializeObject(requestBody);
            name = name ?? data?.name;

            string responseMessage = string.IsNullOrEmpty(name)
                ? "This HTTP triggered function executed successfully. Pass a name in the query string or in the request body for a personalized response."
                : $"Hello, {name}. This HTTP triggered function executed successfully.";

            return new OkObjectResult(responseMessage);
        }

        [FunctionName("BooksApi")]
        public async Task<IActionResult> BooksApiRun(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            //string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            //dynamic data = JsonConvert.DeserializeObject(requestBody);
            //name = name ?? data?.name;
            //BooksRepository booksRepository = new BooksRepository();
            string responseMessage = JsonConvert.SerializeObject(_booksRepository.GetBooks());

            return new OkObjectResult(responseMessage);
        }
    }
}
