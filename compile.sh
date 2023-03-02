#!/bin/bash
mcs /t:winexe /r:System.Windows.Forms.dll,System.Drawing.dll,System.Security.dll *.cs
if test -x HashCalculator.exe ; then
    mono HashCalculator.exe
fi
