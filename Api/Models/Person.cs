
using Api.Mappings;
using Application.Base;
using Domain.Interface;
using Domain.Interface.Domain.Interface;
using Infrastructure.Context;
using Infrastructure.Interface;
using Infrastructure.Repository;
using Infrastructure.UOW;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using UserEntity = Domain.Entities.User;
using PersonEntity = Domain.Entities.Person;


namespace Api.Models
{
   
    public class Person 
    {


        private readonly Service<PersonEntity> _service;
        private readonly IDbContext _context;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<PersonEntity> _repository;

        public Person()
        {
            _context = new PruebaContext();
            _unitOfWork = new UnitOfWork(_context);
            _repository = new GeneryRepository<PersonEntity>(_context);
            _service = new Service<PersonEntity>(_unitOfWork, _repository);
        }


        public int Id { set; get; }

        [Required]
        [MaxLength(20)]
        [MinLength(2)]
        public string FirstName { set; get; }

        [MaxLength(20)]
        [MinLength(2)]
        public string SecondName { set; get; }

       
        [Required]
        [MaxLength(20)]
        [MinLength(2)]
        public string FirstLastName { set; get; }


        [MaxLength(20)]
        [MinLength(2)]
        public string SecondLastName { set; get; }

        [Required]
        public int UserId { set; get; }

        public User User { set; get; }

        public Person Get(Person person)
        {
            return Mapping.ConvertEntityModel(_repository.FindBy(x => x.UserId == person.UserId, includeProperties: nameof(UserEntity)).FirstOrDefault());
        }

        public Person Get(int id)
        {
            return Mapping.ConvertEntityModel(_service.Find(id));
        }

        public Person Create(Person user)
        {
            return Mapping.ConvertEntityModel(_service.Create(Mapping.ConvertModelEntity(user)));
        }

        public IEnumerable<object> GetAll(int pageIndex = 0, int pageSize = int.MaxValue)
        {
            return _service.GetAll(pageIndex, pageSize, "User");
        }

    }
}
