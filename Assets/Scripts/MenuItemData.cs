using UnityEngine;

public class MenuItemData : MonoBehaviour
{
    [Header("Data Spesifik Makanan Ini")]
    public string namaMenu;
    public string kalori;
    public string protein;
    public string lemak;
    public string karbo;
    [TextArea] public string komposisi;
    public string infoAlergi;
    public string harga;

    [Header("Hubungkan ke AR Manager")]
    public FoodDataController uiManager; // Kita butuh akses ke script lamamu

    // Fungsi ini dipanggil otomatis oleh Vuforia saat Target Ketemu
    public void OnFound()
    {
        // Kirim data diri sendiri (this) ke UI Manager untuk ditampilkan
        uiManager.UpdateTampilan(this);
    }

    // Fungsi ini dipanggil saat Target Hilang
    public void OnLost()
    {
        uiManager.SembunyikanInfo();
    }
}