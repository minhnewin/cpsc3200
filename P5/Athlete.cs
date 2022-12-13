// Minh Nguyen
//Athlete.cs

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Interface Invariants
//Athlete
// ~default constructor
//  initializes value for size and creates sessionlog array
//AddSessionLog
// ~adds a sessionlog to the sessionlog array
//Report
// ~returns a single string containing all sessionlog workouts

//Class invariants
//The design of this class shows my knowledge of a base class that will be
//reused by the CoachedAthlete class.

namespace P5
{
    public class Athlete
    {
        protected int Size;
        protected int ObjCount;
        protected SessionLog[] sessions = null;

        //default constructor
        //Precondition: none
        //Postcondition: initialized values of empty Athlete object
        public Athlete()
        {
            this.Size = 10;
            this.ObjCount = 0;
            this.sessions = new SessionLog[Size];
        }
        //Precondition: sessionlog object
        //Postcondition: adds a sessionlog object to the sessionlog array
        public virtual void AddSessionLog(SessionLog addSession)
        {
            ObjCount++;
            sessions[ObjCount - 1] = addSession;
        }

        //Precondition: none
        //Postcondition: returns a single string of of all sessionLog workouts
        public string Report()
        {
            string temp = "";
            for(int i = 0; i < ObjCount; i++)
            {
                temp += "\n\n SessionLog " + (i+1) + "\n\n";
                int count;
                count = sessions[i].getObjCount();
                string[] strings = new string[count];
                strings = sessions[i].shareSession();
                for (int j = 0; j < count; j++)
                {
                    temp += "\n" + strings[j];
                }
            }
            temp += "\n\n";
            return temp;
        }
    }
}

//Implementation Invariants
//Athlete
// ~default constructor
//  initializes value for size and creates sessionlog array
//AddSessionLog
// ~adds a sessionlog to the sessionlog array
//  storing sessionlog objects in this base class
//Report
// ~returns a single string containing all sessionlog workouts
//  this is for easy printing and readability