//Interface Invariants
//Workout
// ~constructor initialize an object with values
//getName
// ~returns name
//getDate
// ~returns date
//getValid
// ~returns valid
//getComplete
// ~returns complete
//getPercentageCompleted
// ~returns percentageCompleted
//getTotalScore
// ~returns totalScore
//forPrint
// ~returns a string value with all info of TriWorkout workout

//Class Invariants
// This is the base class of a FitSet, TriWorkout, and Hiit
// these other classes inherit the functionality of this base class

using System;
using System.Collections.Generic;
using System.Numerics;
using System.Reflection.Metadata.Ecma335;

namespace PA3
{
    public class Workout
    {
        protected string Name;
        protected string Date;
        protected bool Complete = false;
        protected bool Valid = true;
        protected double PercentageCompleted;
        protected double TotalScore;

        protected const int OneHundred = 100;
        protected const int Zero = 0;

        //constructor
        //Precondition: string name, string date
        //Postcondition: initializing values of Workout object
        public Workout(string name, string date)
        {
            Name = name;
            Date = date;
        }
        //Precondition: none
        //Postcondition: returns name
        public string getName()
        {
            if (Valid)
            {
                return Name;
            }
            else
            {
                return "";
            }
        }
        //Precondition: none
        //Postcondition: returns date
        public string getDate()
        {
            if (Valid)
            {
                return Date;
            }
            else
            {
                return "0/0/0000";
            }
        }
        //Precondition: none
        //Postcondition: returns boolean value of complete
        public virtual bool getComplete()
        {
            if (Valid)
            {
                return Complete;
            }
            else
            {
                return false;
            }
        }
        //Precondition: none
        //Postcondition: returns the boolean value of Valid
        public bool getValid()
        {
            if (Valid)
            {
                return Valid;
            }
            else
            {
                return false;
            }
        }
        //Precondition: none
        //Postcondition: returns the percentageCompleted
        public virtual double getPercentageCompleted()
        {
            if (Valid)
            {
                return PercentageCompleted;
            }
            else
            {
                return Zero;
            }
        }
        //Precondition: none
        //Postcondition: returns the totalScore
        public virtual double getTotalScore()
        {
            if (Valid)
            {
                return TotalScore;
            }
            else
            {
                return Zero;
            }
        }
        //Precondition: none
        //Postcondition: returns a string value
        public virtual string forPrint()
        {
            return "";
        }
    }
}
//Implementation Invariants
//public functions
//Workout
// ~constructor initialize an object with values
//getName
// ~returns name
//getDate
// ~returns date
//getValid
// ~returns valid
//getComplete
// ~returns complete if valid
//getPercentageCompleted
// ~returns percentageCompleted if valid
//getTotalScore
// ~returns totalScore if valid
//forPrint
// ~returns a string value with all info of TriWorkout workout