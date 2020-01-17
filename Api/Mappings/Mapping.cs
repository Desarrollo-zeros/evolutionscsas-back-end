using Api.Models;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserEntity = Domain.Entities.User;
using UserModel = Api.Models.User;

using PersonEntity = Domain.Entities.Person;
using PersonModel = Api.Models.Person;

namespace Api.Mappings
{
    public static class Mapping
    {

        public static UserEntity ConvertModelEntity(UserModel user)
        {
            if (user == null) return null;
            return new UserEntity
            {
                Username = user.Username,
                Password = user.Password,
                State = (State)user.State,
            };
        }

        public static UserModel ConvertEntityModel(UserEntity user)
        {
            if (user == null) return null; 

            return new UserModel
            {
                Username = user.Username,
                Password = user.Password,
                State = (int)user.State,
            };
        }

        public static PersonEntity ConvertModelEntity(PersonModel person)
        {
            if (person == null) return null;
            return new PersonEntity
            {
                FirstLastName = person.FirstLastName,
                FirstName = person.FirstName,
                SecondLastName = person.SecondLastName,
                SecondName = person.SecondName,
                UserId = person.UserId
            };
        }

        public static PersonModel ConvertEntityModel(PersonEntity person)
        {
            if (person == null) return null;
            return new PersonModel
            {
                FirstLastName = person.FirstLastName,
                FirstName = person.FirstName,
                SecondLastName = person.SecondLastName,
                SecondName = person.SecondName,
                UserId = person.UserId
            };
        }

    }
}
