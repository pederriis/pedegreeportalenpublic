using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using PedigreePortalen.Shared.AnimalMicroserviceDto.Commands;
using PedigreePortalen.Shared.AnimalMicroserviceDto.Querys;
using PedigreePortalen.Shared.UserMicroserviceDto.Querys;
using PedigreePortalen.UI.Models;
using static PedigreePortalen.UI.Mapper.AnimalMicroServiceMapper.AnimalMapper;
using static PedigreePortalen.UI.Mapper.AnimalMicroServiceMapper.RaceMapper;
using static PedigreePortalen.UI.Mapper.AnimalMicroServiceMapper.SubRaceMapper;
using static PedigreePortalen.UI.Mapper.UserMicroServiceMapper.UserMapper;
using static PedigreePortalen.UI.Mapper.AnimalMicroServiceMapper.LitterMapper;

namespace PedigreePortalen.UI.Controllers
{
    public class AnimalController : Controller
    {
        private readonly HttpClient _httpClient;
        
        public AnimalController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IActionResult> Search()
        {
            return  View();
        }

        public async Task<IActionResult> Index(string searchstring)
        {
            try
            {
                HttpResponseMessage response = await _httpClient.GetAsync($"gateway/GetAnimalsBySearchstring/searchstring?searchstring={searchstring}");
                response.EnsureSuccessStatusCode();
                var result = await response.Content.ReadAsStringAsync();
                var animalListDto = JsonConvert.DeserializeObject<List<AnimalQuerysDto.AnimalDetails>>(result);
                return View(AnimalDetailsMapper.Map(animalListDto));
            }
            catch (Exception)
            {
                ErrorViewModel model = new ErrorViewModel { RequestId = "Kunne ikke finde vovser" };
                return View("Error", model);
            }
        }

        // GET: Customer/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            try
            {
                HttpResponseMessage Response = await _httpClient.GetAsync($"gateway/Animal/GetFullPedegreeTreeByAnimalId?AnimalId={id.Value}");
                Response.EnsureSuccessStatusCode();
                var result = await Response.Content.ReadAsStringAsync();
                var animalDto = JsonConvert.DeserializeObject<AnimalQuerysDto.AnimalDetails>(result);
                
                return View(AnimalDetailsLitterMapper.Map(animalDto));
            }
            catch (Exception)
            {
                ErrorViewModel model = new ErrorViewModel { RequestId = "Hundes detajler kunne ikke vises" };
                return View("Error", model);
            }
        }

        // GET: Customer/Create
        public async Task<IActionResult> Create(Guid? id)
        {
            try
            {
                AnimalViewModel.CreateAnimal animal = new AnimalViewModel.CreateAnimal();

                IEnumerable<RaceViewModel.RaceDetails> raceDetails = await GetAllRaces();
                animal.RaceDetails = raceDetails.ToList();
                
                UserViewModel.UserDetails viewModelUser = await GetUserByLoginUserId(id);
                animal.OwnerId = viewModelUser.UserId;

                IEnumerable<SubRaceViewModel.SubRaceDetails> subRaceDetails = await GetAllSubRaces();
                animal.SubRaceDetails = subRaceDetails.ToList();

                return View(animal);
            }
            catch (Exception)
            {
                ErrorViewModel model = new ErrorViewModel { RequestId = "Kunne ikke finde kunder" };
                return View("Error", model);
            }
        }

