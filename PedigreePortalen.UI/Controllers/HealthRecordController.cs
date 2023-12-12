using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PedigreePortalen.Shared.AnimalMicroserviceDto.Commands;
using PedigreePortalen.Shared.HealthRecordMicroservice.Queries;
using PedigreePortalen.UI.Mapper.HealthRecordMicroserviceMapper;
using PedigreePortalen.UI.Models;

namespace PedigreePortalen.UI.Controllers
{
    public class HealthRecordController : Controller
    {
     
    
        private readonly HttpClient _httpClient;


        public HealthRecordController(HttpClient httpClient)
        {
            _httpClient = httpClient;

        }


       

        public  async Task<IActionResult> Details(Guid animalId)
        {
            
            HttpResponseMessage response = await _httpClient.GetAsync($"/gateway/GetSingleHealRecordDetailsFromAnimalId?animalId={animalId}");
            response.EnsureSuccessStatusCode();

           if (Convert.ToInt16( response.StatusCode)==200)
            {
                try
                {
                    var result = await response.Content.ReadAsStringAsync();

                    var healthrecordDto = JsonConvert.DeserializeObject<HealthRecordQueriesDTO.HealthRecordDetails>(result);

                    var healthRecodViewModel = HealthRecordMapper.Map(healthrecordDto);
                    healthRecodViewModel.Diseases = DiseaseDetialsMapper.Map(healthrecordDto.DiseaseDetails).ToList();

                    return View(healthRecodViewModel);
                    
                }
                catch (Exception)
                {
                    ErrorViewModel model = new ErrorViewModel { RequestId = "Kunne ikke finde sundhedsjournal" };
                    return View("Error", model);
                }
            }
            else
            {
                return RedirectToAction("Create", new { Id = animalId });



            }

        }

        //private async Task<HealthRecordViewModel.HelthRecordDetails> GetHelthRecordDetails(HttpResponseMessage response)
        //{
        //    var result = await response.Content.ReadAsStringAsync();

        //    var healthrecordDto = JsonConvert.DeserializeObject<HealthRecordQueriesDTO.HealthRecordDetails>(result);

        //    var healthRecodViewModel = HealthRecordMapper.Map(healthrecordDto);
        //    healthRecodViewModel.Diseases = DiseaseDetialsMapper.Map(healthrecordDto.DiseaseDetails).ToList();

        //    return healthRecodViewModel;
        //}
        public async Task<IActionResult> Create(Guid id)
        {

            var HealthRecordId = Guid.NewGuid();
            var healthRecordDto = new HealthRecordCommandsDto.V1.CreateHealthRecord();

            healthRecordDto.HealthRecordId = HealthRecordId;
            healthRecordDto.AnimalId = id;

            HttpResponseMessage response = await _httpClient.PostAsJsonAsync($"/gateway/HealthRecord/CreateHealthRecord?HealthRecordId={healthRecordDto.HealthRecordId}&AnimalId={healthRecordDto.AnimalId}", healthRecordDto);

            response.EnsureSuccessStatusCode();

            ViewBag.animalid = id;

            return View();
            //return RedirectToAction("Details", new { Id = healthRecordDto.AnimalId });

        }
    }
}