using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;


namespace Inmobiliaria.Models
{
    public class RepositorioInquilinos
    {
        private readonly string connectionString;
        private readonly IConfiguration configuration;

        public RepositorioInquilinos(IConfiguration configuration)
        {
            this.configuration = configuration;
            connectionString = configuration["ConnectionStrings:DefaultConnection"];
        }
        public int Alta(Inquilinos i)
        {
            int res = -1;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = $"INSERT INTO Inquilinos (Nombre, Apellido, Dni, Telefono, DireccionTrabajo, Nombre_Garante, Dni_Garante) " +
                    $"VALUES (@nombre, @apellido, @dni, @telefono, @trabajo, @nombre_garante, @dni_garante);" +
                    $"SELECT SCOPE_IDENTITY();";//devuelve el id insertado
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.CommandType = CommandType.Text;
                    command.Parameters.AddWithValue("@nombre", i.Nombre);
                    command.Parameters.AddWithValue("@apellido", i.Apellido);
                    command.Parameters.AddWithValue("@dni", i.Dni);
                    command.Parameters.AddWithValue("@telefono", i.Telefono);
                    command.Parameters.AddWithValue("@trabajo", i.DireccionTrabajo);
                    command.Parameters.AddWithValue("@nombre_garante", i.Nombre_Garante);
                    command.Parameters.AddWithValue("@dni_garante", i.Dni_Garante);
                    connection.Open();
                    res = Convert.ToInt32(command.ExecuteScalar());
                    i.IdInq = res;
                    connection.Close();
                }
            }
            return res;
        }
        public int Baja(int id)
        {
            int res = -1;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = $"DELETE FROM Inquilinos WHERE IdInq = @id";
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.CommandType = CommandType.Text;
                    command.Parameters.AddWithValue("@id", id);
                    connection.Open();
                    res = command.ExecuteNonQuery();
                    connection.Close();
                }
            }
            return res;
        }
        public int Modificacion(Inquilinos i)
        {
            int res = -1;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = $"UPDATE Inquilinos SET Nombre=@nombre, Apellido=@apellido, Dni=@dni, Telefono=@telefono, DireccionTrabajo=@trabajo, Nombre_Garante=@nombre_garante, Dni_Garante=@dni_garante " +
                    $"WHERE IdInq = @id";
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.CommandType = CommandType.Text;
                    command.Parameters.AddWithValue("@nombre", i.Nombre);
                    command.Parameters.AddWithValue("@apellido", i.Apellido);
                    command.Parameters.AddWithValue("@dni", i.Dni);
                    command.Parameters.AddWithValue("@telefono", i.Telefono);
                    command.Parameters.AddWithValue("@trabajo", i.DireccionTrabajo);
                    command.Parameters.AddWithValue("@nombre_garante", i.Nombre_Garante);
                    command.Parameters.AddWithValue("@dni_garante", i.Dni_Garante);
                    command.Parameters.AddWithValue("@id", i.IdInq);
                    connection.Open();
                    res = command.ExecuteNonQuery();
                    connection.Close();
                }
            }
            return res;
        }

        public IList<Inquilinos> ObtenerTodos()
        {
            IList<Inquilinos> res = new List<Inquilinos>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = $"SELECT IdInq, Nombre, Apellido, Dni, Telefono, DireccionTrabajo, Nombre_Garante, Dni_Garante" +
                    $" FROM Inquilinos";
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.CommandType = CommandType.Text;
                    connection.Open();
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Inquilinos i = new Inquilinos
                        {
                            IdInq = reader.GetInt32(0),
                            Nombre = reader.GetString(1),
                            Apellido = reader.GetString(2),
                            Dni = reader.GetString(3),
                            Telefono = reader.GetString(4),
                            DireccionTrabajo = reader.GetString(5),
                            Nombre_Garante = reader.GetString(6),
                            Dni_Garante = reader.GetString(7),
                        };
                        res.Add(i);
                    }
                    connection.Close();
                }
            }
            return res;
        }
        public Inquilinos ObtenerPorId(int id)
        {
            Inquilinos i = null;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = $"SELECT IdInq, Nombre, Apellido, Dni, Telefono, DireccionTrabajo, Nombre_Garante, Dni_Garante FROM Inquilinos" +
                    $" WHERE IdInq=@id";
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.Add("@id", SqlDbType.Int).Value = id;
                    command.CommandType = CommandType.Text;
                    connection.Open();
                    var reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        i = new Inquilinos
                        {
                            IdInq = reader.GetInt32(0),
                            Nombre = reader.GetString(1),
                            Apellido = reader.GetString(2),
                            Dni = reader.GetString(3),
                            Telefono = reader.GetString(4),
                            DireccionTrabajo = reader.GetString(5),
                            Nombre_Garante = reader.GetString(6),
                            Dni_Garante = reader.GetString(7),

                        };
                    }
                    connection.Close();
                }
            }
            return i;
        }
    }
}
