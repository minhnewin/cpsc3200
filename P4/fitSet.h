//Minh Nguyen
//fitSet.h

#ifndef FITSET_H
#define FITSET_H
#include "workout.h"
#include <iostream>
#include <string>
#include <memory>
using namespace std;

class fitSet : public workout{
private:
    string Classification;
    double Weight;
    int TargetReps;
    int PerformedReps;

    fitSet(const fitSet&);
public:
    fitSet(string, string, string, double, int, int);
    fitSet& operator=(const fitSet&);
    ~fitSet();

    void setWeight(int);
    void setPerformedReps(int);

    string getClass();
    double getWeight();
    int getTargetReps();
    int getPerformedReps();

    bool getComplete();
    double getPercentageCompleted();
    double getTotalScore();
    string forPrint();

    string forFile();
    shared_ptr<workout> returnCopy();
    void increment();
    void decrement();
};

#endif //fitSet_H
