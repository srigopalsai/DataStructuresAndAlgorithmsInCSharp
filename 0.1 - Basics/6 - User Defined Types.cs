using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataStructuresAndAlgorithms._0._1___Basics
{
    interface I1
    {

    }
    class Cl1 : I1
    { 

    }

    // Cannot inherit Class.
    struct St1 : I1 //, Cl1
    { 

    }

    // Cannot inherit Struct.
    struct Cl2 : I1 //, St1
    {

    }

    class _6___User_Defined_Types
    {

    }
}
