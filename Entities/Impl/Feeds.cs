using Entities.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Impl
{
    public class Feeds : AbstractEntityBase
    {
        public string title { get; set; }
        public List<BookFeedField> rows { get; set; }
    }
}
