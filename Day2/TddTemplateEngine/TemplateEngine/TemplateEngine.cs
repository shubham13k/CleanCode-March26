﻿
namespace TemplateEngine;

public class TemplateEngine
{
    private string? template;
    private Dictionary<string, string> variables = [];
    public object EvaluateTemplate()
    {
        var result = template;
        foreach (var variable in variables)
        {
            result = result?.Replace(variable.Key, variable.Value);
        }
        return result ?? string.Empty;
    }

    public void SetTemplate(string template)
    {
        this.template = template;
    }

    public void SetVariable(string firstName, string lastName)
    {
        variables.Add(firstName, lastName);
    }
}