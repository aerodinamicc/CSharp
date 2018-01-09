﻿using System;
using System.Globalization;
using System.IO;
using System.Windows.Data;
using System.Windows.Media.Imaging;

namespace WpfWindowsBrowser
{
    [ValueConversion(typeof(string), typeof(BitmapImage))]

    public class HeaderToImageConverter : IValueConverter
    {
        public static HeaderToImageConverter Instance = new HeaderToImageConverter();

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var path = (string)value;

            if (path == null)
            {
                return null;
            }

            var image = "/Images/file.jpg";

            var name = DirectoryStructure.GetFolderName(path);

            if (string.IsNullOrEmpty(name))
            {
                image = "/Images/drive.jpg";
            }
            else if (new FileInfo(path).Attributes.HasFlag(FileAttributes.Directory))
            {
                image = "/Images/folder.jpg";
            }
            


            return new BitmapImage(new Uri($"pack://application:,,,{image}"));
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
