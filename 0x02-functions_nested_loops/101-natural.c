#include <stdio.h>
/**
 * main - check the code for Holberton School students.
 *
 * Return: Always 0.
 */
int main(void)
{
  int counter = 2;
  long int a = 1;
  long int b = a + 1;
  long int c = a + b;
​
  printf("%ld, %ld, ", a, b);
  while (counter < 50)
  {
  printf("%ld", c);
  counter++;
  a = b;
  b = c;
  c = a + b;
  if (counter < 50)
  {
  printf(", ");
  }
  }
  printf("\n");
  return (0);
}
