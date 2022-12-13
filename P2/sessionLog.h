//Minh Nguyen
//sessionLog.h

#ifndef SESSIONLOG_H
#define SESSIONLOG_H
#include "fitSet.h"
#include <iostream>
#include <string>
#include <vector>
#include <memory>
using namespace std;

class sessionLog
{
private:
    int objCount;
    int Size;
    bool StrengthTS;   //strength training session, once completed, cant edit any other
    shared_ptr<FitSet> * fitset;
    int StrengthTSreps;
    int StrengthTSweight;
    string * arrayFS;
    bool check;

public:
    sessionLog();
    ~sessionLog();
    sessionLog(const sessionLog&);
    sessionLog& operator=(const sessionLog&);

    void addSet(shared_ptr<FitSet>);
    void addToWorkout(int, shared_ptr<FitSet>);
    void buildSession(vector<shared_ptr<FitSet>>, bool, shared_ptr<sessionLog>);
    void removeSet(int);
    void justDoIt(int, int);
    string* shareSession();

    void resize();
    int getObjCount();
};

#endif //SESSIONLOG_H
