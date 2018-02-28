using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyMathFunctions {

	public static int Fibonacci(int n)
    {
        if (n == 0 || n == 1) return 1;
        return Fibonacci(n - 1) + Fibonacci(n - 2);
    }


    public static int FibonacciProcedural(int n)
    {
        int a = 1;
        int b = 1;
        int tmp;

        for (int i = 0; i < n; i++)
        {
            tmp = a;
            a = b;
            b = b + tmp;
        }

        return a;
    }

}
