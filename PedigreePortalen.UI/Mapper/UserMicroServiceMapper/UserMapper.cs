using PedigreePortalen.Shared.UserMicroserviceDto.Commands;
using PedigreePortalen.Shared.UserMicroserviceDto.Querys;
using PedigreePortalen.UI.Models;
using System.Collections.Generic;
using System.Linq;
using static PedigreePortalen.UI.Mapper.AnimalMicroServiceMapper.LitterMapper;
using static PedigreePortalen.UI.Mapper.UserMicroServiceMapper.AnimalMapper;

namespace PedigreePortalen.UI.Mapper.UserMicroServiceMapper
{
    public static class UserMapper
    {
        public class UserCreateMapper 
        {
            public static UserViewModel.UserCreate Map(UserCommandsDto.V1.CreateUser dto)
            {
                if (dto == null)
                { return null; }
                return new UserViewModel.UserCreate
                {
                    UserId = dto.UserId,
                    LoginUserId = dto.LoginUserId,
                    FirstName = dto.FirstName,
                    LastName = dto.LastName,
                    Email = dto.Email,
                    PhoneNo = dto.PhoneNo,
                    Street = dto.Street,
                    City = dto.City,
                    Zipcode = dto.Zipcode,
                    ProfileText = dto.ProfileText
                };
            }

            public static IEnumerable<UserViewModel.UserCreate> Map(IEnumerable<UserCommandsDto.V1.CreateUser> model)
            {
                return model.Select(x => Map(x)).AsEnumerable();
            }

            public static IEnumerable<UserCommandsDto.V1.CreateUser> Map(IEnumerable<UserViewModel.UserCreate> model)
            {
                return model.Select(x => Map(x)).AsEnumerable();
            }

            public static UserCommandsDto.V1.CreateUser Map(UserViewModel.UserCreate model)
            {
                if (model == null)
                { return null; }
                return new UserCommandsDto.V1.CreateUser
                {
                    UserId = model.UserId,
                    LoginUserId = model.LoginUserId,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Email = model.Email,
                    PhoneNo = model.PhoneNo,
                    Street = model.Street,
                    City = model.City,
                    Zipcode = model.Zipcode,
                    ProfileText = model.ProfileText
                };
            }
        }

        public class UserDetailsAnimalMapper
        {
            public static UserViewModel.UserDetails Map(UserQuerysDto.UserDetails dto)
            {
                if (dto == null)
                { return null; }
                return new UserViewModel.UserDetails
                {
                    UserId = dto.UserId,
                    LoginUserId = dto.LoginUserId,
                    FirstName = dto.FirstName,
                    LastName = dto.LastName,
                    Email = dto.Email,
                    PhoneNo = dto.PhoneNo,
                    Street = dto.Street,
                    City = dto.City,
                    Zipcode = dto.Zipcode,
                    ProfileText = dto.ProfileText,
                    Animals = AnimalDetailsMapper.Map(dto.AnimalDetails).ToList(),
                    //Litters = LitterDetailsMapper.Map(dto.Litters).ToList()
                };
            }

            public static IEnumerable<UserViewModel.UserDetails> Map(IEnumerable<UserQuerysDto.UserDetails> model)
            {
                return model.Select(x => Map(x)).AsEnumerable();
            }

            public static IEnumerable<UserQuerysDto.UserDetails> Map(IEnumerable<UserViewModel.UserDetails> model)
            {
                return model.Select(x => Map(x)).AsEnumerable();
            }

            public static UserQuerysDto.UserDetails Map(UserViewModel.UserDetails model)
            {
                if (model == null)
                { return null; }
                return new UserQuerysDto.UserDetails
                {
                    UserId = model.UserId,
                    LoginUserId = model.LoginUserId,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Email = model.Email,
                    PhoneNo = model.PhoneNo,
                    Street = model.Street,
                    City = model.City,
                    Zipcode = model.Zipcode,
                    ProfileText = model.ProfileText,
                    AnimalDetails = AnimalDetailsMapper.Map(model.Animals).ToList(),
                    //Litters = LitterDetailsMapper.Map(model.Litters).ToList()
                };
            }
        }

        public class UserDetailsMapper
        {
            public static UserViewModel.UserDetails Map(UserQuerysDto.UserDetails dto)
            {
                if (dto == null)
                { return null; }
                return new UserViewModel.UserDetails
                {
                    UserId = dto.UserId,
                    LoginUserId = dto.LoginUserId,
                    FirstName = dto.FirstName,
                    LastName = dto.LastName,
                    Email = dto.Email,
                    PhoneNo = dto.PhoneNo,
                    Street = dto.Street,
                    City = dto.City,
                    Zipcode = dto.Zipcode,
                    ProfileText = dto.ProfileText
                };
            }

            public static IEnumerable<UserViewModel.UserDetails> Map(IEnumerable<UserQuerysDto.UserDetails> model)
            {
                return model.Select(x => Map(x)).AsEnumerable();
            }

            public static IEnumerable<UserQuerysDto.UserDetails> Map(IEnumerable<UserViewModel.UserDetails> model)
            {
                return model.Select(x => Map(x)).AsEnumerable();
            }

            public static UserQuerysDto.UserDetails Map(UserViewModel.UserDetails model)
            {
                if (model == null)
                { return null; }
                return new UserQuerysDto.UserDetails
                {
                    UserId = model.UserId,
                    LoginUserId = model.LoginUserId,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Email = model.Email,
                    PhoneNo = model.PhoneNo,
                    Street = model.Street,
                    City = model.City,
                    Zipcode = model.Zipcode,
                    ProfileText = model.ProfileText
                };
            }
        }
    }
}
