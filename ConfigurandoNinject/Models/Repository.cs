using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ConfigurandoNinject.Models
{
    public class Repository : IRepository
    {
        public int GetInt()
        {
            return 20;
        }
    }
}