using SampleUmbracoProject.Models.FormModels;

namespace SampleUmbracoProject.Core.Services.Interfaces
{
    public interface IContactFormService
    {
        void SaveContactFormSubmission(ContactFormModel model);
    }
}