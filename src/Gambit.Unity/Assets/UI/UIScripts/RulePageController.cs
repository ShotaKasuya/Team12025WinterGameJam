using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RulePageController : MonoBehaviour
{
    public Button nextButton;     // 次のページへ移動するボタン
    public Button backButton;     // 前のページへ移動するボタン
    public Button menuButton;     // メニューへ移動するボタン
    public Button lastButton;     // 最後のページ用ボタン
    public GameObject[] elements; // 表示するGameObjectの配列

    private int currentIndex = 0;

    void Start()
    {
        // 初期状態を設定
        UpdateDisplay();

        // ボタンにリスナーを追加
        nextButton.onClick.AddListener(GoToNextPage);
        backButton.onClick.AddListener(GoToPreviousPage);
        menuButton.onClick.AddListener(BackToTitleScene);
        lastButton.onClick.AddListener(GoToMenuScene); // LastButtonにリスナーを追加

        // ボタンの表示状態を更新
        UpdateButtonStates();
    }

    // 表示を更新するメソッド
    void UpdateDisplay()
    {
        // 全ての要素を非表示にする
        for (int i = 0; i < elements.Length; i++)
        {
            elements[i].SetActive(false);
        }

        // 現在の要素のみを表示
        elements[currentIndex].SetActive(true);
    }

    // 次のページに移動する
    void GoToNextPage()
    {
        if (currentIndex < elements.Length - 1)
        {
            currentIndex++;
            UpdateDisplay();
        }
        UpdateButtonStates(); // ボタンの表示状態を更新
    }

    // 前のページに移動する
    void GoToPreviousPage()
    {
        if (currentIndex > 0)
        {
            currentIndex--;
            UpdateDisplay();
        }
        UpdateButtonStates(); // ボタンの表示状態を更新
    }

    // ボタンの表示状態を更新
    void UpdateButtonStates()
    {
        // 最初の要素ならbackButtonを無効化
        backButton.interactable = currentIndex > 0;

        // 最後の要素ならnextButtonを非表示、lastButtonを表示
        bool isLastElement = currentIndex == elements.Length - 1;
        nextButton.gameObject.SetActive(!isLastElement);
        lastButton.gameObject.SetActive(isLastElement);
    }

    // 最後のページからMenuSceneに遷移する
    void GoToMenuScene()
    {
        SceneManager.LoadScene("TitleScene");
    }

    // スキップしてMenuSceneに移動する
    void BackToTitleScene()
    {
        SceneManager.LoadScene("TitleScene");
    }
}
