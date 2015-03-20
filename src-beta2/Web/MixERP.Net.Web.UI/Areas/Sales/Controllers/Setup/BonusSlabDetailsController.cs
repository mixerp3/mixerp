﻿/********************************************************************************
Copyright (C) Binod Nepal, Mix Open Foundation (http://mixof.org).

This file is part of MixERP.

MixERP is free software: you can redistribute it and/or modify
it under the terms of the GNU General Public License as published by
the Free Software Foundation, either version 3 of the License, or
(at your option) any later version.

MixERP is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU General Public License for more details.

You should have received a copy of the GNU General Public License
along with MixERP.  If not, see <http://www.gnu.org/licenses/>.
***********************************************************************************/

using System.Web.Mvc;
using MixERP.Net.UI.ScrudFactory;
using MixERP.Net.Web.UI.Sales.Resources;
using MixERP.Net.Web.UI.Providers;
using System.Collections.Generic;
using MixERP.Net.Common.Helpers;


namespace MixERP.Net.Web.UI.Sales.Controllers.Setup
{
    [RouteArea("Sales")]
    [RoutePrefix("setup/bonus-slab-details")]
    [Route("{action=index}")]
    public class BonusSlabDetailsController : ScrudController
    {
        public ActionResult Index()
        {
            const string view = "~/Areas/Sales/Views/Setup/BonusSlabDetails.cshtml";

            return View(view, this.GetConfig());
        }

        public override Config GetConfig()
        {
            Config config = ScrudProvider.GetScrudConfig();
               
                config.KeyColumn = "bonus_slab_detail_id";
                config.TableSchema = "core";
                config.Table = "bonus_slab_details";
                config.ViewSchema = "core";
                config.View = "bonus_slab_detail_scrud_view";
                config.DisplayFields = GetDisplayFields();
                config.DisplayViews = GetDisplayViews();
                config.Text = Titles.BonusSlabDetails;
                config.ResourceAssembly = typeof(BonusSlabDetailsController).Assembly;

                this.AddScrudCustomValidatorMessages();

                return config;
            
        }

        private static string GetDisplayFields()
        {
            List<string> displayFields = new List<string>();
            ScrudHelper.AddDisplayField(displayFields, "core.bonus_slabs.bonus_slab_id",
                ConfigurationHelper.GetDbParameter("BonusSlabDisplayField"));
            return string.Join(",", displayFields);
        }

        private static string GetDisplayViews()
        {
            List<string> displayViews = new List<string>();
            ScrudHelper.AddDisplayView(displayViews, "core.bonus_slabs.bonus_slab_id", "core.bonus_slab_scrud_view");
            return string.Join(",", displayViews);
        }

        private void AddScrudCustomValidatorMessages()
        {
            ViewData["CompareAmountErrorMessage"] = Warnings.CompareAmountErrorMessage;
        }
    }
}