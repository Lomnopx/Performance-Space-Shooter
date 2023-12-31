# Performance-Space-Shooter

The code utilizes some known concepts to avoid performance strain and cluttter.

Some simple like leaveraging scope, avoiding exessive use of calls that return arrays, utilizing [serializefield].

I aslo utilized object pooling for both spawning my bullets and enemies.

The memory profiler has been used to assure that positive performance impact was done on changes made.


---------------------------------------------------------------------



PROGRESSION CONTEXT

When stress testing my project initially there was a lot of instability in fps. 
I tested this by spawning 500 enemies and continually destroying them by shooting 20 bullets per second. 
At this point enemies and bullets were instansiated on creation and destroyed on collition.

The fps varied between 300-800 but stayed around 600-750 average.

I knew that instatiating and destroying creates a lot of memory allocation and needs a lot of garbage collection witch is very resource intensive.
![image](https://github.com/Lomnopx/Performance-Space-Shooter/assets/122265254/3e46e1e9-8485-4f96-b8fc-848acae3f997)




Thus I decided to utilize object pooling. This should eliminate most of this previus strain by re-using the enemies and bullets instead of continually re creating and deleting them.

The outcome of this was a bit more stable fps that hovered around 700-850 average and had signifigantly fewer dips in performance. 
I don't know of a way to accuratly measure the frequency of garbage collection to get raw supporting data outside of fps and general performance, but the size of the collection was considerable smaller now
![image](https://github.com/Lomnopx/Performance-Space-Shooter/assets/122265254/8fc7be13-df61-4681-a0fc-d84adf5cf231)

-----------------------------------------------------------------------------

When using the profiler the main performance users are for physics updates and camera rendering. 
![image](https://github.com/Lomnopx/Performance-Space-Shooter/assets/122265254/b0937ebd-3128-46dc-8a99-6abe88d56864)

I did look into improving the performance of the physics. The main things I learned was making sure to use simple colliders and reducing how often collition occurs.
In the test scenario 500 enemies almost constanly collide so this is understandable within this context. As all object utilize simple colliders I decided to instead focus on rendering


When in comes to rendering. Less objects, simple shaders and sprites is what you want and here that is already very simplified. What can be done here however is lowering screen resulution.
I have an example here where instead of rendering the game in 2k (2560x1440) I reduce that to normal HD (1920x1080) with a small change in performance, and no noticable performance in fps

BEFORE (AVG 35  +-5)
![c1a1deffda2b0abfd48b5933c49fe6c1](https://github.com/Lomnopx/Performance-Space-Shooter/assets/122265254/6316d43a-dad8-4660-85f5-ba731c18d1a7)

AFTER (AVG 30  +-5)
![a68b5fca29f17fdea0550b3fb056fb29](https://github.com/Lomnopx/Performance-Space-Shooter/assets/122265254/eaa9169d-64d3-44d4-85f4-7dba4255170d)

I also tried utilizing lower resulution but it seems like rendering the textures in lower resulution has a higher performance impact
TEST WITH (960x480)
![image](https://github.com/Lomnopx/Performance-Space-Shooter/assets/122265254/9dfeed15-6552-44ef-b9d9-cd4d63b24a2e)

--------------------------------------------------------------------------------

ECS IMPLEMENTATION.

I have now implemented Dots to the project. This required me to remake almost everything witch means that the games systems is diffrent. The game plays out pretty much the same tho and have pretty much the same functionality
Dots in combination with burstcompile allowed me to increase the amount of bullets and enemies toward ridiculous amounts and still have stable framerate. 

In the testscenario I fire a bullet every frame and spawn 100 enemies every second. With this I am still able to stay within 100 fps drifting down towards 50 when the entire screen if full of enemies. 
It's obvius that the performance differance here is massive. However it's not easy to directly compare to the previous result due to the diffrence in tests. When doing a simular test as before I got lower fps (20 bullet's per sec 500 enemies flat). 
But it seems like the standard fps is around 400-500 no matter if I have a lot going on or nothing. This is lower than before but when it comes to spawning in massive amounts the results are incredible.

Performance while screen full of enemies (100 enemies per sec slowly decending) and firing bullet every frame
![a15caf4e834a496a1739549d0501f529](https://github.com/Lomnopx/Performance-Space-Shooter/assets/122265254/72e91f59-7591-41a5-bad9-7cfe5d8ce48a)
