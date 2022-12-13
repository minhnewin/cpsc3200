//Minh Nguyen

//Overview:
// This program is for fitness documentation and allows the user to track
// workouts as objects of a class. The class name is FitSet and the user can input
// values in the constructor in this order: a string name, a string date, a string
// classification, an integer number of weight in pounds, an integer number of
// target amount of repetitions, and an integer number of performed repetitions.
// The user is then able to print all this data to the screen by using the
// describeFitSet() public function. The user is also able to manipulate the data
// mentioned above, but if the user changes the weight or performed repetitions
// then the whole workout will be considered invalid, this can be checked through
// the isValid() public function. The user is also able to check the completion
// with the function isComplete(), the percentage completed with the function
// percentageCompleted(), and the total score of the workout with totalScore().
// The total score of the workout is the product of the weight and reps performed.

//Assumptions
// This program assumes that when a workout is recorded, it is always valid, but
// if the weight or performed repetitions is altered, then the workout is invalid
// and the total score of the workout is zero. This program assumes the number of
// performed repetitions can exceed the number of target repetitions, this
// only makes the percentage completed over 100%. This program assumes all values
// are positive not negative.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PA1
{
    class Program
    {
        static void Main(string[] args)
        {
            int minString = 1;
            int maxString = 8;
            int minVal = 0;
            int maxVal = 50;
            int minCal = 1;
            int maxCal = 30;

            Random rnd = new Random();

            string[] names = {"Squat", "Bench Press", "Lunge", "Deadlift",
                "Crunch", "Russian Twist", "Bicep Curl", "Posterior Deltoid Raise"};

            string[] classes = {"Legs", "Arms", "Legs", "Legs",
                "Core", "Core", "Arms", "Arms"};

            Console.WriteLine("----------------------------------" +
                "\nNew FitSet Workout:\n");

            int temp1 = rnd.Next(minString, maxString);
            int temp2 = rnd.Next(minString, maxString);

            FitSet set1 = new FitSet(names[temp1],
                "Sept " + rnd.Next(minCal, maxCal) + ", 2022",
                classes[temp1],
                rnd.Next(minVal, maxVal),
                rnd.Next(minVal, maxVal),
                rnd.Next(minVal, maxVal));

            set1.describeFitSet();
            Console.WriteLine("Completetion: " + set1.isCompleted() +
                "\nPercentage Completed: " + set1.percentageCompleted() + "%" +
                "\nValidity: " + set1.isValid() +
                "\nTotal Score: " + set1.totalScore() + "\n");

            set1.setName(names[temp2]);
            set1.setDate("September " + rnd.Next(minCal, maxCal) + ", 2022");
            set1.setClassification(classes[temp2]);
            set1.describeFitSet();
            Console.WriteLine("Completetion: " + set1.isCompleted() +
                "\nPercentage Completed: " + set1.percentageCompleted() + "%" +
                "\nValidity: " + set1.isValid() +
                "\nTotal Score: " + set1.totalScore() + "\n");

            set1.setPerformedReps(rnd.Next(minVal, maxVal));
            set1.describeFitSet();
            Console.WriteLine("Completetion: " + set1.isCompleted() +
                "\nPercentage Completed: " + set1.percentageCompleted() + "%" +
                "\nValidity: " + set1.isValid() +
                "\nTotal Score: " + set1.totalScore() + "\n");

            Console.WriteLine("----------------------------------" +
                "\nNew FitSet Workout:\n");

            int temp3 = rnd.Next(1, 8);

            FitSet set2 = new FitSet(names[temp3],
                "Sept, " + rnd.Next(minCal, maxCal) + ", 2022",
                classes[temp3],
                rnd.Next(minVal, maxVal),
                rnd.Next(minVal, maxVal),
                rnd.Next(minVal, maxVal));

            set2.describeFitSet();
            Console.WriteLine("Completetion: " + set2.isCompleted() +
                "\nPercentage Completed: " + set2.percentageCompleted() + "%" +
                "\nValidity: " + set2.isValid() +
                "\nTotal Score: " + set2.totalScore() + "\n");

            set2.setWeight(rnd.Next(minVal, maxVal));
            set2.describeFitSet();
            Console.WriteLine("Completetion: " + set2.isCompleted() +
                "\nPercentage Completed: " + set2.percentageCompleted() + "%" +
                "\nValidity: " + set2.isValid() +
                "\nTotal Score: " + set2.totalScore() + "\n");
        }
    }
}
