using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Question_5_Settings.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CredentialNameController : ControllerBase
    {

        private readonly IConfiguration _configuration;
        public CredentialNameController(IConfiguration configuration)
        {
 
            _configuration = configuration;
        }
        [HttpGet]
        public string Get()
        {
            var myvalue = _configuration["credentialName"];
            return $" Read the settings in the config file. Section credentialName :{myvalue}" ;
        }
    }
}
