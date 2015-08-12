# NSBN-Model
NSBN Model

Before starting the simulation the user can set the initial parameters. These are:
-	The height (in cells) of the world
-	The width (in cells) of the world
-	The K values the initial population will consist of
-	The amount of agents per K value at the start of the simulation
-	The amount of nodes (N) of each agents network
-	The generation when the simulation should automatically be restarted (-1 means no restart)
-	Whether the carnivore percentage is active

The simulation can be started be clicking on “start simulation”. The speed can be adjusted by clicking on the draw or pause buttons.

Every 20 turns a new line will be added to the graphdata.csv file (located at the same location as the .exe). This line holds the following values:
Turn, agent count, food count,
K0 agents count, K1 agents count, K2 agents count, K3 agents count, K4 agents count, K5 agents count, K6 agents count, K7 agents count, K8 agents count, K9 agents count, K10 agents count,

Followed by the word “percentages” and the amount of agents for each carnivore percentage, followed by the word “totalAverage” and the average K value of the total population.

For example:

60,167,4610, 0, 0, 0, 0, 0, 0, 34, 33, 33, 34, 33, 0, 0, 0, 0, 0, 0, 0, 0, 0, percentages, 167, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,totalAverage,7,994012
