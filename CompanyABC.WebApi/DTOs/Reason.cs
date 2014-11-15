using System;
using System.Linq;

namespace CompanyABC.WebApi.DTOs
{
    public class Reason : IEquatable<Reason>
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public bool Equals(Reason other)
        {
            bool isEqual = false;
            if (other != null)
            {
                isEqual =
                    other.Id == Id &&
                    string.Equals(other.Name, Name);
            }
            return isEqual;
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as Reason);
        }

        public override int GetHashCode()
        {
            int hashCode = Id.GetHashCode();
            if (Name != null)
            {
                hashCode = Name.GetHashCode();
            }
            return hashCode;
        }
    }
}