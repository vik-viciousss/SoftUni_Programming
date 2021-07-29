using System;
using System.Collections.Generic;
using System.Text;

namespace Custom_DI_Workshop.DI.Attributes
{

    [AttributeUsage(AttributeTargets.Constructor)]
    public class Inject : Attribute
    {


    }
}
