using DVDLibrary.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVDLibrary.Models;
using System.Data.SqlClient;
using System.Configuration;


namespace DVDLibrary.Data.Repositories
{
    public class ADORepository : IDvdRepository
    {
        public void AddDvd(Dvd dvd)
        {
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["DVDLibrary2"].ConnectionString;

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "AddDvd";

                cmd.Parameters.AddWithValue("@ReleaseYear", dvd.realeaseYear);
                cmd.Parameters.AddWithValue("@Rating", dvd.rating);
                cmd.Parameters.AddWithValue("@Notes", dvd.notes);
                cmd.Parameters.AddWithValue("@Title", dvd.title);
                cmd.Parameters.AddWithValue("@Director", dvd.director);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

    
        public void DeleteDvd(int dvdId)
        {
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["DVDLibrary2"].ConnectionString;

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "DeleteDvd";

                cmd.Parameters.AddWithValue("@dvdId", dvdId);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void EditDvd(Dvd dvdId)
        {
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["DVDLibrary2"].ConnectionString;

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "EditDvd";

                cmd.Parameters.AddWithValue("@dvdId", dvdId.dvdId);
                cmd.Parameters.AddWithValue("@ReleaseYear", dvdId.realeaseYear);
                cmd.Parameters.AddWithValue("@Rating", dvdId.rating);
                cmd.Parameters.AddWithValue("@Notes", dvdId.notes);
                cmd.Parameters.AddWithValue("@Title", dvdId.title);
                cmd.Parameters.AddWithValue("@Director", dvdId.director);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public List<Dvd> GetDvdList()
        {
            var toReturn = new List<Dvd>();
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["DvdLibrary2"].ConnectionString;
                //"Server=localhost/SQLEXPRESS;Database=MovieDB;" + "Integrated Security = true";

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "GetDvdList";

                conn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Dvd currentRow = new Dvd();

                        currentRow.director = dr["Director"].ToString();
                        currentRow.dvdId = int.Parse(dr["dvdId"].ToString());
                        currentRow.rating = dr["Rating"].ToString();
                        currentRow.title = dr["Title"].ToString();
                        currentRow.notes = dr["Notes"].ToString();
                        currentRow.realeaseYear = int.Parse(dr["ReleaseYear"].ToString());

                        toReturn.Add(currentRow);
                    }
                }
            }
            return toReturn;
        }

        public List<Dvd> GetDvdsByDirector(string director)
        {
            var toReturn = new List<Dvd>();
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["DvdLibrary2"].ConnectionString;

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "GetAllDvdsByDirector";
                cmd.Parameters.AddWithValue("@Director", director);

                conn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Dvd currentRow = new Dvd();

                        currentRow.director = dr["Director"].ToString();
                        currentRow.dvdId = int.Parse(dr["dvdId"].ToString());
                        currentRow.rating = dr["Rating"].ToString();
                        currentRow.title = dr["Title"].ToString();
                        currentRow.notes = dr["Notes"].ToString();
                        currentRow.realeaseYear = int.Parse(dr["ReleaseYear"].ToString());

                        toReturn.Add(currentRow);
                    }
                }
            }
            return toReturn;
        }



        public List<Dvd> GetDvdsByRating(string rating)
        {
            var toReturn = new List<Dvd>();
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["DvdLibrary2"].ConnectionString;

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "GetAllDvdsByRating";
                cmd.Parameters.AddWithValue("@Rating", rating);

                conn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Dvd currentRow = new Dvd();

                        currentRow.director = dr["Director"].ToString();
                        currentRow.dvdId = int.Parse(dr["dvdId"].ToString());
                        currentRow.rating = dr["Rating"].ToString();
                        currentRow.title = dr["Title"].ToString();
                        currentRow.notes = dr["Notes"].ToString();
                        currentRow.realeaseYear = int.Parse(dr["ReleaseYear"].ToString());

                        toReturn.Add(currentRow);
                    }
                }
            }
            return toReturn;
        }


        public List<Dvd> GetDvdsByTitle(string title)
        {
            var toReturn = new List<Dvd>();
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["DvdLibrary2"].ConnectionString;

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "GetAllDvdsByTitle";
                cmd.Parameters.AddWithValue("@Title", title);

                conn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Dvd currentRow = new Dvd();

                        currentRow.director = dr["Director"].ToString();
                        currentRow.dvdId = int.Parse(dr["dvdId"].ToString());
                        currentRow.rating = dr["Rating"].ToString();
                        currentRow.title = dr["Title"].ToString();
                        currentRow.notes = dr["Notes"].ToString();
                        currentRow.realeaseYear = int.Parse(dr["ReleaseYear"].ToString());

                        toReturn.Add(currentRow);
                    }
                }
            }
            return toReturn;
        }


        public List<Dvd> GetDvdsByYear(int year)
        {
            var toReturn = new List<Dvd>();
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["DvdLibrary2"].ConnectionString;

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "GetAllDvdsByYear";
                cmd.Parameters.AddWithValue("@ReleaseYear", year);

                conn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Dvd currentRow = new Dvd();

                        currentRow.director = dr["Director"].ToString();
                        currentRow.dvdId = int.Parse(dr["dvdId"].ToString());
                        currentRow.rating = dr["Rating"].ToString();
                        currentRow.title = dr["Title"].ToString();
                        currentRow.notes = dr["Notes"].ToString();
                        currentRow.realeaseYear = int.Parse(dr["ReleaseYear"].ToString());

                        toReturn.Add(currentRow);
                    }
                }
            }
            return toReturn;
        }

        public Dvd GetSingleDvd(int id)
        {
            var toReturn = new Dvd();
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["DvdLibrary2"].ConnectionString;

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "GetSingleDvd";

                cmd.Parameters.AddWithValue("@dvdId", id);

                conn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        toReturn.director = dr["director"].ToString();
                        toReturn.dvdId = int.Parse(dr["dvdId"].ToString());
                        toReturn.rating = dr["Rating"].ToString();
                        toReturn.title = dr["Title"].ToString();
                        toReturn.notes = dr["Notes"].ToString();
                        toReturn.realeaseYear = int.Parse(dr["ReleaseYear"].ToString());
                    }
                }
            }
            return toReturn;
        }
    }
}
