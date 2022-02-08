#include "main.h"
/**
 *print_last_digit - main function
 *@n: integer to get last digit of
 *
 *Return: last digit of n
*/
int print_last_digit(int n)
{
	n = n % 10;

	if (n < 0)
		n = -n;
		_putchar(n + '0');
		return (n);
}
