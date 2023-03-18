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
    private static string _connectionString = @"Server=DESKTOP-BS3AF2L\SQLEXPRESS; DataBase=Pizza;Trusted_Connection=True;";

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
        string SQL = "SELECT * FROM Pizzas WHERE Id = @pId";
        using (SqlConnection db = new SqlConnection(_connectionString))
        {
            p = db.QueryFirstOrDefault<Pizza>(SQL, new { @pId = id });
        }
        return p;
    }

    public static int Create(Pizza pizza)
    {
        int i;
        string SQL = "INSERT INTO Pizzas(Nombre, LibreGluten, Importe, Descripcion) VALUES (@pNombre, @pLibreGluten, @pImporte, @pDescripcion)";
        using (SqlConnection db = new SqlConnection(_connectionString))
        {
            i = db.Execute(SQL, new
            {
                pNombre = pizza.nombre,
                pLibreGluten = pizza.libreGluten,
                pImporte = pizza.importe,
                pDescripcion = pizza.descripcion
            });
        }
        return i;
    }

    public static int Update(Pizza p) {
        int i;
        string SQL = "UPDATE Pizzas SET (Nombre=@pNombre, LibreGluten=@pLibreGluten, Importe=@pImporte, Descripcion=@pDescripcion) WHERE Id=@pId";
        using (SqlConnection db = new SqlConnection(_connectionString))
        {
            i=db.Execute(SQL, new
            {
                pId = p.id,
                pNombre = p.nombre,
                pLibreGluten = p.libreGluten,
                pImporte = p.importe,
                pDescripcion = p.descripcion
            });
        }
        return i;
    }

    public static int DeleteById(int id) {
        int i;
        string SQL = "DELETE FROM Pizzas WHERE Id=@pId";
        using (SqlConnection db = new SqlConnection(_connectionString))
        {
            i = db.Execute(SQL, new
            {
                pId = id
            });
        }
        return i;
    }
}