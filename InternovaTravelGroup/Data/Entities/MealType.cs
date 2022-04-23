using System;

namespace Question_7_API.Data.Entities
{
    public class MealType
    {
        public string Id { get; set; }
        public int MealTypeID { get; set; }
        public string Type { get; set; }
        public MealType()
        {
            Id = Guid.NewGuid().ToString();
        }
    }
}
