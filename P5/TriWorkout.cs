//Interface Invariants
//TriWorkout
// ~constructor initialize an object with values
//getTime
// ~returns time
//getPerformedDistance
// ~returns performedDistance
//getTargetDistance
// ~returns targetDistance
//getPace
// ~returns pace
//setPerformedDistance
// ~updates validity and performedDistance
//calcPace
// ~calculates pace
//getComplete
// ~returns complete
//getPercentageCompleted
// ~returns percentageCompleted
//getTotalScore
// ~returns totalScore
//forPrint
// ~returns a string value with all info of TriWorkout workout

//Class Invariants
// This is a sub class of a base class named Workout
// it inherits most of the functionality and some protected attributes
// from Workout.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace P5
{
    public class TriWorkout : Workout
    {
        private int Time;
        private int PerformedDistance;
        private int TargetDistance;
        private double Pace;

        //Precondition: string name, string date, int time, int performedDistance,
        //              int targetDistance
        //Postcondition: returns name
        public TriWorkout(string name, string date, int time, int performedDistance,
            int targetDistance)
            : base(name, date)
        {
            //base
            Name = name;
            Date = date;

            //derived
            Time = time;
            PerformedDistance = performedDistance;
            TargetDistance = targetDistance;
        }
        //Precondition: none
        //Postcondition: returns time
        public int getTime()
        {
            return Time;
        }
        //Precondition: none
        //Postcondition: returns performedDistance
        public override int getPerformed()
        {
            return PerformedDistance;
        }
        //Precondition: none
        //Postcondition: returns targetDistance
        public override int getTarget()
        {
            return TargetDistance;
        }
        //Precondition: none
        //Postcondition: returns pace after calculating the pace
        public double getPace()
        {
            calcPace();
            return Pace;
        }
        //Precondition: new performedDistance
        //Postcondition: updates validity and performedDistance
        public void setPerformedDistance(int performedDistance)
        {
            if (Valid)
            {
                Valid = !Valid;
                this.PerformedDistance = performedDistance;
            }
        }
        //Precondition: none
        //Postcondition: calculates the pace based off performedDistance and Time
        public void calcPace()
        {
            if (Valid)
            {
                if(Time != 0)
                    Pace = Math.Round((double)PerformedDistance / Time * OneHundred, 2);
                else
                    Pace = 0;
            }
        }
        //Precondition: none
        //Postcondition: returns complete or date = 0/0/0000 if false
        public override bool getComplete()
        {
            if (Valid)
            {
                if (getPercentageCompleted() >= OneHundred)
                    return Complete = true;
                else
                    Date = "0/0/0000";
                return Complete = false;
            }
            else
            {
                return false;
            }
        }
        //Precondition: none
        //Postcondition: returns percentageCompleted
        public override double getPercentageCompleted()
        {
            if (Valid)
            {
                if (TargetDistance != Zero)
                {
                    return PercentageCompleted = Math.Round((double)PerformedDistance / TargetDistance * OneHundred, 2);
                }
                else
                {
                    return PercentageCompleted = Zero;
                }
            }
            else
            {
                return Zero;
            }
        }
        //Precondition: none
        //Postcondition: returns totalScore
        public override double getTotalScore()
        {
            if (Valid)
            {
                calcPace();
                getPercentageCompleted();
                return TotalScore = PercentageCompleted * Pace;
            }
            else
            {
                return TotalScore = Zero;
            }
        }
        //Precondition: none
        //Postcondition: returns TriWorkout workout information in a single string
        public override string forPrint()
        {
            string workout;
            workout = "Workout: TriWorkout\n Name: " + getName() + " Date: " + getDate() + " Completion: " + getComplete() +
                "\n Validity: " + getValid() + " Percentage Completed: " + getPercentageCompleted() +
                " Total Score: " + getTotalScore() +

                 //triworkout items
                 "\n Time: " + getTime() + " Performed Distance: " + getPerformed() + " Target Distance: " + getTarget() +
                 " Pace: " + getPace();
            return workout;
        }
    }
}
//Implementation Invariants
//public functions
//TriWorkout
// ~constructor initialize an object with values
//getTime
// ~returns time
//getPerformedDistance
// ~returns performedDistance
//getTargetDistance
// ~returns targetDistance
//getPace
// ~returns pace
//setPerformedDistance
// ~updates validity and performedDistance
//calcPace
// ~calculates pace
//getComplete
// ~returns complete
//getPercentageCompleted
// ~returns percentageCompleted
//getTotalScore
// ~returns totalScore
//forPrint
// ~returns a string value with all info of TriWorkout workout
