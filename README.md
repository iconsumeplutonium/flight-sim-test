#### Description

This is a basic flight simulator I made with simple controls and some instruments. 

![Video](https://cdn.discordapp.com/attachments/690652979036028929/883428311718588466/gif_display.gif)

#### Project Files

This project was written in C# in version 2020.3.12f1 of the Unity engine. To install this project, unzip the folder and add the `Procedural Biome Generation` folder to
your Unity projects folder. Then, simply open it in Unity by hitting `Add` in Unity Hub.


Each aircraft has its own associated "flight profile": how fast it turns, moves,
accelerates, etc. To switch between different aircraft, change the value of "Profile Index" on the FlightController script on the `FlyingObj` gameobject.


![](https://cdn.discordapp.com/attachments/690652979036028929/883393659834339338/unknown.png)

* 1: Cylinder
* 2: X-wing
* 3: Airbus A380

#### Instruments

![](https://cdn.discordapp.com/attachments/690652979036028929/883395459220135957/Untitled.png)

The gauge in the top left shows the angle of the current craft relative to "normal." The yellow line will rotate with the craft and show your rotation relative to the horizon. Speedometer and Altimeter are self-explanatory. 

#### Controls

* W and S: increase or decrease speed
* A and D: Rotate aircraft left or right
* Mouse up/down/left right: move plane up/down/left right

#### Credits

[X-wing Model](https://sketchfab.com/3d-models/x-wing-game-res-uhuZnTJCksW96EYFa92KVZhMY2b)

[Airbus Model](https://sketchfab.com/3d-models/airbus-a380-4dbb5e4cbc7b42fbb74c3bde5491b165)

