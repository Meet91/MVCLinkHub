using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace BLL
{
   public class AdminBs : BaseBs
    {

        public void ApproveOrReject(List<int> Ids, string Status)
        {
            using (TransactionScope tran = new TransactionScope())
            {
                try
                {

                    foreach (var item in Ids)
                    {
                        var myurl = urlBs.GetById(item);
                        myurl.IsApproved = Status;
                        urlBs.Update(myurl);
                    }

                    tran.Complete();


                }catch(Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }
    }
}
