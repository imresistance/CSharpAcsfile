using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Globalization;
using System.Windows.Forms;

public class MySQL
{
    public static string strcon;
    public static void connnectsql()
    

    {
        strcon = "Data Source=COMPUTER\\SQLEXPRESS;Initial Catalog=POS;Integrated Security=True";
        try
        {
            SqlConnection objConn = new SqlConnection();
            objConn.Open();
            objConn.Close();
            objConn = null;
        }
        catch (Exception exx)
        {
            strcon = null;
            MessageBox.Show("ERROR Database", "Database", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }
        MessageBox.Show("Connected", "Database", MessageBoxButtons.OK, MessageBoxIcon.Information);

        //if((e.KeyChar < 48 || e.KeyChar > 57) && (e.KeyChar != 8))
        //    {
        //    e.Handled = true;
        //}
    }

    public static DataTable executsql(string sql)
    {
        SqlDataAdapter dtAdapter = default(SqlDataAdapter);
        SqlConnection objConn = new SqlConnection();
        DataTable dt = new DataTable();
        try
        {
            objConn.ConnectionString = strcon;
            objConn.Open();
            dtAdapter = new SqlDataAdapter(sql, objConn);
            dtAdapter.Fill(dt);
            objConn.Close();
            objConn = null;
            return dt;
        }
        catch(Exception exx)
        {
            Console.Write(exx.ToString());
            dt = null;
        }

        return dt;
    }




















            ////DateTime Datestart = Convert.ToDateTime(dateTimePicker1.Value.ToString());
            ////+Datestart.ToString("yyyy-MM-dd", new CultureInfo("en-US")) +
            ////DateTime DateEnd = Convert.ToDateTime(dateTimePicker2.Value.ToString());
            ////+DateEnd.ToString("yyyy-MM-dd" + " 23:59:59", new CultureInfo("en-US")) +


  

    //String datestart = ConnectionStr.Getdateend(Convert.ToDateTime(DateTime.Now)).ToString();
    //MessageBox.Show(datestart, "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Error);
    public static DateTime Getdate(DateTime datetime)
    {
        //ConnectionStr.Getdateend(Convert.ToDateTime(dateTimePicker1.Value));
        CultureInfo ThaiCulture = new CultureInfo("th-TH");
        Console.WriteLine(datetime.ToString("yyyy-MM-dd", ThaiCulture));

     ///   MessageBox.Show(Convert.ToDateTime(datetime.ToString("yyyy-MM-dd", ThaiCulture)), "");
        return Convert.ToDateTime(datetime.ToString("yyyy-MM-dd", ThaiCulture));

    }

    public static DateTime Getdateend(DateTime datetime)
    {
        //ConnectionStr.Getdateend(Convert.ToDateTime(dateTimePicker1.Value));
        CultureInfo ThaiCulture = new CultureInfo("th-TH");
        Console.WriteLine(datetime.ToString("yyyy-MM-dd" + " 23:59:59", ThaiCulture));
        return Convert.ToDateTime(datetime.ToString("yyyy-MM-dd" + " 23:59:59", ThaiCulture));

    }

 
}

