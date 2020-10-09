using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TestBlocklyHtml.Controllers
{
    public partial class dboAssVA
    {

        public dboAssVA(int id)
        {
            this.idassva = id;
        }



        #region Properties

        public Int64 idassva { get; set; }



        public String nameassva
        {
            get
            {
                return "test " + idassva;
            }
        }


        
        #endregion

    }
    public class People
    {
        public dboAssVA Manager { get; set; }
        public People[] Team { get; set; }

        public int NumberPeopleInTeam
        {
            get
            {
                return Team?.Length ?? 0;
            }
        }
    }
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TestGUIController : ControllerBase
    {

        //TODO: solve how the GUI is displayed for team
        public async Task<People[]> Managers()
        {
            
            
            var p = new People();
            p.Manager = new dboAssVA(6);
            p.Team = new People[3];
            for (int i = 0; i < p.Team.Length; i++)
            {
                var t = new People();
                t.Manager = new dboAssVA(i);
                p.Team[i] = t;
            }
            return new[] { p };
        }
    }
}
