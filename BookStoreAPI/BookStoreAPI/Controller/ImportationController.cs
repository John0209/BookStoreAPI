﻿using AutoMapper;
using BookStoreAPI.Core.DTO;
using BookStoreAPI.Core.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.Service;
using Service.Service.IService;
using static System.Net.Mime.MediaTypeNames;

namespace BookStoreAPI.Controller
{
    [Route("api/importation")]
    [ApiController]
    public class ImportationController : ControllerBase
    {
        IImportationService _import;
        IMapper _map;
        public ImportationController(IImportationService import, IMapper mapper)
        {
            _import = import;
            _map = mapper;
        }
        [HttpGet("getImportation")]
        public async Task<IActionResult> GetImportation()
        {
            var respone = await _import.GetDiplayImport();
            if (respone != null)
            {
                return Ok(respone);
            }
            return BadRequest("importation don't exists");
        }
        [HttpPost("createImportation")]
        public async Task<IActionResult> CreateImportation(ImportationDTO dto)
        {
            if (dto != null)
            {
                var import=_map.Map<Importation>(dto);
                var result = await _import.CreateImport(import);
                if (result) return Ok("Add Import Success");
            }
            return BadRequest("Add Import Fail");
        }
        [HttpPatch("deleteImporatation")]
        public async Task<IActionResult> DeleteImportation(Guid importId)
        {
            var result = await _import.DeleteImport(importId);
            if (result) return Ok("Delete Importation Success");
            return BadRequest("Delete Importation Fail");
        }
        [HttpPatch("restoreImporatation")]
        public async Task<IActionResult> RestoreImportation(Guid importId)
        {
            var result = await _import.RestoreImport(importId);
            if (result) return Ok("Restore Importation Success");
            return BadRequest("Restore" +
                " Importation Fail");
        }
        [HttpDelete("removeImporatation")]
        public async Task<IActionResult> RemoveImportation(Guid importId)
        {
            var result = await _import.RemoveImport(importId);
            if (result) return Ok("Remove Importation Success");
            return BadRequest("Remove" +
                " Importation Fail");
        }
        [HttpPut("updateImportation")]
        public async Task<IActionResult> UpdateImportation(ImportationDTO dto)
        {
            if (dto != null)
            {
                var import = _map.Map<Importation>(dto);
                var result = await _import.UpdateImport(import);
                if (result) return Ok("Update User Success");
            }
            return BadRequest("Update User Fail");
        }
    }
}
