using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1
{
    class Program
    {
        static int intLength(int integer)
        {
            int length = 1;
            if (integer / 10 > 0)
                length = 2;
            if (integer / 100 > 0)
                length = 3;
            return length;
        }

        static String SecondFrameScore(int totalScore, String score2)
        {
            if (intLength(totalScore) == 1)
                score2 += totalScore + "	 ";
            else if (intLength(totalScore) == 2)
                score2 += totalScore + "	";
            if (intLength(totalScore) == 3)
                score2 += totalScore + "   ";
            return score2;
        }
        static void Main(string[] args)
        {
            int frameScore = 0, prevFrame = 0, prevFrameTwo = 0, bowlOne, bowlTwo = 0, frame = 1, totalScore = 0, extraFrame;
            bool strike = false, strikeTwo = false, spare = false;
            String frame1Score1 = "", frame2Score = "", LastFrameTwo = "", LastFrameThree = "", frameNum = "", line = "";

            for (; frame <= 10; frame++)
            {
                Console.WriteLine("Please Enter your Scores for Frame {0}:", frame);
                do 
                {
                    Console.Write("Bowl 1:");
                    bowlOne = int.Parse(Console.ReadLine());
                    
                    //checks for valid bowlOne input...
                }
                while (bowlOne > 10 || bowlOne < 0);
                // if previous frame was a spare add the extra points...
                if (spare == true)
                {
                    prevFrame = 10 + bowlOne;
                    spare = false;
                    totalScore = prevFrame + totalScore;
                    frame2Score = SecondFrameScore(totalScore, frame2Score);

                }
                if (strikeTwo == true && bowlOne == 10)
                {
                    prevFrameTwo = 30;
                    totalScore = prevFrameTwo + totalScore;
                    frame2Score = SecondFrameScore(totalScore, frame2Score);
                }
                if (strikeTwo == true && bowlOne != 10)
                {
                    strikeTwo = false;
                    prevFrameTwo = 10 + 10 + bowlOne;
                    totalScore = prevFrameTwo + totalScore;
                    frame2Score = SecondFrameScore(totalScore, frame2Score);
                }
                if (strike == true && bowlOne == 10)
                {
                    strikeTwo = true;
                    prevFrameTwo = 20;
                }

                //check to make sure there wasn't a strike on first bowl
                if (bowlOne < 10)
                {
                    do 
                    {
                        Console.Write("Bowl 2:");
                        bowlTwo = int.Parse(Console.ReadLine());
                    }
                    while (bowlTwo > (10 - bowlOne) || bowlTwo < 0);
                    if (bowlOne + bowlTwo == 10)
                    {
                        spare = true;
                        frame1Score1 += bowlOne + "-/ | ";
                    }

                    if (strikeTwo == true && frame == 10)
                    {
                        prevFrameTwo = 10 + 10 + bowlTwo;
                        totalScore = prevFrameTwo + totalScore;
                        frame2Score = SecondFrameScore(totalScore, frame2Score);
                        strikeTwo = false;
                    }

                    if (strike == true && bowlOne != 10)
                    {
                        strike = false;
                        prevFrame = 10 + bowlOne + bowlTwo;
                        totalScore = totalScore + prevFrame;
                        frame2Score = SecondFrameScore(totalScore, frame2Score);
                    }
                    if (spare != true && strike != true && strikeTwo != true)
                    {
                        frameScore = bowlOne + bowlTwo;
                        totalScore = totalScore + frameScore;
                        frame2Score = SecondFrameScore(totalScore, frame2Score);
                        if (frame != 10)
                            frame1Score1 += " " + bowlOne + "-" + bowlTwo + " |";
                        else
                            frame1Score1 += " " + bowlOne + "-" + bowlTwo;
                    }
                }
                else
                {
                    strike = true;
                    prevFrame = 10;
                    if (frame != 10)
                        frame1Score1 += " X-  |";
                }
                if (frame == 10 && strike == true)
                {
                    do
                        bowlTwo = int.Parse(Console.ReadLine());
                    while (bowlTwo < 0 || bowlTwo > 10);

                    if (strikeTwo == true)
                    {
                        prevFrameTwo = 10 + 10 + bowlTwo;
                        totalScore = prevFrameTwo + totalScore;
                        frame2Score = SecondFrameScore(totalScore, frame2Score);
                        strikeTwo = false;
                    }
                }

                if (frame == 10 && (spare == true || strike == true))
                {
                    do
                        extraFrame = int.Parse(Console.ReadLine());
                    while (extraFrame < 0 || extraFrame > 10);
                    if (strike == true)
                    {
                        prevFrame = 10 + bowlTwo + extraFrame;
                        totalScore = totalScore + prevFrame;
                        frame2Score = SecondFrameScore(totalScore, frame2Score);
                        if (bowlTwo == 10)
                            LastFrameTwo = "-X";
                        else
                            LastFrameTwo += bowlTwo;
                        if (extraFrame == 10)
                            LastFrameThree = "-X";
                        else
                            LastFrameThree += extraFrame;
                        frame1Score1 += " X" + LastFrameTwo + LastFrameThree;
                    }
                    else
                    {
                        if (extraFrame == 10)
                            LastFrameThree = "-X";
                        else
                            LastFrameThree += extraFrame;
                        if (bowlTwo + extraFrame == 10 && extraFrame != 10)
                            LastFrameThree = "-/";
                        else
                            LastFrameThree += extraFrame;
                        totalScore = totalScore + 10 + extraFrame;
                        frame2Score = SecondFrameScore(totalScore, frame2Score);
                        frame1Score1 += bowlOne + "-/" + LastFrameThree;
                    }
                }
                frameNum += frame + "	 ";
                line += "------";
            }
            Console.WriteLine(frameNum);
            Console.WriteLine(line);
            Console.WriteLine(frame1Score1);
            Console.WriteLine(frame2Score);
        }
    }
}