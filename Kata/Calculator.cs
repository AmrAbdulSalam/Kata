
namespace Kata
{
    public class Calculator
    {
        public Calculator()
        {
        }

        public int Add(string numbers)
        {
            if (string.IsNullOrEmpty(numbers)) return 0;

            string[] values;
            
            if (numbers.StartsWith("//"))
            {
                numbers = numbers.Substring(2);
                var delimiters = numbers.First();
                values = numbers.Split(delimiters , '\n' , ',').Skip(2).ToArray();
            }
            else
            {
                numbers = numbers.Replace('\n', ',');
                values = numbers.Split(",");
            }
            return CalculateValues(values);

        }

        private int CalculateValues(string[] Numbers)
        {
            var total = 0;
            foreach (var num in Numbers)
            {
                if (int.Parse(num) < 0) throw new NegativeValuesException("Negative values");
                total += int.Parse(num);
            }
            return total;
        }
    }
}

