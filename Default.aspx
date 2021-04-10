<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
      <%--tambahkan css--%>
      <link href="assets/style.css" rel="stylesheet" type="text/css" />  
</head>
<body>
    <form id="form1" runat="server" >
    
    Pilih Form Materi
    <asp:DropDownList ID="pilihmetode" runat="server" AutoPostBack="true">
            <asp:ListItem Value="">-- Pilih Materi --</asp:ListItem>
            <asp:ListItem Value="1">Form Nilai</asp:ListItem>    
            <asp:ListItem Value="2">Form Segitiga</asp:ListItem>    
            <asp:ListItem Value="3">Form Biodata Mahasiswa</asp:ListItem>
            <asp:ListItem Value="4">View Data Mahasiswa</asp:ListItem>
    </asp:DropDownList>
    
    <div id="divNilai" runat="server" visible="false">
        <br />
        Nilai 1: 
            <asp:TextBox ID="txt1" runat="server" ></asp:TextBox>
        <br /><br />
        Nilai 2: 
            <asp:TextBox ID="txt2" runat="server" ></asp:TextBox>
        <br /><br />
            <asp:Button ID="btn1" runat="server" Text="Cek" OnClick="btn1_Click"/>
        &nbsp;
        Hasil: 
            <asp:Label ID="hasilnya" runat="server"></asp:Label>
    </div>
    
    <div id="divSegitiga" runat="server" visible="false">
        Mencari Luas Segitiga
        <br />
        Alas: 
            <asp:TextBox ID="txtAlas" runat="server" ></asp:TextBox>
        <br /><br />
        Tinggi: 
            <asp:TextBox ID="txtTinggi" runat="server" ></asp:TextBox>
        <br /><br />
            <asp:Button ID="btnLuas" runat="server" Text="Hitung Luas Segitiga" OnClick="hitungLuas"/>
        &nbsp;
        Hasil: 
            <asp:Label ID="hasilLuas" runat="server"></asp:Label>
    </div>
    
    <div id="formMhs" runat="server" visible="false">
             <p>Form Biodata Mahasiswa</p>
        <table cellpadding="2" cellspacing="4" style="border-collapse: collapse" width="100%">
                    <tr>
                        <td style="width: 150px">Nama</td>
                        <td>:</td>
                        <td><asp:TextBox ID="namamhs" runat="server" Width="100" /></td>
                    </tr>
                    <tr>
                        <td style="width: 150px">Tempat / Tgl Lahir</td>
                        <td>:</td>
                        <td>
                            <asp:TextBox ID="kotalahir" runat="server" />
                             / 
                            <asp:TextBox ID="Date" runat="server" textmode="Date" />
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 150px">Jurusan</td>
                        <td>:</td>
                        <td><asp:DropDownList ID="jurusan" runat="server">
                            </asp:DropDownList></td>
                    </tr>
                    <tr>
                        <td style="width: 100px">
                            <asp:Button ID="btnSoal" runat="server" Text="Get Data" OnClick="getDataSoal" />
                            &nbsp;
                        
                        </td>
                    </tr>
                </table>
                <br />
                <asp:Label ID="feedSoal" runat="server" />
        </div>

    <div id="formtabel" runat="server">
        <br />
        <table cellspacing="1">
            <tr align="left" valign="bottom">
                <td style="width: 30%;">NIM</td>
                <td style="width: 1%;">:</td>
                <td>
                    <asp:TextBox ID="txtNim" runat="server" Width="100%" CssClass="txt" />
                </td>
            </tr>
            <tr align="left" valign="bottom">
                <td style="width: 30%;">Nama</td>
                <td style="width: 1%;">:</td>
                <td>
                    <asp:TextBox ID="txtNamaMhs" runat="server" Width="100%" CssClass="txt" />
                </td>
            </tr>
            <tr align="left" valign="bottom">
                <td style="width: 30%;">Tempat / 
                    Tgl Lahir</td>
                <td style="width: 1%;">:</td>
                <td>
                    <asp:TextBox ID="txtTempatLahir" runat="server" Width="100%" CssClass="txt" />
                </td>
            </tr>
            <tr>
                <td colspan="2"></td>
                <td>
                    Tanggal
                    &nbsp;
                    <asp:TextBox ID="txtTglLahir" runat="server" CssClass="txt" textmode="Date" />
                </td>
            </tr>
            <tr>
                <td>Kelas
                </td>
                <td>:</td>
                <td>
                    <asp:DropDownList ID="ddlKelas" runat="server" Width="100%" CssClass="ddl">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td colspan="2"></td>
                <td>
                    <asp:RadioButtonList ID="rbKelas" runat="server" CssClass="rbl">
                        <asp:ListItem Value="Reguler">Reguler</asp:ListItem>
                        <asp:ListItem Value="Karyawan">Karyawan</asp:ListItem>
                    </asp:RadioButtonList>
                </td>
            </tr>
            <tr>
                <td>Alamat</td>
                <td>:</td>
                <td>
                    <asp:TextBox ID="txtAlamatMhs" runat="server" Width="100%" Height="50" TextMode="MultiLine" />
                </td>
            </tr>
            <tr>
                <td>Kota</td>
                <td>:</td>
                <td>
                    <asp:TextBox ID="txtKotaMhs" runat="server" Width="100%" /></td>
            </tr>
        </table>
        <br />
        <asp:LinkButton ID="save" runat="server" Width="75" CssClass="btn btn-orange" OnClick="save_Click">Simpan</asp:LinkButton>
        
        <br /><br />
        <table cellspacing="1" class="tb blue-skin">
            <tr align="left" valign="bottom">
                <th>No. </th>
                <th width="150">NIM /<br />
                    Nama Mahasiswa</th>
                <th width="100">Tempat / Tgl.Lahir</th>
                <th>Kelas</th>
                <th>Alamat</th>
                <th>Kota</th>
            </tr>
            <asp:PlaceHolder ID="list" runat="server"></asp:PlaceHolder>
        </table>
    </div>
    
</form> 
</body>
</html>
