﻿using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace WarcabyTrue
{
    public class Pole : Button
    {
        public bool IsPlayable;
        public Pole(bool b)
        {
            IsPlayable = b;
        }
    }
    
}