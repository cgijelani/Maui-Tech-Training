using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
 THIS IS A SINGLE FILE CONTAINING MULTIPLE EXAMPLES
IT IS NOT MEANT AS AN EXAMPLE FOR HOW TO STRUCTURE YOUR APP
 */


namespace MAUI101.Maui.ViewModels
{
    public class ExampleViewModel
    {
        private readonly IConfiguration _configuration;

        public ExampleViewModel(IConfiguration configuration)
        {
            this._configuration = configuration;
        }
        //GetApiData
        public string GetRandomApiImage()
        {
            var url = _configuration["ApiSettings:ApiKey"];
            return url;
        }
    }
}
