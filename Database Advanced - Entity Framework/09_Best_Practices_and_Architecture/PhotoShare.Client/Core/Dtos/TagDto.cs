namespace PhotoShare.Client.Core.Dtos
{
    using Validation;

    public class TagDto
    {
        public int Id { get; set; }

        [Tag]
        public string Name { get; set; }
    }
}
