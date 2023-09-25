using System.Collections.Generic;
using System.Linq;
using Strypes.Core.Pages.Contact.DTO;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace Strypes.Tests.Support;

[Binding]
public static class Transformations
{
    [StepArgumentTransformation]
    public static ContactFormData TableToContactFormData(Table table) => table.CreateInstance<ContactFormData>();

    [StepArgumentTransformation]
    public static List<string> TableToListString(Table table) => table.Rows.Select(row => row.Values.ElementAt(0)).ToList();
}
