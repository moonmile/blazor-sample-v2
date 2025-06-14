﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorBmi;

public class BmiItem
{
    public string Name { get; set; } = "";
    public double Height { get; set; }
    public double Weight { get; set; }
    public double Bmi => 
        Height == 0? 0.0: Weight / ((Height / 100.0) * (Height / 100.0));
}
