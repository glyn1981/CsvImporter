namespace CsvImporter.Test
{
    using System.Collections.Generic;
    using CsvImporter.Data.Models;

    /// <summary>
    /// Compares two Vehicle objects for equality based on their properties.
    /// </summary>
    public class VehicleComparer : IEqualityComparer<Vehicle>
    {
        /// <summary>
        /// Compares two lists of vehicles for equality based on their properties.
        /// </summary>
        /// <param name="x">first list</param>
        /// <param name="y">second list</param>
        /// <returns>boolean that signifies whether the two lists are equal.</returns>
        public bool Equals(Vehicle? x, Vehicle? y)
        {
            if (ReferenceEquals(x, y)) return true;
            if (x is null || y is null) return false;

            return x.Id == y.Id &&
                   x.Make == y.Make &&
                   x.Model == y.Model &&
                   x.Reg == y.Reg &&
                   x.Color == y.Color;
        }
        /// <summary>
        ///  Returns a hash code for the specified object. (Unique signature).          
        /// </summary>
        /// <param name="obj">the vehicle in question.</param>
        /// <returns></returns>
        public int GetHashCode(Vehicle obj)
        {
            if (obj is null) return 0;
            int hash = obj.Id.GetHashCode();
            hash = (hash * 397) ^ (obj.Make?.GetHashCode() ?? 0);
            hash = (hash * 397) ^ (obj.Model?.GetHashCode() ?? 0);
            hash = (hash * 397) ^ (obj.Reg?.GetHashCode() ?? 0);
            hash = (hash * 397) ^ (obj.Color?.GetHashCode() ?? 0);
            return hash;
        }
    }
}
