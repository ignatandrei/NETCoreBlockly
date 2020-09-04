using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestBlocklyHtml.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ZArduinoController : ControllerBase
    {
        string ON(string led)
        {
            return "On("+led+")";
        }
        private void verifyLed(int led)
        {
            var r = Enumerable.Range(1, 12);
            if (!r.Contains(led))
                throw new ArgumentException($"led must be between {r.Min()} and {r.Max()}");

        }
        [HttpGet("{led}")]
        public string ONLed(int led)
        {
            verifyLed(led);
            return ON("LED"+led);
        }

        [HttpGet("{led}")]
        public string OFFLed(int led)
        {
            verifyLed(led);
            return OFF("LED" + led);
        }
        string OFF(string led)
        {
            return "Off(" + led + ")";
        }
        [HttpGet("{seconds}")]
        public async Task<string>  Wait(int seconds)
        {
            await Task.Delay(1000 * seconds);
            return "WAIT(" + seconds+ ")";
        }
        [HttpGet("{minutes}")]
        public async Task<string> Sleep(int minutes)
        {
            await Task.Delay(1000 *60 * minutes);
            return "SLEEP(" + minutes + ")";
        }
        [HttpGet()]
        public string SleepForever()
        {
            return "SleepForever()";
        }


    }
}
