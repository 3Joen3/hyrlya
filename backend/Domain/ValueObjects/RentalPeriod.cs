namespace Domain.ValueObjects
{
    public record RentalPeriod
    {
        public DateOnly StartDate { get; }
        public DateOnly? EndDate { get; }
    
        public RentalPeriod(DateOnly startDate, DateOnly? endDate)
        {
            if (endDate.HasValue && endDate.Value < startDate)
                throw new ArgumentOutOfRangeException(nameof(endDate), "End date cannot be earlier than start date.");
            
            if (startDate < DateOnly.FromDateTime(DateTime.UtcNow))
                throw new ArgumentOutOfRangeException(nameof(endDate), "Start date cannot be in the past.");

            StartDate = startDate;
            EndDate = endDate;
        }
    }
}
