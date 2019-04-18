using System;
using System.Collections.Generic;
using System.Text;

namespace DddInPractice.Logic
{
    public sealed class Money : ValueObject<Money>
    {

        public static readonly Money None = new Money(0, 0, 0, 0, 0, 0);
        public static readonly Money Cent = new Money(1, 0, 0, 0, 0, 0);
        public static readonly Money TenCent = new Money(0, 1, 0, 0, 0, 0);
        public static readonly Money Quarter = new Money(0, 0, 1, 0, 0, 0);
        public static readonly Money Dollar = new Money(0, 0, 0, 1, 0, 0);
        public static readonly Money FiveDollar = new Money(0, 0, 0, 0, 1, 0);
        public static readonly Money TwentyDollar = new Money(0, 0, 0, 0, 0, 1);


        // Set Properties setters to private, to provide Inmutability (Using readonly properties)
        public int OneCentCount { get; }
        public int TenCentCount { get; }
        public int QuarterCentCount { get; }
        public int OneDollarCount { get; }
        public int FiveDollarCount { get; }
        public int TwentyDollarCount { get; }

        public Money(int oneCentCount,
            int tenCentCount,
            int quarterCentCount,
            int oneDollarCount,
            int fiveDollarCount,
            int twentyDollarCount)
        {
            if (oneCentCount < 0)
                throw new InvalidOperationException();
            if (tenCentCount < 0)
                throw new InvalidOperationException();
            if (quarterCentCount < 0)
                throw new InvalidOperationException();
            if (oneDollarCount < 0)
                throw new InvalidOperationException();
            if (fiveDollarCount < 0)
                throw new InvalidOperationException();
            if (twentyDollarCount < 0)
                throw new InvalidOperationException();

            OneCentCount += oneCentCount;
            TenCentCount += tenCentCount;
            QuarterCentCount += quarterCentCount;
            OneDollarCount += oneDollarCount;
            FiveDollarCount += fiveDollarCount;
            TwentyDollarCount += twentyDollarCount;
        }

        public static Money operator +(Money money1, Money money2)
        {
            return new Money(
                money1.OneCentCount + money2.OneCentCount,
                money1.TenCentCount + money2.TenCentCount,
                money1.QuarterCentCount + money2.QuarterCentCount,
                money1.OneDollarCount + money2.OneDollarCount,
                money1.FiveDollarCount + money2.FiveDollarCount,
                money1.TwentyDollarCount + money2.TwentyDollarCount
            );
        }

        public static Money operator -(Money money1, Money money2)
        {
            return new Money(
                money1.OneCentCount - money2.OneCentCount,
                money1.TenCentCount - money2.TenCentCount,
                money1.QuarterCentCount - money2.QuarterCentCount,
                money1.OneDollarCount - money2.OneDollarCount,
                money1.FiveDollarCount - money2.FiveDollarCount,
                money1.TwentyDollarCount - money2.TwentyDollarCount
            );
        }


        // Substracion opration. We will create it if we need it (YAGNI: Your are not going to need it)
        protected override bool EqualsCore(Money other)
        {
            return OneCentCount == other.OneCentCount
                   && TenCentCount == other.TenCentCount
                   && QuarterCentCount == other.QuarterCentCount
                   && OneDollarCount == other.OneDollarCount
                   && FiveDollarCount == other.FiveDollarCount
                   && TwentyDollarCount == other.TwentyDollarCount;
        }

        protected override int GetHashCodeCore()
        {
            //Probably because 397 is a prime of sufficient size to cause the result variable to overflow and mix
            //the bits of the hash somewhat, providing a better distribution of hash codes. There's nothing particularly
            //special about 397 that distinguishes it from other primes of the same magnitude.
            unchecked
            {
                int hashcode = OneCentCount;
                hashcode = (hashcode * 397) ^ TenCentCount;
                hashcode = (hashcode * 397) ^ QuarterCentCount;
                hashcode = (hashcode * 397) ^ OneDollarCount;
                hashcode = (hashcode * 397) ^ FiveDollarCount;
                hashcode = (hashcode * 397) ^ TwentyDollarCount;
                return hashcode;
            }
        }

        // Expression body property
        public decimal Amount =>
                OneCentCount*0.01m +
                TenCentCount * .10m +
                QuarterCentCount * 0.25m +
                OneDollarCount +
                FiveDollarCount * 5+
                TwentyDollarCount * 20;

        public override string ToString()
        {
            if (Amount < 1)
                return "¢" + (Amount * 100).ToString("0");
            return "$" + Amount.ToString("0.00");
        }

    }
}