//Minh Nguyen
//Overview:
// This program is for fitness documentation and allows the user to track
// workouts as objects of a class. There is a SessionLog class that has a
// heterogeneous collection of a base class type workout. The user can input a
// string date in the format 0/0/0000 into the constructor of SessionLog.
// The base class Workout has 3 types of sub classes: FitSet, TriWorkout, and Hiit
// The user can input values into the constructor of FitSet in this order:
// a string name, a string date, a string classification, an integer number of weight in pounds,
// an integer number of target amount of repetitions, and an integer number of performed repetitions.
// The user can input values into the constructor of TriWorkout in this order:
// a string name, a string date, an integer time, an integer performedDistance,
// and an int targetDistance.
// The user can input values into the constructor of Hiit in this order:
// a string name, a string date, an integer training Period, an integer performedReps,
// and an integer targetReps
// The user is able to use the public functionality of the SessionLog class which
// are addSet() with the parameter being a Workout type class object to be added
// to the heterogenous collection, removeSet() which removes a Workout from the
// collection at an indexed value passed into removeSet(), buildSession() which takes
// an array of type Workout, a boolean to build off a prior sessionLog object,
// and the sessionLog object that the user wants to build off of depending on the
// value type of the boolean, justDoIt() that takes in an amout of reps and weight
// to complete the Session and log a strength training session, shareSession() which
// returns an array of string values of all the data in a Workout that is contained
// within the heterogeneous collection, and a getObjCount() function that returns the
// number of Workouts in the heterogeneous collection within SessionLog.
// The user is also then able to print all this data to the screen by using the
// printsession() public function in main that takes in a sessionLog object as
// a parameter. the other functions are to randomize the values of the 3 different
// classes

//Assumptions
// This program assumes that when a workout is recorded, it is always valid, but
// if the performed repetitions is altered (and/or the weight in FitSet),
// then the workout is invalid and the total score of the workout is zero.
// This program assumes the number of performed repetitions can exceed the number
// of target repetitions, this only makes the percentage completed over 100%.
// This program assumes all values are positive not negative.

#include "sessionLog.h"
#include "workout.h"
#include "fitSet.h"
#include "triWorkout.h"
#include "hiit.h"
#include <iostream>
#include <string>
#include <vector>
#include <memory>
#include <fstream>
#include <sstream>

using namespace std;

const int size = 3, zero = 0;
const string date = "11/1/2022";
//FitSet
const int maxFS = 7;
const int maxVal = 50;
//TriWorkout
const int maxTW = 2;
const int minTime = 1, maxTimeT = 60;
const int minDist = 1, maxDist = 20;
//Hiit
const int maxH = 10;
const int maxTimeH = 30;

//fitset item characteristics
const string FSnames [] = {"Squat", "Bench-Press", "Lunge",
                    "Deadlift", "Crunch", "Plank",
                    "Pull-Ups", "Push-Ups"};
const string FSclasses [] = {"Legs", "Arms", "Legs", "Legs",
                      "Core", "Core", "Arms", "Arms"};

//TriWorkout item characteristics
const string TRInames [] = {"running", "cycling", "swimming"};

//Hiit item characteristics
const string HIITnames [] = {"high-jacks", "plank-jacks", "burpees", "jumping-lunges",
                      "mountain-climbers", "jumping-squats", "side-lunges", "saw-plank", "butt-kicks",
                      "sideplank-walks", "jumping-jacks"};

const string fileA = "TESTA.txt";
const string fileB = "TESTB.txt";
const string fileC = "TESTC.txt";
const string fileX = "TESTX.txt";
const string fileY = "TESTY.txt";
const string fileZ = "TESTZ.txt";

shared_ptr<workout> randomFitSet();
shared_ptr<workout> randomTriWorkout();
shared_ptr<workout> randomHIIT();
void printFileInfo(sessionLog& a);

void previousTests();
void test1();
void test2();
void test3();

int main() {
    srand (time(NULL));

    previousTests();
    test1();
    test2();
    test3();

    return 0;
}
shared_ptr<workout> randomFitSet(){
    return shared_ptr<workout>
            (new fitSet(FSnames[rand() % maxFS + zero],
                        date,
                        FSclasses[rand() % maxFS + zero],
                        rand() % maxVal + zero,
                        rand() % maxVal + zero,
                        rand() % maxVal + zero));
}

shared_ptr<workout> randomTriWorkout() {
    return shared_ptr<workout>
            (new triWorkout(TRInames[rand() % maxTW + zero],
                            date,
                            rand() % maxTimeT + minTime,
                            rand() % maxDist + minDist,
                            rand() % maxDist + minDist));
}

shared_ptr<workout> randomHIIT() {
    return shared_ptr<workout>
            (new hiit(HIITnames[rand() % maxH + zero],
                      date,
                      rand() % maxTimeH + minTime,
                      rand() % maxTimeH + minTime,
                      rand() % rand() % maxVal + zero,
                      rand() % maxVal + zero));
}

