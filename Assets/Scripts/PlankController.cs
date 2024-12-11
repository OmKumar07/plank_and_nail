using System.Collections.Generic;

public class PlankController
{
    private PlankModel model;
    private PlankView view;

    public PlankController(PlankModel model, PlankView view)
    {
        this.model = model;
        this.view = view;
    }

    public void UpdatePlankState()
    {
        if (model.CanFall())
        {
            view.Fall();
        }
    }
}
