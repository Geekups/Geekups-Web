using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DayanaWeb.Shared.BaseControl;
public enum SortByEnum
{
    CreationDate = 1,
    CreationDateDescending = 2,
}

public enum UserSortBy
{
    CreationDate = 1,
    CreationDateDescending = 2,
    LastLoginDate,
    LastLoginDateDescending,
}