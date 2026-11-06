namespace webapp2.Entity
{
    public class Slide
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Image { get; set; }
        public string URL { get; set; }

        public int Seq { get; set; } = 1;
        public bool Active { get; set; }

        // audit trails
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public string? LastModifiedBy { get; set; }
        public DateTime? LastModifiedDate { get; set; }

    }
}
