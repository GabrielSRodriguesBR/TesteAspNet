using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TesteAsp.Classes
{
    public class ButtonsHelper
    {
        public static Object buttonEdit()
        {
            return new { @class = "btn btn-info"};
        }

        public static Object buttonDetails()
        {
            return new { @class = "btn btn-warning" };
        }

        public static Object buttonDelete()
        {
            return new { @class = "btn btn-danger" };
        }

        public static Object buttonNew()
        {
            return new { @class = "btn btn-primary" };
        }

        public static Object indexButtons()
        {
            return null;
        }


    }
}