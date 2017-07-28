namespace SamuraiCoreApp.Domain
{
    public class Quote
    {
        public int Id { get; set; }
        public string Test { get; set; }
        public Samurai Samurai { get; set; }
        public int SamuraiId { get; set; }
    }
}
