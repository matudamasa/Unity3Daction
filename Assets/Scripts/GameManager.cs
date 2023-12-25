using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;


public class GameManager : MonoBehaviour
{

    [System.NonSerialized]
    public int currentStageNum = 0; //���݂̃X�e�[�W�ԍ��i0�n�܂�j

    [SerializeField]
    string[] stageName; //�X�e�[�W��

    //�ŏ��̏���
    void Start()
    {
        //�V�[����؂�ւ��Ă����̃Q�[���I�u�W�F�N�g���폜���Ȃ��悤�ɂ���
        DontDestroyOnLoad(gameObject);
    }

    //���t���[���̏���
    void Update()
    {

    }

    //���̃X�e�[�W�ɐi�ޏ���
    public void NextStage()
    {
        currentStageNum += 1;

        //�R���[�`�������s
        StartCoroutine(WaitForLoadScene());
    }

    //�V�[���̓ǂݍ��݂Ƒҋ@���s���R���[�`��
    IEnumerator WaitForLoadScene()
    {
        //�V�[����񓯊��œǍ����A�ǂݍ��܂��܂őҋ@����
        yield return SceneManager.LoadSceneAsync(stageName[currentStageNum]);
    }

    //�Q�[���I�[�o�[����
    public void GameOver()
    {

    }
}

