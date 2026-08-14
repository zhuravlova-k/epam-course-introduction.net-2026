namespace CreatingMethods;

public static class MethodsWithRefParameters
{
    public static bool ReturnParameterValueAndSetParameterToDefaultValue(ref bool boolValue)
    {
        bool originalValue = boolValue;
        boolValue = default;
        return originalValue;
    }

    public static char ReturnParameterValueAndSetParameterToDefaultValue(ref char charValue)
    {
        char originalValue = charValue;
        charValue = default;
        return originalValue;
    }

    public static float ReturnParameterValueAndSetParameterToDefaultValue(ref float floatValue)
    {
        float originalValue = floatValue;
        floatValue = default;
        return originalValue;
    }

    public static int ReturnParameterValueAndSetParameterToDefaultValue(ref int intValue)
    {
        int originalValue = intValue;
        intValue = default;
        return originalValue;
    }

    public static long ReturnParameterValueAndSetParameterToDefaultValue(ref long longValue)
    {
        long originalValue = longValue;
        longValue = default;
        return originalValue;
    }
}
