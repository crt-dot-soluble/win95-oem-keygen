namespace WarTime.Win95KeyGen.Lib;

public struct Key
{
    public string SegmentA;
    public string SegmentB;
    public string SegmentC;
    public string SegmentD;

    public override string ToString()
    {
        return $"{SegmentA}-{SegmentB}-{SegmentC}-{SegmentD}";
    }
}
