using Microsoft.Playwright;
using Strypes.Core.Pages.Contact.Controls;

namespace Strypes.Core.Pages.Contact;
public class ContactPage : BasePage
{
    public ContactPage(IPage parent) : base(parent) { }

    public ContactForm ContactForm => new(this.Find("[class='hbspt-form'] form"));
}
