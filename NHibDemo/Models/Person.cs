using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NHibDemo.Models
{
    public class Person
    {
        public virtual int Id { get; set; }
        public virtual string FirstName { get; set; }
        public virtual string LastName { get; set; }
        public virtual Address Address { get; set; }
    }
}