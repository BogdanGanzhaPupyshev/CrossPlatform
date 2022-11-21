using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba2
{
    public class GfG
    {

        public int maximalAreaOfSubMatrixOfAll1(int[][] mat, int n, int m)
        {

            // If matrix is empty, return 0.
            if (mat.Length == 0)
            {
                return 0;
            }

            int[] left = new int[m];
            int[] right = new int[m];
            int[] height = new int[m];

            // Function signature: void fill_n(iterator begin, int n, type value).
            fill_n(left, m, 0);
            fill_n(right, m, m);
            fill_n(height, m, 0);

            int maxArea = 0;

            for (int i = 0; i < n; i++)
            {
                // At each row, initialise its leftBoundary to 0 and rightBoundary to mat-1.

                int curLeft = 0;
                int curRight = m;
                for (int j = 0; j < m; j++)
                {

                    if (mat[i][j] == 1)
                    {
                        height[j]++;
                    }
                    else
                    {
                        height[j] = 0;
                    }

                }

                // Compute left boundary from left to right.
                for (int j = 0; j < m; j++)
                {
                    if (mat[i][j] == 1)
                    {
                        left[j] = Math.Max(left[j], curLeft);
                    }
                    else
                    {
                        // Left boundary will be atleast j+1 for all matrix elements ahead of index j in this row.
                        left[j] = 0;
                        curLeft = j + 1;
                    }

                }

                // Compute right boundary from right to left.
                for (int j = m - 1; j >= 0; j--)
                {
                    if (mat[i][j] == 1)
                    {
                        right[j] = Math.Min(right[j], curRight);
                    }
                    else
                    {
                        // Right boundary will be atmost j-1 for all matrix elements before index j in this row.
                        right[j] = m;
                        curRight = j;
                    }

                }

                for (int j = 0; j < m; j++)
                {
                    maxArea = Math.Max(maxArea, height[j] * (right[j] - left[j]));
                }

            }

            return maxArea;
        }

        private void fill_n(int[] arr, int n, int val)
        {
            for (int i = 0; i < n; i++)
            {
                arr[i] = val;
            } 
        }
    }
}
