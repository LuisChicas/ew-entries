using EasyWallet.Entries.Api.Helpers;
using EasyWallet.Entries.Api.Requests;
using EasyWallet.Entries.Api.Responses;
using EasyWallet.Entries.Business.Abstractions;
using EasyWallet.Entries.Business.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace EasyWallet.Entries.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EntriesController : ControllerBase
    {
        private readonly IEntryService _entryService;

        public EntriesController(IEntryService entryService)
        {
            _entryService = entryService;
        }

        [HttpPost("create")]
        public async Task<Response<CreateEntryResponse>> Create([FromBody] CreateEntryRequest request)
        {
            int entryId;

            try
            {
                entryId = await _entryService.AddEntry(ApiMapper.Map<Entry>(request));
            }
            catch (Exception e)
            {
                return new Response<CreateEntryResponse>
                {
                    Success = false,
                    Message = e.Message
                };
            }

            return new Response<CreateEntryResponse>
            {
                Success = true,
                Data = new CreateEntryResponse
                {
                    EntryId = entryId
                }
            };
        }

        [HttpDelete("delete/{id}")]
        public async Task<Response> Delete(int id)
        {
            try
            {
                await _entryService.DeleteEntry(id);
            }
            catch (Exception e)
            {
                return new Response
                {
                    Success = false,
                    Message = e.Message
                };
            }

            return new Response { Success = true };
        }
    }
}
