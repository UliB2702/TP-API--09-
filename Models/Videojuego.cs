using System.Collections.Generic;
using System;

namespace TP_Final.Models;

public class Videojuego
{
    private int _idVideojuego;
    private int _idEmpresa;
    private DateTime _fechaLanzamiento;
    private string _nombre;
    private string _descripción;
    private string _logo;
    private string _caratula;
    private string _banner;
    private int _idClasificacion;

    public int IdVideojuego
    {
        get{
            return _idVideojuego;
        }
        set{
            _idVideojuego = value;
        }
    }
    public int IdEmpresa
    {
        get{
            return _idEmpresa;
        }
        set{
            _idEmpresa = value;
        }
    }
    public DateTime FechaLanzamiento
    {
        get{
            return _fechaLanzamiento;
        }
        set{
            _fechaLanzamiento = value;
        }
    }

    public string Nombre
    {
        get{
            return _nombre;
        }
        set{
            _nombre = value;
        }
    }
    public string Descripción
    {
        get{
            return _descripción;
        }
        set{
            _descripción = value;
        }
    }
    public string Logo
    {
        get{
            return _logo;
        }
        set{
            _logo = value;
        }
    }
     public string Caratula
    {
        get{
            return _caratula;
        }
        set{
            _caratula = value;
        }
    }
     public string Banner
    {
        get{
            return _banner;
        }
        set{
            _banner = value;
        }
    }

    public int IdClasificacion
    {
        get{
            return _idClasificacion;
        }
        set{
            _idClasificacion = value;
        }
    }

    

}