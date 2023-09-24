using Microsoft.Playwright;
using Strypes.Core.Controls;
using Strypes.Core.Controls.Basic;
using Strypes.Core.Extensions;
using Strypes.Core.Pages.Contact.DTO;

namespace Strypes.Core.Pages.Contact.Controls;
public class ContactForm : BaseControl
{
    public ContactForm(ILocator parent) : base(parent) { }

    private TextInput FirstNameField => new(this.Find("input[name = 'firstname']"));
    private TextInput LastNameField => new(this.Find("input[name = 'lastname']"));
    private TextInput EmailField => new(this.Find("input[name = 'email']"));
    private TextInput CompanyField => new(this.Find("input[name = 'company']"));
    private TextInput MessageField => new(this.Find("textarea[name = 'message']"));
    private Checkbox PrivacyPolicyCheckbox => new(this.Find("label", "I agree with the Privacy policy and Terms of use."));
    private Checkbox SubscribeCheckbox => new(this.Find("label", "Subscribe to our newsletter"));
    private ILocator SendButton => this.Find("input[value='SEND']");
    private ILocator ErrorMessageLocator => this.Find("[class*='hs-main-font-element']");
    private Task<IEnumerable<string>> AllErrorMessages => this.ErrorMessageLocator.AllTextsTrim();

    public async Task Submit(ContactFormData data)
    {
        await this.FillData(data);
        await this.Send();
    }

    public async Task<List<string>> GetErrorMessages() => (await this.AllErrorMessages).ToList();
    private async Task Send() => await this.SendButton.ClickAsync();
    private async Task FillData(ContactFormData data)
    {
        await this.FirstNameField.SafeSet(data.FirstName);
        await this.LastNameField.SafeSet(data.LastName);
        await this.EmailField.SafeSet(data.Email);
        await this.CompanyField.SafeSet(data.CompanyName);
        await this.MessageField.SafeSet(data.Message);
        await this.PrivacyPolicyCheckbox.SetValue(data.AgreeWithPolicy);
        await this.SubscribeCheckbox.SetValue(data.Subscribe);
    }
}
