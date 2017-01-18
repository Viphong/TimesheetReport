using MediatR;
using Microsoft.AspNet.Identity;
using System.Collections.Generic;
using System.Web.Mvc;
using TimesheetReport.Core.Features.MyEquipment;
using TimesheetReport.WebUI.ViewModels.Equipment;

namespace TimesheetReport.WebUI.Controllers
{
    [Authorize]
    public class EmployeeController : Controller
    {
        private readonly IMediator mediator;

        public EmployeeController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public ActionResult MyEquipment()
        {
            var query = new GetEquipmentsOfEmployeeQuery
            {
                UserId = User.Identity.GetUserId()
            };

            var equipments = mediator.Send(query);

            var viewModelItemList = new List<MyEquipmentViewModelItem>();
            foreach (var item in equipments)
            {
                viewModelItemList.Add(new MyEquipmentViewModelItem
                {
                    Name = item.Name,
                    Code = item.Code,
                    AssignOn = item.AssignOn,
                    AssignBy = item.AssignBy,
                });
            }

            var viewModel = new MyEquipmentViewModel
            {
                Items = viewModelItemList.ToArray()
            };

            return View(viewModel);
        }

        // Demo source tree
    }
}