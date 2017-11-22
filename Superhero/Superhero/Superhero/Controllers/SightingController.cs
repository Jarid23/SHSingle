using Superhero.Data.SightingRepository;
using Superhero.Model.Models;
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
        // GET: Sighting
        ISightingRepo repo = SightingRepoFactory.Create();

        

        [System.Web.Http.Route("sighting/{id}")]
        [System.Web.Http.AcceptVerbs("GET")]
        public IHttpActionResult Sighting(int ID)
        {
            return Ok(repo.GetSightingsById(ID));
        }

        [System.Web.Http.Route("sighting/{id}")]
        public Sighting GetById(int ID)
        {
            var toReturn = repo.GetSightingsById(ID);
            return toReturn;
        }

        //[System.Web.Http.Route("sighting/{property}/{parameter}")]
        //public List<Sighting> GetByType(string property, string parameter)
        //{
        //    var toReturn = new List<Sighting>();
           
        //    switch (property)
        //    {               
        //        case "date":
        //            if (parameter[0] == '#')
        //            {
        //                parameter = parameter.Remove(0, 1);
        //            }
        //            toReturn = repo.GetSighintsByDate(parameter);
        //            break;                                   
        //    }
        //    return toReturn;
        }
    }

