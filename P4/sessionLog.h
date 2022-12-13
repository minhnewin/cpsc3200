//Minh Nguyen
//sessionlog.h

#ifndef SESSIONLOG_H
#define SESSIONLOG_H
#include "workout.h"
#include <iostream>
#include <string>
#include <vector>
#include <memory>

class sessionLog {
private:
    int Size;
    int ObjCount;
    string DateCheck;

    int StrengthTSreps;
    int StrengthTSweight;
    bool StrengthTS;   //strength training session, once completed, cant edit any other

    string* print;    //used by sharesession
    shared_ptr<workout>* workouts;

public:
    sessionLog(string);
    sessionLog& operator=(const sessionLog&);
    ~sessionLog();
    sessionLog(const sessionLog&);
    sessionLog(sessionLog &&);
    sessionLog& operator=(sessionLog &&);

    void addSet(shared_ptr<workout>);
    void removeSet(int temp);
    void buildSession(vector<shared_ptr<workout>> obj1, bool usePrior, sessionLog obj2);
    void justDoIt(int reps, int weight);
    string* shareSession();
    string* shareForFile();
    void resize();
    int getObjCount() const;

    friend ostream & operator << (ostream&, sessionLog&);
    friend istream & operator>> (istream&, sessionLog&);

    bool operator<(const sessionLog&);
    bool operator>(const sessionLog&);
    sessionLog& operator+=(sessionLog&);
    sessionLog* operator+(const sessionLog&);
    sessionLog& operator++(int);
    sessionLog& operator--(int);
};


#endif //SESSIONLOG_H
