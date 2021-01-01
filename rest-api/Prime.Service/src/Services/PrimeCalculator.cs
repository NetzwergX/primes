using System;
using System.Collections.Generic;
//using System.Linq;

namespace Prime.Services
{
    public class PrimeCalculator : PrimeService {
        public bool IsPrime (int number)
        {
            if (number <= 1) return false;
            if (number == 2) return true;
            if (number % 2 == 0) return false;

            var boundary = (int) Math.Floor(Math.Sqrt(number));

            for (int i = 3; i <= boundary; i += 2)
                if (number % i == 0)
                    return false;

            return true;
        }

        public int NextPrime (int number)
        {
            if (number < 2) return 2;
            if (number == int.MaxValue - 1) return int.MaxValue;
            if (number == int.MaxValue)
                throw new ArgumentException(String.Format(
                        "Can not find prime numbers greater than {0}",
                        int.MaxValue)
                    );

            while (true) {
                if (IsPrime(++number))
                    return number;
            }
        }

        public IEnumerable<int> GetPrimes (int after = 0) {
            var next = NextPrime(after);
            while (next < int.MaxValue) {
                yield return next;
                next = NextPrime(next);
            }
            yield return next;
        }
    }
}