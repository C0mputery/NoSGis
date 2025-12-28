using BepInEx;

namespace BepInEx5.PluginTemplate
{
    [BepInPlugin(PluginInfo.PLUGIN_GUID, PluginInfo.PLUGIN_NAME, PluginInfo.PLUGIN_VERSION)]
    public class Plugin : BaseUnityPlugin
    {
        private void Update()
        {
            if (PhotonNetwork.isMasterClient)
            {
                foreach (PhotonPlayer player in PhotonNetwork.otherPlayers)
                {
                    if (player.NickName == "Player_SGi")
                    {
                        foreach (PhotonView view in FindObjectsOfType<PhotonView>())
                        {
                            if (view.owner == player && view.gameObject.tag == "Player" && view.gameObject.name.StartsWith("TABS") && MainMenuHandler.IS_RED)
                            {
                                PhotonNetwork.CloseConnection(player);
                                return;
                            }
                        }
                    }
                }
            }
        }
    }
}
