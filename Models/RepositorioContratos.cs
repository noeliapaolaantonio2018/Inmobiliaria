using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Inmobiliaria.Models
{
    public class RepositorioContratos
    {
        private readonly string connectionString;
        private readonly IConfiguration configuration;
        public RepositorioContratos(IConfiguration configuration)
        {
            this.configuration = configuration;
            connectionString = configuration["ConnectionStrings:DefaultConnection"];
        }

        public int Alta(Contratos c)
        {
            int res = -1;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = $"INSERT INTO Contratos(idInm, idInq, FechaInicio, FechaCierre, Monto, Vigente)  " +
                    $"VALUES(@idInm, @idInq, @fechaI, @fechaC, @monto, @vigente)" +
                    $"SELECT SCOPE_IDENTITY();";

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.CommandType = CommandType.Text;
                    command.Parameters.AddWithValue("@idInm", c.IdInm);
                    command.Parameters.AddWithValue("@idInq", c.IdInq);
                    command.Parameters.AddWithValue("@fechaI", c.FechaInicio);
                    command.Parameters.AddWithValue("@fechaC", c.FechaCierre);
                    command.Parameters.AddWithValue("@monto", c.Monto);
                    command.Parameters.AddWithValue("@vigente", c.Vigente);
                    connection.Open();
                    res = Convert.ToInt32(command.ExecuteScalar());
                    c.IdContr = res;
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
                string sql = $"DELETE FROM Contratos WHERE IdContr=@id";

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

        public int Modificacion(Contratos c)
        {
            int res = -1;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = $"UPDATE Contratos SET IdInm=@idInm, idInq=@idInq, FechaInicio=@fechaI, FechaCierre=@fechaC, Monto=@monto, Vigente=@vigente " +
                        $"WHERE idContr=@id";

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.CommandType = CommandType.Text;
                    command.Parameters.AddWithValue("@idInm", c.IdInm);
                    command.Parameters.AddWithValue("@idInq", c.IdInq);
                    command.Parameters.AddWithValue("@fechaI", c.FechaInicio);
                    command.Parameters.AddWithValue("@fechaC", c.FechaCierre);
                    command.Parameters.AddWithValue("@monto", c.Monto);
                    command.Parameters.AddWithValue("@vigente", c.Vigente);
                    command.Parameters.AddWithValue("@id", c.IdContr);
                    connection.Open();
                    res = command.ExecuteNonQuery();
                    connection.Close();
                }
            }

            return res;
        }

        public int NoVigente(Contratos con)
        {
            int i = -1;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = $"UPDATE Contratos SET Vigente= {0} " +
                    $"WHERE IdContr = @id";
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@id", con.IdContr);
                    command.CommandType = CommandType.Text;
                    connection.Open();
                    i = command.ExecuteNonQuery();
                    connection.Close();
                }
            }
            return i;
        }

        public int Vigente(Contratos con)
        {
            int i = -1;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = $"UPDATE Contratos SET Vigente= {1} " +
                   $"WHERE IdContr = @id";
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@id", con.IdContr);
                    command.CommandType = CommandType.Text;
                    connection.Open();
                    i = command.ExecuteNonQuery();
                    connection.Close();
                }
            }
            return i;
        }

        public IList<Contratos> ObtenerTodos()
        {
            IList<Contratos> res = new List<Contratos>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = $"SELECT IdContr, c.IdInq, c.IdInm, FechaInicio, FechaCierre, Monto, Vigente," +
                    $" inq.Nombre, inq.Apellido," +
                    $" inm.Direccion" +
                    $" FROM Contratos c INNER JOIN Inmuebles inm ON c.IdInm = inm.IdInm INNER JOIN Inquilinos inq ON c.IdInq = inq.IdInq";

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.CommandType = CommandType.Text;
                    connection.Open();
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Contratos c = new Contratos
                        {
                            IdContr = reader.GetInt32(0),
                            IdInq = reader.GetInt32(1),
                            IdInm = reader.GetInt32(2),
                            FechaInicio = reader.GetDateTime(3),
                            FechaCierre = reader.GetDateTime(4),
                            Monto = reader.GetDecimal(5),
                            Vigente = reader.GetBoolean(6),

                            Inquilinos = new Inquilinos
                            {
                                IdInq = reader.GetInt32(1),
                                Nombre = reader.GetString(7),
                                Apellido = reader.GetString(8),
                            },

                            Inmuebles = new Inmuebles
                            {
                                IdInm = reader.GetInt32(2),
                                Direccion = reader.GetString(9)
                            }


                        }; res.Add(c);
                    }

                }
                connection.Close();
            }

            return res;

        }

        public IList<Contratos> ObtenerTodosPorInm(int id)
        {
            IList<Contratos> res = new List<Contratos>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = $"SELECT IdContr, c.IdInq, c.IdInm, FechaInicio, FechaCierre, Monto, Vigente," +
                    $" inq.Nombre, inq.Apellido," +
                    $" inm.Direccion, inm.Tipo" +
                    $" FROM Contratos c INNER JOIN Inmuebles inm ON c.IdInm = inm.IdInm INNER JOIN Inquilinos inq ON c.IdInq = inq.IdInq" +
                    $" WHERE c.IdInm = @id";

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.Add("@id", SqlDbType.Int).Value = id;
                    command.CommandType = CommandType.Text;
                    connection.Open();
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Contratos c = new Contratos
                        {
                            IdContr = reader.GetInt32(0),
                            IdInq = reader.GetInt32(1),
                            IdInm = reader.GetInt32(2),
                            FechaInicio = reader.GetDateTime(3),
                            FechaCierre = reader.GetDateTime(4),
                            Monto = reader.GetDecimal(5),
                            Vigente = reader.GetBoolean(6),

                            Inquilinos = new Inquilinos
                            {
                                Nombre = reader.GetString(7),
                                Apellido = reader.GetString(8),
                            },

                            Inmuebles = new Inmuebles
                            {
                                Direccion = reader.GetString(9),
                                Tipo = reader.GetString(10)
                            }


                        }; res.Add(c);
                    }

                }
                connection.Close();
            }

            return res;

        }

        public Contratos ObtenerPorId(int id)
        {
            Contratos con = null;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = $" SELECT IdContr, c.IdInq, c.IdInm, FechaInicio, FechaCierre, Monto, Vigente, " +
                    $" inq.Nombre, inq.Apellido ," +
                    $" inm.Direccion, inm.Tipo" +
                    $" FROM Contratos c INNER JOIN Inmuebles inm ON c.IdInm = inm.IdInm " +
                    $" INNER JOIN Inquilinos inq ON c.IdInq = inq.IdInq " +
                    $" WHERE c.IdContr = @id";

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.Add("@id", SqlDbType.Int).Value = id;
                    command.CommandType = CommandType.Text;
                    connection.Open();
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        con = new Contratos
                        {
                            IdContr = reader.GetInt32(0),
                            IdInq = reader.GetInt32(1),
                            IdInm = reader.GetInt32(2),
                            FechaInicio = reader.GetDateTime(3),
                            FechaCierre = reader.GetDateTime(4),
                            Monto = reader.GetDecimal(5),
                            Vigente = reader.GetBoolean(6),


                            Inquilinos = new Inquilinos
                            {
                                Nombre = reader.GetString(7),
                                Apellido = reader.GetString(8),
                            },

                            Inmuebles = new Inmuebles
                            {
                                Direccion = reader.GetString(9),
                                Tipo = reader.GetString(10)
                            }


                        };
                    }

                }
                connection.Close();
            }

            return con;

        }
        public IList<Contratos> VigentesPorFecha(DateTime f)
        {
            List<Contratos> res = new List<Contratos>();
            Contratos con = null;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = $"SELECT IdContr, c.IdInq, c.IdInm, FechaInicio, FechaCierre, Monto, Vigente, " +
                    $"i.Nombre, i.Apellido, " +
                    $"inm.Direccion, inm.Tipo" +
                    $" FROM Contratos c INNER JOIN Inquilinos i ON c.IdInq = i.IdInq INNER JOIN Inmuebles inm ON c.IdInm = inm.IdInm " +
                    $"WHERE  @fechaConsulta BETWEEN FechaInicio AND FechaCierre AND Vigente = {1} ";

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.Add("@fechaConsulta", SqlDbType.DateTime).Value = f;
                    command.CommandType = CommandType.Text;
                    connection.Open();
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        con = new Contratos
                        {
                            IdContr = reader.GetInt32(0),
                            IdInm = reader.GetInt32(1),
                            IdInq = reader.GetInt32(2),
                            FechaInicio = reader.GetDateTime(3),
                            FechaCierre = reader.GetDateTime(4),
                            Monto = reader.GetDecimal(5),
                            Vigente = reader.GetBoolean(6),
                            Inquilinos = new Inquilinos
                            {
                                Nombre = reader.GetString(7),
                                Apellido = reader.GetString(8)
                            },
                            Inmuebles = new Inmuebles
                            {
                                Direccion = reader.GetString(9),
                                Tipo = reader.GetString(10)
                            }


                        };
                        res.Add(con);
                    }
                    connection.Close();
                }
            }
            return res;
        }
        public Contratos ObtenerPorInm(int id)
        {
            Contratos con = null;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = $" SELECT IdContr, c.IdInq, c.IdInm, FechaInicio, FechaCierre, Monto, Vigente, " +
                    $" inq.Nombre, inq.Apellido ," +
                    $" inm.Direccion, inm.Tipo" +
                    $" FROM Contratos c INNER JOIN Inmuebles inm ON c.IdInm = inm.IdInm " +
                    $" INNER JOIN Inquilinos inq ON c.IdInq = inq.IdInq " +
                    $" WHERE c.IdInm = @id";

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.Add("@id", SqlDbType.Int).Value = id;
                    command.CommandType = CommandType.Text;
                    connection.Open();
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        con = new Contratos
                        {
                            IdContr = reader.GetInt32(0),
                            IdInq = reader.GetInt32(1),
                            IdInm = reader.GetInt32(2),
                            FechaInicio = reader.GetDateTime(3),
                            FechaCierre = reader.GetDateTime(4),
                            Monto = reader.GetDecimal(5),
                            Vigente = reader.GetBoolean(6),


                            Inquilinos = new Inquilinos
                            {
                                Nombre = reader.GetString(7),
                                Apellido = reader.GetString(8),
                            },

                            Inmuebles = new Inmuebles
                            {
                                Direccion = reader.GetString(9),
                                Tipo = reader.GetString(10)
                            }


                        };
                    }

                }
                connection.Close();
            }

            return con;

        }
    }
}
