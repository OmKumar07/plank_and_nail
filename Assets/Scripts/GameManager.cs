using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public List<NailController> nailControllers = new List<NailController>();
    public PlankController plankController;

    private void Start()
    {
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = 60;
        NailView[] nailViews = FindObjectsOfType<NailView>();
        List<NailModel> nailModels = new List<NailModel>();
        foreach (var nailView in nailViews)
        {
            NailModel nailModel = new NailModel();
            nailModels.Add(nailModel);

            NailController nailController = new NailController(nailModel, nailView);
            nailControllers.Add(nailController);
        }
        PlankView plankView = FindObjectOfType<PlankView>();
        if (plankView == null)
        {
            Debug.LogError("PlankView not found in the scene!");
            return;
        }
        PlankModel plankModel = new PlankModel(nailModels);
        plankController = new PlankController(plankModel, plankView);
    }
    public void ReloadScene()
    {
        SceneManager.LoadScene(0);
    }

    private void Update()
    {
        plankController?.UpdatePlankState();
    }
}
