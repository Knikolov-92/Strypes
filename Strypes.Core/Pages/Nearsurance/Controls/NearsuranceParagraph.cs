using Microsoft.Playwright;
using Strypes.Core.Controls;

namespace Strypes.Core.Pages.Nearsurance.Controls;
public class NearsuranceParagraph : BaseControl
{
    public NearsuranceParagraph(ILocator parent) : base(parent) { }

    private ILocator HeadingLocator => this.Find("h5");

    public Task<string> Heading => this.HeadingLocator.InnerTextAsync();
}
