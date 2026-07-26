namespace IfStatements;

public static class Task9
{
    public static bool DoSomething(bool b, int i)
    {
        if (b)
        {
            if (i >= -8 && i < -4)
            {
                return false;
            }

            if (i == 0)
            {
                return false;
            }

            if (i > 4 && i <= 8)
            {
                return false;
            }

            return true;
        }

        if (i >= -8 && i < -4)
        {
            return false;
        }

        if (i == 0)
        {
            return false;
        }

        if (i >= 4 && i < 8)
        {
            return false;
        }

        return true;
    }
}
