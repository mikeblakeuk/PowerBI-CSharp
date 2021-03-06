// <auto-generated>
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.
// </auto-generated>

namespace Microsoft.PowerBI.Api.V2.Models
{
    using Newtonsoft.Json;

    /// <summary>
    /// Defines values for Days.
    /// </summary>
    /// <summary>
    /// Determine base value for a given allowed value if exists, else return
    /// the value itself
    /// </summary>
    [JsonConverter(typeof(DaysConverter))]
    public struct Days : System.IEquatable<Days>
    {
        private Days(string underlyingValue)
        {
            UnderlyingValue=underlyingValue;
        }

        public static readonly Days Monday = "Monday";

        public static readonly Days Tuesday = "Tuesday";

        public static readonly Days Wednesday = "Wednesday";

        public static readonly Days Thursday = "Thursday";

        public static readonly Days Friday = "Friday";

        public static readonly Days Saturday = "Saturday";

        public static readonly Days Sunday = "Sunday";


        /// <summary>
        /// Underlying value of enum Days
        /// </summary>
        private readonly string UnderlyingValue;

        /// <summary>
        /// Returns string representation for Days
        /// </summary>
        public override string ToString()
        {
            return UnderlyingValue.ToString();
        }

        /// <summary>
        /// Compares enums of type Days
        /// </summary>
        public bool Equals(Days e)
        {
            return UnderlyingValue.Equals(e.UnderlyingValue);
        }

        /// <summary>
        /// Implicit operator to convert string to Days
        /// </summary>
        public static implicit operator Days(string value)
        {
            return new Days(value);
        }

        /// <summary>
        /// Implicit operator to convert Days to string
        /// </summary>
        public static implicit operator string(Days e)
        {
            return e.UnderlyingValue;
        }

        /// <summary>
        /// Overriding == operator for enum Days
        /// </summary>
        public static bool operator == (Days e1, Days e2)
        {
            return e2.Equals(e1);
        }

        /// <summary>
        /// Overriding != operator for enum Days
        /// </summary>
        public static bool operator != (Days e1, Days e2)
        {
            return !e2.Equals(e1);
        }

        /// <summary>
        /// Overrides Equals operator for Days
        /// </summary>
        public override bool Equals(object obj)
        {
            return obj is Days && Equals((Days)obj);
        }

        /// <summary>
        /// Returns for hashCode Days
        /// </summary>
        public override int GetHashCode()
        {
            return UnderlyingValue.GetHashCode();
        }

    }
}
