﻿namespace GlobalConstants
{
    using System.Web.Hosting;

    public class ServicesConstants
    {
        public const string IMAGES_PREFIX_FROM_ROOT = "Content\\Uploads\\Images\\";

        public const int MAX_FILES_IN_DIRECTORY = 20;

        public static readonly string APP_ROOT_PATH = HostingEnvironment.ApplicationPhysicalPath;

        public static readonly string ROOT_IMAGES_FOLDER = APP_ROOT_PATH + "Content\\Uploads\\Images\\";
    }
}
