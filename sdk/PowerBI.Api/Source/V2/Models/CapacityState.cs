// <auto-generated>
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.
// </auto-generated>

namespace Microsoft.PowerBI.Api.V2.Models
{
    using Newtonsoft.Json;

    /// <summary>
    /// Defines values for CapacityState.
    /// </summary>
    /// <summary>
    /// Determine base value for a given allowed value if exists, else return
    /// the value itself
    /// </summary>
    [JsonConverter(typeof(CapacityStateConverter))]
    public struct CapacityState : System.IEquatable<CapacityState>
    {
        private CapacityState(string underlyingValue)
        {
            UnderlyingValue=underlyingValue;
        }

        /// <summary>
        /// Not Supported
        /// </summary>
        public static readonly CapacityState NotActivated = "NotActivated";

        /// <summary>
        /// Capacity ready for use
        /// </summary>
        public static readonly CapacityState Active = "Active";

        /// <summary>
        /// Capacity in activation process
        /// </summary>
        public static readonly CapacityState Provisioning = "Provisioning";

        /// <summary>
        /// Capacity failed to provisioned
        /// </summary>
        public static readonly CapacityState ProvisionFailed = "ProvisionFailed";

        /// <summary>
        /// Capacity suspended for use
        /// </summary>
        public static readonly CapacityState Suspended = "Suspended";

        /// <summary>
        /// Not Supported
        /// </summary>
        public static readonly CapacityState PreSuspended = "PreSuspended";

        /// <summary>
        /// Capacity in process of being deleted
        /// </summary>
        public static readonly CapacityState Deleting = "Deleting";

        /// <summary>
        /// Capacity has been deleted and is not available
        /// </summary>
        public static readonly CapacityState Deleted = "Deleted";

        /// <summary>
        /// Capacity can not be used
        /// </summary>
        public static readonly CapacityState Invalid = "Invalid";

        /// <summary>
        /// Capacity Sku change is in progress
        /// </summary>
        public static readonly CapacityState UpdatingSku = "UpdatingSku";


        /// <summary>
        /// Underlying value of enum CapacityState
        /// </summary>
        private readonly string UnderlyingValue;

        /// <summary>
        /// Returns string representation for CapacityState
        /// </summary>
        public override string ToString()
        {
            return UnderlyingValue.ToString();
        }

        /// <summary>
        /// Compares enums of type CapacityState
        /// </summary>
        public bool Equals(CapacityState e)
        {
            return UnderlyingValue.Equals(e.UnderlyingValue);
        }

        /// <summary>
        /// Implicit operator to convert string to CapacityState
        /// </summary>
        public static implicit operator CapacityState(string value)
        {
            return new CapacityState(value);
        }

        /// <summary>
        /// Implicit operator to convert CapacityState to string
        /// </summary>
        public static implicit operator string(CapacityState e)
        {
            return e.UnderlyingValue;
        }

        /// <summary>
        /// Overriding == operator for enum CapacityState
        /// </summary>
        public static bool operator == (CapacityState e1, CapacityState e2)
        {
            return e2.Equals(e1);
        }

        /// <summary>
        /// Overriding != operator for enum CapacityState
        /// </summary>
        public static bool operator != (CapacityState e1, CapacityState e2)
        {
            return !e2.Equals(e1);
        }

        /// <summary>
        /// Overrides Equals operator for CapacityState
        /// </summary>
        public override bool Equals(object obj)
        {
            return obj is CapacityState && Equals((CapacityState)obj);
        }

        /// <summary>
        /// Returns for hashCode CapacityState
        /// </summary>
        public override int GetHashCode()
        {
            return UnderlyingValue.GetHashCode();
        }

    }
}
