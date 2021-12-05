using System.Collections.Generic;
using Xunit;

namespace me.jamesharvey.advent.twentyone.test
{
    public class AimingNavigatorTest
    {
        [Fact]
        public void MoveDown_MovesSubDown_ByGivenAmount()
        {
            AimingNavigator classUnderTest = new AimingNavigator();
            classUnderTest.MoveDown(5);
            Assert.Equal(5, classUnderTest.Aim);
        }

        [Fact]
        public void MoveUp_MovesSubUp_ByGivenAmount_GivenDepthIsDeeperThanValue()
        {
            AimingNavigator classUnderTest = new AimingNavigator();
            classUnderTest.MoveDown(10);
            classUnderTest.MoveUp(5);
            Assert.Equal(5, classUnderTest.Aim);
        }

        [Fact]
        public void MoveForward_MovesSubForward_ByGivenAmount()
        {
            AimingNavigator classUnderTest = new AimingNavigator();
            classUnderTest.MoveDown(5);
            classUnderTest.MoveForward(5);
            Assert.Equal(5, classUnderTest.Horizontal);
            Assert.Equal(5, classUnderTest.Aim);
            Assert.Equal(25, classUnderTest.Depth);
        }

        [Fact]
        public void ParseInstruction_MovesSubDown_ByGivenAmount_GivenStringInstruction()
        {
            AimingNavigator classUnderTest = new AimingNavigator();
            classUnderTest.ParseInstruction("down 5");
            Assert.Equal(5, classUnderTest.Aim);
        }

        [Fact]
        public void ParseInstruction_MovesSubUp_ByGivenAmount_GivenStringInstruction()
        {
            AimingNavigator classUnderTest = new AimingNavigator();
            classUnderTest.MoveDown(10);
            classUnderTest.ParseInstruction("up 5");
            Assert.Equal(5, classUnderTest.Aim);
        }

        [Fact]
        public void ParseInstruction_MovesSubForward_ByGivenAmount_GivenStringInstruction()
        {
            AimingNavigator classUnderTest = new AimingNavigator();
            classUnderTest.MoveDown(5);
            classUnderTest.ParseInstruction("forward 5");
            Assert.Equal(5, classUnderTest.Horizontal);
            Assert.Equal(5, classUnderTest.Aim);
            Assert.Equal(25, classUnderTest.Depth);
        }

        [Fact]
        public void LocationReference_ReturnsValue_GivenDepthGreaterThanZeroAndHorizontalGreaterThanZero()
        {
            AimingNavigator classUnderTest = new AimingNavigator();
            classUnderTest.MoveDown(5);
            classUnderTest.MoveForward(5);
            Assert.Equal(125, classUnderTest.LocationReference);
        }

        [Fact]
        public void LocationReference_ReturnsZero_GivenDepthofZeroAndHorizontalGreaterThanZero()
        {
            AimingNavigator classUnderTest = new AimingNavigator();
            classUnderTest.MoveForward(5);
            Assert.Equal(0, classUnderTest.LocationReference);
        }

        [Fact]
        public void LocationReference_ReturnsZero_GivenDepthGreaterThanZeroAndHorizontalOfZero()
        {
            AimingNavigator classUnderTest = new AimingNavigator();
            classUnderTest.MoveDown(5);
            Assert.Equal(0, classUnderTest.LocationReference);
        }

        [Fact]
        public void LocationReference_ReturnsZero_GivenDepthOfZeroAndHorizontalOfZero()
        {
            AimingNavigator classUnderTest = new AimingNavigator();
            Assert.Equal(0, classUnderTest.LocationReference);
        }

        [Fact]
        public void LocationReference_Returns900_GivenSampleInput()
        {
            List<string> sampleInstructions = new List<string>
            {
                "forward 5",
                "down 5",
                "forward 8",
                "up 3",
                "down 8",
                "forward 2"
            };
            AimingNavigator classUnderTest = new AimingNavigator();
            classUnderTest.ParseInstruction(sampleInstructions[0]);
            Assert.Equal(5, classUnderTest.Horizontal);
            Assert.Equal(0, classUnderTest.Depth);
            Assert.Equal(0, classUnderTest.Aim);
            classUnderTest.ParseInstruction(sampleInstructions[1]);
            Assert.Equal(5, classUnderTest.Horizontal);
            Assert.Equal(0, classUnderTest.Depth);
            Assert.Equal(5, classUnderTest.Aim);
            classUnderTest.ParseInstruction(sampleInstructions[2]);
            Assert.Equal(13, classUnderTest.Horizontal);
            Assert.Equal(40, classUnderTest.Depth);
            Assert.Equal(5, classUnderTest.Aim);
            classUnderTest.ParseInstruction(sampleInstructions[3]);
            Assert.Equal(13, classUnderTest.Horizontal);
            Assert.Equal(40, classUnderTest.Depth);
            Assert.Equal(2, classUnderTest.Aim);
            classUnderTest.ParseInstruction(sampleInstructions[4]);
            Assert.Equal(13, classUnderTest.Horizontal);
            Assert.Equal(40, classUnderTest.Depth);
            Assert.Equal(10, classUnderTest.Aim);
            classUnderTest.ParseInstruction(sampleInstructions[5]);
            Assert.Equal(15, classUnderTest.Horizontal);
            Assert.Equal(60, classUnderTest.Depth);
            Assert.Equal(10, classUnderTest.Aim);
            Assert.Equal(900, classUnderTest.LocationReference);
        }
    }
}
