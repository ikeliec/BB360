using System.Collections.Generic;

namespace BB360TestBrief.Data.Models
{
    public class ErrorResponse
    {
        public bool Status { get; set; } = false;
        public string Message { get; set; }
        public List<string> Errors { get; set; } = new List<string>();
        public string TraceId { get; set; }
    }
}