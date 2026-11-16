using System;
using System.Collections.Generic;
using Npgsql;

namespace Rabota
{
    public class DatabaseHelper
    {
        // Укажите ваш пароль от пользователя postgres
        private readonly string _connectionString =
            "Host=localhost;Port=5432;Database=rabota_db;Username=postgres;Password=admin;";

        public NpgsqlConnection GetConnection()
        {
            return new NpgsqlConnection(_connectionString);
        }

        // ==================== ДРОНЫ (DRONES) ====================

        public List<Drone> GetDrones()
        {
            var list = new List<Drone>();
            using (var conn = GetConnection())
            {
                conn.Open();
                string sql = "SELECT id, name, model, type, inventory_number, status FROM drones ORDER BY id";
                using (var cmd = new NpgsqlCommand(sql, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new Drone
                        {
                            Id = reader.GetInt32(0),
                            Name = reader.GetString(1),
                            Model = reader.GetString(2),
                            Type = reader.IsDBNull(3) ? "" : reader.GetString(3),
                            InventoryNumber = reader.IsDBNull(4) ? "" : reader.GetString(4),
                            Status = reader.IsDBNull(5) ? "" : reader.GetString(5)
                        });
                    }
                }
            }
            return list;
        }

        public void AddDrone(Drone drone)
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                string sql = @"INSERT INTO drones (name, model, type, inventory_number, status) 
                               VALUES (@name, @model, @type, @inv, @status)";
                using (var cmd = new NpgsqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("name", drone.Name);
                    cmd.Parameters.AddWithValue("model", drone.Model);
                    cmd.Parameters.AddWithValue("type", drone.Type ?? "");

                    if (string.IsNullOrWhiteSpace(drone.InventoryNumber) || drone.InventoryNumber == "Б/Н")
                        cmd.Parameters.AddWithValue("inv", DBNull.Value);
                    else
                        cmd.Parameters.AddWithValue("inv", drone.InventoryNumber);

                    cmd.Parameters.AddWithValue("status", drone.Status ?? "Исправен");
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void UpdateDroneStatus(int id, string newStatus)
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                string sql = "UPDATE drones SET status = @status WHERE id = @id";
                using (var cmd = new NpgsqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("status", newStatus);
                    cmd.Parameters.AddWithValue("id", id);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void DeleteDrone(int id)
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                string sql = "DELETE FROM drones WHERE id = @id";
                using (var cmd = new NpgsqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("id", id);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        // ==================== ЗАПЧАСТИ (PARTS) ====================

        public List<Part> GetParts()
        {
            var list = new List<Part>();
            using (var conn = GetConnection())
            {
                conn.Open();
                string sql = "SELECT id, name, category, quantity, storage_location FROM parts ORDER BY id";
                using (var cmd = new NpgsqlCommand(sql, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new Part
                        {
                            Id = reader.GetInt32(0),
                            Name = reader.GetString(1),
                            Category = reader.IsDBNull(2) ? "" : reader.GetString(2),
                            Quantity = reader.GetInt32(3),
                            StorageLocation = reader.IsDBNull(4) ? "" : reader.GetString(4)
                        });
                    }
                }
            }
            return list;
        }

        public void AddPart(Part part)
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                string sql = @"INSERT INTO parts (name, category, quantity, storage_location) 
                               VALUES (@name, @cat, @qty, @loc)";
                using (var cmd = new NpgsqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("name", part.Name);
                    cmd.Parameters.AddWithValue("cat", part.Category ?? "");
                    cmd.Parameters.AddWithValue("qty", part.Quantity);
                    cmd.Parameters.AddWithValue("loc", part.StorageLocation ?? "");
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void UpdatePartQuantity(int id, int newQuantity)
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                string sql = "UPDATE parts SET quantity = @qty WHERE id = @id";
                using (var cmd = new NpgsqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("qty", newQuantity);
                    cmd.Parameters.AddWithValue("id", id);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void DeletePart(int id)
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                string sql = "DELETE FROM parts WHERE id = @id";
                using (var cmd = new NpgsqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("id", id);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
//я пло