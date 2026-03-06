namespace BookstoreWebApp.Models.Reviews
{
    public class ReviewsIndexViewModel
    {
        public Guid Id { get; set; }
        public string Username { get; set; } = null!;
        public string Text { get; set; } = null!;
        public DateTime DateAndTime { get; set; }
        public Guid BookId { get; set; }
    }
}
