namespace MaidenheadService.Model;

public class Distance
{
    public Distance()
    {
        //Needed to serialize as xml
    }
    public Distance(double kilometers)
    {
        Kilometers = (int)Math.Round(kilometers,0,MidpointRounding.AwayFromZero);
        Miles = (int)Math.Round(kilometers * .6214,0,MidpointRounding.AwayFromZero);
    }
    public int Miles { get; set; }

    public int Kilometers { get; set; }
}