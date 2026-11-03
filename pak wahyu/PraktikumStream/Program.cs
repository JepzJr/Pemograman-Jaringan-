using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Xml.Serialization;

namespace PraktikumStream
{
    class Program
    {
        static void Main(string[] args)
        {
            // 1. Inisialisasi Objek Mahasiswa
            List<string> matkul = new List<string> { "Pemrograman Jaringan", "Kriptografi", "Sistem Terdistribusi" };
            Mahasiswa mhsAsli = new Mahasiswa(22001, "Jefri", "Teknologi Informasi", matkul);

            Console.WriteLine("=== OBJEK ASLI DARI MEMORI ===");
            mhsAsli.TampilkanInfo();

            // 2. Serialisasi JSON dan Simpan ke File Stream
            string jsonString = JsonSerializer.Serialize(mhsAsli, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText("mahasiswa.json", jsonString);
            Console.WriteLine("[LOG] Berkas 'mahasiswa.json' berhasil disimpan.\n");

            // 3. Serialisasi XML dan Simpan ke File Stream
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Mahasiswa));
            using (StringWriter writer = new StringWriter())
            {
                xmlSerializer.Serialize(writer, mhsAsli);
                File.WriteAllText("mahasiswa.xml", writer.ToString());
            }
            Console.WriteLine("[LOG] Berkas 'mahasiswa.xml' berhasil disimpan.\n");

            // 4. Pembacaan File Stream & Deserialisasi JSON
            Console.WriteLine("=== DESERIALISASI DARI FILE JSON ===");
            string jsonFromFile = File.ReadAllText("mahasiswa.json");
            Mahasiswa mhsFromJson = JsonSerializer.Deserialize<Mahasiswa>(jsonFromFile);
            mhsFromJson.TampilkanInfo();

            // 5. Pembacaan File Stream & Deserialisasi XML
            Console.WriteLine("=== DESERIALISASI DARI FILE XML ===");
            string xmlFromFile = File.ReadAllText("mahasiswa.xml");
            using (StringReader reader = new StringReader(xmlFromFile))
            {
                Mahasiswa mhsFromXml = (Mahasiswa)xmlSerializer.Deserialize(reader);
                mhsFromXml.TampilkanInfo();
            }
        }
    }
}