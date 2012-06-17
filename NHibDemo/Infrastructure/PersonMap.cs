using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FluentNHibernate.Mapping;
using NHibDemo.Models;

namespace NHibDemo.Infrastructure
{
    public class PersonMap : ClassMap<Person>
    {
        public PersonMap()
        {
            Id(x => x.Id);
            Map(x => x.FirstName);
            Map(x => x.LastName);
            References(x => x.Address);
        }
    }

    public class AddressMap : ClassMap<Address>
    {
        public AddressMap()
        {
            Id(x => x.Id);
            Map(x => x.City);
            Map(x => x.ZipCode);
            Map(x => x.Street);
        }
    }
}