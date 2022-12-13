//Minh Nguyen
//triworkout.cpp

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
//~forFile
// returns the information about this workout in a single string
//~returnCopy
// returns copy of this workout
//~increment
// helper function to increment target reps
//~decrement
// helper function to increment target reps

//Class Invariants
// This is a sub class of a base class named Workout
// it inherits most of the functionality and some protected attributes
// from Workout.

#include "triWorkout.h"
#include <iostream>
#include <string>
#include <cmath>
#include <memory>
using namespace std;

//Precondition: string name, string date, int time, int performedDistance,
//              int targetDistance
//Postcondition: initialized values of object from input
triWorkout::triWorkout(string name, string date, double time, double performedDistance,
                       double targetDistance) : workout(name, date)
{
    //base
    Name = name;
    Date = date;
    //derived
    Time = time;
    PerformedDistance = performedDistance;
    TargetDistance = targetDistance;
}
//assignment overload operator
//Precondition: fitSet object
//Postcondition: initialized data from other object to this object
triWorkout& triWorkout::operator=(const triWorkout &obj){
    Name = obj.Name;
    Date = obj.Date;
    Time = obj.Time;
    if(PerformedDistance != obj.PerformedDistance)
        Valid = false;
    PerformedDistance = obj.PerformedDistance;
    TargetDistance = obj.TargetDistance;
    getComplete();
    return *this;
}
//destructor
//Precondition: none
//Postcondition: none
triWorkout::~triWorkout() {}
//copy constructor
//Precondition: fitSet object
//Postcondition: none
triWorkout::triWorkout(const triWorkout &obj){}
//Precondition: new performedDistance
//Postcondition: updates validity and performedDistance
void triWorkout::setPerformedDistance(int performedDistance)
{
    if (Valid)
    {
        Valid = !Valid;
        this->PerformedDistance = performedDistance;
    }
}
//Precondition: none
//Postcondition: returns time
double triWorkout::getTime()
{
    if (Valid)
    {
        return Time;
    }
    else
    {
        return 0;
    }
}
//Precondition: none
//Postcondition: returns performedDistance
double triWorkout::getPerformedDistance()
{
    if (Valid)
    {
        return PerformedDistance;
    }
    else
    {
        return 0;
    }
}
//Precondition: none
//Postcondition: returns targetDistance
double triWorkout::getTargetDistance()
{
    if (Valid)
    {
        return TargetDistance;
    }
    else
    {
        return 0;
    }
}
//Precondition: none
//Postcondition: returns pace after calculating the pace
double triWorkout::getPace()
{
    if (Valid)
    {
        calcPace();
        return Pace;
    }
    else
    {
        return 0;
    }
}
//Precondition: none
//Postcondition: calculates the pace based off performedDistance and Time
void triWorkout::calcPace()
{
    if (Valid)
    {
        if(Time != 0)
            Pace = (double)PerformedDistance / (double)Time * OneHundred;
        else
            Pace = 0;
    }
}
//Precondition: none
//Postcondition: returns complete or date = 0/0/0000 if false
bool triWorkout::getComplete()
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
double triWorkout::getPercentageCompleted()
{
    if (Valid)
    {
        if (TargetDistance != Zero)
        {
            return PercentageCompleted = (double)PerformedDistance / (double)TargetDistance * OneHundred;
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
double triWorkout::getTotalScore()
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
string triWorkout::forPrint()
{
    string workout;
    workout = "Workout: TriWorkout\n Name: " + getName() +
            " Date: " + getDate() +
            " Completion: " + to_string(getComplete()) +
            "\n Validity: " + to_string(getValid()) +
            " Percentage Completed: " + to_string(getPercentageCompleted()) +
            " Total Score: " + to_string(getTotalScore()) +

            //triworkout items
            "\n Time: " + to_string(getTime()) +
            " Performed Distance: " + to_string(getPerformedDistance()) +
            " Target Distance: " + to_string(getTargetDistance()) +
            " Pace: " + to_string(getPace());
    return workout;
}
//Precondition: none
//Postcondition: returns the information about this workout in a single string
string triWorkout::forFile()
{
    string temp;
    temp = "TriWorkout " + getName() + " " + to_string(getTime()) +
           " " + to_string(getPerformedDistance());
    return temp;
}
//Precondition: none
//Postcondition: returns a copy of this workout
shared_ptr<workout> triWorkout::returnCopy()
{
    return shared_ptr<workout> (new triWorkout(Name, Date, Time, PerformedDistance, TargetDistance));
}
//Precondition: none
//Postcondition: increments target distance
void triWorkout::increment()
{
    TargetDistance++;
}
//Precondition: none
//Postcondition: decrements target distance
void triWorkout::decrement()
{
    TargetDistance--;
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
//~forFile
// returns the information about this workout in a single string
//~returnCopy
// returns copy of this workout
//~increment
// helper function to increment target reps
//~decrement
// helper function to increment target reps