namespace SD.pesel;

public class PersonId
{
    private readonly string _id;

    public PersonId(string Id)
    {
        _id = Id;
    }
    /// <summary>
    /// Get full year from PESEL
    /// </summary>
    /// <returns></returns>
    public int GetYear()
    {
        string id = _id;
        string year = id.Substring(startIndex: 0, length: 2);
        int yearInt = int.Parse(year);

        string month = id.Substring(startIndex: 2, length: 2);
        int monthInt = int.Parse(month);
        if (monthInt > 20) // 2000-2099
        {
            yearInt += 2000;
        }
        else // 1900-1999
        {
            yearInt += 1900;
        }
        return yearInt;
       
    }

    /// <summary>
    /// Get month from PESEL
    /// </summary>
    public int GetMonth()
    {
        string id = _id;
        string month = id.Substring(startIndex: 2, length: 2);
        int monthInt = int.Parse(month);

        if (monthInt > 20)
        {
            monthInt -= 20;
        }
        else
        {
            monthInt -= 0;
        }
        return monthInt;
    }

    /// <summary>
    /// Get day from PESEL
    /// </summary>
    /// <returns></returns>
    public int GetDay()
    {
        string id = _id;
        string result = id.Substring(startIndex: 4, length: 2);
        int resultInt = int.Parse(result);

        return resultInt;
    }

    /// <summary>
    /// Get year of birth from PESEL
    /// </summary>
    /// <returns></returns>
    public int GetAge()
    {
        string id = _id;
        string year = id.Substring(startIndex: 0, length: 2);
        int yearInt = int.Parse(year);

        string month = id.Substring(startIndex: 2, length: 2);
        int monthInt = int.Parse(month);
        if (monthInt > 20) // 2000-2099
        {
            yearInt += 2000;
        }
        else // 1900-1999
        {
            yearInt += 1900;
        }

        int age = DateTime.Now.Year - yearInt;
        return age;
    }

    /// <summary>
    /// Get gender from PESEL
    /// </summary>
    /// <returns>m</returns>
    /// <returns>f</returns>
    public string GetGender()
    {
        string id = _id;
        int genderDigit = int.Parse(id[9].ToString());

        return genderDigit % 2 == 0 ? "Kobieta" : "Mężczyzna";
    }

    /// <summary>
    /// check if PESEL is valid
    /// </summary>
    /// <returns></returns>
    public bool IsValid()
    {
        string id = _id;
        int[] weights = { 1, 3, 7, 9, 1, 3, 7, 9, 1, 3 };
        int sum = 0;

        for (int i = 0; i < 10; i++)
        {
            sum += weights[i] * int.Parse(id[i].ToString());
        }

        int controlNumber = (10 - (sum % 10)) % 10;

        return controlNumber == int.Parse(id[10].ToString());
    }
}