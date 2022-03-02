using System;
using System.Collections.Generic;
using System.Text;

namespace DLL.Interfaces
{
    public interface ITrackable
    {
        DateTimeOffset CreatedAt { get; set; }
        string CreatedBy { get; set; }
        DateTimeOffset lastUpdatedAt { get; set; }
        string UpdatedBy { get; set;}
    }
}
