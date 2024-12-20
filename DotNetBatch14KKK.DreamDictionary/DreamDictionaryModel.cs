using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetBatch14KKK.DreamDictionary
{
    public class DreamDictionaryModel
    {
        public int groupId { get; set; }
        public string title { get; set; }
 
    }
    public class DreamDictionaryResponseModel
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
    }

    public class DreamDictionaryListResponseModel
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public List<DreamDictionaryModel> Data { get; set; }
    }
}
