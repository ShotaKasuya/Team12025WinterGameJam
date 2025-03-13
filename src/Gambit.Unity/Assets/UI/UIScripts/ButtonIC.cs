using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using KanKikuchi.AudioManager;
using UnityEngine.SceneManagement;

public class ButtonIC : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject MatchWaitingConfpanel; // 開閉するPanel
    public GameObject DeclarationPanel;
    public Sprite highlightedSprite; // カーソルが重なったときの画像
    private Image buttonImage;
    private Sprite normalSprite; // ボタンの通常の画像

    public UnityEvent onClickEvents;

    void Start()
    {
        buttonImage = GetComponent<Image>(); // 修正: 型を明示
        normalSprite = buttonImage.sprite; // ボタンの通常の画像を記憶する

        // ボタンコンポーネントがあればクリックイベントを追加
        Button button = GetComponent<Button>();
        if (button != null)
        {
            button.onClick.AddListener(() =>
            {
                onClickEvents.Invoke(); // Inspector で設定したイベントを実行
            });
        }
    }

    // カーソルがボタンに重なったときの処理
    public void OnPointerEnter(PointerEventData eventData)
    {
        buttonImage.sprite = highlightedSprite; // カーソルが重なったときの画像に変更する
        SEManager.Instance.Play(SEPath.SELECTED_SE, 0.3f);
    }

    // カーソルがボタンから離れたときの処理
    public void OnPointerExit(PointerEventData eventData)
    {
        buttonImage.sprite = normalSprite; // 通常の画像に戻す
    }

    // ボタンがクリックされたときの処理
    public void OnDecideButtonClick()
    {
        SEManager.Instance.Play(SEPath.DECISION_SE, 0.1f);
    }

    public void OnCancelButtonClick()
    {
        SEManager.Instance.Play(SEPath.CANCEL_SE2, 0.2f);
    }

    public void ToRuleScene()
    {
        SceneManager.LoadScene("RuleScene");
    }

    public void OnMatchButtonClick()
    {
        SEManager.Instance.Play(SEPath.PUSH_GAME_START_BUTTON_SE, 0.1f);
        MatchWaitingConfpanel.SetActive(true);
    }

    public void OnDeclarationButtonClick()
    {
        DeclarationPanel.SetActive(true);
        SEManager.Instance.Play(SEPath.DECLARATION_BUTTON_SE, 0.2f);

    }

    public void BackDeclarationButtonClick()
    {
        DeclarationPanel.SetActive(false);
        SEManager.Instance.Play(SEPath.CANCEL_SE2, 0.2f);
    }

    //対戦相手が見つかって対戦画面に移行する際に呼び出してほしい関数です
    public void CloseMatchWaitingConfPanel()
    {
        MatchWaitingConfpanel.SetActive(false);
    }


}
