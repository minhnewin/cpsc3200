//Minh Nguyen
//fitset.cpp

#include "fitSet.h"
#include <iostream>
#include <cmath>
#include <iomanip>
using namespace std;

//Interface Invariants
//FitSet
// ~constructors initialize an object with values
//FitSet& operator=
// ~overloaded assignment operator assigns values from another object
//~FitSet
// ~destructor
//setWeight
// ~allows user to change the weight of the object
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

//default constructor
//Precondition: none
//Postcondition: initializing values of empty object
FitSet::FitSet()
{
    Name = "";
    Date = "";
    Classification = "";
    Weight = 0;
    TargetReps = 0;
    PerformedReps = 0;
    Valid = true;
    Complete = false;
}

//constructor
//Precondition: new data to be assigned to object
//Postcondition: initialized values of object from input
FitSet::FitSet(string unnamed, string unnamed1, string name, string date, string classification, int weight,
               int targetReps, int performedReps)
{
    Name = name;
    Date = date;
    Classification = classification;
    Weight = abs(weight);
    TargetReps = abs(targetReps);
    PerformedReps = abs(performedReps);
    Valid = true;
    isCompleted();
}

//destructor
//Precondition: none
//Postcondition: none
FitSet::~FitSet(){}

//copy constructor
//Precondition: FitSet object
//Postcondition: none
FitSet::FitSet(const FitSet &obj){}

//assignment overload operator
//Precondition: FitSet object
//Postcondition: initialized data from other object to this object
FitSet& FitSet::operator=(const FitSet &obj){
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
    isCompleted();
    return *this;
}

//Precondition: new weight
//Postcondition: updates the weight of the FitSet
void FitSet::setWeight(int weight)
{
    if (Valid)
        Valid = !Valid;
    this->Weight = weight;
}

//Precondition: new performed repetitions
//Postcondition: updates the completeness of the FitSet and performed
//               repetitions of the FitSet
void FitSet::setPerformedReps(int performedReps)
{
    if (Valid)
        Valid = !Valid;
    this->PerformedReps = performedReps;
    isCompleted();
    percentageCompleted();
}

//Precondition: none
//Postcondition: returns the boolean value of Complete
bool FitSet::isCompleted()
{
    if (percentageCompleted() >= OneHundred)
        return Complete = true;
    else
        Date = "0/0/0000";
    return Complete;
}

//Precondition: none
//Postcondition: returns the boolean value of Valid
bool FitSet::isValid()
{
    return Valid;
}

//Precondition: none
//Postcondition: returns the percentage of repetitions performed
//               out of the target number of repetitions if there
//               is no division by zero. if there is, return zero.
int FitSet::percentageCompleted()
{
    if(TargetReps != Zero)
    {
        return (PerformedReps / TargetReps * OneHundred);
    }
    else
    {
        return Zero;
    }
}

//Precondition: none
//Postcondition: returns the product of weight and repetitions
//               performed as a total score
int FitSet::totalScore()
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
//Postcondition: returns name
string FitSet::getName()
{
  return Name;
}

//Precondition: none
//Postcondition: returns classification
string FitSet::getClass()
{
  return Classification;
}

//Precondition: none
//Postcondition: returns weight
int FitSet::getWeight()
{
  return Weight;
}

//Precondition: none
//Postcondition: returns targetReps
int FitSet::getTargetReps()
{
  return TargetReps;
}

//Precondition: none
//Postcondition: returns performedReps
int FitSet::getPerformedReps()
{
  return PerformedReps;
}

//Precondition: none
//Postcondition: returns date
string FitSet::getDate()
{
  return Date;
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
// ~getName
// ~getClass
// ~getWeight
// ~getTargetReps
// ~getPerformedReps
// ~getDate
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
