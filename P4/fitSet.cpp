//Minh Nguyen
//fitSet.cpp

//Interface Invariants
//FitSet
// ~constructor initialize an object with values
//setWeight
// ~allows user to change the weight of the object
//setPerformedReps
// ~allows user to change the number of performed repetitions of the object
//getComplete
// ~returns a true boolean value if the PerformedReps matches or exceeds the
//  TargetReps
// ~returns a false boolean value if the PerformedReps do not match or exceed
//  the TargetReps
//getPercentageCompleted
// ~returns the percentage of repetitions performed out of the target repetitions
// ~it is okay for the percentage to be over 100, this is just working past your
//  original target and going above and beyond for your fitness
//totalScore
// ~returns the total score of the FitSet calculated from the product of the
//  Weight and PerformedReps
//forPrint
// ~returns a string value with all info of Hiit workout

//Class Invariants
// This is a sub class of a base class named Workout
// it inherits most of the functionality and some protected attributes
// from Workout.
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

#include "fitSet.h"
#include <iostream>
#include <string>
#include <cmath>
#include <memory>
using namespace std;

//constructor
//Precondition: new data to be assigned to object
//Postcondition: initialized values of object from input
fitSet::fitSet(string name, string date, string classification, double weight,
               int targetReps, int performedReps) : workout(name, date)
{
    //base
    Name = name;
    Date = date;
    //derived
    Classification = classification;
    Weight = weight;
    TargetReps = targetReps;
    PerformedReps = performedReps;
}
//assignment overload operator
//Precondition: fitSet object
//Postcondition: initialized data from other object to this object
fitSet& fitSet::operator=(const fitSet &obj){
    Name = obj.Name;
    Date = obj.Date;
    Classification = obj.Classification;
    TargetReps = obj.TargetReps;
    if(Weight != obj.Weight)
        Valid = false;
    Weight = obj.Weight;
    if(PerformedReps != obj.PerformedReps)
        Valid = false;
    PerformedReps = obj.PerformedReps;
    getComplete();
    return *this;
}
//destructor
//Precondition: none
//Postcondition: none
fitSet::~fitSet(){}
//copy constructor
//Precondition: fitSet object
//Postcondition: none
fitSet::fitSet(const fitSet &obj){}
//Precondition: new weight
//Postcondition: updates the weight of the fitSet
void fitSet::setWeight(int weight)
{
    if (Valid)
    {
        Valid = !Valid;
        this->Weight = weight;
    }
}
//Precondition: new performed repetitions
//Postcondition: updates the completeness of the fitSet and performed
//               repetitions of the fitSet
void fitSet::setPerformedReps(int performedReps)
{
    if (Valid)
    {
        Valid = !Valid;
        this->PerformedReps = performedReps;
        getComplete();
        getPercentageCompleted();
    }
}
//Precondition: none
//Postcondition: returns classification
string fitSet::getClass()
{
    if (Valid)
    {
        return Classification;
    }
    else
    {
        return "";
    }
}
//Precondition: none
//Postcondition: returns weight
double fitSet::getWeight()
{
    if (Valid)
    {
        return Weight;
    }
    else
    {
        return 0;
    }
}
//Precondition: none
//Postcondition: returns targetReps
int fitSet::getTargetReps()
{
    if (Valid)
    {
        return TargetReps;
    }
    else
    {
        return 0;
    }
}
//Precondition: none
//Postcondition: returns performedReps
int fitSet::getPerformedReps()
{
    if (Valid)
    {
        return PerformedReps;
    }
    else
    {
        return 0;
    }
}
//Precondition: none
//Postcondition: returns the boolean value of Complete
bool fitSet::getComplete()
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
//Postcondition: returns the percentage of repetitions performed
//               out of the target number of repetitions if there
//               is no division by zero. if there is, return zero.
double fitSet::getPercentageCompleted()
{
    if (Valid)
    {
        if (TargetReps != Zero)
        {
            return PercentageCompleted = (double)PerformedReps / (double)TargetReps * OneHundred;
        }
        else
        {
            return PercentageCompleted = Zero;
        }
    }
    else
    {
        return PercentageCompleted = Zero;
    }
}
//Precondition: none
//Postcondition: returns the product of weight and repetitions
//               performed as a total score
double fitSet::getTotalScore()
{
    if (Valid)
    {
        return TotalScore = Weight * PerformedReps;
    }
    else
    {
        return TotalScore = Zero;
    }
}
//Precondition: none
//Postcondition: returns the information about this workout in a single string
string fitSet::forPrint()
{
    string workout;
    workout = "Workout: FitSet\n Name: " + getName() +
            " Date: " + getDate() +
            " Completion: " + to_string(getComplete()) +
            "\n Validity: " + to_string(getValid()) +
            " Percentage Completed: " + to_string(getPercentageCompleted()) +
            " Total Score: " + to_string(getTotalScore()) +

            //fitSet items
            "\n Class: " + getClass() +
            " Weight: " + to_string(getWeight()) +
            " TargetReps: " + to_string(getTargetReps()) +
            " PerformedReps: " + to_string(getPerformedReps());
    return workout;
}
//Precondition: none
//Postcondition: returns the information about this workout in a single string
string fitSet::forFile()
{
    string temp;
    temp = "FitSet " + getName() + " " + getClass() +
            " " + to_string(getWeight()) + " " + to_string(getPerformedReps());
    return temp;
}
//Precondition: none
//Postcondition: returns a copy of this workout
shared_ptr<workout> fitSet::returnCopy()
{
    return shared_ptr<workout> (new fitSet(Name, Date, Classification, Weight, TargetReps, PerformedReps));
}
//Precondition: none
//Postcondition: increments target reps
void fitSet::increment()
{
    TargetReps++;
}
//Precondition: none
//Postcondition: decrements target reps
void fitSet::decrement()
{
    TargetReps--;
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
// ~setWeight
// ~setPerformedReps
// ~getClass
// ~getWeight
// ~getTargetReps
// ~getPerformedReps
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
//~forPrint
// returns the information about this workout in a single string
//~forFile
// returns the information about this workout in a single string
//~returnCopy
// returns copy of this workout
//~increment
// helper function to increment target reps
//~decrement
// helper function to increment target reps