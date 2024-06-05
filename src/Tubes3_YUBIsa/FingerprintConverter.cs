// using System.Text;

// // Konversi Gambar Fingerprint ke Pixel
// Bitmap fingerprintImage = new Bitmap("1__M_Left_index_finger.BMP"); // Ubah "fingerprint.jpg" dengan path gambar sidik jari
// int[,] grayscalePixels = new int[fingerprintImage.Width, fingerprintImage.Height];

// for (int x = 0; x < fingerprintImage.Width; x++)
// {
//     for (int y = 0; y < fingerprintImage.Height; y++)
//     {
//         Color pixelColor = fingerprintImage.GetPixel(x, y);
//         int grayscaleValue = (int)(pixelColor.R * 0.3 + pixelColor.G * 0.59 + pixelColor.B * 0.11);
//         grayscalePixels[x, y] = grayscaleValue;
//     }
// }

// // Konversi Pixel ke Binary
// int threshold = 128; // batas untuk konversi
// StringBuilder binaryStringBuilder = new StringBuilder();

// for (int y = 0; y < fingerprintImage.Height; y++)
// {
//     for (int x = 0; x < fingerprintImage.Width; x++)
//     {
//         if (grayscalePixels[x, y] < threshold)
//         {
//             binaryStringBuilder.Append("0");
//         }
//         else
//         {
//             binaryStringBuilder.Append("1");
//         }
//     }
// }

// string binaryData = binaryStringBuilder.ToString();

// // Konversi Binary ke ASCII
// StringBuilder asciiStringBuilder = new StringBuilder();

// for (int i = 0; i < binaryData.Length; i += 8)
// {
//     string binaryChunk = binaryData.Substring(i, 8);
//     int asciiValue = Convert.ToInt32(binaryChunk, 2);
//     char asciiChar = (char)asciiValue;
//     asciiStringBuilder.Append(asciiChar);
// }

// string asciiData = asciiStringBuilder.ToString();

// Console.WriteLine("ASCII data: " + asciiData);
