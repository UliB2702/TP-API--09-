using System.Collections.Generic;
using System;

namespace TPN09.Models;


public class Empresa
{
    private int _idEmpresa;
    private string _nombre;
    private string _sedeCentral;
    private string _fundador;
    private DateTime _fechaFundacion;
    private string _logo;

    public int IdEmpresa
    {
        get{
            return _idEmpresa;
        }
        set{
            _idEmpresa = value;
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

    public string SedeCentral
    {
        get{
            return _sedeCentral;
        }
        set{
            _sedeCentral = value;
        }
    }

    public string Fundador
    {
        get{
            return _fundador;
        }
        set{
            _fundador = value;
        }
    }

    public DateTime FechaFundacion
    {
        get{
            return _fechaFundacion;
        }
        set{
            _fechaFundacion = value;
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

}