using UnityEngine;

public class SkyboxSwitcher : MonoBehaviour
{
    public Material firstSkybox; // 一つ目のSkybox
    public Material secondSkybox; // もう一つのSkybox

    void Update()
    {
        // iキーを押すと一つ目のSkyboxに切り替え
        if (Input.GetKeyDown(KeyCode.I))
        {
            RenderSettings.skybox = firstSkybox;
        }
        // oキーを押すともう一つのSkyboxに切り替え
        else if (Input.GetKeyDown(KeyCode.O))
        {
            RenderSettings.skybox = secondSkybox;
        }
    }
}