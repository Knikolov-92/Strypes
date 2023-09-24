namespace Strypes.Core.Pages.Careers.Enums;
public enum Departments
{
    Technology,
    DevOps,
    Python,
    QA
}
public static class DepartmentsEnumExtensions
{
    public static string GetValue(this Departments value) =>
        value switch
        {
            Departments.Technology => "Technology",
            Departments.DevOps => "DevOps Engineers",
            Departments.Python => "Python Development",
            Departments.QA => "QA/Feature Integrators",
            _ => throw new ArgumentException($"Unexpected value of {Enum.GetName(value)}")
        };
}
