using Microsoft.AspNetCore.Http.HttpResults;
using SampleUmbracoProject.Models.DBModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Umbraco.Cms.Infrastructure.Migrations;

namespace SampleUmbracoProject.Core
{
    public class ContactFormMigrationPlan : MigrationPlan
    {
        public ContactFormMigrationPlan()
            : base("ContactFormSubmissions")
        {
            From(string.Empty)
                .To<CreateContactFormTableMigration>("create-contact-form-table");
        }
    }
    public class CreateContactFormTableMigration : MigrationBase
    {
        public CreateContactFormTableMigration(IMigrationContext context)
            : base(context)
        {
        }

        protected override void Migrate()
        {

            if (!TableExists("ContactFormSubmissions"))
            {
                Create.Table<ContactFormSubmission>().Do();
            }
        }
    }
}
