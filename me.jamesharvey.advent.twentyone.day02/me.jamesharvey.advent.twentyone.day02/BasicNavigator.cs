using System;
namespace me.jamesharvey.advent.twentyone.day02
{
    public class BasicNavigator : BaseNavigator
    {

        /// <summary>
        /// Move position Forward
        /// </summary>
        /// <param name="measurement">Distance to move</param>
        public override void MoveForward(int measurement)
        {
            Horizontal += measurement;
        }

        /// <summary>
        /// Move position Down
        /// </summary>
        /// <param name="measurement">Distance to move</param>
        public override void MoveDown(int measurement)
        {
            Depth += measurement;
        }

        /// <summary>
        /// Move position Up
        /// </summary>
        /// <param name="measurement">Distance to move</param>
        public override void MoveUp(int measurement)
        {
            Depth -= measurement;
        }
    }
}
