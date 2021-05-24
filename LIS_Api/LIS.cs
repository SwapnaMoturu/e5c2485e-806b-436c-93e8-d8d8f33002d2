using System;
using System.Collections.Generic;

namespace LIS_Api
{
    public class LIS : ILIS
    {
        public string input { get; set; }
        public string output { get; set; }
        public void Solve(int[] arr)
        {
            if (null == arr || arr.Length < 1)
            {
                output = null;
                return;
            }
            int[,] data = new int[arr.Length, 2];
            int max_length = 0;
            //  first location for previous element index (for backtracing to print list) and second for longest series length for the element
            for (int i = 0; (i < arr.Length); i++)
            {
                data[i, 0] = -1;
                // none should point to anything at first
                data[i, 1] = 1;
                for (int j = (i - 1); (j >= 0); --j)
                {
                    if ((arr[i] > arr[j]))
                    {
                        if ((data[i, 1]
                                    <= (data[j, 1] + 1)))
                        {
                            //  <= instead of < because we are aiming for the first longest sequence
                            data[i, 1] = (data[j, 1] + 1);
                            data[i, 0] = j;
                        }

                    }

                }

                max_length = Math.Max(max_length, data[i, 1]);
            }

            List<int> ans = new List<int>();
            for (int i = 0; (i < arr.Length); i++)
            {
                if ((data[i, 1] == max_length))
                {
                    int curr = i;
                    while ((curr != -1))
                    {
                        ans.Add(arr[curr]);
                        curr = data[curr, 0];
                    }

                    break;
                }

            }

            ans.Reverse();
            //  since there were added in reverse order in the above while loop
            output = String.Join(" ", ans.ToArray());
        }

    }
}
