using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project.b.support.SupportDto
{
    public class ErrorDetails
    {
        public int StatusCode { get; set; } = 500;
        public IEnumerable<object> Errors { get; set; }
    }
}
