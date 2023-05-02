# Sheep Shooter

Welcome to Sheep Shooter, developed from introduction to Scripting tutorial. I've added some functionalities to the game.

1. open the "menu" scene and start the unity simulation.

![image](https://user-images.githubusercontent.com/72511703/235790317-5042dee7-b12e-4add-85bc-1ad45329baa0.png)

2. press Start Game to go shooting sheeps or press Upgrades to consult the upgrades you'll buy when you have points. You gain points each game, 1 point per sheep fed, and each tier of upgrade costs 5 points. You'll see that you have 0 points in upgrades. If you try to buy an upgrade without having at least 5 points or the stat is at max level (5), nothing will happen and the points won't be substracted. To debug, instead of playing the game you can give yourself the points you want here (line 20 of Upgrades script):

![image](https://user-images.githubusercontent.com/72511703/235790881-84a628d5-2f91-4ae4-aee4-f16911bac1a8.png)


2.1. if you are in Upgrades press the button go Back in the top right and once in the menu press Start Game.

3. press space for shooting and left-right to move. As the simulation progresses the spawn rate and the player speed increase, and the bullet cooldown decrease in order to make it more frenetic. However, with upgrades the start will be easier. The current game ends when you press Back To Menu in top right or when you kill 40 sheep. Then you will go to the menu automatically. Both ways are accounted for counting the total points.

4. everytime you press Start Game your counter (the sheeps in that game) is 0, but there is a global counter of the sheeps fed, that you can see in Upgrades. Upgrades are conserved between games.

Developed in Unity 2020.3.47f1
