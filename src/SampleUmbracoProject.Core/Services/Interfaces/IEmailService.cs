﻿using SampleUmbracoProject.Models.FormModels;

namespace SampleUmbracoProject.Core.Services.Interfaces
{
    public interface IEmailService
    {
        void SendFormEmail(ContactFormModel model,bool isAdminEmail= false);
    }
}