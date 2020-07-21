using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GlobalData
{
    private static bool versusAI;

    public static bool VersusAI
    {
        get
        {
            return versusAI;
        }
        set
        {
            versusAI = value;
        }
    }
}
