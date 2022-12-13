//Author: Minh Nguyen
//Date: Wednesday September 28th, 2022
//Revision History
//First Revision: Monday September 26th, 2022
//Second Revision: Tuesday September 27th, 2022
//Third Revision: Wednesday September 28th, 2022

//Interface Invariants
//setName
// ~allows user to change the name of the object
//setDate
// ~allows user to change the date of the object
//setClassification
// ~allows user to change the classification of the object
//setWeight
// ~allows user to change the weight of the object
//setTargetReps
// ~allows user to change the number of target repetitions of the object
//setPerformedReps
// ~allows user to change the number of performed repetitions of the object
//isCompleted
// ~returns a true boolean value if the PerformedReps matches or exceeds the
//  TargetReps
// ~returns a false boolean value if the PerformedReps do not match or exceed
//  the TargetReps
//isValid
// ~returns a true boolean value if the FitSet object's weight or repetitions
//  has not been altered or changed since its initial creation
// ~returns a false boolean value if the user has changed or updated either the
//  weight or performed repetitions at least once since the initial creation of
//  the object
//percentageCompleted
// ~returns the percentage of repetitions performed out of the target repetitions
// ~it is okay for the percentage to be over 100, this is just working past your
//  original target and going above and beyond for your fitness
//totalScore
// ~returns the total score of the FitSet calculated from the product of the
//  Weight and PerformedReps

//Class Invariants
// The design of this class demonstrates my knowledge and understanding of classes
// and its attributes, constructor, and methods. This class uses information from
// its own attributes to update other attributes. To get the percentage of
// repetitions, i changed TargetReps and PerformedReps into float values so that
// when dividing I could get an accurate decimal value that represents the
// percentage of repetitions completed. Then I multipled that value by a constant
// integer OneHundred and added a percentafe sign (%) for readability. It is okay
// if the PerformedReps exceeds the TagetReps because that means the FitSet was
// completed and the user went above and beyond and performed extra. An object
// is complete if the percentage of repetitions is at 100% or exceeds 100%.
// To get the total score for the set, I multiplied the Weight by the
// PerformedReps and returned the total value as a float value because Weight
// is an integer value and PerformedReps is a float value. To solve for the
// validity of the object, there is a check inside the functions of setWeight and
// setPerformedReps to check if valid is true, and if the user changes the weight
// or number of performed repetitions of that object, then the validity of that
// object is false.

using System;
using System.Collections.Generic;
using System.Numerics;
using System.Reflection.Metadata.Ecma335;

namespace PA1
{
    public class FitSet
    {
        private string Name;
        private string Date;
        private string Classification;
        private int Weight;
        private float TargetReps;
        private float PerformedReps;
        private bool Complete = false;
        private bool Valid = true;
        private const int OneHundred = 100;
        private const int Zero = 0;

        public FitSet(string name, string date, string classification, int weight,
            float targetReps, float performedReps)
        {
            Name = name;
            Date = date;
            Classification = classification;
            Weight = weight;
            TargetReps = targetReps;
            PerformedReps = performedReps;
        }

        //Precondition: new name
        //Postcondition: updates the name of the FitSet
        public void setName(string name)
        {
            this.Name = name;
        }

        //Precondition: new date
        //Postcondition: updates the date of the FitSet
        public void setDate(string date)
        {
            this.Date = date;
        }

        //Precondition: new classification
        //Postcondition: updates the classification of the FitSet
        public void setClassification(string classification)
        {
            this.Classification = classification;
        }

        //Precondition: new weight
        //Postcondition: updates the weight of the FitSet
        public void setWeight(int weight)
        {
            if (Valid)
                Valid = !Valid;
            this.Weight = weight;
        }

        //Precondition: new target repetitions
        //Postcondition: updates the completeness of the FitSet and target
        //               repetitions of the FitSet
        public void setTargetReps(float targetReps)
        {
            this.TargetReps = targetReps;
            isCompleted();
            percentageCompleted();
        }

        //Precondition: new performed repetitions
        //Postcondition: updates the completeness of the FitSet and performed
        //               repetitions of the FitSet
        public void setPerformedReps(float performedReps)
        {
            if (Valid)
                Valid = !Valid;
            this.PerformedReps = performedReps;
            isCompleted();
            percentageCompleted();
        }

