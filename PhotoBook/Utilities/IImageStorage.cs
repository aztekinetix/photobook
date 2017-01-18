using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace PhotoBook.Utilities
{
    interface IImageStorage
    {
        void SaveImage(HttpPostedFileBase postedFile);
    }
}
