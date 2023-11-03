using API.ApplicationCore.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.ApplicationCore.Interfaces
{
    public interface IUserRepository
    {
        List<UserResponse> GetUsers();

        UserResponse GetUserById(Guid uid);

        void DeleteUserById(Guid uid);

        UserResponse CreateUser(CreateUserRequest request);

        UserResponse UpdateUser(Guid uid, UpdateUserRequest request); 
    }
}
