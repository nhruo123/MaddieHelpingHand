﻿using Celeste.Mod.Entities;
using Celeste.Mod.MaxHelpingHand.Entities;
using Microsoft.Xna.Framework;
using Celeste.Mod.MaxHelpingHand.Module;

namespace Celeste.Mod.MaxHelpingHand.Triggers {
    [CustomEntity("MaxHelpingHand/PopStrawberrySeedsTrigger")]
    public class PopStrawberrySeedsTrigger : Trigger {
        private readonly bool popMultiRoomStrawberrySeeds;

        public PopStrawberrySeedsTrigger(EntityData data, Vector2 offset) : base(data, offset) {
            popMultiRoomStrawberrySeeds = data.Bool("popMultiRoomStrawberrySeeds");
        }

        public override void OnStay(Player player) {
            base.OnStay(player);

            foreach (Follower follower in player.Leader.Followers.ToArray()) {
                if (follower.Entity is StrawberrySeed &&
                    (popMultiRoomStrawberrySeeds || !(follower.Entity is MultiRoomStrawberrySeed))) {

                    player.Leader.LoseFollower(follower);
                }
            }

            if (popMultiRoomStrawberrySeeds) {
                MaxHelpingHandModule.Instance.Session.CollectedMultiRoomStrawberrySeeds.Clear();
            }
        }
    }
}
