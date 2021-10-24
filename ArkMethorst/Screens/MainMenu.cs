using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using FlatRedBall;
using FlatRedBall.Input;
using FlatRedBall.Instructions;
using FlatRedBall.AI.Pathfinding;
using FlatRedBall.Graphics.Animation;
using FlatRedBall.Graphics.Particle;
using FlatRedBall.Math.Geometry;
using FlatRedBall.Localization;



namespace ArkMethorst.Screens
{
    public partial class MainMenu
    {

        void CustomInitialize()
        {
            PlayerInstance.Position.X = 500;
            PlayerInstance.Position.Y = 500;

        }

        void CustomActivity(bool firstTimeCalled)
        {
            PlayerInstance.Position.X = 500;
            PlayerInstance.Position.Y = 500;

            if(PlayerInstance.InputPickup.WasJustPressed || PlayerInstance.JumpInput.WasJustPressed)
            {
                MoveToScreen("Level1");
            }

        }

        void CustomDestroy()
        {


        }

        static void CustomLoadStaticContent(string contentManagerName)
        {


        }

    }
}
