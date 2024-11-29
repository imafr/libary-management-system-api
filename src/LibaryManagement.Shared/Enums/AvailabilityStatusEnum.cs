using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace LibaryManagement.Shared.Enums;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum AvailabilityStatusEnum
{
    [EnumMember(Value = "Available")]
    Available,

    [EnumMember(Value = "Borrowed")]
    Borrowed
}
