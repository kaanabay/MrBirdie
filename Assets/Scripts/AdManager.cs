using System.Collections;
using UnityEngine;
using UnityEngine.Monetization;

public class AdManager : MonoBehaviour
{
    public string placementId = "video";

    private void Start()
    {
    }

    public void ShowAd()
    {
        Debug.Log("ShowAd started.........");
        StartCoroutine(ShowAdWhenReady());
    }

    private IEnumerator ShowAdWhenReady()
    {
        while (!Monetization.IsReady(placementId))
        {
            Debug.Log("Monetization is not ready...");
            yield return new WaitForSeconds(0.25f);
        }

        ShowAdPlacementContent ad = null;
        ad = Monetization.GetPlacementContent(placementId) as ShowAdPlacementContent;

        Debug.Log("Ad is null: " + ad == null);

        if (ad != null)
        {
            ad.Show();
        }
    }
}