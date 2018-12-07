using System;
using System.Collections.Generic;
using System.Text;
using Xamfire.Tests.Common.Models;

namespace Xamfire.Tests.Integration.Samples
{
    public static class Users
    {
        public static User GetUser()
        {
            return new User
            {
                Id = new Guid("16bbfa0a-8c41-4917-9931-fa770af1b409"),
                Name = "Janusz",
                Products = Products.SamplesProducts
            };
        }
    }
}
