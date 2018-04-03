// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TimingMethod.cs" company="OhioTrackStats.com">
//   Copyright (c) 2018-2018 OhioTrackStats.com.
//   All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace OhioTrackStats.Constants
{
    using System;

    /// <summary>
    /// Represents a timing method.
    /// </summary>
    public class TimingMethod : IEquatable<TimingMethod>, IEquatable<string>
    {
        /// <summary>
        /// The internal name of the timing method.
        /// </summary>
        private readonly string timingMethod;

        /// <summary>
        /// Initializes a new instance of the <see cref="TimingMethod" /> class.
        /// </summary>
        /// <param name="timing">
        /// The timing method.
        /// </param>
        internal TimingMethod(string timing) => this.timingMethod = timing;

        /// <summary>
        /// Gets the Fully Automatic timing method.
        /// </summary>
        public static TimingMethod FullyAutomatic => new TimingMethod(nameof(FullyAutomatic));

        /// <summary>
        /// Gets the manual timing method.
        /// </summary>
        public static TimingMethod Manual => new TimingMethod(nameof(Manual));

        /// <summary>
        /// Gets the field event timing method.
        /// </summary>
        public static TimingMethod FieldEvent => new TimingMethod(nameof(FieldEvent));

        /// <summary>
        /// Checks if two <see cref="TimingMethod" /> instances are equal.
        /// </summary>
        /// <param name="timingMethod1">
        /// The first <see cref="TimingMethod" /> instance.
        /// </param>
        /// <param name="timingMethod2">
        /// The second <see cref="TimingMethod" /> instance.
        /// </param>
        /// <returns>
        /// A value indicating whether or not the two instances are equal.
        /// </returns>
        public static bool operator ==(TimingMethod timingMethod1, TimingMethod timingMethod2)
        {
            if (ReferenceEquals(null, timingMethod1))
            {
                if (ReferenceEquals(null, timingMethod2))
                {
                    return true;
                }

                return false;
            }

            return timingMethod1.Equals(timingMethod2);
        }

        /// <summary>
        /// Checks if two <see cref="TimingMethod" /> instances are unequal.
        /// </summary>
        /// <param name="timingMethod1">
        /// The first <see cref="TimingMethod" /> instance.
        /// </param>
        /// <param name="timingMethod2">
        /// The second <see cref="TimingMethod" /> instance.
        /// </param>
        /// <returns>
        /// A value indicating whether or not the two instances are unequal.
        /// </returns>
        public static bool operator !=(TimingMethod timingMethod1, TimingMethod timingMethod2)
        {
            if (ReferenceEquals(null, timingMethod1))
            {
                if (ReferenceEquals(null, timingMethod2))
                {
                    return false;
                }

                return true;
            }

            return !timingMethod1.Equals(timingMethod2);
        }

        /// <summary>
        /// Checks if a <see cref="TimingMethod" /> instance is equal to a <see cref="String" />.
        /// </summary>
        /// <param name="timingMethod1">
        /// The <see cref="TimingMethod" /> instance.
        /// </param>
        /// <param name="timingMethod2">
        /// The <see cref="String" /> instance.
        /// </param>
        /// <returns>
        /// A value indicating whether or not the two instances are equal.
        /// </returns>
        public static bool operator ==(TimingMethod timingMethod1, string timingMethod2)
        {
            if (ReferenceEquals(null, timingMethod1))
            {
                if (ReferenceEquals(null, timingMethod2))
                {
                    return true;
                }

                return false;
            }

            return timingMethod1.Equals(timingMethod2);
        }

        /// <summary>
        /// Checks if a <see cref="TimingMethod" /> instance is unequal to a <see cref="String" />.
        /// </summary>
        /// <param name="timingMethod1">
        /// The <see cref="TimingMethod" /> instance.
        /// </param>
        /// <param name="timingMethod2">
        /// The <see cref="String" /> instance.
        /// </param>
        /// <returns>
        /// A value indicating whether or not the two instances are unequal.
        /// </returns>
        public static bool operator !=(TimingMethod timingMethod1, string timingMethod2)
        {
            if (ReferenceEquals(null, timingMethod1))
            {
                if (ReferenceEquals(null, timingMethod2))
                {
                    return false;
                }

                return true;
            }

            return !timingMethod1.Equals(timingMethod2);
        }

        /// <inheritdoc />
        public override string ToString() => this.timingMethod;

        /// <inheritdoc />
        public override bool Equals(object obj)
        {
            switch (obj)
            {
                case TimingMethod tm:
                    return tm.ToString() == this.timingMethod;
                case string s:
                    return s == this.timingMethod;
                default:
                    return false;
            }
        }

        /// <inheritdoc />
        public override int GetHashCode()
        {
            return this.timingMethod != null ? this.timingMethod.GetHashCode() : 0;
        }

        /// <inheritdoc />
        public bool Equals(TimingMethod other)
        {
            if (ReferenceEquals(null, other))
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            return string.Equals(this.timingMethod, other.timingMethod);
        }

        /// <inheritdoc />
        public bool Equals(string other)
        {
            if (ReferenceEquals(null, other))
            {
                return false;
            }

            if (ReferenceEquals(this.timingMethod, other))
            {
                return true;
            }

            return string.Equals(this.timingMethod, other);
        }
    }
}