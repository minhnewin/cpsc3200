//Minh Nguyen
//triworkout.h

#ifndef TRIWORKOUT_H
#define TRIWORKOUT_H
#include "workout.h"
#include <iostream>
#include <string>
using namespace std;

class triWorkout : public workout{
private:
    double Time;
    double PerformedDistance;
    double TargetDistance;
    double Pace;

    triWorkout(const triWorkout&);
public:
    triWorkout(string, string, double, double, double);
    triWorkout& operator=(const triWorkout&);
    ~triWorkout();

    void setPerformedDistance(int);

    double getTime();
    double getPerformedDistance();
    double getTargetDistance();
    double getPace();

    void calcPace();
    bool getComplete();
    double getPercentageCompleted();
    double getTotalScore();
    string forPrint();

    string forFile();
    shared_ptr<workout> returnCopy();
    void increment();
    void decrement();
};

#endif //TRIWORKOUT_H
