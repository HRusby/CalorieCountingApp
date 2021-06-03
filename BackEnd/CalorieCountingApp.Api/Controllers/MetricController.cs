using System.Collections.Generic;
using BackEnd.CalorieCountingApp.Data.Dao;
using BackEnd.CalorieCountingApp.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace BackEnd.CalorieCountingApp.Api.Controllers
{
    [ApiController]
    [Route("Metric")]
    public class MetricController
    {
        private readonly MetricDao dao;

        public MetricController(IConfiguration configuration)
        {
            string connString = configuration.GetValue<string>("ConnectionStrings:CalorieCounting");
            dao = new MetricDao(connString);
        }

        [HttpPost]
        [Route("GetMetrics")]
        public List<Metric> GetMetrics(){
            return dao.GetMetrics();
        }
    }
}