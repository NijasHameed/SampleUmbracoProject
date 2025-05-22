using SampleUmbracoProject.Models.DBModels;

namespace SampleUmbracoProject.Core.Repositories.Interfaces
{
    public interface IContactFormRepository
    {
        void SaveSubmission(ContactFormSubmission submission);
    }
}