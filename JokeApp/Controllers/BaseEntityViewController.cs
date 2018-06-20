using System;
using JokeApp.Data;
using Microsoft.AspNetCore.Mvc;

namespace JokeApp.Controllers
{
    public abstract class BaseEntityViewApiController : Controller
    {
        private ApplicationDbContext _Entities;
        protected ApplicationDbContext Entities
        {
            get { return _Entities;}
            private set { _Entities = value;}
        }
        public BaseEntityViewApiController(ApplicationDbContext entities)
        {
            this.Entities = entities;
        }
    }
}