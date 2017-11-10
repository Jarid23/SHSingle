using DVDLibrary.Models;
using DVDLibrary.Models.Interfaces;
using DVDLibrary.Models.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;


namespace DVDLibrary2.API.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class DvdController : ApiController
    {
        IDvdRepository repo = DVDRepositoryFactory.Create();
        // GET: Dvd
        [System.Web.Http.Route("dvd/{id}")]
        [System.Web.Http.AcceptVerbs("GET")]
        public IHttpActionResult Dvd(int id)
        {
            return Ok(repo.GetSingleDvd(id));
        }

        [Route("dvds")]
        [AcceptVerbs("GET")]
        public IHttpActionResult Dvds()
        {
            return Ok(repo.GetDvdList());
        }

        [Route("dvd")]
        [AcceptVerbs("POST")]
        public IHttpActionResult Add(Dvd dvd)
        {
            repo.AddDvd(dvd);
            return Created($"dvd/{dvd.dvdId}", dvd);
        }

        [Route("dvd")]
        [Route("dvd/{id}")]
        [AcceptVerbs("OPTIONS")]
        public IHttpActionResult Options()
        {
            return Ok();
        }

        [Route("dvd/{id}")]
        [AcceptVerbs("DELETE")]
        public IHttpActionResult Delete(int id)
        {
            repo.DeleteDvd(id);
            return Ok();
        }
        [Route("dvd/{id}")]
        [AcceptVerbs("PUT")]
        public IHttpActionResult Edit(Dvd dvd)
        {
            repo.EditDvd(dvd);
            return Ok();
        }

        [Route("dvds/rating/{Rating}")]
        [AcceptVerbs("GET")]
        public IHttpActionResult DvdsRating(string rating)
        {
            return Ok(repo.GetDvdsByRating(rating));
        }

        [Route("dvds/year/{ReleaseYear}")]
        [AcceptVerbs("GET")]
        public IHttpActionResult DvdsYear(int releaseYear)
        {
            return Ok(repo.GetDvdsByYear(releaseYear));
        }

        [Route("dvds/title/{Title}")]
        [AcceptVerbs("GET")]
        public IHttpActionResult DvdsTitle(string title)
        {
            return Ok(repo.GetDvdsByTitle(title));
        }

        [Route("dvds/director/{Director}")]
        [AcceptVerbs("GET")]
        public IHttpActionResult DvdsDirector(string director)
        {
            return Ok(repo.GetDvdsByDirector(director));
        }
    }
}
