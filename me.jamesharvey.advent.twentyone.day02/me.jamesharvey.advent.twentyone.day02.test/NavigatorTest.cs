using System;
using System.Collections.Generic;
using Xunit;

namespace me.jamesharvey.advent.twentyone.day02.test
{
    public class NavigatorTest
    {
        [Fact]
        public void MoveDown_MovesSubDown_ByGivenAmount()
        {
            Navigator classUnderTest = new Navigator();
            classUnderTest.MoveDown(5);
            Assert.Equal(5, classUnderTest.Depth);
            Assert.Equal(0, classUnderTest.Horizontal);
        }

        [Fact]
        public void MoveUp_MovesSubUp_ByGivenAmount_GivenDepthIsDeeperThanValue()
        {
            Navigator classUnderTest = new Navigator();
            classUnderTest.MoveDown(10);
            classUnderTest.MoveUp(5);
            Assert.Equal(5, classUnderTest.Depth);
            Assert.Equal(0, classUnderTest.Horizontal);
        }

        [Fact]
        public void MoveForward_MovesSubForward_ByGivenAmount()
        {
            Navigator classUnderTest = new Navigator();
            classUnderTest.MoveForward(5);
            Assert.Equal(5, classUnderTest.Horizontal);
            Assert.Equal(0, classUnderTest.Depth);
        }

        [Fact]
        public void ParseInstruction_MovesSubDown_ByGivenAmount_GivenStringInstruction()
        {
            Navigator classUnderTest = new Navigator();
            classUnderTest.ParseInstruction("down 5");
            Assert.Equal(5, classUnderTest.Depth);
            Assert.Equal(0, classUnderTest.Horizontal);
        }

        [Fact]
        public void ParseInstruction_MovesSubUp_ByGivenAmount_GivenStringInstruction()
        {
            Navigator classUnderTest = new Navigator();
            classUnderTest.MoveDown(10);
            classUnderTest.ParseInstruction("up 5");
            Assert.Equal(5, classUnderTest.Depth);
            Assert.Equal(0, classUnderTest.Horizontal);
        }

        [Fact]
        public void ParseInstruction_MovesSubForward_ByGivenAmount_GivenStringInstruction()
        {
            Navigator classUnderTest = new Navigator();
            classUnderTest.ParseInstruction("forward 5");
            Assert.Equal(5, classUnderTest.Horizontal);
            Assert.Equal(0, classUnderTest.Depth);
        }

        [Fact]
        public void LocationReference_ReturnsValue_GivenDepthGreaterThanZeroAndHorizontalGreaterThanZero()
        {
            Navigator classUnderTest = new Navigator();
            classUnderTest.MoveDown(5);
            classUnderTest.MoveForward(5);
            Assert.Equal(25, classUnderTest.LocationReference);
        }

        [Fact]
        public void LocationReference_ReturnsZero_GivenDepthofZeroAndHorizontalGreaterThanZero()
        {
            Navigator classUnderTest = new Navigator();
            classUnderTest.MoveForward(5);
            Assert.Equal(0, classUnderTest.LocationReference);
        }

        [Fact]
        public void LocationReference_ReturnsZero_GivenDepthGreaterThanZeroAndHorizontalOfZero()
        {
            Navigator classUnderTest = new Navigator();
            classUnderTest.MoveDown(5);
            Assert.Equal(0, classUnderTest.LocationReference);
        }

        [Fact]
        public void LocationReference_ReturnsZero_GivenDepthOfZeroAndHorizontalOfZero()
        {
            Navigator classUnderTest = new Navigator();
            Assert.Equal(0, classUnderTest.LocationReference);
        }

        [Fact]
        public void LocationReference_Returns150_GivenSampleInput()
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
            Navigator classUnderTest = new Navigator();
            classUnderTest.ParseInstruction(sampleInstructions[0]);
            Assert.Equal(5, classUnderTest.Horizontal);
            classUnderTest.ParseInstruction(sampleInstructions[1]);
            Assert.Equal(5, classUnderTest.Depth);
            classUnderTest.ParseInstruction(sampleInstructions[2]);
            Assert.Equal(13, classUnderTest.Horizontal);
            classUnderTest.ParseInstruction(sampleInstructions[3]);
            Assert.Equal(2, classUnderTest.Depth);
            classUnderTest.ParseInstruction(sampleInstructions[4]);
            Assert.Equal(10, classUnderTest.Depth);
            classUnderTest.ParseInstruction(sampleInstructions[5]);
            Assert.Equal(15, classUnderTest.Horizontal);
            Assert.Equal(150, classUnderTest.LocationReference);
        }
    }
}
