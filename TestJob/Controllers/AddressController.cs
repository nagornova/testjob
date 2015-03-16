using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using TestJob.Models;
using System.Linq.Dynamic;


namespace TestJob.Controllers
{

    public class AddressController : ApiController
    {
        private AddressesEntities db = new AddressesEntities();

 
        [HttpGet]
        public PagedList GetAddresses(string searchtext, string searchtextCity, string searchtextStreet, string searchtextHouse, string searchtextPostCode, string searchtextDate, string searchtextDate2, int page = 1, int pageSize = 10, string sortBy = "ID_address", string sortDirection = "asc")
        {
            
            var pagedRecord = new PagedList();
          
            //DateTime date = DateTime.TryParse(searchtextDate, out date) ? date : DateTime.Today;
            if (searchtextHouse == null)
            {
                searchtextHouse = "1,999";
            }
            string[] house =searchtextHouse.Split(new Char []{','});
              
            int house1= (Int32.TryParse(house[0],out house1)? house1 : 0);
            int house2;
            if (house.Count() == 2)
            {
                house2 = (Int32.TryParse(house[1], out house2) ? house2 : 0);
            }
            else
            {
                house2 = 999;
            }
            //if (searchtextDate == null)
            //{
            //    searchtextDate = "2000-01-01T00:00:00,2015-12-31T00:00:00";
            //}
            //string[] date = searchtextDate.Split(new Char[] { ',' });

            //DateTime date1 = DateTime.TryParse(date[0], out date1) ? date1 : DateTime.Today;
            //DateTime date2 = DateTime.TryParse(date[1], out date2) ? date2 : DateTime.Today;
            DateTime date1 = DateTime.TryParse(searchtextDate, out date1) ? date1 : DateTime.Today;
            DateTime date2 = DateTime.TryParse(searchtextDate2, out date2) ? date2 : DateTime.Today;
            pagedRecord.Content = db.Address
                   .Where(x => (searchtext == null || x.Country.Contains(searchtext)) &&
                          (searchtextCity == null || x.City.Contains(searchtextCity)) &&
                          (searchtextStreet == null || x.Street.Contains(searchtextStreet)) &&
                        (searchtextHouse == null || (x.House >= house1 && x.House <= house2) || (x.House == house1)) &&
                        (searchtextPostCode == null || x.PostCode.Contains(searchtextPostCode)) &&
                        (searchtextDate == null || (x.Date>=date1 && x.Date<=date2))

                        ).OrderBy(sortBy + " " + sortDirection)
                        .Skip((page - 1) * pageSize)
                        .Take(pageSize)
                        .ToList();
           
            // Count
            pagedRecord.TotalRecords = db.Address
                        .Where(x => (searchtext == null || x.Country.Contains(searchtext)) &&
                          (searchtextCity == null || x.City.Contains(searchtextCity)) &&
                          (searchtextStreet == null || x.Street.Contains(searchtextStreet)) &&
                           (searchtextHouse == null || (x.House >= house1 && x.House <= house2)) &&
                            (searchtextPostCode == null || x.PostCode.Contains(searchtextPostCode)) &&
                            (searchtextDate == null || (x.Date >= date1 && x.Date <= date2))
                            ).Count();

            pagedRecord.CurrentPage = page;
            pagedRecord.PageSize = pageSize;

            return pagedRecord;
        }


        // GET api/Address/5
        public Address GetAddress(int id)
        {
            Address address = db.Address.Find(id);
            if (address == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return address;
        }

        // PUT api/Address/5
        public HttpResponseMessage PutAddress(int id, Address address)
        {
            if (ModelState.IsValid && id == address.ID_address)
            {
                db.Entry(address).State = EntityState.Modified;

                try
                {
                    db.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound);
                }

                return Request.CreateResponse(HttpStatusCode.OK);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        // POST api/Address
        public HttpResponseMessage PostAddress(Address address)
        {
            if (ModelState.IsValid)
            {
                db.Address.Add(address);
                db.SaveChanges();

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, address);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = address.ID_address }));
                return response;
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        // DELETE api/Address/5
        public HttpResponseMessage DeleteAddress(int id)
        {
            Address address = db.Address.Find(id);
            if (address == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            db.Address.Remove(address);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            return Request.CreateResponse(HttpStatusCode.OK, address);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}