using Strypes.Core.Pages.Contact.DTO;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace Strypes.Tests.Support;

[Binding]
public static class Transformations
{
    [StepArgumentTransformation]
    public static ContactFormData TableToContactFormData(Table table) => table.CreateInstance<ContactFormData>();
}
