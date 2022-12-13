//Minh Nguyen
//hiit.cpp

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
//~forFile
// returns the information about this workout in a single string
//~returnCopy
// returns copy of this workout
//~increment
// helper function to increment target reps
//~decrement
// helper function to increment target reps

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

#include "hiit.h"
#include <iostream>
#include <string>
#include <cmath>
#include <memory>
using namespace std;

//constructor
//Precondition: string name, string date, int trainingPeriod, int performedReps,
//              int targetReps
//Postcondition: initializing values of Workout object
hiit::hiit(string name, string date, double train, double rest, int performedReps,
           int targetReps) : workout(name, date)
{
    //base
    Name = name;
    Date = date;
    //derived
    TrainingPeriod = train;
    RestPeriod = rest;
    Time = TrainingPeriod + RestPeriod;
    PerformedReps = performedReps;
    TargetReps = targetReps;
}
//assignment overload operator
//Precondition: fitSet object
//Postcondition: initialized data from other object to this object
hiit& hiit::operator=(const hiit &obj){
    Name = obj.Name;
    Date = obj.Date;
    Time = obj.Time;
    TrainingPeriod = obj.TrainingPeriod;
    RestPeriod = obj.RestPeriod;
    if(PerformedReps != obj.PerformedReps)
        Valid = false;
    PerformedReps = obj.PerformedReps;
    TargetReps = obj.TargetReps;
    getComplete();
    return *this;
}
//destructor
//Precondition: none
//Postcondition: none
hiit::~hiit() {}
//copy constructor
//Precondition: fitSet object
//Postcondition: none
hiit::hiit(const hiit &obj){}
//Precondition: new performedReps
//Postcondition: changes the validity to false
//               updates performedreps
void hiit::setPerformedReps(int performedReps)
{
    if (Valid)
    {
        Valid = !Valid;
        this->PerformedReps = performedReps;
    }
}
//Precondition: none
//Postcondition: returns time
double hiit::getTime()
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
//Postcondition: returns trainingperiod
double hiit::getTrainingPeriod()
{
    if (Valid)
    {
        return TrainingPeriod;
    }
    else
    {
        return 0;
    }
}
//Precondition: none
//Postcondition: returns restperiod
double hiit::getRestPeriod()
{
    if (Valid)
    {
        return RestPeriod;
    }
    else
    {
        return 0;
    }
}
//Precondition: none
//Postcondition: returns performedreps
int hiit::getPerformedReps()
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
//Postcondition: returns targetreps
int hiit::getTargetReps()
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
//Postcondition: returns complete, if false date = 0/0/0000
bool hiit::getComplete()
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
double hiit::getPercentageCompleted()
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
        return Zero;
    }
}
//Precondition: none
//Postcondition: returns totalScore
double hiit::getTotalScore()
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
string hiit::forPrint()
{
    string workout;
    workout = "Workout: Hiit\n Name: " + getName() +
            " Date: " + getDate() +
            " Completion: " + to_string(getComplete()) +
            "\n Validity: " + to_string(getValid()) +
            " Percentage Completed: " + to_string(getPercentageCompleted()) +
            " Total Score: " + to_string(getTotalScore()) +

              //Hiit items
              "\n Time: " + to_string(getTime()) +
              " Training Period: " + to_string(getTrainingPeriod()) +
              " Rest Period: " + to_string(getRestPeriod()) +
              "\n Performed Reps: " + to_string(getPerformedReps()) +
              " TargetReps: " + to_string(getTargetReps());
    return workout;
}
//Precondition: none
//Postcondition: returns the information about this workout in a single string
string hiit::forFile()
{
    string temp;
    temp = "HIIT " + getName() + " " + to_string(getPerformedReps()) +
           " " + to_string(getTrainingPeriod()) + " " + to_string(getRestPeriod());
    return temp;
}
//Precondition: none
//Postcondition: returns a copy of this workout
shared_ptr<workout> hiit::returnCopy()
{
    return shared_ptr<workout> (new hiit(Name, Date, TrainingPeriod, RestPeriod, PerformedReps, TargetReps));
}
//Precondition: none
//Postcondition: increments target reps
void hiit::increment()
{
    TargetReps++;
}
//Precondition: none
//Postcondition: decrements targetreps
void hiit::decrement()
{
    TargetReps--;
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
//~forFile
// returns the information about this workout in a single string
//~returnCopy
// returns copy of this workout
//~increment
// helper function to increment target reps
//~decrement
// helper function to increment target reps