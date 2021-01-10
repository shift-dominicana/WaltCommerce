using System;

namespace DataLayer.Models.Core
{
    public class BaseModel
    {
        public int Id { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreationDate { get; set; } = DateTime.Now;
        public string ModificatedBy { get; set; }
        public DateTime? ModificationDate { get; set; }
        public bool IsDeleted { get; set; }
    }
}
