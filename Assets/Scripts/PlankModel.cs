using System.Collections.Generic;

public class PlankModel
{
    private List<NailModel> nails;

    public PlankModel(List<NailModel> nails)
    {
        this.nails = nails;
    }

    public bool CanFall()
    {
        foreach (var nail in nails)
        {
            if (!nail.IsRemoved) return false;
        }
        return true;
    }
}
