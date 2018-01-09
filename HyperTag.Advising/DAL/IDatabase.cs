using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hypertag.Advising.DAL
{
    interface IDatabase
    {
        bool Table();
        string Error { get; set; }

    }
}
