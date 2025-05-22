using Microsoft.Extensions.Logging;
using SampleUmbracoProject.Core.Repositories.Interfaces;
using SampleUmbracoProject.Core.Services.Interfaces;
using SampleUmbracoProject.Models.DBModels;
using SampleUmbracoProject.Models.FormModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleUmbracoProject.Core.Services
{
    public class ContactFormService : IContactFormService
    {
        private readonly IContactFormRepository _contactFormRepository;
        private readonly ILogger<ContactFormService> _logger;
        public ContactFormService(IContactFormRepository contactFormRepository,
            ILogger<ContactFormService> logger)
        {
            _contactFormRepository = contactFormRepository;
            _logger = logger;
        }

        public void SaveContactFormSubmission(ContactFormModel model)
        {
            try
            {
                // Save to database
                var submission = new ContactFormSubmission
                {
                    Title = model.Title,
                    Name = model.Name,
                    DateOfBirth = model.DateOfBirth,
                    Email = model.Email,
                    Message = model.Message,
                    SubmissionDate = DateTime.UtcNow
                };

                _contactFormRepository.SaveSubmission(submission);
            }
            catch (Exception e)
            {
                _logger.LogError(e, "SaveContactFormSubmission | Exception: {0} | Message: {1}", e.InnerException != null ? e.InnerException.ToString() : "", e.Message != null ? e.Message.ToString() : "");
            }
        }
    }
}
