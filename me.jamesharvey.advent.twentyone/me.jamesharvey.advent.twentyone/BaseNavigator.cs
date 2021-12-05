using System;
namespace me.jamesharvey.advent.twentyone
{
    public abstract class BaseNavigator
    {
        /// <summary>
        /// Depth position
        /// </summary>
        public int Depth { get; set; }

        /// <summary>
        /// Horizontal Postion
        /// </summary>
        public int Horizontal { get; set; }

        public BaseNavigator()
        {
            Depth = 0;
            Horizontal = 0;
        }

        /// <summary>
        /// Return the location reference - multiplication of Depth and Horizontal position
        /// </summary>
        public int LocationReference
        {
            get
            {
                if (Depth > 0 && Horizontal > 0)
                {
                    return Horizontal * Depth;
                }
                return 0;
            }
        }

        /// <summary>
        /// Parse String from Input into navigation instruction
        /// </summary>
        /// <param name="instruction">Instruction String</param>
        public void ParseInstruction(string instruction)
        {
            string[] instructionDetail = instruction.Split(' ');
            switch (instructionDetail[0])
            {
                case "forward":
                    MoveForward(int.Parse(instructionDetail[1]));
                    break;
                case "up":
                    MoveUp(int.Parse(instructionDetail[1]));
                    break;
                case "down":
                    MoveDown(int.Parse(instructionDetail[1]));
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// Move position Forward
        /// </summary>
        /// <param name="measurement">Distance to move</param>
        public abstract void MoveForward(int measurement);

        /// <summary>
        /// Move position Down
        /// </summary>
        /// <param name="measurement">Distance to move</param>
        public abstract void MoveDown(int measurement);

        /// <summary>
        /// Move position Up
        /// </summary>
        /// <param name="measurement">Distance to move</param>
        public abstract void MoveUp(int measurement);
    }
}
