namespace Abgabe_1_2;

public static class NameController
{
    public static List<string> DivideNamesToList(string allNamesString)
    {
        char[] separators = { ' ', ',' };
        List<string> fullNames =
            new List<string>(allNamesString.Split(separators, StringSplitOptions.RemoveEmptyEntries));

        return fullNames;
    }

    public static (List<string> firstNames, List<string> lastNames) DivideFirstLastName(List<string> names)
    {
        List<string> firstNames = new List<string>();
        List<string> lastNames = new List<string>();

        for (int i = 0; i < names.Count; i++)
        {
            if (i % 2 == 0)
                firstNames.Add(names[i]);
            else
                lastNames.Add(names[i]);
        }

        return (firstNames, lastNames);
    }

    public static string GenerateDriverName(List<string> firstNames, List<string> lastNames)
    {
        Random rnd = new Random();

        string generatedFullName =
            firstNames[rnd.Next(0, firstNames.Count)] + " " + lastNames[rnd.Next(0, lastNames.Count)];

        return generatedFullName;
    }
}