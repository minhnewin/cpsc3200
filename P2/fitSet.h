//Minh Nguyen
//fitset.h

#ifndef FITSET_H
#define FITSET_H
#include <iostream>
#include <string>
using namespace std;

class FitSet {
private:
    string Name;
    string Date;
    string Classification;
    int Weight;
    int TargetReps;
    int PerformedReps;
    bool Complete = false;
    bool Valid;
    const int OneHundred = 100;
    const int Zero = 0;

    FitSet(const FitSet&);
public:
    FitSet();
    FitSet(string, string, string, int, int, int);
    FitSet& operator=(const FitSet&);
    ~FitSet();

    void setWeight(int);
    void setPerformedReps(int);

    string getName();
    string getClass();
    int getWeight();
    int getTargetReps();
    int getPerformedReps();
    string getDate();
  
    bool isCompleted();
    bool isValid();
    int percentageCompleted();
    int totalScore();
};

#endif //FITSET_H
