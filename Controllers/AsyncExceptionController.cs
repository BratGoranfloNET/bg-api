using Microsoft.AspNetCore.Mvc;

namespace bg_api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public  class AsyncExceptionController : Controller
    {

        [HttpGet(Name = "GetAsync")]
        public async Task<string> Get()
        {
            var result =  await  MainAsync();

            return result;
        }


         async Task<string> MainAsync() 
        {
            string path = @"d:\testfile.txt";

            Task<string> task = ReadFileAsync(path);

            try
            {
                string text = await task;
                return text;                

            }
            catch(Exception ex)
            {
                return ex.Message;

            }
           
        }

         async Task<string> ReadFileAsync(string fileName)
        {
            using (StreamReader sr = System.IO.File.OpenText(fileName))
            {
                return await sr.ReadToEndAsync();   
            }
        }

    }
}
