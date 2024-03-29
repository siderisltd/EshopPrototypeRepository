﻿namespace Eshop.Services.Common
{
    using System;
    using System.Drawing;
    using System.Drawing.Imaging;
    using System.IO;
    using System.Net;
    using Contracts;

    public class ImageHelper : IImageHelper
    {
        /// <summary>
        /// This method uses Internet connection to get the image as byte array. It cam be very easy modified to return
        /// it in MemoryStream
        /// </summary>
        /// <param name="url">imageUrl</param>
        /// <param name="longestSide">desired longest side</param>
        /// <param name="format">image format</param>
        /// <returns>byte array with the resized image</returns>
        public byte[] GetFromUrl(string url, int longestSide, ImageFormat format)
        {
            byte[] imgArray = this.GetFromUrl(url);
            byte[] resizedImgArray;

            using (MemoryStream stream = new MemoryStream())
            {
                // write the string to the stream
                stream.Write(imgArray, 0, imgArray.Length);

                // create the start Bitmap from the MemoryStream that contains the image
                Image startBitmap = new Bitmap(stream);
                resizedImgArray = this.ScaleImage(startBitmap, longestSide, format);
            }

            return resizedImgArray;
        }

        public byte[] GetFromUrl(string url, ImageFormat format)
        {
            byte[] imgArray = this.GetFromUrl(url);

            using (MemoryStream stream = new MemoryStream())
            {
                // write the string to the stream
                stream.Write(imgArray, 0, imgArray.Length);

                // create the start Bitmap from the MemoryStream that contains the image
                Image startBitmap = new Bitmap(stream);
                return this.ImageToByte(startBitmap, format);
            }
        }

        public byte[] GetFromUrlAndBrandImage(string url, ImageFormat format, Image brandImage)
        {
            byte[] imgArray = this.GetFromUrl(url);
            return this.AddBranding(imgArray, brandImage, format);
        }

        /// <summary>
        /// This method uses Internet connection to get the image as byte array. It cam be very easy modified to return
        /// it in MemoryStream
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public byte[] GetFromUrl(string url)
        {
            byte[] imageData = new byte[0];
            try
            {
                WebRequest req = WebRequest.Create(url);
                WebResponse response = req.GetResponse();
                using (Stream stream = response.GetResponseStream())
                {
                    byte[] buffer = new byte[1024];
                    using (MemoryStream memStream = new MemoryStream())
                    {
                        int bytesRead = stream.Read(buffer, 0, buffer.Length);
                        while (bytesRead > 0)
                        {
                            memStream.Write(buffer, 0, bytesRead);
                            bytesRead = stream.Read(buffer, 0, buffer.Length);
                        }

                        imageData = memStream.ToArray();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Getting the image causes a problem - image url : " + url);
                Console.WriteLine("EX type : " + ex.GetType());
                Console.WriteLine("EX message : " + ex.Message);
            }

            return imageData;
        }

        public byte[] ScaleImage(Image image, int longestSide, ImageFormat format)
        {
            return this.ScaleImage(image, longestSide, longestSide, format);
        }

        public byte[] ScaleImage(Image image, int maxWidth, int maxHeight, ImageFormat format)
        {
            var ratioX = (double)maxWidth / image.Width;
            var ratioY = (double)maxHeight / image.Height;
            var ratio = Math.Min(ratioX, ratioY);

            var newWidth = (int)(image.Width * ratio);
            var newHeight = (int)(image.Height * ratio);

            var newImage = new Bitmap(newWidth, newHeight);
            Graphics.FromImage(newImage).DrawImage(image, 0, 0, newWidth, newHeight);
            return this.ImageToByte(newImage, format);
        }

        public byte[] StreamToByteArray(Stream input)
        {
            byte[] buffer = new byte[16 * 1024];
            using (MemoryStream ms = new MemoryStream())
            {
                int read;
                while ((read = input.Read(buffer, 0, buffer.Length)) > 0)
                {
                    ms.Write(buffer, 0, read);
                }

                return ms.ToArray();
            }
        }

        public byte[] ImageToByte(Image img, ImageFormat format)
        {
            byte[] byteArray = new byte[0];
            using (MemoryStream stream = new MemoryStream())
            {
                img.Save(stream, format);
                stream.Close();

                byteArray = stream.ToArray();
            }

            return byteArray;
        }

        public Image ByteToImage(byte[] array)
        {
            using (var ms = new MemoryStream(array))
            {
                return Image.FromStream(ms);
            }
        }

        public Image AddBranding(string firstImagePath, string brandImagePath, int posX = 0, int posY = 0)
        {
            Image image = Image.FromFile(firstImagePath);
            Graphics gra = Graphics.FromImage(image);
            Image smallImg = Image.FromFile(brandImagePath);
            var brandImageHeight = (int)Math.Ceiling(image.Height / 3.1);
            gra.DrawImage(smallImg, posX, posY, image.Width, brandImageHeight);
            return image;
        }

        public Image AddBranding(Image originalImage, Image brandImage, int posX = 0, int posY = 0)
        {
            Graphics gra = Graphics.FromImage(originalImage);
            var brandImageHeight = (int)Math.Ceiling(originalImage.Height / 3.1);
            gra.DrawImage(brandImage, posX, posY, originalImage.Width, brandImageHeight);
            return originalImage;
        }

        public byte[] AddBranding(byte[] imgArray, Image brandImage, ImageFormat format)
        {
            using (MemoryStream stream = new MemoryStream())
            {
                stream.Write(imgArray, 0, imgArray.Length);
                Image startBitmap = new Bitmap(stream);
                var result = this.AddBranding(startBitmap, brandImage);

                return this.ImageToByte(result, format);
            }
        }
    }
}
