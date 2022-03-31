﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Core.DesignPatterns.Observer
{
    public class UserObserver : IUserObserver
    {
        public string Email { get; set; }
        public UserObserver(string email)
        {
            Email = email;
        }
        public void Notify(Book book)
        {
            Console.WriteLine($"sending email to {Email} about {book.Title}");
        }
    }
}