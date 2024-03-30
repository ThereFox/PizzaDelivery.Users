namespace PizzaDelivery.Src.Core.Common;

    public struct NumericDate
    {
        public readonly long NumberDate;

        public NumericDate(DateTime dateTime)
        {
            var step = dateTime - DateTime.UnixEpoch;
            NumberDate = (long)step.TotalSeconds;
        }

        public NumericDate(long step)
        {
            NumberDate = step;
        }

        public static implicit operator DateTime(NumericDate date)
        {
            return DateTime.UnixEpoch.AddSeconds(date.NumberDate);
        }

    }