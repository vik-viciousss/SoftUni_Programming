﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Telephony
{
    public interface IBrowsable : ICallable
    {
        void Browse(string website);
    }
}
