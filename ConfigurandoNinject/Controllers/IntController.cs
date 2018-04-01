using ConfigurandoNinject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ConfigurandoNinject.Controllers
{
    public class IntController : ApiController
    {
        private IRepository _repo;

        public IntController(IRepository repo)
        {
            _repo = repo;
        }

        public int GetInt()
        {
            return _repo.GetInt();
        }
    }
}
