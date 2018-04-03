// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Program.cs" company="OhioTrackStats.com">
//   Copyright (c) 2018-2018 OhioTrackStats.com.
//   All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace OhioTrackStats.Database
{
    using System;
    using System.Configuration;
    using System.Linq;
    using System.Reflection;

    using DbUp;

    /// <summary>
    /// This program runs the DbUp scripts to get the given database to the correct level.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// The main entry point of the program. All the magic happens here.
        /// </summary>
        /// <param name="args">
        /// The incoming command-line arguments.
        /// </param>
        /// <returns>
        /// The program's exit code.
        /// </returns>
        public static int Main(string[] args)
        {
            var connectionString = args.FirstOrDefault() ?? ConfigurationManager.ConnectionStrings["OhioTrackStats"].ConnectionString;
            var upgrader = DeployChanges
                .To.SqlDatabase(connectionString)
                .WithScriptsEmbeddedInAssembly(Assembly.GetExecutingAssembly())
                .WithTransactionPerScript()
                .LogToConsole()
                .Build();
            var result = upgrader.PerformUpgrade();

            if (!result.Successful)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(result.Error);
                Console.ResetColor();
#if DEBUG
                Console.ReadLine();
#endif
                return -1;
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Success!");
            Console.ResetColor();
            return 0;
        }
    }
}
