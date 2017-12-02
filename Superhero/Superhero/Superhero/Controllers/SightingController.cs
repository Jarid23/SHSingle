using Superhero.Data;
using Superhero.Data.SightingRepository;
using Superhero.Model.Models;
using Superhero.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Mvc;

namespace Superhero.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class SightingController : ApiController
    {
        //SuperheroDBContext context = new SuperheroDBContext();
        ISightingRepo repo = SightingRepoFactory.Create();

        
        [System.Web.Http.Route("sightings/{property}/{parameter}")]
        public IHttpActionResult GetByType(string property, string parameter)
        {
            ISightingRepo repo = SightingRepoFactory.Create();
            var toReturn = new List<Sighting>();

            switch (property)
            {
                case "Hero":
                    toReturn = repo.GetSightingsByHero(parameter).ToList();
                    break;
                case "Location":
                    toReturn = repo.GetSightingsByLocation(parameter).ToList();
                    break;
                case "date":
                    if (parameter[0] == '#')
                    {
                        parameter = parameter.Remove(0, 1);
                    }
                    toReturn = repo.GetSighintsByDate(parameter).ToList();
                    break;
                //case "Organization":
                //    toReturn = repo.GetSightingsByOrganization(parameter);
                //    break;
            }
             return Ok(toReturn);
        }
    }
}
