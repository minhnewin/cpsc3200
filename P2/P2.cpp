//Minh Nguyen
#include <iostream>
#include <string>
#include <vector>
#include <memory>
#include "sessionLog.h"
using namespace std;

//for random FitSet array sizes
const int minString = 0, maxString = 7;
const int minVal = 0, maxVal = 50;
const int minCal = 1, maxCal = 30;

//arrays with random information for randomized FitSets
const string names [] = {"Squat      ", "Bench-Press", "Lunge      ",
                         "Deadlift   ", "Crunch     ", "Plank      ",
                         "Pull-Ups   ", "Push-Ups   "};
const string classes [] = {"Legs", "Arms", "Legs", "Legs",
                           "Core", "Core", "Arms", "Arms"};

shared_ptr<FitSet> randomFitSet();
void newSession(vector<shared_ptr<sessionLog>>&);
void removeSession(vector<shared_ptr<sessionLog>>&);
void printSessions(vector<shared_ptr<sessionLog>>);
void addSet(int, vector<shared_ptr<sessionLog>>&);
void removeSet(int, int, vector<shared_ptr<sessionLog>>&);
void editSet(int, int, vector<shared_ptr<sessionLog>>&);
void completeSession(int, int, int, vector<shared_ptr<sessionLog>>&);
void testAssignment(int, int, vector<shared_ptr<sessionLog>>&);
void testCopy(int, vector<shared_ptr<sessionLog>>&);
void build(int, int, vector<shared_ptr<FitSet>>, bool,
           vector<shared_ptr<sessionLog>>&);

int main()
{
    //for random number generator
    srand (time(NULL));

    //stl container vector of shared_ptr<sessionLog>
    vector<shared_ptr<sessionLog>> multipleSessions;

    //add a new session 1 to vector
    newSession(multipleSessions);

    //add a randomized fitset to session 1
    addSet(1, multipleSessions);

    //add to FitSet workout in session 1's fitset[0]
    editSet(1,1, multipleSessions);

    //add another randomized fitset to session 1
    addSet(1, multipleSessions);

    //remove 2nd added fitset from session 1
    removeSet(1,2,multipleSessions);

    //strength training session
    //triggers StrengthTrainingSession = true
    //no more additions to multiple sessions[0] or throw exception
    completeSession(1,10,10,multipleSessions);

    //add set3 to session 1
    //triggers throw exception
    /*
    addSet(1, multipleSessions);
     */

    //add a new session 2 to vector
    newSession(multipleSessions);

    //assignment overloaded operator testing for sessionLog
    testAssignment(2, 1, multipleSessions);

    //add a new session 3 to vector with copy constructor copying from session 2
    testCopy(2, multipleSessions);

    //add a new session 4 to vector
    newSession(multipleSessions);

    //add a new session 5 to vector
    newSession(multipleSessions);

    //add 2 fitsets to session 4
    addSet(4, multipleSessions);
    addSet(4, multipleSessions);

    //create a vector of 2 fitset objects
    vector<shared_ptr<FitSet>> multipleFitSet;
    multipleFitSet.push_back(randomFitSet());
    multipleFitSet.push_back(randomFitSet());

    //builds session4 off session3 and then the vector of FitSet objects are added after
    //session 3 must not have Strength Training Session completed
    //boolean prior to tell buildSession to build off previous session
    //if true, then build off the previous session
    //if false, then the session will build off the remaining fitset vector
    build(5,4,multipleFitSet, true, multipleSessions);

    //should be sessions 1-5
    printSessions(multipleSessions);

    //removing 4 sessionLogs from the stl container
    removeSession(multipleSessions);
    removeSession(multipleSessions);
    removeSession(multipleSessions);
    removeSession(multipleSessions);

    //should be only session 1
    printSessions(multipleSessions);

    return 0;
}

shared_ptr<FitSet> randomFitSet(){
    string day = to_string(rand() % maxCal + minCal);
    string date = "9/" + day + "/2022";
    int temp1 = rand() % maxString + minString;
    int temp2 = rand() % maxVal + minVal;
    int temp3 = rand() % maxVal + minVal;
    int temp4 = rand() % maxVal + minVal;
    return shared_ptr<FitSet> (new FitSet(names[temp1], date, classes[temp1],
                                           temp2, temp3, temp4));
}

void newSession(vector<shared_ptr<sessionLog>>& sessions){
    sessions.push_back(shared_ptr<sessionLog> (new sessionLog()));
}

void removeSession(vector<shared_ptr<sessionLog>>& sessions){
    sessions.pop_back();
}

void printSessions(vector<shared_ptr<sessionLog>> sessions){
  for(long unsigned int i = 0; i < sessions.size(); i++) {
    cout << "\nSession " << i + 1 << "\n";
    cout << "Name         Class  Weight TargetReps "
         << "PerformedReps Date       Completion" << endl;
    int count = sessions[i]->getObjCount();
    string* arr = new string[count - 1];
    arr =  sessions[i]->shareSession();
    for(int j = 0; j < count; j++){
      cout << arr[j] << endl;
    }
  }
}

void addSet(int session, vector<shared_ptr<sessionLog>>& sessions){
    sessions[session - 1]->addSet(randomFitSet());
}

void removeSet(int session, int fitset, vector<shared_ptr<sessionLog>>& sessions){
    sessions[session - 1]->removeSet(fitset - 1);
}

void editSet(int session, int fitset, vector<shared_ptr<sessionLog>>& sessions){
    sessions[session -  1]->addToWorkout(fitset - 1, randomFitSet());
}

void completeSession(int session, int weight, int reps, vector<shared_ptr<sessionLog>>& sessions){
    sessions[session - 1]->justDoIt(weight, reps);
}

void testAssignment(int session1, int session2, vector<shared_ptr<sessionLog>>& sessions){
    sessions[session1 - 1] = sessions[session2 - 1];
}

void testCopy(int session, vector<shared_ptr<sessionLog>>& sessions){
    sessions.push_back(shared_ptr<sessionLog> (new sessionLog()) = sessions[session - 1]);
}

void build(int session1, int session2, vector<shared_ptr<FitSet>> obj1,
           bool prior, vector<shared_ptr<sessionLog>>& sessions){
    sessions[session1 - 1]->buildSession(obj1, prior, sessions[session2 - 1]);
}
