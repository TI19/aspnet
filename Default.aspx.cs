using System;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Data;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Fill();

        if (!IsPostBack)
        {
            Kelas(jurusan);
            Kelas(ddlKelas);
        }

        divNilai.Visible = false;
        divSegitiga.Visible = false;
        formMhs.Visible = false;
        formtabel.Visible = false;

        if (pilihmetode.Text == "1")
        {            
            divNilai.Visible = true;
        }
        else if (pilihmetode.Text == "2")
        {
            divSegitiga.Visible = true;
        }
        else if (pilihmetode.Text == "3")
        {
            formMhs.Visible = true;
        }
        else if (pilihmetode.Text == "4")
        {
            formtabel.Visible = true;
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


    private void Fill()
    {
        list.Controls.Clear();

        int b = 0;

        DataTable sql = ClassConfig.Call("SELECT * FROM biodata");

        for (int i = 0; i < sql.Rows.Count; i++)
        {
            if (!Response.IsClientConnected) break;

            var data = sql.Rows[i];

            string TTL = data["TempatLahir"].ToString();
            TTL += ",<br/> " + Convert.ToDateTime(data["TglLahir"]).ToString("dd-MM-yyyy");
            
            b++;
            Label l;
            TextBox t;
            HtmlInputButton btn;
            HtmlTableCell c;
            HtmlTableRow r;

            r = new HtmlTableRow();

            c = new HtmlTableCell();
            l = new Label();
            l.Text = (i + 1).ToString();
            c.Controls.Add(l);
            r.Cells.Add(c);

            c = new HtmlTableCell();
            l = new Label();
            l.Text = "(" + data["Nim"].ToString() + ") <br/>" + data["Nama"].ToString();
            c.Controls.Add(l);
            r.Cells.Add(c);

            c = new HtmlTableCell();
            l = new Label();
            l.Text = TTL;
            c.Controls.Add(l);
            r.Cells.Add(c);

            c = new HtmlTableCell();
            l = new Label();
            l.Text = data["Kelas"].ToString() + "<br/>(" + data["TipeKelas"].ToString() + ")";
            c.Controls.Add(l);
            r.Cells.Add(c);

            c = new HtmlTableCell();
            l = new Label();
            l.Text = data["Alamat"].ToString();
            c.Controls.Add(l);
            r.Cells.Add(c);

            c = new HtmlTableCell();
            l = new Label();
            l.Text = data["Kota"].ToString();
            c.Controls.Add(l);
            r.Cells.Add(c);

            list.Controls.Add(r);
        }
    }


    protected void save_Click(object sender, EventArgs e)
    {
        string Nim = txtNim.Text;
        string Nama = txtNamaMhs.Text;
        string Kelas = ddlKelas.SelectedValue;
        string Kota = txtKotaMhs.Text;
        string Alamat = txtAlamatMhs.Text;
        string TempatLahir = txtTempatLahir.Text;
        string TglLahir = Convert.ToDateTime(txtTglLahir.Text).ToString("yyyy-MM-dd");
        string TipeKelas = rbKelas.SelectedValue;
        
        ClassConfig.Eksekusi("INSERT INTO biodata "
                            + " (Nim, Nama, Kelas, Kota, Alamat, TempatLahir, TglLahir, TipeKelas) "
                            + "   VALUES ("
                            + "'" + Nim + "'"
                            + ",'" + Nama + "'"
                            + ",'" + Kelas + "'"
                            + ",'" + Kota + "'"
                            + ",'" + Alamat + "'"
                            + ",'" + TempatLahir + "'"
                            + ",'" + TglLahir + "'"
                            + ",'" + TipeKelas + "'"
                            + ");");

        Response.Redirect("Default.aspx?done=1");

    }
    
}