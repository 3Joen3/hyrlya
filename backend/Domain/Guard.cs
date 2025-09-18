namespace Domain
{
    public static class Guard
    {
        public static void AgainstEmpty(Guid id, string paramName)
        {
            if (id == Guid.Empty)
                throw new ArgumentException($"Guid cannot be empty.", paramName);
        }

        public static void AgainstNull<T>(T value, string paramName)
        {
            if (value is null)
                throw new ArgumentNullException(paramName);
        }

        public static void AgainstOutOfRange(int number, int min, string paramName)
        {
            if (number < min)
                throw new ArgumentOutOfRangeException(paramName, $"Value must be >= {min}");
        }

        public static void AgainstEmptyCollection<T>(IEnumerable<T> collection, string paramName)
        {
            if (!collection.Any())
                throw new ArgumentException("Collection must not be empty.", paramName);
        }
    }
}
