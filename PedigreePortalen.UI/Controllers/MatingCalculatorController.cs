using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PedigreePortalen.Shared.MatingCalculatorMicroserviceDto.Queries;
using PedigreePortalen.UI.Models;
using PedigreePortalen.UI.Mapper.MatingCalculatorMicroServiceMapper;
using PedigreePortalen.Shared.MatingCalculatorMicroserviceDto.Commands;
using PedigreePortalen.Shared.AnimalMicroserviceDto.Commands;
using Microsoft.AspNetCore.Http;
using PedigreePortalen.Shared.UserMicroserviceDto.Querys;
using static PedigreePortalen.UI.Mapper.UserMicroServiceMapper.UserMapper;

namespace PedigreePortalen.UI.Controllers
{
    public class MatingCalculatorController : Controller
    {
        private readonly HttpClient _httpClient;
       
        public MatingCalculatorController(HttpClient httpClient)
        {
            _httpClient = httpClient;
           
        }

        public async Task<IActionResult> Create(Guid? id)
        {
            
            if (id == null)
            {
                return RedirectToAction("GetAllAnimalsWithoutUserId");
            }

            UserViewModel.UserDetails viewModelUser = await GetUserFromLoginId(id);
            
            
            try
            {
                HttpResponseMessage response = await _httpClient.GetAsync($"/gateway/GetDogDetailsFromOwnerId/ownerid?ownerid={viewModelUser.UserId}");
                response.EnsureSuccessStatusCode();
                var result = await response.Content.ReadAsStringAsync();
                var dogListDto = JsonConvert.DeserializeObject<List<DogQuriesDto.DogDetails>>(result);

                return View(DogMapper.DogDetailsMapper.Map(dogListDto));
            }
            catch (Exception)
            {
              
                ErrorViewModel model = new ErrorViewModel { RequestId = "Kunne ikke finde hunde" };
                 return View("Error", model);
               
            }
        }

        public async Task<IActionResult> Details(Guid fatherdogid, Guid motherdogid)
        {
       
            //Guid matingcalculationId = Guid.NewGuid();
            var matetwodogsDto = new MatingCalculationCommandDto.V1.MateTwoDogs();

            matetwodogsDto.MatingCalculationId = Guid.NewGuid();
            matetwodogsDto.FatherDogId = fatherdogid;
            matetwodogsDto.MotherDogId = motherdogid;

            HttpResponseMessage response = await _httpClient.PostAsJsonAsync($"gateway/MatingCalculator/matetwodogs/motherdogid?motherdogid={motherdogid}&fatherdogid?fatherdogid={fatherdogid}&MatingCalculationId?MatingCalculatorId={matetwodogsDto.MatingCalculationId}", matetwodogsDto);

            response.EnsureSuccessStatusCode();

            MatingCalculatorViewModel.MatingCalculatorDetails matingcalculatorviewmodel = await GetMatingCalculation(matetwodogsDto.MatingCalculationId);
            return View(matingcalculatorviewmodel);

        }

        public async Task<IActionResult> GetAllAnimalsWithoutUserId()
        {
            try
            {
                HttpResponseMessage response = await _httpClient.GetAsync($"/gateway/GetAllDogDetailsForMatingCalculation");
                response.EnsureSuccessStatusCode();

                var result = await response.Content.ReadAsStringAsync();

                var dogListDto = JsonConvert.DeserializeObject<List<DogQuriesDto.DogDetails>>(result);

                return View("Create",DogMapper.DogDetailsMapper.Map(dogListDto));
            }
            catch (Exception)
            {

                ErrorViewModel model = new ErrorViewModel { RequestId = "Kunne ikke finde hunde" };
                return View("Error", model);

            }
        }
        private async Task<MatingCalculatorViewModel.MatingCalculatorDetails> GetMatingCalculation(Guid matingcalculationId)
        {
            HttpResponseMessage response = await _httpClient.GetAsync($"/gateway/GetSingleMatingCalculator?matingcalculatorId={matingcalculationId}");
            response.EnsureSuccessStatusCode();

            var result = await response.Content.ReadAsStringAsync();

            var matingcalculationDto = JsonConvert.DeserializeObject<MatingCalculationQueriesDto.MatingCalculationDetails>(result);

            MatingCalculatorViewModel.MatingCalculatorDetails matingCalculatorDetails = MatingCalculationMapper.MatingCalculationDetailsMapper.Map(matingcalculationDto);

            matingCalculatorDetails.CalculatedDiseaseDetails = await GetCalculatedDiseaseDetailsFromMatingCalculationId(matingcalculationId);

            return matingCalculatorDetails;
        }

        private async Task<List<CalculatedDiseaseViewModel.CalculatedDiseaseDetails>> GetCalculatedDiseaseDetailsFromMatingCalculationId(Guid matingcalculationId)
        {
            HttpResponseMessage response = await _httpClient.GetAsync($"/gateway/GetAllCalculatedDiseaseDetailsFromMatingCalculationId?matingCalculationId={matingcalculationId}");
            response.EnsureSuccessStatusCode();

            var result = await response.Content.ReadAsStringAsync();

            var calculatedDiseasesDto = JsonConvert.DeserializeObject<List<CalculatedDiseaseQueriesDto.CalculatedDiseaseDetails>>(result);

            List<CalculatedDiseaseViewModel.CalculatedDiseaseDetails> calculatedDiseaseDetails = CalculatedDiseaseMapper.CalculatedDiseaseDetialsMapper.Map(calculatedDiseasesDto).ToList();

            return calculatedDiseaseDetails;
        }

      
        private async Task<UserViewModel.UserDetails> GetUserFromLoginId(Guid? id)
        {
            HttpResponseMessage userresponse = await _httpClient.GetAsync($"gateway/User/GetUserByLoginUserId?LoginUserId={id}");
            userresponse.EnsureSuccessStatusCode();
            var userresult = await userresponse.Content.ReadAsStringAsync();
            var userDto = JsonConvert.DeserializeObject<UserQuerysDto.UserDetails>(userresult);
            UserViewModel.UserDetails viewModelUser = UserDetailsMapper.Map(userDto);

            return viewModelUser;
        }
    }
}