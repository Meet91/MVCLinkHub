using BOL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;


namespace BLL
{
    public class CommonBs :BaseBs
    {

        public void InsertQuickURL(QuickURLSubmitModel MyQuickUrl)
        {
            using(TransactionScope trans = new TransactionScope())
            {
                try
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

                    trans.Complete();
                }catch(Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }

            
        }
    }
}
