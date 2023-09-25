using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pims.Core.Model
{
   public  class Department
    {
        public int Id { set; get; }
        public string Name { set; get; }
        public string Code { get; set; }
        public bool IsActive { set; get; }
    }
}
