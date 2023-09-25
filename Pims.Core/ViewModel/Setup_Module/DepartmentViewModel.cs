using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pims.Core.ViewModel
{
    public class DepartmentViewModel
    {
        public int Id { set; get; }
        [Required]
        public string Name { set; get; }
        [Required]
        public string Code { get; set; }
        public bool IsActive { set; get; }
    }
}
