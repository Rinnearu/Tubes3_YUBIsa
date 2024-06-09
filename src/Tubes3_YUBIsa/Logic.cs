using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Drawing;

namespace Tubes3_YUBIsa
{
    internal class Logic
    {

    }
    
    class ImageResizer
    {
        public static Bitmap ResizeImageWithBlackBars(Image image, int targetWidth, int targetHeight)
        {
            // Calculate the new dimensions while maintaining the aspect ratio
            float aspectRatio = (float)image.Width / image.Height;
            int newWidth, newHeight;
            if (aspectRatio > 1) // Landscape
            {
                newWidth = targetWidth;
                newHeight = (int)(targetWidth / aspectRatio);
            }
            else // Portrait or square
            {
                newHeight = targetHeight;
                newWidth = (int)(targetHeight * aspectRatio);
            }

            // Create a new bitmap with the desired resolution
            Bitmap newImage = new Bitmap(targetWidth, targetHeight);
            using (Graphics graphics = Graphics.FromImage(newImage))
            {
                // Fill the background with black
                graphics.Clear(Color.Black);

                // Draw the resized image onto the new bitmap
                int offsetX = (targetWidth - newWidth) / 2;
                int offsetY = (targetHeight - newHeight) / 2;
                graphics.DrawImage(image, offsetX, offsetY, newWidth, newHeight);
            }

            return newImage;
        }
        public static Bitmap StretchImageToResolution(Image image, int targetWidth, int targetHeight)
        {
            // Create a new bitmap with the desired resolution
            Bitmap newImage = new Bitmap(targetWidth, targetHeight);
            using (Graphics graphics = Graphics.FromImage(newImage))
            {
                // Draw the stretched image onto the new bitmap
                graphics.DrawImage(image, 0, 0, targetWidth, targetHeight);
            }

            return newImage;
        }
    }
    class FingerprintProcessor
    {
        public static Bitmap ExtractCenterImage(Image image, int cropWidth, int cropHeight)
        {
            // Calculate the center point
            int centerX = image.Width / 2;
            int centerY = image.Height / 2;

            // Calculate the start point of the crop area
            int startX = Math.Max(centerX - cropWidth / 2, 0);
            int startY = Math.Max(centerY - cropHeight / 2, 0);

            // Ensure the crop area does not exceed the bounds of the image
            if (startX + cropWidth > image.Width)
                cropWidth = image.Width - startX;
            if (startY + cropHeight > image.Height)
                cropHeight = image.Height - startY;

            // Create a new bitmap for the cropped area
            Bitmap croppedImage = new Bitmap(cropWidth, cropHeight);
            using (Graphics graphics = Graphics.FromImage(croppedImage))
            {
                graphics.DrawImage(image, new Rectangle(0, 0, cropWidth, cropHeight), new Rectangle(startX, startY, cropWidth, cropHeight), GraphicsUnit.Pixel);
            }

            return croppedImage;
        }
        public static byte[,] ConvertImageToBinary(string imagePath)
        {
            using (Bitmap image = new Bitmap(imagePath))
            {
         

                int width = image.Width;
                int height = image.Height;
                byte[,] binaryImage = new byte[height, width];

                for (int y = 0; y < height; y++)
                {
                    for (int x = 0; x < width; x++)
                    {
                        Color pixelColor = image.GetPixel(x, y);
                        int grayValue = (pixelColor.R + pixelColor.G + pixelColor.B) / 3;
                        binaryImage[y, x] = (byte)(grayValue > 128 ? 1 : 0);
                    }
                }

                return binaryImage;
            }
        }
        public static byte[,] ConvertImageToBinaryCenter(string imagePath)
        {
            using (Bitmap image = new Bitmap(imagePath))
            {
                // Extract the center 30x30 pixels of the image
                //Bitmap centerImage = ExtractCenterImage(image, 30, 30);

                int width = 30;
                int height = 30;
                byte[,] binaryImage = new byte[height, width];
                int yasli = 0;
                int xax = 0;
                for (int y = image.Height / 2 - 15; y < image.Height / 2 + 15; y++)
                {
                    for (int x = image.Width / 2 - 15; x < image.Width / 2 + 15; x++)
                    {
                        Color pixelColor = image.GetPixel(x, y);
                        int grayValue = (pixelColor.R + pixelColor.G + pixelColor.B) / 3;
                        binaryImage[yasli, xax] = (byte)(grayValue > 128 ? 1 : 0);
                        xax++;
                    }
                    xax = 0;
                    yasli++;
                }

                return binaryImage;
            }
        }
        public static Bitmap BinaryToBitmap(byte[,] binaryImage)
        {
            int height = binaryImage.GetLength(0);
            int width = binaryImage.GetLength(1);
            Bitmap bitmap = new Bitmap(width, height);

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    Color color = binaryImage[y, x] == 1 ? Color.White : Color.Black;
                    bitmap.SetPixel(x, y, color);
                }
            }

