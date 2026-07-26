namespace IfStatements;

public static class Task10
{
    public static int DoSomething(bool b1, bool b2, int i)
    {
        if (b1)
        {
            if (b2)
            {
                if (i >= -9 && i <= -2)
                {
                    return 5 + i;
                }

                if (i == 0)
                {
                    return -1;
                }

                if (i >= 2 && i <= 9)
                {
                    return 10 - i;
                }

                return i;
            }

            if (i >= -9 && i <= -2)
            {
                return 5 - i;
            }

            if (i == 0)
            {
                return -1;
            }

            if (i >= 2 && i <= 9)
            {
                return 10 + i;
            }

            return i;
        }

        if (b2)
        {
            if (i <= -10 || i >= 10)
            {
                return i + 1;
            }

            if (i > -5 && i < 0)
            {
                return i + 10;
            }

            if (i > 0 && i < 5)
            {
                return i + 10;
            }

            if (i == 0)
            {
                return 1;
            }

            return i;
        }

        if (i <= -10 || i >= 10)
        {
            return i - 1;
        }

        if (i > -5 && i < 0)
        {
            return i - 10;
        }

        if (i > 0 && i < 5)
        {
            return i - 10;
        }

        if (i == 0)
        {
            return -1;
        }

        return i;
    }
}
