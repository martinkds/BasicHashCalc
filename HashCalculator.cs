using System;
using System.Windows.Forms;

public class HashCalculator
{
    
    [STAThread]
    static void Main()
    {
        HashCalculatorGui form = new HashCalculatorGui();
        Application.Run(form);
    }
}
