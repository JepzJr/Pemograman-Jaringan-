import json
import mahasiswa_pb2  # Memanggil file hasil kompilasi protoc

# Data mentah yang akan dikirim melalui jaringan
data_mentah = {
    "nim": 241313100,
    "nama": "Jefri Ramadhan",
    "ipk": 4.0
}

print("=== PROSES DI SISI PENGIRIM (SERVER/CLIENT) ===\n")

# 1. SIMULASI JSON (TEKS)
json_string = json.dumps(data_mentah)
payload_json_bytes = json_string.encode('utf-8')
print(f"[JSON] String yang dikirim: {json_string}")
print(f"[JSON] Ukuran Payload Jaringan: {len(payload_json_bytes)} bytes\n")

# 2. SIMULASI PROTOBUF (BINER)
mhs_proto = mahasiswa_pb2.PaketMahasiswa()
mhs_proto.nim = data_mentah["nim"]
mhs_proto.nama = data_mentah["nama"]
mhs_proto.ipk = data_mentah["ipk"]
payload_proto_bytes = mhs_proto.SerializeToString()
print(f"[Protobuf] Data Biner (Raw): {payload_proto_bytes}")
print(f"[Protobuf] Ukuran Payload Jaringan: {len(payload_proto_bytes)} bytes\n")

print("==================================================")
print(f"KESIMPULAN: Protobuf lebih hemat {len(payload_json_bytes) - len(payload_proto_bytes)} bytes dibanding JSON!")
print("==================================================\n")

print("=== PROSES DI SISI PENERIMA (DESERIALISASI) ===")
data_masuk_jaringan = payload_proto_bytes
objek_diterima = mahasiswa_pb2.PaketMahasiswa()
objek_diterima.ParseFromString(data_masuk_jaringan)

print("Berhasil membaca data dari socket!")
print(f"Nama Mahasiswa : {objek_diterima.nama}")
print(f"NIM            : {objek_diterima.nim}")
print(f"IPK            : {objek_diterima.ipk}")