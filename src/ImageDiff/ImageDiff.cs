using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ImageMagick;
using System.IO;

namespace Imagere
{
    class ImageDiff
    {

        // folders
        public String CurrentImageFolder { get; set; }
        public String BaselineImageFolder { get; set; }
        public String DiffImageFolder { get; set; }


        // compare options



        // constructor

        public ImageDiff(String currentImageFolder, String baselineImageFolder, String DiffImageFolder)
        {

        }
        static void Main(string[] args)
        {
        }

        public void CompareFile(String imageFileName)
        {
            var currentImage = new MagickImage(PathCombine(CurrentImageFolder, imageFileName));
            var baselineImage = new MagickImage(PathCombine(BaselineImageFolder, imageFileName));
            try
            {

                using (var diff = new MagickImage())
                {
                    currentImage.Compare(baselineImage, ErrorMetric.PeakAbsolute, diff);
                }
            }
            catch (Exception ex)
            {
                throw;
            }



        }


        private String PathCombine(String dir, String fileName)
        {
            if (Path.GetFileName(fileName) != fileName)
            {
                throw new Exception("'fileName' is invalid!");
            }


            return Path.Combine(dir, Path.GetFileName(fileName));
        }


    }
}
