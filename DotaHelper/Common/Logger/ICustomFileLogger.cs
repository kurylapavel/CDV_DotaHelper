﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Logger
{
    public interface ICustomFileLogger
    {
        void Log(Exception ex, string when);
    }
}
