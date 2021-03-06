﻿using System;
using System.Text;
using System.Collections.Generic;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Week1_Maze;
using Pointer = Week1_Maze.Pointer;

namespace Maze_Test
{
    [TestClass]
    public class Maze_UnitTest
    {
        //public Maze_UnitTest()
        //{
            //Maze myMaze0 = new Maze();
            //Maze myMaze1 = new Maze(@"C:\Users\ana_k\Documents\Visual Studio 2015\Projects\Week1_Maze\Week1_Maze\Input0.txt");
        //}

        [TestMethod]
        public void TextFileWasReadIntoArray()
        {
            Maze myMaze1 = new Maze(@"C:\Users\ana_k\Documents\CodingChallenges\Week 1\Karen\Week1_Maze\Week1_Maze\Input0.txt");

            int expected = 6;
            int actual = myMaze1.GetDesiredEndResultNum();
            Assert.AreEqual(expected, actual);

            string firstLineExpected = "0 +1";
            string firstLineActual = myMaze1.GetLines(1);
            Assert.AreEqual(firstLineActual, firstLineExpected);

            string secondLineExpected = "+4 +2";
            string secondLineActual = myMaze1.GetLines(2);
            Assert.AreEqual(secondLineActual, secondLineExpected);

            int sizeExpected = 3;
            int sizeActual = myMaze1.GetMazeSize();
            Assert.AreEqual(sizeExpected, sizeActual);
        }

        [TestMethod]
        public void MatrixZeroWasCreated()
        {
            Maze myMaze1 = new Maze(@"C:\Users\ana_k\Documents\CodingChallenges\Week 1\Karen\Week1_Maze\Week1_Maze\Input0.txt");

            int expected = 6;
            int actual = myMaze1.GetDesiredEndResultNum();
            Assert.AreEqual(expected, actual);

            string expected00 = "0";
            string actual00 = myMaze1.GetMatrix(0, 0);
            Assert.AreEqual(expected00, actual00);

            string expected01 = "+1";
            string actual01 = myMaze1.GetMatrix(0, 1);
            Assert.AreEqual(expected01, actual01);

            string expected10 = "+4";
            string actual10 = myMaze1.GetMatrix(1, 0);
            Assert.AreEqual(expected10, actual10);

            string expected11 = "+2";
            string actual11 = myMaze1.GetMatrix(1, 1);
            Assert.AreEqual(expected11, actual11);
        }

        [TestMethod]
        public void MatrixOneWasCreated()
        {
            Maze myMaze1 = new Maze(@"C:\Users\ana_k\Documents\CodingChallenges\Week 1\Karen\Week1_Maze\Week1_Maze\Input1.txt");

            int expected = 6;
            int actual = myMaze1.GetDesiredEndResultNum();
            Assert.AreEqual(expected, actual);

            string expected00 = "2";
            string actual00 = myMaze1.GetMatrix(0, 0);
            Assert.AreEqual(expected00, actual00);

            string expected01 = "+2";
            string actual01 = myMaze1.GetMatrix(0, 1);
            Assert.AreEqual(expected01, actual01);

            string expected02 = "-3";
            string actual02 = myMaze1.GetMatrix(0, 2);
            Assert.AreEqual(expected02, actual02);


            string expected10 = "-1";
            string actual10 = myMaze1.GetMatrix(1, 0);
            Assert.AreEqual(expected10, actual10);

            string expected11 = "*3";
            string actual11 = myMaze1.GetMatrix(1, 1);
            Assert.AreEqual(expected11, actual11);

            string expected12 = "+3";
            string actual12 = myMaze1.GetMatrix(1, 2);
            Assert.AreEqual(expected12, actual12);


            string expected20 = "+1";
            string actual20 = myMaze1.GetMatrix(2, 0);
            Assert.AreEqual(expected20, actual20);

            string expected21 = "+4";
            string actual21 = myMaze1.GetMatrix(2, 1);
            Assert.AreEqual(expected21, actual21);

            string expected22 = "+1";
            string actual22 = myMaze1.GetMatrix(2, 2);
            Assert.AreEqual(expected22, actual22);
        }

