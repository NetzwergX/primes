package net.teumert.prime.api;

import java.util.stream.IntStream;

import javax.enterprise.context.ApplicationScoped;

@ApplicationScoped
public class PrimeService {

	public boolean isPrime (int number)
	{
		if (number <= 1) return false;
		if (number == 2) return true;
		if (number % 2 == 0) return false;

		int boundary = (int) Math.floor(Math.sqrt(number));

		for (int i = 3; i <= boundary; i += 2)
			if (number % i == 0)
				return false;

		return true;
	}

	public int nextPrime (int number)
	{
		if (number < 2) return 2;
		if (number == Integer.MAX_VALUE - 1) return Integer.MAX_VALUE;
		if (number == Integer.MAX_VALUE)
			throw new IllegalArgumentException(String.format(
					"Can not find prime numbers greater than %d",
					Integer.MAX_VALUE));

		while (true) {
			if (isPrime(++number))
				return number;
		}
	}

	public IntStream getPrimes (int after) {
		return IntStream.iterate(nextPrime(after), this::nextPrime);
	}
}
