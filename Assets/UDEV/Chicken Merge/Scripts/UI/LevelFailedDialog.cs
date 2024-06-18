using UDEV.DMTool;
using Thirdweb;
using UnityEngine.UI;
using UnityEngine;

namespace UDEV.ChickenMerge
{
    public class LevelFailedDialog : Dialog
    {
        public Button replayBtn;
        public Button homeBtn;

        public override void Show()
        {
            base.Show();
            AdmobController.Ins.ShowInterstitial();
        }

        public void BackHome()
        {
            Close();
            Helper.LoadScene(GameScene.Menu.ToString(), true);
        }

        public async void Replay()
        {
            replayBtn.interactable = false;
            homeBtn.interactable = false;
            Contract contract = ThirdwebManager.Instance.SDK.GetContract("0x539Ab53B7414809bDF652099098f0798E625c484");
            var data = await contract.ERC20.Claim("1");
            Debug.Log("Gold were claimed!");
            replayBtn.interactable = true;
            homeBtn.interactable = true;
            Close();
            GameController.Ins?.Replay();
        }
    }

}