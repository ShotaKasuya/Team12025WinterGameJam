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
    public GameObject MatchWaitingConfpanel; // �J����Panel
    public GameObject DeclarationPanel;
    public Sprite highlightedSprite; // �J�[�\�����d�Ȃ����Ƃ��̉摜
    private Image buttonImage;
    private Sprite normalSprite; // �{�^���̒ʏ�̉摜

    public UnityEvent onClickEvents;

    void Start()
    {
        buttonImage = GetComponent<Image>(); // �C��: �^�𖾎�
        normalSprite = buttonImage.sprite; // �{�^���̒ʏ�̉摜���L������

        // �{�^���R���|�[�l���g������΃N���b�N�C�x���g��ǉ�
        Button button = GetComponent<Button>();
        if (button != null)
        {
            button.onClick.AddListener(() =>
            {
                onClickEvents.Invoke(); // Inspector �Őݒ肵���C�x���g�����s
            });
        }
    }

    // �J�[�\�����{�^���ɏd�Ȃ����Ƃ��̏���
    public void OnPointerEnter(PointerEventData eventData)
    {
        buttonImage.sprite = highlightedSprite; // �J�[�\�����d�Ȃ����Ƃ��̉摜�ɕύX����
        SEManager.Instance.Play(SEPath.SELECTED_SE, 0.3f);
    }

    // �J�[�\�����{�^�����痣�ꂽ�Ƃ��̏���
    public void OnPointerExit(PointerEventData eventData)
    {
        buttonImage.sprite = normalSprite; // �ʏ�̉摜�ɖ߂�
    }

    // �{�^�����N���b�N���ꂽ�Ƃ��̏���
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

    //�ΐ푊�肪�������đΐ��ʂɈڍs����ۂɌĂяo���Ăق����֐��ł�
    public void CloseMatchWaitingConfPanel()
    {
        MatchWaitingConfpanel.SetActive(false);
    }


}
