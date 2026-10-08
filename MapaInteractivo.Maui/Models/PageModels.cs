namespace MapaInteractivo.Maui.Models;

public class RegionPageModel
{
    public Region Region { get; set; } = new();
    public List<Seccion> Secciones { get; set; } = new();
    public List<Cacique> Caciques { get; set; } = new();
}

public class CaciquePageModel
{
    public Cacique Cacique { get; set; } = new();
    public List<Seccion> Secciones { get; set; } = new();
}

public class AcercaPageModel
{
    public List<Cacique> Caciques { get; set; } = new();
    public List<Seccion> Referencias { get; set; } = new();
    public string Creditos { get; set; } = "";
}