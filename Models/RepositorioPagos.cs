using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Inmobiliaria.Models
{
    public class RepositorioPagos
    {
        private readonly string connectionString;
        private readonly IConfiguration configuration;

        public RepositorioPagos(IConfiguration configuration)
        {
            this.configuration = configuration;
            connectionString = configuration["ConnectionStrings:DefaultConnection"];
        }

        public int Alta(Pagos p)
        {
            int res = -1;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = $"INSERT INTO Pagos(NumPago, IdContr, FechaPago, Importe)" +
                    $"VALUES (@pago, @idContr, @fec, @importe);" +
                    $"SELECT SCOPE_IDENTITY();";
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.CommandType = CommandType.Text;
                    command.Parameters.AddWithValue("@pago", p.NumPago);
                    command.Parameters.AddWithValue("@idContr", p.IdContr);
                    command.Parameters.AddWithValue("@fec", p.FechaPago);
                    command.Parameters.AddWithValue("@importe", p.Importe);
                    connection.Open();
                    res = Convert.ToInt32(command.ExecuteScalar());
                    p.IdPago = res;
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
                string sql = $"DELETE FROM Pagos WHERE idPago=@id";

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

        public int Modificacion(Pagos p)
        {
            int res = -1;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = $"UPDATE Pagos SET  Importe=@importe " +
                            $"WHERE IdPago=@id";

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.CommandType = CommandType.Text;
                    command.Parameters.AddWithValue("@importe", p.Importe);
                    command.Parameters.AddWithValue("@id", p.IdPago);
                    connection.Open();
                    res = command.ExecuteNonQuery();
                    connection.Close();
                }
            }

            return res;
        }

        public IList<Pagos> ObtenerTodos()
        {
            IList<Pagos> res = new List<Pagos>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = $"SELECT IdPago, NumPago, p.IdContr, FechaPago, Importe, " +
                    $"c.IdInm, c.IdInq," +
                    $"Inm.Direccion, Inm.Tipo," +
                    $"  Inq.Nombre, Inq.Apellido FROM Pagos p INNER JOIN Contratos c ON p.IdContr = c.IdContr INNER JOIN Inmuebles Inm ON Inm.IdInm = c.IdInm INNER JOIN Inquilinos Inq ON Inq.IdInq = c.IdInq";

                using (SqlCommand command = new SqlCommand(sql, connection))
                {

                    command.CommandType = CommandType.Text;
                    connection.Open();
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Pagos p = new Pagos
                        {
                            IdPago = reader.GetInt32(0),
                            NumPago = reader.GetInt32(1),
                            IdContr = reader.GetInt32(2),
                            FechaPago = reader.GetDateTime(3),
                            Importe = reader.GetDecimal(4),
                            Contratos = new Contratos
                            {
                                IdInm = reader.GetInt32(5),
                                IdInq = reader.GetInt32(6),
                                Inmuebles = new Inmuebles
                                {
                                    Direccion = reader.GetString(7),
                                    Tipo = reader.GetString(8),
                                },
                                Inquilinos = new Inquilinos
                                {
                                    Nombre = reader.GetString(9),
                                    Apellido = reader.GetString(10),
                                }
                            }

                        };
                        res.Add(p);
                    }
                    connection.Close();
                }
            }
            return res;
        }
        public Pagos ObtenerPorId(int id)
        {
            Pagos p = null;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = $"SELECT IdPago, NumPago, p.IdContr,FechaPago, Importe, " +
                     $"c.IdInq, c.IdInq," +
                    $"Inm.Direccion, Inm.Tipo," +
                    $"Inq.Nombre, Inq.Apellido FROM Pagos p INNER JOIN Contratos c ON c.IdContr=p.IdContr " +
                    $"INNER JOIN Inmuebles Inm ON Inm.IdInm = c.IdInm " +
                    $"INNER JOIN Inquilinos Inq ON Inq.IdInq = c.IdInq " +
                    $"WHERE p.IdPago=@id";

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.CommandType = CommandType.Text;
                    command.Parameters.AddWithValue("@id", id);
                    connection.Open();
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        p = new Pagos
                        {
                            IdPago = reader.GetInt32(0),
                            NumPago = reader.GetInt32(1),
                            IdContr = reader.GetInt32(2),
                            FechaPago = reader.GetDateTime(3),
                            Importe = reader.GetDecimal(4),
                            Contratos = new Contratos
                            {
                                IdInm = reader.GetInt32(5),
                                IdInq = reader.GetInt32(6),
                                Inmuebles = new Inmuebles
                                {
                                    Direccion = reader.GetString(7),
                                    Tipo = reader.GetString(8),
                                },
                                Inquilinos = new Inquilinos
                                {
                                    Nombre = reader.GetString(9),
                                    Apellido = reader.GetString(10)
                                }
                            }
                        };
                    }
                    connection.Close();
                }
            }
            return p;
        }


        public IList<Pagos> ObtenerPorContr(int id)
        {
            IList<Pagos> res = new List<Pagos>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = $"SELECT IdPago, NumPago, p.IdContr,FechaPago, Importe, " +
                     $"c.IdInq, c.IdInq," +
                    $"Inm.Direccion, Inm.Tipo," +
                    $"Inq.Nombre, Inq.Apellido FROM Pagos p INNER JOIN Contratos c ON c.IdContr=p.IdContr " +
                    $"INNER JOIN Inmuebles Inm ON Inm.IdInm = c.IdInm " +
                    $"INNER JOIN Inquilinos Inq ON Inq.IdInq = c.IdInq " +
                    $"WHERE p.IdContr=@id";

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.CommandType = CommandType.Text;
                    command.Parameters.AddWithValue("@id", id);
                    connection.Open();
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Pagos p = new Pagos
                        {
                            IdPago = reader.GetInt32(0),
                            NumPago = reader.GetInt32(1),
                            IdContr = reader.GetInt32(2),
                            FechaPago = reader.GetDateTime(3),
                            Importe = reader.GetDecimal(4),
                            Contratos = new Contratos
                            {
                                IdInm = reader.GetInt32(5),
                                IdInq = reader.GetInt32(6),
                                Inmuebles = new Inmuebles
                                {
                                    Direccion = reader.GetString(7),
                                    Tipo = reader.GetString(8),
                                },
                                Inquilinos = new Inquilinos
                                {
                                    Nombre = reader.GetString(9),
                                    Apellido = reader.GetString(10)
                                }
                            }
                        };
                        res.Add(p);
                    }
                    connection.Close();
                }
            }
            return res;

        }
    }
}



