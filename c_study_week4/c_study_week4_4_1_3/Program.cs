namespace c_study_week4_4_1_3
{
    internal class Program
    {
        public enum Month
        {
            Jan = 1,
            Feb,
            Mar,
            Apr,
            May,
            Jun,
            Jul,
            Aug,
            Sep,
            Oct,
            Nov,
            Dec
        }

        public static void ProcessMonth(int month)
        {
            if (month >= (int)Month.Jan && month <= (int)Month.Dec)
            {
                Month selectMonth = (Month)month;
                Console.WriteLine("선택한 월은 {0}입니다.", selectMonth);
            } else
            {
                Console.WriteLine("올바른 월을 입력해주세요.");
            }
        }
        static void Main(string[] args)
        {
            int userInput = 7;
            ProcessMonth(userInput);
        }
    }
}