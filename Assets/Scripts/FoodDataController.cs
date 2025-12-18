using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;

public class FoodDataController : MonoBehaviour
{
    [Header("UI Components")]
    public GameObject panelInfo;
    public GameObject tombolInfo; 

    // Text Objects
    public TextMeshProUGUI txtJudulMakanan;
    public TextMeshProUGUI txtInfoNutrisi;
    public TextMeshProUGUI txtKomposisi;
    public TextMeshProUGUI txtAlergi;
    public TextMeshProUGUI txtHarga;

    // Variabel sementara untuk menyimpan data yang sedang aktif
    private MenuItemData dataAktif; 

    void Start()
    {
        // Reset tampilan awal
        SembunyikanInfo();
    }

    void Update()
    {
        // Cek tombol Back/Escape menggunakan NEW INPUT SYSTEM
        if (Keyboard.current != null && Keyboard.current.escapeKey.wasPressedThisFrame)
        {
            Application.Quit();
        }
    }

    // --- FUNGSI BARU: Menerima Data dari Image Target ---
    public void UpdateTampilan(MenuItemData dataMasuk)
    {
        // 1. Simpan data
        dataAktif = dataMasuk;

        // 2. Update Teks dengan FORMAT RAPI (Rich Text)
        
        // JUDUL (Dibuat Besar & Bold)
        txtJudulMakanan.text = $"<size=120%><b>{dataAktif.namaMenu}</b></size>";

        // NUTRISI (Dibuat 2 Baris biar gak panjang ke samping)
        // Baris 1: Kalori
        // Baris 2: Protein | Lemak | Karbo
        txtInfoNutrisi.text = $"<size=80%>Kalori: {dataAktif.kalori} | Protein: {dataAktif.protein} | Lemak: {dataAktif.lemak} | Karbo: {dataAktif.karbo}</size>";

        // KOMPOSISI (Judul di atas, isi di bawahnya)
        txtKomposisi.text = $"<b>Komposisi:</b>\n{dataAktif.komposisi}";

        // ALERGI (Pakai warna merah buat peringatan)
        txtAlergi.text = $"<color=yellow><b>Info Alergi:</b></color>\n{dataAktif.infoAlergi}";

        // HARGA (Besar di bawah)
        txtHarga.text = $"<size=120%><b>{dataAktif.harga}</b></size>";

        // 3. Munculkan Tombol
        tombolInfo.SetActive(true);
    }

    // --- FUNGSI LAMA: Dipanggil Tombol UI ---
    public void ToggleInfo()
    {
        bool isActive = panelInfo.activeSelf;
        panelInfo.SetActive(!isActive);
    }

    // --- FUNGSI BARU: Reset saat hilang ---
    public void SembunyikanInfo()
    {
        tombolInfo.SetActive(false);
        panelInfo.SetActive(false);
    }
}
