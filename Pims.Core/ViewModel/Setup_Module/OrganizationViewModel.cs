using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pims.Core.ViewModel.Setup_Module
{
     public class OrganizationViewModel
    {
        public int Id { set; get; }
        public string Name { set; get; }
        public string Address { set; get; }
        public bool IsActive { set; get; }
    }
}