            return bitmap;
        }

    }

    class BinaryToAsciiConverter
    {
        public static string ConvertToAscii(byte[,] binaryImage)
        {
            StringBuilder asciiString = new StringBuilder();

            for (int y = 0; y < binaryImage.GetLength(0); y++)
            {
                for (int x = 0; x < binaryImage.GetLength(1); x += 8)
                {
                    byte asciiValue = 0;
                    for (int bit = 0; bit < 8; bit++)
                    {
                        if (x + bit < binaryImage.GetLength(1))
                        {
                            asciiValue = (byte)(asciiValue << 1 | binaryImage[y, x + bit]);
                        }
                    }
                    asciiString.Append((char)asciiValue);
                }
            }

            return asciiString.ToString();
        }
        public static byte[,] AsciiToBinary(string asciiString, int height, int width)
        {
            byte[,] binaryImage = new byte[height, width];
            int index = 0;

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x += 8)
                {
                    if (index < asciiString.Length)
                    {
                        byte asciiValue = (byte)asciiString[index++];
                        for (int bit = 0; bit < 8; bit++)
                        {
                            if (x + bit < width)
                            {
                                binaryImage[y, x + bit] = (byte)((asciiValue >> (7 - bit)) & 1);
                            }
                        }
                    }
                }
            }

            return binaryImage;
        }
    }

    class KMPAlgorithm
    {
        public static int[] ComputeLPSArray(string pattern)
        {
            int length = 0;
            int i = 1;
            int[] lps = new int[pattern.Length];
            lps[0] = 0;

            while (i < pattern.Length)
            {
                if (pattern[i] == pattern[length])
                {
                    length++;
                    lps[i] = length;
                    i++;
                }
                else
                {
                    if (length != 0)
                    {
                        length = lps[length - 1];
                    }
                    else
                    {
                        lps[i] = 0;
                        i++;
                    }
                }
            }
            return lps;
        }

        public static int KMPSearch(string text, string pattern)
        {
            int[] lps = ComputeLPSArray(pattern);
            int i = 0;
            int j = 0;

            while (i < text.Length)
            {
                if (pattern[j] == text[i])
                {
                    i++;
                    j++;
                }

                if (j == pattern.Length)
                {
                    return i - j; // Match found
                }
                else if (i < text.Length && pattern[j] != text[i])
                {
                    if (j != 0)
                    {
                        j = lps[j - 1];
                    }
                    else
                    {
                        i++;
                    }
                }
            }

            return -1; // No match found
        }
    }

    class BoyerMooreAlgorithm
    {
        private static int[] ComputeBadCharacterTable(string pattern)
        {
            int[] badCharTable = new int[256];
            for (int i = 0; i < badCharTable.Length; i++)
            {
                badCharTable[i] = pattern.Length;
            }
            for (int i = 0; i < pattern.Length - 1; i++)
            {
                badCharTable[(int)pattern[i]] = pattern.Length - 1 - i;
            }
            return badCharTable;
        }

        public static int BoyerMooreSearch(string text, string pattern)
        {
            int[] badCharTable = ComputeBadCharacterTable(pattern);
            int skip;

            for (int i = 0; i <= text.Length - pattern.Length; i += skip)
            {
                skip = 0;
                for (int j = pattern.Length - 1; j >= 0; j--)
                {
                    if (pattern[j] != text[i + j])
                    {
                        skip = Math.Max(1, badCharTable[text[i + j]] - (pattern.Length - 1 - j));
                        break;
                    }
                }
                if (skip == 0)
                {
                    return i; // Match found
                }
            }

            return -1; // No match found
        }
    }

    class HammingDistanceCalculator
    {
        public static int ComputeHammingDistance(string str1, string str2)
        {
            int distance = 0;
            if (str1.Length != str2.Length)
            {
                int jarak = str1.Length - str2.Length;
                if (jarak < 0)
                {
                    jarak = jarak * -1;
                }
                distance += jarak;
            }

            for (int i = 0; i < str1.Length; i++)
            {
                if (str1[i] != str2[i])
                {
                    distance++;
                }
            }
            return distance;
        }
    }
    class LCSC
    {
        static int LCSLength(string str1, string str2)
        {
            int m = str1.Length;
            int n = str2.Length;
            int[,] dp = new int[m + 1, n + 1];

            for (int i = 0; i <= m; i++)
            {
                for (int j = 0; j <= n; j++)
                {
                    if (i == 0 || j == 0)
                    {
                        dp[i, j] = 0;
                    }
                    else if (str1[i - 1] == str2[j - 1])
                    {
                        dp[i, j] = dp[i - 1, j - 1] + 1;
                    }
                    else
                    {
                        dp[i, j] = Math.Max(dp[i - 1, j], dp[i, j - 1]);
                    }
                }
            }

            return dp[m, n];
        }

        static string LCSString(string str1, string str2)
        {
            int m = str1.Length;
            int n = str2.Length;
            int[,] dp = new int[m + 1, n + 1];

            for (int i = 0; i <= m; i++)
            {
                for (int j = 0; j <= n; j++)
                {
                    if (i == 0 || j == 0)
                    {
                        dp[i, j] = 0;
                    }
                    else if (str1[i - 1] == str2[j - 1])
                    {
                        dp[i, j] = dp[i - 1, j - 1] + 1;
                    }
                    else
                    {
                        dp[i, j] = Math.Max(dp[i - 1, j], dp[i, j - 1]);
                    }
                }
            }

            int index = dp[m, n];
            char[] lcs = new char[index];
            int x = m, y = n;

            while (x > 0 && y > 0)
            {
                if (str1[x - 1] == str2[y - 1])
                {
                    lcs[index - 1] = str1[x - 1];
                    x--;
                    y--;
                    index--;
                }
                else if (dp[x - 1, y] > dp[x, y - 1])
                {
                    x--;
                }
                else
                {
                    y--;
                }
            }

            return new string(lcs);
        }

        public static double CalculateSimilarity(string str1, string str2)
        {
            int lcsLength = LCSLength(str1, str2);
            return (2.0 * lcsLength) / (str1.Length + str2.Length);
        }
    }

    class Test
    {
        static void test(string[] args) //Ubah ke MAIN KALO MAU TEST PAKE CLI
        {
            string imagePath = "C:\\Users\\User\\OneDrive - Institut Teknologi Bandung\\Pictures\\bh3rd\\2022-09-30-13-27-57_0.png"; // Change this path to your image file
            byte[,] binaryImage = FingerprintProcessor.ConvertImageToBinary(imagePath);
            string asciiString = BinaryToAsciiConverter.ConvertToAscii(binaryImage);

            // Example fingerprint pattern to search
            string image2 = "C:\\Users\\User\\OneDrive - Institut Teknologi Bandung\\Pictures\\bh3rd\\2022-09-30-13-28-05_0.png";
            byte[,] binaryImag2e = FingerprintProcessor.ConvertImageToBinary(image2);
            string ascii2 = BinaryToAsciiConverter.ConvertToAscii(binaryImag2e);

            // KMP Search
            int kmpResult = KMPAlgorithm.KMPSearch(asciiString, ascii2);
            Console.WriteLine("KMP Search Result: " + kmpResult);

            // Boyer-Moore Search
            int bmResult = BoyerMooreAlgorithm.BoyerMooreSearch(asciiString, ascii2);
            Console.WriteLine("Boyer-Moore Search Resul t: " + bmResult);

            // Example strings for Hamming Distance
            double hammingDistance = LCSC.CalculateSimilarity(asciiString, ascii2);
            Console.WriteLine("similarity: " + hammingDistance*100);
        }
    }

}
