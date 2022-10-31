namespace SchoolMealsOrderingSystem.Data.Entities
{

    public class Child
    {


        public Guid Id { get; init; } = Guid.NewGuid();

        public string FirstName { get; set; } = null!;



    }
}
