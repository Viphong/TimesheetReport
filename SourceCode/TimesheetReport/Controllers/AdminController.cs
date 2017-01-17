using MediatR;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TimesheetReport.Core.Features.Files;
using TimesheetReport.Core.Features.Projects;
using TimesheetReport.WebUI.ViewModels.Projects;

namespace TimesheetReport.WebUI.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly IMediator mediator;

        public AdminController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public ActionResult ProjectManagement(ProjectViewModel model)
        {
            var query = new GetListProjectsQuery
            {
                SearchText = model.SearchText
            };

            var projects = mediator.Send(query);

            var viewModelItemList = new List<ProjectViewModelItem>();

            foreach (var item in projects)
            {
                viewModelItemList.Add(new ProjectViewModelItem
                {
                    ProjectId = item.Id,
                    ProjectName = item.Name,
                    ClientName = item.ClientName,
                    Status = item.Status,
                    StartDate = item.StartDate,
                });
            }

            var viewModel = new ProjectViewModel
            {
                Items = viewModelItemList.ToArray()
            };

            return View(viewModel);
        }

        [HttpGet]
        public ActionResult AddProject()
        {
            var viewModel = new AddProjectModel();

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddProject(AddProjectModel addProject)
        {
            if (ModelState.IsValid)
            {
                var icon = GetIcon();
                var command = new AddProjectsCommand
                {
                    File = icon,
                    Name = addProject.Name,
                    ClientName = addProject.ClientName,
                    Status = addProject.Status,
                    StartDate = addProject.StartDate,
                    ProjectOwner = addProject.ProjectOwner,
                    Description = addProject.Description
                };

                var result = mediator.Send(command);

                if (result == true)
                {
                    return RedirectToAction("ProjectManagement", "Admin");
                }

                return RedirectToAction("AddProject", new { message = TimesheetReport.Controllers.ManageController.ManageMessageId.Error });
            }

            return RedirectToAction("ProjectManagement");
        }

        [HttpGet]
        public ActionResult EditProject(Guid projectId)
        {
            var query = new GetProjectQuery
            {
                ProjectId = projectId
            };
            
            var project = mediator.Send(query);

            var model = new EditProjectModel()
            {
                ProjectId = projectId,
                Name = project.Name,
                ClientName = project.ClientName,
                Status = project.Status,
                StartDate = project.StartDate,
                ProjectOwner = project.ProjectOwner,
                Description = project.Description,
                IconId = project.IconId
            };

            return View(model);
        }

        [HttpPost]
        public ActionResult EditProject(EditProjectModel editProject)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var icon = GetIcon();

                    var command = new EditProjectsCommand
                    {
                        ProjectId = editProject.ProjectId,
                        File = icon,
                        Name = editProject.Name,
                        ClientName = editProject.ClientName,
                        Status = editProject.Status,
                        StartDate = editProject.StartDate,
                        ProjectOwner = editProject.ProjectOwner,
                        Description = editProject.Description
                    };

                    var result = mediator.Send(command);

                    if (result == true)
                    {
                        return RedirectToAction("ProjectManagement", "Admin");
                    }
                }
                catch (Exception)
                {
                }
            }

            return RedirectToAction("ProjectManagement");
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