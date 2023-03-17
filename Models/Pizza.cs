using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Data.SqlClient;
using Dapper;

namespace Pizzas.Models;

public class Pizza{
    private int _id, _importe;
    private string _nombre, _descripcion;
    private bool _libreGluten;

    public Pizza(){}

    public Pizza(int Id, string Nombre, bool LibreGluten, int Importe, string Descripcion){
        _id = Id;
        _nombre = Nombre;
        _libreGluten = LibreGluten;
        _importe = Importe;
        _descripcion = Descripcion;
    }

    public int id {get; set;}
    public string nombre {get; set;}
    public bool libreGluten {get; set;}
    public int importe {get; set;}
    public string descripcion {get; set;}
}