﻿// -----------------------------------------------------------------------
//  <copyright file="ManageController.cs" company="Microsoft">
//      Copyright (c) Microsoft Corporation. All rights reserved.
//  </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Griffin.Connectors.Management.Areas.Aircall.Controllers
{
    using System.Threading.Tasks;
    using System.Web.Mvc;
    using Microsoft.Griffin.Connectors.Management.Controllers;
    using Microsoft.Griffin.Connectors.Providers.Aircall;
    using Microsoft.Griffin.Connectors.Providers.Common;
    using Microsoft.Griffin.Connectors.Providers.Common.Management;

    /// <summary>
    /// Manage Controller for Aircall test
    /// </summary>
    public class ManageController : ProviderWebhookManageController
    {
        /// <summary>
        /// Aircall provider
        /// </summary>
        private static readonly AircallConnector AircallProvider = new AircallConnector();

        /// <summary>
        /// Initializes a new instance of the <see cref="ManageController"/> class.
        /// </summary>
        /// <param name="dependencies">Dependencies needed by the base class.</param>
        public ManageController(BaseControllerDependencies dependencies)
            : base(dependencies, AircallProvider)
        {
        }

        /// <inheritdoc />
        protected override string ProviderName
        {
            get { return AircallConstants.ProviderName; }
        }

        /// <inheritdoc />
        protected override string ViewName
        {
            get { return "Aircall"; }
        }

        /// <inheritdoc />
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async new Task<ActionResult> Create(ProviderWebhookViewModel modelData)
        {
            ProviderWebhookViewModel model = (ProviderWebhookViewModel)await this.CreateNewProfileViewModel();
            model.FriendlyName = modelData.FriendlyName;

            return await base.Create(model);
        }
        
        /// <inheritdoc />
        protected override BaseProfileViewModel CreateViewModel()
        {
            return new ProviderWebhookViewModel(AircallConstants.ProviderName);
        }
    }
}
