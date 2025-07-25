using System.Collections.Immutable;

namespace WarTime.Win95KeyGen.Lib;

public static class KeyGenerator
{
    private static readonly Random _random = new Random();

    public static Key GenerateKey()
    {
        return new Key
        {
            SegmentA = GenerateSegmentA(),
            SegmentB = GenerateSegmentB(),
            SegmentC = GenerateSegmentC(),
            SegmentD = GenerateSegmentD(),
        };
    }

    public static List<Key> GenerateKeys(int quantity)
    {
        var keys = new List<Key>(quantity);
        for (var i = 0; i < quantity; i++)
        {
            keys.Add(GenerateKey());
        }
        return keys;
    }

    public static bool ValidateKey(string key)
    {
        throw new NotImplementedException("Key validation logic is not implemented yet.");
    }

    private static string GenerateSegmentA()
    {
        var day = _random.Next(1, 367);
        var year = Math.Abs(_random.Next(1995, 2003)) % 100;
        var dateCode = $"{day:D3}{year:D2}";
        return dateCode;
    }

    private static string GenerateSegmentB()
    {
        const string OemMarker = "OEM";
        return OemMarker;
    }

    private static string GenerateSegmentC()
    {
        const int size = 7;
        var blacklist = ImmutableArray.Create(0, 8, 9);
        var part = new int[size];

        do
        {
            part[0] = 0;
            for (var i = 1; i < size; i++)
            {
                int value;
                do
                {
                    value = _random.Next(0, 10);
                } while (blacklist.Contains(value));
                part[i] = value;
            }
        } while (part.Sum() % 7 != 0);
        return string.Join("", part);
    }

    private static string GenerateSegmentD()
    {
        var noise = _random.Next(0, 100000);
        return $"{noise:D5}";
    }
}
