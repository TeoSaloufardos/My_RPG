using UnityEngine;
using System.Collections;

public class AssetLoader : MonoBehaviour
{
    public string assetBundlePath;

    IEnumerator Start()
    {
        // Load AssetBundle asynchronously
        AssetBundleCreateRequest request = AssetBundle.LoadFromFileAsync(assetBundlePath);
        yield return request;

        // Get reference to the loaded AssetBundle
        AssetBundle assetBundle = request.assetBundle;

        // Load asset from the AssetBundle
        GameObject prefab = assetBundle.LoadAsset<GameObject>("MyPrefab");

        // Instantiate the asset
        Instantiate(prefab);

        // Unload the AssetBundle when finished
        assetBundle.Unload(false);
    }
}