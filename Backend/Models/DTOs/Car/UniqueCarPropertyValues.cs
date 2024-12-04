using System.Collections;

namespace Backend.Models.DTOs.Car
{
    public class UniqueCarPropertyValues
    {
        public List<string?>? FuelTypes { get; set; }
        public List<string?>? BodyTypes { get; set; }
        public List<string?>? Colors { get; set; }
    }
}