        // POST: Customer/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AnimalId,OwnerId,Phone,SubRaceId,RegNo,PedigreeName,ShortName,BirthDate,DeathDate,Gender,Color,WeightInKg,ProfileText")] AnimalViewModel.CreateAnimal animal, Guid? id)
        {
            AnimalCommandsDto.V1.CreateAnimal animalDto = AnimalCreateMapper.Map(animal);

            if (ModelState.IsValid)
            {
                try
                {
                    animalDto.AnimalId = Guid.NewGuid();
                    HttpResponseMessage response = await _httpClient.PostAsJsonAsync
                        (
                        $"gateway/Animal/CreateAnimal?AnimalId={animalDto.AnimalId}&OwnerId={animalDto.OwnerId}&SubRaceId={animalDto.SubRaceId}" +
                        $"&RegNo={animalDto.RegNo}&PedigreeName={animalDto.PedigreeName}&ShortName={animalDto.ShortName}&BirthDate={animalDto.BirthDate}" +
                        $"&DeathDate={animalDto.DeathDate}&Gender={animalDto.Gender}&Color={animalDto.Color}&WeightInKg={animalDto.WeightInKg}&ProfileText={animalDto.ProfileText}", animalDto
                        );
                    response.EnsureSuccessStatusCode();

                    if (response.IsSuccessStatusCode)
                    {
                        return RedirectToAction("Details", "User", new { id });
                    }
                    else
                    {
                        return View(animal);
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

        // GET: Customer/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            try
            {
                HttpResponseMessage response = await _httpClient.GetAsync($"gateway/Animal/GetSingleAnimalByAnimalId?AnimalId={id.Value}");
                response.EnsureSuccessStatusCode();
                var result = await response.Content.ReadAsStringAsync();
                var animalDto = JsonConvert.DeserializeObject<AnimalQuerysDto.AnimalDetails>(result);

                if (animalDto == null)
                {
                    return NotFound();
                }
                return View(AnimalDetailsMapper.Map(animalDto));
            }
            catch (Exception)
            {
                ErrorViewModel model = new ErrorViewModel { RequestId = "Kunden kunne ikke rettes" };
                return View("Error", model);
            }
        }

        // POST: Customer/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid? id, [Bind("AnimalId,OwnerId,RegNo,PedigreeName,ShortName,BirthDate,DeathDate,Gender,Color,WeightInKg,ProfileText")] AnimalViewModel.DetailsAnimal animal)
        {
            AnimalQuerysDto.AnimalDetails animalDto = AnimalDetailsMapper.Map(animal);
            animalDto.AnimalId = id.Value;

            if (ModelState.IsValid)
            {
                try
                {
                    HttpResponseMessage response = await _httpClient.PutAsJsonAsync
                    ($"gateway/Animal/UpdateAnimal?AnimalId={animalDto.AnimalId}&HumanId={animalDto.OwnerId}&RegNo={animalDto.RegNo}&PedigreeName={animalDto.PedigreeName}" +
                    $"&ShortName={animalDto.ShortName}&BirthDate={animalDto.BirthDate}&DeathDate={animalDto.DeathDate}&Gender={animalDto.Gender}&Color={animalDto.Color}&WeightInKg={animalDto.WeightInKg}" +
                    $"&IsBreedable={animalDto.IsBreedable}&ProfileText={animalDto.ProfileText}", animalDto);
                    response.EnsureSuccessStatusCode();

                    if (response.IsSuccessStatusCode)
                    {
                        return RedirectToAction("Details", "Animal", new { id });
                    }
                    else
                    {
                        return View(animal);
                    }
                }
                catch (Exception)
                {
                    ErrorViewModel model = new ErrorViewModel { RequestId = "Kunden kunne ikke rettes" };
                    return View("Error", model);
                }
            }
            return View(animal);
        }

        // GET: Customer/Edit/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            try
            {
                HttpResponseMessage response = await _httpClient.GetAsync($"gateway/Animal/GetSingleAnimalByAnimalId?AnimalId={id.Value}");
                response.EnsureSuccessStatusCode();
                var result = await response.Content.ReadAsStringAsync();
                var animalDto = JsonConvert.DeserializeObject<AnimalQuerysDto.AnimalDetails>(result);

                if (animalDto == null)
                {
                    return NotFound();
                }
                return View(AnimalDetailsMapper.Map(animalDto));
            }
            catch (Exception)
            {
                ErrorViewModel model = new ErrorViewModel { RequestId = "Kunden kunne ikke rettes" };
                return View("Error", model);
            }
        }

        // POST: Animal/Delete
        [HttpPost]
        public async Task<IActionResult> Delete(Guid? id, [Bind("AnimalId")] AnimalViewModel.DetailsAnimal animal)
        {
            AnimalQuerysDto.AnimalDetails animalDto = AnimalDetailsMapper.Map(animal);
            
            if (ModelState.IsValid)
            {
                try
                {
                    HttpResponseMessage response = await _httpClient.PutAsJsonAsync
                    ($"gateway/Animal/DeleteAnimal?AnimalId={animalDto.AnimalId}", animalDto);
                    response.EnsureSuccessStatusCode();

                    if (response.IsSuccessStatusCode)
                    {
                        return RedirectToAction("Details", "User", new { id });
                    }
                    else
                    {
                        return View(animal);
                    }
                }
                catch (Exception)
                {
                    ErrorViewModel model = new ErrorViewModel { RequestId = "Kunden kunne ikke rettes" };
                    return View("Error", model);
                }
            }
            return View(animal);
        }

        //GET: Animal/AddLitterToAnimal/5
        public async Task<IActionResult> AddLitterToAnimal(Guid? id,Guid AnimalId)
        {
            try
            {
                AnimalViewModel.AddLitterToAnimal animal = new AnimalViewModel.AddLitterToAnimal();

                HttpResponseMessage animalResponse = await _httpClient.GetAsync($"gateway/Animal/GetSingleAnimalByAnimalId?AnimalId={AnimalId}");
                animalResponse.EnsureSuccessStatusCode();
                var animalResult = await animalResponse.Content.ReadAsStringAsync();
                var animalDto = JsonConvert.DeserializeObject<AnimalQuerysDto.AnimalDetails>(animalResult);
                animal.AnimalId = animalDto.AnimalId;

                UserViewModel.UserDetails viewModelUser = await GetUserByLoginUserId(id);

                IEnumerable<LitterViewModel.LitterDetails> litters = await GetAllLitterByOwnerId(viewModelUser.UserId);
                animal.Litters = litters.ToList();

                return View(animal);
            }
            catch (Exception)
            {
                ErrorViewModel model = new ErrorViewModel { RequestId = "Kunden kunne ikke rettes" };
                return View("Error", model);
            }
        }

        // POST: Animal/AddLitterToAnimal/5
        [HttpPost]
        public async Task<IActionResult> AddLitterToAnimal([Bind("AnimalId,LitterId")] AnimalViewModel.AddLitterToAnimal animal)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    HttpResponseMessage response = await _httpClient.PutAsJsonAsync
                    ($"gateway/Animal/AddAnimalToLitter?AnimalId={animal.AnimalId}&LitterId={animal.LitterId}", animal);
                    response.EnsureSuccessStatusCode();

                    Guid id = animal.AnimalId;
                    if (response.IsSuccessStatusCode)
                    {
                        return RedirectToAction("Details", "Animal", new { id });
                    }
                    else
                    {
                        return View(animal);
                    }
                }
                catch (Exception)
                {
                    ErrorViewModel model = new ErrorViewModel { RequestId = "Kunden kunne ikke rettes" };
                    return View("Error", model);
                }
            }
            return RedirectToAction("Details", "Animal", new { animal.AnimalId });
        }

        // GET: Animal/AddAnimalToLitter
        public async Task<IActionResult> AddAnimalToLitter(Guid id)
        {
            try
            {
                AnimalViewModel.AddAnimalToLitter animalToLitter  = new AnimalViewModel.AddAnimalToLitter();

                HttpResponseMessage animalResponse = await _httpClient.GetAsync($"gateway/GetAllParentingAnimals");
                animalResponse.EnsureSuccessStatusCode();
                var animalResult = await animalResponse.Content.ReadAsStringAsync();
                var animalDto = JsonConvert.DeserializeObject<List<AnimalQuerysDto.AnimalDetails>>(animalResult);
                IEnumerable<AnimalViewModel.DetailsAnimal> animals = AnimalDetailsMapper.Map(animalDto);
                animalToLitter.Animals = animals.ToList();
                animalToLitter.LitterId = id;

                return View(animalToLitter);
            }
            catch (Exception)
            {
                ErrorViewModel model = new ErrorViewModel { RequestId = "Kunne ikke finde kunder" };
                return View("Error", model);
            }
        }

        // POST: Customer/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> AddAnimalToLitter([Bind("AnimalId,LitterId")] AnimalViewModel.AddAnimalToLitter animalToLitter, Guid id)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    HttpResponseMessage response = await _httpClient.PutAsJsonAsync
                    ($"gateway/Animal/AddAnimalToLitter?AnimalId={animalToLitter.AnimalId}&LitterId={id}", animalToLitter);
                    response.EnsureSuccessStatusCode();

                    if (response.IsSuccessStatusCode)
                    {
                        return RedirectToAction("Details", "Litter", new { id });
                    }
                    else
                    {
                        return View(animalToLitter);
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

        private async Task<IEnumerable<SubRaceViewModel.SubRaceDetails>> GetAllSubRaces()
        {
            HttpResponseMessage subRaceResponse = await _httpClient.GetAsync($"gateway/GetAllSubRaces");
            subRaceResponse.EnsureSuccessStatusCode();
            var subRaceResult = await subRaceResponse.Content.ReadAsStringAsync();
            var subRaceDtoList = JsonConvert.DeserializeObject<List<SubRaceQuerysDto.SubRaceDetails>>(subRaceResult);
            IEnumerable<SubRaceViewModel.SubRaceDetails> subRaceDetailsViewModel = SubRaceDetailsMapper.Map(subRaceDtoList);

            return subRaceDetailsViewModel;
        }

        private async Task<IEnumerable<RaceViewModel.RaceDetails>> GetAllRaces() 
        {
            HttpResponseMessage raceResponse = await _httpClient.GetAsync("gateway/GetAllRaces");
            raceResponse.EnsureSuccessStatusCode();
            var raceResult = await raceResponse.Content.ReadAsStringAsync();
            var raceDtoList = JsonConvert.DeserializeObject<List<RaceQuerysDto.RaceDetails>>(raceResult);
            IEnumerable<RaceViewModel.RaceDetails> raceDetailsViewModel = RaceDetailsMapper.Map(raceDtoList);

            return raceDetailsViewModel;
        }

        private async Task<IEnumerable<LitterViewModel.LitterDetails>> GetAllLitterByOwnerId(Guid id) 
        {
            HttpResponseMessage LitterResponse = await _httpClient.GetAsync($"gateway/Litter/GetAllLitterByOwnerId?BreedById={id}");
            LitterResponse.EnsureSuccessStatusCode();
            var litterResult = await LitterResponse.Content.ReadAsStringAsync();
            var LitterDto = JsonConvert.DeserializeObject<List<LitterQuerysDto.LitterDetails>>(litterResult);
            IEnumerable<LitterViewModel.LitterDetails> litter = LitterDetailsMapper.Map(LitterDto);

            return litter;
        }
    }
}
