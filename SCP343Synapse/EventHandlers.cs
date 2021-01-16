using System.Collections.Generic;
using Synapse;
using Synapse.Api;
using System;

namespace SCP343Synapse
{
    class EventHandlers
    {
        public static List<Player> scp343 = new List<Player>();
        public EventHandlers()
        {
            Server.Get.Events.Player.PlayerSetClassEvent += Player_PlayerSetClassEvent;
            Server.Get.Events.Player.PlayerPickUpItemEvent += Player_PlayerPickUpItemEvent;
            Server.Get.Events.Player.PlayerCuffTargetEvent += Player_PlayerCuffTargetEvent;
            Server.Get.Events.Player.PlayerDropItemEvent += Player_PlayerDropItemEvent;
            Server.Get.Events.Map.WarheadDetonationEvent += Map_WarheadDetonationEvent;
            Server.Get.Events.Round.RoundEndEvent += Round_RoundEndEvent;
            Server.Get.Events.Map.LCZDecontaminationEvent += Map_LCZDecontaminationEvent;
            Server.Get.Events.Player.PlayerLeaveEvent += Player_PlayerLeaveEvent;
            Server.Get.Events.Player.PlayerDeathEvent += Player_PlayerDeathEvent;
            Server.Get.Events.Scp.ScpAttackEvent += Scp_ScpAttackEvent;
            Server.Get.Events.Scp.Scp096.Scp096AddTargetEvent += Scp096_Scp096AddTargetEvent;
            Server.Get.Events.Player.PlayerDamageEvent += Player_PlayerDamageEvent;
        }

        private void Player_PlayerDamageEvent(Synapse.Api.Events.SynapseEventArguments.PlayerDamageEventArgs ev)
        {
            if(ev.Killer.RoleID == 035 || ev.Killer.RoleID == 056)
            {
                ev.Allow = false;
            }
        }

        private void Scp096_Scp096AddTargetEvent(Synapse.Api.Events.SynapseEventArguments.Scp096AddTargetEventArgument ev)
        {
            if (ev.Player.RoleID == 343)
                ev.Allow = false;
        }

        private void Scp_ScpAttackEvent(Synapse.Api.Events.SynapseEventArguments.ScpAttackEventArgs ev)
        {
            if (ev.AttackType == Synapse.Api.Enum.ScpAttackType.Scp106_Grab && ev.Target.RoleID == 343)
                ev.Allow = false;
        }
        private void Player_PlayerDeathEvent(Synapse.Api.Events.SynapseEventArguments.PlayerDeathEventArgs ev)
        {
            if (ev.Victim.RoleID == 343)
            {
                Kill343(ev.Victim);
            }
        }

        private void Player_PlayerLeaveEvent(Synapse.Api.Events.SynapseEventArguments.PlayerLeaveEventArgs ev)
        {
            if (ev.Player.RoleID == 343)
            {
                Kill343(ev.Player);
            }
        }

        private void Map_LCZDecontaminationEvent(Synapse.Api.Events.SynapseEventArguments.LCZDecontaminationEventArgs ev)
        {
            foreach (Player pp in scp343)
            {
                pp.Kill(DamageTypes.Decont);
                pp.SendBroadcast(5, "You got killed by decontamination!");
                if (pp.RoleID == 343)
                {
                    Kill343(pp);
                }
            }
        }

        private void Round_RoundEndEvent()
        {
            scp343.Clear();
        }

        private void Map_WarheadDetonationEvent()
        {
            foreach (Player pp in scp343)
            {
                pp.Kill(DamageTypes.Nuke);
                pp.SendBroadcast(5, "Somehow the nuke radiation killed you!");
                if (pp.RoleID == 343)
                {
                    Kill343(pp);
                }
            }
        }

        private void Player_PlayerDropItemEvent(Synapse.Api.Events.SynapseEventArguments.PlayerDropItemEventArgs ev)
        {
            if (ev.Player.RoleID == 343)
            {
                ev.Allow = false;
            }
        }

        private void Player_PlayerCuffTargetEvent(Synapse.Api.Events.SynapseEventArguments.PlayerCuffTargetEventArgs ev)
        {
            if (ev.Target.RoleID == 343)
            {
                ev.Allow = false;
                ev.Cuffer.SendBroadcast(3, "You can\'t cuff SCP-343!");
            }
        }

        private void Player_PlayerPickUpItemEvent(Synapse.Api.Events.SynapseEventArguments.PlayerPickUpItemEventArgs ev)
        {
            if (ev.Player.RoleID == 343)
            {
                ev.Allow = false;
            }
        }

        private void Player_PlayerSetClassEvent(Synapse.Api.Events.SynapseEventArguments.PlayerSetClassEventArgs ev)
        {
            if (ev.Player.RoleType == RoleType.ClassD)
            {
                Random r = new Random();
                int SpawnChance = r.Next(0, 101);
                if (SpawnChance <= Plugin.Config.SpawnChance)
<<<<<<< HEAD
                    ev.Player.RoleID = 343;
=======
                Spawn343(ev.Player);
>>>>>>> 5ca6720c88b4e8cc989fc192bbabd997a04b896e
            }
        }
        public static void Spawn343(Player pp)
        {
            if (scp343.Count < 1)
            {
                scp343.Add(pp);
                pp.SendBroadcast(5, Plugin.Config.Message);
                pp.GodMode = true;
                pp.Bypass = true;
<<<<<<< HEAD
                pp.Scp173Controller.IgnoredPlayers.Add(pp);
                pp.RankName = "SCP-343";
=======
                pp.DisplayName = "SCP-343";
>>>>>>> 5ca6720c88b4e8cc989fc192bbabd997a04b896e
            }
        }
        public static void Kill343(Player pp)
        {
            if (pp.RoleID == 343)
            {
                scp343.Remove(pp);
            }
            pp.GodMode = false;
            pp.Bypass = false;
            pp.RankName = "";
        }
    }
}
