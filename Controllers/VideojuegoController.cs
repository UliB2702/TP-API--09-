using System.Diagnostics;
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using TPN09.Models;

namespace TPN09.Controllers;


[ApiController]
[Route("[controller]")]
public class VideojuegosController : ControllerBase
{

    [HttpGet]
    public IActionResult Get()
    {
        List<Videojuego> lista = BD.BuscarVideojuegos();
        return Ok(lista);
    }

    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
        if (id < 1)
        {
            return BadRequest();
        }
        Videojuego v = BD.BuscarVideojuegoSegunID(id); 

        if(v == null)
        {
            return NotFound();
        }

        return Ok(v);
    }

    [HttpPost]
    public IActionResult Post(Videojuego v)
    {
        if(v.Nombre == null || v.Nombre == "")
        {
            return BadRequest();
        }
        BD.InsertarVideojuegoConObjeto(v);
        return CreatedAtAction("Post",null);
    }

    [HttpPut("{id}")]
    public IActionResult Put(int id, Videojuego v)
    {
        if (id < 1)
        {
            return BadRequest();
        }
        if(v == null)
        {
            return BadRequest();
        }
        Videojuego v2 = BD.BuscarVideojuegoSegunID(id); 
        if(v2 == null)
        {
            return NotFound();
        }
        BD.ActualizarVideojuego(id, v);
        return Ok();
    }
    [HttpPatch("{id}")]
    public IActionResult Patch(int id, Videojuego v)
    {
        if (id < 1)
        {
            return BadRequest();
        }
        if(v == null)
        {
            return BadRequest();
        }
        Videojuego v2 = BD.BuscarVideojuegoSegunID(id); 
        if(v2 == null)
        {
            return NotFound();
        }
        BD.ActualizarVideojuego(id, v);
        return Ok();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        if(id < 1)
        {
            return BadRequest();
        }

        Videojuego v = BD.BuscarVideojuegoSegunID(id);

        if(v == null)
        {
            return NotFound();
        }

        BD.EliminarVideojuegoDeVXC(id);
        BD.EliminarVideojuegoSegunId(id);
        return Ok();
    }

}
