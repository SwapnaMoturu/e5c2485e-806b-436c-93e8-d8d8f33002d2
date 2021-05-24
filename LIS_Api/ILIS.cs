namespace LIS_Api
{
    public interface ILIS
    {
        string input { get; set; }
        string output { get; set; }

        void Solve(int[] arr);
    }
}