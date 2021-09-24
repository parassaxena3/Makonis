using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Makonis.Common.Models
{
    public class ResponseModel
    {

        public ResponseModel(bool success, string message)
        {
            this.Success = success;
            this.Message = message;
        }


        public bool Success { get; set; }

        public string Message { get; set; }

    }
}
