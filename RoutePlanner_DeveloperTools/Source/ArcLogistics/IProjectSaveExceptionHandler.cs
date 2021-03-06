/*
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

namespace ESRI.ArcLogistics
{
    /// <summary>
    /// Interface represents project's Save method exception handler.
    /// </summary>
    public interface IProjectSaveExceptionHandler
    {
        /// <summary>
        /// Exception handler.
        /// </summary>
        /// <param name="e">Exception.</param>
        /// <returns>Returns 'false' if this exeption must be thrown, 'true' otherwise</returns>
        /// <exception cref="System.ArgumentNullException"><paramref name="e"/>
        /// argument is a null reference.</exception>
        bool HandleException(Exception e);
    }
}
