using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace TSD_TestGenerator.Controllers
{
    [Route("api")]
    [ApiController]
    public class ApiController : Controller
    {
        public class ApiEndpoint
        {
            public const string GET = "GET";
            public const string POST = "POST";

            public string Url { get; set; }
            public string Description { get; set; }
            public string HttpRequestType { get; set; }
            public List<string> ReturnObjectFields { get; set; }
            public string ExampleResponsetData { get; set; }
            public List<string> RequestObjectFields { get; set; }
            public string ExampleRequestData { get; set; }
            public Dictionary<string, string> OptionalParameters { get; set; }
        }

        private List<ApiEndpoint> endpoints = new List<ApiEndpoint>
        {
            new ApiEndpoint
            {
                Url = "api",
                Description = "List of availible endpoints",
                HttpRequestType = ApiEndpoint.GET,
                RequestObjectFields = null,
                ReturnObjectFields = new List<string>
                {
                    "url", "description", "httpRequestType", "returnObjectFields", "exampleResponsetData", "requestObjectFields", "exampleRequestData" , "optionalParameters"
                },
                ExampleResponsetData = "",
                OptionalParameters = null
            },
            new ApiEndpoint
            {
                Url = "api/quiz",
                Description = "Generate random quiz",
                HttpRequestType = ApiEndpoint.GET,
                RequestObjectFields = null,
                ExampleRequestData = null,
                ReturnObjectFields = new List<string>
                {
                    "content", "answers { content, isCorrect}"
                },
                ExampleResponsetData = "[{\"content\":\"Pierwsze pytanie\",\"answers\":[{\"content\":\"Pierwsza odpowiedz\",\"isCorrect\":true},{\"content\":\"Druga\",\"isCorrect\":false},{\"content\":\"Trzecia\",\"isCorrect\":false},{\"content\":\"Czwarta\",\"isCorrect\":false}]}]",
                OptionalParameters = new Dictionary<string, string>
                {
                    { "number", "number of questions in generated quiz" }
                }
            },
            new ApiEndpoint
            {
                Url = "api/quiz/question",
                Description = "Add question",
                HttpRequestType = ApiEndpoint.POST,
                RequestObjectFields = new List<string>
                {
                    "content", "answers { content, isCorrect}"
                },
                ExampleRequestData = "{\"content\":\"Trzecie pytanie\",\"answers\":[{\"content\":\"1\",\"isCorrect\":true},{\"content\":\"2\",\"isCorrect\":false}]}",
                ReturnObjectFields = null,
                ExampleResponsetData = null,
                OptionalParameters = null
            }
        };

        [HttpGet]
        public ActionResult<IEnumerable<ApiEndpoint>> Get()
        {
            return endpoints;
        }
    }
}