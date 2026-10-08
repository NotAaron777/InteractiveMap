using System.Text.Json.Serialization;

namespace MapaInteractivo.Maui.Models;

public class Region
{
    public string Id { get; set; } = "";
    public string Nombre { get; set; } = "";
    public string Subtitulo { get; set; } = "";
    public string? Color { get; set; }
    public string? Imagen { get; set; }

    public string? Ubicacion { get; set; }
    public string? Pueblos { get; set; }
    public string? Idiomas { get; set; }
    public string? Historia { get; set; }
    public string? Cultura { get; set; }
    public string? Gastronomia { get; set; }
    public string? Medicina { get; set; }
    public string? Resistencia { get; set; }
    public string? Datos { get; set; }
    public string? Fuentes { get; set; }

    [JsonPropertyName("caciques")]
    public List<string> CaciqueIds { get; set; } = new();
}

public class Cacique
{
    public string Id { get; set; } = "";
    public string Nombre { get; set; } = "";
    public string Pueblo { get; set; } = "";
    public string Periodo { get; set; } = "";
    public string? Titulos { get; set; }
    public string? Territorio { get; set; }
    public string Biografia { get; set; } = "";
    public string? Rol { get; set; }
    public string? Hechos { get; set; }
    public string? Legado { get; set; }
    public string? Fuentes { get; set; }
    public string? Imagen { get; set; }
    public string? Color { get; set; }

    [JsonPropertyName("region")]
    public string? RegionId { get; set; }

    [JsonIgnore]
    public string Iniciales
    {
        get
        {
            var palabras = Nombre.Split(' ', StringSplitOptions.RemoveEmptyEntries).Take(2);
            return string.Concat(palabras.Select(p => p[0]))?.ToUpperInvariant() ?? "?";
        }
    }
}

public class TimelineEvent
{
    public string Año { get; set; } = "";
    public int Orden { get; set; }
    public string Titulo { get; set; } = "";
    public string Descripcion { get; set; } = "";
    public string? Imagen { get; set; }

    [JsonIgnore]
    public bool Izquierda { get; set; }

    [JsonIgnore]
    public bool NoIzquierda => !Izquierda;
}

public class FuentesInfo
{
    public List<string> Referencias { get; set; } = new();
    public string Creditos { get; set; } = "";
}

public class Seccion
{
    public string Titulo { get; set; } = "";
    public string Texto { get; set; } = "";
}