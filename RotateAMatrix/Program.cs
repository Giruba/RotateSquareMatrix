using System;

namespace RotateAMatrix
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Rotate a Matrix by 90degrees!");
            Console.WriteLine("-----------------------------");

            int[,] matrix = GetMatrixFromInput();
            PrintRotatedMatrixBy90(matrix);

            Console.ReadLine();
        }

        private static int[,] GetMatrixFromInput() {
            int[,] resultantMatrix = null;

            Console.WriteLine("Enter the dimension of the square matrix");
            try
            {
                int dimension = int.Parse(Console.ReadLine());
                resultantMatrix = new int[dimension, dimension];
                for (int i = 0; i < dimension; i++) {
                    Console.WriteLine("Enter the elements of row" +
                        " "+(i+1)+" saparated by space");
                    String[] elements = Console.ReadLine().Split(' ');
                    for (int j = 0; j < dimension; j++) {
                        resultantMatrix[i, j] = int.Parse(elements[j]);
                    }
                }
            }
            catch (Exception exception) {
                Console.WriteLine("Thrown exception is "+exception.Message);
            }


            return resultantMatrix;
        }
        private static void PrintRotatedMatrixBy90(int[,] matrix) {

            for (int i = 0; i < matrix.GetLength(0)/2; i++) {
                for (int j = i; j < matrix.GetLength(0)-i-1; j++) {
                    int temporarayVariable = matrix[i,j];
                    matrix[i, j] = matrix[(matrix.GetLength(0)-j-1),i];
                    matrix[(matrix.GetLength(0) - j - 1), i] = 
                        matrix[(matrix.GetLength(0) - i-1), 
                                (matrix.GetLength(1)-j-1)];
                    matrix[(matrix.GetLength(0) - i - 1),
                                (matrix.GetLength(1) - j - 1)] =
                               matrix[j, (matrix.GetLength(0) - i - 1)];
                    matrix[j, (matrix.GetLength(0) - i - 1)] = temporarayVariable;
                }
            }

            PrintMatrix(matrix);
        }

        private static void PrintMatrix(int[,] matrix) {

            for (int index = 0; index < matrix.GetLength(0); index++) {
                for (int secIndex = 0; secIndex < matrix.GetLength(1);
                    secIndex++) {
                    Console.Write(matrix[index, secIndex]+" ");
                }
                Console.WriteLine();
            }
        }
    }
}
