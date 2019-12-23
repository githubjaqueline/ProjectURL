using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectURL.Data.Context;
using ProjectURL.Domain.Models;
using ProjectURL.Domain.Services;

namespace ProjectURL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UrlsController : ControllerBase
    {
        private readonly ProjectURLContext _context;




        public UrlsController(ProjectURLContext context)
        {
            _context = context;
         
        }


        // POST: api/Urls
        //[HttpPost]
        //public ActionResult<Url> ExecuteProcessUrl([FromBody] Url url)
        //{
        //    try
        //    {

        //        var result = _urlService.ExecuteProcessShortURL(url);
        //        return Ok(result);

        //    }
        //    catch (Exception e)
        //    {
        //        return BadRequest();
        //    }

        //}



        // POST: api/Urls1
        [HttpPost]
        public ActionResult<Url> PostUrl(Url url)
        {

            try
            {

                UrlService urlServ = new UrlService();

                var result = urlServ.ExecuteProcessShortURL(url);
                _context.dbSetUrl.Add(url);
                _context.SaveChanges();
                return Ok(result);

            }
            catch (Exception e)
            {

                return BadRequest();


            }
        }

        // GET: api/Urls1/5
        [HttpGet("{id}")]
        public ActionResult<string> GetUrl(Guid id)
        {

            

            var url = _context.dbSetUrl.Where(x => x.Id.Equals(id)).FirstOrDefault();

            if (url == null)
            {
                return NotFound();
            }

            return Redirect(url.longURL);
        }

    }
}
