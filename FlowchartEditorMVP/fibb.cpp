#include <stdio.h>

int fib(int n);

int main(char** argc, int argv)
{
	int n = 0;
	scanf("%d", &n);
	printf("fib(n) = %d", fib(n));
	return 0;
}//endoffunc

int fib(int n)
{
	int prev1 = 1;
	int prev2 = 1;
	int tmp;
	if (n == 0) 
	{
		return 0;
	}//endofif
	if (n < 3) 
	{
		return 1;
	}//endofif	
	for (int i = 2; i < n; i++)
	{
		tmp = prev2;
		prev2 = prev1 + prev2;
		prev1 = tmp;
	}//endoffor
	int k = 0;
	return prev2;
}//endoffunc