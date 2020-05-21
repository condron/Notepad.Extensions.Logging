﻿using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Notepad.Extensions.Logging.FunctionalTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var sc = new ServiceCollection();
            sc.AddLogging(lb =>
            {
                lb.AddConsole();
                lb.AddNotepad();
            });

            var sp = sc.BuildServiceProvider();
            var logger = sp.GetRequiredService<ILogger<Program>>();

            logger.LogWarning("Here is a warning.");
            logger.LogError(GetException(), "oh no!.");
            logger.LogInformation("Here is some info.");
        }

        static Exception GetException()
        {
            try
            {
                throw new InvalidOperationException("Wheeeeeeee");
            }
            catch (Exception ex)
            {
                return ex;
            }
        }
    }
}
