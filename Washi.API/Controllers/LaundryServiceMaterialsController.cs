using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Washi.API.Domain.Models;
using Washi.API.Domain.Services;
using Washi.API.Extensions;
using Washi.API.Resources;
namespace Washi.API.Controllers
{
    [Route("/api")]
    public class LaundryServiceMaterialsController : Controller
    {
        private readonly ILaundryServiceMaterialService _laundryServiceMaterialService;
        private readonly IMapper _mapper;

        public LaundryServiceMaterialsController(ILaundryServiceMaterialService laundryServiceMaterialService, IMapper mapper)
        {
            _laundryServiceMaterialService = laundryServiceMaterialService;
            _mapper = mapper;
        }
        [HttpPost("laundry-service-material")]
        public async Task<IActionResult> PostAsync([FromBody] SaveLaundryServiceMaterialResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());
            var laundryServiceMaterial = _mapper.Map<SaveLaundryServiceMaterialResource, LaundryServiceMaterial>(resource);
            var result = await _laundryServiceMaterialService.AddAsync(laundryServiceMaterial);

            if (!result.Success)
                return BadRequest(result.Message);

            var laundryServiceMaterialResource = _mapper
                .Map<LaundryServiceMaterial, LaundryServiceMaterialResource>(result.Resource);
            return Ok(laundryServiceMaterialResource);
        }

        [HttpGet("laundry-service-materials")]
        public async Task<IEnumerable<LaundryServiceMaterialResource>> GetAllAsync()
        {
            var laundryServiceMaterials = await _laundryServiceMaterialService.ListAsync();
            var resources = _mapper
                .Map<IEnumerable<LaundryServiceMaterial>, IEnumerable<LaundryServiceMaterialResource>>(laundryServiceMaterials);
            return resources;
        }

        [HttpGet("laundry-service-materials/{laundryServiceMaterialId}/laundries")]
        public async Task<IEnumerable<UserProfileResource>> GetAllLaundriesByLaundryServiceMaterialIdAsync(int laundryServiceMaterialId)
        {
            var laundries = await _laundryServiceMaterialService.ListLaundriesByLaundryServiceMaterialIdAsync(laundryServiceMaterialId);
            var resources = _mapper
                .Map<IEnumerable<UserProfile>, IEnumerable<UserProfileResource>>(laundries);
        //Check if ok
            return resources;
        }

        [HttpGet("laundries/{laundryId}/laundry-service-materials")]
        public async Task<IEnumerable<LaundryServiceMaterialResource>> GetAllLaundryServicesMaterialsByLaundryIdAsync(int laundryId)
        {
            var laundryServiceMaterials = await _laundryServiceMaterialService.ListLaundryServicesMaterialsByLaundryIdAsync(laundryId);
            var resources = _mapper
                .Map<IEnumerable<LaundryServiceMaterial>, IEnumerable<LaundryServiceMaterialResource>>(laundryServiceMaterials);
        //Check if ok
            return resources;
        }

        [HttpGet("service-materials/{serviceMaterialId}/laundries")]
        public async Task<IEnumerable<UserProfileResource>> GetAllLaundriesByServiceMaterialIdAsync(int serviceMaterialId)
        {
            var laundries = await _laundryServiceMaterialService.ListLaundriesByServiceMaterialIdAsync(serviceMaterialId);
            var resources = _mapper
                .Map<IEnumerable<UserProfile>, IEnumerable<UserProfileResource>>(laundries);
            //Check if ok
            return resources;
        }

        [HttpGet("service-materials/{serviceMaterialId}/districts/{districtId}/laundries")]
        public async Task<IEnumerable<UserProfileResource>> GetAllLaundriesByServiceMaterialIdAndDistrictIdAsync(int serviceMaterialId, int districtId)
        {
            var laundries = await _laundryServiceMaterialService.ListLaundriesByServiceMaterialIdAndDistrictIdAsync(serviceMaterialId, districtId);
            var resources = _mapper
                .Map<IEnumerable<UserProfile>, IEnumerable<UserProfileResource>>(laundries);
            //Check if ok
            return resources;
        }

        [HttpGet("service-materials/{serviceMaterialId}/laundry-service-materials")]
        public async Task<IEnumerable<LaundryServiceMaterialResource>> GetAllLaundryServicesMaterialsByServiceMaterialIdAsync(int serviceMaterialId)
        {
            var laundryServiceMaterials = await _laundryServiceMaterialService.ListLaundryServiceMaterialsByServiceMaterialIdAsync(serviceMaterialId);
            var resources = _mapper
                .Map<IEnumerable<LaundryServiceMaterial>, IEnumerable<LaundryServiceMaterialResource>>(laundryServiceMaterials);
            //Check if ok
            return resources;
        }

        [HttpDelete("laundry-service-material/{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _laundryServiceMaterialService.DeleteAsync(id);

            if (!result.Success)
                return BadRequest(result.Message);
            var laundryServiceMaterialResource = _mapper
                .Map<LaundryServiceMaterial, LaundryServiceMaterialResource>(result.Resource);
            return Ok(laundryServiceMaterialResource);
        }

        [HttpPut("laundry-service-material/{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaveLaundryServiceMaterialResource resource)
        {
            var laundryServiceMaterial = _mapper.Map<SaveLaundryServiceMaterialResource, LaundryServiceMaterial>(resource);
            var result = await _laundryServiceMaterialService.UpdateAsync(id, laundryServiceMaterial);

            if (!result.Success)
                return BadRequest(result.Message);
            var laundryServiceMaterialResource = _mapper
                .Map<LaundryServiceMaterial, LaundryServiceMaterialResource>(result.Resource);
            return Ok(laundryServiceMaterialResource);
        }
        [HttpGet("laundry/{laundryId}/service-material/{serviceMaterialId}")]
        public async Task<IActionResult> GetServiceMaterialByLaundryIdAndServiceMaterialIdAsync(int laundryId, int serviceMaterialId)
        {
            var result = await _laundryServiceMaterialService.GetByLaundryIdAndServiceMaterialId(laundryId, serviceMaterialId);
            if (!result.Success)
                return BadRequest(result.Message);
            var resource = _mapper
                .Map<LaundryServiceMaterial, LaundryServiceMaterialResource>(result.Resource);
            return Ok(resource);
        }
    }
}
