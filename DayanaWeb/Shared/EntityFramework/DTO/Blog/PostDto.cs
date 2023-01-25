using DayanaWeb.Shared.EntityFramework.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DayanaWeb.Shared.EntityFramework.DTO.Blog
{
    public class PostDto : BaseDto
    {
        public string Name { get; set; }
    }
}
