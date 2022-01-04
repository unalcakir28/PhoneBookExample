using System.ComponentModel.DataAnnotations;

namespace Contact.Entity.Base
{
    public abstract class EntityBase : IEntity
    {
        [Key]
        public int Id { get; set; }
        public bool isDeleted { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public DateTime? DeleteDate { get; set; }
    }
}
