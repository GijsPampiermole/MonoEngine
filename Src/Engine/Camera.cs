using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended;
using MonoGame.Extended.ViewportAdapters;
using System;

namespace Engine.Src.Engine
{
    internal class Camera
    {
        Controls controls = new Controls();

        

        public void MoveCamera(GameTime gameTime)
        {
            var speed = 200;
            var seconds = gameTime.GetElapsedSeconds();
            var movementDirection = controls.GetMovementDirection();
            GlobalVariables._cameraPosition += movementDirection * seconds * speed;
            GlobalVariables._cameraPosition.Y = Convert.ToInt32(GlobalVariables._cameraPosition.Y);
            GlobalVariables._cameraPosition.X = Convert.ToInt32(GlobalVariables._cameraPosition.X);
        }

        public void setCameraPos(int x, int y)
        {
            GlobalVariables._cameraPosition.X = x;
            GlobalVariables._cameraPosition.Y = y;
        }
    }
}
