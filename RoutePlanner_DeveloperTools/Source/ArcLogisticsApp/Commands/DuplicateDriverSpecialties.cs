﻿/*
 | Version 10.1.84
 | Copyright 2013 Esri
 |
 | Licensed under the Apache License, Version 2.0 (the "License");
 | you may not use this file except in compliance with the License.
 | You may obtain a copy of the License at
 |
 |    http://www.apache.org/licenses/LICENSE-2.0
 |
 | Unless required by applicable law or agreed to in writing, software
 | distributed under the License is distributed on an "AS IS" BASIS,
 | WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 | See the License for the specific language governing permissions and
 | limitations under the License.
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ESRI.ArcLogistics.App.Pages;
using ESRI.ArcLogistics.DomainObjects;
using System.Collections;
using System.Collections.ObjectModel;

namespace ESRI.ArcLogistics.App.Commands
{
    /// <summary>
    /// Command duplicates driver specialties
    /// </summary>
    class DuplicateDriverSpecialties : DuplicateCommandBase
    {
        #region Public Fields

        public const string COMMAND_NAME = "ArcLogistics.Commands.DuplicateDriverSpecialties";

        public override string Name
        {
            get
            {
                return COMMAND_NAME;
            }
        }

        #endregion

        #region DuplicateCommandBase Protected Methods

        /// <summary>
        /// Duplicates driver specialties
        /// </summary>
        protected override void _Duplicate()
        {
            Project project = App.Current.Project;

            List<DriverSpecialty> selectedSpecialties = new List<DriverSpecialty>();

            foreach (DriverSpecialty specialty in ((ISupportSelection)ParentPage).SelectedItems)
                selectedSpecialties.Add(specialty);

            foreach (DriverSpecialty driverSpecialty in selectedSpecialties)
            {
                DriverSpecialty ds = driverSpecialty.Clone() as DriverSpecialty;
                ds.Name = DataObjectNamesConstructor.GetDuplicateName(driverSpecialty.Name, project.DriverSpecialties);
                project.DriverSpecialties.Add(ds);
            }            

            App.Current.Project.Save();
        }

        #endregion DuplicateCommandBase Protected Methods

        #region DuplicateCommandBase Protected Properties

        protected override ISupportDataObjectEditing ParentPage
        {
            get
            {
                if (_parentPage == null)
                {
                    SpecialtiesPage page = (SpecialtiesPage)((MainWindow)App.Current.MainWindow).GetPage(PagePaths.SpecialtiesPagePath);

                    // get driver specialties panel
                    _parentPage = page.driverSpecialties;
                }
                return _parentPage;
            }
        }

        #endregion DuplicateCommandBase Protected Properties

        #region Private Members

        private ISupportDataObjectEditing _parentPage;

        #endregion Private Members
    }
}
