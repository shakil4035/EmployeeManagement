﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pims.Core.ViewModel.Setup_Module
{
   public  class LanguageViewModel
    {
        public int Id { set; get; }
        [Required]
        public string Name { set; get; }
    }
}
