using System.Collections.Generic;

namespace FCommerce.Model.Helper
{
    public class ListWithCount<T>
    {
        public int RecordCount { get; set; }
        public IEnumerable<T> RecordList { get; set; }

        public ListWithCount(int count, IEnumerable<T> recordList)
        {
            RecordCount = count;
            RecordList = recordList;
        }
    }
}
