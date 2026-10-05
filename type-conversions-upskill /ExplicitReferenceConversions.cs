using System;
using TypeConversions.TypesForConversions;

namespace TypeConversions;

public static class ExplicitReferenceConversions
{
    public static Circle? CastExpressionFromObjectToCircle(object @object)
    {
        try
        {
            return (Circle)@object;
        }
        catch (InvalidCastException)
        {
            return null;
        }
    }

    public static Square? CastExpressionFromObjectToSquare(object @object)
    {
        try
        {
            return (Square)@object;
        }
        catch (InvalidCastException)
        {
            return null;
        }
    }

    public static Shape? CastExpressionFromObjectToShape(object @object)
    {
        try
        {
            return (Shape)@object;
        }
        catch (InvalidCastException)
        {
            return null;
        }
    }

    public static Circle? CastExpressionShapeToCircle(Shape shape)
    {
        try
        {
            return (Circle)shape;
        }
        catch (InvalidCastException)
        {
            return null;
        }
    }

    public static Square? CastExpressionFromShapeToSquare(Shape shape)
    {
        try
        {
            return (Square)shape;
        }
        catch (InvalidCastException)
        {
            return null;
        }
    }

    public static Square? CastExpressionFromIColorableToSquare(IColorable colorable)
    {
        try
        {
            return (Square)colorable;
        }
        catch (InvalidCastException)
        {
            return null;
        }
    }

    public static Shape? AsOperatorFromObjectToShape(object @object)
    {
        return @object as Shape;
    }

    public static Square? AsOperatorFromObjectToSquare(object @object)
    {
        return @object as Square;
    }

    public static Circle? AsOperatorFromObjectToCircle(object @object)
    {
        return @object as Circle;
    }

    public static Square? AsOperatorFromShapeToSquare(Shape shape)
    {
        return shape as Square;
    }

    public static Circle? AsOperatorFromShapeToCircle(Shape shape)
    {
        return shape as Circle;
    }

    public static Square? AsOperatorFromIColorableToSquare(IColorable colorable)
    {
        return colorable as Square;
    }

    public static Shape? PatternMatchingFromObjectToShape(object @object)
    {
        if (@object is Shape shape)
        {
            return shape;
        }
        else
        {
            return null;
        }
    }

    public static Square? PatternMatchingFromObjectToSquare(object @object)
    {
        if (@object is Square square)
        {
            return square;
        }
        else
        {
            return null;
        }
    }

    public static Circle? PatternMatchingFromObjectToCircle(object @object)
    {
        if (@object is Circle circle)
        {
            return circle;
        }
        else
        {
            return null;
        }
    }

    public static Square? PatternMatchingFromShapeToSquare(Shape shape)
    {
        if (shape is Square square)
        {
            return square;
        }
        else
        {
            return null;
        }
    }

    public static Circle? PatternMatchingFromShapeToCircle(Shape shape)
    {
        if (shape is Circle circle)
        {
            return circle;
        }
        else
        {
            return null;
        }
    }

    public static Square? PatternMatchingFromIColorableToSquare(IColorable colorable)
    {
        if (colorable is Square square)
        {
            return square;
        }
        else
        {
            return null;
        }
    }
}
