//Minh Nguyen
//sessionlog.cpp

//Interface Invariants
//sessionLog
// ~constructors initialize an object with values
//addSet
// ~adds a FitSet object to fitset array
// ~if session is completed, throw exception
//removeSet
// ~removes a FitSet object from the fitset array
// ~if session is completed, throw exception
//buildSession
// ~builds a session off a prior session if client wants
// ~adds multiple FitSet objects to fitset array
//justDoIt
// ~user performs Strength Training Session and logs weight and reps
//  and once this session is performed, the session cannot be changed or edited
//shareSession
// ~displays session information to user
//resize
// ~resizes the fitset array if needed

//Class Invariants
// The purpose of this class is to store an array of FitSet objects
// and to show my understanding and use of smart pointers. FitSet objects
// referenced by many shared_ptrs and those are stored in an array of
// type shared_ptr<FitSet>. These FitSet objects are added, edited, and
// removed from the sessionLog class when needed. User can build a sessionLog
// from prior sessionLogs and is able to use deep copying. the class also has
// a Strength Training Session with the justDoIt member function and this
// halts any additions, edits, or removals of FitSets to the sessionLog object.

#include "sessionLog.h"
#include "workout.h"
#include "triWorkout.h"
#include "fitSet.h"
#include "hiit.h"
#include <iostream>
#include <vector>
#include <string>
#include <cmath>
#include <memory>
using namespace std;

sessionLog::sessionLog(string dateCheck)
{
    Size = 10;
    ObjCount = 0;
    DateCheck = dateCheck;
    StrengthTSreps = 0;
    StrengthTSweight = 0;
    StrengthTS = false;
    print = new string[Size];
    workouts = new shared_ptr<workout>[Size];
}
//overloaded assignment operator
//Precondition: sessionLog object
//Postcondition: initialized data from other object
sessionLog& sessionLog::operator=(const sessionLog &obj)
{
    ObjCount = obj.ObjCount;
    Size = obj.Size;
    delete [] workouts;
    workouts = new shared_ptr<workout>[Size];
    StrengthTS = obj.StrengthTS;
    StrengthTSreps = obj.StrengthTSreps;
    StrengthTSweight = obj.StrengthTSweight;
    DateCheck = obj.DateCheck;
    for(int i = 0; i < obj.Size; i++){
        workouts[i] = obj.workouts[i];
    }
    return *this;
}
//destructor
//Precondition: none
//Postcondition: delete print array and workouts array
sessionLog::~sessionLog() {
    delete[] print;
    delete[] workouts;
}
//copy constructor
//Precondition: sessionLog object
//Postcondition: creates new object and initialized data from other object
sessionLog::sessionLog(const sessionLog &obj)
{
    ObjCount = obj.ObjCount;
    Size = obj.Size;
    workouts = new shared_ptr<workout>[Size];
    StrengthTS = obj.StrengthTS;
    StrengthTSreps = obj.StrengthTSreps;
    StrengthTSweight = obj.StrengthTSweight;
    DateCheck = obj.DateCheck;
    for(int i = 0; i < obj.Size; i++){
        workouts[i] = obj.workouts[i];
    }
}
sessionLog::sessionLog(sessionLog &&src)
{
    Size = src.Size;
    ObjCount = src.ObjCount;
    DateCheck = src.DateCheck;
    StrengthTSreps = src.StrengthTSreps;
    StrengthTSweight = src.StrengthTSweight;
    StrengthTS = src.StrengthTS;
    print = src.print;
    workouts = src.workouts;

    //zero out caller's handle
    src.Size = 0;
    src.ObjCount = 0;
    src.DateCheck = "";
    src.StrengthTSreps = 0;
    src.StrengthTSweight = 0;
    src.StrengthTS = false;
    src.print = nullptr;
    src.workouts = nullptr;
}
sessionLog& sessionLog::operator=(sessionLog &&src){
    swap(Size, src.Size);
    swap(ObjCount, src.ObjCount);
    swap(DateCheck, src.DateCheck);
    swap(StrengthTSreps, src.StrengthTSreps);
    swap(StrengthTSweight, src.StrengthTSweight);
    swap(StrengthTS, src.StrengthTS);
    swap(print, src.print);
    swap(workouts, src.workouts);
    return *this;
}
//Precondition: Class type Workout object
//Postcondition: adds a workout object to work array or throws exception
//               resizing the array when needed
void sessionLog::addSet(shared_ptr<workout> addWorkout)
{
    if (!StrengthTS)
    {
        if (DateCheck != addWorkout->getDate())
        {
            //Date is not valid
            return;
        }
        else
        {
            ObjCount++;
            if (StrengthTS)
            {
                ObjCount--;
                throw new invalid_argument("\nStrength Training Session Completed!\n Unable to add Workout.");
            }
            else if (ObjCount > Size)
            {
                resize();
                workouts[ObjCount - 1] = addWorkout;
            }
            else
            {
                workouts[ObjCount - 1] = addWorkout;
            }
        }
    }
}
//Precondition: int temp for work index
//Postcondition: removes a workout from the fitset array or throws exception
void sessionLog::removeSet(int temp)
{
    if (!StrengthTS)
    {
        if (StrengthTS)
        {
            throw new invalid_argument("\nStrength Training Session Completed!\n Unable to remove FitSet.");
        }
        else
        {
            ObjCount--;
            for (int i = temp - 1; i < 4; i++)
            {
                workouts[i] = workouts[i + 1];
            }
        }
    }
}
//Precondition: array of type workout, boolean value, and
//               sessionLog object
//Postcondition: option to build session from a prior sessionLog or just add multiple
//               workout objects to the work array on a sessionLog object
void sessionLog::buildSession(vector<shared_ptr<workout>> obj1, bool usePrior, sessionLog obj2)
{
    if (!StrengthTS)
    {
        //build session off of old session
        if (usePrior)
        {
            ObjCount = obj2.ObjCount;
            Size = obj2.Size;
            workouts = new shared_ptr<workout>[Size];
            StrengthTS = obj2.StrengthTS;
            StrengthTSreps = obj2.StrengthTSreps;
            StrengthTSweight = obj2.StrengthTSweight;
            for (int i = 0; i < Size; i++)
            {
                workouts[i] = obj2.workouts[i];
            }
        }

        //build session with more than one Workout
        for (long unsigned int i = 0; i < obj1.size() ; i++)
        {
            addSet(obj1[i]);
        }
    }
}
//Precondition: int reps and int weight values for a Strength Training Session
//Postcondition: assigns the values of weight and reps to the sessionLog object
//               and also assigns true to StrengthTS which does not allow for
//               any operations on SessionLog
void sessionLog::justDoIt(int reps, int weight)
{
    this->StrengthTSreps = reps;
    this->StrengthTSweight = weight;
    StrengthTS = true;
}
//Precondition: none
//Postcondition: returns a string array of all information from work array
string* sessionLog::shareSession()
{
    cout << "0" << endl;

    cout << "1" << endl;
    //print = new string[ObjCount];
    cout << "2" << endl;
    for (int i = 0; i < ObjCount; i++)
    {
        print[i] = workouts[i]->forPrint();
    }
    return print;
}
//Precondition: none
//Postcondition: returns a string array of all information from work array
string* sessionLog::shareForFile()
{
    for (int i = 0; i < ObjCount; i++)
    {
        print[i] = workouts[i]->forFile();
    }
    return print;
}
//Precondition: none
//Postcondition: resizes the fitset array by doubling the size of the array
void sessionLog::resize()
{
    Size = Size * 2;
    shared_ptr<workout>* tempArr = new shared_ptr<workout>[Size];
    for (int i = 0; i < Size / 2; i++)
    {
        tempArr[i] = workouts[i];
    }
    workouts = tempArr;
}
//Precondition: none
//Postcondition: returns ObjCount
int sessionLog::getObjCount() const
{
    return ObjCount;
}
//Precondition: sessionLog&
//Postcondition: returns bool on whether the session is less than the other
bool sessionLog::operator<(const sessionLog& obj)
{
    if(ObjCount < obj.ObjCount)
        return true;
    return false;
}
//Precondition: sessionLog&
//Postcondition: returns bool on whether the session is greater than the other
bool sessionLog::operator>(const sessionLog& obj)
{
    if(ObjCount > obj.ObjCount)
        return true;
    return false;
}
//Precondition: sessionLog&
//Postcondition: adds workouts from another session to this session
sessionLog& sessionLog::operator+=(sessionLog& obj)
{
    if(obj.workouts)
    {
        for(int i = 0; i < obj.ObjCount; i++)
        {
            addSet(obj.workouts[i]->returnCopy());
        }
    }
    return *this;
}
//Precondition: sessionLog&
//Postcondition: adds two sessions together creating a third
sessionLog* sessionLog::operator+(const sessionLog& obj)
{
    sessionLog* temp = new sessionLog("11/1/2022");
    for(int i = 0; i < ObjCount; i++)
    {
        temp->addSet(workouts[i]->returnCopy());
    }
    for(int i = 0; i < obj.ObjCount; i++)
    {
        temp->addSet(obj.workouts[i]->returnCopy());
    }
    return temp;
}
//Precondition: int
//Postcondition: increments the target of each workout
sessionLog& sessionLog::operator++(int)
{
    for(int i = 0; i < ObjCount; i++)
    {
        workouts[i]->increment();
    }
    return *this;
}
//Precondition: int
//Postcondition: decrements the target of each workout
sessionLog& sessionLog::operator--(int)
{
    for(int i = 0; i < ObjCount; i++)
    {
        workouts[i]->decrement();
    }
    return *this;
}

