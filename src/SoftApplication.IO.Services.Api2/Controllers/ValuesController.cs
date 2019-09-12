using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

using SoftApplication.IO.Domain.Core.Notificatios;
using SoftApplication.IO.Domain.Interfaces;
using SoftApplication.IO.Services.Api2.Controllers;
using SoftApplication.IO.Services.Api2.ViewModels;

namespace SoftApplication.IO.Services.Api2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {

        //private readonly IDomainNotificationHandler<DomainNotification> _Notifications;
        //private readonly IMediatorHandler _Mediator;
        //private readonly IMapper _Mapper;

        //public ValuesController(IDomainNotificationHandler<DomainNotification> pNotifications,
        //                         IMapper pMapper,
        //                         IMediatorHandler pMediator) : base(pNotifications, pMediator)
        //{
        //    _Notifications = pNotifications;
        //    _Mapper = pMapper;
        //    _Mediator = pMediator;
        //}

        //[HttpGet]
        //[Route("eventos")]
        ////[AllowAnonymous]
        //public IEnumerable<EventoViewModel> Get()
        //{
        //    return null;
        //}


        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
