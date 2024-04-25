using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrassenMatrixAlgorithem
{
    
    /// <summary>
    /// Class Strassen Alghorithem
    /// </summary>
    public class Strassen
    {
        /// Function to multiply matrices 
        /// understanding complex data type benefit is requered
        public int[,] Multiply(int[,] A, int[,] B) //A = Matrix first , B = Matrix secound
        {
            int n = A.GetLength(0);   //size of row and column of result array
            int[,] R = new int[n, n]; // Result array has n column and n rows

            ///return point of recursive method 
            if (n == 1)
            {
                R[0, 0] = A[0, 0] * B[0, 0];   //if(lenght array is 1 multiple simple)
            }
            else
            {
                ///first 2D array initialization memory
                int[,] A11 = new int[n / 2, n / 2]; //A00
                int[,] A12 = new int[n / 2, n / 2]; //A01
                int[,] A21 = new int[n / 2, n / 2]; //A10
                int[,] A22 = new int[n / 2, n / 2]; //A11
                ///secound 2D array initialization memory
                int[,] B11 = new int[n / 2, n / 2]; //B00
                int[,] B12 = new int[n / 2, n / 2]; //B01
                int[,] B21 = new int[n / 2, n / 2]; //B10
                int[,] B22 = new int[n / 2, n / 2]; //B11

                ///Initialization Sub array for First array
                Split(A, A11, 0, 0);
                Split(A, A12, 0, n / 2);
                Split(A, A21, n / 2, 0);
                Split(A, A22, n / 2, n / 2);
                ///Initialization Sub array for secound array
                Split(B, B11, 0, 0);
                Split(B, B12, 0, n / 2);
                Split(B, B21, n / 2, 0);
                Split(B, B22, n / 2, n / 2);

                ///Calculate each 1 to 7 strassen formula metric  
                int[,] M1 = Multiply(Add(A11, A22), Add(B11, B22)); // M1 = (A11 + A22)(B11 + B22)
                int[,] M2 = Multiply(Add(A21, A22), B11);           // M2 = (A21 + A22) B11
                int[,] M3 = Multiply(A11, Sub(B12, B22));           // M3 = A11 (B12 - B22)
                int[,] M4 = Multiply(A22, Sub(B21, B11));           // M4 = A22 (B21 - B11)
                int[,] M5 = Multiply(Add(A11, A12), B22);           // M5 = (A11 + A12) B22
                int[,] M6 = Multiply(Sub(A21, A11), Add(B11, B12)); // M6 = (A21 - A11) (B11 + B12)
                int[,] M7 = Multiply(Sub(A12, A22), Add(B21, B22)); // M7 = (A12 - A22) (B21 + B22)

                ///Calculate each final element with strassen formula
                int[,] C11 = Add(Sub(Add(M1, M4), M5), M7); // C11 = M1 + M4 - M5 + M7
                int[,] C12 = Add(M3, M5);                   // C12 = M3 + M5
                int[,] C21 = Add(M2, M4);                   // C21 = M2 + M4
                int[,] C22 = Add(Sub(Add(M1, M3), M2), M6); // C22 = M1 - M2 + M3 + M6

                /** join 4 halves into one result matrix **/
                Join(C11, R, 0, 0);
                Join(C12, R, 0, n / 2);
                Join(C21, R, n / 2, 0);
                Join(C22, R, n / 2, n / 2);
            }

            ///return result 
            return R;
        }
        /// <summary>
        /// دو تا آرایه رو از هم کم میکند و آرایه ی جواب را بازگشت میدهد
        /// </summary>
        public int[,] Sub(int[,] A, int[,] B)
        {
            int n = A.GetLength(0);
            int[,] C = new int[n, n]; //

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    C[i, j] = A[i, j] - B[i, j];
                }
            }
            return C; //abbrevate of calculated
        }
        /// <summary>
        /// دو تا آرایه رو با هم جمع میکند و آرایه ی جواب را بازگشت میدهد
        /// </summary>
        public int[,] Add(int[,] A, int[,] B)
        {
            int n = A.GetLength(0);
            int[,] C = new int[n, n];

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    C[i, j] = A[i, j] + B[i, j];
                }
            }
            return C; //abbrevate of calculated
        }
        /// <summary>
        /// آرایه ی والد را به بچه هاشت برای حل به روش تقسیم و غلبه تقسیم میکند
        /// </summary>
        public void Split(int[,] ParentArray, int[,] ChildArray, int StartAreaIndex_i, int StartAreaIndex_j)
        {
            for (int index_i1 = 0, index_i2 = StartAreaIndex_i; index_i1 < ChildArray.GetLength(0); index_i1++, index_i2++)
            {
                for (int index_j1 = 0, index_j2 = StartAreaIndex_j; index_j1 < ChildArray.GetLength(0); index_j1++, index_j2++)
                {
                    ChildArray[index_i1, index_j1] = ParentArray[index_i2, index_j2];
                }
            }

        }

        /// <summary>
        /// آرایه های فرزند رو دور هم جمع میکند و در جای اصلی خود در آرایه ی والد قرار میدهد 
        /// </summary>
        public void Join(int[,] ChildArray, int[,] ParentArray, int StartAreaIndex_i, int StartAreaIndex_j)
        {
            for (int index_i1 = 0, index_i2 = StartAreaIndex_i; index_i1 < ChildArray.GetLength(0); index_i1++, index_i2++)
            {
                for (int index_j1 = 0, index_j2 = StartAreaIndex_j; index_j1 < ChildArray.GetLength(0); index_j1++, index_j2++)
                {
                    ParentArray[index_i2, index_j2] = ChildArray[index_i1, index_j1];
                }
            }
        }
    }

}
