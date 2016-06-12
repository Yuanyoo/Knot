using UnityEngine;
using System.Collections;

public class Timer  {
	private static System.Timers.Timer aTimer;
	private static int second = 1000;//1000 is one second.
//	private static int minute = 60000;//6 * 1000 is one minute
	public static bool started;
	public bool Stoped { get; set; }

	public Timer(){
	}

	public void initTimer(float numberSeconds, int numberMinutes){
		started = false;
		Debug.Log ("Init Timer");
		// Normally, the timer is declared at the class level,
		// so that it stays in scope as long as it is needed.
		// If the timer is declared in a long-running method,  
		// KeepAlive must be used to prevent the JIT compiler 
		// from allowing aggressive garbage collection to occur 
		// before the method ends. You can experiment with this
		// by commenting out the class-level declaration and 
		// uncommenting the declaration below; then uncomment
		// the GC.KeepAlive(aTimer) at the end of the method.
		//System.Timers.Timer aTimer;
		
		// Create a timer with a ten second interval.
		aTimer = new System.Timers.Timer(numberSeconds * second);//aTimer = new System.Timers.Timer(10 * second);
		Debug.Log ("INTERVAL1: " + aTimer.Interval);
		// Hook up the Elapsed event for the timer.
		aTimer.Elapsed += new System.Timers.ElapsedEventHandler(OnTimedEvent);
		
		// Set the Interval to 2 seconds (2000 milliseconds).
		//aTimer.Interval = 2 * second; Debug.Log ("INTERVAL2: " + aTimer.Interval);
		aTimer.Enabled = true;
		
		Debug.Log ("Finish configuring Timer");
		
		// If the timer is declared in a long-running method, use
		// KeepAlive to prevent garbage collection from occurring
		// before the method ends.
		//GC.KeepAlive(aTimer);

		started = true;
	}

	// Specify what you want to happen when the Elapsed event is 
	// raised.
	private void OnTimedEvent(object source, System.Timers.ElapsedEventArgs e)
	{
		Debug.Log ("INTERVAL3: " + aTimer.Interval);
		Debug.Log (string.Format("The Elapsed event was raised at {0}", e.SignalTime));
		aTimer.Stop ();
		Stoped = true;

	}


}
