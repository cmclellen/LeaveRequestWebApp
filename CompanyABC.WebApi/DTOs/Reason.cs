using System;
using System.Linq;

namespace CompanyABC.WebApi.DTOs
{
    public class Reason : IEquatable<Reason>
    {
        public string DisplayName { get; set; }

        public bool Equals(Reason other)
        {
            bool isEqual = false;
            if (other != null)
            {
                isEqual = string.Equals(other.DisplayName, DisplayName);
            }
            return isEqual;
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as Reason);
        }

        public override int GetHashCode()
        {
            int hashCode = 0;
            if (DisplayName != null)
            {
                hashCode = DisplayName.GetHashCode();
            }
            return hashCode;
        }
    }
}