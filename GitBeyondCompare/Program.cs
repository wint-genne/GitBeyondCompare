using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;

namespace GitBeyondCompare
{
    class Program
    {
        static void Main(string[] args)
        {
            var source = args[0];
            var target = args[1];

            Console.WriteLine(source + " " + target);

            if (File.Exists(source) && IsTemp(source))
            {
                var temp = Path.GetTempFileName();
                File.Copy(source, temp, true);
                source = temp;
            }
            if (File.Exists(target) && IsTemp(target))
            {
                var temp = Path.GetTempFileName();
                File.Copy(target, temp, true);
                target = temp;
            }

            Process.Start(@"c:\Program Files (x86)\Beyond Compare 3\bcomp.exe", source + " " + target);
        }

        private static bool IsTemp(string source)
        {
            Console.WriteLine(Path.GetDirectoryName(source).ToLower() + " == " + Path.GetTempPath().ToLower());
            return Path.GetDirectoryName(source).ToLower() + "\\" == Path.GetTempPath().ToLower();
        }
    }
}
