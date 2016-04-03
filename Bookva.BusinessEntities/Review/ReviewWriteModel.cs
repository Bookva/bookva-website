namespace Bookva.BusinessEntities.Review
{
    public class ReviewWriteModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public int UserId { get; set; }
        public int WorkId { get; set; }
    }
}
