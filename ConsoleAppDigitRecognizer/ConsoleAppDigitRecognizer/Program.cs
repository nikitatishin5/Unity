using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;
using IronPython.Hosting;
using Microsoft.Scripting.Hosting;

namespace ConsoleAppDigitRecognizer
{
    class Program
    {
        static void Main(string[] args)
        {
            //ScriptEngine engine = Python.CreateEngine();
            //engine.ExecuteFile(@"D:\ProjectsCSharp\ConsoleAppDigitRecognizer\python_scripts\Hello.py");
            var image = System.Drawing.Image.FromFile(@"C:\Users\Ann\Pictures\0.png"); ;
            ScriptEngine engine = Python.CreateEngine();
            ScriptScope scope = engine.CreateScope();
            scope.SetVariable("image", image);
            
            engine.ExecuteFile(@"D:\ProjectsCSharp\ConsoleAppDigitRecognizer\python_scripts\DigitRecognize.py", scope);
            int xNumber = scope.GetVariable("OutputNumber");
            Console.WriteLine( "Нарисовнное число равно: {0}", xNumber);

            Console.ReadLine();
        }
    }
}
