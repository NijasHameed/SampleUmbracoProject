using NPoco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Umbraco.Cms.Infrastructure.Persistence.DatabaseAnnotations;

namespace SampleUmbracoProject.Models.DBModels
{
    [TableName("ContactFormSubmissions")]
    [PrimaryKey("Id", AutoIncrement = true)]
    [ExplicitColumns]
    public class ContactFormSubmission
    {
        [Column("Id")]
        [PrimaryKeyColumn(AutoIncrement = true)]
        public int Id { get; set; }

        [Column("Title")]
        [NullSetting(NullSetting = NullSettings.Null)]
        public string Title { get; set; }

        [Column("Name")]
        [NullSetting(NullSetting = NullSettings.Null)]
        public string Name { get; set; }

        [Column("DateOfBirth")]
        [NullSetting(NullSetting = NullSettings.Null)]
        public DateTime? DateOfBirth { get; set; }

        [Column("Email")]
        [NullSetting(NullSetting = NullSettings.NotNull)]
        public string Email { get; set; }

        [Column("Message")]
        [NullSetting(NullSetting = NullSettings.NotNull)]
        public string Message { get; set; }

        [Column("SubmissionDate")]
        public DateTime SubmissionDate { get; set; }
    }
}
