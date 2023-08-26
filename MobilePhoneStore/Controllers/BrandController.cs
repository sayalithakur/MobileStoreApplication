using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using MobilePhoneStore.Models;
using MobilePhoneStore.Repository;
using MobilePhoneStore.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Numerics;
using System.Reflection.Metadata;
using System.Runtime.Intrinsics.X86;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace MobilePhoneStore.Controllers
{
    [ApiController]
    [Route("/brands")]
    public class BrandController : ControllerBase
    {
        private readonly IBrandService _brandService;
        private readonly IBrandRepository _brandRepository; 


        public BrandController(IBrandService brandService, IBrandRepository brandRepository)
        {
            _brandService = brandService;
            _brandRepository = brandRepository;
        }

        [HttpPost]
        public async Task<IActionResult> Create(Brand brand)
        {
            await _brandService.Create(brand);
            return Ok();
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            Brand brand = await _brandRepository.GetById(id);
            if (brand == null)
            {
                return NotFound();
            }
            return Ok(brand);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _brandRepository.Delete(id);
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var brands = await _brandRepository.GetAll();
            return Ok(brands);
        }

        [HttpPost("bulk-insert")]
        public IActionResult BulkInsertBrands(List<Brand> brands)
        {
            _brandRepository.BulkInsertBrands(brands);
            return Ok("Bulk insert successful.");
        }
        [HttpPost("bulk-update")]
        public IActionResult BulkUpdateBrands(List<Brand> brands)
        {
            _brandRepository.BulkUpdateBrands(brands);
            return Ok("Bulk update successful.");
        }
    }
    




}
