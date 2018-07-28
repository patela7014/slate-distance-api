using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using DAL.Core.Models;
using DAL.Helpers;
using DAL.Resources;
using DAL.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace ApiServer.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        private readonly IOptions<ServiceSettings> _serviceSettings;
        private readonly IGenericService<BuildingDto> buildingService;
        private readonly IGenericService<EmployeeDto> employeeService;

        public ValuesController(IOptions<ServiceSettings> serviceSettings, IGenericService<BuildingDto> buildingService, IGenericService<EmployeeDto> employeeService)
        {
            _serviceSettings = serviceSettings;
            this.buildingService = buildingService;
            this.employeeService = employeeService;
        }

        // GET api/values
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var Url = _serviceSettings.Value.GMUrl;
            var Key = _serviceSettings.Value.GMApiKey;
            var inputSourceAddresses = buildingService.GetAll();
            var inputDestinationAddresses = employeeService.GetAll();
            var inputDestinationAddressesArray = new List<string>();
            var inputSourceAddressesArray = new List<string>();
            foreach(var source in inputSourceAddresses)
            {
                inputSourceAddressesArray.Add(string.Format("{0}, {1}, {2}, {3}, {4}", source.Address, source.City, source.State, source.Country, source.Zip));
            }

            foreach (var destination in inputDestinationAddresses)
            {
                inputDestinationAddressesArray.Add(string.Format("{0}, {1}, {2}, {3}, {4}", destination.Address, destination.City, destination.State, destination.Country, destination.Zip));
            }

            GoogleDistanceMatrixApi api = new GoogleDistanceMatrixApi(Url, Key, inputSourceAddressesArray.ToArray(), inputDestinationAddressesArray.ToArray());
            var response = await api.GetResponse();
            var originAdresses = response.OriginAddresses.ToList();
            var destinationAdresses = response.DestinationAddresses.ToList();
            var rows = response.Rows.ToList();
            foreach (var row in rows)
            {
                int i = rows.IndexOf(row);
                var elements = row.Elements.ToList();

                foreach (var element in elements)
                {
                    int j = elements.IndexOf(element);
                    element.OriginAddress = originAdresses[i];
                    element.DestinationAddress = destinationAdresses[j];
                }
            }
            response.Rows = rows.ToArray();
            return Json(response);
        }
        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public async void Post(IFormFileCollection formCollection)
        {
            var files = Request.Form;
            string folder = "general";

            foreach (var cur_file in files.Files)
            {
                switch (Path.GetExtension(cur_file.FileName))
                {
                    case ".png":
                    case ".jgp":
                    case ".jpeg":
                    case ".gif":
                        folder = "general";
                        break;
                    case ".mp3":
                    case ".mp4":
                        folder = "audio";
                        break;
                    default:
                        folder = "general";
                        break;
                }
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot\\{folder}");
                using (var fileStream = new FileStream(Path.Combine(filePath, cur_file.FileName), FileMode.Create))
                {
                    await cur_file.CopyToAsync(fileStream);
                }
            }
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
