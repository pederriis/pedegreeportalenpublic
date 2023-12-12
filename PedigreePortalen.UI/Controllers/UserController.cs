using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PedigreePortalen.Shared.AnimalMicroserviceDto.Querys;
using PedigreePortalen.Shared.UserMicroserviceDto.Querys;
using PedigreePortalen.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using static PedigreePortalen.UI.Mapper.AnimalMicroServiceMapper.LitterMapper;
using static PedigreePortalen.UI.Mapper.UserMicroServiceMapper.UserMapper;

namespace PedigreePortalen.UI.Controllers
{
    public class UserController : Controller
    {
        private readonly HttpClient _httpClient;

        public UserController(HttpClient httpClient) 
        {
            _httpClient = httpClient;
        }

        public async Task<IActionResult> Index()
        {
            try
            {
                HttpResponseMessage response = await _httpClient.GetAsync("gateway/getallusers");
                response.EnsureSuccessStatusCode();
                var result = await response.Content.ReadAsStringAsync();
                var userlist = JsonConvert.DeserializeObject<List<UserViewModel.UserCreate>>(result);
                
                return View(userlist);
            }
            catch (Exception)
            {
                ErrorViewModel model = new ErrorViewModel { RequestId = "Kunne ikke finde kunder" };
                return View("Error", model);
            }
        }

        //GET: User/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            try
            {
                UserViewModel.UserDetails user = await GetUserByLoginUserId(id);

                IEnumerable<LitterViewModel.LitterDetails> litterDetails = await GetAllLitterByOwnerId(user.UserId);
                user.Litters = litterDetails.ToList();

                if (user == null)
                {
                    return NotFound();
                }
                return View(user);
            }
            catch (Exception)
            {
                return Redirect("/Identity/Account/Login");
            }
        }

        //Create User is same place as Create LoginUser

        // GET: User/Edit/5
        public async Task<IActionResult> Edit(Guid? id , Guid userId)
        {
            try
            {
                UserViewModel.UserDetails user = new UserViewModel.UserDetails();

                HttpResponseMessage response = await _httpClient.GetAsync($"gateway/User/GetUserByUserId?UserId={userId}");
                response.EnsureSuccessStatusCode();
                var result = await response.Content.ReadAsStringAsync();
                var userDto = JsonConvert.DeserializeObject<UserQuerysDto.UserDetails>(result);

                user.LoginUserId = id.ToString();

                if (userDto == null)
                {
                    return NotFound();
                }
                return View(UserDetailsMapper.Map(userDto));
            }
            catch (Exception)
            {
                ErrorViewModel model = new ErrorViewModel { RequestId = "Kunden kunne ikke rettes" };
                return View("Error", model);
            }
        }

        // POST: User/Edit/5
        [HttpPost]
        public async Task<IActionResult> Edit(Guid? id, [Bind("UserId,FirstName,LastName,Email,PhoneNo,Street,City,Zipcode,ProfileText")] UserViewModel.UserDetails user)
        {
            UserQuerysDto.UserDetails userDto = UserDetailsMapper.Map(user);
            //userDto.UserId = id.Value;

            if (ModelState.IsValid)
            {
                try
                {
                    HttpResponseMessage response = await _httpClient.PutAsJsonAsync
                    ($"gateway/User/UpdateUser?UserId={userDto.UserId}&FirstName={userDto.FirstName}&LastName={userDto.LastName}&Email={userDto.Email}&PhoneNo={userDto.PhoneNo}&Street={userDto.Street}&City={userDto.City}&Zipcode={userDto.Zipcode}&ProfileText={userDto.ProfileText}", userDto);
                    response.EnsureSuccessStatusCode();

                    if (response.IsSuccessStatusCode)
                    {
                        return RedirectToAction("Details", "User", new { id });
                    }
                    else
                    {
                        return View(user);
                    }
                }
                catch (Exception)
                {
                    ErrorViewModel model = new ErrorViewModel { RequestId = "Kunden kunne ikke rettes" };
                    return View("Error", model);
                }
            }
            return View(user);
        }

        //GET: User/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            try
            {
                HttpResponseMessage response = await _httpClient.GetAsync($"gateway/User/GetUserByUserId?UserId={id}");
                response.EnsureSuccessStatusCode();
                var result = await response.Content.ReadAsStringAsync();
                var userDto = JsonConvert.DeserializeObject<UserQuerysDto.UserDetails>(result);

                if (userDto == null)
                {
                    return NotFound();
                }
                return View(UserDetailsMapper.Map(userDto));
            }
            catch (Exception)
            {
                ErrorViewModel model = new ErrorViewModel { RequestId = "Kunden kunne ikke rettes" };
                return View("Error", model);
            }
        }

        // POST: User/Delete/5
        [HttpPost]
        public async Task<IActionResult> Delete(Guid? id, [Bind("UserId")] UserViewModel.UserDetails user)
        {
            UserQuerysDto.UserDetails userDto = UserDetailsMapper.Map(user);
            userDto.UserId = id.Value;

            if (ModelState.IsValid)
            {
                try
                {
                    HttpResponseMessage response = await _httpClient.PutAsJsonAsync
                    ($"gateway/User/DeleteUser?UserId={userDto.UserId}", userDto);
                    response.EnsureSuccessStatusCode();

                    if (response.IsSuccessStatusCode)
                    {
                        return RedirectToAction(nameof(Index));
                    }
                    else
                    {
                        return View(user);
                    }
                }
                catch (Exception)
                {
                    ErrorViewModel model = new ErrorViewModel { RequestId = "Kunden kunne ikke rettes" };
                    return View("Error", model);
                }
            }
            return View(user);
        }

        private async Task<UserViewModel.UserDetails> GetUserByLoginUserId(Guid? id)
        {
            HttpResponseMessage userresponse = await _httpClient.GetAsync($"gateway/User/GetUserByLoginUserId?LoginUserId={id}");
            userresponse.EnsureSuccessStatusCode();
            var userresult = await userresponse.Content.ReadAsStringAsync();
            var userDto = JsonConvert.DeserializeObject<UserQuerysDto.UserDetails>(userresult);
            UserViewModel.UserDetails viewModelUser = UserDetailsAnimalMapper.Map(userDto);

            return viewModelUser;
        }

        private async Task<IEnumerable<LitterViewModel.LitterDetails>> GetAllLitterByOwnerId(Guid id) 
        {
            HttpResponseMessage litterResponse = await _httpClient.GetAsync($"gateway/Litter/GetAllLitterByOwnerId?BreedById={id}");
            litterResponse.EnsureSuccessStatusCode();
            var litterResult = await litterResponse.Content.ReadAsStringAsync();
            var litterDto = JsonConvert.DeserializeObject<List<LitterQuerysDto.LitterDetails>>(litterResult);
            IEnumerable<LitterViewModel.LitterDetails> litterDetails = LitterDetailsMapper.Map(litterDto);

            return litterDetails;
        }
    }
}
