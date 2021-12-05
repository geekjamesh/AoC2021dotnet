using System;
namespace me.jamesharvey.advent.twentyone
{
    public class AimingNavigator : BaseNavigator
    {
        public int Aim { get; set; }

        public AimingNavigator() : base()
        {
            Aim = 0;
        }

        /// <summary>
        /// Move position Forward
        /// </summary>
        /// <param name="measurement">Distance to move</param>
        public override void MoveForward(int measurement)
        {
            Horizontal += measurement;
            Depth += (Aim * measurement);
        }

        /// <summary>
        /// Move position Down
        /// </summary>
        /// <param name="measurement">Distance to move</param>
        public override void MoveDown(int measurement)
        {
            Aim += measurement;
        }

        /// <summary>
        /// Move position Up
        /// </summary>
        /// <param name="measurement">Distance to move</param>
        public override void MoveUp(int measurement)
        {
            Aim -= measurement;
        }
    }
}
