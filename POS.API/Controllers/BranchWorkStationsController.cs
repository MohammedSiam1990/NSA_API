using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using POS.API.Models;
using POS.Core.Resources;
using POS.Data.Entities;
using POS.Service.IService;

namespace POS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BranchWorkStationsController : ControllerBase
    {
        private IBranchWorkStationsService BranchWorkStationsService;
        private IMapper Mapper;
        public BranchWorkStationsController(IBranchWorkStationsService _BranchWorkStationsService, IMapper mapper)
        {
            BranchWorkStationsService = _BranchWorkStationsService;
            Mapper = mapper;
        }

        [HttpPost("SaveBranchWorkStations")]
        public IActionResult SaveBranchWorkStationsService(BranchWorkStationsModel model, string Lang = "en")
        {
            try
            {
                Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(Lang);
                Thread.CurrentThread.CurrentUICulture = new CultureInfo(Lang);
                var branchWorkStations = Mapper.Map<BranchWorkStations>(model);
                int data = BranchWorkStationsService.ValidateNameAlreadyExist(branchWorkStations);

                if (data == 1)
                {
                    if (branchWorkStations.BranchWorkstationID == 0)
                        BranchWorkStationsService.AddBranchWorkStations(branchWorkStations);
                    else
                    {
                        BranchWorkStationsService.UpdateBranchWorkStations(branchWorkStations);
                    }
                    return Ok(new { success = true, message = lang.Saved_successfully_completed });
                }
                else if (data == -1)
                    return Ok(new { success = false, message = lang.An_error_occurred_while_processing_your_request });
                else if (data == -2)
                    return Ok(new { success = false, message = lang.English_name_already_exists, repeated = "branchWorkStationsName" });
            }
            catch (Exception ex)
            {
                ExceptionError.SaveException(ex);
                // return error message if there was an exception

            }
            return Ok(new { success = false, message = lang.An_error_occurred_while_processing_your_request });
        }


    }
}
