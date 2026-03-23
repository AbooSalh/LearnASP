namespace ControllersExample.Models
{
    public class Person(Guid Id = default, string? Name = default, int? Age = default)
    {
        // default constructor 

        public Guid Id { get; set; }
        public string? Name { get; set; }
        public int? Age { get; set; }
    }
}
