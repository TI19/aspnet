using System;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Data;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

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

        Fill();

        //Tambahkan
        if (Request.QueryString["nomor"] != null
            || Request.QueryString["del"] != null
            || Request.QueryString["done"] != null)
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

        if (Request.QueryString["nomor"] != null)
        {
            if (Request.QueryString["del"] != null)
            {
                ClassConfig.Eksekusi("DELETE FROM biodata "
                                  + " WHERE MhsId = '" + Request.QueryString["nomor"] + "' ");
                Response.Redirect("Default.aspx?done=3");
            }

            DataTable sqlEdit = 
                ClassConfig.Call("SELECT * FROM biodata "
                               + " WHERE MhsId = " + Request.QueryString["nomor"]);

            for (int i = 0; i < sqlEdit.Rows.Count; i++)
            {
                if (!Response.IsClientConnected) break;

                var Edit = sqlEdit.Rows[i];

                if (!this.IsPostBack)
                {
                    txtNim.Text = Edit["Nim"].ToString();
                    txtNamaMhs.Text = Edit["Nama"].ToString();
                    ddlKelas.SelectedValue = Edit["Kelas"].ToString();
                    txtAlamatMhs.Text = Edit["Alamat"].ToString();
                    txtKotaMhs.Text = Edit["Kota"].ToString();
                    txtTempatLahir.Text = Edit["TempatLahir"].ToString();
                    txtTglLahir.Text = Convert.ToDateTime(Edit["TglLahir"]).ToString("yyyy-MM-dd");
                    rbKelas.SelectedValue = Edit["TipeKelas"].ToString();
                }
            }

            formtabel.Visible = true;
            save.Visible = false;
            edit.Visible = true;

        }
        else
        {
            save.Visible = true;
            edit.Visible = false;
        }

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

            //tambah
            c = new HtmlTableCell();
            btn = new HtmlInputButton();
            c.Attributes["Style"] = "width:100%;";
            btn.Value = "Edit";
            btn.Attributes["onclick"] = "popEdit(" + data["MhsId"].ToString() + ")";
            btn.Attributes["class"] = "btn btn-blue";
            btn.Attributes["Style"] = "width:100%; height: 30px; padding:5px;";
            c.Controls.Add(btn);
            r.Cells.Add(c);

            c = new HtmlTableCell();
            btn = new HtmlInputButton();
            c.Attributes["Style"] = "width:100%;";
            btn.Value = "Hapus";
            btn.Attributes["onclick"] = "popHapus(" + data["MhsId"].ToString() + ")";
            btn.Attributes["class"] = "btn btn-red";
            btn.Attributes["Style"] = "width:100%; height: 30px; padding:5px;";
            c.Controls.Add(btn);
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


    protected void edit_Click(object sender, EventArgs e)
    {
        string IdMhs = Request.QueryString["nomor"];
        string Nama = txtNamaMhs.Text;
        string Kelas = ddlKelas.SelectedValue;
        string Alamat = txtAlamatMhs.Text;
        string Kota = txtKotaMhs.Text;
        string TempatLahir = txtTempatLahir.Text;
        string TglLahir = Convert.ToDateTime(txtTglLahir.Text).ToString("yyyy-MM-dd");
        string TipeKelas = rbKelas.SelectedValue;

        ClassConfig.Eksekusi("UPDATE biodata SET "
                            + " Nama = '" + Nama + "'"
                            + ",Kelas = '" + Kelas + "'"
                            + ",Kota = '" + Kota + "'"
                            + ",Alamat = '" + Alamat + "'"
                            + ",TempatLahir = '" + TempatLahir + "'"
                            + ",TglLahir = '" + TglLahir + "'"
                            + ",TipeKelas = '" + TipeKelas + "'"
                            + " WHERE MhsId = '" + IdMhs + "';");

        Response.Redirect("Default.aspx?done=2");
    }

    
}