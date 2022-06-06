# GOAP
Proyecto de inteligencia artificial mediante GOAP para la asignatura Inteligencia Artificial en Videojuegos.

### Características generales del proyecto
* Inteligencia artificial manejada por GOAP (Goal Oriented Action Planning).
* Tres entidades que interactuan entre sí utilizando este sistema.
* Pequeña escena "City" bajo "Assets/CarCity" de una ciudad donde el usuario puede observar a las entidades y jugar con ellas.

### Entidades
* Entidad Coche (entidades blancas): Sus objetivos son volver a casa después de trabajar, tener el depósito lleno y ser libres en caso de que cometan un crimen. Pululan por la ciudad entre sus hogares y su lugar de trabajo. Necesitan gas para moverse, y si se quedan sin paciencia se pasarán del límite de velocidad:
  * GoToWork: la entidad se dirige al trabajo, agregando dinero al balance.
  * ReturnHome: la entidad vuelve al hogar.
  * WaitForRemolque(lo se, debería ser ReturnForTow o algo): si la entidad no tiene gas, se queda quieta y espera a que venga el remolque.
  * GoToGasStation: La entidad es "remolcada" a la estación de servicio.
  * GoToPrison: la entidad es "arrestada" por el coche de policía y se dirige a su celda.

* Entidad Remolque (entidades verdes): Su objetivo es esperar a que los coches se queden sin gasolina para recogerlos y trasladarlos a la gasolinera, donde regeneran el gas. Sus acciones son:
  * GoToCar: se traslada hasta el coche sin gasolina, que en estos momentos estaría quieto.
  * BringBrokenCarToGasStation: llevar el coche rescatado a la estación de servicio para que recupere gasolina. Esta acción no representa un gasto de dinero, pero toma bastante tiempo si el coche está muy lejos de la grua.
  * ReturnToRepairShop: volver al puesto de guardia.

* Entidad Coche de policia (entidades azules): Su objetivo es esperar a los coches que pierden la paciencia y se pasan del límite de velocidad. Luego los detiene y los traslada a comisaría, donde pagan multa y pasan condena. Las celdas de prisión funcionan mediante inventario. La celda objetivo se traslada y comunica a las entidades y si no hay ninguna disponible, no será posible realizar la acción.
  * GetSpeedingCar: se traslada hasta el coche que se ha pasado del límite de velocidad, que en estos momentos se está moviendo.
  * FollowSpeederToPrison: sigue al criminal a prisión donde se le asigna una celda.
  * ReturnToPolicePost: tras llevar al prisionero a su celda, el coche de policía vuvelve a la estación de guardia.

### Modificaciones a la base GOAP
* Agregada condición follow. Si es verdadera, las entidades actualizan la posición objetivo en cada frame hasta llegar a esta.
* Agregado método para abortar una acción previo a completarla.
* Abortar las acciones que se están ejecutando en ese momento y cesar el movimiento si el coche se queda sin gasolina.
* Abortar las acciones que se están ejecutando en ese momento y aumentar la velocidad si el coche pierde la paciencia.

### Acerca del juego
La escena consta de 4 elementos fundamentales: la ciudad, las entidades, el panel de balance y el panel de mejoras. Las entidades se mueven por la ciudad y realizan sus acciones. Algunas de estas acciones conllevan costes o ingresos, que modifican el balance total de la partida (panel inferior izquierdo en la escena). Podemos optar a mejoras mediante el panel de mejoras (panel superior derecho en la escena). Para poder comprar mejoras nuestro balance deberá ser superior al coste listado por cada mejora.

__________
# ENGLISH
__________

# GOAP
Artificial intelligence project using GOAP for the subject Artificial Intelligence in Video Games.

### General characteristics of the project
* Artificial intelligence managed by GOAP (Goal Oriented Action Planning).
* Three entities that interact with each other using this system.
* Small scene "City" under "Assets/CarCity" of a city where the user can observe the entities and play with them.

### Entities
* Car Entity (white entities): Their goals are to go home after work, to have a full tank of gas and to be free in case they commit a crime. They roam the city between their homes and their place of work. They need gas to get around, and if they run out of patience they will go over the speed limit:
  * GoToWork: the entity heads to work, adding money to the balance sheet.
  * ReturnHome: the entity returns home.
  * WaitForRemolque(I know, it should be ReturnForTow or something): if the entity has no gas, it stands still and waits for the trailer to come.
  * GoToGasStation: The entity is "towed" to the gas station.
  * GoToPrison: The entity is "arrested" by the police car and goes to its cell.

* Entity Tow (green entities): Its objective is to wait for the cars to run out of gas to pick them up and move them to the gas station, where they regenerate the gas. Their actions are:
  * GoToCar: moves to the car out of gas, which would currently be standing still.
  * BringBrokenCarToGasStation: take the rescued car to the gas station to recover gas. This action does not cost any money, but takes a long time if the car is too far away from the tow truck.
  * ReturnToRepairShop: return to the guard post.

* Police Car Entity (blue entities): Its purpose is to wait for cars that lose patience and go over the speed limit. It then stops them and takes them to the police station, where they pay a fine and serve time. Prison cells work through inventory. The target cell is moved and communicated to the entities, and if none is available, the action will not be possible.
  * GetSpeedingCar: moves to the car that has gone over the speed limit, which is currently moving.
  * FollowSpeederToPrison: follows the criminal to prison where he is assigned a cell.
  * ReturnToPolicePost: after taking the prisoner to his cell, the police car returns to the guard station.

### Modifications to the GOAP base
* Added follow condition. If true, entities update the target position every frame until they reach it.
* Added method to abort an action prior to completion.
* Abort actions that are currently running and cease movement if the car runs out of gas.
* Abort currently running actions and increase speed if the car loses patience.

### About the game
The scene consists of 4 main elements: the city, the entities, the balance panel and the upgrade panel. The entities move around the city and perform their actions. Some of these actions involve costs or income, which change the total balance of the game (bottom left panel in the scene). We are eligible for upgrades via the upgrades panel (top right panel in the scene). To be able to buy upgrades our balance must be higher than the cost listed for each upgrade.
