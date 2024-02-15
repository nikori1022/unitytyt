using UnityEngine;
using UnityEngine.UI;
using System.Collections;
public class NameInputField : MonoBehaviour
{
    #region Private�ϐ���`
    static string playerNamePrefKey = "PlayerName";
    #endregion
    #region MonoBehaviour�R�[���o�b�N
    void Start()
    {
        string defaultName = "";
        InputField _inputField = this.GetComponent<InputField>();
        //�O��v���C�J�n���ɓ��͂������O�����[�h���ĕ\��
        if (_inputField != null)
        {
            if (PlayerPrefs.HasKey(playerNamePrefKey))
            {
                defaultName = PlayerPrefs.GetString(playerNamePrefKey);
                _inputField.text = defaultName;
            }
        }
    }
    #endregion
    #region Public Method
    public void SetPlayerName(string value)
    {
        PhotonNetwork.playerName = value + " ";     //����Q�[���ŗ��p����v���C���[�̖��O��ݒ�
        PlayerPrefs.SetString(playerNamePrefKey, value);    //����̖��O���Z�[�u
        Debug.Log(PhotonNetwork.player.NickName);   //player�̖��O�̊m�F�B�i���삪�m�F�ł���΂��̍s�͏����Ă������j
    }
    #endregion
}