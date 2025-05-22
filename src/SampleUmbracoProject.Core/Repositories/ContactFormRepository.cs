using SampleUmbracoProject.Core.Repositories.Interfaces;
using SampleUmbracoProject.Models.DBModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Umbraco.Cms.Core.Scoping;

namespace SampleUmbracoProject.Core.Repositories
{
    public class ContactFormRepository : IContactFormRepository
    {
        private readonly IScopeProvider _scopeProvider;

        public ContactFormRepository(IScopeProvider scopeProvider)
        {
            _scopeProvider = scopeProvider;
        }

        public void SaveSubmission(ContactFormSubmission submission)
        {
            using (var scope = _scopeProvider.CreateScope())
            {
                scope.Database.Insert(submission);
                scope.Complete();
            }
        }
    }
}
