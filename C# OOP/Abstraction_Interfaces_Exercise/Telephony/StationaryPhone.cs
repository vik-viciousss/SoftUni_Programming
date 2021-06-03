using System;
using System.Collections.Generic;
using System.Text;

namespace Telephony
{
    public class StationaryPhone : Phone, ICallable
    {
        public override string Call(string number)
        {
            Validator.ThrowIfNumberIsInvalid(number);

            return $"Dialing... {number}";
        }
    }
}
