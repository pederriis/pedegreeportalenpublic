using PedigreePortalen.Shared.UserMicroserviceDto.Querys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace User.Infrastructure.Mappers
{
    public static class UserMapper
    {
        public static class UserDtoMapper
        {
            public static UserQuerysDto.UserDetails Map(Domain.User.User dto)
            {
                if (dto == null)
                { return null; }
                return new UserQuerysDto.UserDetails
                {
                    UserId=dto.UserId,
                    LoginUserId=dto.LoginUserId,
                    FirstName=dto.FirstName,
                    LastName=dto.LastName,
                    Street=dto.Street,
                    PhoneNo=dto.PhoneNo,
                    Email=dto.Email,
                    Zipcode=dto.Zipcode,
                    City=dto.City,
                    ProfileText=dto.ProfileText,
                    IsDeleted = dto.IsDeleted,
                    AnimalDetails=AnimalMapper.AnimalDtoMapper.Map(dto.Animals).ToList()
                    
                };
            }

            public static IEnumerable<UserQuerysDto.UserDetails> Map(IEnumerable<Domain.User.User> model)
            {
                return model.Select(x => Map(x)).AsEnumerable();
            }


        }
    }
}
