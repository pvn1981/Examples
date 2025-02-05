using System;

namespace TypeofExample;

class Program
{
    public enum Cats { Рыжик = 3, Барсик = 5, Мурзик, Васька, Пушок };



    static void Main(string[] args)
    {
        // Перечисляем все элементы перечисления
        
        // 1
        string[] catNames = Enum.GetNames(typeof(Cats));

        //2
        // string[] catNames = typeof(Cats).GetEnumNames();

        try
        {
            foreach (var t in catNames)
            {
                Console.WriteLine("t: {0}, iValue: {1}", t, Convert.ToInt32(Enum.Parse<Cats>(t)));
            }
        }
        catch(ArgumentException e)
        {
            Console.WriteLine($"e: {e.Message}");
        }
    }
}
