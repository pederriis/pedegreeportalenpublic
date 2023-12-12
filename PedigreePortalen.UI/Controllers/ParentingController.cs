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
using static PedigreePortalen.UI.Mapper.AnimalMicroServiceMapper.ParentingMapper;
using static PedigreePortalen.UI.Mapper.UserMicroServiceMapper.UserMapper;

namespace PedigreePortalen.UI.Controllers
{
    public class ParentingController : Controller
    {
        private readonly HttpClient _httpClient;

        public ParentingController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public IActionResult Index()
        {
            return View();
        }

        //GET: Parenting/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            try
            {
                HttpResponseMessage Response = await _httpClient.GetAsync($"gateway/Parentings/GetAllParentingsByAnimalId?AnimalId={id}");
                Response.EnsureSuccessStatusCode();
                var result = await Response.Content.ReadAsStringAsync();
                var parentingDto = JsonConvert.DeserializeObject<ParentingQuerysDto.ParentingDetails>(result);

                return View(ParentingDetailsMapper.Map(parentingDto));
            }
            catch (Exception)
            {
                ErrorViewModel model = new ErrorViewModel { RequestId = "Kundens detajler kunne ikke vises" };
                return View("Error", model);
            }
        }

        // GET: Parenting/AddParentingToLitter
        public async Task<IActionResult> AddParentingToLitter(Guid id,Guid AnimalId)
        {
            try
            {
                ParentingViewModel.AddParentingToLitter parenting = new ParentingViewModel.AddParentingToLitter();

                UserViewModel.UserDetails user = await GetUserByLoginUserId(id);

                AnimalViewModel.DetailsAnimal animal = await GetSingleAnimalByAnimalId(AnimalId);
                parenting.AnimalId = animal.AnimalId;

                IEnumerable<LitterViewModel.LitterDetails> litter = await GetAllLitterByOwnerId(user.UserId);
                parenting.Litters = litter.ToList();

                return View(parenting);
            }
            catch (Exception)
            {
                ErrorViewModel model = new ErrorViewModel { RequestId = "Kunne ikke finde kunder" };
                return View("Error", model);
            }
        }

        // POST: Parenting/AddParentingToLitter
        [HttpPost]
        public async Task<IActionResult> AddParentingToLitter([Bind("ParentingId,AnimalId,LitterId")] ParentingViewModel.AddParentingToLitter parenting, Guid id)
        {
            ParentingCommandsDto.V1.CreateParenting parentingDto = AddParentingToLitterMapper.Map(parenting);

            if (ModelState.IsValid)
            {
                try
                {
                    parentingDto.ParentingId = Guid.NewGuid();
                    HttpResponseMessage response = await _httpClient.PostAsJsonAsync
                        ($"gateway/Parenting/CreateParenting?ParentingId={parentingDto.ParentingId}&AnimalId={parentingDto.AnimalId}&LitterId={parentingDto.LitterId}", parentingDto);
                    response.EnsureSuccessStatusCode();

                    if (response.IsSuccessStatusCode)
                    {
                        id = parentingDto.AnimalId;
                        return RedirectToAction("Details", "Animal", new { id });
                    }
                    else
                    {
                        return View(parenting);
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

        // GET: Customer/Create
        public async Task<IActionResult> Create(Guid id)
        {
            try
            {
                ParentingViewModel.CreateParenting parenting = new ParentingViewModel.CreateParenting();
                parenting.LitterId = id;

                IEnumerable<AnimalViewModel.DetailsAnimal> animals = await GetAllParentingAnimals();
                parenting.Animals = animals.ToList();

                return View(parenting);
            }
            catch (Exception)
            {
                ErrorViewModel model = new ErrorViewModel { RequestId = "Kunne ikke finde kunder" };
                return View("Error", model);
            }
        }

        // POST: Parenting/Create
        [HttpPost]
        public async Task<IActionResult> Create([Bind("ParentingId,AnimalId,LitterId")] ParentingViewModel.CreateParenting parenting, Guid id)
        {
            ParentingCommandsDto.V1.CreateParenting parentingDto = CreateParentingMapper.Map(parenting);
            if (ModelState.IsValid)
            {
                try
                {
                    parentingDto.ParentingId = Guid.NewGuid();
                    HttpResponseMessage response = await _httpClient.PostAsJsonAsync
                        ($"gateway/Parenting/CreateParenting?ParentingId={parentingDto.ParentingId}&AnimalId={parentingDto.AnimalId}&LitterId={parentingDto.LitterId}", parentingDto);
                    response.EnsureSuccessStatusCode();

                    if (response.IsSuccessStatusCode)
                    {
                        return RedirectToAction("Details", "Litter", new { id });
                    }
                    else
                    {
                        return View(parenting);
                    }
                }
                catch (Exception)
                {
                    ErrorViewModel model = new ErrorViewModel { RequestId = "Kunne ikke finde kunder" };
                    return View("Error", model);
                }
            }
            return RedirectToAction("Details", "Litter", new { id });
        }

        private async Task<UserViewModel.UserDetails> GetUserByLoginUserId(Guid? id)
        {
            HttpResponseMessage userresponse = await _httpClient.GetAsync($"gateway/User/GetUserByLoginUserId?LoginUserId={id}");
            userresponse.EnsureSuccessStatusCode();
            var userresult = await userresponse.Content.ReadAsStringAsync();
            var userDto = JsonConvert.DeserializeObject<UserQuerysDto.UserDetails>(userresult);
            UserViewModel.UserDetails viewModelUser = UserDetailsMapper.Map(userDto);

            return viewModelUser;
        }

        private async Task<AnimalViewModel.DetailsAnimal> GetSingleAnimalByAnimalId(Guid id)
        {
            HttpResponseMessage animalResponse = await _httpClient.GetAsync($"gateway/Animal/GetSingleAnimalByAnimalId?AnimalId={id}");
            animalResponse.EnsureSuccessStatusCode();
            var animalResult = await animalResponse.Content.ReadAsStringAsync();
            var animalDto = JsonConvert.DeserializeObject<AnimalQuerysDto.AnimalDetails>(animalResult);
            AnimalViewModel.DetailsAnimal animal = AnimalDetailsMapper.Map(animalDto);

            return animal;
        }

        private async Task<IEnumerable<LitterViewModel.LitterDetails>> GetAllLitterByOwnerId(Guid id) 
        {
            HttpResponseMessage response = await _httpClient.GetAsync($"gateway/Litter/GetAllLitterByOwnerId?BreedById={id}");
            response.EnsureSuccessStatusCode();
            var result = await response.Content.ReadAsStringAsync();
            var LitterDto = JsonConvert.DeserializeObject<List<LitterQuerysDto.LitterDetails>>(result);
            IEnumerable<LitterViewModel.LitterDetails> litter = LitterDetailsMapper.Map(LitterDto);

            return litter;
        }

        private async Task<IEnumerable<AnimalViewModel.DetailsAnimal>> GetAllParentingAnimals() 
        {
            HttpResponseMessage animalResponse = await _httpClient.GetAsync($"gateway/GetAllParentingAnimals");
            animalResponse.EnsureSuccessStatusCode();
            var animalResult = await animalResponse.Content.ReadAsStringAsync();
            var animalDto = JsonConvert.DeserializeObject<List<AnimalQuerysDto.AnimalDetails>>(animalResult);
            IEnumerable<AnimalViewModel.DetailsAnimal> animals = AnimalDetailsMapper.Map(animalDto);

            return animals;
        }
    }
}
