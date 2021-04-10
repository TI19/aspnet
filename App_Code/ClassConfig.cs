using System;
using System.Data;
using MySql.Data.MySqlClient;

public class ClassConfig
{
    public static string CnnString
    {
        get
        {
            System.Configuration.AppSettingsReader s = new System.Configuration.AppSettingsReader();
            string x = (string)s.GetValue("cnnString", typeof(string));
            s = null;
            return x;
        }
    }

    public static DataTable Call(string strSql)
    {
        return Call(strSql, CnnString);
    }

    public static DataTable Call(string strSql, string Conn)
    {
        MySqlConnection sqlCnn = new MySqlConnection(Conn);
        MySqlDataAdapter sqlAdapter = new MySqlDataAdapter(strSql, sqlCnn);
        DataSet objDS = new DataSet();
        sqlAdapter.Fill(objDS, "data");
        sqlCnn.Close();

        DataTable rst = new DataTable();
        rst = objDS.Tables["data"];

        return rst;
    }

    //Untuk Eksekusi ke database
    public static void Eksekusi(string strSql)
    {
        Eksekusi(strSql, CnnString);
    }

    public static void Eksekusi(string strSql, string Conn)
    {
        MySqlConnection sqlCnn = new MySqlConnection(Conn);
        MySqlCommand sqlCmd = new MySqlCommand(strSql, sqlCnn);
        sqlCnn.Open();
        sqlCmd.ExecuteNonQuery();
        sqlCnn.Close();
    }

}