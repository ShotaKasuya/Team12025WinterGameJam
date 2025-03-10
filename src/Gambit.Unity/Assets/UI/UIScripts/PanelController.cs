using UnityEngine;
using UnityEngine.UI;

public class PanelController : MonoBehaviour
{
    public GameObject MatchingConfpanel; // �J����Panel
    public Button openButton; // Panel���J���{�^��
    public Button closeButton; // Panel�����{�^��

    void Start()
    {
        // ������Ԃ�Panel���\���ɂ���
        //MatchingConfpanel.SetActive(false);

        // �{�^���ɃC�x���g��o�^
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
