using P5;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Collections.Specialized.BitVector32;

//Interface Invariants
//CoachedAthlete
// ~constructor
//Subscribe
// ~adds an observer to the list of observers for this provider, where on the
//  action of adding a sessionlog object will call OnNext for each monitor in
//  List of observers "subscribed"
//AddSessionLog
// ~adds a sessionlog to the base class array of sessionlogs and calls
//  the function OnNext for each monitor that is subscribed to the provider
//  for that sessionlog object
//getFirstObserver
// ~for testing file of CoachedAthlete

//Class Invariants
//The design of this class represents my knowlege of code reuse and how
//to use and apply interfaces and the applications of the IObservable class
//where there is simulated multiple inheritance.
//observers (which are our monitors) are subscribed to this provider and
//after this provider adds a sessionlog, it is checked by each monitor's
//respective OnNext function call

namespace P5
{
    public class CoachedAthlete : Athlete, IObservable<SessionLog>
    {
        private List<IObserver<SessionLog>> observers;

        //Precondition: none
        //Postcondition: creates CoachedAthlete object and new List of observers
        public CoachedAthlete()
        {
            observers = new List<IObserver<SessionLog>>();
        }
        //Precondition: none
        //Postcondition: none
        class NoOpUnsubscriber : IDisposable
        {
            public void Dispose() { } 
        }
        //Precondition: IObserver<SessionLog> observer (monitor object)
        //Postcondition: adds the observer to the list of observers
        public IDisposable Subscribe(IObserver<SessionLog> observer)
        {
            if (!observers.Contains(observer))
            {
                observers.Add(observer);
            }
            return new NoOpUnsubscriber();
        }
        //Precondition: sessionlog object
        //Postcondition: adds the sessionlog in the base class array and
        //              calls OnNext for each observer in the list of observers
        public override void AddSessionLog(SessionLog addSession)
        {
            base.AddSessionLog(addSession);
            foreach (IObserver<SessionLog> observer in observers)
            {
                observer.OnNext(addSession);
            }
        }
        //For test file only
        //Precondition: none
        //Postcondition: returns the first observer in the list of observers
        public IObserver<SessionLog> getFirstObserver()
        {
            if (observers.Count <= 1)
                return observers[0];
            else return null;
        }
    }
}
//Implementation Invariants
//CoachedAthlete
// ~constructor
//  creates empty object
//Subscribe
// ~adds an observer to the list of observers for this provider, where on the
//  action of adding a sessionlog object will call OnNext for each monitor in
//  List of observers "subscribed"
//AddSessionLog
// ~adds a sessionlog to the base class array of sessionlogs and calls
//  the function OnNext for each monitor that is subscribed to the provider
//  for that sessionlog object
//getFirstObserver
// ~for testing file of CoachedAthlete