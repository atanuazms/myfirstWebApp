﻿using myfirstWebApp.Models;
using System.Data.SqlClient;

namespace myfirstWebApp.Services
{
    public class ProductService : IProductService
    {
        //private static string db_source = "atandb.database.windows.net";
        //private static string db_user = "atandbadmin";
        //private static string db_password = "Atanu@1983";
        //private static string db_database = "webappdb";

        private readonly IConfiguration _configuration;

        public ProductService(IConfiguration configuration)
        {
            _configuration = configuration;
        }


        private SqlConnection GetConnection()
        {
            //var _builder = new SqlConnectionStringBuilder();
            //_builder.DataSource = db_source;
            //_builder.UserID = db_user;
            //_builder.Password = db_password;
            //_builder.InitialCatalog = db_database;
            return new SqlConnection(_configuration.GetConnectionString("SQLConnection"));
        }

        public List<Product> GetProducts()
        {
            SqlConnection conn = GetConnection();
            List<Product> products = new List<Product>();

            String statement = "SELECT ProductId, Productname, Quantity FROM Products";
            conn.Open();
            SqlCommand cmd = new SqlCommand(statement, conn);

            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    Product product = new Product()
                    {
                        ProductId = reader.GetInt32(0),
                        ProductName = reader.GetString(1),
                        Quantity = reader.GetInt32(2)
                    };

                    products.Add(product);
                }
            };
            conn.Close();
            return products;

        }
    }
}
