using LoginTestAppMaui.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginTestAppMaui.Services.Implementation
{
    public class StringService : IStringService
    {
        public string CheckStringNullOrWhiteSpace(string current)
        {
            return string.IsNullOrWhiteSpace(current) ? "[none]" : current;
        }

        public string ToList(IEnumerable<object> items)
        {
            if (items == null)
            {
                return string.Empty;
            }

            return items.Aggregate(string.Empty, (sender, obj) => sender + (sender.Length == 0 ? "" : ", ") + ((string)obj));
        }
    }
}
