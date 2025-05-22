using Microsoft.Extensions.DependencyInjection;
using SampleUmbracoProject.Core.Repositories.Interfaces;
using SampleUmbracoProject.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Umbraco.Cms.Core.Composing;
using Umbraco.Cms.Core.DependencyInjection;
using Umbraco.Cms.Core.Migrations;
using Umbraco.Cms.Core.Services;
using Umbraco.Cms.Infrastructure.Migrations.Upgrade;
using Umbraco.Cms.Core.Scoping;
// Composers/ContactFormComposer.cs
using Umbraco.Cms.Core.Composing;
using Umbraco.Cms.Core.DependencyInjection;
using Umbraco.Cms.Core.Migrations;
using Umbraco.Cms.Core.Scoping;
using Umbraco.Cms.Core.Services;
using Umbraco.Cms.Infrastructure.Migrations;
using Umbraco.Cms.Infrastructure.Migrations.Upgrade;
using Microsoft.Extensions.DependencyInjection;

namespace SampleUmbracoProject.Core.DI
{
    public class BlogCommentsComposer : ComponentComposer<ContactFormComponent>
    {
    }

    public class ContactFormComponent : IComponent
    {
        private readonly IMigrationPlanExecutor _migrationPlanExecutor;
        private readonly IScopeProvider _scopeProvider;
        private readonly IKeyValueService _keyValueService;
        private readonly IRuntimeState _runtimeState;

        public ContactFormComponent(
            IMigrationPlanExecutor migrationPlanExecutor,
            IScopeProvider scopeProvider,
            IKeyValueService keyValueService,
            IRuntimeState runtimeState)
        {
            _migrationPlanExecutor = migrationPlanExecutor;
            _scopeProvider = scopeProvider;
            _keyValueService = keyValueService;
            _runtimeState = runtimeState;
        }

        public void Initialize()
        {
            if (_runtimeState.Level == Umbraco.Cms.Core.RuntimeLevel.Run)
            {
                var plan = new ContactFormMigrationPlan();
                var upgrader = new Upgrader(plan);
                upgrader.Execute(_migrationPlanExecutor, _scopeProvider, _keyValueService);
            }
        }

        public void Terminate()
        {
            // Cleanup if needed
        }
    }
}
