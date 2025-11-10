using System;

namespace CD_WithModifiedContact.Helpers
{
    public class RangeCalculator
    {
        /// <summary>
        /// Вычисляет диапазон и среднее значение на основе входных данных и коэффициентов.
        /// </summary>
        /// <param name="baseValue">Базовое значение (например, D-d или B).</param>
        /// <param name="minRangeCoefficient">Коэффициент для минимального диапазона.</param>
        /// <param name="maxRangeCoefficient">Коэффициент для максимального диапазона.</param>
        /// <returns>Диапазон и среднее значение.</returns>
        public RangeResult CalculateRange(decimal baseValue, decimal minRangeCoefficient, decimal maxRangeCoefficient)
        {
            decimal minRangeValue = baseValue * minRangeCoefficient;
            decimal maxRangeValue = baseValue * maxRangeCoefficient;
            decimal averageValue = (minRangeValue + maxRangeValue) / 2;

            return new RangeResult
            {
                MinValue = minRangeValue,
                MaxValue = maxRangeValue,
                AverageValue = averageValue
            };
        }
    }
}
