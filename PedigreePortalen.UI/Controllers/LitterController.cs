using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PedigreePortalen.Shared.AnimalMicroserviceDto.Commands;
using PedigreePortalen.Shared.AnimalMicroserviceDto.Querys;
using PedigreePortalen.Shared.UserMicroserviceDto.Querys;
using PedigreePortalen.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using static PedigreePortalen.UI.Mapper.AnimalMicroServiceMapper.AnimalMapper;
using static PedigreePortalen.UI.Mapper.AnimalMicroServiceMapper.LitterMapper;
using static PedigreePortalen.UI.Mapper.UserMicroServiceMapper.UserMapper;

namespace PedigreePortalen.UI.Controllers
{
    public class LitterController : Controller
    {
        private readonly HttpClient _httpClient;

        public LitterController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        //GET: Litter/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            try
            {
                LitterViewModel.LitterDetails litter = new LitterViewModel.LitterDetails();

                HttpResponseMessage Response = await _httpClient.GetAsync($"gateway/Litter/GetLitterById?LitterId={id.Value}");
                Response.EnsureSuccessStatusCode();
                var result = await Response.Content.ReadAsStringAsync();
                var litterDto = JsonConvert.DeserializeObject<LitterQuerysDto.LitterDetails>(result);
                litter = LitterAnimalParentingDetailsMapper.Map(litterDto);

                return View(litter);
            }
            catch (Exception)
            {
                ErrorViewModel model = new ErrorViewModel { RequestId = "Kundens detajler kunne ikke vises" };
                return View("Error", model);
            }
        }

        // GET: Litter/Create
        public async Task<IActionResult> Create(Guid? id)
        {
            try
            {
                LitterViewModel.CreateLitter litter = new LitterViewModel.CreateLitter();

                HttpResponseMessage response = await _httpClient.GetAsync($"gateway/User/GetUserByLoginUserId?LoginUserId={id}");
                response.EnsureSuccessStatusCode();
                var result = await response.Content.ReadAsStringAsync();
                var userDto = JsonConvert.DeserializeObject<UserQuerysDto.UserDetails>(result);
                UserViewModel.UserDetails viewModelUser = UserDetailsMapper.Map(userDto);

                litter.BreedById = viewModelUser.UserId;

                return View(litter);
            }
            catch (Exception)
            {
                ErrorViewModel model = new ErrorViewModel { RequestId = "Kunne ikke finde kunder" };
                return View("Error", model);
            }
        }

        // POST: Litter/Create
        [HttpPost]
        public async Task<IActionResult> Create([Bind("LitterId,BreedById,LitterName,LitterBirthDate,MatingDate")] LitterViewModel.CreateLitter litter, Guid id)
        {
            LitterCommandsDto.V1.CreateLitter litterDto = LitterCreateMapper.Map(litter);

            if (ModelState.IsValid)
            {
                try
                {
                    litterDto.LitterId = Guid.NewGuid();
                    HttpResponseMessage response = await _httpClient.PostAsJsonAsync
                        ($"gateway/Litter/CreateLitter?LitterId={litterDto.LitterId}&BreedById={litterDto.BreedById}&LitterName={litterDto.LitterName}&LitterBirthDate={litterDto.LitterBirthDate}&MatingDate={litterDto.MatingDate}", litterDto);
                    response.EnsureSuccessStatusCode();

                    if (response.IsSuccessStatusCode)
                    {
                        return RedirectToAction("Details", "User", new { id });
                    }
                    else
                    {
                        return View(litter);
                    }
                }
                catch (Exception)
                {
                    ErrorViewModel model = new ErrorViewModel { RequestId = "Kunne ikke finde kunder" };
                    return View("Error", model);
                }
            }
            return RedirectToAction("Details", "User", new { id });
        }

        // GET: Litter/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            try
            {
                LitterViewModel.LitterDetails litter = new LitterViewModel.LitterDetails();

                HttpResponseMessage Response = await _httpClient.GetAsync($"gateway/Litter/GetLitterById?LitterId={id.Value}");
                Response.EnsureSuccessStatusCode();
                var result = await Response.Content.ReadAsStringAsync();
                var litterDto = JsonConvert.DeserializeObject<LitterQuerysDto.LitterDetails>(result);

                litter = LitterDetailsMapper.Map(litterDto);

                return View(litter);
            }
            catch (Exception)
            {
                ErrorViewModel model = new ErrorViewModel { RequestId = "Kunden kunne ikke rettes" };
                return View("Error", model);
            }
        }

        // POST: Litter/Edit/5
        [HttpPost]
        public async Task<IActionResult> Edit(Guid? id, [Bind("LitterId,BreedById,LitterName,LitterBirthDate,MatingDate")] LitterViewModel.LitterDetails litter)
        {
            LitterQuerysDto.LitterDetails litterDto = LitterDetailsMapper.Map(litter);
            litterDto.LitterId = id.Value;

            if (ModelState.IsValid)
            {
                try
                {
                    HttpResponseMessage response = await _httpClient.PutAsJsonAsync
                    ($"gateway/Litter/UpdateLitter?LitterId={litterDto.LitterId}&LitterName={litterDto.LitterName}&LitterBirthDate={litterDto.LitterBirthDate}&MatingDate={litterDto.MatingDate}", litterDto);
                    response.EnsureSuccessStatusCode();

                    if (response.IsSuccessStatusCode)
                    {
                        return RedirectToAction("Details", new { id });
                    }
                    else
                    {
                        return View(litter);
                    }
                }
                catch (Exception)
                {
                    ErrorViewModel model = new ErrorViewModel { RequestId = "Kunden kunne ikke rettes" };
                    return View("Error", model);
                }
            }
            return RedirectToAction("Details", new { id });
        }

        // GET: Litter/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            try
            {
                LitterViewModel.LitterDetails litter = new LitterViewModel.LitterDetails();

                HttpResponseMessage Response = await _httpClient.GetAsync($"gateway/Litter/GetLitterById?LitterId={id.Value}");
                Response.EnsureSuccessStatusCode();
                var result = await Response.Content.ReadAsStringAsync();
                var litterDto = JsonConvert.DeserializeObject<LitterQuerysDto.LitterDetails>(result);
                litter = LitterDetailsMapper.Map(litterDto);

                return View(litter);
            }
            catch (Exception)
            {
                ErrorViewModel model = new ErrorViewModel { RequestId = "Kunden kunne ikke rettes" };
                return View("Error", model);
            }
        }

        // POST: Litter/Delete/5
        [HttpPost]
        public async Task<IActionResult> Delete(Guid? id, [Bind("LitterId")] LitterViewModel.LitterDetails litter)
        {
            LitterQuerysDto.LitterDetails litterDto = LitterDetailsMapper.Map(litter);
            
            if (ModelState.IsValid)
            {
                try
                {
                    HttpResponseMessage response = await _httpClient.PutAsJsonAsync
                    ($"gateway/Litter/DeleteLitter?LitterId={litterDto.LitterId}", litterDto);
                    response.EnsureSuccessStatusCode();

                    if (response.IsSuccessStatusCode)
                    {
                        return RedirectToAction("Details", "User", new { id });
                    }
                    else
                    {
                        return View(litter);
                    }
                }
                catch (Exception)
                {
                    ErrorViewModel model = new ErrorViewModel { RequestId = "Kunden kunne ikke rettes" };
                    return View("Error", model);
                }
            }
            return View(litter);
        }
    }
}
