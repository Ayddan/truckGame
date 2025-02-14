using System.Collections;
using Assets.Scripts.Views;
using UnityEngine;


public class LoadingSpotsController
{
    LoadingSpotsData loadingSpotsData;
    LoadingSpotsView loadingSpotsView;

    public LoadingSpotsController(LoadingSpotsData loadingSpotsData, LoadingSpotsView loadingSpotsView)
    {
        this.loadingSpotsData = loadingSpotsData;
        this.loadingSpotsView = loadingSpotsView;
    }

    public LoadingSpotData GetLoadingSpotData(int id)
    {
        return loadingSpotsData.loadingSpotsDataList[id];
    }

    public void CreateLoadingSpot(LoadingSpotData loadingSpotData) 
    {
        loadingSpotsData.loadingSpotsDataList.Add(loadingSpotData);
    }

    public void UpdateLoadingSpot(LoadingSpotData loadingSpotData)
    {
        loadingSpotsData.loadingSpotsDataList[loadingSpotData.id] = loadingSpotData;
    }
}
