using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Data.SqlClient;
using Pizzas.Models;
using Dapper;

namespace Pizzas.Models;

public static class DB
{
    private static string _connectionString = @"Server=A-phz2-ami-004; DataBase=Pizza;Trusted_Connection=True;";

    public static List<Pizza> getAll()
    {
        List<Pizza> Lista = null;
        string SQL = "SELECT * FROM Pizzas";
        using (SqlConnection db = new SqlConnection(_connectionString))
        {
            Lista = db.Query<Pizza>(SQL).ToList();
        }
        return Lista;
    }

    public static Pizza GetById(int id)
    {
        Pizza p = null;
        string SQL = "SELECT * FROM Pizza WHERE Id = @pId";
        using (SqlConnection db = new SqlConnection(_connectionString))
        {
            p = db.QueryFirstOrDefault<Pizza>(SQL, new { @pId = id });
        }
        return p;
    }

    public static void Create(Pizza pizza)
    {
        string SQL = "INSERT INTO Pizzas(Id, Nombre, LibreGluten, Importe, Descripcion) VALUES (@pId, @pNombre, @pLibreGluten, @pImporte, @pDescripcion)";
        using (SqlConnection db = new SqlConnection(_connectionString))
        {
            db.Execute(SQL, new
            {
                pId = pizza.id,
                pNombre = pizza.nombre,
                pLibreGluten = pizza.libreGluten,
                pImporte = pizza.importe,
                pDescripcion = pizza.descripcion
            });
        }
    }

    public static void Update(int id, Pizza p) {
        string SQL = "UPDATE Pizza SET (Nombre=@pNombre, LibreGluten=@pLibreGluten, Importe=@pImporte, Descripcion=@pDescripcion) WHERE Id=@pId";
        using (SqlConnection db = new SqlConnection(_connectionString))
        {
            db.Execute(SQL, new
            {
                pId = id,
                pNombre = p.nombre,
                pLibreGluten = p.libreGluten,
                pImporte = p.importe,
                pDescripcion = p.descripcion
            });
        }
    }

    public static void DeleteById(int id) {
        string SQL = "DELETE FROM Pizzas WHERE Id=@pId";
        using (SqlConnection db = new SqlConnection(_connectionString))
        {
            db.Execute(SQL, new
            {
                pId = id
            });
        }
    }
}