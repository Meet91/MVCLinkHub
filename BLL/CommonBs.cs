using BOL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class CommonBs :BaseBs
    {

        public void InsertQuickURL(QuickURLSubmitModel MyQuickUrl)
        {
            tbl_User u = MyQuickUrl.myUser;
            u.Password = u.ConfirmPassword = "123";
            u.Role = "U";
            userBs.Insert(u);

            tbl_Url url = MyQuickUrl.myUrl;
            url.UserId = u.UserId;
            url.UrlDesc = url.UrlTitle;
            url.IsApproved = "P";
            urlBs.Insert(url);
        }
    }
}
