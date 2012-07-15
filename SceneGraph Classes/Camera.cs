using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace AlluringNinja.SceneGraph_Classes
{
    public class Camera
    {
        Vector2 positionVector = new Vector2(0, 0);

        public void setPositionVector(Vector2 positionVector)
        {
            //System.Console.WriteLine("Setting position vector to " + positionVector);
            this.positionVector = positionVector;
        }

        public Vector2 getPositionVector()
        {
            return positionVector;    
        }

        public Matrix getPositionMatrix()
        {
            Vector3 translateVector = new Vector3(0, 0, 0);
            translateVector.X = positionVector.X;
            translateVector.Y = positionVector.Y;
            //System.Console.WriteLine("Position Vector in getPositionMatrix is " + positionVector);
            //System.Console.WriteLine("Translate vector is " + translateVector);
            Matrix translationMatrix = Matrix.CreateTranslation(translateVector);

            return translationMatrix;
        }
    }
}
