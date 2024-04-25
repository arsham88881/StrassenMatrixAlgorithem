using StrassenMatrixAlgorithem;

Console.WriteLine("Strassen Multiplication Algorithm Test\n");
/// Make an object of Strassen class
Strassen Obj = new Strassen();

int N = 4; //size of row and column for test arrays use only for showing
/** Accept two 2d matrices **/

int[,] A =  { { 1, 2, 3, 4 },
              { 9, 9, 8, 7 },
              { 3, 4, 7, 55 },
              { 7, 33, 1, 2 } 
            };

int[,] B =  { { 9, 8, 7, 3 },
              { 9, 99, 43, 21 },
              { 30, 32, 36, 3 },
              { 21, 22, 26, 5 } 
            };
Console.WriteLine("\nArray A =>");
///show first array 
for (int i = 0; i < N; i++)
{
    for (int j = 0; j < N; j++)
    {
        Console.Write(A[i, j] + " ");
    }
    Console.WriteLine();
}

Console.WriteLine("\nArray B =>");
///show secound array
for (int i = 0; i < N; i++)
{
    for (int j = 0; j < N; j++)
    {
        Console.Write(B[i, j] + " ");
    }
    Console.WriteLine();
}

int[,] C = Obj.Multiply(A, B); //calculate multiply matrixes with strassen algorithem

Console.WriteLine("\nProduct of matrices A and B : ");
for (int i = 0; i < N; i++)
{
    for (int j = 0; j < N; j++)
    { 
        Console.Write(C[i, j] + " ");
    }
    Console.WriteLine();
}