using System;
using System.Collections.Generic;

namespace PraktikumStream
{
    [Serializable]
    public class Mahasiswa
    {
        public int NIM { get; set; }
        public string Nama { get; set; }
        public string Jurusan { get; set; }
        public List<string> Matakuliah { get; set; }

        // Constructor kosong wajib untuk serialisasi XML
        public Mahasiswa() { }

        public Mahasiswa(int nim, string nama, string jurusan, List<string> matkul)
        {
            NIM = nim;
            Nama = nama;
            Jurusan = jurusan;
            Matakuliah = matkul;
        }

        public void TampilkanInfo()
        {
            Console.WriteLine($"NIM       : {NIM}");
            Console.WriteLine($"Nama      : {Nama}");
            Console.WriteLine($"Jurusan   : {Jurusan}");
            Console.WriteLine($"Matkul    : {string.Join(", ", Matakuliah)}");
            Console.WriteLine("-----------------------------------");
        }
    }
}