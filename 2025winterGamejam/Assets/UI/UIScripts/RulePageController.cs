using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RulePageController : MonoBehaviour
{
    public Button nextButton;     // ���̃y�[�W�ֈړ�����{�^��
    public Button backButton;     // �O�̃y�[�W�ֈړ�����{�^��
    public Button menuButton;     // ���j���[�ֈړ�����{�^��
    public Button lastButton;     // �Ō�̃y�[�W�p�{�^��
    public GameObject[] elements; // �\������GameObject�̔z��

    private int currentIndex = 0;

    void Start()
    {
        // ������Ԃ�ݒ�
        UpdateDisplay();

        // �{�^���Ƀ��X�i�[��ǉ�
        nextButton.onClick.AddListener(GoToNextPage);
        backButton.onClick.AddListener(GoToPreviousPage);
        menuButton.onClick.AddListener(BackToTitleScene);
        lastButton.onClick.AddListener(GoToMenuScene); // LastButton�Ƀ��X�i�[��ǉ�

        // �{�^���̕\����Ԃ��X�V
        UpdateButtonStates();
    }

    // �\�����X�V���郁�\�b�h
    void UpdateDisplay()
    {
        // �S�Ă̗v�f���\���ɂ���
        for (int i = 0; i < elements.Length; i++)
        {
            elements[i].SetActive(false);
        }

        // ���݂̗v�f�݂̂�\��
        elements[currentIndex].SetActive(true);
    }

    // ���̃y�[�W�Ɉړ�����
    void GoToNextPage()
    {
        if (currentIndex < elements.Length - 1)
        {
            currentIndex++;
            UpdateDisplay();
        }
        UpdateButtonStates(); // �{�^���̕\����Ԃ��X�V
    }

    // �O�̃y�[�W�Ɉړ�����
    void GoToPreviousPage()
    {
        if (currentIndex > 0)
        {
            currentIndex--;
            UpdateDisplay();
        }
        UpdateButtonStates(); // �{�^���̕\����Ԃ��X�V
    }

    // �{�^���̕\����Ԃ��X�V
    void UpdateButtonStates()
    {
        // �ŏ��̗v�f�Ȃ�backButton�𖳌���
        backButton.interactable = currentIndex > 0;

        // �Ō�̗v�f�Ȃ�nextButton���\���AlastButton��\��
        bool isLastElement = currentIndex == elements.Length - 1;
        nextButton.gameObject.SetActive(!isLastElement);
        lastButton.gameObject.SetActive(isLastElement);
    }

    // �Ō�̃y�[�W����MenuScene�ɑJ�ڂ���
    void GoToMenuScene()
    {
        SceneManager.LoadScene("TitleScene");
    }

    // �X�L�b�v����MenuScene�Ɉړ�����
    void BackToTitleScene()
    {
        SceneManager.LoadScene("TitleScene");
    }
}
