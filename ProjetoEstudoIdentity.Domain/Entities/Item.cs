namespace ProjetoEstudoIdentity.Domain.Entities
{
    public class Item
    {
        public int Id { get; set; }
        public string Description { get; set; }

        public string UserId { get; set; }
        public virtual User User { get; set; }
    }
}
