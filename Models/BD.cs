using TPN09.Models;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Data.SqlClient;
using Dapper;

namespace TPN09.Models;

public class BD{

private static string _connectionString = @"Server=A-PHZ2-AMI-004;DataBase=AlmacenVideoJuegos;Trusted_Connection=True";

public static List<Videojuego> BuscarVideojuegos(){
    List<Videojuego> lista = new List<Videojuego>();
    using(SqlConnection db = new SqlConnection(_connectionString)){  
        string sql = "SELECT * FROM Videojuego";
        lista = db.Query<Videojuego>(sql).ToList();
    }
    return lista;
}

public static Videojuego ActualizarVideojuego(int id, Videojuego v)
{    
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

public static List<Videojuego> BuscarVideojuegosSegunClasificacion(string nombre){
    List<Videojuego> lista = new List<Videojuego>();
    using(SqlConnection db = new SqlConnection(_connectionString)){   
        string sql = "SELECT * FROM Videojuego v Inner Join Clasificacion c ON v.IdClasificacion = c.IdClasificacion WHERE c.Nombre = %@vNombre%";
        lista = db.Query<Videojuego>(sql, new{vNombre = nombre}).ToList();
    }
    return lista;
}

public static List<Clasificacion> BuscarClasificacion(){
    List<Clasificacion> lista = new List<Clasificacion>();
    using(SqlConnection db = new SqlConnection(_connectionString)){   
        string sql = "SELECT * FROM Clasificacion";
        lista = db.Query<Clasificacion>(sql).ToList();
    }
    return lista;
}

public static List<Categoria> BuscarCategorias(){
    List<Categoria> lista = new List<Categoria>();
    using(SqlConnection db = new SqlConnection(_connectionString)){  
        string sql = "SELECT * FROM Categoria";
        lista = db.Query<Categoria>(sql).ToList();
    }
    return lista;
}

public static List<Empresa> BuscarEmpresasSegunNombre(string nombre){
    List<Empresa> lista = new List<Empresa>();
    using(SqlConnection db = new SqlConnection(_connectionString)){   
        string sql = "SELECT * FROM Empresa WHERE Nombre LIKE '%' + @vNombre + '%'";
        lista = db.Query<Empresa>(sql, new{vNombre = nombre}).ToList();
    }
    return lista;
}
public static List<Empresa> BuscarEmpresas(){
    List<Empresa> lista = new List<Empresa>();
    using(SqlConnection db = new SqlConnection(_connectionString)){   
        string sql = "SELECT * FROM Empresa";
        lista = db.Query<Empresa>(sql).ToList();
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
        db.Execute(sql, new {pEmpresa=v.IdEmpresa, pFechaLanzamiento=v.FechaLanzamiento ,pNombre=v.Nombre ,pDescripcion = v.Descripción, pClasificacion= v.Clasificacion, pCaratula = v.Caratula, pBanner = v.Banner, pLogo = v.Logo});
    }
}

public static Videojuego BuscarUltimoRegistro()
{    
    Videojuego lista = new Videojuego();
    string sql = "SELECT TOP 1 * From Videojuego ORDER BY IdVideojuego desc";
    using(SqlConnection db = new SqlConnection(_connectionString)){
       lista = db.QueryFirstOrDefault<Videojuego>(sql);
    }
    return lista;
}

public static void InsertarCategorias(List<int> categorias, int id)
{
    using(SqlConnection db = new SqlConnection(_connectionString)){
        foreach(int c in categorias)
        {
            Console.WriteLine(c);
            string sql = "INSERT INTO VideojuegoXCategoria VALUES (@vc, @vid)";
            db.Execute(sql, new{vc = c, vid = id});
        }
    }

}

public static void InsertarEmpresa(string Nombre, string SedeCentral, string Fundador, DateTime fechaFundacion, string Logo)
{
    string sql = "INSERT INTO Empresa VALUES (@vNombre, @vSedeCentral, @vFundador, @vfechaFundacion, @vLogo)";
    using(SqlConnection db = new SqlConnection(_connectionString)){
        db.Execute(sql, new { vNombre=Nombre ,vSedeCentral = SedeCentral, vFundador = Fundador, vfechaFundacion = fechaFundacion, vLogo = Logo});
    }
}
public static Empresa BuscarEmpresasSegunID(int id){
    Empresa empresa = new Empresa();
    string sql = "SELECT * FROM Empresa WHERE IdEmpresa = @eid";
    using(SqlConnection db = new SqlConnection(_connectionString)){   
        empresa = db.QueryFirstOrDefault<Empresa>(sql, new{eid = id});
    }
    return empresa;
}

public static Videojuego BuscarVideojuegoSegunID(int id){
    Videojuego videojuego = new Videojuego();
    string sql = "SELECT * FROM Videojuego v WHERE IdVideojuego = @vid ";
    using(SqlConnection db = new SqlConnection(_connectionString)){   
        videojuego = db.QueryFirstOrDefault<Videojuego>(sql, new{vid = id});
    }
    return videojuego;
}

public static Clasificacion BuscarClasificacionSegunID(int id)
{
    Clasificacion clasificacion = new Clasificacion();
    string sql = "SELECT * FROM Clasificacion Where IdClasificacion = @cid";
    using(SqlConnection db = new SqlConnection(_connectionString)){
        clasificacion = db.QueryFirstOrDefault<Clasificacion>(sql, new{cid = id});
    }
    return clasificacion;
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

public static List<int> BuscarCategoriaXVideojuego(int id)
{
    List<int> ids = new List<int>();
    string sql = "SELECT IdCategoria FROM VideojuegoXCategoria WHERE IdVideojuego = @vid";
    using(SqlConnection db = new SqlConnection(_connectionString)){
        ids = db.Query<int>(sql, new {vid = id}).ToList();
    }
    return ids;
}

public static List<Categoria> BuscarCategoriaPorIdVideojuego(List<int> ids){
    List<Categoria> categorias = new List<Categoria>();
    using(SqlConnection db = new SqlConnection(_connectionString)){
        foreach(int i in ids)
        {
            string sql = "SELECT * FROM Categoria WHERE IdCategoria = @vi";
            categorias.AddRange(db.Query<Categoria>(sql, new{vi = i}).ToList());
        }
    }

    return categorias;
}

}