//Interface Invariants
//sessionLog
// ~constructors initialize an object with values
//addSet
// ~adds a FitSet object to fitset array
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


using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace PA3
{
    public class SessionLog
    {
        private int Size;
        private int ObjCount;
        private string DateCheck;

        private int StrengthTSreps;
        private int StrengthTSweight;
        private bool StrengthTS;   //strength training session, once completed, cant edit any other

        private string[] arrayFS = null;    //used by sharesession
        private Workout[] work = null;

        //default constructor
        //Precondition: string Date to check against workouts
        //Postcondition: initialized values of empty object with dateCheck updated
        public SessionLog(string dateCheck)
        {
            this.Size = 10;
            this.ObjCount = 0;
            this.DateCheck = dateCheck;
            this.StrengthTSreps = 0;
            this.StrengthTSweight = 0;
            this.StrengthTS = false;
            this.arrayFS = new string[Size];
            this.work = new Workout[Size];
        }
        //Precondition: Class type Workout object
        //Postcondition: adds a workout object to work array or throws exception
        //               resizing the array when needed
        public void addSet(Workout addWorkout)
        {
            if (!StrengthTS)
            {
                if (!String.Equals(DateCheck, addWorkout.getDate()))
                {
                    //Date is not valid
                    return;
                }
                else
                {
                    ObjCount++;
                    if (StrengthTS)
                    {
                        ObjCount--;
                        throw new InvalidOperationException("\nStrength Training Session Completed!\n Unable to add Workout.");
                    }
                    else if (ObjCount > Size)
                    {
                        resize();
                        work[ObjCount - 1] = addWorkout;
                    }
                    else
                    {
                        work[ObjCount - 1] = addWorkout;
                    }
                }
            }
        }
        //Precondition: int temp for work index
        //Postcondition: removes a workout from the fitset array or throws exception
        public void removeSet(int temp)
        {
            if (!StrengthTS)
            {
                if (StrengthTS)
                {
                    throw new InvalidOperationException("\nStrength Training Session Completed!\n Unable to remove FitSet.");
                }
                else
                {
                    ObjCount--;
                    for (int i = temp - 1; i < 4; i++)
                    {
                        work[i] = work[i + 1];
                    }
                }
            }
        }
        //Precondition: array of type workout, boolean value, and
        //               sessionLog object
        //Postcondition: option to build session from a prior sessionLog or just add multiple
        //               workout objects to the work array on a sessionLog object
        public void buildSession(Workout[] obj1, bool usePrior,
                              SessionLog obj2)
        {
            if (!StrengthTS)
            {
                //build session off of old session
                if (usePrior)
                {
                    ObjCount = obj2.ObjCount;
                    Size = obj2.Size;
                    work = new Workout[Size];
                    StrengthTS = obj2.StrengthTS;
                    StrengthTSreps = obj2.StrengthTSreps;
                    StrengthTSweight = obj2.StrengthTSweight;
                    for (int i = 0; i < Size; i++)
                    {
                        work[i] = obj2.work[i];
                    }
                }

                //build session with more than one Workout
                for (int i = 0; i < obj1.Length; i++)
                {
                    addSet(obj1[i]);
                }
            }
        }
        //Precondition: int reps and int weight values for a Strength Training Session
        //Postcondition: assigns the values of weight and reps to the sessionLog object
        //               and also assigns true to StrengthTS which does not allow for
        //               any operations on SessionLog
        public void justDoIt(int reps, int weight)
        {
            this.StrengthTSreps = reps;
            this.StrengthTSweight = weight;
            StrengthTS = true;
        }
        //Precondition: none
        //Postcondition: returns a string array of all information from work array
        public string[] shareSession()
        {
            arrayFS = new string[ObjCount];
            for (int i = 0; i < ObjCount; i++)
            {
                arrayFS[i] = work[i].forPrint();
            }
            return arrayFS;
        }
        //Precondition: none
        //Postcondition: resizes the fitset array by doubling the size of the array
        public void resize()
        {
            Size = Size * 2;
            Workout[] tempArr = new Workout[Size];
            for (int i = 0; i < Size / 2; i++)
            {
                tempArr[i] = work[i];
            }
            work = tempArr;
        }
        //Precondition: none
        //Postcondition: returns ObjCount
        public int getObjCount()
        {
            return ObjCount;
        }
    }
}
//Implementation Invariants
//Public Functions
// ~sessionLog
//  ~constructor initialize an object with values

//addSet
// ~this function adds a FitSet object to the sessionLog fitset array
//  ~if the object count is greater than the size of the array, then
//   a resize of the array is needed
//  ~objCount is incremented
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
//getObjCount
// ~returns the SessionLog objCount