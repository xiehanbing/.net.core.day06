using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using day06.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace day06.Controllers
{
    public class ConfigController : Controller
    {
        private IOptions<PersonModelV2> _options;

        public ConfigController(IOptions<PersonModelV2> options)
        {
            _options = options;
        }
        /// <summary>
        /// 测试 .net core config 
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            var configBuild = new ConfigurationBuilder();
            configBuild.SetBasePath(System.IO.Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");

            var configuration = configBuild.Build();

            //return Content(configuration.GetConnectionString("DefaultConnection"));

            //var name = configuration.GetValue<string>("name");
            var name1 = configuration["person:0:age"];

            var option = _options.Value;
            if (option == null)
            {
                throw new Exception("未获取到配置");
            }

           

            return Content(option.Name.ToString());
        }
    }
}