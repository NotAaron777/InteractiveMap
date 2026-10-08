using System.Text.Json.Serialization;
using MapaInteractivo.Maui.Models;
using Region = MapaInteractivo.Maui.Models.Region;

namespace MapaInteractivo.Maui.Services;

[JsonSourceGenerationOptions(PropertyNameCaseInsensitive = true)]
[JsonSerializable(typeof(List<Region>))]
[JsonSerializable(typeof(List<Cacique>))]
[JsonSerializable(typeof(List<TimelineEvent>))]
[JsonSerializable(typeof(FuentesInfo))]
internal partial class DatosJsonContext : JsonSerializerContext
{
}