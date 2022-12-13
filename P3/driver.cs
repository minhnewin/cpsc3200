//Minh Nguyen

//Overview:
// This program is for fitness documentation and allows the user to track
// workouts as objects of a class. There is a SessionLog class that has a
// heterogeneous collection of a base class type workout. The user can input a
// string date in the format 0/0/0000 into the constructor of SessionLog.
// The base class Workout has 3 types of sub classes: FitSet, TriWorkout, and Hiit
// The user can input values into the constructor of FitSet in this order:
// a string name, a string date, a string classification, an integer number of weight in pounds,
// an integer number of target amount of repetitions, and an integer number of performed repetitions.
// The user can input values into the constructor of TriWorkout in this order:
// a string name, a string date, an integer time, an integer performedDistance,
// and an int targetDistance.
// The user can input values into the constructor of Hiit in this order:
// a string name, a string date, an integer training Period, an integer performedReps,
// and an integer targetReps
// The user is able to use the public functionality of the SessionLog class which
// are addSet() with the parameter being a Workout type class object to be added
// to the heterogenous collection, removeSet() which removes a Workout from the
// collection at an indexed value passed into removeSet(), buildSession() which takes
// an array of type Workout, a boolean to build off a prior sessionLog object,
// and the sessionLog object that the user wants to build off of depending on the
// value type of the boolean, justDoIt() that takes in an amout of reps and weight
// to complete the Session and log a strength training session, shareSession() which
// returns an array of string values of all the data in a Workout that is contained
// within the heterogeneous collection, and a getObjCount() function that returns the
// number of Workouts in the heterogeneous collection within SessionLog.
// The user is also then able to print all this data to the screen by using the
// printsession() public function in main that takes in a sessionLog object as
// a parameter. the other functions are to randomize the values of the 3 different
// classes

//Assumptions
// This program assumes that when a workout is recorded, it is always valid, but
// if the performed repetitions is altered (and/or the weight in FitSet),
// then the workout is invalid and the total score of the workout is zero.
// This program assumes the number of performed repetitions can exceed the number
// of target repetitions, this only makes the percentage completed over 100%.
// This program assumes all values are positive not negative.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using static System.Collections.Specialized.BitVector32;

