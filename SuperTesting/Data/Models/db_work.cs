using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace SuperTesting.Data.Models
{
    public class db_work
    {
        public List<Cat> cats = new List<Cat>();
        public List<TipsNotification> tips = new List<TipsNotification>();
        string connStr = "server=localhost;user=DESKTOP-KC5JCPR;database=SuperTest;password=0000;Trusted_Connection=True;";

        public db_work()
        {
            cats = getCat();
            tips = getTips();
        }

        public List<Cat> getCat()
        {
            List<Cat> cats_list = new List<Cat>();

            SqlConnection conn = new SqlConnection(connStr);
            conn.Open();
            string sql = "SELECT * FROM cat_pics";
            SqlCommand command = new SqlCommand(sql, conn);
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                cats_list.Add(new Cat { id = Convert.ToInt32(reader[0]), pic_name = reader[1].ToString() });
            }

            reader.Close(); 
            conn.Close();
            return cats_list;
        }

        public List<TipsNotification> getTips()
        {
            List<TipsNotification> tips_list = new List<TipsNotification>();

            SqlConnection conn = new SqlConnection(connStr);
            conn.Open();
            string sql = "SELECT tips.id, tip, id_category, tips_category FROM tips INNER JOIN category_tips ON tips.id_category = category_tips.id";
            SqlCommand command = new SqlCommand(sql, conn);
            SqlDataReader reader = command.ExecuteReader();

            while(reader.Read())
            {
                tips_list.Add(new TipsNotification { tip = reader[1].ToString(), tip_categry = reader[3].ToString() });
            }

            reader.Close();
            conn.Close();
            return tips_list;
        }
    }
}
