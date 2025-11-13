//using Microsoft.AspNetCore.Http;
//using ProgrammingTest.Application.Interfaces;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Security.Claims;

//namespace ProgrammingTest.Infrastructure.Identity
//{
//    public class CurrentUserService : ICurrentUserService
//    {
//        private readonly IHttpContextAccessor _httpContextAccessor;

//        public CurrentUserService(IHttpContextAccessor httpContextAccessor)
//        {
//            _httpContextAccessor = httpContextAccessor;
//        }

//        public string? UserId =>
//            _httpContextAccessor.HttpContext?.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value;
//    }
//}
