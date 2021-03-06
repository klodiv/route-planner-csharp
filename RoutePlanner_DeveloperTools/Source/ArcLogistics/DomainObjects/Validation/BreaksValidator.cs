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
using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;
using Microsoft.Practices.EnterpriseLibrary.Validation;
using Microsoft.Practices.EnterpriseLibrary.Validation.Configuration;

namespace ESRI.ArcLogistics.DomainObjects.Validation
{
    /// <summary>
    /// <see cref="T:ESRI.ArcLogistics.DomainObjects.Breaks"/> validator implementation.
    /// </summary>
    [ConfigurationElementType(typeof(CustomValidatorData))]
    sealed class BreaksValidator : Validator<Breaks>
    {
        #region Constructors
    
        /// <summary>
        /// Create a new instance of the <c>BreaksValidator</c> class.
        /// </summary>
        public BreaksValidator()
            : base(null, null)
        { }

        #endregion 

        #region Protected methods
        
        /// <summary>
        /// Does validation.
        /// </summary>
        /// <param name="objectToValidate">Object to validation
        /// (<see cref="T:ESRI.ArcLogistics.DomainObjects.Breaks"/>).</param>
        /// <param name="currentTarget">Ignored.</param>
        /// <param name="key">Ignored.</param>
        /// <param name="validationResults">Validation results.</param>
        protected override void DoValidate(Breaks objectToValidate,
                                           object currentTarget,
                                           string key,
                                           ValidationResults validationResults)
        {
            if (null == objectToValidate)
                return;

            // Check that all breaks have same type.
            if (objectToValidate.Count > 0)
            {
                Type type = objectToValidate[0].GetType();
                foreach (var br in objectToValidate)
                    if (type != br.GetType())
                    {
                        // Breaks have different types. Cant validate brakes.
                        this.LogValidationResult(validationResults, Properties.Messages.Error_BreaksHaveDifferentTypes,
                            currentTarget, key);
                        return;
                    }
            }

            // Doing validation for all breaks.
            for (int index = 0; index < objectToValidate.Count; ++index)
            {
                this.LogValidationResult(validationResults, objectToValidate[index].Error, currentTarget, key);
            }

        }

        /// <summary>
        /// Default message template for validation.
        /// </summary>
        protected override string DefaultMessageTemplate
        {
            get { return Properties.Messages.Error_InvalidBreakDuration; }
        }

        #endregion 
    }
}
