using System;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using System.Collections.Generic;
using CD_WithModifiedContact.Helpers;
using CD_WithModifiedContact.Calculation;

public class GenericParameterProcessor
{
    private readonly List<Action> calculationMethods = new List<Action>();
    private readonly List<Action> addFormulasValueMethods = new List<Action>();
    private readonly List<Action> inputValuesMethods = new List<Action>();

    private Dictionary<string, decimal> inputParameters = new Dictionary<string, decimal>();

    private bool IsNeedToStopCalculation = false;

    public GenericParameterProcessor(Dictionary<string, decimal> inputParameters)
    {
        this.inputParameters = inputParameters;
    }

    public void StopCalculation()
    {
        IsNeedToStopCalculation = true;
    }   

    public bool TryProcessParameters(Parameters parameters)
    {
        GetCalculationMethods(parameters);

        if (inputValuesMethods.Count > 0)
        {
            FindAndExcuteInputProperties(parameters);
        }

        if (calculationMethods.Count > 0)
        {
            foreach (var calcMethod in calculationMethods)
            {
                calcMethod();

                if (IsNeedToStopCalculation)
                {
                    return false;
                }
            }
        }
        else
        {
            MessageBox.Show($"Methods not found, vot i dumay :/"); //поменять на делегат
            return false;
        }

        return true;
    }

    private void FindAndExcuteInputProperties(Parameters parameters)
    {
        Type parameterType = parameters.GetType();

        if (parameterType != null)
        {
            var properties = parameterType.GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic)
                .Select(p => new { Property = p, Attr = p.GetCustomAttribute<PropertyMetadataAttribute>() })
                .Where(x => x.Attr != null && inputParameters.ContainsKey(x.Attr.Symbol)).Select(p => p.Property).ToList();

            foreach (var property in properties)
            {
                decimal value = inputParameters[property.GetCustomAttribute<PropertyMetadataAttribute>().Symbol];
                property.SetValue(parameters, value);
            }
        }
    }

    private void GetCalculationMethods(Parameters parameters)
    {
        Type parameterType = parameters.GetType();

        if (parameterType != null)
        {
            var allCalculateMethods = parameterType.GetMethods(BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.NonPublic)
                .Where(m => m.Name.StartsWith("Calculate"))
                .ToList();

            var inputMethods = parameterType.GetMethods(BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.NonPublic)
                .Select(m => new { Method = m, Attr = m.GetCustomAttribute<ExecutionOrderAttribute>() })
                .Where(x => x.Attr != null && inputParameters.ContainsKey(x.Attr.FormulaName)).Select(x => x.Method).ToList();

            var filteredMethods = allCalculateMethods
                .Except(inputMethods)
                .ToList();


            var sortedMethods = SortMethodsByAttribute(filteredMethods);

            foreach (var method in sortedMethods)
            {
                Action action = (Action)Delegate.CreateDelegate(typeof(Action), parameters, method);
                calculationMethods.Add(action);
            }
            foreach (var inputMethod in inputMethods)
            {
                Action action = (Action)Delegate.CreateDelegate(typeof(Action), parameters, inputMethod);
                inputValuesMethods.Add(action);
            }
        }
    }

    public void ExecuteFormulasValueMethods(Parameters parameters)
    {
        AddFormulasValuesMethods(parameters);

        if (addFormulasValueMethods.Count > 0)
        {;
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