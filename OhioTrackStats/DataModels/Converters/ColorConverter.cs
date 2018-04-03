// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ColorConverter.cs" company="OhioTrackStats.com">
//   Copyright (c) 2018-2018 OhioTrackStats.com.
//   All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace OhioTrackStats.DataModels.Converters
{
    using System;
    using System.Data;
    using System.Drawing;

    using ServiceStack.OrmLite;

    /// <summary>
    /// Custom converter for the <see cref="Color" /> type for ORMLite.
    /// </summary>
    public class ColorConverter : OrmLiteConverter
    {
        /// <inheritdoc />
        public override string ColumnDefinition => "INT";

        /// <inheritdoc />
        public override DbType DbType => DbType.Int32;

        /// <inheritdoc />
        public override object FromDbValue(Type fieldType, object value)
        {
            if (int.TryParse(value.ToString(), out var result))
            {
                return Color.FromArgb(result);
            }

            return Color.Transparent;
        }

        /// <inheritdoc />
        public override object ToDbValue(Type fieldType, object value)
        {
            return ((Color)value).ToArgb();
        }
    }
}