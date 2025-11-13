using ProgrammingTest.Application.DTOs.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingTest.Application.Interfaces
{
    public interface IUserServiceClient
    {
        Task<UserDTO> GetUserByIdAsync(Guid userId);
    }
}
