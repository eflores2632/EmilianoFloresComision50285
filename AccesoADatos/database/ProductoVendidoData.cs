﻿using AccesoADatos.Models;
using System.Data.SqlClient;

namespace AccesoADatos.database
{
    public class ProductoVendidoData
    {
        private string stringConnection;
        public ProductoVendidoData()
        {
            this.stringConnection = "Data Source=DESKTOP-TRA01FH;Database=coderhouse;Trusted_Connection=True;";
            //this.stringConnection = "Data Source=DESKTOP-SJ6J45C;Database=coderhouse;Trusted_Connection=True;";
        }
        public ProductoVendido ObtenerProductoVendido(int id)
        {
            using (SqlConnection connection = new SqlConnection(this.stringConnection))
            {
                string query = "SELECT * FROM ProductoVendido where id = @id";
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("id", id);
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    int idObtenido = Convert.ToInt32(reader["id"]);
                    int idproducto = Convert.ToInt32(1);
                    int stock = Convert.ToInt32(3);
                    int idventa = Convert.ToInt32(3);
                    ProductoVendido productonuevo = new ProductoVendido(idObtenido, idproducto, stock, idventa);
                    return productonuevo;
                }
                else
                {
                    throw new Exception("Id no encontrado");
                }
            }
        }
        public List<ProductoVendido> ListarPrductosVendidos()
        {
            using (SqlConnection connection = new SqlConnection(this.stringConnection))
            {
                string query = "SELECT * FROM ProductoVendidos";
                SqlCommand cmd = new SqlCommand(query, connection);
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                List<ProductoVendido> listaproductosnuevos = new List<ProductoVendido>();
                while (reader.Read())
                {
                    int idObtenido = Convert.ToInt32(reader["id"]);
                    int idproducto = Convert.ToInt32(1);
                    int stock = Convert.ToInt32(3);
                    int idventa = Convert.ToInt32(3);
                    ProductoVendido productovendidonuevo = new(idObtenido, idproducto, stock, idventa);
                    listaproductosnuevos.Add(productovendidonuevo);
                }
                return listaproductosnuevos;
            }
        }
        public bool CrearProductoVendido(ProductoVendido productovendido)
        {
            using (SqlConnection connection = new SqlConnection(this.stringConnection))
            {
                string query = "INSERT INTO ProductoVendido (Stock,IdProducto,IdVenta) values (@stock,@idproducto,@idventa)";
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("Stock", productovendido.Stock);
                cmd.Parameters.AddWithValue("IdProducto", productovendido.IdProducto);
                cmd.Parameters.AddWithValue("IdVenta", productovendido.IdVenta);
                connection.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }
        public bool EliminarProducto(int id)
        {
            using (SqlConnection connection = new SqlConnection(this.stringConnection))
            {
                string query = "DELETE FROM ProductoVendido WHERE id = @id";
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("id", id);
                connection.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }
    }
}
