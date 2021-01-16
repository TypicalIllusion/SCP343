using MEC;
using Synapse;
using Synapse.Api;

namespace SCP343Synapse
{
    class SCP343PlayerScript : Synapse.Api.Roles.Role
    {
        public override int GetRoleID() => 343;

        public override string GetRoleName() => "Scp343";

        public override Team GetTeam() => Team.SCP;

        public override void Spawn()
        {
            Player.SendBroadcast(5, "You are SCP 343");
            Player.GodMode = true;
            Player.Bypass = true;
            Player.RankName = "SCP-343";
            foreach (var scpplayer in Server.Get.Players)
                Player.Scp173Controller.IgnoredPlayers.Add(scpplayer);
        }
        public override void DeSpawn()
        {
            Player.GodMode = false;
            Player.Bypass = false;
            Player.RankName = "";
            foreach (var scpplayer in Server.Get.Players)
                Player.Scp173Controller.IgnoredPlayers.Remove(scpplayer);
        }
    }
}
