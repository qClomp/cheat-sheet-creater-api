
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace cheat_sheat_creater_api.Models;

public class Sheet
{
    [BsonId]
    public string url { get; set; } = null!;

    public string sheetName { get; set; } = null!;

    public List<SheetData> sheetData { get; set; } = null!;
}