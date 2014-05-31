using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SE22
{
    public class User
    {
        public string Username { get; private set; }

        public string Name { get; private set; }

        public string Email { get; set; }

        public List<Rights> Function { get; set; }
    }
}