using System.Collections.Generic;

namespace Database.Utils
{
    public class OperationResult<T>
    {
        public bool Success { get; set; }
        public List<T> Datas { get; set; }
        public T Data { get; set; }
        public string Message { get; set; }
    }
}

