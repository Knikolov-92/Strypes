using System.Threading.Tasks;
using FluentAssertions;
using Strypes.Core.Pages.Contact;
using Strypes.Core.Pages.Contact.DTO;
using TechTalk.SpecFlow;

namespace Strypes.Tests.StepDefinitions.Contact;

[Binding]
public sealed class ContactSteps : BasePageSteps<ContactPage>
{
    public ContactSteps(ScenarioContext scenarioContext) : base(scenarioContext, p => new ContactPage(p)) { }

    [When(@"the contact form data is submitted")]
    public async Task WhenTheContactFormDataIsSubmitted(ContactFormData data) => await this.Page.ContactForm.Submit(data);

    [Then(@"the contact form error message ""(.*)"" for invalid email is displayed")]
    public async Task ThenTheContactFormErrorMessageForInvalidEmailIsDisplayed(string error)
    {
        var errors = await this.Page.ContactForm.GetErrorMessages();

        errors.Should().Contain(error);
    }
}
