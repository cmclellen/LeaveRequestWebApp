using System;
using System.Linq;

namespace CompanyABC.Core.Config
{
    /// <summary>
    /// Contract defining application settings.
    /// </summary>
    public interface IApplicationSettings
    {
        /// <summary>
        /// Gets or sets the <see cref="System.String"/> with the specified error.
        /// </summary>
        /// <value>
        /// The <see cref="System.String"/>.
        /// </value>
        /// <returns></returns>
        string this[String settingsKey] { get; }
    }
}