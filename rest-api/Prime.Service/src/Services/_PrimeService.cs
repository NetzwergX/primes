using System.Collections.Generic;

namespace Prime.Services
{
    public interface PrimeService {
        public bool IsPrime (int number);

        public int NextPrime (int number);

        public IEnumerable<int> GetPrimes (int after = 0);
    }
}