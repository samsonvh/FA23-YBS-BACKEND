﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using YBS.Data.Enums;
using YBS.Middlewares;
using YBS.Service.Dtos.InputDtos;
using YBS.Service.Dtos.PageRequests;
using YBS.Service.Services;

namespace YBS.Controllers
{
    [ApiController]
    [Consumes("multipart/form-data")]
    public class YachtsController : ControllerBase
    {
        private readonly IYachtService _yachtService;

        public YachtsController(IYachtService yachtService)
        {
            _yachtService = yachtService;
        }
        [Route(APIDefine.YACHT_GET_ALL)]
        [HttpGet]
        public async Task<IActionResult> GetAllYacht([FromQuery] YachtPageRequest pageRequest)
        {
            return Ok(await _yachtService.GetAllYacht(pageRequest));    
        }

        [HttpGet]
        [Route(APIDefine.YACHT_DETAIL)]
        public async Task<IActionResult> GetDetailYacht([FromRoute]int id)
        {
            return Ok(await _yachtService.GetDetailYacht(id));
        }

        [RoleAuthorization(nameof(EnumRole.COMPANY))]
        [HttpPost]
        [Route(APIDefine.YACHT_CREATE)]
        public async Task<IActionResult> Create([FromForm] YachtInputDto pageRequest)
        {
            await _yachtService.Create(pageRequest);
            return Ok("Create Yacht Successfully");
        }

        [RoleAuthorization(nameof(EnumRole.COMPANY))]
        [HttpPut]
        [Route(APIDefine.YACHT_UPDATE)]
        public async Task<IActionResult> Update([FromRoute] int id,[FromBody] YachtInputDto pageRequest)
        {
            await _yachtService.Update(id,pageRequest);
            return Ok("Update Yacht Successfully");
        }

        [RoleAuthorization(nameof(EnumRole.COMPANY))]
        [HttpPatch]
        [Route(APIDefine.YACHT_CHANGE_STATUS)]
        public async Task<IActionResult> ChangeStatusYaccht([FromRoute] int id, [FromForm] string status)
        {
            var changedStatus = await _yachtService.ChangeStatusYacht(id, status);  
            if(changedStatus)
            {
                return Ok("Change status yacht successful.");
            }
            return BadRequest("Change status yacht fail.");
        }
    }
}
