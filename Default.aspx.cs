using System;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Kelas(jurusan);
        }
        
    }

    protected void btn1_Click(object sender, EventArgs e)
    {
        string hasil = "";
        if (Convert.ToDecimal(txt1.Text) > Convert.ToDecimal(txt2.Text))
        {
            hasil = txt1.Text + " adalah Nilai tertinggi.";
        }
        else
        {
            hasil = txt2.Text + " adalah Nilai tertinggi.";
        }

        hasilnya.Text = hasil;
    }

    protected void hitungLuas(object sender, EventArgs e)
    {
        // Rumus luas segitiga
        // (Alas * Tinggi) / 2

        Decimal luassegitiga = 0;
        Decimal Alas = Convert.ToDecimal(txtAlas.Text);
        Decimal Tinggi = Convert.ToDecimal(txtTinggi.Text);

        luassegitiga = (Alas * Tinggi) / 2;
        //konversi ke string
        hasilLuas.Text = " Hasil Luas Segitiga = " + Convert.ToString(luassegitiga);
    }

    //DATA MAHASISWA

    public static void Bulan(DropDownList container)
    {
        string[] namaBulan = {
              "Januari"
            , "Februari"
            , "Maret"
            , "April"
            , "Mei"
            , "Juni"
            , "Juli"
            , "Agustus"
            , "September"
            , "Oktober"
            , "November"
            , "Desember"
            };

        for (int i = 0; i < namaBulan.Length; i++)
        {
            container.Items.Add(new ListItem(namaBulan[i], namaBulan[i]));
        }
    }

    public static void Kelas(DropDownList container)
    {
        string[] listKelas = {
              "Teknik Informatika"
            , "Sistem Informasi"
            };

        for (int i = 0; i < listKelas.Length; i++)
        {
            container.Items.Add(new ListItem(listKelas[i], listKelas[i]));
        }
    }

    protected void getDataSoal(object sender, EventArgs e)
    {
        feedSoal.Text = "Nama Mahasiswa : " + namamhs.Text + " <br/>"
            + "Tgl Lahir : " + Date.Text + " <br/>"
            + "Jurusan : " + jurusan.Text
            ;
    }
    

}