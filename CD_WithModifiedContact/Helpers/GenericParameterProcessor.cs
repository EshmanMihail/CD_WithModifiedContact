using CD_WithModifiedContact.Calculation;
using CD_WithModifiedContact.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

public class GenericParameterProcessor
{
    private readonly List<Action> calculationMethods = new List<Action>();
    private readonly List<Action> addFormulasValueMethods = new List<Action>();

    public void ProcessParameters(Parameters parameters)
    {
        if (parameters == null)
            throw new ArgumentNullException(nameof(parameters));

        GetCalculationMethods(parameters);

        if (calculationMethods.Count > 0)
        {
            foreach (var calcMethod in calculationMethods)
            {
                calcMethod();
            }

            ExecuteFormulasValueMethods(parameters);
        }
        else
        {
            MessageBox.Show($"Methods not found, vot i dumay :/"); //поменять на делегат
        }
    }

    private void GetCalculationMethods(Parameters parameters)
    {
        Type parameterType = parameters.GetType();

        if (parameterType != null)
        {
            var methods = parameterType.GetMethods(BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.NonPublic)
                .Where(m => m.Name.StartsWith("Calculate"))
                .ToList();

            var sortedMethods = SortMethodsByAttribute(methods);

            foreach (var method in sortedMethods)
            {
                Action action = (Action)Delegate.CreateDelegate(typeof(Action), parameters, method);
                calculationMethods.Add(action);
            }
        }
    }

    private void ExecuteFormulasValueMethods(Parameters parameters)
    {
        AddFormulasValuesMethods(parameters);

        if (addFormulasValueMethods.Count > 0)
        {
            foreach (var addMethod in addFormulasValueMethods)
            {
                addMethod();
            }
        }
        else
        {
            MessageBox.Show("No methods to add formulas found."); //поменять на делегат
        }
    }

    private void AddFormulasValuesMethods(Parameters parameters)
    {
        Type parameterType = parameters.GetType();

        if (parameterType != null)
        {
            var methods = parameterType.GetMethods(BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.NonPublic)
                .Where(m => m.Name.StartsWith("AddValueToFormulaCollection"))
                .ToList();

            var sortedMethods = SortMethodsByAttribute(methods);

            foreach (var method in sortedMethods)
            {
                Action action = (Action)Delegate.CreateDelegate(typeof(Action), parameters, method);
                addFormulasValueMethods.Add(action);
            }
        }
    }

    /// <summary>
    /// Сортирует методы по атрибуту ExecutionOrderAttribute.
    /// Если атрибут отсутствует, метод получает максимальный порядок (int.MaxValue).
    /// </summary>
    /// <param name="methods">Список методов, которые нужно отсортировать.</param>
    /// <returns>Отсортированный список методов.</returns>
    private IEnumerable<MethodInfo> SortMethodsByAttribute(IEnumerable<MethodInfo> methods)
    {
        return methods.Select(m => new
        {
            Method = m,
            Order = m.GetCustomAttribute<ExecutionOrderAttribute>()?.Order ?? int.MaxValue
        }).OrderBy(m => m.Order).Select(m => m.Method);
    }
}