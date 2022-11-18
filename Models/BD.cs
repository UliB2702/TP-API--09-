using TPN09.Models;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Data.SqlClient;
using Dapper;

namespace TPN09.Models;

public class BD{

private static string _connectionString = @"Server=A-PHZ2-CIDI-047;DataBase=AlmacenVideoJuegos;Trusted_Connection=True";

public static List<Videojuego> BuscarVideojuegos(){
    List<Videojuego> lista = new List<Videojuego>();
    using(SqlConnection db = new SqlConnection(_connectionString)){  
        string sql = "SELECT * FROM Videojuego";
        lista = db.Query<Videojuego>(sql).ToList();
    }
    return lista;
}

public static void ActualizarVideojuego(int id, Videojuego v){    
    string sql = "UPDATE Videojuego SET IdEmpresa = @pIdEmpresa, fechaLanzamiento = @pFechaLanzamiento, Nombre = @pNombre, Descripción = @pDescripción, IdClasificacion = @pIdClasificacion, Caratula = @pCaratula, Banner = @pBanner, Logo = @v.Logo WHERE IdVideojuego = @vid";
    using(SqlConnection db = new SqlConnection(_connectionString)){
        db.Execute(sql, new{vid = id, pIdEmpresa = v.IdEmpresa, pFechaLanzamiento = v.FechaLanzamiento, pNombre = v.Nombre, pDescripción = v.Descripción, pIdClasificacion = v.IdClasificacion, pCaratula = v.Caratula, pBanner = v.Banner, pLogo = v.Logo});
    }
}
public static List<Videojuego> BuscarVideojuegosSegunNombre(string nombre){
    List<Videojuego> lista = new List<Videojuego>();
    using(SqlConnection db = new SqlConnection(_connectionString)){  
        string sql = "SELECT * FROM Videojuego WHERE Nombre LIKE '%' + @vNombre + '%'";
        lista = db.Query<Videojuego>(sql, new{vNombre = nombre}).ToList();
    }
    return lista;
}

public static void InsertarVideojuego(int empresa, DateTime fechaLanzamiento, string nombre, string descripcion, int clasificacion, string caratula, string banner,string Logo)
{
    string sql = "INSERT INTO Videojuego VALUES (@vEmpresa, @vFechaLanzamiento, @vNombre, @vDescripcion, @vClasificacion, @vCaratula, @vBanner ,@vLogo)";
    using(SqlConnection db = new SqlConnection(_connectionString)){
        db.Execute(sql, new {vEmpresa=empresa, vFechaLanzamiento=fechaLanzamiento ,vNombre=nombre ,vDescripcion = descripcion, vClasificacion= clasificacion, vCaratula = caratula, vBanner = banner, vLogo = Logo});
    }
}

public static void InsertarVideojuegoConObjeto(Videojuego v)
{
    string sql = "INSERT INTO Videojuego VALUES (@pEmpresa, @pFechaLanzamiento, @pNombre, @pDescripcion, @pClasificacion, @pCaratula, @pBanner ,@pLogo)";
    using(SqlConnection db = new SqlConnection(_connectionString)){
        db.Execute(sql, new {pEmpresa=v.IdEmpresa, pFechaLanzamiento=v.FechaLanzamiento ,pNombre=v.Nombre ,pDescripcion = v.Descripción, pClasificacion= v.IdClasificacion, pCaratula = v.Caratula, pBanner = v.Banner, pLogo = v.Logo});
    }
}




public static Videojuego BuscarVideojuegoSegunID(int id){
    Videojuego videojuego = new Videojuego();
    string sql = "SELECT * FROM Videojuego v WHERE IdVideojuego = @vid ";
    using(SqlConnection db = new SqlConnection(_connectionString)){   
        videojuego = db.QueryFirstOrDefault<Videojuego>(sql, new{vid = id});
    }
    return videojuego;
}


public static void EliminarVideojuegoSegunId(int id)
{
    string sql = "DELETE FROM Videojuego WHERE IdVideojuego = @vid";
     using(SqlConnection db = new SqlConnection(_connectionString)){
        db.Execute(sql, new {vid = id});
    }

}

public static void EliminarVideojuegoDeVXC(int id)
{
    string sql = "DELETE FROM VideojuegoXCategoria WHERE IdVideojuego = @vid";
     using(SqlConnection db = new SqlConnection(_connectionString)){
        db.Execute(sql, new {vid = id});
    }
}


}