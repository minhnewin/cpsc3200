//Minh Nguyen
//hiit.h

#ifndef HIIT_H
#define HIIT_H
#include "workout.h"
#include <iostream>
#include <string>
#include <memory>
using namespace std;

class hiit : public workout{
private:
    double Time;
    double TrainingPeriod;
    double RestPeriod;
    int PerformedReps;
    int TargetReps;

    hiit(const hiit&);
public:
    hiit(string, string, double, double, int, int);
    hiit& operator=(const hiit&);
    ~hiit();

    void setPerformedReps(int performedReps);

    double getTime();
    double getTrainingPeriod();
    double getRestPeriod();
    int getPerformedReps();
    int getTargetReps();

    bool getComplete();
    double getPercentageCompleted();
    double getTotalScore();
    string forPrint();

    string forFile();
    shared_ptr<workout> returnCopy();
    void increment();
    void decrement();
};


#endif //HIIT_H
