using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pims.Core.CommonModule
{
   public  class BaseDomain
    {
        public bool IsDelete { set; get; }
         public string CreateBy { set; get; }
         public DateTime CreateDate { set; get; }
         public string UpdateBy { set; get; }
         public DateTime? UpdateDate { set; get; }
         public string IsDeleteBy { set; get; }
         public DateTime? DeleteDate { set; get; }
    }
}
