﻿using BenchmarkDotNet.Running;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BenchmarkAnts
{
    class Program
    {
        public static void Main(string[] args) 
        {
            var summary = BenchmarkRunner.Run<DeadAntsV1N2>();
        }
    }
}
