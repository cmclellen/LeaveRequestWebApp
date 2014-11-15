using System;
using System.Data.Entity.Validation;
using System.Linq;

namespace CompanyABC.Data.Helpers
{
    public static class DbEntityValidationExceptionHelpers
    {
        /// <summary>
        /// Adds the details.
        /// </summary>
        /// <param name="dbEntityValidationException">The database entity validation exception.</param>
        /// <returns></returns>
        public static Exception AddDetails(this DbEntityValidationException dbEntityValidationException)
        {
            var errorMessages = dbEntityValidationException.EntityValidationErrors
                .SelectMany(x => x.ValidationErrors)
                .Select(x => x.ErrorMessage);

            // Join the list to a single string.
            var fullErrorMessage = string.Join("; ", errorMessages);

            // Combine the original exception message with the new one.
            var exceptionMessage = string.Concat(dbEntityValidationException.Message, " The validation errors are: ",
                fullErrorMessage);

            // Throw a new DbEntityValidationException with the improved exception message.
            return new DbEntityValidationException(exceptionMessage, dbEntityValidationException.EntityValidationErrors);
        }
    }
}