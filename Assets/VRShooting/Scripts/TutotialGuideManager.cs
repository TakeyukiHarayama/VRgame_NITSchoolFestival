using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class TutotialGuideManager : MonoBehaviour {
    public Text GuideText;
    public Text NextGuideText;
    public Button OKButton;
    public Text OKButtonText;
    public Button NextOKButton;
    public Text NextOKButtonText;
    public Text PageText;
    public Text NextPageText;
    public Canvas GuideCanvas;

    private string guide0 = "ここはじゃがいもに支配された5J VR World...\n次々とあらわれるじゃがいもたちを倒し、5Jの平穏な日常を取り戻そう！";
    private string guide1 = "それではゲームの説明を始めます。頭を動かすとあたりを見渡すことができます。後ろを振り向いてチュートリアルを続けよう！";
    private string guide2 = "じゃがいもがあらわれると右上のマップに赤い点が示され、アラームが鳴ります。背後からも出現するじゃがいもをいち早く発見しよう。";
    private string guide3 = "じゃがいもを倒すには手元の銃を使おう！トリガーを引くことで自分の向いている方向へ弾が発射されます。";
    private string guide4 = "手始めに周りのじゃがいもを倒してみよう！見事じゃがいもに命中するとじゃがいもは爆発し、倒すことができます。";
    private string guide5 = "さあ！VRの世界へ出発＊＊＊";
    private string[] guides;

    private int page;
    private int nextPage;

	// Use this for initialization
	void Start () {
        if (VRMode.vrmode == false)
            GvrViewer.Instance.VRModeEnabled = false;
        this.page = 0;
        this.nextPage = 1;

        this.guides = new string[] { guide0, guide1, guide2, guide3, guide4, guide5 };
    }

    // Update is called once per frame
    void Update()
    {
        this.GuideText.text = guides[page];
        this.PageText.text = (page + 1).ToString() + " / " + guides.Length.ToString();

        if(page > 0 && nextPage >= 2)
        {
            this.NextGuideText.text = guides[nextPage];
            NextPageText.text = (nextPage + 1).ToString() + " / " + guides.Length.ToString();
        }

        if (nextPage == 1)
        {
            this.NextOKButtonText.text = "続ける";
        }
    }

    public void OKButtonPressed()
    {
        page++;
        
        if(page == 1)
        {
            this.NextGuideText.text = "続けるボタンを押そう！";
            this.OKButtonText.text = "";
            Destroy(this.OKButton);
        }
    }

    public void NextOKButtonPressed()
    {
        if(page > 1)
        {
            page++;
        }

        this.NextOKButtonText.text = "OK";


        if (nextPage == guides.Length - 1)
        {
            SceneManager.LoadScene("vrs");
        }
        else if (nextPage < guides.Length)
        {
            nextPage++;

            if (nextPage == guides.Length - 1)
            {
                this.NextOKButtonText.text = "START!";
            }
        }
    }
}
