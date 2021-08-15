using Domain.Models;
using System.Collections.Generic;

namespace Infra.Mock
{
    public static class UserMock
    {
        public static List<User> GetAll()
        {
            return new List<User>() {
                new User("spiderman", "123", "spiderman@spiderman.com"),
                new User("ironman", "123", "ironman@ironman.com"),
                new User("thor", "123", "thor@thor.com"),
                new User("hulk", "123", "hulk@hulk.com"),
                new User("captainamerica", "123", "captainamerica@captainamerica.com")
            };
        }
    }
}
