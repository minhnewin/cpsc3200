using System.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Interface Invariants
//RepetitionMonitor
// ~constructor initializes values
//Subscribe
// ~calls the provider's subscribe which adds this monitor to the list
//  of observers in CoachedAthlete
//Oncompleted
// ~No implementation needed: Method is not called by the CoachedMonitor class.
//OnError
// ~No implementation needed: Method is not called by the CoachedMonitor class.
//OnNext
// ~checks the sessionlog object if the parameters meet, and if they do it
//  uses the textwriter to either write to the console, write to a file,
//  or write to a string what that can be printed to the console. This monitor
//  will check if the performed reps for a workout is greater than its own workout
//  set target distance.

//Class invariants
//This class shows my knowledge of how a monitor would react to a call from
//something it is subscribed to, in this case CoachedAthlete's call of OnNext
//each time a new sessionlog is added to the CoachedAthlete array of
//sessionlogs. It will update its textwriter functionality if and only if the
//requirments are met by the sessionlog class

namespace P5
{
    public class RepetitionMonitor : IObserver<SessionLog>
    {
        private string Name;
        private IDisposable cancellation;
        private TextWriter Writer;

        //Precondition: string name and textwriter object
        //Postcondition: initializes an empty monitor
        public RepetitionMonitor(string name, TextWriter writer)
        {
            if (String.IsNullOrEmpty(name))
                throw new ArgumentNullException("The observer must be assigned a name.");
            this.Name = name;
            this.Writer = writer;
        }

        //Precondition: Coached Athlete provider object
        //Postcondition: calls the provider's subscribe which adds this monitor
        //               to the list of observers in CoachedAthlete
        public virtual void Subscribe(CoachedAthlete provider)
        {
            cancellation = provider.Subscribe(this);
        }

        //Precondition: none
        //Postcondition: none
        public virtual void OnCompleted()
        {
            // No implementation.
        }

        //Precondition: none
        //Postcondition: none
        public virtual void OnError(Exception e)
        {
            // No implementation.
        }

        //Precondition: sessionlog object
        //Postcondition: checks the sessionlog object if the parameters meet
        public virtual void OnNext(SessionLog session)
        {
            int count = session.getObjCount();
            Workout[] temp = session.shareWorkouts();
            bool check = false;
            foreach(Workout work in temp)
            {
                if(work.getPerformed() >= work.getTarget() && !check)
                {
                    check = true;
                    Writer.Write("The given session log has at least one workout where\n" +
                            "the performed repetitions are greater than target repetitions\n\n");
                }
            }
            Writer.Flush();
        }
    }
}
//RepetitionMonitor
// ~constructor initializes values
//Subscribe
// ~calls the provider's subscribe which adds this monitor to the list
//  of observers in CoachedAthlete
//Oncompleted
// ~No implementation needed: Method is not called by the CoachedMonitor class.
//OnError
// ~No implementation needed: Method is not called by the CoachedMonitor class.
//OnNext
// ~checks the sessionlog object if the parameters meet, and if they do it
//  uses the textwriter to either write to the console, write to a file,
//  or write to a string what that can be printed to the console. This monitor
//  will check if the performed reps for a workout is greater than its own workout
//  set target distance.