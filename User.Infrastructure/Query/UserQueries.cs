using Microsoft.EntityFrameworkCore;
using User.Infrastructure.Shared;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static PedigreePortalen.Shared.UserMicroserviceDto.Querys.UserQuerysDto;
using PedigreePortalen.Shared.UserMicroserviceDto.Querys;
using User.Infrastructure.Mappers;

namespace User.Infrastructure.Query
{
    public class UserQueries
    {
        private readonly UserDbContext _context;

        public UserQueries(UserDbContext userDbContext)
        {
            _context = userDbContext;
        }

        public async Task<List<UserDetails>> GetAllUsers()
        {
            var users = await _context.Users
               
               .Include(u=>u.Animals)
                .AsNoTracking()
                .Where(u=>u.IsDeleted.Value==false)
                .ToListAsync();

            return UserMapper.UserDtoMapper.Map(users).ToList();
           
        }


        public async Task<UserDetails> GetUserByUserId(QueryModels.UserQueryModels.GetUserByUserId query)
        {
           var user= await _context.Users.AsNoTracking()
                .Where(x => x.UserId == query.UserId && x.IsDeleted.Value == false)
                .Include(u=>u.Animals)
                .FirstOrDefaultAsync();

            return UserMapper.UserDtoMapper.Map(user);
        }
        public async Task<UserDetails> GetUserByLoginUserId(QueryModels.UserQueryModels.GetUserByLoginUserId query)
        {
          var user=await _context.Users.AsNoTracking()
                .Where(x => x.LoginUserId.Value == query.LoginUserId && x.IsDeleted.Value == false)
                .Include(u=>u.Animals)
                .FirstOrDefaultAsync();

            return UserMapper.UserDtoMapper.Map(user);
        }
    }
}
//    return await _context.Users.AsNoTracking()
//        .Where(x => x.IsDeleted.Value == false)
//        .Select(x => new UserDetails
//        {
//            UserId = x.UserId,
//            LoginUserId = x.LoginUserId,
//            FirstName = x.FirstName,
//            LastName = x.LastName,
//            Email = x.Email,
//            PhoneNo = x.PhoneNo,
//            Street = x.Street.Value,
//            City = x.City.Value,
//            Zipcode = x.Zipcode,
//            ProfileText = x.ProfileText,

//            AnimalDetails = x.Animals.Select(x => new AnimalQuriesDto.AnimalDetails
//            {
//                AnimalId = x.AnimalId,
//                UserId = x.UserId,
//                Name = x.Name,
//                IsDeleted = x.IsDeleted
//            }).ToList()
//        })
//         .ToListAsync();
//}

//public async Task<UserDetails> GetUserByUserId(QueryModels.UserQueryModels.GetUserByUserId query)
//{
//    var user = await _context.Users
//         .FirstOrDefault(u => u.UserId == query.UserId)

//public async Task<UserDetails> GetUserByUserId(QueryModels.UserQueryModels.GetUserByUserId query)
//{
//    return await _context.Users.AsNoTracking()
//        .Where(x => x.UserId == query.UserId && x.IsDeleted.Value == false)
//        .Select(x => new UserDetails
//        {
//            UserId = x.Id.Value,
//            LoginUserId = x.LoginUserId,
//            FirstName = x.FirstName.Value,
//            LastName = x.LastName.Value,
//            Email = x.Email.Value,
//            PhoneNo = x.PhoneNo.Value,
//            Street = x.Street.Value,
//            City = x.City.Value,
//            Zipcode = x.Zipcode.Value,
//            ProfileText = x.ProfileText.Value,
//            IsDeleted = x.IsDeleted.Value,

//            AnimalDetails = x.Animals.Select(x => new AnimalQuriesDto.AnimalDetails
//            {
//                AnimalId = x.AnimalId,
//                UserId = x.UserId,
//                Name = x.Name,
//                IsDeleted = x.IsDeleted
//            }).ToList()
//        })
//        .FirstOrDefaultAsync();
//}

//public async Task<UserDetails> GetUserByLoginUserId(QueryModels.UserQueryModels.GetUserByLoginUserId query)
//{
//    return await _context.Users.AsNoTracking()
//        .Where(x => x.LoginUserId.Value == query.LoginUserId && x.IsDeleted.Value == false)
//        .Select(x => new UserDetails
//        {
//            UserId = x.Id.Value,
//            LoginUserId = x.LoginUserId,
//            FirstName = x.FirstName.Value,
//            LastName = x.LastName.Value,
//            Email = x.Email.Value,
//            PhoneNo = x.PhoneNo.Value,
//            Street = x.Street.Value,
//            City = x.City.Value,
//            Zipcode = x.Zipcode.Value,
//            ProfileText = x.ProfileText.Value,
//            IsDeleted = x.IsDeleted.Value,

//            AnimalDetails = x.Animals.Select(x => new AnimalQuriesDto.AnimalDetails
//            {
//                AnimalId = x.AnimalId,
//                UserId = x.UserId,
//                Name = x.Name,
//                IsDeleted = x.IsDeleted
//            }).ToList()
//        })
//        .FirstOrDefaultAsync();
//}