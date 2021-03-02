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

    public static void ConnnectSQL()

    {
        strcon = "Data Source=LAPTOP-BMLRPG13\\SQLEXPRESS;Initial Catalog=POS;Integrated Security=True";

        try
        {
            SqlConnection objConnTest = new SqlConnection();
            objConnTest.ConnectionString = strcon;
            objConnTest.Open();
            objConnTest.Close();
            objConnTest = null;

            //POSC.FormAsMain.ActiveForm.Invoke(new Action(() => Form.ActiveForm.Text = "test")) ;

        }
        catch //(Exception exx)
        {
            strcon = null;
            MessageBox.Show("ERROR Database", "Database", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }
       // MessageBox.Show("Connected", "Database", MessageBoxButtons.OK, MessageBoxIcon.Information);
    }

    public static DataTable Query(string sql)
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
        catch (Exception exx)
        {
            Console.Write(exx.ToString());
            dt = null;
        }

        return dt;
    }

}