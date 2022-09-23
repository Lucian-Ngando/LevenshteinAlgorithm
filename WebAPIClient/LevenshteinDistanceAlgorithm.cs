using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAPIClient;

public class LevenshteinDistanceAlgorithm
{

    //Create a matrix that returns the distance between two strings

    public static string LevenshteinDistance(string userInput, string dataSource)
    {

        double[,] matrix = new double[userInput.Length + 1 , dataSource.Length + 1];

        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            matrix[i, 0] = i;
        }

        for (int i = 0; i < matrix.GetLength(1); i++)
        {
            matrix[0, i] = i;
        }
        for (int row = 1; row < matrix.GetLength(0); row = row + 1)
        {
            for (int col = 1; col < matrix.GetLength(1); col = col + 1)
            {

                //charaters are same
                if (dataSource[col - 1] == userInput[row - 1])
                {
                    matrix[row, col] = matrix[row - 1, col - 1];
                }



                //charaters are different
                else
                {
                    matrix[row, col] = Math.Min(matrix[row, col - 1], Math.Min(
                        matrix[row - 1, col], matrix[row - 1, col - 1])) + 1;
                }
            }
        }

        string result = matrix[matrix.GetLength(0) - 1, matrix.GetLength(1) - 1].ToString();

        return result;
    }
    

}
