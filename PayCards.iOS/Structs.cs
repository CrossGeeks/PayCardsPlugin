using System;
using ObjCRuntime;

namespace PayCards
{ 
	[Native]
	public enum PayCardsRecognizerResultMode : ulong
	{
		Async,
		Sync
	}

	[Flags]
	[Native]
	public enum PayCardsRecognizerDataMode : ulong
	{
		None = 0x0,
		Number = 0x1,
		Date = 0x2,
		Name = 0x4,
		GrabCardImage = 0x8
	}
}