        [TestMethod]
        public void SolveMazeEmpty()
        {
            Maze myMaze1 = new Maze(@"C:\Users\ana_k\Documents\CodingChallenges\Week 1\Karen\Week1_Maze\Week1_Maze\InputEmpty.txt");
            myMaze1.SolveMaze();

            //int expectedAmountOfNumsInPath = 0;
            //int actualAmountOfNumsInPath = myMaze1.GetAmountOfNumsInPath();
            //Assert.AreEqual(expectedAmountOfNumsInPath, actualAmountOfNumsInPath);

            string expectedPath = null;
            string actualPath = myMaze1.GetPath();
            Assert.AreEqual(expectedPath, actualPath);
        }

        [TestMethod]
        public void SolveMazeThree()
        {
            Maze myMaze1 = new Maze(@"C:\Users\ana_k\Documents\CodingChallenges\Week 1\Karen\Week1_Maze\Week1_Maze\Input3.txt");
            myMaze1.SolveMaze();

            string expectedPath = "1\n1";
            string actualPath = myMaze1.GetPath();
            Assert.AreEqual(expectedPath, actualPath);
        }

        [TestMethod]
        public void SolveMazeZero()
        {
            Maze myMaze1 = new Maze(@"C:\Users\ana_k\Documents\CodingChallenges\Week 1\Karen\Week1_Maze\Week1_Maze\Input0.txt");
            myMaze1.SolveMaze();

            string expectedPath = "3\n1 3 4";
            string actualPath = myMaze1.GetPath();
            Assert.AreEqual(expectedPath, actualPath);
        }

        [TestMethod]
        public void SolveMazeZFour()
        {
            Maze myMaze1 = new Maze(@"C:\Users\ana_k\Documents\CodingChallenges\Week 1\Karen\Week1_Maze\Week1_Maze\Input4.txt");
            myMaze1.SolveMaze();

            string expectedPath = "5\n1 3 4 3 4";
            string actualPath = myMaze1.GetPath();
            Assert.AreEqual(expectedPath, actualPath);
        }

        [TestMethod]
        public void SolveMazeOne()
        {
            Maze myMaze1 = new Maze(@"C:\Users\ana_k\Documents\CodingChallenges\Week 1\Karen\Week1_Maze\Week1_Maze\Input1.txt");
            myMaze1.SolveMaze();

            string expectedPath = "7\n1 4 5 2 3 6 9";
            string actualPath = myMaze1.GetPath();
            Assert.AreEqual(expectedPath, actualPath);
        }

        [TestMethod]
        public void SolveMazeTwo()
        {
            Maze myMaze1 = new Maze(@"C:\Users\ana_k\Documents\CodingChallenges\Week 1\Karen\Week1_Maze\Week1_Maze\Input2.txt");
            myMaze1.SolveMaze();

            string expectedPath = "15\n1 2 3 4 9 14 13 12 17 22 23 24 25 20 25";
            string actualPath = myMaze1.GetPath();
            Assert.AreEqual(expectedPath, actualPath);
        }

        [TestMethod]
        public void SolveMazeFive()
        {
            Maze myMaze1 = new Maze(@"C:\Users\ana_k\Documents\CodingChallenges\Week 1\Karen\Week1_Maze\Week1_Maze\Input5.txt");
            myMaze1.SolveMaze();

            string expectedPath = "3\n1 3 4";
            string actualPath = myMaze1.GetPath();
            Assert.AreEqual(expectedPath, actualPath);
        }

        [TestMethod]
        public void populateListOfPointers()
        {
            List<Pointer> myList = new List<Pointer>();
            myList.Add(new Pointer(2,1));

            int expectedY = 2;
            int actualY = myList[0].Y;
            Assert.AreEqual(expectedY, actualY);

            int expectedX = 1;
            int actualX = myList[0].getX();
            Assert.AreEqual(expectedX, actualX);
        }
    }
}
