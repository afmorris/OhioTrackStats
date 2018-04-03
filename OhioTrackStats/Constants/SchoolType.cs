// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SchoolType.cs" company="OhioTrackStats.com">
//   Copyright (c) 2018-2018 OhioTrackStats.com.
//   All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace OhioTrackStats.Constants
{
    using System;

    /// <summary>
    /// Represents a school type.
    /// </summary>
    public class SchoolType : IEquatable<SchoolType>, IEquatable<string>
    {
        /// <summary>
        /// The internal name of the school type.
        /// </summary>
        private readonly string schoolType;

        /// <summary>
        /// Initializes a new instance of the <see cref="SchoolType"/> class.
        /// </summary>
        /// <param name="schoolType">
        /// The name school type.
        /// </param>
        internal SchoolType(string schoolType) => this.schoolType = schoolType;

        /// <summary>
        /// Gets the public school type.
        /// </summary>
        public static SchoolType Public => new SchoolType(nameof(Public));

        /// <summary>
        /// Gets the private school type.
        /// </summary>
        public static SchoolType Private => new SchoolType(nameof(Private));

        /// <summary>
        /// Checks if two <see cref="SchoolType" /> instances are equal.
        /// </summary>
        /// <param name="schoolType1">
        /// The first <see cref="SchoolType" /> instance.
        /// </param>
        /// <param name="gender2">
        /// The second <see cref="SchoolType" /> instance.
        /// </param>
        /// <returns>
        /// A value indicating whether or not the two instances are equal.
        /// </returns>
        public static bool operator ==(SchoolType schoolType1, SchoolType gender2)
        {
            if (ReferenceEquals(null, schoolType1))
            {
                if (ReferenceEquals(null, gender2))
                {
                    return true;
                }

                return false;
            }

            return schoolType1.Equals(gender2);
        }

        /// <summary>
        /// Checks if two <see cref="SchoolType" /> instances are unequal.
        /// </summary>
        /// <param name="schoolType1">
        /// The first <see cref="SchoolType" /> instance.
        /// </param>
        /// <param name="gender2">
        /// The second <see cref="SchoolType" /> instance.
        /// </param>
        /// <returns>
        /// A value indicating whether or not the two instances are unequal.
        /// </returns>
        public static bool operator !=(SchoolType schoolType1, SchoolType gender2)
        {
            if (ReferenceEquals(null, schoolType1))
            {
                if (ReferenceEquals(null, gender2))
                {
                    return false;
                }

                return true;
            }

            return !schoolType1.Equals(gender2);
        }

        /// <summary>
        /// Checks if a <see cref="SchoolType" /> instance is equal to a <see cref="String" />.
        /// </summary>
        /// <param name="schoolType1">
        /// The <see cref="SchoolType" /> instance.
        /// </param>
        /// <param name="schoolType2">
        /// The <see cref="String" /> instance.
        /// </param>
        /// <returns>
        /// A value indicating whether or not the two instances are equal.
        /// </returns>
        public static bool operator ==(SchoolType schoolType1, string schoolType2)
        {
            if (ReferenceEquals(null, schoolType1))
            {
                if (ReferenceEquals(null, schoolType2))
                {
                    return true;
                }

                return false;
            }

            return schoolType1.Equals(schoolType2);
        }

        /// <summary>
        /// Checks if a <see cref="SchoolType" /> instance is unequal to a <see cref="String" />.
        /// </summary>
        /// <param name="schoolType1">
        /// The <see cref="SchoolType" /> instance.
        /// </param>
        /// <param name="schoolType2">
        /// The <see cref="String" /> instance.
        /// </param>
        /// <returns>
        /// A value indicating whether or not the two instances are unequal.
        /// </returns>
        public static bool operator !=(SchoolType schoolType1, string schoolType2)
        {
            if (ReferenceEquals(null, schoolType1))
            {
                if (ReferenceEquals(null, schoolType2))
                {
                    return false;
                }

                return true;
            }

            return !schoolType1.Equals(schoolType2);
        }

        /// <inheritdoc />
        public override string ToString() => this.schoolType;

        /// <inheritdoc />
        public override bool Equals(object obj)
        {
            switch (obj)
            {
                case SchoolType st:
                    return st.ToString() == this.schoolType;
                case string s:
                    return s == this.schoolType;
                default:
                    return false;
            }
        }

        /// <inheritdoc />
        public override int GetHashCode()
        {
            return this.schoolType != null ? this.schoolType.GetHashCode() : 0;
        }

        /// <inheritdoc />
        public bool Equals(SchoolType other)
        {
            if (ReferenceEquals(null, other))
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            return string.Equals(this.schoolType, other.schoolType);
        }

        /// <inheritdoc />
        public bool Equals(string other)
        {
            if (ReferenceEquals(null, other))
            {
                return false;
            }

            if (ReferenceEquals(this.schoolType, other))
            {
                return true;
            }

            return string.Equals(this.schoolType, other);
        }
    }
}