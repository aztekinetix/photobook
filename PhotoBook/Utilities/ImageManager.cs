using PhotoBook.Exceptions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace PhotoBook.Utilities
{
    public class ImageManager : IImageStorage
    {

        private readonly string[] allowedExtensions = { "jpg", "jpeg", "png" };

        public void SaveImage(HttpPostedFileBase MyFile, string DirectorytoSave, string MyFilename)
        {
            if (MyFile != null)
            {
                var fileExtension = Path.GetExtension(MyFile.FileName);
                if (allowedExtensions.Contains(fileExtension))
                {
                    var filePath= Path.Combine(DirectorytoSave, MyFilename); // combining Directory with Filename
                    MyFile.SaveAs(filePath);
                }
                else //it has no valid extension
                {
                    throw new NonValidFileExtension("Please upload only images jpg or png");

                }
            }
            else //MyFile is null
            {

                throw new NonValidFileExtension("The File is null and it can't be null :) ");
            }
        }
    }
}