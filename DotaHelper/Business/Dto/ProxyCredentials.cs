﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Dto
{
    public class ProxyCredentials
    {
        public string UserName { get; set; }

        public string Password { get; set; }

        public int Port { get; set; }

        public string Host { get; set; } 
    }
}
