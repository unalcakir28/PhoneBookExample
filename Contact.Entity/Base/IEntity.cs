namespace Contact.Entity.Base
{
    public interface IEntity
    {
        public int Id { get; set; }
        public bool isDeleted { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public DateTime? DeleteDate { get; set; }
    }
}
