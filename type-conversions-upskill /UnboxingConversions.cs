using System;
using TypeConversions.TypesForConversions;

namespace TypeConversions;

public static class UnboxingConversions
{
    public static Point? CastExpressionFromObjectToPoint(object @object)
    {
        try
        {
            return (Point)@object;
        }
        catch (InvalidCastException)
        {
            return null;
        }
    }

    public static Point? AsOperatorFromObjectToPoint(object @object)
    {
        return @object as Point?;
    }

    public static Point? PatternMatchingFromObjectToPoint(object @object)
    {
        if (@object is Point point)
        {
            return point;
        }
        else
        {
            return null;
        }
    }

    public static Point? CastExpressionFromValueTypeToPoint(ValueType valueType)
    {
        try
        {
            return (Point)valueType;
        }
        catch (InvalidCastException)
        {
            return null;
        }
    }

    public static Point? AsOperatorFromValueTypeToPoint(ValueType valueType)
    {
        return valueType as Point?;
    }

    public static Point? PatternMatchingFromValueTypeToPoint(ValueType valueType)
    {
        if (valueType is Point point)
        {
            return point;
        }
        else
        {
            return null;
        }
    }

    public static Point? CastExpressionFromIColorableToPoint(IColorable colorable)
    {
        try
        {
            return (Point)colorable;
        }
        catch (InvalidCastException)
        {
            return null;
        }
    }

    public static Point? AsOperatorFromIColorableToPoint(IColorable colorable)
    {
        return colorable as Point?;
    }

    public static Point? PatternMatchingFromIColorableToPoint(IColorable colorable)
    {
        if (colorable is Point point)
        {
            return point;
        }
        else
        {
            return null;
        }
    }

    public static Color? CastExpressionFromObjectToColor(object @object)
    {
        try
        {
            return (Color)@object;
        }
        catch (InvalidCastException)
        {
            return null;
        }
    }

    public static Color? AsOperatorFromObjectToColor(object @object)
    {
        return @object as Color?;
    }

    public static Color? PatternMatchingFromObjectToColor(object @object)
    {
        if (@object is Color color)
        {
            return color;
        }
        else
        {
            return null;
        }
    }

    public static Color? CastExpressionFromValueTypeToColor(ValueType valueType)
    {
        try
        {
            return (Color)valueType;
        }
        catch (InvalidCastException)
        {
            return null;
        }
    }

    public static Color? AsOperatorFromValueTypeToColor(ValueType valueType)
    {
        return valueType as Color?;
    }

    public static Color? PatternMatchingFromValueTypeToColor(ValueType valueType)
    {
        if (valueType is Color color)
        {
            return color;
        }
        else
        {
            return null;
        }
    }

    public static Color? CastExpressionFromEnumToColor(Enum @enum)
    {
        try
        {
            return (Color)@enum;
        }
        catch (InvalidCastException)
        {
            return null;
        }
    }

    public static Color? AsOperatorFromEnumToColor(Enum @enum)
    {
        return @enum as Color?;
    }

    public static Color? PatternMatchingFromEnumToColor(Enum @enum)
    {
        if (@enum is Color color)
        {
            return color;
        }
        else
        {
            return null;
        }
    }

    public static int? CastExpressionFromObjectToInt32(object @object)
    {
        try
        {
            return (int)@object;
        }
        catch (InvalidCastException)
        {
            return null;
        }
    }

    public static int? AsOperatorFromObjectToInt32(object @object)
    {
        return @object as int?;
    }

    public static int? PatternMatchingFromObjectToInt32(object @object)
    {
        if (@object is int value)
        {
            return value;
        }
        else
        {
            return null;
        }
    }

    public static int? CastExpressionFromValueTypeToInt32(ValueType valueType)
    {
        try
        {
            return (int)valueType;
        }
        catch (InvalidCastException)
        {
            return null;
        }
    }

    public static int? AsOperatorFromValueTypeToInt32(ValueType valueType)
    {
        return valueType as int?;
    }

    public static int? PatternMatchingFromValueTypeToInt32(ValueType valueType)
    {
        if (valueType is int value)
        {
            return value;
        }
        else
        {
            return null;
        }
    }

    public static int? CastExpressionFromIFormattableToInt32(IFormattable formattable)
    {
        try
        {
            return (int)formattable;
        }
        catch (InvalidCastException)
        {
            return null;
        }
    }

    public static int? AsOperatorFromIFormattableToInt32(IFormattable formattable)
    {
        return formattable as int?;
    }

    public static int? PatternMatchingFromIFormattableToInt32(IFormattable formattable)
    {
        if (formattable is int value)
        {
            return value;
        }
        else
        {
            return null;
        }
    }
}
