using MediatR;
using System;
using System.Web.Mvc;
using TimesheetReport.Core.Features.Files;

namespace TimesheetReport.WebUI.Controllers
{
    public class FileController : Controller
    {
        private readonly IMediator mediator;

        public FileController(
            IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost]
        public ActionResult Upload(int fileModule)
        {
            try
            {
                if (Request.Files != null && Request.Files.Count > 0)
                {
                    var uploadFile = Request.Files[0];
                    if (uploadFile != null && uploadFile.ContentLength > 0)
                    {
                        var file = new File
                        {
                            Name = System.IO.Path.GetFileName(uploadFile.FileName),
                            Type = System.IO.Path.GetExtension(uploadFile.FileName),
                        };

                        using (var reader = new System.IO.BinaryReader(uploadFile.InputStream))
                        {
                            file.Data = reader.ReadBytes(uploadFile.ContentLength);
                        }

                        var command = new UploadFileCommand
                        {
                            File = file
                        };

                        var uploadFileResult = mediator.Send(command);

                        if (uploadFileResult == "Success")
                        {
                            return Json(new { Error = 0, Name = file.Name, FileId = file.Id });
                        }
                        else
                        {
                            return Json(new { Error = -40001, Message = uploadFileResult });
                        }
                    }
                }

                return Json(new { Error = -40001, Message = "Nullable file upload error" });
            }
            catch (Exception ex)
            {
                return Json(new { Error = -40002, Message = ex.Message });
            }
        }

        public ActionResult View(Guid fileId)
        {
            try
            {
                var query = new GetFileByFileIdQuery
                {
                    FileId = fileId
                };

                var file = mediator.Send(query);
                if (file == null)
                {
                    return Json(new { Error = -40003, Message = "Cannot get file with this FileId." });
                }
                else
                {
                    string mediaFileType = string.Empty;
                    mediaFileType = GetTypeOfFile(file.Type, mediaFileType);

                    string value = "inline; filename = \"" + file.Name + "\"";

                    HttpContext.Response.AddHeader("content-disposition", value);
                    return File(file.Data, mediaFileType);
                }
            }
            catch (Exception ex)
            {
                return Json(new { Error = -40004, Message = ex.Message });
            }
        }

        public ActionResult Download(Guid fileId)
        {
            try
            {
                var query = new GetFileByFileIdQuery
                {
                    FileId = fileId
                };

                var file = mediator.Send(query);
                if (file == null)
                {
                    return Json(new { Error = -40003, Message = "Cannot get file with this FileId." });
                }
                else
                {
                    string mediaFileType = string.Empty;
                    mediaFileType = GetTypeOfFile(file.Type, mediaFileType);

                    return File(file.Data, mediaFileType, file.Name);
                }
            }
            catch (Exception ex)
            {
                return Json(new { Error = -40004, Message = ex.Message });
            }
        }

        private string GetTypeOfFile(string fileType, string mediaFileType)
        {
            if (!string.IsNullOrEmpty(fileType) && (fileType.ToUpper().Equals(".PNG") || fileType.ToUpper().Equals(".JPG")))
            {
                mediaFileType = "image/" + fileType.Substring(1).ToLower();
            }

            if (!string.IsNullOrEmpty(fileType) && (fileType.ToUpper().Equals(".PDF")))
            {
                mediaFileType = "application/" + fileType.Substring(1).ToLower();
            }

            if (!string.IsNullOrEmpty(fileType) && (fileType.ToUpper().Equals(".DOC")))
            {
                mediaFileType = "application/msword";
            }

            if (!string.IsNullOrEmpty(fileType) && (fileType.ToUpper().Equals(".DOCX")))
            {
                mediaFileType = "application/vnd.openxmlformats-officedocument.wordprocessingml.document";
            }

            return mediaFileType;
        }
    }
}