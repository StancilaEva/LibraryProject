﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainApp
{
    internal class NonExistentUserException : Exception
    {
        public NonExistentUserException(string? message) : base(message)
        {
        }
    }
}