using EasyWallet.Entries.Api.Requests;
using EasyWallet.Entries.Api.Responses;
using EasyWallet.Entries.Business.Abstractions;
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

        [HttpPost]
        public async Task<Response<CreateEntryResponse>> Create([FromBody] CreateEntryRequest request)
        {
            int entryId;

            try
            {
                entryId = await _entryService.AddEntry(request.KeywordId, request.Amount, request.Date);
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

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
