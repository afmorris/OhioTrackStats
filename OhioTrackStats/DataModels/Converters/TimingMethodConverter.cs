// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TimingMethodConverter.cs" company="OhioTrackStats.com">
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
    /// Custom converter for the <see cref="TimingMethod" /> type for ORMLite.
    /// </summary>
    public class TimingMethodConverter : OrmLiteConverter
    {
        /// <inheritdoc />
        public override string ColumnDefinition => "NVARCHAR(20)";

        /// <inheritdoc />
        public override DbType DbType => DbType.String;

        /// <inheritdoc />
        public override object FromDbValue(Type fieldType, object value)
        {
            return new TimingMethod((string)value);
        }

        /// <inheritdoc />
        public override object ToDbValue(Type fieldType, object value)
        {
            return ((TimingMethod)value).ToString();
        }
    }
}