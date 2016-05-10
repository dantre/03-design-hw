namespace TagsCloud.Options
{
    public static class InputOptionsValidator 
    {
        public static bool IsValid(InputOptions options, out string message)
        {
            message = null;
            return true;
        }

        public static bool IsParameterInSegment(int value, int minValue, int maxValue)
        {
            return value > minValue && value < maxValue;
        }
    }
}
