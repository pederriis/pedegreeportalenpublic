using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PedigreePortalen.Shared.HealthRecordMicroservice.Commands;
using PedigreePortalen.UI.Mapper.HealthRecordMicroserviceMapper;
using PedigreePortalen.UI.Models;

namespace PedigreePortalen.UI.Controllers
{
    public class DiseaseController : Controller
    {
        private readonly HttpClient _httpClient;

        public DiseaseController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IActionResult> Create(Guid id, Guid animalId)
        {
            try
            {
                DiseaseViewModel.CreateDisease disease = new DiseaseViewModel.CreateDisease();
                disease.HealthRecordId = id;

                ViewBag.animalId = animalId;
                return View(disease);
            }
            catch (Exception)
            {
                ErrorViewModel model = new ErrorViewModel { RequestId = "Noget gik galt" };
                return View("Error", model);
            }
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("HealthRecordId,Name,Note,Date,IsHereditary")] DiseaseViewModel.CreateDisease disease, Guid? id, Guid animalId)
        {
            DiseaseCommandsDTO.V1.CreateDisease diseaseDto = DiseaseCreateMapper.Map(disease);
            diseaseDto.DiseaseId = Guid.NewGuid();

            if (ModelState.IsValid)
            {
                try
                {
                    
                    HttpResponseMessage response = await _httpClient.PostAsJsonAsync
                        (
                        $"/gateway/Disease/CreateDisease?DiseaseId={diseaseDto.DiseaseId}"
                        +$"&HealthRecordId={diseaseDto.HealthRecordId}&Name={diseaseDto.Name}"
                        +$"&Date={diseaseDto.Date}&Note={diseaseDto.Note}&Probabilty={diseaseDto.Probabilty}" 
                        +$"&IsHereditary={diseaseDto.IsHereditary}", diseaseDto);
                    response.EnsureSuccessStatusCode();

                    if (response.IsSuccessStatusCode)
                    {
                        return RedirectToAction("Details", "HealthRecord", new { animalId });
                    }
                    else
                    {
                        return View(disease);
                    }
                }
                catch (Exception)
                {
                    ErrorViewModel model = new ErrorViewModel { RequestId = "Kunne ikke tilføje sygdom" };
                    return View("Error", model);
                }
            }
            return  RedirectToAction("Details", "HealthRecord", new { animalId });
        }


    }
}