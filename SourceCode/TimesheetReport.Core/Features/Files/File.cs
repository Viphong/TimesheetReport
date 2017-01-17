using System;
using TimesheetReport.Core.Features.Utilities;

namespace TimesheetReport.Core.Features.Files
{
    public class File
    {
        public File()
        {
            Id = SequentialGuidGenerator.NewSequentialGuid();
        }

        public Guid Id { get; set; }

        public int Length { get; set; }

        public string Name { get; set; }

        public string Type { get; set; }

        public byte [] Data { get; set; }
    }
}
