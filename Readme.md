Using the Code
=
Using the code is as simple as this:

	static void Main()
	{
	    //First and only entry point of the profiler
	    ProxyGenerator.Init();
	            
	    Application.Run(new Form1());
	}

How it works
=
This profiler works by intercepting how the internals of the DbProvider work. This profiler creates a proxy around all the Db*** classes. This allows us to time how long certain commands take to execute, when a connection is established, etc. This library can be configured to include server side query statistics.

More info
=
See [pietervp.com](http://www.pietervp.com) for more info.