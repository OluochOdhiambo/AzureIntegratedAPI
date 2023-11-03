using API.ApplicationCore.DTOs;
using API.ApplicationCore.Exceptions;
using API.Infrastructure.Persistence.Contexts;
using AutoMapper;
using API.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using API.ApplicationCore.Entities;
using API.ApplicationCore;

namespace API.Infrastructure.Persistence.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly APIContext _context;
        private readonly IMapper _mapper;

        public UserRepository(APIContext context, IMapper mapper)
        {
            this._mapper = mapper;
            this._context = context;
        }

        public UserResponse CreateUser(CreateUserRequest request)
        {
            var user = this._mapper.Map<User>(request);
            user.Name = request.Name;
            user.CreatedAt = user.UpdatedAt = DateUtil.GetCurrentDate();

            this._context.Users.Add(user);
            this._context.SaveChanges();

            return _mapper.Map<UserResponse>(user);
        }

        public void DeleteUserById(Guid uid)
        {
            var user = this._context.Users.Find(uid);
            if (user != null)
            {
                this._context.Users.Remove(user);
                this._context.SaveChanges();
            }
            else
            {
                throw new NotFoundException();
            }
        }

        public UserResponse GetUserById(Guid uid)
        {
            var user = this._context.Users.Find(uid);
            if (user != null)
            {
                return this._mapper.Map<UserResponse>(user);
            }
            throw new NotFoundException();
        }

        public List<UserResponse> GetUsers()
        {
            return this._context.Users.Select(o => _mapper.Map<UserResponse>(o)).ToList(); ;
        }

        public UserResponse UpdateUser(Guid uid, UpdateUserRequest request)
        {
            var user = this._context.Users.Find(uid);
            if (user != null) 
            { 
                user.Name = request.Name;
                user.UpdatedAt = DateUtil.GetCurrentDate();

                this._context.Users.Update(user);
                this._context.SaveChanges();

                return _mapper.Map<UserResponse>(user);
            }

            throw new NotFoundException();
        }
    }
}
