

class MyClass
{
    public static void Main()
    {
        string[] array = 
        {
            "вертикаль", "кильватер", "апельсин", 
            "спаниель", "австралопитек", "ватерполистка", "кластер", "сталкер", "стрелка", "корабль" 
        };
        

        Dictionary<int, string[]> dictionary1 = CheckForAnagrams(array);

        foreach (var kvp in dictionary1)
        {
            Console.Write($"{kvp.Key}: ");
            foreach (var value in kvp.Value)
            {
                Console.Write($"{value} ");
            }
            Console.WriteLine();
        }
        
        Console.WriteLine();
        
        Dictionary<int, List<string>> dictionary2 = CheckForAnagramsOptimized(array);

        foreach (var kvp in dictionary2)
        {
            Console.Write($"{kvp.Key}: ");
            foreach (var value in kvp.Value)
            {
                Console.Write($"{value} ");
            }
            Console.WriteLine();
        }
        
        
    } 
    
    /// <summary>
    /// находит анаграммы и выводит их
    /// </summary>
    /// <param name="str"> исходный массив строк </param>
    /// <returns> словарь, где ключ - порядковый номер, значение - массив их двух анаграмм </returns>
    public static Dictionary<int, string[]> CheckForAnagrams(string[] str)
    {
        Dictionary<int, string[]> dict = new Dictionary<int, string[]>();
        int key = 0;
    
        for (int i = 0; i < str.Length - 1; i++)
        {
            if (str[i].Length == str[i + 1].Length)
            {
                int p = 0;
                for (int j = 0; j < str[i].Length; j++)
                {
                    for (int k = 0; k < str[i].Length; k++)
                    {
                        if(str[i][j] == str[i][k])
                        {
                            p++;
                            break;
                        }
                    }
                }

                if (p == str[i].Length)
                {
                    string[] newString = {str[i], str[i + 1]};
                    dict.Add(key++, newString);
                }
            }
        }

        return dict;
    }

    public static Dictionary<int, List<string>> CheckForAnagramsOptimized(string[] str)
    {
        Dictionary<int, List<string>> dictionary = new Dictionary<int, List<string>>();
        
        foreach (var value in str)
        {
            int hashCode = value.OrderBy(c => c).GetHashCode();

            if (!dictionary.ContainsKey(hashCode))
            {
                dictionary.Add(hashCode, new List<string>{value});
            }
            else
            {
                dictionary[hashCode].Add(value);
            }

            dictionary.Where(pair => pair.Value.Count >= 2).ToDictionary(pair => pair.Key, pair => pair.Value);
        }
        return dictionary;
    }
}