using CD_WithModifiedContact.Helpers;
using System;
using System.Windows.Forms;

public class RangeDisplayManager
{
    private readonly RangeCalculator _rangeCalculator;

    public RangeDisplayManager()
    {
        _rangeCalculator = new RangeCalculator();
    }

    /// <summary>
    /// Вычисляет диапазон и отображает его в Label и TextBox.
    /// </summary>
    /// <param name="baseValue">Базовое значение (например, D-d или B).</param>
    /// <param name="minCoefficient">Коэффициент для минимального диапазона.</param>
    /// <param name="maxCoefficient">Коэффициент для максимального диапазона.</param>
    /// <param name="rangeLabel">Label для отображения диапазона.</param>
    /// <param name="valueTextBox">TextBox для отображения среднего значения.</param>
    /// <param name="message">Сообщение для отображения пользователю.</param>
    public void CalculateAndDisplayRange(
        decimal baseValue, decimal minCoefficient, decimal maxCoefficient,
        Label rangeLabel, TextBox valueTextBox, string message)
    {
        var rangeResult = _rangeCalculator.CalculateRange(baseValue, minCoefficient, maxCoefficient);

        rangeLabel.Text = $"({rangeResult.MinValue}    {rangeResult.MaxValue})";
        valueTextBox.Text = rangeResult.AverageValue.ToString();

        if (message != "") MessageBox.Show(message);
    }

    /// <summary>
    /// Проверяет, заполнены ли TextBox'ы и вызывает расчет диапазона.
    /// </summary>
    /// <param name="textBox1">Первый TextBox для проверки и парсинга значения.</param>
    /// <param name="textBox2">Второй TextBox для проверки и парсинга значения (опционально).</param>
    /// <param name="minCoefficient">Коэффициент для минимального диапазона.</param>
    /// <param name="maxCoefficient">Коэффициент для максимального диапазона.</param>
    /// <param name="rangeLabel">Label для отображения диапазона.</param>
    /// <param name="valueTextBox">TextBox для отображения среднего значения.</param>
    /// <param name="message">Сообщение для отображения пользователю.</param>
    public void HandleRangeCalculation(
        TextBox textBox1, TextBox textBox2, decimal minCoefficient,
        decimal maxCoefficient, Label rangeLabel, TextBox valueTextBox, string message)
    {
        if (!string.IsNullOrWhiteSpace(textBox1.Text) && (textBox2 == null || !string.IsNullOrWhiteSpace(textBox2.Text)))
        {
            decimal value1 = decimal.Parse(textBox1.Text);
            decimal value2 = textBox2 != null ? decimal.Parse(textBox2.Text) : 0;

            decimal baseValue = textBox2 != null ? value1 - value2 : value1;

            CalculateAndDisplayRange(baseValue, minCoefficient, maxCoefficient, rangeLabel, valueTextBox, message);
        }
        else
        {
            rangeLabel.Text = "";
        }
    }
}