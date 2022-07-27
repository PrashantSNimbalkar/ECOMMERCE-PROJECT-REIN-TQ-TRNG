using EcommerceProjectReinTrng.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceProjectReinTrng
{
    public class CartDAL
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;
        public CartDAL()
        {
            con = new SqlConnection(Startup.ConnectionString);
        }
        private bool CheckCartData(Cart cart)
        {

            return true;
        }
        public int AddToCart(Cart cart)
        {
            bool result = CheckCartData(cart);
            if (result == true)
            {
                string qry = "insert into Cart values(@userid,@prodid)";
                cmd = new SqlCommand(qry, con);
                cmd.Parameters.AddWithValue("@userid", cart.UserId);
                cmd.Parameters.AddWithValue("@prodid", cart.Id);
                con.Open();
                int res = cmd.ExecuteNonQuery();
                con.Close();
                return res;
            }
            else
            {
                return 2;
            }
        }

        public List<Product> ViewProductsFromCart(string userid)
        {
            List<Product> plist = new List<Product>();
            string qry = "select p.Id,p.Name,p.Price, c.CartId,c.UserId from Product p " +
                        " inner join Cart c on c.Id = p.Id " +
                        " where c.UserId = @id";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@id", Convert.ToInt32(userid));
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    Product p = new Product();
                    p.Id = Convert.ToInt32(dr["Id"]);
                    p.Name = dr["Name"].ToString();
                    p.Price = Convert.ToDouble(dr["Price"]);
                    p.CartId = Convert.ToInt32(dr["CartId"]);
                    p.UserId = Convert.ToInt32(dr["UserId"]);
                    plist.Add(p);
                }
                con.Close();
                return plist;
            }
            else
            {
                return plist;
            }
        }
        public int RemoveFromCart(int id)
        {

            string qry = "delete from Cart where CartId=@id";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@id", id);
            con.Open();
            int res = cmd.ExecuteNonQuery();
            con.Close();
            return res;
        }
    }
}
