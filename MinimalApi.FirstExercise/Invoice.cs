namespace MinimalApi.FirstExercise
{
    public class Invoice
    {
        public DateTime? Timestamp { get; set; }
        public decimal Amount { get; set; }
        public string Customer { get; set; }

        public override string ToString()
        {
            return $"Fattura per: {Customer}, Ammontare: {Amount}, del {Timestamp?.ToShortDateString()}";
        }
    }
}
