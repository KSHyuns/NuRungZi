using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class InGameBtnManager : MonoBehaviour
{
    public Text atkCount;       // 어택버튼의 Max 카운트를 인게임에서 보여줄 수 있는 Text입니다. (임시코드입니다. 추후 변경 가능)
    public GameObject Setting;

    int maxAttackCount;         // 어택버튼을 누를 Max 카운트 수 입니다.
    int numOfCount;            // 카운트가 넘어간 횟수입니다.
    
    public bool isPause = false;       // 게임 일시정지를 체크해줍니다

    Player playerInfo;

    void Start()
    {
        maxAttackCount = 1;
        numOfCount = 1;

        playerInfo = FindObjectOfType<Player>();
    }

    void Update()
    {
        if (isPause == true)
            Time.timeScale = 0f;
        else
            Time.timeScale = 1;
    }

    // 공격버튼에 관련된 코드입니다.
    public void AttackButton()
    {
        if (!isPause)
        {
            if (maxAttackCount == 1)
            {
                numOfCount++;

                maxAttackCount += numOfCount;

                // 플레이어가 공격할 시 Bullet 프리팹을 생성합니다.
                playerInfo.Attack();
            }

            maxAttackCount--;

            atkCount.text = maxAttackCount.ToString();
        }
    }

    // 공격횟수를 1로 초기화 시키는 버튼에 관련된 코드입니다.
    public void BMButton()
    {
        if (!isPause)
        {
            // 모든 수치 초기화
            maxAttackCount = 1;
            numOfCount = 1;
            atkCount.text = maxAttackCount.ToString();
        }
    }

    public void SettingButton()
    {
        Setting.SetActive(true);
        isPause = true;
    }

    public void SettingExitButton()
    {
        Setting.SetActive(false);
        isPause = false;
    }

    public void GotoScene()
    {
        SceneManager.LoadScene("Stage");
    }

    public void ReStart()
    {
        SceneManager.LoadScene("PlayScene_JW");
    }
}
