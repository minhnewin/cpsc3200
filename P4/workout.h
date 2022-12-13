//Minh Nguyen
//workout.h

#ifndef WORKOUT_H
#define WORKOUT_H
#include <iostream>
#include <string>
#include <memory>
using namespace std;

class workout {
protected:
    string Name;
    string Date;
    bool Complete = false;
    bool Valid = true;
    double PercentageCompleted;
    double TotalScore;
    const int OneHundred = 100;
    const int Zero = 0;
public:
    workout();
    workout(string, string);
    virtual workout& operator=(const workout&);

    string getName();
    string getDate();
    bool getValid();
    virtual bool getComplete();
    virtual double getPercentageCompleted();
    virtual double getTotalScore();
    virtual string forPrint();

    virtual string forFile();
    virtual shared_ptr<workout> returnCopy();
    virtual void increment();
    virtual void decrement();
};

#endif //WORKOUT_H