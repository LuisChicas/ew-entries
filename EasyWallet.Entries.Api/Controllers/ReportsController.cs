using EasyWallet.Entries.Api.Requests;
using EasyWallet.Entries.Api.Responses;
using EasyWallet.Entries.Business.Abstractions;
using EasyWallet.Entries.Business.Models.Reports;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace EasyWallet.Entries.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportsController : ControllerBase
    {
        private readonly IReportService _reportService;

        public ReportsController(IReportService reportService)
        {
            _reportService = reportService;
        }

        [HttpGet("history/{userId}")]
        public async Task<Response<HistoryReport>> GetHistoryReport(int userId)
        {
            return await GetReportResponse(() => _reportService.GetHistoryReport(userId));
        }

        [HttpGet("monthly/{userId}")]
        public async Task<Response<MonthlyReport>> GetMonthlyReport(int userId)
        {
            return await GetReportResponse(() => _reportService.GetMonthlyReport(userId));
        }
        
        [HttpGet("balance/{userId}/{incomeCategoryId}")]
        public async Task<Response<BalanceReport>> GetBalanceReport(int userId, int incomeCategoryId)
        {
            return await GetReportResponse(() => _reportService.GetBalanceReport(userId, incomeCategoryId));
        }

        private async Task<Response<T>> GetReportResponse<T>(Func<Task<T>> getReport)
        {
            T report;

            try
            {
                report = await getReport();
            }
            catch (Exception e)
            {
                return new Response<T>
                {
                    Success = false,
                    Message = e.Message
                };
            }

            return new Response<T>
            {
                Success = true,
                Data = report
            };
        }
    }
}