void printFileInfo(sessionLog& a) {
    if (a.getObjCount() != 0) {
        int count = a.getObjCount();
        string *arr = new string[count - 1];
        arr = a.shareForFile();
        for (int j = 0; j < count; j++) {
            cout << arr[j] << endl;
        }
        delete[] arr;
    }
}

ostream & operator << (ostream &out, sessionLog &s)
{
    int temp = s.getObjCount();
    out << temp << "\n";

    string* arr = new string[temp];
    arr = s.shareForFile();

    for (int i = 0; i < temp; i ++)
    {
        out << arr[i] << "\n";
    }
    return out;
}

istream& operator >> (istream& in, sessionLog& s)
{
    int temp;
    in >> temp;

    //shared
    string type;
    string name;
    double time;
    int reps;
    //Tri
    double dist;
    //Hiit
    double rest;
    //Fitset
    string cat;
    double weight;

    stringstream ss;
    for (int i = 0; i < temp; i ++)
    {
        in >> type;
        if (type == "TriWorkout")
        {
            in >> name >> time >> dist;
            s.addSet(shared_ptr<workout> (new triWorkout(name, date, time, dist, dist*(double)2)));
        }
        if (type == "HIIT")
        {
            in >> name >> reps >> time >> rest;
            s.addSet(shared_ptr<workout> (new hiit(name, date, time, rest, reps, reps*2)));
        }
        if (type == "FitSet")
        {
            in >> name >> cat >> weight >> reps;
            s.addSet(shared_ptr<workout> (new fitSet(name, date, cat, weight, reps*2, reps)));
        }
    }
    return in;
}

void previousTests()
{
    vector<unique_ptr<sessionLog>> manySessions;
    unique_ptr<sessionLog> SL = make_unique<sessionLog>("11/1/2022");
    manySessions.push_back(move(SL));
    manySessions[0]->addSet(randomFitSet());
}

void test1()
{
    // PART 1

    sessionLog forA(date);
    forA.addSet(randomFitSet());
    forA.addSet(randomTriWorkout());
    forA.addSet(randomHIIT());

    sessionLog forB(date);
    forB.addSet(randomFitSet());
    forB.addSet(randomTriWorkout());
    forB.addSet(randomHIIT());
    forB.addSet(randomFitSet());
    forB.addSet(randomTriWorkout());
    forB.addSet(randomHIIT());

    ofstream makeA(fileA);
    makeA << forA;
    makeA.close();

    ofstream makeB(fileB);
    makeB << forB;
    makeB.close();

    sessionLog A(date), B(date);

    ifstream readA;
    readA.open(fileA);
    if (readA.is_open()) {
        readA >> A;
    }
    readA.close();

    ifstream readB;
    readB.open(fileB);
    if (readB.is_open()) {
        readB >> B;
    }
    readB.close();

    sessionLog* C = new sessionLog(date);
    C = A + B;

    ofstream makeC(fileC);
    makeC << *C;
    makeC.close();
    delete C;
}

void test2()
{
    // PART 2
    sessionLog forY(date);
    forY.addSet(randomFitSet());
    forY.addSet(randomTriWorkout());
    forY.addSet(randomHIIT());

    sessionLog forZ(date);
    forZ.addSet(randomFitSet());
    forZ.addSet(randomTriWorkout());
    forZ.addSet(randomHIIT());
    forZ.addSet(randomFitSet());
    forZ.addSet(randomTriWorkout());
    forZ.addSet(randomHIIT());

    ofstream makeY(fileY);
    makeY << forY;
    makeY.close();

    ofstream makeZ(fileZ);
    makeZ << forZ;
    makeZ.close();

    sessionLog* Y = new sessionLog(date);
    sessionLog* Z = new sessionLog(date);

    ifstream readY;
    readY.open(fileY);
    if (readY.is_open()) {
        readY >> *Y;
    }
    readY.close();

    ifstream readZ;
    readZ.open(fileZ);
    if (readZ.is_open()) {
        readZ >> *Z;
    }
    readZ.close();

    cout << endl << endl << "Size of Y: " << Y->getObjCount() << endl;
    cout << "Size of Z: " << Z->getObjCount() << endl;

    bool test1;
    test1 = Y < Z;

    cout << "Bool value for Y less than Z: ";
    if(test1)
        cout << "true" << endl;
    else
        cout << "false" << endl;

    bool test2;
    test2 = Y > Z;

    cout << "Bool value for Y greater than Z: ";
    if(test2)
        cout << "true" << endl;
    else
        cout << "false" << endl;
}
void test3()
{
    // PART 3

    sessionLog forX(date);
    forX.addSet(randomFitSet());
    forX.addSet(randomTriWorkout());
    forX.addSet(randomHIIT());

    ofstream makeX(fileX);
    makeX << forX;
    makeX.close();

    sessionLog X(date);

    ifstream readX;
    readX.open(fileX);
    if (readX.is_open()) {
        readX >> X;
    }
    readX.close();

    X++;
    cout << endl << "AFTER INCREMENTING X" << endl << endl;
    printFileInfo(X);
}
