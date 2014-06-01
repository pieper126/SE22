﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SE22
{
    public class User
    {
        public User(string username, string name, string email, List<Rights> functions)
        {
            this.Username = username;
            this.Name = name;
            this.Email = email;
            this.Functions = functions;
        }

        public string Username { get; private set; }

        public string Name { get; private set; }

        public string Email { get; set; }

        public List<Rights> Functions { get; set; }
    }
}