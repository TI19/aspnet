<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
      <link rel="stylesheet" href="//code.jquery.com/ui/1.12.1/themes/smoothness/jquery-ui.css">
  
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
