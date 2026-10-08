using System.Text.Json;
using MapaInteractivo.Maui.Models;
using Region = MapaInteractivo.Maui.Models.Region;

namespace MapaInteractivo.Maui.Services;

public class JsonDataService
{
    private readonly List<Region> _regiones = new();
    private readonly List<Cacique> _caciques = new();
    private List<TimelineEvent> _cronologia = new();
    private FuentesInfo _fuentes = new();
    private bool _cargado;

    public IReadOnlyList<Region> Regiones => _regiones;
    public IReadOnlyList<Cacique> Caciques => _caciques;
    public IReadOnlyList<TimelineEvent> Cronologia => _cronologia;
    public FuentesInfo Fuentes => _fuentes;

    public async Task CargarAsync()
    {
        if (_cargado) return;

        _regiones.AddRange(await CargarAsync<List<Region>>("regiones.json"));
        _caciques.AddRange(await CargarAsync<List<Cacique>>("caciques.json"));

        var cronologia = await CargarAsync<List<TimelineEvent>>("cronologia.json");
        cronologia = cronologia.OrderBy(e => e.Orden).ToList();
        for (var i = 0; i < cronologia.Count; i++)
            cronologia[i].Izquierda = i % 2 == 0;
        _cronologia = cronologia;

        _fuentes = await CargarAsync<FuentesInfo>("fuentes.json");
        _cargado = true;
    }

    private static async Task<T> CargarAsync<T>(string nombre)
    {
        using var stream = await FileSystem.OpenAppPackageFileAsync(nombre);
        var resultado = await JsonSerializer.DeserializeAsync(stream, typeof(T), DatosJsonContext.Default, CancellationToken.None);
        return (T)(resultado ?? throw new InvalidDataException($"No se pudo cargar {nombre}"));
    }

    public Region? RegionPorId(string id) =>
        _regiones.FirstOrDefault(r => r.Id == id);

    public Cacique? CaciquePorId(string id) =>
        _caciques.FirstOrDefault(c => c.Id == id);

    public List<Cacique> CaciquesDeRegion(string regionId) =>
        _caciques.Where(c => c.RegionId == regionId).ToList();

    public List<Seccion> Secciones(Region r)
    {
        var secciones = new List<Seccion>
        {
            new() { Titulo = "Ubicación geográfica", Texto = r.Ubicacion ?? "" },
            new() { Titulo = "Pueblos originarios", Texto = r.Pueblos ?? "" },
            new() { Titulo = "Idiomas", Texto = r.Idiomas ?? "" },
            new() { Titulo = "Historia", Texto = r.Historia ?? "" },
            new() { Titulo = "Cultura y tradiciones", Texto = r.Cultura ?? "" },
            new() { Titulo = "Gastronomía", Texto = r.Gastronomia ?? "" },
            new() { Titulo = "Medicina tradicional", Texto = r.Medicina ?? "" },
            new() { Titulo = "Resistencia y legado", Texto = r.Resistencia ?? "" },
            new() { Titulo = "Datos importantes", Texto = r.Datos ?? "" },
            new() { Titulo = "Fuentes y referencias", Texto = r.Fuentes ?? "" },
        };
        return secciones.Where(s => !string.IsNullOrWhiteSpace(s.Texto)).ToList();
    }

    public List<Seccion> Secciones(Cacique c)
    {
        var secciones = new List<Seccion>
        {
            new() { Titulo = "Nombre completo y títulos", Texto = c.Titulos ?? "" },
            new() { Titulo = "Pueblo al que pertenecía", Texto = c.Pueblo },
            new() { Titulo = "Período histórico", Texto = c.Periodo },
            new() { Titulo = "Territorio", Texto = c.Territorio ?? "" },
            new() { Titulo = "Biografía", Texto = c.Biografia },
            new() { Titulo = "Rol y liderazgo", Texto = c.Rol ?? "" },
            new() { Titulo = "Hechos destacados y resistencia", Texto = c.Hechos ?? "" },
            new() { Titulo = "Legado y memoria", Texto = c.Legado ?? "" },
            new() { Titulo = "Fuentes y referencias", Texto = c.Fuentes ?? "" },
        };
        return secciones.Where(s => !string.IsNullOrWhiteSpace(s.Texto)).ToList();
    }
}