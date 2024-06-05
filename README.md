# Tubes3_YUBIsa
> **Welcome to Tubes 3 YUBIsa team Repository**
> Solution yang terdapat pada folder src merupakan aplikasi untuk mencari fingerprint yang sesuai dengan gambar yang dimasukkan menggunakan dataset [_Sokoto Coventry Fingerprint Dataset (SOCOFing)_](https://www.kaggle.com/datasets/ruizgara/socofing).
> Kemudian terdapat juga folder dtbs yang berisi dump dari basis data SQL yang digunakan dan folder doc yang merupakan laporan yang telah dibuat.

## Daftar Isi
* [Deskripsi Aplikasi](#deskripsi-aplikasi)
* [Penjelasan Singkat Implementasi Algoritma](#penjelasan-singkat-implementasi-algoritma)
* [Kebutuhan Pembangunan dan Penjalanan Aplikasi](#kebutuhan-pembangunan-dan-penjalanan-aplikasi)
* [Kebutuhan Sebelum Menjalankan](#kebutuhan-sebelum-menjalankan)
* [Cara Membangun dan Menjalankan Aplikasi](#cara-membangun-dan-menjalankan-aplikasi)
* [Identitas Pembuat](#identitas-pembuat)

## Deskripsi Aplikasi
> Aplikasi akan menerima input gambar dari pengguna, kemudian mengubah gambar tersebut ke dalam format binary, setelah itu gambar akan diubah kembali menjadi ASCII yang kemudian akan dicocokkan dengan berkas_citra yang dimiliki basis data menggunakan algoritma pencocokan string KMP (Knuth–Morris–Pratt) dan BM (Boyer–Moore) sesuai dengan keinginan pengguna
> Jika tidak menemukan melalui kedua algoritma tersebut, pencocokan string akan dilakukan secara hamming distance yang akan mencari berkas citra yang paling serupa dengan gambar yang dimasukkan

## Penjelasan Singkat Implementasi Algoritma
### Knuth–Morris–Pratt Algorithm
>
### Boyer-Moore Algorithm
>
### Regular Expression
> Regular expression digunakan ketika akan mengambil biodata melalui nama. Pada biodata, nama bisa mengalami korupsi data sehingga tidak sesuai dengan format yang biasanya. Jadi ketika sudah mendapatkan berkas-citra tertentu, nama yang terasosiasi dengan citra tersebut akan diubah menjadi suatu pola regex tertentu yang akan digunakan dalam query SQL untuk mencarinya di database SQL

## Kebutuhan Pembangunan dan Penjalanan Aplikasi
- dotnet
- Basis data berbasis MySQL (Aplikasi yang dibuat utamanya menggunakan MariaDB)
- (OPSIONAL) Visual Studio
- (OPSIONAL) Aplikasi Manajemen Database (HeidiSQL untuk MariaDB)

## Kebutuhan Sebelum Menjalankan
- Pada solution, terdapat App.config
'''bash
    <?xml version="1.0" encoding="utf-8" ?>
    <configuration>
        <connectionStrings>
            <add name="Default"
                connectionString="Server=ServerName;Database=DataBase;Uid=UserName;Pwd=Password;"
                providerName="MySql.Data.MySqlClient" />
        </connectionStrings>
    </configuration>
'''
Ubah ServerName, DataBaseName, UserName, dan Password sesuai dengan basis data yang ingin diakses
- Pada basis data yang dituju, isi juga database tersebut dengan file sql dump yang terdapat pada folder "dtbs"

## Cara Membangun dan Menjalankan Aplikasi
1. Pergi ke direktori ~/src (Di terminal maupun tidak)
'''bash
    cd src
'''
2. Jika memiliki Visual Studio, buka solution TUBES3_YUBIsa.sln dengan Visual Studio
3. Pada terminal masukkan perintah-perintah berikut
'''bash
    dotnet restore
    dotnet build
'''
4. Jika dilakukan pada Visual Studio, Anda bisa langsung menekan tombol mulai yang disediakan.
5. Jika tidak dilakukan dengan Visual Studio, masuk ke direktori TUBES3_YUBIsa dan jalankan file berekstensi .csproj dengan
'''bash
    cd TUBES_YUBIsa
    dotnet run
'''

## Identitas Pembuat
1. Ahmad Farid Mudrika - 13522008
2. Chelvadinda - 13522154
3. Rayhan Ridhar Rahman - 13522160