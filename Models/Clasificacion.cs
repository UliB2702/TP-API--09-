using System.Collections.Generic;

namespace TPN09.Models;

public class Clasificacion
{
    private int _idClasificacion;
    private string _nombre;
    private string _logotipo;

    public int IdClasificacion
    {
        get{
            return _idClasificacion;
        }
        set{
            _idClasificacion = value;
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

    public string Logotipo
    {
        get{
            return _logotipo;
        }
        set{
            _logotipo = value;
        }
    }
}