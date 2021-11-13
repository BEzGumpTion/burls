﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Burls.Windows
{
    public interface IBurlsPage
    {
        string Title { get; }
        IViewModel ViewModelBase { get; set; }
    }
}
