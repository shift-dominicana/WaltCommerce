using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Mobile.Helpers
{
    public static class DateValid
    {
        public static bool IsDate(String date)

        {

            try

            {

                DateTime dt = DateTime.Parse(date);

                return true;

            }
            catch

            {

                return false;

            }

        }


    }
}
