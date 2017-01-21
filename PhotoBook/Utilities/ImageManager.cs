using PhotoBook.Exceptions;
using System.IO;
using System.Linq;
using System.Web;

namespace PhotoBook.Utilities
{
    public class ImageManager : IImageStorage
    {

        private readonly string[] allowedExtensions = { ".jpg",".JPG", ".jpeg", ".JPEG", ".png",".PNG" };

        public void SaveImage(HttpPostedFileBase MyFile, string DirectorytoSave, string MyFilename, bool AddExtension=true)
        {

            if (MyFile != null && DirectorytoSave!=null && MyFilename!=null)
            {
                Directory.CreateDirectory(DirectorytoSave); //checking if the directory exists, otherwise it is created
                var fileExtension = Path.GetExtension(MyFile.FileName).ToLower(); //saving extension in lower case just because :)
                if (allowedExtensions.Contains(fileExtension))
                {
                    if(AddExtension)
                    {
                        MyFilename += fileExtension;
                    }
                    var filePath= Path.Combine(DirectorytoSave, MyFilename); // combining Directory with Filename
                    MyFile.SaveAs(filePath);
                }
                else //it has no valid extension
                {
                    throw new NonValidFileExtension("There was an error with your request. Please upload only images jpg or png");

                }
            }
            else //MyFile is null
            {

                throw new NonValidFileExtension("There was an error with your request. The File is null and it can't be null :) ");
            }

        }

        
    }
}