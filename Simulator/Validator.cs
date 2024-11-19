namespace Simulator
{
    public class Validator
    {
        public static int Limiter(int value, int min, int max)
        {
            if (value < min) { return min; }
            if (value > max) { return max; }
            return value;
        }

        public static string Shortener(string value, int min, int max, char placeholder)
        {
            string trimmedValue = value.Trim();

            if (trimmedValue.Length > max)
            {
                trimmedValue = trimmedValue.Substring(0, max).Trim();
            }

            if (trimmedValue.Length < min)
            {
                trimmedValue = trimmedValue.PadRight(min, placeholder);
            }

            if (char.IsLower(trimmedValue[0]))
            {
                trimmedValue = char.ToUpper(trimmedValue[0]) + trimmedValue.Substring(1);
            }

            return trimmedValue;
        }
    }
}
