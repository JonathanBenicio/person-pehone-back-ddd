using System.Collections.Generic;

namespace Examples.Charge.Application.Common.Messages
{
    public abstract class BaseResponse
    {
        public bool Success { get; set; } = true;

        public IEnumerable<object> Errors { get; set; } = null;
        private object _data { get; set; } = null;

        public object Data { get { return _data; } set { _data =  value; } } 
    }
}