//Implementation Invariants
//Public Functions
// ~sessionLog
//  ~constructor initialize an object with values

//addSet
// ~this function adds a FitSet object to the sessionLog fitset array
//  ~if the object count is greater than the size of the array, then
//   a resize of the array is needed
//  ~objCount is incremented
// ~if session is completed, throw exception
//removeSet
// ~removes a FitSet object from the sessionLog fitset array
//  ~decrements objCount
// ~if session is completed, throw exception
//buildSession
// ~builds a session off a prior session by passing in a pointer to a
//  prior sessionLog by reference and building off of that previous sessionLog
// ~then the function adds multiple FitSet objects to fitset array through
//  a passed in vector of type shared_ptr<FitSet>
//justDoIt
// ~user performs Strength Training Session and logs weight and reps
//  and once this session is performed, the session cannot be changed or edited
//   ~this means a bool is then flipped from false to true and now when
//    something tries to alter sessionLog, they are unable to do so
//shareSession
// ~displays session information to user
//resize
// ~resizes the fitset array if needed
//  ~need to copy to a temp array and delete fitset before assigning
//   fitset to the temp array
//getObjCount
// ~returns the SessionLog objCount
//shareForFile
// ~displays session information to user
//operator>
// returns bool on whether the session is greater than the other
//operator<
// returns bool on whether the session is less than the other
//operator+
// adds two sessionlog objects' workouts into one new sessionlog
//operator++
// increments the target of all workouts
//operator--
// decrements the target of all workouts
//operator+=
// adds to existing sessionlog object from another sessionlog
