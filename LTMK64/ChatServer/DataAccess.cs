using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace ChatServer
{
    public class DataAccess
    {
        String chuoiKetNoi = "Data Source = .\\MSSQL; Initial Catalog=LTMK64DB; User ID=admin; Password=abc123;";

        public DataTable Doc(String truyVan)
        {
            SqlConnection boKetNoi = new SqlConnection(chuoiKetNoi);
            SqlCommand boLenh = new SqlCommand(truyVan, boKetNoi);
            try
            {
                boKetNoi.Open();
                SqlDataReader dr = boLenh.ExecuteReader();
                DataTable tb = new DataTable();
                tb.Load(dr, LoadOption.OverwriteChanges);
                boKetNoi.Close();
                return tb;
            }
            catch
            {
                return null;
            }
        }

        public int Ghi(String truyVan)
        {
            SqlConnection boKetNoi = new SqlConnection(chuoiKetNoi);
            SqlCommand boLenh = new SqlCommand(truyVan, boKetNoi);
            try
            {
                boKetNoi.Open();
                int dem = boLenh.ExecuteNonQuery();
                boKetNoi.Close();
                return dem;
            }
            catch
            {
                return -1;
            }
        }
    }
}
