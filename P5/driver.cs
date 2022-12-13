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
// classes.
// The user is now able to have monitors UndertrainingMonitor, which checks to see if the
// performed distance of triworkout workouts is greater than that of the set target, where the
// parameters of this monitor are a string name, an integer target, and a textwriter object.
// OvertrainingMonitor, which which checks to see if the performed distance of triworkout
// workouts is greater than that of the set target, where the parameters of this monitor
// are a string name, an integer target, and a textwriter object. RepetitionMonitor, which
// checks to see if the performed distance of any workout is greater than that of the workout's
// set target, where the parameters of this monitor are a string name and a textwriter object
// These monitors utilize the textwriter object to either write to the console,
// write to a text file, or write to a string where that string can later be read and written
// to the console. There is a class CoachedAthlete that holds an array of sessionlog objects
// and has the functions AddSessionLog with the parameter being a sessionlog object, Report
// prints all the CoachedAthlete's sessionlogs and workouts to the console, and Subscribe
// where subscribe is called indirectly from a Monitor's subscribe call. Monitors have the
// ability to subscribe to a provider (CoachedAthlete) though the subscribe method with
// the parameter being a CoachedAthlete object that it is subscribing to. This was, when a
// monitor subscribes to a CoachedAthlete object, the monitor calls subscribe in the
// CoachedAthelte class and the monitor is added to the List of observers that the
// CoachedAthlete class contains. After a monitor subscribes, depending on what the monitor
// does, after a CoachedAthlete adds a sesionlog to its array of sessionlogs, each monitor's
// OnNext function will be called for that sessionlog and it will check the parameters and
// will do its actions respectively. 

//Assumptions
// This program assumes that when a workout is recorded, it is always valid, but
// if the performed repetitions is altered (and/or the weight in FitSet),
// then the workout is invalid and the total score of the workout is zero.
// This program assumes the number of performed repetitions can exceed the number
// of target repetitions, this only makes the percentage completed over 100%.
// This program assumes all values are positive not negative.

using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using static System.Collections.Specialized.BitVector32;

