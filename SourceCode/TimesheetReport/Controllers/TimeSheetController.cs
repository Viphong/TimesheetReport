using MediatR;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Web.Mvc;
using TimesheetReport.Core.Features.Projects;
using TimesheetReport.Core.Features.TimeSheets;
using TimesheetReport.WebUI.Models;
using TimesheetReport.WebUI.ViewModels;

namespace TimesheetReport.WebUI.Controllers
{
    public class TimeSheetController : Controller
    {
        private readonly IMediator mediator;

        public TimeSheetController(
            IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost]
        public ActionResult AddTimeSheet(AddWorkTimeViewModel listWorkTime)
        {
            if (ModelState.IsValid)
            {
                var query = new AddWorkTimeCommand
                {
                    UserId = User.Identity.GetUserId(),
                    Hours = listWorkTime.Hours,
                    ProjectId = listWorkTime.ProjectId,
                    Tasks = listWorkTime.Tasks,
                    AddedDate = listWorkTime.AddedDate
                };
                var addTimeSheet = mediator.Send(query);
                return Json(addTimeSheet, JsonRequestBehavior.AllowGet);
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult DeleteTaskWorkTime(Guid TaskId)
        {
            if (ModelState.IsValid)
            {
                var query = new DeleteTaskCommand
                {
                    TaskId = TaskId
                };
                var task = mediator.Send(query);

                return Json("successful");
            }
            return RedirectToAction("TimesheetManagement");
        }

        [HttpGet]
        public ActionResult TimesheetManagement()
        {
            return this.View();
        }

        [HttpGet]
        public ActionResult GetListTimesheet(DateTime? startDate, DateTime? endDate)
        {
            var today = DateTime.Today;
            var query = new GetListTimeSheetQuery
            {
                UserId = User.Identity.GetUserId(),
                StartDate = startDate.HasValue ? startDate.Value : new DateTime(today.Year, today.Month, 1),
                EndDate = endDate.HasValue ? endDate.Value : today
            };

            var listTimeSheet = mediator.Send(query);

            var timeSheetItems = new List<ListTimeSheet>();

            foreach (var item in listTimeSheet)
            {
                timeSheetItems.Add(new ListTimeSheet
                {
                    Date = item.Date,
                    TotalHours = item.TotalHours
                });
            }

            var timeSheetViewModel = new TimeSheetViewModel
            {
                ListTimeSheet = timeSheetItems.ToArray(),
                StartDate = query.StartDate,
                EndDate = query.EndDate
            };

            return this.PartialView("_ListTimesheetPartial", timeSheetViewModel);
        }

        [HttpGet]
        public ActionResult ReloadTimeSheet(DateTime? startDate, DateTime? endDate)
        {
            var today = DateTime.Today;
            var query = new GetListTimeSheetQuery
            {
                UserId = User.Identity.GetUserId(),
                StartDate = startDate.HasValue ? startDate.Value : new DateTime(today.Year, today.Month, 1),
                EndDate = endDate.HasValue ? endDate.Value : today
            };

            var listTimeSheet = mediator.Send(query);

            var timeSheetItems = new List<ListTimeSheet>();

            foreach (var item in listTimeSheet)
            {
                timeSheetItems.Add(new ListTimeSheet
                {
                    Date = item.Date,
                    TotalHours = item.TotalHours
                });
            }

            var timeSheetViewModel = new TimeSheetViewModel
            {
                ListTimeSheet = timeSheetItems.ToArray(),
                StartDate = query.StartDate,
                EndDate = query.EndDate
            };

            return this.PartialView("_UpdateHourWorkTimePartial", timeSheetViewModel);
        }

        [HttpGet]
        public ActionResult GetTimesheetDetail(DateTime singleWorkTime)
        {
            var projectList = GetProjectList();

            List<TimeSheetItem> timeSheetItems = GetTimeSheetDetail(singleWorkTime);

            var viewModel = new TimeSheetViewModel()
            {
                Projects = projectList.ToArray(),
                TimeSheetItems = timeSheetItems.ToArray()
            };

            return this.PartialView("_TimeSheetDetails", viewModel);
        }

        [HttpPost]
        public ActionResult EditWorkTime(EditWorkTimeViewModel editViewModel)
        {
            if (ModelState.IsValid)
            {
                var query = new EditWorkTimeCommand
                {
                    Id = editViewModel.Id,
                    ProjectId = editViewModel.ProjectId,
                    Tasks = editViewModel.Tasks,
                    Hours = editViewModel.Hours
                };

                var editedWorkTime = mediator.Send(query);
                return Json("Successful");
            }
            return RedirectToAction("Index");
        }

        private List<TimeSheetItem> GetTimeSheetDetail(DateTime singleWorkTime)
        {
            var query = new GetTimeSheetDetailQuery
            {
                UserId = User.Identity.GetUserId(),
                SingleDate = singleWorkTime
            };

            var timeSheetDetail = mediator.Send(query);

            var timeSheetItems = new List<TimeSheetItem>();
            
            foreach (var item in timeSheetDetail)
            {
                timeSheetItems.Add(new TimeSheetItem
                {
                    Hours = item.Hours,
                    ProjectName = item.ProjectName,
                    Tasks = item.Task,
                    WorkTimeId = item.WorkTimeId
                });
            }
            var timeSheetViewModel = new TimeSheetViewModel();
            timeSheetViewModel.TimeSheetItems = timeSheetItems.ToArray();

            return timeSheetItems;
        }

        private List<ViewModels.ProjectModel> GetProjectList()
        {
            var query = new GetProjectsQuery();
            
            var projects = mediator.Send(query);

            var projectList = new List<ViewModels.ProjectModel>();
            foreach (var item in projects)
            {
                projectList.Add(new ViewModels.ProjectModel
                {
                    Id = item.Id,
                    Name = item.Name
                });
            }

            return projectList;
        }
    }
}