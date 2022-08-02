namespace Portfol.io.Domain
{
    public class Role
    {
        public int Id { get; set; }
        public string Name { get; set; } = "guest";

        public virtual User? User { get; set; }
    }
}
