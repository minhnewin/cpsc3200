//Minh Nguyen
//workout.cpp

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

#include "workout.h"
#include <iostream>
#include <string>
#include <memory>
using namespace std;

workout::workout(string name, string date)
{
    Name = name;
    Date = date;
}
workout::workout(){}
//Precondition:
//Postcondition:
workout& workout::operator=(const workout &obj){
    Name = obj.Name;
    Date = obj.Date;
    Complete = obj.Complete;
    Valid = obj.Valid;
    PercentageCompleted = obj.PercentageCompleted;
    TotalScore = obj.TotalScore;
    return *this;
}
//Precondition: none
//Postcondition: returns name
string workout::getName()
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
string workout::getDate()
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
//Postcondition: returns the boolean value of Valid
bool workout::getValid()
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
//Postcondition: returns boolean value of complete
bool workout::getComplete()
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
//Postcondition: returns the percentageCompleted
double workout::getPercentageCompleted()
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
double workout::getTotalScore()
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
string workout::forPrint()
{
    return "";
}
//Precondition: none
//Postcondition: returns a string value
string workout::forFile()
{
    return "";
}
//Precondition: none
//Postcondition: returns a copy of the workout
shared_ptr<workout> workout::returnCopy()
{
    return 0;
}
//Precondition: none
//Postcondition: increments target
void workout::increment()
{

}
//Precondition: none
//Postcondition: decrements target
void workout::decrement()
{

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
// ~returns a string value with all info of workout
//~forFile
// returns the information about this workout in a single string
//~returnCopy
// returns copy of this workout
//~increment
// helper function to increment target
//~decrement
// helper function to increment target
