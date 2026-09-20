namespace UmlDesignBasics;

public class SimpleClass14
{
    private SimpleClass14(int intValue, long longValue, float floatValue, double doubleValue, char charValue, bool booleanValue, string stringValue, object objectValue)
    {
        this.IntValue = intValue;
        this.LongValue = longValue;
        this.FloatValue = floatValue;
        this.DoubleValue = doubleValue;
        this.CharValue = charValue;
        this.BooleanValue = booleanValue;
        this.StringValue = stringValue;
        this.ObjectValue = objectValue;
    }

    public int IntValue { get; private set; }

    public long LongValue { get; private set; }

    public float FloatValue { get; private set; }

    public double DoubleValue { get; private set; }

    public char CharValue { get; private set; }

    public bool BooleanValue { get; private set; }

    public string StringValue { get; private set; }

    public object ObjectValue { get; private set; }

    public static SimpleClass14 Create() => Create(-1132);

    public static SimpleClass14 Create(int intValue) => Create(intValue, -11537L);

    public static SimpleClass14 Create(int intValue, long longValue) => Create(intValue, longValue, 11369.321f);

    public static SimpleClass14 Create(int intValue, long longValue, float floatValue) => Create(intValue, longValue, floatValue, 11867.3854);

    public static SimpleClass14 Create(int intValue, long longValue, float floatValue, double doubleValue) => Create(intValue, longValue, floatValue, doubleValue, 'i');

    public static SimpleClass14 Create(int intValue, long longValue, float floatValue, double doubleValue, char charValue) => Create(intValue, longValue, floatValue, doubleValue, charValue, true);

    public static SimpleClass14 Create(int intValue, long longValue, float floatValue, double doubleValue, char charValue, bool booleanValue) => Create(intValue, longValue, floatValue, doubleValue, charValue, booleanValue, "pqr");

    public static SimpleClass14 Create(int intValue, long longValue, float floatValue, double doubleValue, char charValue, bool booleanValue, string stringValue) => Create(intValue, longValue, floatValue, doubleValue, charValue, booleanValue, stringValue, null);

    public static SimpleClass14 Create(int intValue, long longValue, float floatValue, double doubleValue, char charValue, bool booleanValue, string stringValue, object objectValue)
    {
        return new SimpleClass14(intValue, longValue, floatValue, doubleValue, charValue, booleanValue, stringValue, objectValue);
    }
}
