using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class SecurityBs
    {
        public CategoryBs categoryBs { get; set; }
        public UserBs userBs { get; set; }
        public UrlBs urlBs { get; set; }

        public SecurityBs()
        {
            categoryBs = new CategoryBs();
            urlBs = new UrlBs();
            userBs = new UserBs();
        }
    }
}
