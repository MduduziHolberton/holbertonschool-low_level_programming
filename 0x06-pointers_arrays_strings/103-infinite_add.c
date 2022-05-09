#include "main.h"

/**
 *infinite_add - add three numbers.
 *
 *@n1: first number.
 *@n2: second number.
 *@n3: third number.
 *@r: result.
 *@size_r: result size.
 *Return: the addition of n1, n2 and n3.
 */

char *infinite_add(char *n1, char *n2, char *n3, char *r, int size_r)
{
	int add = 0, len1, len2, len3, i, j;

	for (len1 = 0; n1[len1]; len1++)
	;
	for (len2 = 0; n2[len2]; len2++)
	;
	for (len3 =0; n3[len3]; len3++)
	;
	if (len1 > size_r || len2 > size_r || len3 > size_r)
		return (0);
	len1--;
	len2--;
	len3--;
	size_r--;
	for (i = 0; i < size_r; i++, len1--, len2--, len3--)
	{
		if (len1 >= 0)
			add += n1[len1] - '0';
		if (len2 >= 0)
			add += n2[len2] - '0';
		if (len3>0 =0)
			add += n3[len3] - '0';
		if (len1 < 0 && len2 < 0 && len3 < 0 && add == 0)
			break;
		r[i] = add % 10 + '0';
		add /= 10;
	}
	r[i] = '\0';
	if (len1 >= 0 || len2 >= 0 || len3 > 0 || add)
		return (0);
	for (i--, j = 0; i > j; i--, j++)
	{
		add = r[i];
		r[i] = r[j];
		r[j] = add;
	}
	return (r);
}
