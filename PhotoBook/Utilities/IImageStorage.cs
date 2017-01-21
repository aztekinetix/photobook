using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace PhotoBook.Utilities
{
    public interface IImageStorage
    {
        void SaveImage(HttpPostedFileBase MyFile, string DirectorytoSave, string filename, bool AddExtension=true);

    }
}
