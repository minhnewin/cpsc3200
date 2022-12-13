//Interface Invariants
//Hiit
// ~constructor initialize an object with values
//getTime
// ~returns time
//getTrainingPeriod
// ~returns TrainingPeriod
//getRestPeriod
// ~returns restPeriod
//getPerformedReps
// ~returns performedReps
//getTargetReps
// ~returns targetReps
//setPerformedReps
// ~updates validity and performedReps
//getComplete
// ~returns complete
//getPercentageCompleted
// ~returns percentageCompleted
//getTotalScore
// ~returns totalScore
//forPrint
// ~returns a string value with all info of Hiit workout

//calcPace
// ~calculates pace
//getComplete
// ~returns complete
//getPercentageCompleted
// ~returns percentageCompleted

//Class Invariants
// This is a sub class of a base class named Workout
// it inherits most of the functionality and some protected attributes
// from Workout.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P5
{
    public class Hiit : Workout
    {
        private int Time;
        private int TrainingPeriod;
        private int RestPeriod;
        private int PerformedReps;
        private int TargetReps;

        //constructor
        //Precondition: string name, string date, int trainingPeriod, int performedReps,
        //              int targetReps
        //Postcondition: initializing values of Workout object
        public Hiit(string name, string date, int trainingPeriod, int performedReps,
            int targetReps)
            : base(name, date)
        {
            //base
            Name = name;
            Date = date;

            //derived
            TrainingPeriod = trainingPeriod;
            RestPeriod = TrainingPeriod * 2;
            Time = TrainingPeriod + RestPeriod;
            PerformedReps = performedReps;
            TargetReps = targetReps;
        }
        //Precondition: none
        //Postcondition: returns time
        public int getTime()
        {
            return Time;
        }
        //Precondition: none
        //Postcondition: returns trainingperiod
        public int getTrainingPeriod()
        {
            return TrainingPeriod;
        }
        //Precondition: none
        //Postcondition: returns restperiod
        public int getRestPeriod()
        {
            return RestPeriod;
        }
        //Precondition: none
        //Postcondition: returns performedreps
        public override int getPerformed()
        {
            return PerformedReps;
        }
        //Precondition: none
        //Postcondition: returns targetreps
        public override int getTarget()
        {
            return TargetReps;
        }
        //Precondition: new performedReps
        //Postcondition: changes the validity to false
        //               updates performedreps
        public void setPerformedReps(int performedReps)
        {
            if (Valid)
            {
                Valid = !Valid;
                this.PerformedReps = performedReps;
            }
        }
        //Precondition: none
        //Postcondition: returns complete, if false date = 0/0/0000
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
                if (TargetReps != Zero)
                {
                    return PercentageCompleted = Math.Round((double)PerformedReps / TargetReps * OneHundred, 2);

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
                getPercentageCompleted();
                return TotalScore = PercentageCompleted * Time;
            }
            else
            {
                return TotalScore = Zero;
            }
        }
        //Precondition: none
        //Postcondition: returns Hiit workout information in a single string
        public override string forPrint()
        {
            string workout;
            workout = "Workout: Hiit\n Name: " + getName() + " Date: " + getDate() + " Completion: " + getComplete() +
                "\n Validity: " + getValid() + " Percentage Completed: " + getPercentageCompleted() +
                " Total Score: " + getTotalScore() +

                 //Hiit items
                "\n Time: " + getTime() + " Training Period: " + getTrainingPeriod() + " Rest Period: " + getRestPeriod() +
                "\n Performed Reps: " + getPerformed() + " TargetReps: " + getTarget();
            return workout;
        }
    }
}
//Implementation Invariants
//public functions
//Hiit
// ~constructor initialize an object with values
//getTime
// ~returns time
//getTrainingPeriod
// ~returns TrainingPeriod
//getRestPeriod
// ~returns restPeriod
//getPerformedReps
// ~returns performedReps
//getTargetReps
// ~returns targetReps
//setPerformedReps
// ~updates validity and performedReps
//getComplete
// ~returns complete if valid
//getPercentageCompleted
// ~returns percentageCompleted if valid
//getTotalScore
// ~returns totalScore if valid
//forPrint
// ~returns a string value with all info of Hiit workout