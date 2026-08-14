namespace CreatingMethods;

public static class MethodsWithInParameters
{
    public static bool ReturnDefaultValueWithoutChangingParameter(in bool boolValue) => false;

    public static char ReturnDefaultValueWithoutChangingParameter(in char charValue) => '\0';

    public static float ReturnDefaultValueWithoutChangingParameter(in float floatValue) => 0.0f;

    public static int ReturnDefaultValueWithoutChangingParameter(in int intValue) => 0;

    public static long ReturnDefaultValueWithoutChangingParameter(in long longValue) => 0L;
}
