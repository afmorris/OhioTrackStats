// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GenderConverter.cs" company="OhioTrackStats.com">
//   Copyright (c) 2018-2018 OhioTrackStats.com.
//   All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace OhioTrackStats.DataModels.Converters
{
    using System;
    using System.Data;

    using OhioTrackStats.Constants;

    using ServiceStack.OrmLite;

    /// <summary>
    /// Custom converter for the <see cref="Gender" /> type for ORMLite.
    /// </summary>
    public class GenderConverter : OrmLiteConverter
    {
        /// <inheritdoc />
        public override string ColumnDefinition => "NVARCHAR(10)";

        /// <inheritdoc />
        public override DbType DbType => DbType.String;

        /// <inheritdoc />
        public override object FromDbValue(Type fieldType, object value)
        {
            return new Gender((string)value);
        }

        /// <inheritdoc />
        public override object ToDbValue(Type fieldType, object value)
        {
            return ((Gender)value).ToString();
        }
    }
}