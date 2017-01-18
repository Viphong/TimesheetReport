using MediatR;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TimesheetReport.Core.Features.Equipments;
using TimesheetReport.Core.Features.Files;
using TimesheetReport.WebUI.ViewModels.Equipment;

namespace TimesheetReport.WebUI.Controllers
{
    public class EquipmentController : Controller
    {
        private readonly IMediator mediator;

        public EquipmentController(IMediator _mediator)
        {
            this.mediator = _mediator;
        }
        // GET: Equipment
        public ActionResult Index()
        {
            var query = new GetEquipmentQuery();
            var equipments = mediator.Send(query);

            var viewModelItemList = new List<EquipmentViewModel>();
            foreach (var item in equipments)
            {
                viewModelItemList.Add(new EquipmentViewModel
                {
                    Id = item.Id,
                    Name = item.Name,
                    Code = item.Code,
                    Status = item.Status,
                    CreatedOn = item.CreatedOn,
                    UsingBy = item.AssignTo
                });
                
            }
            var viewModel = new MyEquipmentViewModel
            {
                EquimentItems = viewModelItemList.ToArray()
            };
            return View(viewModel);
        }
        
        [HttpGet]
        public ActionResult AddEquipment()
        {
            var addEquipment = new AddEquipmentViewModel();
            return View(addEquipment);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddEquipment(AddEquipmentViewModel viewModel)
        {

            if (ModelState.IsValid)
            {
                var icon = GetIcon();
                if (icon != null)
                {
                    var command = new AddEquipmentCommand
                    {
                        File = icon,
                        Name = viewModel.Name,
                        Code = viewModel.Code,
                        Status = viewModel.Status,
                        Description = viewModel.Description,
                        UserName = User.Identity.GetUserName()
                    };
                    try
                    {
                        mediator.Send(command);
                        return RedirectToAction("Index", "Equipment");
                    }
                    catch (Exception ex)
                    {
                        ex.Message.Contains("add is not success");
                        return View();
                    }

                }
                else
                {
                    var command = new AddEquipmentCommand
                    {
                        Name = viewModel.Name,
                        Code = viewModel.Code,
                        Status = viewModel.Status,
                        Description = viewModel.Description,
                        UserName = User.Identity.GetUserName()
                    };
                    try
                    {
                        mediator.Send(command);
                        return RedirectToAction("Index", "Equipment");
                    }
                    catch
                    {
                        return View("Error");
                    }
                }
            }
            return View();
        }

        private File GetIcon()
        {
            if (Request.Files != null && Request.Files.Count > 0)
            {
                var uploadFile = Request.Files[0];
                if (uploadFile != null && uploadFile.ContentLength > 0)
                {
                    var icon = new File
                    {
                        Name = System.IO.Path.GetFileName(uploadFile.FileName),
                        Type = System.IO.Path.GetExtension(uploadFile.FileName),
                    };
                    using (var reader = new System.IO.BinaryReader(uploadFile.InputStream))
                    {
                        icon.Data = reader.ReadBytes(uploadFile.ContentLength);
                    }

                    return icon;
                }
            }

            return null;
        }
    }
}