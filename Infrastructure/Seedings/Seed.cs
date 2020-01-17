using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Seedings
{
    public static class Seed
    {
        public static User[] users = new User[]
        {
            new User{ Id = 1,Username = "zeros", Password = new PasswordHasher().HashPassword("toor"), State = State.Activo},
            new User{Id = 2, Username = "test", Password = new PasswordHasher().HashPassword("test"), State = State.Activo},
        };

        public static Person[] persons = new Person[]
        {
            new Person
            {
                Id = 1,
                FirstName = "Carlos",
                FirstLastName = "Andrés",
                SecondName = "Castilla",
                SecondLastName = "García",
                UserId = 1,
            },

            new Person
            {
                Id = 2,
                FirstName = "Test",
                FirstLastName = "Test",
                SecondName = "Test",
                SecondLastName = "Test",
                UserId = 2,
            },
        };
    }
}
