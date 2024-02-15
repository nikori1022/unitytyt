using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class LauncherScript : Photon.PunBehaviour
{
    #region Public�ϐ���`
    //Public�ϐ��̒�`�̓R�R��
    #endregion
    #region Private�ϐ�
    //Private�ϐ��̒�`�̓R�R��
    string _gameVersion = "test";   //�Q�[���̃o�[�W�����B�d�l���قȂ�o�[�W�����ƂȂ����Ƃ��̓o�[�W������ύX���Ȃ��ƃG���[����������B
    #endregion
    #region Public Methods
    //���O�C���{�^�����������Ƃ��Ɏ��s�����
    public void Connect()
    {
        if (!PhotonNetwork.connected)
        {                         //Photon�ɐڑ��ł��Ă��Ȃ����
            PhotonNetwork.ConnectUsingSettings(_gameVersion);   //Photon�ɐڑ�����
            Debug.Log("Photon�ɐڑ����܂����B");
        }
    }
    #endregion
    #region Photon�R�[���o�b�N
    //Auto-JoinLobby�Ƀ`�F�b�N�����Ă����Photon�ɐڑ���OnJoinLobby()���Ă΂��B
    public override void OnJoinedLobby()
    {
        Debug.Log("���r�[�ɓ���܂����B");
        //Random�ŕ�����I�сA�����ɓ���i�������������OnPhotonRandomJoinFailed���Ă΂��j
        PhotonNetwork.JoinRandomRoom();
    }
    //JoinRandomRoom�����s�����Ƃ��ɌĂ΂��
    public override void OnPhotonRandomJoinFailed(object[] codeAndMsg)
    {
        Debug.Log("���[���̓����Ɏ��s���܂����B");
        //TestRoom�Ƃ������O�̕������쐬���āA�����ɓ���
        PhotonNetwork.CreateRoom("TestRoom");
    }
    //�����ɓ��������ɌĂ΂��
    public override void OnJoinedRoom()
    {
        Debug.Log("���[���ɓ���܂����B");
        //battle�V�[�������[�h
        PhotonNetwork.LoadLevel("Supermarket wars");
    }
    #endregion
}