namespace P5
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rnd = new Random();
            const int size = 3;
            const int minCal = 1, maxCal = 30;
            const int maxFS = 7;
            const int minVal = 0, maxVal = 50;
            const int maxTW = 2;
            const int minTimeT = 1, maxTimeT = 60;
            const int minDist = 1, maxDist = 20;
            const int maxH = 10;
            const int minTimeH = 1, maxTimeH = 30;
            string[] FSnames = {"Squat", "Bench-Press", "Lunge", "Deadlift", "Crunch", "Plank", "Pull-Ups", "Push-Ups"};
            string[] FSclasses = {"Legs", "Arms", "Legs", "Legs", "Core", "Core", "Arms", "Arms"};
            string[] TRInames = { "running", "cycling", "swimming" };
            string[] HIITnames = {"high-jacks", "plank-jacks", "burpees", "jumping-lunges", "mountain-climbers", "jumping-squats", "side-lunges", "saw-plank", "butt-kicks", "sideplank-walks", "jumping-jacks"};

            testAthlete();
            testRepetitionMonitor();
            testOvertrainingMonitor();
            testUndertrainingMonitor();

            void testAthlete()
            {
                //session with date = 10/1/2022
                SessionLog obj1 = new SessionLog("10/1/2022");
                addWorkout(obj1, randomFitSet1());
                addWorkout(obj1, randomFitSet1());
                addWorkout(obj1, randomTriWorkout1());
                addWorkout(obj1, randomTriWorkout1());
                addWorkout(obj1, randomHiit1());
                addWorkout(obj1, randomHiit1());

                //session with date = 10/2/2022
                SessionLog obj2 = new SessionLog("10/2/2022");
                addWorkout(obj2, randomFitSet2());
                addWorkout(obj2, randomFitSet2());
                addWorkout(obj2, randomTriWorkout2());
                addWorkout(obj2, randomTriWorkout2());
                addWorkout(obj2, randomHiit2());
                addWorkout(obj2, randomHiit2());

                //session with date = 10/2/2022
                SessionLog obj3 = new SessionLog("10/2/2022");
                addWorkout(obj3, randomFitSet2());
                addWorkout(obj3, randomFitSet2());
                addWorkout(obj3, randomTriWorkout2());
                addWorkout(obj3, randomTriWorkout2());
                addWorkout(obj3, randomHiit2());
                addWorkout(obj3, randomHiit2());

                //Testing Athlete
                Athlete test = new Athlete();
                test.AddSessionLog(obj1);
                test.AddSessionLog(obj2);
                test.AddSessionLog(obj3);
                string AthleteReport = test.Report();
                Console.Write(AthleteReport);
            }

            void testRepetitionMonitor()
            {
                //session with date = 10/1/2022
                SessionLog obj1 = new SessionLog("10/1/2022");
                addWorkout(obj1, randomFitSet1());
                addWorkout(obj1, randomFitSet1());
                addWorkout(obj1, randomTriWorkout1());
                addWorkout(obj1, randomTriWorkout1());
                addWorkout(obj1, randomHiit1());
                addWorkout(obj1, randomHiit1());

                //session with date = 10/2/2022
                SessionLog obj2 = new SessionLog("10/2/2022");
                addWorkout(obj2, randomFitSet2());
                addWorkout(obj2, randomFitSet2());
                addWorkout(obj2, randomTriWorkout2());
                addWorkout(obj2, randomTriWorkout2());
                addWorkout(obj2, randomHiit2());
                addWorkout(obj2, randomHiit2());

                //session with date = 10/2/2022
                SessionLog obj3 = new SessionLog("10/2/2022");
                addWorkout(obj3, randomFitSet2());
                addWorkout(obj3, randomFitSet2());
                addWorkout(obj3, randomTriWorkout2());
                addWorkout(obj3, randomTriWorkout2());
                addWorkout(obj3, randomHiit2());
                addWorkout(obj3, randomHiit2());

                //Testing Repetition Monitor
                //Console.Out
                CoachedAthlete provider1 = new CoachedAthlete();
                TextWriter writer1 = Console.Out;
                RepetitionMonitor observer1 = new RepetitionMonitor("RepetitionMonitor", writer1);

                writer1.Write("----------------------------------------------------\n" +
                        "Running RepetitionMonitor Console.Out Program:\n\n");
                writer1.Flush();

                provider1.AddSessionLog(obj1);
                observer1.Subscribe(provider1);
                provider1.AddSessionLog(obj2);
                provider1.AddSessionLog(obj3);

                writer1.Write("Done Running RepetitionMonitor Console.Out Program\n" +
                        "----------------------------------------------------\n\n");
                writer1.Flush();
                writer1.Dispose();

                //StreamWriter
                CoachedAthlete provider2 = new CoachedAthlete();
                string filename1 = "RepetitionMonitorTests.txt";
                StreamWriter writer2 = new StreamWriter(filename1, true);
                RepetitionMonitor observer2 = new RepetitionMonitor("RepetitionMonitor", writer2);

                writer2.Write("----------------------------------------------------\n" +
                        "Running RepetitionMonitor StreamWriter Program:\n\n");
                writer2.Flush();

                provider2.AddSessionLog(obj1);
                observer2.Subscribe(provider2);
                provider2.AddSessionLog(obj2);
                provider2.AddSessionLog(obj3);

                writer2.Write("Done Running RepetitionMonitor StreamWriter Program\n" +
                        "----------------------------------------------------\n\n");
                writer2.Flush();
                writer2.Dispose();

                //StringWriter
                CoachedAthlete provider3 = new CoachedAthlete();
                StringWriter writer3 = new StringWriter();
                RepetitionMonitor observer3 = new RepetitionMonitor("RepetitionMonitor", writer3);

                writer3.Write("----------------------------------------------------\n" +
                        "Running RepetitionMonitor StringWriter Program:\n\n");
                writer3.Flush();

                provider3.AddSessionLog(obj1);
                observer3.Subscribe(provider3);
                provider3.AddSessionLog(obj2);
                provider3.AddSessionLog(obj3);

                writer3.Write("Done Running RepetitionMonitor StringWriter Program\n" +
                        "----------------------------------------------------\n\n");
                writer3.Flush();

                Console.WriteLine(writer3.ToString());

                writer3.Dispose();
            }

            void testOvertrainingMonitor()
            {
                int target = rnd.Next(minDist, maxDist);

                //session with date = 10/1/2022
                SessionLog obj1 = new SessionLog("10/1/2022");
                addWorkout(obj1, randomFitSet1());
                addWorkout(obj1, randomFitSet1());
                addWorkout(obj1, randomTriWorkout1());
                addWorkout(obj1, randomTriWorkout1());
                addWorkout(obj1, randomHiit1());
                addWorkout(obj1, randomHiit1());

                //session with date = 10/2/2022
                SessionLog obj2 = new SessionLog("10/2/2022");
                addWorkout(obj2, randomFitSet2());
                addWorkout(obj2, randomFitSet2());
                addWorkout(obj2, randomTriWorkout2());
                addWorkout(obj2, randomTriWorkout2());
                addWorkout(obj2, randomHiit2());
                addWorkout(obj2, randomHiit2());

                //session with date = 10/2/2022
                SessionLog obj3 = new SessionLog("10/2/2022");
                addWorkout(obj3, randomFitSet2());
                addWorkout(obj3, randomFitSet2());
                addWorkout(obj3, randomTriWorkout2());
                addWorkout(obj3, randomTriWorkout2());
                addWorkout(obj3, randomHiit2());
                addWorkout(obj3, randomHiit2());

                //Testing Overtraining Monitor
                //Console.Out
                CoachedAthlete provider1 = new CoachedAthlete();
                TextWriter writer1 = Console.Out;
                OvertrainingMonitor observer1 = new OvertrainingMonitor("OvertrainingMonitor", target, writer1);

                writer1.Write("----------------------------------------------------\n" +
                        "Running OvertrainingMonitor Console.Out Program:\n\n");
                writer1.Flush();

                provider1.AddSessionLog(obj1);
                observer1.Subscribe(provider1);
                provider1.AddSessionLog(obj2);
                provider1.AddSessionLog(obj3);

                writer1.Write("Done Running OvertrainingMonitor Console.Out Program\n" +
                        "----------------------------------------------------\n\n");
                writer1.Flush();
                writer1.Dispose();

                //StreamWriter
                CoachedAthlete provider2 = new CoachedAthlete();
                string filename2 = "OvertrainingMonitorTests.txt";
                StreamWriter writer2 = new StreamWriter(filename2, true);
                OvertrainingMonitor observer2 = new OvertrainingMonitor("OvertrainingMonitor", target, writer2);

                writer2.Write("----------------------------------------------------\n" +
                        "Running OvertrainingMonitor StreamWriter Program:\n\n");
                writer2.Flush();

                provider2.AddSessionLog(obj1);
                observer2.Subscribe(provider2);
                provider2.AddSessionLog(obj2);
                provider2.AddSessionLog(obj3);

                writer2.Write("Done Running OvertrainingMonitor StreamWriter Program\n" +
                        "----------------------------------------------------\n\n");
                writer2.Flush();
                writer2.Dispose();

                //StringWriter
                CoachedAthlete provider3 = new CoachedAthlete();
                StringWriter writer3 = new StringWriter();
                OvertrainingMonitor observer3 = new OvertrainingMonitor("OvertrainingMonitor", target, writer3);

                writer3.Write("----------------------------------------------------\n" +
                        "Running OvertrainingMonitor StringWriter Program:\n\n");
                writer3.Flush();

                provider3.AddSessionLog(obj1);
                observer3.Subscribe(provider3);
                provider3.AddSessionLog(obj2);
                provider3.AddSessionLog(obj3);

                writer3.Write("Done Running OvertrainingMonitor StringWriter Program\n" +
                        "----------------------------------------------------\n\n");
                writer3.Flush();

                Console.WriteLine(writer3.ToString());

                writer3.Dispose();
            }

            void testUndertrainingMonitor()
            {
                int target = rnd.Next(minDist, maxDist);

                //session with date = 10/1/2022
                SessionLog obj1 = new SessionLog("10/1/2022");
                addWorkout(obj1, randomFitSet1());
                addWorkout(obj1, randomFitSet1());
                addWorkout(obj1, randomTriWorkout1());
                addWorkout(obj1, randomTriWorkout1());
                addWorkout(obj1, randomHiit1());
                addWorkout(obj1, randomHiit1());

                //session with date = 10/2/2022
                SessionLog obj2 = new SessionLog("10/2/2022");
                addWorkout(obj2, randomFitSet2());
                addWorkout(obj2, randomFitSet2());
                addWorkout(obj2, randomTriWorkout2());
                addWorkout(obj2, randomTriWorkout2());
                addWorkout(obj2, randomHiit2());
                addWorkout(obj2, randomHiit2());

                //session with date = 10/2/2022
                SessionLog obj3 = new SessionLog("10/2/2022");
                addWorkout(obj3, randomFitSet2());
                addWorkout(obj3, randomFitSet2());
                addWorkout(obj3, randomTriWorkout2());
                addWorkout(obj3, randomTriWorkout2());
                addWorkout(obj3, randomHiit2());
                addWorkout(obj3, randomHiit2());

                //Testing Overtraining Monitor
                //Console.Out
                CoachedAthlete provider1 = new CoachedAthlete();
                TextWriter writer1 = Console.Out;
                UndertrainingMonitor observer1 = new UndertrainingMonitor("UndertrainingMonitor", target, writer1);

                writer1.Write("----------------------------------------------------\n" +
                        "Running UndertrainingMonitor Console.Out Program:\n\n");
                writer1.Flush();

                provider1.AddSessionLog(obj1);
                observer1.Subscribe(provider1);
                provider1.AddSessionLog(obj2);
                provider1.AddSessionLog(obj3);

                writer1.Write("Done Running UndertrainingMonitor Console.Out Program\n" +
                        "----------------------------------------------------\n\n");
                writer1.Flush();
                writer1.Dispose();

                //StreamWriter
                CoachedAthlete provider2 = new CoachedAthlete();
                string filename2 = "UndertrainingMonitorTests.txt";
                StreamWriter writer2 = new StreamWriter(filename2, true);
                UndertrainingMonitor observer2 = new UndertrainingMonitor("UndertrainingMonitor", target, writer2);

                writer2.Write("----------------------------------------------------\n" +
                        "Running UndertrainingMonitor StreamWriter Program:\n\n");
                writer2.Flush();

                provider2.AddSessionLog(obj1);
                observer2.Subscribe(provider2);
                provider2.AddSessionLog(obj2);
                provider2.AddSessionLog(obj3);

                writer2.Write("Done Running UndertrainingMonitor StreamWriter Program\n" +
                        "----------------------------------------------------\n\n");
                writer2.Flush();
                writer2.Dispose();

                //StringWriter
                CoachedAthlete provider3 = new CoachedAthlete();
                StringWriter writer3 = new StringWriter();
                UndertrainingMonitor observer3 = new UndertrainingMonitor("UndertrainingMonitor", target, writer3);

                writer3.Write("----------------------------------------------------\n" +
                        "Running UndertrainingMonitor StringWriter Program:\n\n");
                writer3.Flush();

                provider3.AddSessionLog(obj1);
                observer3.Subscribe(provider3);
                provider3.AddSessionLog(obj2);
                provider3.AddSessionLog(obj3);

                writer3.Write("Done Running UndertrainingMonitor StringWriter Program\n" +
                        "----------------------------------------------------\n\n");
                writer3.Flush();

                Console.WriteLine(writer3.ToString());

                writer3.Dispose();
            }

            void addWorkout(SessionLog obj, Workout work)
            {
                obj.addSet(work);
            }
            void removeWorkout(int workout, SessionLog obj)
            {
                obj.removeSet(workout);
            }
            void build(Workout[] arr, bool prior, SessionLog obj)
            {
                obj.buildSession(arr, prior, obj);
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
