# FlareChallenge
BattleShip state tracker class, in .net CORE.

Caveats:
1. Ship names must be unique when added. This could be easily catered for in the code obviously.
2. Currently there's no way to identify the type of ship hit/sunk. Again, this could easily be extended to be included.
3. The standard board size of 10x10 is used, unless specifically provided in the setup method call.

StateTracker is the main class to be instantiated for each player.
Unit tests have been provided to test the basic requirements of the challenge.
