using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tracker.Data.Models;
using Tracker.Domain.IServices;

namespace Tracker.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DaysForAutomticApprovedStatusController : ControllerBase
    {
        private readonly IDaysForAutomaticApprovedStatusService  _DaysForAutomaticApprovedStatusService ;
        public DaysForAutomticApprovedStatusController(IDaysForAutomaticApprovedStatusService  daysForAutomaticApprovedStatusService )
        {
            _DaysForAutomaticApprovedStatusService = daysForAutomaticApprovedStatusService;
        }
        
        [HttpGet]
        public IEnumerable<DaysforAutomticApproveStatus> Get()
         {
            return _DaysForAutomaticApprovedStatusService.GetAllDaysForAutomaticApprovedStatus();
        }

        [HttpPut("{id}")]
        public void Put(int id, DaysforAutomticApproveStatus daysforAutomticApproveStatus)
        {
            _DaysForAutomaticApprovedStatusService.UpdateDaysForAutomaticApprovedStatus(id, daysforAutomticApproveStatus);
        }
        [HttpGet("{id}")]
        public ActionResult<DaysforAutomticApproveStatus> GetbyId(int id)
        {
            return _DaysForAutomaticApprovedStatusService.GetDayforAutomaticApprovedStatusbyID(id);
        }


    }
}
