using IronPython.Hosting;
using Microsoft.Scripting.Hosting;

public class PythonExeScript 
{
	
    void PythonExeScript()
    {

        ScriptEngine engine = Python.CreateEngine();
        ScriptScope scope = engine.CreateScope();
        engine.ExecuteFile(@"C:\Users\osmirnov\Documents\repos\Unity3d\ConsoleAppDigitRecognizer\PythonData\DigitRecognize.py", scope);
        int x = scope.GetVariable("x");
        Debug.Log(x);
    }

}