// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Gender.cs" company="OhioTrackStats.com">
//   Copyright (c) 2018-2018 OhioTrackStats.com.
//   All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace OhioTrackStats.Constants
{
    using System;

    /// <summary>
    /// Represents a gender.
    /// </summary>
    public class Gender : IEquatable<Gender>, IEquatable<string>
    {
        /// <summary>
        /// The internal name of the gender.
        /// </summary>
        private readonly string gender;

        /// <summary>
        /// Initializes a new instance of the <see cref="Gender" /> class.
        /// </summary>
        /// <param name="gender">
        /// The name of the gender.
        /// </param>
        internal Gender(string gender) => this.gender = gender;

        /// <summary>
        /// Gets the Male gender.
        /// </summary>
        public static Gender Male => new Gender(nameof(Male));

        /// <summary>
        /// Gets the Female gender.
        /// </summary>
        public static Gender Female => new Gender(nameof(Female));

        /// <summary>
        /// Checks if two <see cref="Gender" /> instances are equal.
        /// </summary>
        /// <param name="gender1">
        /// The first <see cref="Gender" /> instance.
        /// </param>
        /// <param name="gender2">
        /// The second <see cref="Gender" /> instance.
        /// </param>
        /// <returns>
        /// A value indicating whether or not the two instances are equal.
        /// </returns>
        public static bool operator ==(Gender gender1, Gender gender2)
        {
            if (ReferenceEquals(null, gender1))
            {
                if (ReferenceEquals(null, gender2))
                {
                    return true;
                }

                return false;
            }

            return gender1.Equals(gender2);
        }

        /// <summary>
        /// Checks if two <see cref="Gender" /> instances are unequal.
        /// </summary>
        /// <param name="gender1">
        /// The first <see cref="Gender" /> instance.
        /// </param>
        /// <param name="gender2">
        /// The second <see cref="Gender" /> instance.
        /// </param>
        /// <returns>
        /// A value indicating whether or not the two instances are unequal.
        /// </returns>
        public static bool operator !=(Gender gender1, Gender gender2)
        {
            if (ReferenceEquals(null, gender1))
            {
                if (ReferenceEquals(null, gender2))
                {
                    return false;
                }

                return true;
            }

            return !gender1.Equals(gender2);
        }

        /// <summary>
        /// Checks if a <see cref="Gender" /> instance is equal to a <see cref="String" />.
        /// </summary>
        /// <param name="gender1">
        /// The <see cref="Gender" /> instance.
        /// </param>
        /// <param name="gender2">
        /// The <see cref="String" /> instance.
        /// </param>
        /// <returns>
        /// A value indicating whether or not the two instances are equal.
        /// </returns>
        public static bool operator ==(Gender gender1, string gender2)
        {
            if (ReferenceEquals(null, gender1))
            {
                if (ReferenceEquals(null, gender2))
                {
                    return true;
                }

                return false;
            }

            return gender1.Equals(gender2);
        }

        /// <summary>
        /// Checks if a <see cref="Gender" /> instance is unequal to a <see cref="String" />.
        /// </summary>
        /// <param name="gender1">
        /// The <see cref="Gender" /> instance.
        /// </param>
        /// <param name="gender2">
        /// The <see cref="String" /> instance.
        /// </param>
        /// <returns>
        /// A value indicating whether or not the two instances are unequal.
        /// </returns>
        public static bool operator !=(Gender gender1, string gender2)
        {
            if (ReferenceEquals(null, gender1))
            {
                if (ReferenceEquals(null, gender2))
                {
                    return false;
                }

                return true;
            }

            return !gender1.Equals(gender2);
        }

        /// <inheritdoc />
        public override string ToString() => this.gender;

        /// <inheritdoc />
        public override bool Equals(object obj)
        {
            switch (obj)
            {
                case Gender g:
                    return g.ToString() == this.gender;
                case string s:
                    return s == this.gender;
                default:
                    return false;
            }
        }

        /// <inheritdoc />
        public override int GetHashCode()
        {
            return this.gender != null ? this.gender.GetHashCode() : 0;
        }

        /// <inheritdoc />
        public bool Equals(Gender other)
        {
            if (ReferenceEquals(null, other))
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            return string.Equals(this.gender, other.gender);
        }

        /// <inheritdoc />
        public bool Equals(string other)
        {
            if (ReferenceEquals(null, other))
            {
                return false;
            }

            if (ReferenceEquals(this.gender, other))
            {
                return true;
            }

            return string.Equals(this.gender, other);
        }
    }
}