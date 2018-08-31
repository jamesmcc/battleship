
Explanation of some decisions:

1. Why is there no game object ?

I took the requirement of "state-tracker for a single player" meant I just needed to 
make the single player view of the data.

2. Why no matrix for the board ?

I debated about this one alot, but in the end decided to keep the hit logic at the ship level this will
give the flexibility of a really large map and ability to add extra game logic if we wanted to expand 
things like shields etc at the ship level.


