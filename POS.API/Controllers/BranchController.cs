using AutoMapper;
using Exceptions;
using ImagesService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Pos.IService;
using POS.Core.Resources;
using POS.Data.Entities;
using POS.Entities;
using POS.Models;
using POS.Service.IService;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;

namespace POS.API.CORE.Controllers
{
    [AllowAnonymous]
    [ApiController]
    [Route("api/[controller]")]
    public class BranchController : ControllerBase
    {
        private ImagesPath imagesPath;
        private IBranchService BranchService;
        private IBranchesConnectingService BranchesConnecting;

        private IMapper Mapper;

        public BranchController(
                                      IBranchService _BranchService,
                                       ImagesPath _imagesPath,
                                      IMapper mapper,
                                      IBranchesConnectingService _BranchesConnecting
                                )
        {
            BranchService = _BranchService;
            imagesPath = _imagesPath;
            Mapper = mapper;
            BranchesConnecting = _BranchesConnecting;
        }



        [HttpGet("GetBranches")]
        public IActionResult GetBranches(int BrandID = 0, string Lang = "en")
        {
            try
            {
                Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(Lang);
                Thread.CurrentThread.CurrentUICulture = new CultureInfo(Lang);

                var data = BranchService.GetProcBranches(BrandID, imagesPath.Branch);
                if (data != null)
                {
                    if (data.Count() == 0)
                    {
                        return Ok(new { success = true, message = lang.No_data_available, datalist = JsonConvert.DeserializeObject(data) });
                    }
                    else
                    {
                        return Ok(new { success = true, message = "", datalist = JsonConvert.DeserializeObject(data) });
                    }

                }
            }

            catch (Exception ex)
            {
                ExceptionError.SaveException(ex);
            }

            return Ok(new { success = false, message = lang.An_error_occurred_while_processing_your_request });

        }


        [HttpPost("Save_Branches")]
        public IActionResult Save_Branches(BranchesModel model, string Lang = "en")
        {
            try
            {
                Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(Lang);
                Thread.CurrentThread.CurrentUICulture = new CultureInfo(Lang);

                var Branch = Mapper.Map<Branches>(model);
                var data = BranchService.SaveProcBranch(Branch);
                if (data != 1)
                {
                    if (data == -1)
                    {
                        return Ok(new { success = false, message = lang.An_error_occurred_while_processing_your_request });
                    }

                    if (data == -2)
                    {
                        return Ok(new { success = false, message = lang.English_name_already_exists, repeated = "BranchName" });
                    }
                    if (data == -3)
                    {
                        return Ok(new { success = false, message = lang.Arabic_name_already_exists, repeated = "BranchNameAr" });
                    }
                    if (data == -4)
                    {
                        return Ok(new { success = false, message = lang.Branch_num_already_exist, repeated = "BranchNum" });
                    }
                }
                else
                {
                    return Ok(new { success = true, message = lang.Saved_successfully_completed });
                }

            }
            catch (Exception ex)
            {
                ExceptionError.SaveException(ex);
            }
            return Ok(new { success = false, message = lang.An_error_occurred_while_processing_your_request });
        }


        [HttpPost("SaveBranchesConnecting")]
        public IActionResult SaveBranchesConnecting(List<BranchesConnecting> model, int BranchID, int TypeID, string Lang = "en")
        {
            try
            {
                Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(Lang);
                Thread.CurrentThread.CurrentUICulture = new CultureInfo(Lang);

                BranchesConnecting.SaveBranchesConnecting(model, BranchID, TypeID);
                return Ok(new { success = true, message = lang.Saved_successfully_completed });

            }
            catch (Exception ex)
            {
                ExceptionError.SaveException(ex);
            }
            return Ok(new { success = false, message = lang.An_error_occurred_while_processing_your_request });
        }

    }
}
