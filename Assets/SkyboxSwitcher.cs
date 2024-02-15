using UnityEngine;

public class SkyboxSwitcher : MonoBehaviour
{
    public Material firstSkybox; // ��ڂ�Skybox
    public Material secondSkybox; // �������Skybox

    void Update()
    {
        // i�L�[�������ƈ�ڂ�Skybox�ɐ؂�ւ�
        if (Input.GetKeyDown(KeyCode.I))
        {
            RenderSettings.skybox = firstSkybox;
        }
        // o�L�[�������Ƃ������Skybox�ɐ؂�ւ�
        else if (Input.GetKeyDown(KeyCode.O))
        {
            RenderSettings.skybox = secondSkybox;
        }
    }
}