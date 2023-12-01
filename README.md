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

When using the profiler the main performance users are for physics updates and camera rendering. 
![de5652776c704acdadfabd489d8b0924](https://github.com/Lomnopx/Performance-Space-Shooter/assets/122265254/773598f9-bb25-4db2-aadd-5661a42405b4)
I did look into improving the performance of the physics. The main things I learned was making sure to use simple colliders and reducing how often collition occurs.
In the test scenario 500 enemies almost constanly collide so this is understandable within this context.


When in comes to rendering less objects, simple shaders and sprites is what you want and here that is already very simplified. What can be done here however is lowering screen resulution.
I have an example here where instead of rendering the game in 2k (2560x1440) I reduce that to normal HD (1920x1080) with a small change in performance, and no noticable performance in fps

BEFORE
![de5652776c704acdadfabd489d8b0924](https://github.com/Lomnopx/Performance-Space-Shooter/assets/122265254/773598f9-bb25-4db2-aadd-5661a42405b4)
AFTER
![a68b5fca29f17fdea0550b3fb056fb29](https://github.com/Lomnopx/Performance-Space-Shooter/assets/122265254/eaa9169d-64d3-44d4-85f4-7dba4255170d)

I also tried utilizing lower resulution but it seems like rendering the textures in lower resulution has a higher performance impact
TEST WITH (960x480)
![image](https://github.com/Lomnopx/Performance-Space-Shooter/assets/122265254/9dfeed15-6552-44ef-b9d9-cd4d63b24a2e)
