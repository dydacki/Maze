namespace AtlasCopco.Maze.VerySimpleMaze.Test.Utils
{
    using System;

    using Moq;

    public static class SequentialRandomFactory
    {
        private static int counter;
        private static int scope;
        private static int scopeCounter;

        public static Random BuildSequentialRandomizer()
        {
            var randoMoq = new Mock<Random>();
            randoMoq.Setup(rm => rm.Next(It.IsAny<int>()))
                    .Returns<int>(c => MoqNext(c));

            return randoMoq.Object;
        }

        public static Random BuildSequentialRandomizer(int upperLimit)
        {
            scope = upperLimit;
            var randoMoq = new Mock<Random>();
            randoMoq.Setup(rm => rm.Next(It.IsAny<int>()))
                    .Returns<int>((c) => MoqNextFromScope());

            return randoMoq.Object;
        }

        private static int MoqNext(int maxValue)
        {
            if (counter == maxValue)
            {
                counter = 0;
            }

            return counter++;
        }

        private static int MoqNextFromScope()
        {
            if (scopeCounter == scope)
            {
                scopeCounter = 0;
            }

            return scopeCounter++;
        }
    }
}
