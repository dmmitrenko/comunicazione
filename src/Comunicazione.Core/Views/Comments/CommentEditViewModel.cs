﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comunicazione.Core.Views
{
    public class CommentEditViewModel
    {
        public string Content { get; set; }
        public DateTime DateUpdate { get { return DateTime.Now; } }
    }
}
