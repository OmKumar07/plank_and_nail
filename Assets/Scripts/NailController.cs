using UnityEngine;

public class NailController
{
    private NailModel model;
    private NailView view;

    public NailController(NailModel model, NailView view)
    {
        this.model = model;
        this.view = view;

        this.view.OnNailClicked += HandleNailClicked;
    }

    private void HandleNailClicked(NailView nailView)
    {
        if (!model.IsRemoved)
        {
            model.RemoveNail();
            view.RemoveVisual();
        }
    }
}
