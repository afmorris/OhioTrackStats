// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PerformanceDataConverter.cs" company="OhioTrackStats.com">
//   Copyright (c) 2018-2018 OhioTrackStats.com.
//   All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace OhioTrackStats.DataModels.Converters
{
    using System;
    using System.Data;

    using OhioTrackStats.Models;

    using ServiceStack.OrmLite;

    /// <summary>
    /// Custom converter for the <see cref="PerformanceData" /> type for ORMLite.
    /// </summary>
    public class PerformanceDataConverter : OrmLiteConverter
    {
        /// <inheritdoc />
        public override string ColumnDefinition => "NVARCHAR(50)";

        /// <inheritdoc />
        public override DbType DbType => DbType.String;

        /// <inheritdoc />
        public override object FromDbValue(Type fieldType, object value)
        {
            var output = value.ToString();

            if (output.StartsWith("D|"))
            {
                output = output.Remove(0, 2);
                var distanceSplit = output.Split(':');
                int.TryParse(distanceSplit[0], out int feet);
                float.TryParse(distanceSplit[1], out float inches);
                return new PerformanceData
                           {
                               Distance = new Distance
                                              {
                                                  Feet = feet,
                                                  Inches = inches
                                              },
                               Time = default(TimeSpan)
                           };
            }

            output = output.Remove(0, 2);
            var timeSplit = output.Split(':');
            int.TryParse(timeSplit[0], out int minutes);
            var minuteSplit = timeSplit[1].Split('.');
            int.TryParse(minuteSplit[0], out int seconds);
            int.TryParse(minuteSplit[1], out int milliseconds);

            return new PerformanceData
                       {
                           Distance = default(Distance),
                           Time = new TimeSpan(0, 0, minutes, seconds, milliseconds)
                       };
        }

        /// <inheritdoc />
        public override object ToDbValue(Type fieldType, object value)
        {
            var input = (PerformanceData)value;
            if (input.Time.CompareTo(default(TimeSpan)) == 0)
            {
                return $"D|{input.Distance.Feet}:{input.Distance.Inches}";
            }

            return $"T|{input.Time.Minutes}:{input.Time.Seconds}.{input.Time.Milliseconds}";
        }
    }
}