﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ValidationAttributes
{
    public class MyRequiredAttribute : MyValidationAttribute
    {
        public override bool IsValid(object obj)
        {
            if ((string)obj == null)
            {
                return false;
            }
            return true;
        }
    }
}
