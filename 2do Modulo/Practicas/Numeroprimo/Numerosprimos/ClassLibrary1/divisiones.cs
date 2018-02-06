namespace ClassLibrary1
{
    public class divisiones
    {
        public static int EsPrimo(int i)
        {
            int division = 0, j;
            for (j = 2; j <= i; j++)
            {
                if (i % j == 0)
                {
                    division++;
                }
            }
            return division;
        }
    }
}

