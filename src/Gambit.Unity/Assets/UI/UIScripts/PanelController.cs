using UnityEngine;
using UnityEngine.UI;

public class PanelController : MonoBehaviour
{
    public GameObject MatchingConfpanel; // 開閉するPanel
    public Button openButton; // Panelを開くボタン
    public Button closeButton; // Panelを閉じるボタン

    void Start()
    {
        // 初期状態でPanelを非表示にする
        //MatchingConfpanel.SetActive(false);

        // ボタンにイベントを登録
        openButton.onClick.AddListener(OpenPanel);
        closeButton.onClick.AddListener(ClosePanel);
    }

    void OpenPanel()
    {
        MatchingConfpanel.SetActive(true);
    }

    void ClosePanel()
    {
        MatchingConfpanel.SetActive(false);
    }
}
