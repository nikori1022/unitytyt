using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManagerScript : Photon.PunBehaviour
{
    // �N�������O�C������x�ɐ�������v���C���[Prefab
    public GameObject playerPrefab;
    void Start()
    {
        if (!PhotonNetwork.connected)   //Phootn�ɐڑ�����Ă��Ȃ����
        {
            SceneManager.LoadScene("Launcher"); //���O�C����ʂɖ߂�
            return;
        }
        //Photon�ɐڑ����Ă���Ύ��v���C���[�𐶐�
        GameObject Player = PhotonNetwork.Instantiate("cartman1", new Vector3(0f, 0f, 0f), Quaternion.identity, 0);

        if (Player == null)
        {
            Debug.LogError("�v���C���[�̐����Ɏ��s���܂����B");
        }
    }
    // Update is called once per frame
    void Update()
    {
        // PhotonNetwork.connected �̏�ԕω����Ď�
        if (!PhotonNetwork.connected)
        {
            SceneManager.LoadScene("Launcher"); // �ڑ����ؒf���ꂽ�烍�O�C����ʂɖ߂�
        }
    }
}