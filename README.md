# SCP-008

## What is SCP-008?
SCP-008, known as the zombie virus, is contained at various sites.  
It's origin is still unknown to the foundation, but it is widely spread around the world.  

Apparently SCP-049 was able to recreate the virus to some extend and improved its own zombies, called SCP-049-2, with it.  
Anybody hit by said SCP-049-2 will get infected and eventually turned into a zombie.  
In contrast to the original virus SCP-049's version **can** be cured by using any medical item.

***

## Installation
1. [Install Synapse](https://docs.synapsesl.xyz/setup/setup)
2. Place the SCP008.dll file in your plugin directory
3. Restart/Start your server

***

##Configuration
There is not much to configure.  
The first is ```damagePercent```.  
It controls how much damage a player gets per damaging phase.  

The second one is ```damageDelay```.  
It controls the delay between the damaging phases.  
**CAUTION: The delay has to be in milliseconds!**
```yml
damagePercent: 10
damageDelay: 3000
```