        //Precondition: none
        //Postcondition: returns the boolean value of Complete
        public bool isCompleted()
        {
            if (percentageCompleted() >= OneHundred)
                return Complete = true;
            return Complete;
        }
        //Precondition: none
        //Postcondition: returns the boolean value of Valid
        public bool isValid()
        {
            return Valid;
        }
        //Precondition: none
        //Postcondition: returns the percentage of repetitions performed
        //               out of the target number of repetitions if there
        //               is no division by zero. if there is, return zero.
        public double percentageCompleted()
        {
            if(TargetReps != Zero)
            {
                return Math.Round(PerformedReps / TargetReps * OneHundred, 2);
            }
            else
            {
                return Zero;
            }
        }
        //Precondition: none
        //Postcondition: returns the product of weight and repetitions
        //               performed as a total score
        public float totalScore()
        {
            if(Valid)
            {
                return Weight * PerformedReps;
            }
            else
            {
                return Zero;
            }
        }

        
        //Precondition: none
        //Postcondition: returns all of the information regarding one singular object
        //               to the user
        public void describeFitSet()
        {
            Console.WriteLine("\nWorkout Name: " + Name +
                "\nDate: " + Date +
                "\nClassification: " + Classification +
                "\nWeight: " + Weight +
                "\nTarget Repetitions: " + TargetReps +
                "\nPerformed Repetitions: " + PerformedReps);
        }
    }
}

//Implementation Invariants
//Attributes
// ~I created string Date as an attirbute because when a object is created,
//  it needs to be dated as completed on a specific date
// ~I created bool Valid as an attribute to return whether or not the object
//  is valid after the creation of of the object because of the factors that
//  could lead an object to become invalid
// ~I created const int OneHundred in place of 100 because I did not want to
//  hard code numbers into my code and I used the OneHundred variable to compare
//  if the percentage from percentageCompleted was equal to or over 100 and to
//  multiply the percentage value inside of percentageCompleted to become a
//  whole number instead of a decimal number for readbility purposes
//Public functions
//~mutators
// ~I allowed mutators so that the user can change aspects of the workout if needed
//  and i understand that changing the weight or number of performed repetitions
//  will make the workout invalid
// ~setName
// ~setDate
// ~setClassification
// ~setWeight
// ~setTargetReps
// ~setPerformedReps
//  ~all of these mutators set the attributes of an object, but there is not a
//   setComplete() or setValid() functions because these fields are updated by
//   the other attributes
//   ~Complete is updated by the calculation of the function isCompleted
//   ~Valid is updated by the setWeight and setPerformedReps functions
//   ~percentageCompleted() and isCompleted() is updated by the setTargetReps
//    function and setPerformedReps function after the data has been updated
//~isCompleted function
// ~This function will return a true or false boolean value based on if the object
//  has or has not been completed which uses the percentageCompleted function
// ~I chose to return Complete = true when the PerformedReps matches or exceeds the
//  TargetReps of the FitSet from the percentageCompleted
// ~I also made the choice to create a constant int variable named OneHundred to
//  compare if the percentageCompleted function returned a value equal to or more
//  than 100 to change the boolean completed to true
//~isValid function
// ~this function will return a true or false boolean value based on if the object's
//  weight or repetitions has not been altered or changed.
//  ~solving this problem was my most challenging because it made me think about
//   each thing that could happen to turn the object invalid. Then by checking each
//   case, when the weight of the object is updated, or when the performed repetitions
//   of teh object was updated, I can ensure the validity of a FitSet by checking to
//   see if it the object was altered or not
//   ~also this is based under the assumption that the "number of repetitions" from
//    canvas means the number of performed repetitions, not target repetitions
//~percentageCompleted function
// ~this function returns the percentage of repetitions performed out of the target
//  repetitions.
//  ~to solve this problem, I changed the TargetReps and PerformedReps object attributes
//   into float values so that when dividing I could get an accurate decimal value that
//   could then be multiplied by the constant integer OneHundred to represent the
//   percentage of repetitions completed as a whole number and not a decimal.
//  ~note there is no division by zero, so if the target repetitions is 0, then
//   this function should return zero
//  ~I used Math.Round(*double*, 2) to get only 2 decimal places for readability
//~totalScore function
// ~this function returns the total score of the FitSet calculated from the product
//  of the Weight and PerformedReps.
//  ~to solve this problem, I multiplied the Weight by the PerformedReps and
//   returned the total value as a float value because Weight is an integer
//   value and PerformedReps is a float value and I would need the returned value
//   then be a float because a float cannot change into an int but an int can
//   be casted into a float
// ~note, if the object is invalid, the score will be zero