using System.Reflection;
using System.Text;
using HarmonyLib;
using Sandbox.Game.Localization;
using Sandbox.Graphics.GUI;
using SpaceEngineers.Game.GUI;
using VRage;

namespace SpawnScreenFix
{
    [HarmonyPatch]
    internal static class RespawnScreenPatch
    {
        private static MethodBase TargetMethod()
        {
            return AccessTools.FirstMethod(typeof(MyGuiScreenMedicals),
                m => m.Name.Contains("<RefreshMedicalRooms>g__AddSuitRespawn"));
        }

        private static void Postfix(MyGuiControlTable ___m_respawnsTable)
        {
            var row = ___m_respawnsTable.Find(b => b.GetCell(0).Text.EqualsStrFast(MyTexts.GetString(MySpaceTexts.SpawnInSpaceSuit)));
            if (row is null)
                return;
            ___m_respawnsTable.Remove(row);
            ___m_respawnsTable.Insert(0, row);
            ___m_respawnsTable.SelectedRow = row;
        }
    }
}