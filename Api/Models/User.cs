
using Api.Mappings;
using Application.Services;
using Domain.Interface;
using Domain.Interface.Domain.Interface;
using Infrastructure.Context;
using Infrastructure.Interface;
using Infrastructure.Repository;
using Infrastructure.UOW;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using UserEntity = Domain.Entities.User;

namespace Api.Models
{
   
    public class User 
    {
        private readonly UserService _userService;
        private readonly IDbContext _context;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<UserEntity> _repository;

        public User()
        {
            _context = new PruebaContext();
            _unitOfWork = new UnitOfWork(_context);
            _repository = new GeneryRepository<UserEntity>(_context);
            _userService = new UserService(_unitOfWork, _repository);
        }

        public int Id { set; get; }

        [Required]
        [MaxLength(20)]
        [MinLength(4)]
        public string Username { set; get; }

        [Required]
        [MaxLength(20)]
        [MinLength(4)]
       
        public string Password { set; get; }

        [Required]
        [DefaultValue(0)]
        public int State { set; get; }

        public string Token { set; get; }


        public User Get(User user)
        {
            return Mapping.ConvertEntityModel(_userService.GetUser(Mapping.ConvertModelEntity(user)));
        }

        public User Get(int id)
        {
            return Mapping.ConvertEntityModel(_userService.Find(id));
        }

        public User Create(User user)
        {
            return Mapping.ConvertEntityModel(_userService.Create(Mapping.ConvertModelEntity(user)));
        }

        public IEnumerable<User> GetAll(int pageIndex = 0, int pageSize = int.MaxValue)
        {

            IEnumerable<User> users = new List<User>();

            _userService.GetAll(pageIndex, pageSize).ToList().ForEach(x => {
                users.ToList().Add(Mapping.ConvertEntityModel(x));
            });

            return users;
        }


        
    }
}
