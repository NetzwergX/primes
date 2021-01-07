 using System;
 using System.Linq;

 using Xunit;

 using Prime.Services;
using System.Collections.Generic;
using System.Collections;

namespace Prime.Tests.Unit.Services
{
    public class OIESA000040 {
         // See https://oeis.org/A000040
        public static readonly  int [] primes = new int[] {
                2,3,5,7,11,13,17,19,23,29,31,37,41,43,47,53,59,
                61,67,71,73,79,83,89,97,101,103,107,109,113,127,
                131,137,139,149,151,157,163,167,173,179,181,191,
                193,197,199,211,223,227,229,233,239,241,251,257,
                263,269,271
        };
    }

    public class PrimeService_IsPrime
    {
        private readonly PrimeService _service;

        public PrimeService_IsPrime()
        {
            _service = new PrimeCalculator();
        }

        [Theory (DisplayName="No primes smaller 2 ")]
        [InlineData (int.MinValue)]
        [InlineData (-1)]
        [InlineData (0)]
        [InlineData (1)]
        [InlineData (int.MinValue)]
        public void False_For_LessThan_2(int value)
        {
            var result = _service.IsPrime(value);

            Assert.False(result, $"{value} should not be prime");
        }

        [Theory (DisplayName="Valid primes smaller 10 ")]
        [InlineData(2)]
        [InlineData(3)]
        [InlineData(5)]
        [InlineData(7)]
        public void True_Below_10(int value)
        {
            var result = _service.IsPrime(value);

            Assert.True(result, $"{value} should be prime");
        }

        [Theory (DisplayName="Wrong primes smaller 10 ")]
        [InlineData(4)]
        [InlineData(6)]
        [InlineData(8)]
        [InlineData(9)]
        public void False_Below_10(int value)
        {
            var result = _service.IsPrime(value);

            Assert.False(result, $"{value} should not be prime");
        }

        [Fact (DisplayName="int#MaxValue is prime")]
        public void Max_Int_Is_Prime() {
              Assert.True(_service.IsPrime(int.MaxValue));
        }
    }

    public class PrimeService_NextPrime
    {


        private readonly PrimeService _service;

        public PrimeService_NextPrime()
        {
            _service = new PrimeCalculator();
        }

        [Theory (DisplayName = "Next prime for all numbers < 2 is 2 ")]
        [InlineData(int.MinValue)]
        [InlineData(-1)]
        [InlineData(0)]
        [InlineData(1)]
        public void Return_2_For_LessThan_2(int value)
        {
            var result = _service.NextPrime(value);

            Assert.Equal(2, result);
        }

        [Theory (DisplayName = "Next prime for all numbers < 10 ")]
        [InlineData(2, 3)]
        [InlineData(3, 5)]
        [InlineData(4, 5)]
        [InlineData(5, 7)]
        [InlineData(6, 7)]
        [InlineData(7, 11)]
        [InlineData(8, 11)]
        [InlineData(9, 11)]
        public void Next_Primes_LessThan_10(int value, int next)
        {
            var result = _service.NextPrime(value);

            Assert.Equal(next, result);
        }

        public static IEnumerable<object[]> Sequence_Next =>
           Enumerable.Range(1, OIESA000040.primes.Length-1)
                .Select ((index) =>
                    new object[] {
                        OIESA000040.primes[index-1],
                        OIESA000040.primes[index]});

        [Theory (DisplayName = "Next prime for all numbers in OIESA000040 ")]
        [MemberData(nameof(Sequence_Next))]
        public void Next_Primes_OIESA000040 (int value, int next)
        {
            var result = _service.NextPrime(value);

            Assert.Equal(next, result);
        }

        [Fact (DisplayName="int#maxValue throws ArgumentException")]
        public void Exception_On_Max_Int() {
              Assert.Throws<ArgumentException>(() => _service.NextPrime (int.MaxValue));
        }

        [Fact (DisplayName="int#MaxValue-1 returns int#MaxValue")]
        public void Max_Int_Predecessor() {
              Assert.Equal(int.MaxValue, _service.NextPrime(int.MaxValue-1));
        }
    }


    public class PrimeService_GetPrimes
    {
        private readonly PrimeService _service;

        public PrimeService_GetPrimes()
        {
            _service = new PrimeCalculator();
        }

        [Fact (DisplayName = "Valid first 58 primes (Sequence OIESA000040) ")]
        public void GetPrimes_First_58 () {
            var primes = _service.GetPrimes().Take(OIESA000040.primes.Length).ToArray();

            for (int i = 0; i < OIESA000040.primes.Length; i++)
                Assert.Equal(OIESA000040.primes[i], primes[i]);
        }

        [Theory (DisplayName = "Starts with 2 for all numbers < 2 ")]
        [InlineData(int.MinValue)]
        [InlineData(-1)]
        [InlineData(0)]
        [InlineData(1)]
        public void GetPrimes_Below_2 (int value) {
            var result = _service.GetPrimes(value);
            Assert.Equal(2, result.First());
        }

        [Fact (DisplayName = "Ends gracefully for after=int#MaxValue-1")]
        public void GetPrimes_Max_Value () {
            var primes = _service.GetPrimes(int.MaxValue - 1).ToArray();
            Assert.Single(primes);
            Assert.Equal(int.MaxValue, primes[0]);
        }
    }

}