using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace RentalSystem.Shared
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum FacTypeEnum
    {
        Conference,
        Guesthouse,
        Classroom
    }
}