namespace PA3
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rnd = new Random();

            const int size = 3;
            //date
            const int minCal = 1, maxCal = 30;
            //FitSet
            const int maxFS = 7;
            const int minVal = 0, maxVal = 50;
            //TriWorkout
            const int maxTW = 2;
            const int minTimeT = 1, maxTimeT = 60;
            const int minDist = 1, maxDist = 20;
            //Hiit
            const int maxH = 10;
            const int minTimeH = 1, maxTimeH = 30;

            //fitset item characteristics
            string[] FSnames = {"Squat      ", "Bench-Press", "Lunge      ",
                         "Deadlift   ", "Crunch     ", "Plank      ",
                         "Pull-Ups   ", "Push-Ups   "};
            string[] FSclasses = {"Legs", "Arms", "Legs", "Legs",
                           "Core", "Core", "Arms", "Arms"};

            //TriWorkout item characteristics
            string[] TRInames = { "running", "cycling", "swimming" };

            //Hiit item characteristics
            string[] HIITnames = {"high jacks", "plank jacks", "burpees", "jumping lunges",
                "mountain climbers", "jumping squats", "side lunges", "saw plank", "butt kicks",
                "sideplank walks", "jumping jacks"};

            //session with date = 10/1/2022
            SessionLog obj1 = new SessionLog("10/1/2022");

            addWorkout(obj1, randomFitSet1());
            addWorkout(obj1, randomFitSet1());
            addWorkout(obj1, randomTriWorkout1());
            addWorkout(obj1, randomTriWorkout1());
            addWorkout(obj1, randomHiit1());
            addWorkout(obj1, randomHiit1());
            printSession(obj1);

            //session with date = 10/2/2022
            SessionLog obj2 = new SessionLog("10/2/2022");
            addWorkout(obj2, randomFitSet2());
            addWorkout(obj2, randomFitSet2());
            addWorkout(obj2, randomTriWorkout2());
            addWorkout(obj2, randomTriWorkout2());
            addWorkout(obj2, randomHiit2());
            addWorkout(obj2, randomHiit2());
            printSession(obj2);

            //session with date = 10/3/2022
            //this one might or might not work depending on if the randomized
            //date is 10/3/2022 or something else
            SessionLog obj3 = new SessionLog("10/3/2022");
            addWorkout(obj3, randomFitSet());
            addWorkout(obj3, randomFitSet());
            addWorkout(obj3, randomTriWorkout());
            addWorkout(obj3, randomTriWorkout());
            addWorkout(obj3, randomHiit());
            addWorkout(obj3, randomHiit());
            printSession(obj3);

            //test remove
            SessionLog obj4 = new SessionLog("10/1/2022");
            addWorkout(obj4, randomFitSet1());
            addWorkout(obj4, randomTriWorkout1());
            addWorkout(obj4, randomHiit1());
            printSession(obj4);
            removeWorkout(1, obj4);
            printSession(obj4);

            //test buildSession
            SessionLog obj5 = new SessionLog("10/1/2022");
            addWorkout(obj5, randomFitSet1());
            addWorkout(obj5, randomTriWorkout1());
            addWorkout(obj5, randomHiit1());
            Workout [] arr = new Workout[size];
            for(int i = 0; i < size; i++)
            {
                arr[i] = randomFitSet1();
            }

            build(arr, true, obj5);

            void addWorkout(SessionLog obj, Workout work)
            {
                obj.addSet(work);
            }
            void removeWorkout(int workout, SessionLog obj)
            {
                obj.removeSet(workout);
            }
            void build(Workout [] arr, bool prior, SessionLog obj)
            {

            }

            //randomized fitset, triworkout, and Hiit with varying dates
            FitSet randomFitSet()
            {
                return new FitSet(FSnames[rnd.Next(maxFS)],
                    "10/" + rnd.Next(minCal, maxCal) + "/2022",
                    FSclasses[rnd.Next(maxFS)],
                    rnd.Next(minVal, maxVal),
                    rnd.Next(minVal, maxVal),
                    rnd.Next(minVal, maxVal));
            }
            TriWorkout randomTriWorkout()
            {
                return new TriWorkout(TRInames[rnd.Next(maxTW)],
                    "10/" + rnd.Next(minCal, maxCal) + "/2022",
                    rnd.Next(minTimeT, maxTimeT),
                    rnd.Next(minDist, maxDist),
                    rnd.Next(minDist, maxDist));
            }
            Hiit randomHiit()
            {
                return new Hiit(HIITnames[rnd.Next(maxH)],
                    "10/" + rnd.Next(minCal, maxCal) + "/2022",
                    rnd.Next(minTimeH, maxTimeH),
                    rnd.Next(minVal, maxVal),
                    rnd.Next(minVal, maxVal));
            }
            //randomized fitset, triworkout, and Hiit with date as 10/1/2022
            FitSet randomFitSet1()
            {
                return new FitSet(FSnames[rnd.Next(maxFS)],
                    "10/1/2022",
                    FSclasses[rnd.Next(maxFS)],
                    rnd.Next(minVal, maxVal),
                    rnd.Next(minVal, maxVal),
                    rnd.Next(minVal, maxVal));
            }
            TriWorkout randomTriWorkout1()
            {
                return new TriWorkout(TRInames[rnd.Next(maxTW)],
                    "10/1/2022",
                    rnd.Next(minTimeT, maxTimeT),
                    rnd.Next(minDist, maxDist),
                    rnd.Next(minDist, maxDist));
            }
            Hiit randomHiit1()
            {
                return new Hiit(HIITnames[rnd.Next(maxH)],
                    "10/1/2022",
                    rnd.Next(minTimeH, maxTimeH),
                    rnd.Next(minVal, maxVal),
                    rnd.Next(minVal, maxVal));
            }
            //randomized fitset, triworkout, and Hiit with date as 10/2/2022
            FitSet randomFitSet2()
            {
                return new FitSet(FSnames[rnd.Next(maxFS)],
                    "10/2/2022",
                    FSclasses[rnd.Next(maxFS)],
                    rnd.Next(minVal, maxVal),
                    rnd.Next(minVal, maxVal),
                    rnd.Next(minVal, maxVal));
            }
            TriWorkout randomTriWorkout2()
            {
                return new TriWorkout(TRInames[rnd.Next(maxTW)],
                    "10/2/2022",
                    rnd.Next(minTimeT, maxTimeT),
                    rnd.Next(minDist, maxDist),
                    rnd.Next(minDist, maxDist));
            }
            Hiit randomHiit2()
            {
                return new Hiit(HIITnames[rnd.Next(maxH)],
                    "10/2/2022",
                    rnd.Next(minTimeH, maxTimeH),
                    rnd.Next(minVal, maxVal),
                    rnd.Next(minVal, maxVal));
            }

            void printSession(SessionLog session)
            {
                Console.WriteLine("\nSession " + session + "\n");
                int count = session.getObjCount();
                string[] arr = session.shareSession();
                for (int j = 0; j < count; j++)
                {
                    Console.WriteLine(arr[j]);
                    Console.WriteLine("\n");
                }
            }
        }
    }
}
