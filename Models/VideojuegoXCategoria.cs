using System.Collections.Generic;

namespace TP_Final.Models;

public class VideojuegoXCategoria
{
    private int _idCategoria;
    private int _idVideojuego;

    public int IdCategoria
    {
        get{
            return _idCategoria;
        }
        set{
            _idCategoria = value;
        }
    }

    public int IdVideojuego
    {
        get{
            return _idVideojuego;
        }
        set{
            _idVideojuego = value;
        }
    }
}