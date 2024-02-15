using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManagerScript : Photon.PunBehaviour
{
    // 誰かがログインする度に生成するプレイヤーPrefab
    public GameObject playerPrefab;
    void Start()
    {
        if (!PhotonNetwork.connected)   //Phootnに接続されていなければ
        {
            SceneManager.LoadScene("Launcher"); //ログイン画面に戻る
            return;
        }
        //Photonに接続していれば自プレイヤーを生成
        GameObject Player = PhotonNetwork.Instantiate("cartman1", new Vector3(0f, 0f, 0f), Quaternion.identity, 0);

        if (Player == null)
        {
            Debug.LogError("プレイヤーの生成に失敗しました。");
        }
    }
    // Update is called once per frame
    void Update()
    {
        // PhotonNetwork.connected の状態変化を監視
        if (!PhotonNetwork.connected)
        {
            SceneManager.LoadScene("Launcher"); // 接続が切断されたらログイン画面に戻る
        }
    }
}