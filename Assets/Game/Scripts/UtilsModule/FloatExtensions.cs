namespace UtilsModule
{
    public static class FloatExtensions
    {
        /// <summary>
        /// Remaps a float value from one range to another.
        /// </summary>
        /// <param name="value">The value to remap.</param>
        /// <param name="fromMin">The minimum of the original range.</param>
        /// <param name="fromMax">The maximum of the original range.</param>
        /// <param name="toMin">The minimum of the target range.</param>
        /// <param name="toMax">The maximum of the target range.</param>
        /// <returns>The remapped value within the target range.</returns>
        public static float Remap(this float from, float fromMin, float fromMax, float toMin, float toMax)
        {
            var fromAbs = from - fromMin;
            var fromMaxAbs = fromMax - fromMin;

            var normal = fromAbs / fromMaxAbs;

            var toMaxAbs = toMax - toMin;
            var toAbs = toMaxAbs * normal;

            var to = toAbs + toMin;

            return to;
        }
    }
}