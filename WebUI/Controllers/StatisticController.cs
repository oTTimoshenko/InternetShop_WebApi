using AutoMapper;
using BLL.DTO;
using BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebUI.Models;

namespace WebUI.Controllers
{
    public class StatisticController : ApiController
    {
        IStatisticService _stat;
        IMapper _mapper;

        public StatisticController(IStatisticService stat, IMapper mapper)
        {
            _stat = stat;
            _mapper = mapper;
        }
        public StatisticController() { }

        [HttpGet]
        [Route("api/Statisticpanel/getStats")]
        public StatisticView getStats()
        { 
            var stat = _stat.getOverallStats();
            var statM = _mapper.Map<StatisticView>(stat);
            return statM;
        }
    }
}
