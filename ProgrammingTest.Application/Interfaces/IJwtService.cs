using ProgrammingTest.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingTest.Application.Interfaces
{
    public interface IJwtService
    {
        Task<string> GenerateToken(User user);
    }
}
