//Minh Nguyen
//sessionLog.cpp

#include "sessionLog.h"
#include <memory>
#include <vector>
#include <iostream>
using namespace std;

//Interface Invariants
//sessionLog
// ~constructors initialize an object with values
//~sessionLog
// ~destructor destroys allocated array
//sessionLog(const sessionLog&)
// ~copy constructor allows for deep copying
//sessionlog& operator=(const sessionLog&)
// ~overloaded assignment operator assigns values from another object
//addSet
// ~adds a FitSet object to fitset array
// ~if session is completed, throw exception
//addToWorkout
// ~edits a FitSet object in the fitset array
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

//default constructor
//Precondition: none
//Postcondition: initialized values of empty object
sessionLog::sessionLog()
{
    objCount = 0;
    Size = 10;
    StrengthTS = false;
    fitset = new shared_ptr<FitSet>[Size];
    StrengthTSreps = 0;
    StrengthTSweight = 0;
    check = false;
}

//destructor
//Precondition: none
//Postcondition: delete fitset array
sessionLog::~sessionLog()
{
  delete [] fitset;
  delete [] arrayFS;
}

//copy constructor
//Precondition: sessionLog object
//Postcondition: creates new object and initialized data from other object
sessionLog::sessionLog(const sessionLog &obj)
{
    objCount = obj.objCount;
    Size = obj.Size;
    fitset = new shared_ptr<FitSet>[Size];
    StrengthTS = obj.StrengthTS;
    StrengthTSreps = obj.StrengthTSreps;
    StrengthTSweight = obj.StrengthTSweight;
    check = obj.check;
    for(int i = 0; i < obj.Size; i++){
        fitset[i] = obj.fitset[i];
    }
}

//overloaded assignment operator
//Precondition: sessionLog object
//Postcondition: initialized data from other object
sessionLog& sessionLog::operator=(const sessionLog &obj)
{
    objCount = obj.objCount;
    Size = obj.Size;
    delete [] fitset;
    fitset = new shared_ptr<FitSet>[Size];
    StrengthTS = obj.StrengthTS;
    StrengthTSreps = obj.StrengthTSreps;
    StrengthTSweight = obj.StrengthTSweight;
    check = obj.check;
    for(int i = 0; i < obj.Size; i++){
        fitset[i] = obj.fitset[i];
    }
    return *this;
}

//Precondition: shared_ptr of type FitSet pointing to a FitSet object
//Postcondition: adds a fitset object to fitset array or throws exception
//               resizing the array when needed
void sessionLog::addSet(shared_ptr<FitSet> shared1) {
    objCount++;
    if (StrengthTS) {
        objCount--;
        throw invalid_argument("\nStrength Training Session Completed!"
                               "\n Unable to add FitSet.");
    }else if (objCount > Size) {
        resize();
        fitset[objCount - 1] = shared1;
    }else {
        fitset[objCount - 1] = shared1;
    }
}

//Precondition: int value for fitset index and shared_ptr of type FitSet
//              pointing to a FitSet object
//Postcondition: updates a fitset stored in fitset array or throws exception
void sessionLog::addToWorkout(int val, shared_ptr<FitSet> obj){
    if(StrengthTS)
        throw invalid_argument("\nStrength Training Session Completed!"
                               "\n Unable to edit FitSet.");
    else
        fitset[val] = obj;
}

//Precondition: int temp for fitset index
//Postcondition: removes a fitset from the fitset array or throws exception
void sessionLog::removeSet(int temp)
{
    if(StrengthTS){
        throw invalid_argument("\nStrength Training Session Completed!"
                               "\n Unable to remove FitSet.");
    }else{
        objCount--;
        fitset[temp].reset();  //delete the managed object
    }
}

//Precondition: vector of type shared_ptr of type FitSet, boolean value, and
//              shared_ptr of type sessionLog
//Postcondition: option to build session from a prior sessionLog or just add multiple
//               FitSet objects to the fitset array on a sessionLog object
void sessionLog::buildSession(vector<shared_ptr<FitSet>> obj1, bool usePrior,
                              shared_ptr<sessionLog> obj2)
{
    //build session off of old session
    if(usePrior){
        objCount = obj2->objCount;
        Size = obj2->Size;
        delete [] fitset;
        fitset = new shared_ptr<FitSet>[Size];
        StrengthTS = obj2->StrengthTS;
        StrengthTSreps = obj2->StrengthTSreps;
        StrengthTSweight = obj2->StrengthTSweight;
        for(int i = 0; i < obj2->Size; i++) {
            fitset[i] = obj2->fitset[i];
        }
    }

    //build session with more than one FitSet
    for(long unsigned int i = 0; i < obj1.size(); i++){
        addSet(obj1[i]);
    }
}

//Precondition: int reps and int weight values for a Strength Training Session
//Postcondition: assigns the values of weight and reps to the sessionLog object
//               and also assigns true to StrengthTS which does not allow for
//               any FitSets to be added, edited, or deleted from the fitset array
void sessionLog::justDoIt(int reps, int weight)
{
    this->StrengthTSreps = reps;
    this->StrengthTSweight = weight;
    StrengthTS = true;
}

//Precondition: none
//Postcondition: displays information about the sessionLog object
string* sessionLog::shareSession()
{
  if(check){
    delete [] arrayFS;
    check = false;
  }
  string* arrayFS = new string[objCount];
  check = true;
  string FS;
  for(int i = 0; i < objCount; i++){
    FS = fitset[i]->getName() + "  " +
      fitset[i]->getClass() + "   " +
      to_string(fitset[i]->getWeight()) + "      " +
      to_string(fitset[i]->getTargetReps()) + "        " +
      to_string(fitset[i]->getPerformedReps()) + "             " +
      fitset[i]->getDate() +"    " +
      to_string(fitset[i]->isCompleted());
    arrayFS[i] = FS;
  }
  return arrayFS;
}

//Precondition: none
//Postcondition: resizes the fitset array by doubling the size of the array
void sessionLog::resize()
{
    Size = Size * 2;
    shared_ptr<FitSet> * tempArr = new shared_ptr<FitSet>[Size];
    for(int i = 0; i < Size/2; i++){
        tempArr[i] = fitset[i];
    }
    delete [] fitset;
    fitset = tempArr;
}

int sessionLog::getObjCount(){
    return objCount;
}

//Implementation Invariants
//Public Functions
// ~sessionLog
//  ~constructors initialize an object with values
// ~~sessionLog
//  ~destructor destroys allocated array fitset with delete
//sessionLog(const sessionLog&)
// ~copy constructor allows for deep copying
//sessionlog& operator=(const sessionLog&)
// ~overloaded assignment operator assigns values from another object
//addSet
// ~this function adds a FitSet object to the sessionLog fitset array
//  ~if the object count is greater than the size of the array, then
//   a resize of the array is needed
//  ~objCount is incremented
// ~if session is completed, throw exception
//addToWorkout
// ~edits a FitSet object in the sessionLog fitset array
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
